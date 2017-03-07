**iOS:**

Application.dataPath : Application/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/xxx.app/Data

 

Application.streamingAssetsPath : Application/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/xxx.app/Data/Raw

 

Application.persistentDataPath : Application/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/Documents

 

Application.temporaryCachePath : Application/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/Library/Caches

 

 

 

**Android:**

 

Application.dataPath : /data/app/xxx.xxx.xxx.apk

 

Application.streamingAssetsPath : jar:file:///data/app/xxx.xxx.xxx.apk/!/assets

 

Application.persistentDataPath : /data/data/xxx.xxx.xxx/files

 

Application.temporaryCachePath : /data/data/xxx.xxx.xxx/cache

 

 

 

**Windows Web Player:**

 

Application.dataPath : file:///D:/MyGame/WebPlayer (即导包后保存的文件夹，html文件所在文件夹)

 

Application.streamingAssetsPath :

 

Application.persistentDataPath :

 

Application.temporaryCachePath :

---

**Application.dataPath**

Unity Editor: `<path to project folder>/Assets`

Mac player: `<path to player app bundle>/Contents`

iOS player: `<path to player app bundle>/<AppName.app>/Data` (this folder is read only, use Application.persistentDataPath to save data).

Win/Linux player: `<path to executablename_Data folder>` (note that most Linux installations will be case-sensitive!)

WebGL: The absolute url to the player data file folder (without the actual data file name)

Android: Normally it would point directly to the APK. The exception is if you are running a split binary build in which case it points to the the OBB instead.

**Application.streamingAssetsPath**

On a desktop computer (Mac OS or Windows) the location of the files can be obtained with the following code:
 `path = Application.dataPath + "/StreamingAssets";`

On iOS, use:
 `path = Application.dataPath + "/Raw";`

On Android, use:
 `path = "jar:file://" + Application.dataPath + "!/assets/";`

On Android, the files are contained within a compressed .jar file

**Application.persistentDataPath**

Mac: `/Users/<UserName>/Library/Application Support/<Company Name>/<ApplicationName>/`

Windows: `C:\Users\<user_name>\AppData\LocalLow\<company_name>\<product_name>`