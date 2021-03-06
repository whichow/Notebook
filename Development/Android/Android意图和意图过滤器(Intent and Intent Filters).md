# Android意图和意图过滤器(Intent and Intent Filters)
**Intent类型**

Intent分为两种类型：

-   显式 Intent：按名称指定要启动的组件。
-   隐式Intent：不指定特定的组件，而是声明要指定的常规操作，从而允许其他组件来处理它。

创建显式Intent启动Activity或服务时，系统将立即启动Intent对象中指定的应用组件。

创建隐式Intent时，Android系统将通过Intent的内容与在设备上其他应用的清单文件中声明的Intent过滤器进行比较，从而找到要启动的相应组件。

**构建Intent**

Intent对象携带了Android系统用来确定要启动哪个组件的信息，以及接收组件要正确操作而使用的信息。

Intent中包含的主要信息如下：

**组件名称**

要启动的组件名称。如果构建的是显式Intent应当制定组件名称来启动特定的组件。如果没有组件名称，则Intent是隐式的，系统将根据其他Intent信息决定哪个组件接收Intent。

**操作**

指定要执行的通用操作的字符串。如：ACTION_VIEW, ACTION_SEND。使用setAction()或Intent构造函数来指定。

**数据**

引用待操作数据或该数据MIME类型的URI。提供的数据类型通常由Intent的操作决定。仅设置数据URI调用setData()，仅设置MIMEl类型调用setType()，setSataAndType()同时设置二者。

**类别**

包含处理Intent组件类型的附加信息的字符串。

**Extra**

携带完成操作所需的附加信息的键值对。使用putExtra()方法添加附加数据，或者创建一个包含所有附加数据的Bundle对象，然后使用putExtras()将Bundle插入Intent中。

**标志**

在Intent类中定义的、充当Intent元数据的标准。 标志可以指示 Android 系统如何启动 Activity，以及启动之后如何处理。

**显式 Intent 示例**

例如，如果在应用中构建了一个名为 DownloadService、旨在从 Web 中下载文件的服务，则可使用以下代码启动该服务：
```java
// Executed in an Activity, so 'this' is the Context
// The fileUrl is a string URL, such as "http://www.example.com/image.png"
Intent downloadIntent = new Intent(this, DownloadService.class);
downloadIntent.setData(Uri.parse(fileUrl));
startService(downloadIntent);
```
**隐式 Intent 示例**

例如，如果您希望用户与他人共享您的内容，请使用 ACTION_SEND 操作创建 Intent，并添加指定共享内容的 Extra。使用该 Intent 调用 startActivity()时，用户可以选取共享内容所使用的应用。

警告：用户可能没有任何应用处理您发送到 startActivity() 的隐式 Intent。如果出现这种情况，则调用将会失败，且应用会崩溃。要验证 Activity 是否会接收 Intent，请对 Intent 对象调用 resolveActivity()。如果结果为非空，则至少有一个应用能够处理该 Intent，且可以安全调用startActivity()。如果结果为空，则不应使用该 Intent。如有可能，您应禁用发出该 Intent 的功能。
```java
// Create the text message with a string
Intent sendIntent = new Intent();
sendIntent.setAction(Intent.ACTION_SEND);
sendIntent.putExtra(Intent.EXTRA_TEXT, textMessage);
sendIntent.setType("text/plain");
// Verify that the intent will resolve to an activity
if (sendIntent.resolveActivity(getPackageManager()) != null) {
    startActivity(sendIntent);
}
```
>注意：在这种情况下，系统并没有使用 URI，但已声明 Intent 的数据类型，用于指定 Extra 携带的内容。

**接收隐式 Intent**

要公布应用可以接收哪些隐式 Intent，请在清单文件中使用 `<intent-filter>` 元素为每个应用组件声明一个或多个 Intent 过滤器。每个 Intent 过滤器均根据 Intent 的操作、数据和类别指定自身接受的 Intent 类型。仅当隐式 Intent 可以通过 Intent 过滤器之一传递时，系统才会将该 Intent 传递给应用组件。

注意：显式 Intent 始终会传递给其目标，无论组件声明的 Intent 过滤器如何均是如此。

可以使用以下三个元素中的一个或多个指定要接受的 Intent 类型：

`<action>`

     在 name 属性中，声明接受的 Intent 操作。该值必须是操作的文本字符串值，而不是类常量。

`<data>`

     使用一个或多个指定 数据 URI（scheme、host、port、path 等）各个方面和 MIME 类型的属性，声明接受的数据类型。

`<category>`

     在 name 属性中，声明接受的 Intent 类别。该值必须是操作的文本字符串值，而不是类常量。

>注意：为了接收隐式 Intent，必须将 CATEGORY_DEFAULT 类别包括在 Intent 过滤器中。方法 startActivity() 和 startActivityForResult() 将按照已申明 CATEGORY_DEFAULT 类别的方式处理所有 Intent。 如果未在 Intent 过滤器中声明此类别，则隐式 Intent 不会解析为您的 Activity。

例如，以下是一个使用 Intent 过滤器进行的 Activity 声明，当数据类型为文本时，系统将接收 ACTION_SEND Intent ：
```xml
<activity android:name="ShareActivity">
    <intent-filter>
        <action android:name="android.intent.action.SEND"/>
        <category android:name="android.intent.category.DEFAULT"/>
        <data android:mimeType="text/plain"/>
    </intent-filter>
</activity>
```
可以创建一个包括多个 `<action>`、`<data>` 或 `<category>` 实例的过滤器。创建时，仅需确定组件能够处理这些过滤器元素的任何及所有组合即可。。

>警告：为了避免无意中运行不同应用的 Service，请始终使用显式 Intent 启动您自己的服务，且不必为该服务声明 Intent 过滤器。

>注意： 对于所有 Activity，您必须在清单文件中声明 Intent 过滤器。但是，广播接收器的过滤器可以通过调用 registerReceiver() 动态注册。稍后，您可以使用 unregisterReceiver() 注销该接收器。这样一来，应用便可仅在应用运行时的某一指定时间段内侦听特定的广播。


