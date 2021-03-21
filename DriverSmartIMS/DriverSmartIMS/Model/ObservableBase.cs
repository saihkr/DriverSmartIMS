using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace DriverSmartIMS.Model
{
    public class ObservableBase : INotifyPropertyChanged
    {

        protected bool SetProperty<T>(ref T backStore, T Value, [CallerMemberName] string pName = "", Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backStore, Value)) return false;
            backStore = Value;
            onChanged?.Invoke();
            OnPropertyChanged(pName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string pName = "")
        {
            var changed = PropertyChanged;
            if (changed == null) return;
            changed.Invoke(this, new PropertyChangedEventArgs(pName));
        }
        #endregion
    }
}
