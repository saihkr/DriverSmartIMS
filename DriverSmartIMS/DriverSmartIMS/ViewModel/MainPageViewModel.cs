using DriverSmartIMS.Interfaces;
using DriverSmartIMS.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace DriverSmartIMS.ViewModel
{
    public class MainPageViewModel : ObservableBase
    {
        #region Services
        public IFileStorage FileServiceManager = DependencyService.Get<IFileStorage>();
        public IDriverService DriverServiceManager = DependencyService.Get<IDriverService>();
        #endregion

        #region variables
        private HashSet<string> DriverList = new HashSet<string>();
        private List<DriverTripModel> DriverTripDetails = new List<DriverTripModel>();
        #endregion

        #region Properties
        
        private string _driverInfoText;
        public string DriverInfoText
        {
            get { return _driverInfoText; }
            set 
            { 
                SetProperty(ref _driverInfoText, value);
                RunCommand.ChangeCanExecute();
            }
        }

        private ObservableCollection<DriverTripReportModel> _driverTripReport = new ObservableCollection<DriverTripReportModel>();
        public ObservableCollection<DriverTripReportModel> DriverTripReport
        {
            get { return _driverTripReport; }
            set { SetProperty(ref _driverTripReport, value); }
        }

        private bool _showResults;
        public bool ShowResults
        {
            get { return _showResults; }
            set { SetProperty(ref _showResults, value); }
        }
        
        #endregion

        #region Commands
        private Command _runCommand;
        public Command RunCommand { get { return _runCommand = _runCommand ?? new Command(OnRunDriverDetails, CanRunDriverDetails); } }
        #endregion

        public MainPageViewModel() { }

        #region Methods

        public async void Initialize()
        {
            try
            {
                var inputStream = FileServiceManager.GetInputStream("driversinfo.txt");
                if (inputStream != null)
                {
                    using (var reader = new StreamReader(inputStream))
                    {
                        DriverInfoText = reader.ReadToEnd();
                    }
                }
                ShowResults = false;
                DriverTripReport.Clear();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
            }
        }

        private bool CanRunDriverDetails() { return !string.IsNullOrEmpty(DriverInfoText); }

        //
        // Summary:
        //     Generates the drivers trip reports.
        //
        private async void OnRunDriverDetails()
        {
            try
            {
                DriverTripReport.Clear();
                DriverList.Clear();
                DriverTripDetails.Clear();
                var inputValue = DriverInfoText.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                foreach (string val in inputValue)
                {
                    var commands = val.Split(' ');
                    switch (commands[0].ToUpperInvariant())
                    {
                        case "DRIVER":
                            if (commands.Length == 2) DriverList.Add(commands[1]);
                            break;
                        case "TRIP":
                            try
                            {
                                if (commands.Length == 5) DriverTripDetails.Add(new DriverTripModel(commands));
                            }
                            catch(Exception ex){}
                            break;
                    }
                }

                List<DriverTripReportModel> driverTripReport = DriverServiceManager.GetDriverTripReports(DriverList, DriverTripDetails);
                if (driverTripReport.Any()) DriverTripReport = new ObservableCollection<DriverTripReportModel>(driverTripReport);
                ShowResults = DriverTripReport.Any();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
            }
        }
        #endregion

        //
        // Summary:
        //     clears the editor
        //
        public Command ClearCommand => new Command(() => 
        { 
            DriverInfoText = string.Empty;
            ShowResults = false;
            DriverTripReport.Clear();
        });

        //
        // Summary:
        //     To load the editor with text from driverinfo.txt in inputs folder
        //
        public Command ReloadCommand => new Command(() => { Initialize(); });
    }
}
