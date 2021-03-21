# DriverSmartIMS
Provides the driver trips reports

The code will process an input file.

Each line in the input file will start with a command. There are two possible commands.
The first command is Driver, which will register a new Driver in the app. Example: Driver
Dan The second command is Trip, which will record a trip attributed to a driver. The line
will be space delimited with the following fields: the command (Trip), driver name, start
time, stop time, miles driven. Times will be given in the format of hours:minutes. We'll
use a 24-hour clock and will assume that drivers never drive past midnight (the start
time will always be before the end time). Example: Trip Dan 07:15 07:45 17.3 Discard any
trips that average a speed of less than 5 mph or greater than 100 mph. Generate a
report containing each driver with total miles driven and average speed. Sort the output
by most miles driven to least. Round miles and miles per hour to the nearest integer.

# Sample Input
Driver Dan

Driver Alex

Driver Bob

Trip Dan 07:15 07:45 17.3

Trip Dan 06:12 06:32 21.8

Trip Alex 12:01 13:16 42.0

# Sample Output
Alex: 42 miles @ 34 mph

Dan: 39 miles @ 47 mph

Bob: 0 miles

# Supported Targets
UWP, Android & Ios

# Prerequisites to execute 

Inputs can be given in two ways
Procedure 1 :  User can provide the informaion in the editor in line by line format
Procedure 2 : Befure running the program, user can provide the inputs in driverinfo.txt in the path **DriverSmartIMS/DriverSmartIMS/DriverSmartIMS/Inputs**
