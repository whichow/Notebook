Switching the scripting backend to the IL2CPP and using Universal architecture in the player settings solved this problem for me. Here are the steps:

Open up Player Settings either via Edit menu -> Project Settings -> Player or File menu -> Build Settings ... -> Player Settings... button at the bottom. Player Settings will appear in the inspector.

Click on the iPhone, iPod Touch, and iPad settings tab (the icon that looks like an iPhone).

Under Settings for iOS, open up Other Settings

Under the Configuration heading:

For Scripting Backend, select IL2CPP (Defaults to Mono (2.x)).

For Architecture, select Universal.

Now build the Xcode project, and Xcode should compile without errors. If you still encounter errors, ensure Architectures is set to Standard architectures (armv7, arm64) and Valid Architectures is set to "arm64 armv7 armv7s"

[Xcode 5.1.1: missing architectures [arm64]](http://answers.unity3d.com/questions/788331/xcode-511-missing-architectures-arm64.html)

[Upgrading to 64 bit iOS](https://docs.unity3d.com/Manual/iphone-64bit.html)