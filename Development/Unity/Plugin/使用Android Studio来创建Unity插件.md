This is one post which I wanted to write badly, not because it is
difficult but because it is so useful to know how to add the core
Android features which Unity doesn't have built in. In this post we will
be Creating a Share Your Game / App Plugin using Intents. Of course,
this is very simple. But hey, it's pretty useful to let users have the
luxury of sharing your game with just a click.\
\
We will write an Android Activity which will let the users share some
text / description about your game, for instance, the Play Store link to
your game. Isn't that super useful? You bet it is. Let's get started.\
\

### <span>Exporting the jar from the Android Studio for Unity</span>

<div>

Watch the video below to export the jar or simply follow the steps
listed beneath the video\
\
\
\
This step used to be straight forward using Eclipse IDE. However, there
are some modifications to be done in the Gradle file in terms of
creating new tasks so as to be able to export the jar file. Some of them
tend to export the jar by adding a Module. However, TGC will show you a
very simple way to achieve this by adding task to the Gradle which will
let you build the jar using Android Studio.

</div>

<div>

\

</div>

<div>

<span>1. Create a new Android Studio project</span>

</div>

\
\

  -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
  [![](使用Android%20Studio来创建Unity插件_files/newproj.jpg){width="400" height="238"}](http://4.bp.blogspot.com/-IxA4jJeS_dw/VR_wtjfjNHI/AAAAAAAAA9g/Hs68P_0C5mo/s1600/newproj.jpg)

  Fig 1: Android Plugin For Unity <span>using Android Studio</span><span> - New Android Studio Project</span>\
  \
  -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

<span>Create a New Android Studio Project and specify the details as in
Fig 1. Press Next and it should ask you to select the Form Factors the
app will run on. Keep the default settings and press Next. Now, it will
ask you to add an Activity. Keep it to default (Blank Activity) as well
and press Next. We do not want to customize the Activity and we press
Finish. Once you click on Finish, it will take some time to load the new
Project.</span>\
\
<span>2. Add External Jar file as Library in Android Studio</span>\
\
<span>Until it loads, navigate to the following
location </span><span>C:\\Program Files
(x86)\\Unity\\Editor\\Data\\PlaybackEngines\\androidplayer\\release\\bin </span><span>and
copy the </span><span>Classes.jar</span> <span>file.</span>\
\
<span>The Android Studio should have loaded the new project by now.
Switch to the </span><span>Project</span><span> view and you should have
something like the screenshot below</span>\
\

  ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
  [![](使用Android%20Studio来创建Unity插件_files/newproj_2.jpg){width="400" height="208"}](http://4.bp.blogspot.com/-me6v06fKsg4/VR_za7iwdYI/AAAAAAAAA9s/ICJOltmMWFs/s1600/newproj.jpg)

  Fig 2: Android Plugin For Unity <span>using Android Studio </span><span>- Project View</span>\
  \
  \
  ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

<span>Paste the copied Classes.jar file into
the </span><span>libs</span> <span>folder
under </span><span>app</span><span>. Right click on the the Classes.jar
file added and select </span><span>Add as Library</span><span> for us to
use import the UnityPlayerActivity class and other contents of this
jar.</span>\
<span>Many of them don't know how to add an external jar as library in
the Android Studio, well, maybe you can show them how it's done now that
you know it.</span>\
\

  ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
  [![](使用Android%20Studio来创建Unity插件_files/newproj_3.jpg){width="400" height="233"}](http://4.bp.blogspot.com/-wUJrx7pHsrM/VR_00_37BhI/AAAAAAAAA94/QM31wKVf14c/s1600/newproj.jpg)
  Fig 3: Android Plugin For Unity using Android Studio - Add external jar as Library 
  ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

<span>If you have correctly followed the steps, then you should have the
build.gradle file under the </span><span>app</span> <span>folder as
below</span>\
\

    apply plugin: 'com.android.application'

    android {
        compileSdkVersion 21
        buildToolsVersion "21.1.2"

        defaultConfig {
            applicationId "com.thegamecontriver.sharetext"
            minSdkVersion 15
            targetSdkVersion 21
            versionCode 1
            versionName "1.0"
        }
        buildTypes {
            release {
                minifyEnabled false
                proguardFiles getDefaultProguardFile('proguard-android.txt'), 'proguard-rules.pro'
            }
        }
    }

    dependencies {
        compile fileTree(dir: 'libs', include: ['*.jar'])
        compile 'com.android.support:appcompat-v7:21.0.3'
        compile files('libs/classes.jar')
    }

\
<span>The 25th line being the one which is added as a result of adding
the jar as Library.</span>\
\
<span>3. Write code to Share text using Intents</span>\
\
<span>Paste the below code inside
the </span><span>MainActivity.java</span><span> file</span>\
\

<div>

<div>

<div>

<span>[?](#)</span>

</div>

+--------------------------------------+--------------------------------------+
| <div>                                | <div>                                |
|                                      |                                      |
| 1                                    | <div>                                |
|                                      |                                      |
| </div>                               | <span>package</span>                 |
|                                      | <span>com.thegamecontriver.sharetext |
| <div>                                | ;</span>                             |
|                                      |                                      |
| 2                                    | </div>                               |
|                                      |                                      |
| </div>                               | <div>                                |
|                                      |                                      |
| <div>                                |                                      |
|                                      |                                      |
| 3                                    | </div>                               |
|                                      |                                      |
| </div>                               | <div>                                |
|                                      |                                      |
| <div>                                | <span>import</span>                  |
|                                      | <span>android.content.Intent;</span> |
| 4                                    |                                      |
|                                      | </div>                               |
| </div>                               |                                      |
|                                      | <div>                                |
| <div>                                |                                      |
|                                      | <span>import</span>                  |
| 5                                    | <span>com.unity3d.player.UnityPlayer |
|                                      | Activity;</span>                     |
| </div>                               |                                      |
|                                      | </div>                               |
| <div>                                |                                      |
|                                      | <div>                                |
| 6                                    |                                      |
|                                      |                                      |
| </div>                               |                                      |
|                                      | </div>                               |
| <div>                                |                                      |
|                                      | <div>                                |
| 7                                    |                                      |
|                                      | <span>public</span>                  |
| </div>                               | <span>class</span>                   |
|                                      | <span>MainActivity extends</span>    |
| <div>                                | <span>UnityPlayerActivity {</span>   |
|                                      |                                      |
| 8                                    | </div>                               |
|                                      |                                      |
| </div>                               | <div>                                |
|                                      |                                      |
| <div>                                | <span>    </span>                    |
|                                      |                                      |
| 9                                    | </div>                               |
|                                      |                                      |
| </div>                               | <div>                                |
|                                      |                                      |
| <div>                                | <span>    public</span>              |
|                                      | <span>void</span>                    |
| 10                                   | <span>shareText(String subject,      |
|                                      | String body) {</span>                |
| </div>                               |                                      |
|                                      | </div>                               |
| <div>                                |                                      |
|                                      | <div>                                |
| 11                                   |                                      |
|                                      | <span>        Intent sharingIntent = |
| </div>                               | new</span>                           |
|                                      | <span>Intent(android.content.Intent. |
| <div>                                | ACTION\_SEND);</span>                |
|                                      |                                      |
| 12                                   | </div>                               |
|                                      |                                      |
| </div>                               | <div>                                |
|                                      |                                      |
| <div>                                | <span>        sharingIntent.setType( |
|                                      | "text/plain");</span>                |
| 13                                   |                                      |
|                                      | </div>                               |
| </div>                               |                                      |
|                                      | <div>                                |
| <div>                                |                                      |
|                                      | <span>        sharingIntent.putExtra |
| 14                                   | (android.content.Intent.EXTRA\_SUBJE |
|                                      | CT,                                  |
| </div>                               | subject);</span>                     |
|                                      |                                      |
| <div>                                | </div>                               |
|                                      |                                      |
| 15                                   | <div>                                |
|                                      |                                      |
| </div>                               | <span>        sharingIntent.putExtra |
|                                      | (android.content.Intent.EXTRA\_TEXT, |
| <div>                                | body);</span>                        |
|                                      |                                      |
| 16                                   | </div>                               |
|                                      |                                      |
| </div>                               | <div>                                |
|                                      |                                      |
|                                      | <span>        startActivity(Intent.c |
|                                      | reateChooser(sharingIntent,          |
|                                      | "Share via"));</span>                |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div>                                |
|                                      |                                      |
|                                      | <span>    }</span>                   |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div>                                |
|                                      |                                      |
|                                      | <span>    </span>                    |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div>                                |
|                                      |                                      |
|                                      | <span>}</span>                       |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+

</div>

</div>

\
<span>The above class has a
method </span><span>shareText</span> <span>which takes in two string
parameters </span><span>subject</span><span> and </span><span>body</span><span>,
which as they say are the subject and body of the text that is to be
shared.</span>\
\
<span>4. Adding tasks to build.gradle file to export as jar</span>\
\
<span>Change the contents of the build.gradle under the app folder to
the content given below</span>\
\

    //indicates that this is a library
    apply plugin: 'com.android.library'

    android {
        compileSdkVersion 21
        buildToolsVersion "21.1.2"
        sourceSets {
            main {
                //Path to your source code
                java {
                    srcDir 'src/main/java'
                }
            }
        }

        defaultConfig {

            minSdkVersion 15
            targetSdkVersion 21

        }
        buildTypes {
            release {
                minifyEnabled false
                proguardFiles getDefaultProguardFile('proguard-android.txt'), 'proguard-rules.txt'
            }
        }
        lintOptions {
            abortOnError false
        }
    }

    dependencies {
        compile fileTree(dir: 'libs', include: ['*.jar'])
        compile 'com.android.support:appcompat-v7:21.0.3'
        compile files('libs/classes.jar')
    }

    //task to delete the old jar
    task deleteOldJar(type: Delete) {
        delete 'release/AndroidPlugin.jar'
    }

    //task to export contents as jar
    task exportJar(type: Copy) {
        from('build/intermediates/bundles/release/')
        into('release/')
        include('classes.jar')
        ///Rename the jar
        rename('classes.jar', 'AndroidPlugin.jar')
    }

    exportJar.dependsOn(deleteOldJar, build)

\
<span>Resync the project and Rebuild it just to confirm that everything
is all fine.</span>\
<span>Once this is done, you should have a new task created in
the </span><span>Gradle</span><span> tab which will be named
as </span><span>exportJar</span><span>.</span>\
\

  ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
  [![](使用Android%20Studio来创建Unity插件_files/newproj_4.jpg){width="400" height="191"}](http://4.bp.blogspot.com/-gZhLL09yZEI/VR_7zpNn6MI/AAAAAAAAA-I/VqEFRHoZoX8/s1600/newproj.jpg)
  <span>Fig 4: Android Plugin For Unity using Android Studio - Export JAR </span>
  ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

<span>Double click on exportJar and it should start building a jar file.
Once you see the BUILD SUCCESSFUL message in the Run window. Navigate
to </span><span>\\AndroidStudioProjects\\ShareText\\app\\release</span><span> and
you should have a AndroidPlugin.jar file built. That is the file we
needed. That is the plugin which we will be using in our Unity project
to Share text.</span>\
\
<span>Copy this file and navigate to Unity and create a New Folder
called </span><span>Plugins</span><span> under
the </span><span>Assets</span><span> folder of you project. Under the
Plugins folder, create another folder
named </span><span>Android</span><span>. Paste the AndroidPlugin.jar
file under this folder.</span>\
<span>Create a new xml file named AndroidManifest.xml in the same
Android folder and paste the following content</span>\
\

    <?xml version="1.0" encoding="utf-8"?>
    <manifest xmlns:android="http://schemas.android.com/apk/res/android"
          package="com.thegamecontriver.sharetext"
          android:versionCode="1"
          android:versionName="1.0">
        <uses-sdk android:minSdkVersion="9" />
        <application android:label="@string/app_name">
            <activity android:name=".MainActivity"
                      android:label="@string/app_name">
                <intent-filter>
                    <action android:name="android.intent.action.MAIN" />
                    <category android:name="android.intent.category.LAUNCHER" />
                </intent-filter>
            </activity>
        </application>
    </manifest>

\
<span>Save the file and move to Unity. Now, you are ready to use this
Share Feature. You just need to call it from your script.</span>\
\

### <span>Use the JAR in Unity </span>

<span>Create a new C\# Script
named </span><span>ShareApp</span> <span>and add the following code to
it</span>\
\

<div>

<div>

<div>

<span>[?](#)</span>

</div>

+--------------------------------------+--------------------------------------+
| <div>                                | <div>                                |
|                                      |                                      |
| 1                                    | <div>                                |
|                                      |                                      |
| </div>                               | <span>using</span>                   |
|                                      | <span>UnityEngine;</span>            |
| <div>                                |                                      |
|                                      | </div>                               |
| 2                                    |                                      |
|                                      | <div>                                |
| </div>                               |                                      |
|                                      | <span>using</span>                   |
| <div>                                | <span>System.Collections;</span>     |
|                                      |                                      |
| 3                                    | </div>                               |
|                                      |                                      |
| </div>                               | <div>                                |
|                                      |                                      |
| <div>                                |                                      |
|                                      |                                      |
| 4                                    | </div>                               |
|                                      |                                      |
| </div>                               | <div>                                |
|                                      |                                      |
| <div>                                | <span>public</span>                  |
|                                      | <span>class</span> <span>ShareApp :  |
| 5                                    | MonoBehaviour {</span>               |
|                                      |                                      |
| </div>                               | </div>                               |
|                                      |                                      |
| <div>                                | <div>                                |
|                                      |                                      |
| 6                                    |                                      |
|                                      |                                      |
| </div>                               | </div>                               |
|                                      |                                      |
| <div>                                | <div>                                |
|                                      |                                      |
| 7                                    | <span> string</span> <span>subject = |
|                                      | "WORD-O-MAZE";</span>                |
| </div>                               |                                      |
|                                      | </div>                               |
| <div>                                |                                      |
|                                      | <div>                                |
| 8                                    |                                      |
|                                      | <span> string</span> <span>body =    |
| </div>                               | "PLAY THIS AWESOME. GET IT ON THE    |
|                                      | PLAYSTORE";</span>                   |
| <div>                                |                                      |
|                                      | </div>                               |
| 9                                    |                                      |
|                                      | <div>                                |
| </div>                               |                                      |
|                                      |                                      |
| <div>                                |                                      |
|                                      | </div>                               |
| 10                                   |                                      |
|                                      | <div>                                |
| </div>                               |                                      |
|                                      | <span> public</span>                 |
| <div>                                | <span>void</span>                    |
|                                      | <span>callShareApp(){</span>         |
| 11                                   |                                      |
|                                      | </div>                               |
| </div>                               |                                      |
|                                      | <div>                                |
| <div>                                |                                      |
|                                      | <span>  AndroidJavaClass unity =     |
| 12                                   | new</span> <span>AndroidJavaClass    |
|                                      | ("com.unity3d.player.UnityPlayer");< |
| </div>                               | /span>                               |
|                                      |                                      |
| <div>                                | </div>                               |
|                                      |                                      |
| 13                                   | <div>                                |
|                                      |                                      |
| </div>                               | <span>  AndroidJavaObject            |
|                                      | currentActivity =                    |
| <div>                                | unity.GetStatic&lt;AndroidJavaObject |
|                                      | &gt;                                 |
| 14                                   | ("currentActivity");</span>          |
|                                      |                                      |
| </div>                               | </div>                               |
|                                      |                                      |
|                                      | <div>                                |
|                                      |                                      |
|                                      | <span>  currentActivity.Call         |
|                                      | ("shareText", subject, body);</span> |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div>                                |
|                                      |                                      |
|                                      | <span> }</span>                      |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div>                                |
|                                      |                                      |
|                                      | <span>}</span>                       |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+

</div>

</div>

\
<span>Save the script and move back to unity. Attach this script to the
Main Camera.</span>\
<span>Create a new Button and add an On Click event to this button. Drag
and drop the Main Camera under the GameObject field and select
ShareApp-&gt;callShareApp function in the function to be called
field.</span>\
\
<span>Save the scene and now this little app is ready to be tested.
However, there is one last change to be made. The Bundle Identifier
should be changed to the package name that we used while creating the
Android plugin, i.e.,</span><span> </span>com.thegamecontriver.shareapp\
\

  ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
  [![](使用Android%20Studio来创建Unity插件_files/newproj_5.jpg){width="400" height="135"}](http://1.bp.blogspot.com/-klmGkWBC0RY/VSAIv9DvE_I/AAAAAAAAA-Y/rhzeX5UGWBM/s1600/newproj.jpg)
  <span>Fig 5: Android Plugin For Unity using Android Studio - Bundle Identifier</span>
  ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

<span>Once you build the app and test it. On clicking the button you
should get something like the one that is shown screenshot below</span>\
\

  -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
  [![](使用Android%20Studio来创建Unity插件_files/Screenshot_2015-04-03-22-34-42.png){width="225" height="400"}](http://1.bp.blogspot.com/-6cSpm6WTFUM/VSAKOf_pt-I/AAAAAAAAA-k/8Z26E6E6WFg/s1600/Screenshot_2015-04-03-22-34-42.png)
  <span>Fig 5: Android Plugin For Unity using Android Studio - Share App</span>
  -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

<span>Hope this post will be of some use to you guys.</span>\
\
<span>See you around.</span>
