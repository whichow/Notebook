This is one post which I wanted to write badly, not because it is difficult but because it is so useful to know how to add the core Android features which Unity doesn't have built in. In this post we will be Creating a Share Your Game / App Plugin using Intents. Of course, this is very simple. But hey, it's pretty useful to let users have the luxury of sharing your game with just a click.
We will write an Android Activity which will let the users share some text / description about your game, for instance, the Play Store link to your game. Isn't that super useful? You bet it is. Let's get started.

### Exporting the jar from the Android Studio for Unity

Watch the video below to export the jar or simply follow the steps listed beneath the video
This step used to be straight forward using Eclipse IDE. However, there are some modifications to be done in the Gradle file in terms of creating new tasks so as to be able to export the jar file. Some of them tend to export the jar by adding a Module. However, TGC will show you a very simple way to achieve this by adding task to the Gradle which will let you build the jar using Android Studio.

1. Create a new Android Studio project

[TABLE]

Create a New Android Studio Project and specify the details as in Fig 1. Press Next and it should ask you to select the Form Factors the app will run on. Keep the default settings and press Next. Now, it will ask you to add an Activity. Keep it to default (Blank Activity) as well and press Next. We do not want to customize the Activity and we press Finish. Once you click on Finish, it will take some time to load the new Project.
2. Add External Jar file as Library in Android Studio
Until it loads, navigate to the following location C:\\Program Files (x86)\\Unity\\Editor\\Data\\PlaybackEngines\\androidplayer\\release\\bin and copy the Classes.jar file.
The Android Studio should have loaded the new project by now. Switch to the Project view and you should have something like the screenshot below

[TABLE]

Paste the copied Classes.jar file into the libs folder under app. Right click on the the Classes.jar file added and select Add as Library for us to use import the UnityPlayerActivity class and other contents of this jar.
Many of them don't know how to add an external jar as library in the Android Studio, well, maybe you can show them how it's done now that you know it.

|                                                                                                                                                             |
|-------------------------------------------------------------------------------------------------------------------------------------------------------------|
| [![](../../../Images/使用Android%20Studio来创建Unity插件_files/newproj_3.jpg)](http://4.bp.blogspot.com/-wUJrx7pHsrM/VR_00_37BhI/AAAAAAAAA94/QM31wKVf14c/s1600/newproj.jpg) |
| Fig 3: Android Plugin For Unity using Android Studio - Add external jar as Library                                                                          |

If you have correctly followed the steps, then you should have the build.gradle file under the app folder as below

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

The 25th line being the one which is added as a result of adding the jar as Library.
3. Write code to Share text using Intents
Paste the below code inside the MainActivity.java file

[?](#)

[TABLE]

The above class has a method shareText which takes in two string parameters subject and body, which as they say are the subject and body of the text that is to be shared.
4. Adding tasks to build.gradle file to export as jar
Change the contents of the build.gradle under the app folder to the content given below

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

Resync the project and Rebuild it just to confirm that everything is all fine.
Once this is done, you should have a new task created in the Gradle tab which will be named as exportJar.

|                                                                                                                                                             |
|-------------------------------------------------------------------------------------------------------------------------------------------------------------|
| [![](../../../Images/使用Android%20Studio来创建Unity插件_files/newproj_4.jpg)](http://4.bp.blogspot.com/-gZhLL09yZEI/VR_7zpNn6MI/AAAAAAAAA-I/VqEFRHoZoX8/s1600/newproj.jpg) |
| Fig 4: Android Plugin For Unity using Android Studio - Export JAR                                                                                           |

Double click on exportJar and it should start building a jar file. Once you see the BUILD SUCCESSFUL message in the Run window. Navigate to \\AndroidStudioProjects\\ShareText\\app\\release and you should have a AndroidPlugin.jar file built. That is the file we needed. That is the plugin which we will be using in our Unity project to Share text.
Copy this file and navigate to Unity and create a New Folder called Plugins under the Assets folder of you project. Under the Plugins folder, create another folder named Android. Paste the AndroidPlugin.jar file under this folder.
Create a new xml file named AndroidManifest.xml in the same Android folder and paste the following content

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

Save the file and move to Unity. Now, you are ready to use this Share Feature. You just need to call it from your script.

### Use the JAR in Unity 

Create a new C\# Script named ShareApp and add the following code to it

[?](#)

[TABLE]

Save the script and move back to unity. Attach this script to the Main Camera.
Create a new Button and add an On Click event to this button. Drag and drop the Main Camera under the GameObject field and select ShareApp-&gt;callShareApp function in the function to be called field.
Save the scene and now this little app is ready to be tested. However, there is one last change to be made. The Bundle Identifier should be changed to the package name that we used while creating the Android plugin, i.e., com.thegamecontriver.shareapp

|                                                                                                                                                             |
|-------------------------------------------------------------------------------------------------------------------------------------------------------------|
| [![](../../../Images/使用Android%20Studio来创建Unity插件_files/newproj_5.jpg)](http://1.bp.blogspot.com/-klmGkWBC0RY/VSAIv9DvE_I/AAAAAAAAA-Y/rhzeX5UGWBM/s1600/newproj.jpg) |
| Fig 5: Android Plugin For Unity using Android Studio - Bundle Identifier                                                                                    |

Once you build the app and test it. On clicking the button you should get something like the one that is shown screenshot below

|                                                                                                                                                                                                         |
|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| [![](../../../Images/使用Android%20Studio来创建Unity插件_files/Screenshot_2015-04-03-22-34-42.png)](http://1.bp.blogspot.com/-6cSpm6WTFUM/VSAKOf_pt-I/AAAAAAAAA-k/8Z26E6E6WFg/s1600/Screenshot_2015-04-03-22-34-42.png) |
| Fig 5: Android Plugin For Unity using Android Studio - Share App                                                                                                                                        |

Hope this post will be of some use to you guys.
See you around.
