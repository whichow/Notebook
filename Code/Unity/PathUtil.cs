using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditorInternal;
#endif
using System;
using System.IO;

/// <summary>
/// A class which handles various Unity specific paths.
/// 
/// </summary>
public class PathUtil
{
    /// <summary>
    /// Retrieves Application.persistentDataPath depends on the given platform.
    /// 
    /// iOS            - /var/mobile/Applications/[program_ID]/Documents : read/write
    /// Android        - [External] /mnt/sdcard/Android/data/[bundle id]/files : read/write
    ///                  [Internal] /data/data/[bundle id]/files/ : read/write
    /// WEB Player     - /                
    /// Windows Player - [UserDirectory]/AppData/LocalLow/[Company]/[Product Name] : read/write
    /// OSX            - [UserDirectory]/Library/Caches/unity.[Company].[Product] : read/write
    /// Windows Edtor  - [UserDirectory]/AppData/LocalLow/[Company]/[Product] : read/write
    /// Mac Editor     - [UserDirectory]/Library/Caches/unity.[Company].[Product] : read/write
    /// </summary>
    public static string GetDocumentFolderPath()
    {
        return GetDocumentFilePath("");
    }

    /// <summary>
    /// Retrieves a path of combining Application.persistentDataPath with the given filename.
    /// </summary>
    public static string GetDocumentFilePath(string fileName)
    {
        string result = string.Empty;

        if (Application.isEditor)
        {
            string datapath = "Assets";
            string path = Application.dataPath.Substring(0, Application.dataPath.Length - datapath.Length);
            result = Path.Combine(Path.Combine(path, "_doc_"), fileName);
        }
        else if (Application.platform == RuntimePlatform.WindowsPlayer)
        {
            result = Path.Combine(Application.dataPath, fileName);
        }
        else
        {
            result = Path.Combine(Application.persistentDataPath, fileName);
        }

        result = result.Replace('\\', '/');
        return result;
    }

    /// <summary>
    /// Retrieves Application.temporaryCachePath depends on the given platform.
    /// 
    /// iOS            - /var/mobile/Applications/[program_ID]/Library/Caches : read/write
    /// Android        - [External] /mnt/sdcard/Android/data/[bundle id]/cache 
    ///                  [Internal] /data/data/com.xxx.xxx/cache/
    /// WEB Player     - C:\Users\username\AppData\Local\Temp\UnityWebPlayer\log\log_UNIQUEID.txt
    /// Windows Player - %LocalAppData%/Local/Temp/Temp/%Company%/%Product% 
    /// </summary>
    public static string GetTemporaryCacheFolderPath()
    {
        return GetTemporaryCacheFilePath("");
    }

    /// <summary>
    /// Retrieves a path of combining Application.temporaryCachePath with the given filename.
    /// </summary>
    public static string GetTemporaryCacheFilePath(string filename)
    {
        string result = string.Empty;

        if (Application.isEditor)
        {
            string datapath = "Assets";
            string path = Application.dataPath.Substring(0, Application.dataPath.Length - datapath.Length);
            result = Path.Combine(Path.Combine(path, "_temporaryCachePath_"), filename);
            return result = result.Replace('\\', '/');
        }
        else if (Application.platform == RuntimePlatform.WindowsPlayer)
        {
            result = Path.Combine(Application.dataPath, filename);
            return result = result.Replace('\\', '/');
        }
        else
        {
            result = Path.Combine(Application.temporaryCachePath, filename);
            return result = result.Replace('\\', '/');
        }
    }

    /// <summary>
    /// Retrieves Application.streamingAssetsPath depends on the given platform.
    /// 
    /// iOS            - /var/mobile/Applications/[program_ID]/[appname].app/Data/Raw  (read only)
    /// Android        - [External] jar:file:///data/app/[bundle id].apk!/assets  (read only, accessiable via www)
    ///                  [Internal] jar:file:///data/app/[bundle id].apk!/assets  (read only, accessiable via www)
    /// WEB            - Application.streamingAssetsPath : empty
    /// Windows Player - [Exe file]/[Exe file]_Data/StreamingAssets : read/write
    /// OSX Player     - [Exe file].app/Contents/Data/StreamingAssets : read/write
    /// Windows Edtor  - [ProjectDirectory]/Assets/StreamingAssets	: read/write
    /// Mac Editor     - [ProjectDirectory]/Assets/StreamingAssets : read/write
    /// </summary>
    public static string GetStreamingAssetsPath()
    {
        return Application.streamingAssetsPath;
    }

    /// <summary>
    /// Retrieves a path of combining Application.streamingAssetsPath with the given filename.
    /// </summary>
    public static string GetStreamingAssetsFilePath(string fileName)
    {
        string result = Path.Combine(Application.streamingAssetsPath, fileName);
        return result = result.Replace('\\', '/');
    }

    /// <summary>
    /// 
    /// </summary>
    public static string GetApplicationPath()
    {
        if (Application.platform == RuntimePlatform.OSXPlayer)
            return Application.dataPath + "/../../";
        else if (Application.platform == RuntimePlatform.WindowsPlayer)
            return Application.dataPath + "/../";

        return GetTemporaryCacheFolderPath();
    }

    /// <summary>
    /// 
    /// </summary>
    public static string GetApplicationFilePath(string fileName)
    {
        string result = Path.Combine(GetApplicationPath(), fileName);
        return result = result.Replace('\\', '/');
    }

#if UNITY_EDITOR
    /// <summary>
    /// preferences folder 
    /// </summary>
    public static string GetPreferencesFolderPath()
    {
        return InternalEditorUtility.unityPreferencesFolder;
    }

    /// <summary>
    /// editor assembly path 
    /// </summary>
    /// <returns></returns>
    public static string GetEditorAssemblyPath()
    {
        return InternalEditorUtility.GetEditorAssemblyPath();
    }

    /// <summary>
    /// engine assembly path 
    /// </summary>
    public static string GetEngineAssemblyPath()
    {
        return InternalEditorUtility.GetEngineAssemblyPath();
    }

    /// <summary>
    /// layout folder path 
    /// </summary>
    /// <returns></returns>
    public static string GetLayoutFolderPath()
    {
        string result = InternalEditorUtility.unityPreferencesFolder + Path.DirectorySeparatorChar + "Layouts";
        return result = result.Replace('\\', '/');
    }

    /// <summary>
    /// Assetstore download folder path 
    /// </summary>
    public static string GetAssetstoreDownloadPath()
    {
        string path = string.Empty;

        if (SystemInfo.operatingSystem.Contains("Windows"))
        {
            path = InternalEditorUtility.unityPreferencesFolder + Path.DirectorySeparatorChar + "../../Asset Store";
        }
        else if (SystemInfo.operatingSystem.Contains("Mac"))
        {
            path = InternalEditorUtility.unityPreferencesFolder + Path.DirectorySeparatorChar + "../../../Unity/Asset Store";
        }
        else
            Debug.LogError("Unknown platform. Cannot resolve Assetstore download folder for this platform.");

        return Path.GetFullPath(path);
    }

    /// <summary>
    /// editor log path
    /// </summary>
    public static string GetEditorLogPath()
    {
        string path = string.Empty;

        if (SystemInfo.operatingSystem.Contains("Windows"))
        {
            path = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic) + "/../Library/Logs/Unity/";
        }
        else if (SystemInfo.operatingSystem.Contains("Mac"))
        {
            path = Environment.GetEnvironmentVariable("LocalAppData") + "/Unity/Editor/";
        }
        else
            Debug.LogError("Unknown platform. Cannot resolve Log file folder for this platform.");

        return Path.GetFullPath(path);
    }

    /// <summary>
    /// Retrieves path of an external script editor. e.g) path of where VisualStudio etc.
    /// </summary>
    public static string GetExternalScriptEditorPath()
    {
        return InternalEditorUtility.GetExternalScriptEditor();
    }
#endif

}