# Attaching MonoDevelop Debugger To An Android Device
You can attach the MonoDevelop debugger to an Android device with ADB via TCP/IP. The process is described below.

- Enable “USB debugging” on your device and connect the device to your development machine via USB cable. Ensure your device is on the same subnet mask and gateway as your development machine. Also, make sure there are no other active network connections on the device, i.e. disable data access over mobile/cellular network.
- On your development machine, open up your terminal/cmd and navigate to the location of the ADB. You can find the ADB tool in <sdk>/platform-tools/
- Restart host ADB in TCP/IP mode with the following command:
```
adb tcpip 5555
```
This will have enabled ADB over TCP/IP using port 5555. If port 5555 is unavailable, you should use a different port (see ADB.) The following output should be produced:
```
restarting in TCP mode port: 5555
```
- Find out the IP address of your Android device (Settings -> About -> Status) and input the following command:
```
adb connect DEVICEIPADDRESS
```
DEVICEIPADDRESS is the actual IP address of your Android device. This should produce the following output:
```
connected to DEVICEIPADDRESS:5555
```
- Ensure that your device is recognised by inputting the following command:
```
adb devices
```
This should produce the following output:
```
List of devices attached
DEVICEIPADDRESS:5555 device
```
- Build and run your Unity application to the device. Ensure you build your application with Development Build flag enabled and Script Debugging turned on.
- Disconnect the USB cable as the device no longer needs to be connected to your development machine.
- Finally, while the application is running on your device, open your script in MonoDevelop, add a breakpoint, select “Run” -> “Attach to Process” and select your device from the list. (It might take a few seconds for the device to appear in the list. It may not appear in the list if the application is not running or if the device’s display goes to sleep).
For some more details and for troubleshooting, see the Wireless Usage section in the Android developers guide for the ADB.

> Note: The device sends multicast messages and the editor and MonoDevelop subscribe/listen for them. For the process to work, your network will need to be setup correctly for Multicasting.