### iPhone

- Application.persistentDataPath: /var/mobile/Applications/[program_ID]/Documents (read/write)
- Application.dataPath: /var/mobile/Applications/[program_ID]/[appname].app/Data (read only)
- Application.streamingAssetsPath: /var/mobile/Applications/[program_ID]/[appname].app/Data/Raw (read only)
- Application.temporaryCachePath: /var/mobile/Applications/[program_ID]/Library/Caches (read/write)

### Android

#### [External]

- Application.persistentDataPath: /mnt/sdcard/Android/data/[bundle id]/files (read/write)
- Application.dataPath: /data/app/[bundle id-number].apk
- Application.streamingAssetsPath: jar:file:///data/app/[bundle id].apk!/assets (read only, should access via WWW)
- Application.temporaryCachePath: /mnt/sdcard/Android/data/[bundle id]/cache

#### [Internal]

- Application.persistentDataPath: /data/data/[bundle id]/files/ (read/write)
- Application.dataPath: /data/app/[bundle id-number].apk
- Application.streamingAssetsPath: jar:file:///data/app/[bundle id].apk!/assets (read only, should access via WWW)
- Application.temporaryCachePath: /data/data/com.xxx.xxx/cache/

### WEB read only

- Application.persistentDataPath: /
- Application.dataPath: folder in unity3d file
- Application.streamingAssetsPath: empty

### Windows Player

- Application.persistentDataPath: [UserDirectory]/AppData/LocalLow/[Company]/[Product Name] (read/write)
- Application.dataPath: [Exe file]/[Exe file]_Data : read/write
- Application.streamingAssetsPath: [Exe file]/[Exe file]_Data/StreamingAssets (read/write)
- Application.temporaryCachePath: %LocalAppData%/Local/Temp/Temp/%Company%/%Product%

### MAC Player

- Application.persistentDataPath: [UserDirectory]/Library/Caches/unity.[Company].[Product] (read/write)
- Application.dataPath: [Exe file].app/Contents
- Application.streamingAssetsPath: [Exe file].app/Contents/Data/StreamingAssets (read/write)

### Windows Editor

- Application.persistentDataPath: [UserDirectory]/AppData/LocalLow/[Company]/[Product] (read/write)
- Application.dataPath: [ProjectDirectory]/Assets
- Application.streamingAssetsPath: [ProjectDirectory]/Assets/StreamingAssets	(read/write)

### MAC Editor

- Application.persistentDataPath: [UserDirectory]/Library/Caches/unity.[Company].[Product] (read/write)
- Application.dataPath: [ProjectDirectory]/Assets
- Application.streamingAssetsPath: [ProjectDirectory]/Assets/StreamingAssets (read/write)
