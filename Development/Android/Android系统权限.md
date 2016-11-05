Android系统权限
<div>

<div>

使用权限：一个基本的Android应用默认情况下是没有任何权限的，这意味着它不能作出任何不利于用户体验或设备中数据的事情。为了确保使用在设备上受保护的特性，你必须在你应用的manifest中包含一个或多个&lt;uses-permission&gt;标签。

</div>

<div>

例如，一个应用需要监测收到的短信需要指定：

</div>

<div
style="font-size: 13px; margin: 0px 0px 1em; color: rgb(0, 102, 0); font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-family: Consolas, 'Liberation Mono', Menlo, Monaco, Courier, monospace; -webkit-font-smoothing: subpixel-antialiased; padding: 1em; overflow: auto; border: 1px solid rgb(221, 221, 221); letter-spacing: normal; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; background: rgb(247, 247, 247);">

<span style="color: rgb(0, 0, 136);">&lt;manifest</span><span
style="color: rgb(0, 0, 0);"> </span><span
style="color: rgb(136, 34, 136);">xmlns:android</span><span
style="color: rgb(102, 102, 0);">=</span><span
style="color: rgb(136, 0, 0);">"http://schemas.android.com/apk/res/android"</span><span
style="color: rgb(0, 0, 0);">\
   </span> <span style="color: rgb(136, 34, 136);">package</span><span
style="color: rgb(102, 102, 0);">=</span><span
style="color: rgb(136, 0, 0);">"com.android.app.myapp"</span><span
style="color: rgb(0, 0, 0);"> </span><span
style="color: rgb(0, 0, 136);">&gt;</span><span
style="color: rgb(0, 0, 0);">\
   </span> <span
style="color: rgb(0, 0, 136);">&lt;uses-permission</span><span
style="color: rgb(0, 0, 0);"> </span><span
style="color: rgb(136, 34, 136);">android:name</span><span
style="color: rgb(102, 102, 0);">=</span><span
style="color: rgb(136, 0, 0);">"android.permission.RECEIVE\_SMS"</span><span
style="color: rgb(0, 0, 0);"> </span><span
style="color: rgb(0, 0, 136);">/&gt;</span><span
style="color: rgb(0, 0, 0);">\
    ...</span>
<div>

<span style="color: rgb(0, 0, 136);">&lt;/manifest&gt;</span>

</div>

</div>

<div>

定义和执行权限：为了执行你自己的权限，你必须在你的AndroidManifest.xml中用一个或多个&lt;permission&gt;元素来声明它们。例如，一个应用想要控制谁能启动它的一个activity可以用下面的方式：

</div>

<div
style="font-size: 13px; margin: 0px 0px 1em; color: rgb(0, 102, 0); font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-family: Consolas, 'Liberation Mono', Menlo, Monaco, Courier, monospace; -webkit-font-smoothing: subpixel-antialiased; padding: 1em; overflow: auto; border: 1px solid rgb(221, 221, 221); letter-spacing: normal; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; background: rgb(247, 247, 247);">

<span style="color: rgb(0, 0, 136);">&lt;manifest</span><span
style="color: rgb(0, 0, 0);"> </span><span
style="color: rgb(136, 34, 136);">xmlns:android</span><span
style="color: rgb(102, 102, 0);">=</span><span
style="color: rgb(136, 0, 0);">"http://schemas.android.com/apk/res/android"</span><span
style="color: rgb(0, 0, 0);">\
   </span> <span style="color: rgb(136, 34, 136);">package</span><span
style="color: rgb(102, 102, 0);">=</span><span
style="color: rgb(136, 0, 0);">"com.example.myapp"</span><span
style="color: rgb(0, 0, 0);"> </span><span
style="color: rgb(0, 0, 136);">&gt;</span><span
style="color: rgb(0, 0, 0);">\
   </span> <span
style="color: rgb(0, 0, 136);">&lt;permission</span><span
style="color: rgb(0, 0, 0);"> </span><span
style="color: rgb(136, 34, 136);">android:name</span><span
style="color: rgb(102, 102, 0);">=</span><span
style="color: rgb(136, 0, 0);">"com.example.myapp.permission.DEADLY\_ACTIVITY"</span><span
style="color: rgb(0, 0, 0);">\
       </span> <span
style="color: rgb(136, 34, 136);">android:label</span><span
style="color: rgb(102, 102, 0);">=</span><span
style="color: rgb(136, 0, 0);">"@string/permlab\_deadlyActivity"</span><span
style="color: rgb(0, 0, 0);">\
       </span> <span
style="color: rgb(136, 34, 136);">android:description</span><span
style="color: rgb(102, 102, 0);">=</span><span
style="color: rgb(136, 0, 0);">"@string/permdesc\_deadlyActivity"</span><span
style="color: rgb(0, 0, 0);">\
       </span> <span
style="color: rgb(136, 34, 136);">android:permissionGroup</span><span
style="color: rgb(102, 102, 0);">=</span><span
style="color: rgb(136, 0, 0);">"android.permission-group.COST\_MONEY"</span><span
style="color: rgb(0, 0, 0);">\
       </span> <span
style="color: rgb(136, 34, 136);">android:protectionLevel</span><span
style="color: rgb(102, 102, 0);">=</span><span
style="color: rgb(136, 0, 0);">"dangerous"</span><span
style="color: rgb(0, 0, 0);"> </span><span
style="color: rgb(0, 0, 136);">/&gt;</span><span
style="color: rgb(0, 0, 0);">\
    ...\
</span><span style="color: rgb(0, 0, 136);">&lt;/manifest&gt;</span>

</div>

<div>

\

</div>

</div>
