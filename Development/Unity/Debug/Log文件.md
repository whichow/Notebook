Log Files
There might be times during the development when you need to obtain information from the logs of the webplayer you've built, your standalone player, the target device or the editor. Usually you need to see these files when you have experienced a problem and you have to know where exactly the problem occurred.

On Mac the webplayer, player and editor logs can be accessed uniformly through the standard Console.app utility.

On Windows the webplayer and editor logs are place in folders there are not shown in the Windows Explorer by default. Please see the Accessing hidden folders page to resolve that situation.

Editor
Editor log can be brought up through the Open Editor Log button in Unity's Console window.

Mac OS X	`~/Library/Logs/Unity/Editor.log`
Windows XP	`C:\Documents and Settings\username\Local Settings\Application Data\Unity\Editor\Editor.log`
Windows Vista/7	`C:\Users\username\AppData\Local\Unity\Editor\Editor.log`
On Windows, the Editor log file is stored in the local application data folder: `%LOCALAPPDATA%\Unity\Editor\Editor.log`, where LOCALAPPDATA is defined by CSIDL_LOCAL_APPDATA.

  Desktop
On Mac all the logs can be accessed uniformly through the standard Console.app utility.

Webplayer
Mac OS X	`~/Library/Logs/Unity/WebPlayer.log`
Windows XP	`C:\Documents and Settings\username\Local Settings\Temp\UnityWebPlayer\log\log_UNIQUEID.txt`
Windows Vista/7	`C:\Users\username\AppData\Local\Temp\UnityWebPlayer\log\log_UNIQUEID.txt`
Windows Vista/7 + IE7 + UAC	`C:\Users\username\AppData\Local\Temp\Low\UnityWebPlayer\log\log_UNIQUEID.txt`
On Windows the webplayer log is stored in a temporary folder: `%TEMP%\UnityWebPlayer\log\log_UNIQUEID.txt`, where TEMP is defined by GetTempPath.

Player
Mac OS X	`~/Library/Logs/Unity/Player.log`
Windows	`EXECNAME_Data\output_log.txt`
On Windows, EXECNAME_Data is a folder next to the executable with your game.

Note that on Windows standalones the location of the log file can be changed (or logging suppressed.) See the command line page for further details.

iOS
The device log can be accessed in XCode via GDB console or the Organizer Console. The latter is useful for getting crashlogs when your application was not running through the XCode debugger.

Please see Debugging Applications in the iOS Development Guide. Also our Troubleshooting and Bugreporting guides may be useful for you.

Android
The device log can be viewed by using the logcat console. Use the adb application found in Android SDK/platform-tools directory with a trailing logcat parameter:

$ adb logcat

Another way to inspect the LogCat is to use the Dalvik Debug Monitor Server (DDMS). DDMS can be started either from Eclipse or from inside the Android SDK/tools. DDMS also provides a number of other debug related tools.