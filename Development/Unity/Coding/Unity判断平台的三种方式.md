```csharp
using UnityEngine;
#if UNITY_EDITOR 
using UnityEditor; 
#endif 
public class BBApplication : MonoBehaviour { 
	private RuntimePlatform platform 
	{ 
		get 
		{ 
			#if UNITY_ANDROID 
			return RuntimePlatform.Android; 
			#elif UNITY_IOS 
			return RuntimePlatform.IPhonePlayer; 
			#elif UNITY_STANDALONE_OSX 
			return RuntimePlatform.OSXPlayer; 
			#elif UNITY_STANDALONE_WIN 
			return RuntimePlatform.WindowsPlayer; 
			#endif 
		} 
	} 
	public bool isTouchInterface 
	{ 
		get 
		{ 
			#if UNITY_EDITOR // Game is being played in the editor and the selected BuildTarget is either Android or iOS 
			if (EditorUserBuildSettings.activeBuildTarget == BuildTarget.Android || EditorUserBuildSettings.activeBuildTarget == BuildTarget.iOS) 
			{ 
				return true; 
			} 
			#endif // Game is being played on an Android or iOS device 
			if (platform == RuntimePlatform.Android || platform == RuntimePlatform.IPhonePlayer) 
			{ 
				return true; 
			} // Game is being played on something other then an Android or iOS device 
			else 
			{ 
				return false; 
			} 
		} 
	} 
}
```