Unity3D offers a ton of great features for Android projects, but often there are gaps that must be filled with plugins.

Let’s take the example of [Toast](http://developer.android.com/guide/topics/ui/notifiers/toasts.html "Toast") popups for Android.  In your game you might like to show a popup message that explains an error, or states that you are signed in to a server.

Start by creating a new Android library project.  If you’re like me, you’ll be using the command line with a text editor instead of an IDE.

Terminal

Shell

[TABLE]

In your newly created ToastExample.java file add the following source code:

ToastExample.java

Java

[TABLE]

There are a few things to note in the source code.  Because we will be making use of the AndroidJavaObject to represent our instance, we need to create the instance and return it.  The static function instance() will create our instance if it does not already exist by calling the class constructor and then returning it for Unity3D to use.  Beyond the required instance and constructor methods everything thing else is up to your imagination.  In our case we will be creating a Toast popup that requires an activity context.  You can either create a separate function like setContext or require the context as a parameter for showMessage.

To include the plugin in a Unity3D game you must first compile and bundle it into a JAR file.  Again if you’re using a command line to build you can add the following to your build.xml file:

build.xml

Shell

[TABLE]

From this point you can just run ant jar and you will end up with bin/TestPlugin.jar

Assuming that you got no errors on the Java side of things, you can proceed to your Unity3D project.  In your project create Assets/Plugins/Android if it doesn’t already exist.  Unity3D knows to pick up all Android plugins from this location.  Copy your TestPlugin.jar to the plugin location.

Inside your Assets/Scripts directory create a new C\# script called UnityToastExample and include the following code:

UnityToastExample.cs

C\#

[TABLE]

Because we have decided to keep things simple and not extend the UnityPlayerActivity in our Android code, we need to get the current activity from the player.  This is the only way to get the activity context required by our Toast.

Once we have the activity context we can load our class and create the ToastExample object instance.  When the object instance has been created we are now able to call any public function from the class.  The first thing we do is set the context that we got from our current activity.  This is where it can get confusing.  Toast popups are UI features so they are required to run on the UI thread.  This can be done many different ways whether in the Java code or in the Unity code.  In this example it will be done in the Unity3D code.

UnityToastExample.cs

C\#

[TABLE]

Anything in this particular AndroidJavaRunnable will be run on the UI thread.

Attach the UnityToastExample.cs script to a GameObject and build for Android.  If everything went smooth, you should see a Toast popup on your device at launch.  Make sure to only run for Android as you’ll get errors for other platforms.


