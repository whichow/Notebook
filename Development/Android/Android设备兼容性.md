Android设备兼容性
Android设备兼容性分为

-   设备特性
-   平台版本
-   屏幕配置

设备特性：你可以通过在manifest文件中声明&lt;uses-feature&gt;元素来防止那些设备不能提供指定特性的用户来安装你的应用。

例如，如果你的应用不打算被安装在那些缺失罗盘传感器的设备上，你可以在下面的manifest标签中声明罗盘传感器是必须的：

&lt;manifest ... &gt;

    &lt;uses-feature android:name="android.hardware.sensor.compass"
                  android:required="true" /&gt;
    ...
&lt;/manifest&gt;

然而，如果你的应用的主要功能不是必须用到一个设备特性的话，你应该将required属性设置为"false"并且在运行时检测这个设备特性。如果应用特性在该设备上不被支持的话，降低相应的设备特性。例如，你可以调用hasSystemFeature()来查询一个特性是否可用：

PackageManager pm = getPackageManager();
if (!pm.hasSystemFeature(PackageManager.FEATURE\_SENSOR\_COMPASS)) {
    // This device does not have a compass, turn off the compass feature
    disableCompassFeature();
}

平台版本：API level允许你声明你的应用兼容的最低版本，使用&lt;uses-sdk&gt;manifest标签和&lt;minSdkVersion&gt;属性。

例如，Canlendar Provider API在Android 4.0(API level 14)被加入。如果你的应用离开了这些API就不能正常工作的话，你应该声明API level 14作为你的应用最低支持的版本：

&lt;manifest ... &gt;
    &lt;uses-sdk android:minSdkVersion="14" android:targetSdkVersion="19" /&gt;
    ...
&lt;/manifest&gt;

minSdkversion属性声明你的应用兼容的最低版本，targetSdkVersion属性声明你针对你的应用进行过优化的最高版本。

每个连续的Android版本都能够兼容使用之前版本API构建的应用，因此你的应用在使用Android API的时候应该始终兼容最新的Android版本。

注意：targetSdkVersion属性并不会阻止你的应用被安装在高于这个版本的平台上，但是这很重要，因为它给系统指明你的应用是否应该继承在更新版本上的行为。如果你没有更新targetSdkVersion到最新版本，系统运行在最新版本上时会在假定你的应用需要一些向后兼容行为。

然而，如果你的应用使用了最近平台版本新加入的一些API，但是在主要功能上并不是必须的，你应该在运行时检查API level并且在API level太低的时降低相应的特性。这种情况下，设置minSdkVersion到你的应用主要功能使用到的最低版本，然后将当前系统版本SDK\_INT和你想要检查的相应的API level常量Build.VERSION\_CODES比较，例如：

if (Build.VERSION.SDK\_INT &lt; Build.VERSION\_CODES.HONEYCOMB) {
    // Running on something older than API level 11, so disable
    // the drag/drop features that use `ClipboardManager` APIs
    disableDragAndDrop();
}

屏幕配置：Android使用两个特性来给不同设备的屏幕类型分类：屏幕尺寸和屏幕分辨率。Android将这些不同类型归纳为组：

-   四种广义的尺寸：small,normal,large和xlarge。
-   一些广义的分辨率：mdpi,hdpi,xhdpi,xxhdpi和其他。

默认情况下，你的应用将兼容所有屏幕尺寸和分辨率，因为系统对你的UI布局和图片资源在需要时做适当的调整。然而，你应当通过为每种屏幕配置增加专门的布局和为常用屏幕分辨率优化位图图像来优化用户体验。


