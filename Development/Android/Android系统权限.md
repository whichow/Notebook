# Android系统权限
使用权限：一个基本的Android应用默认情况下是没有任何权限的，这意味着它不能作出任何不利于用户体验或设备中数据的事情。为了确保使用在设备上受保护的特性，你必须在你应用的manifest中包含一个或多个&lt;uses-permission&gt;标签。

例如，一个应用需要监测收到的短信需要指定：
```xml
<manifest xmlns:android="http://schemas.android.com/apk/res/android"
    package="com.android.app.myapp" >
    <uses-permission android:name="android.permission.RECEIVE\_SMS" />
    ...
</manifest>
```
定义和执行权限：为了执行你自己的权限，你必须在你的AndroidManifest.xml中用一个或多个&lt;permission&gt;元素来声明它们。例如，一个应用想要控制谁能启动它的一个activity可以用下面的方式：
```xml
<manifest xmlns:android="http://schemas.android.com/apk/res/android"
    package="com.example.myapp" >
    <permission android:name="com.example.myapp.permission.DEADLY\_ACTIVITY"
        android:label="@string/permlab\_deadlyActivity"
        android:description="@string/permdesc\_deadlyActivity"
        android:permissionGroup="android.permission-group.COST\_MONEY"
        android:protectionLevel="dangerous" />
    ...
</manifest>
```

