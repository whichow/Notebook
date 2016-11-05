 {#section style="font-size: 24px; line-height: 28px; margin-top: 0px; margin-bottom: 0px; color: rgb(53, 47, 40); font-family: Verdana, Geneva, sans-serif; font-variant-ligatures: normal; orphans: 2; widows: 2; background-color: rgb(255, 255, 255);"}

<div class="content"
style="padding: 10px 0px; color: rgb(53, 47, 40); font-family: Verdana, Geneva, sans-serif; font-size: 12px; font-variant-ligatures: normal; orphans: 2; widows: 2; background-color: rgb(255, 255, 255);">

<div style="color:gray">

Unity Standalone Player command line arguments {#unity-standalone-player-command-line-arguments style="margin-top: 0px; margin-bottom: 15px; padding-top: 10px; font-size: 1.5em; line-height: 1em; color: rgb(27, 34, 41); font-family: 'Open Sans', sans-serif; font-variant-ligatures: normal;"}
----------------------------------------------

Standalone players built with Unity also understand some command line
arguments:

+--------------------------------------+--------------------------------------+
| <span                                | <span                                |
| style="font-weight: 700;">Command</s | style="font-weight: 700;">Details</s |
| pan>                                 | pan>                                 |
+======================================+======================================+
| <span                                | Allows the game to run full-screen   |
| style="font-weight: 700;">-adapter N | on another display. The N maps to a  |
| (Windows only)</span>                | Direct3D display adaptor. In most    |
|                                      | cases there is a one-to-one          |
|                                      | relationship between adapters and    |
|                                      | video cards. On cards that support   |
|                                      | multi-head (that is, they can drive  |
|                                      | multiple monitors from a single      |
|                                      | card) each “head” may be its own     |
|                                      | adapter.                             |
+--------------------------------------+--------------------------------------+
| <span                                | Run the game in “headless” mode. The |
| style="font-weight: 700;">-batchmode | game does not display anything or    |
| </span>                              | accept user input. This is mostly    |
|                                      | useful for running servers           |
|                                      | for[networked                        |
|                                      | games](https://docs.unity3d.com/Manu |
|                                      | al/NetworkReferenceGuide.html).      |
+--------------------------------------+--------------------------------------+
| <span                                | Force the game to use Direct3D 9 for |
| style="font-weight: 700;">-force-d3d | rendering. Normally, the graphics    |
| 9                                    | API depends on player settings, and  |
| (Windows only)</span>                | typically defaults to D3D11.         |
+--------------------------------------+--------------------------------------+
| <span                                | Force the game to run using          |
| style="font-weight: 700;">-force-d3d | Direct3D’s “Reference” software      |
| 9-ref                                | renderer. The [DirectX               |
| (Windows only)</span>                | SDK](http://msdn.microsoft.com/en-us |
|                                      | /directx/default.aspx) has           |
|                                      | to be installed for this to work.    |
|                                      | This is mostly useful for building   |
|                                      | automated test suites, where you     |
|                                      | want to ensure rendering is exactly  |
|                                      | the same no matter what graphics     |
|                                      | card is being used.                  |
+--------------------------------------+--------------------------------------+
| <span                                | Force the game to use Direct3D 11    |
| style="font-weight: 700;">-force-d3d | for rendering.                       |
| 11                                   |                                      |
| (Windows only)</span>                |                                      |
+--------------------------------------+--------------------------------------+
| <span                                | Force DirectX 11.0 to be created     |
| style="font-weight: 700;">-force-d3d | without                              |
| 11-no-singlethreaded</span>          | a `D3D11_CREATE_DEVICE_SINGLETHREADE |
|                                      | D`{style="font-size: 1em; padding: 1 |
|                                      | px 1px 0px 0px; background: rgb(240, |
|                                      |  240, 240);"} flag.                  |
+--------------------------------------+--------------------------------------+
| <span                                | Force the game to use OpenGL for     |
| style="font-weight: 700;">-force-ope | rendering, even if Direct3D is       |
| ngl                                  | available. Usually, OpenGL is only   |
| (Windows only)</span>                | used if Direct3D 9.0c is not         |
|                                      | available.                           |
+--------------------------------------+--------------------------------------+
| <span                                | Force the Editor to use OpenGL core  |
| style="font-weight: 700;">-force-glc | profile for rendering. The Editor    |
| ore                                  | tries to use on the best OpenGL      |
| (Windows only)</span>                | version available and all OpenGL     |
|                                      | extensions exposed by the OpenGL     |
|                                      | drivers. If the platform isn’t       |
|                                      | supported, Direct3D is used.         |
+--------------------------------------+--------------------------------------+
| <span                                | Similar                              |
| style="font-weight: 700;">-force-glc | to `-force-glcore`{style="font-size: |
| oreXY                                |  1em; padding: 1px 1px 0px 0px; back |
| (Windows only)</span>                | ground: rgb(240, 240, 240);"},       |
|                                      | but requests a specific OpenGL       |
|                                      | context version. Accepted values for |
|                                      | XY: 32, 33, 40, 41, 42, 43, 44 or    |
|                                      | 45.                                  |
+--------------------------------------+--------------------------------------+
| <span                                | Used together                        |
| style="font-weight: 700;">-force-cla | with `-force-glcoreXY`{style="font-s |
| mped                                 | ize: 1em; padding: 1px 1px 0px 0px;  |
| (Windows only)</span>                | background: rgb(240, 240, 240);"},   |
|                                      | this prevents checking for           |
|                                      | additional OpenGL extensions,        |
|                                      | allowing it to run between platforms |
|                                      | with the same code paths.            |
+--------------------------------------+--------------------------------------+
| <span                                | When running in batch mode, do not   |
| style="font-weight: 700;">-nographic | initialize graphics device at all.   |
| s</span>                             | This makes it possible to run your   |
|                                      | automated workflows on machines that |
|                                      | don’t even have a GPU.               |
+--------------------------------------+--------------------------------------+
| <span                                | Do not produce an output log.        |
| style="font-weight: 700;">-nolog     | Normally `output_log.txt`{style="fon |
| (Linux & Windows only)</span>        | t-size: 1em; padding: 1px 1px 0px 0p |
|                                      | x; background: rgb(240, 240, 240);"} |
|                                      |  is                                  |
|                                      | written in                           |
|                                      | the `*_Data`{style="font-size: 1em;  |
|                                      | padding: 1px 1px 0px 0px; background |
|                                      | : rgb(240, 240, 240);"} folder       |
|                                      | next to the game executable,         |
|                                      | where [Debug.Log](https://docs.unity |
|                                      | 3d.com/ScriptReference/Debug.Log.htm |
|                                      | l)output                             |
|                                      | is printed.                          |
+--------------------------------------+--------------------------------------+
| <span                                | Create the window as a a pop-up      |
| style="font-weight: 700;">-popupwind | window, without a frame.             |
| ow</span>                            |                                      |
+--------------------------------------+--------------------------------------+
| <span                                | Override the default full-screen     |
| style="font-weight: 700;">-screen-fu | state. This must be 0 or 1.          |
| llscreen</span>                      |                                      |
+--------------------------------------+--------------------------------------+
| <span                                | Override the default screen height.  |
| style="font-weight: 700;">-screen-he | This must be an integer from a       |
| ight</span>                          | supported resolution.                |
+--------------------------------------+--------------------------------------+
| <span                                | Override the default screen width.   |
| style="font-weight: 700;">-screen-wi | This must be an integer from a       |
| dth</span>                           | supported resolution.                |
+--------------------------------------+--------------------------------------+
| <span                                | Override the default screen quality. |
| style="font-weight: 700;">-screen-qu | Example usage would                  |
| ality</span>                         | be: `/path/to/myGame -screen-quality |
|                                      |  Beautiful`{style="font-size: 1em; p |
|                                      | adding: 1px 1px 0px 0px; background: |
|                                      |  rgb(240, 240, 240);"}               |
+--------------------------------------+--------------------------------------+
| <span                                | Forces the screen selector dialog to |
| style="font-weight: 700;">-show-scre | be shown.                            |
| en-selector</span>                   |                                      |
+--------------------------------------+--------------------------------------+
| <span                                | Allow only one instance of the game  |
| style="font-weight: 700;">-single-in | to run at the time. If another       |
| stance                               | instance is already running then     |
| (Linux & Windows only)</span>        | launching it again                   |
|                                      | with `-single-instance`{style="font- |
|                                      | size: 1em; padding: 1px 1px 0px 0px; |
|                                      |  background: rgb(240, 240, 240);"} f |
|                                      | ocuses                               |
|                                      | the existing one.                    |
+--------------------------------------+--------------------------------------+
| <span                                | This embeds the Windows Standalone   |
| style="font-weight: 700;">-parentHWN | application into another             |
| D                                    | application. When using this, you    |
| &lt;HWND&gt;|delayed (Windows        | need to pass the parent              |
| only)</span>                         | application’s window handle to the   |
|                                      | Windows Standalone application. \    |
|                                      | When                                 |
|                                      | passing `-parentHWND delayed`{style= |
|                                      | "font-size: 1em; padding: 1px 1px 0p |
|                                      | x 0px; background: rgb(240, 240, 240 |
|                                      | );"},                                |
|                                      | the Unity application is hidden      |
|                                      | while running. You must also         |
|                                      | call [SetParent](https://msdn.micros |
|                                      | oft.com/en-us/library/windows/deskto |
|                                      | p/ms633541(v=vs.85).aspx) for        |
|                                      | Unity in the application, which      |
|                                      | embeds the Unity window.\            |
|                                      | For more information, see this       |
|                                      | example: [EmbeddedWindow.zip](https: |
|                                      | //docs.unity3d.com/uploads/Examples/ |
|                                      | EmbeddedWindow.zip)\                 |
|                                      | <div style="color:gray">             |
|                                      |                                      |
|                                      | 来源： <https://docs.unity3d.com/Manual |
|                                      | /CommandLineArguments.html>          |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+

</div>

</div>
