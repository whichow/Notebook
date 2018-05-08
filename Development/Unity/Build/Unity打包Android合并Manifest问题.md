- Manifest merger failed : Attribute application@label value=(@string/app_name)

原因：可能是使用到的第三方库中包含的Manifest中也有`android:label`这个属性，导致无法合并Manifest。

解决方法：编辑AndroidManifest.xml在  
`manifest`中加上`xmlns:tools="http://schemas.android.com/tools"`  
`application`中加上`tools:replace="android:label"`  
```
如：
```xml
<?xml version="1.0" encoding="utf-8"?>  
<manifest  
    xmlns:android="http://schemas.android.com/apk/res/android"  
    xmlns:tools="http://schemas.android.com/tools"  
    ...>
    <application
        android:label="@string/app_name"
        tools:replace="android:label"
        ...>
    </application>
</manifest>
```
或者删掉其中一个Manifest中的`android:label`属性

[Manifest merger failed : Attribute application@label value=(@string/app_name)](https://blog.csdn.net/goodmentc/article/details/51088621)