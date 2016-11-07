1.新建一个Android工程，注意这里的包名一定要和Unity里的一样，Minimum Required SDK最好选择4.0以上，
![](Unity%20Android平台开机自启动_files/baf0e5c0-395b-4b8c-beb6-5b29d5f4a81b.png)

选择Mark this project as a library，
![](Unity%20Android平台开机自启动_files/92a29718-3f69-45a3-b7aa-50a4b1173fd6.png)

将Unity里的classes.jar包导入到Android工程里，

![](Unity%20Android平台开机自启动_files/fdc5573a-6e70-412a-9524-3a7272b61f9d.png)

新建一个Activity或者将MainActivity修改为继承自UnityPlayerActivity，删除掉this.setContentView方法，保留super.onCreate方法，

``` prettyprint
package com.wuhao.testplugin;import com.unity3d.player.UnityPlayerActivity;import android.os.Bundle;import android.widget.Toast;public class MainActivity extends UnityPlayerActivity {    @Override    protected void onCreate(Bundle savedInstanceState) {        super.onCreate(savedInstanceState);        Toast.makeText(this, "Hello", Toast.LENGTH_LONG).show();    }}
```

新建一个BroadcastReceive，在onReceive方法中接收到开机启动的广播时，启动继承自UnityPlayerActivity的Activity，

``` prettyprint
package com.wuhao.testplugin;import android.content.BroadcastReceiver;import android.content.Context;import android.content.Intent;public class BootCompletedReceiver extends BroadcastReceiver {    @Override    public void onReceive(Context context, Intent intent) {     if(intent.getAction().equals(Intent.ACTION_BOOT_COMPLETED)) {
          Intent newIntent = new Intent(context, MainActivity.class);            newIntent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);         context.startActivity(newIntent);        }    }}
```

将工程Build后Export，选择JAR file

![](Unity%20Android平台开机自启动_files/94b91c64-efa2-4f81-8da4-4abec9ca5ee0.png)

导出设置如下：

![](Unity%20Android平台开机自启动_files/63a54ce2-9f35-48b8-ac3d-c613f02cc7a0.png)

将导出的jar包和res文件夹复制到Unity的Assets/Plugins/Android目录下，并将Unity里的AndroidManifest.xml文件也复制到该目录下，

![](Unity%20Android平台开机自启动_files/f9cd75d8-d881-4598-a72f-e783e9a99f69.png)

修改AndroidManifest，修改包名，将Activity修改为继承自UnityPlayerActivity的Activity，添加开机启动的BroadcastReceiver，添加广播接收权限，

``` prettyprint
<?xml version="1.0" encoding="utf-8"?><manifest    xmlns:android="http://schemas.android.com/apk/res/android"    package="com.wuhao.testplugin" android:installLocation="preferExternal"    android:versionCode="1"    android:versionName="1.0">    <supports-screens        android:smallScreens="true"        android:normalScreens="true"        android:largeScreens="true"        android:xlargeScreens="true"        android:anyDensity="true"/>    <uses-permission android:name="android.permission.RECEIVE_BOOT_COMPLETED" />         <application      android:theme="@android:style/Theme.NoTitleBar.Fullscreen"      android:icon="@drawable/app_icon"        android:label="@string/app_name"        android:debuggable="true">        <activity android:name="com.wuhao.testplugin.MainActivity"                  android:label="@string/app_name">            <intent-filter>                <action android:name="android.intent.action.MAIN" />                <category android:name="android.intent.category.LAUNCHER" />                <category android:name="android.intent.category.LEANBACK_LAUNCHER" />            </intent-filter>            <meta-data android:name="unityplayer.UnityActivity" android:value="true" />            <meta-data android:name="unityplayer.ForwardNativeEventsToDalvik" android:value="false" />        </activity>        <receiver android:name="com.wuhao.testplugin.BootCompletedReceiver">            <intent-filter>                <action android:name="android.intent.action.BOOT_COMPLETED" />            </intent-filter>        </receiver>    </application></manifest>
```

编译成APK之前注意修改Unity里的包名，

![](Unity%20Android平台开机自启动_files/e02b3b17-eda6-4ee0-ba7d-1ec66918c1ef.png)


