 {#section style="margin: 0px 0px 10px; padding: 0px; word-wrap: break-word;"}

<span data-wiz-span="data-wiz-span">平台定义</span>
===================================================

<span data-wiz-span="data-wiz-span">Unity支持的平台定义有：</span>
------------------------------------------------------------------

<div>

  Property:                                                Function:
  -------------------------------------------------------- ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
  <span class="doc-prop">UNITY\_EDITOR</span>              Define for calling Unity Editor scripts from your game code.
  <span class="doc-prop">UNITY\_EDITOR\_WIN</span>         Platform define for editor code on Windows.
  <span class="doc-prop">UNITY\_EDITOR\_OSX</span>         Platform define for editor code on Mac OSX.
  <span class="doc-prop">UNITY\_STANDALONE\_OSX</span>     Platform define for compiling/executing code specifically for Mac OS (This includes Universal, PPC and Intel architectures).
  <span class="doc-prop">UNITY\_STANDALONE\_WIN</span>     Use this when you want to compile/execute code for Windows stand alone applications.
  <span class="doc-prop">UNITY\_STANDALONE\_LINUX</span>   Use this when you want to compile/execute code for Linux stand alone applications.
  <span class="doc-prop">UNITY\_STANDALONE</span>          Use this to compile/execute code for any standalone platform (Mac, Windows or Linux).
  <span class="doc-prop">UNITY\_WEBPLAYER</span>           Platform define for web player content (this includes Windows and Mac Web player executables).
  <span class="doc-prop">UNITY\_WII</span>                 Platform define for compiling/executing code for the Wii console.
  <span class="doc-prop">UNITY\_IOS</span>                 Platform define for compiling/executing code for the iOS platform.
  <span class="doc-prop">UNITY\_IPHONE</span>              Deprecated. Use <span class="doc-prop">UNITY\_IOS</span> instead.
  <span class="doc-prop">UNITY\_ANDROID</span>             Platform define for the Android platform.
  <span class="doc-prop">UNITY\_PS3</span>                 Platform define for running PlayStation 3 code.
  <span class="doc-prop">UNITY\_PS4</span>                 Platform define for running PlayStation 4 code.
  <span class="doc-prop">UNITY\_XBOX360</span>             Platform define for executing Xbox 360 code.
  <span class="doc-prop">UNITY\_XBOXONE</span>             Platform define for executing Xbox One code.
  <span class="doc-prop">UNITY\_BLACKBERRY</span>          Platform define for a Blackberry10 device.
  <span class="doc-prop">UNITY\_TIZEN</span>               Platform define for the Tizen platform.
  <span class="doc-prop">UNITY\_WP8</span>                 Platform define for Windows Phone 8.
  <span class="doc-prop">UNITY\_WP8\_1</span>              Platform define for Windows Phone 8.1.
  <span class="doc-prop">UNITY\_WSA</span>                 Platform define for Windows Store Apps (additionally <span class="doc-prop">NETFX\_CORE</span> is defined when compiling C\# files against .NET Core).
  <span class="doc-prop">UNITY\_WSA\_8\_0</span>           Platform define for Windows Store Apps when targeting SDK 8.0.
  <span class="doc-prop">UNITY\_WSA\_8\_1</span>           Platform define for Windows Store Apps when targeting SDK 8.1.
  <span class="doc-prop">UNITY\_WSA\_10\_0</span>          Platform define for Windows Store Apps when targeting Universal Windows 10 Apps (additionally WINDOWS\_UWP and NETFX\_CORE is defined when compiling C\# files against .NET Core).
  <span class="doc-prop">UNITY\_WINRT</span>               Equivalent to <span class="doc-prop">UNITY\_WP8</span> | <span class="doc-prop">UNITY\_WSA</span>.
  <span class="doc-prop">UNITY\_WINRT\_8\_0</span>         Equivalent to <span class="doc-prop">UNITY\_WP8</span> | <span class="doc-prop">UNITY\_WSA\_8\_0</span>.
  <span class="doc-prop">UNITY\_WINRT\_8\_1</span>         Equivalent to <span class="doc-prop">UNITY\_WP\_8\_1</span> | <span class="doc-prop">UNITY\_WSA\_8\_1</span>. It’s also defined when compiling against Universal SDK 8.1.
  <span class="doc-prop">UNITY\_WINRT\_10\_0</span>        Same as <span class="doc-prop">UNITY\_WSA\_10\_0</span>
  <span class="doc-prop">UNITY\_WEBGL</span>               Platform define for WebGL.
  <span class="doc-prop">UNITY\_ANALYTICS</span>           Define for calling Unity Analytics methods from your game code. Version 5.2 and above.

<span data-wiz-span="data-wiz-span">与Unity版本的相关定义有：</span>
--------------------------------------------------------------------

</div>

<div>

\
  ---------------------------------------------- -----------------------------------------------------
  <span class="doc-prop">UNITY\_2\_6</span>      Platform define for the major version of Unity 2.6.
  <span class="doc-prop">UNITY\_2\_6\_1</span>   Platform define for specific version 2.6.1.
  <span class="doc-prop">UNITY\_3\_0</span>      Platform define for the major version of Unity 3.0.
  <span class="doc-prop">UNITY\_3\_0\_0</span>   Platform define for specific version 3.0.0.
  <span class="doc-prop">UNITY\_3\_1</span>      Platform define for major version of Unity 3.1.
  <span class="doc-prop">UNITY\_3\_2</span>      Platform define for major version of Unity 3.2.
  <span class="doc-prop">UNITY\_3\_3</span>      Platform define for major version of Unity 3.3.
  <span class="doc-prop">UNITY\_3\_4</span>      Platform define for major version of Unity 3.4.
  <span class="doc-prop">UNITY\_3\_5</span>      Platform define for major version of Unity 3.5.
  <span class="doc-prop">UNITY\_4\_0</span>      Platform define for major version of Unity 4.0.
  <span class="doc-prop">UNITY\_4\_0\_1</span>   Platform define for specific version 4.0.1.
  <span class="doc-prop">UNITY\_4\_1</span>      Platform define for major version of Unity 4.1.
  <span class="doc-prop">UNITY\_4\_2</span>      Platform define for major version of Unity 4.2.
  <span class="doc-prop">UNITY\_4\_3</span>      Platform define for major version of Unity 4.3.
  <span class="doc-prop">UNITY\_4\_5</span>      Platform define for major version of Unity 4.5.
  <span class="doc-prop">UNITY\_4\_6</span>      Platform define for major version of Unity 4.6.
  <span class="doc-prop">UNITY\_5\_0</span>      Platform define for major version of Unity 5.0.
  ---------------------------------------------- -----------------------------------------------------

<div style="margin: 0px 0px 15px; padding: 0px; max-width: 1100px;">

<span
data-wiz-span="data-wiz-span">你可以使用DEVELOPMENT\_BUILD定义来表明发布的时候是否选中了“Development
Build”选项</span>

</div>

 {#section-1 style="margin-top: 0px; margin-bottom: 15px; padding-top: 10px;"}

<div>

测试预定义代码：

</div>

<span style="font-weight: normal;"><span data-wiz-span="data-wiz-span"
style="font-size: 1rem;">可以通过选择目标平台来在Unity
Editor中测试平台相关的代码</span>\
<span data-wiz-span="data-wiz-span" style="font-size: 1rem;">在菜单File
&gt;Build Settings. 打开 Build Settings 窗口：</span></span>

![Build Settings window with the WebPlayer Selected as Target
platform.](Unity平台相关的预编译宏定义_files/0.3209067168645561.png)
<span
style="font-size: 1.33rem; line-height: 1.6; font-weight: normal;"><span
data-wiz-span="data-wiz-span"
style="font-size: 1rem;">选择要测试的平台，点击 Switch
Platform来切换到目标平台。</span></span>

<span style="line-height: 1.6;">自定义</span>平台的宏定义： {#自定义平台的宏定义 style="margin: 0px 0px 15px; padding: 0px; max-width: 1100px;"}
-----------------------------------------------------------

可以通过Unity编辑器内置的选项来定义自己的宏定义. 在相关平台的 Player
Settings 的 <span class="doc-keyword">Other Settings</span> 面板中
,你将看到 Scripting Define Symbols 文本框

![](Unity平台相关的预编译宏定义_files/c72e5d28-7f35-497c-9dbd-e536798abd91.png)
在这里可以输入你要定义的符号来定义指定的平台的宏定义，用分号隔开，这些符号可以用在宏定义的条件判断中。

自定义全局的宏定义： {#自定义全局的宏定义 style="margin: 0px 0px 15px; padding: 10px 0px 0px;"}
--------------------

你可以定义预处理指令来控制哪段代码会被编译.。可以通过在<span
style="line-height: 1.6;">“Assets/”</span><span
style="line-height: 1.6;">文件夹中添加</span><span
style="line-height: 1.6;">一个文本文件来实现.。文件的名字取决于你使用的语言，并使用.rsp作为文件的扩展名：</span><span
style="line-height: 1.6;"></span>

  ---------------------- --------------------------------------
  C\#                    &lt;Project Path&gt;/Assets/smcs.rsp
  C\# - Editor Scripts   &lt;Project Path&gt;/Assets/gmcs.rsp
  UnityScript            &lt;Project Path&gt;/Assets/us.rsp
  ---------------------- --------------------------------------

举个例子，如果你使用单独的一行“<span
style="font-size: 1em;">-define:UNITY\_DEBUG</span>”在你的smcs.rsp文件中，将定义<span
style="font-size: 1em;">UNITY\_DEBUG</span>作为一个全局的宏定义在<span
style="line-height: 1.6;">Editor以外的</span><span
style="line-height: 1.6;">C\#脚本中。还可以通过</span><span
style="line-height: 1.6;">-unsafe来使用不安全的代码。</span>

<div>

来源： &lt;<http://docs.unity3d.com/Manual/PlatformDependentCompilation.html>&gt;

</div>

 

</div>
