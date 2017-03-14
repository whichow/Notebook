# Log Files
There might be times during development when you need to obtain information from the logs of the standalone player you’ve built, the target device, or the Editor. Usually you need to see these files when you have experienced a problem, to find out exactly where the problem occurred.

On macOS, the player and Editor logs can be accessed uniformly through the standard Console.app utility.

On Windows, the Editor logs are placed in folders which are not shown in the Windows Explorer by default. See below.

## Editor

To view the Editor log, select Open Editor Log in Unity’s Console window.

OS	Log files
macOS	~/Library/Logs/Unity/Editor.log
Windows XP	C:\Documents and Settings\username\Local Settings\Application Data_\Unity\Editor\Editor.log
Windows Vista/7	C:\Users\username\AppData\Local\Unity\Editor\Editor.log
On macOS, all the logs can be accessed uniformly through the standard Console.app utility.

On Windows, the Editor log file is stored in the local application data folder <LOCALAPPDATA>\Unity\Editor\Editor.log, where <LOCALAPPDATA> is defined by CSIDL_LOCAL_APPDATA.

## Player

|OS	|Log files|
|---|---------|
|macOS	|~/Library/Logs/Unity/Player.log|
|Windows	|_EXECNAME_Data_\output_log.txt|
|Windows (Low Integrity Level)|	%USERPROFILE%\AppData\LocalLow\CompanyName\ProductName\output_log.txt|
|Linux	|~/.config/unity3d/CompanyName/ProductName/Player.log|
On Windows, EXECNAME_Data is a folder next to the executable with your game.

Note that on Windows and Linux standalones, the location of the log file can be changed (or logging suppressed). See documenttion on Command line arguments for further details.

## iOS

Access the device log in XCode via the GDB console or the Organizer Console. The latter is useful for getting crashlogs when your application was not running through the XCode debugger.

The Troubleshooting and Reporting crash bugs guides may be useful for you.

## Android

Access the device log using the logcat console. Use the adb application found in Android SDK/platform-tools directory with a trailing logcat parameter:
```
$ adb logcat
```
Another way to inspect the LogCat is to use the Dalvik Debug Monitor Server (DDMS). DDMS can be started either from Eclipse or from inside the Android SDK/tools. DDMS also provides a number of other debug related tools.

Accessing log files on Windows

On Windows, the log files are stored in locations that are hidden by default. In Windows XP, make hidden folders visible in Windows Explorer using Tools > Folder Options… > View (tab).

On Windows Vista/7, make the AppData folder visible in Windows Explorer using Tools > Folder Options… > View (tab). The Tools menu is hidden by default; press the Alt key once to display it.