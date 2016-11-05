Unity4: Test Unity iOS plug-in on iOS simulator
<div>

\
<div style="font-size: 16px">

<div>

<div
style="font-family:Arial, Helvetica, sans-serif;font-size:14px;color:rgb(90, 90, 90);background:url(&quot;&quot;) repeat;">

<div>

<div
style="border-radius:5px;box-shadow:rgba(0, 0, 0, 0.227451) 0px 0px 3px 0px;background:rgb(255, 255, 255);">

<div>

+--------------------------------------------------------------------------+
| <div style="float:left;">                                                |
|                                                                          |
| <div>                                                                    |
|                                                                          |
| <div>                                                                    |
|                                                                          |
| <div>                                                                    |
|                                                                          |
| [Unity4: Test Unity iOS plug-in on iOS simulator](http://tzuhsunlu.weebl |
| y.com/my-development-blog/unity4-test-unity-ios-plug-in-on-ios-simulator |
| ) {#unity4-test-unity-ios-plug-in-on-ios-simulator style="margin:0px;pad |
| ding:0.5em 0px 0.2em;font-size:24px;line-height:1.2;font-family:Rosario, |
|  sans-serif;font-weight:bold;"}                                          |
| ------------------------------------------------------------------------ |
| ------------------------------------------------------------------------ |
| -                                                                        |
|                                                                          |
| <span> 4/21/2014 </span>                                                 |
|                                                                          |
| [2                                                                       |
| Comments](http://tzuhsunlu.weebly.com/my-development-blog/unity4-test-un |
| ity-ios-plug-in-on-ios-simulator#comments)                               |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div>                                                                    |
|                                                                          |
|                                                                          |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div>                                                                    |
|                                                                          |
| <div                                                                     |
| style="margin:0px;padding:0.5em 0px;line-height:1.5;text-align:left;">   |
|                                                                          |
| It's relatively slow to build on real iOS device compare to simulator.   |
| Running on simulator can save me a lots of time when testing the iOS     |
| plug-in I wrote. Here are the steps we need to do to make the plug-in    |
| works on simulator properly:                                             |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| How? {#how style="margin:0px;padding:0.5em 0px 0.2em;font-size:24px;line |
| -height:1.2;font-family:Rosario, sans-serif;font-weight:bold;text-align: |
| left;"}                                                                  |
| ----                                                                     |
|                                                                          |
| <div>                                                                    |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div                                                                     |
| style="margin:0px;padding:0.5em 0px;line-height:1.5;text-align:left;">   |
|                                                                          |
| Move **void mono\_dl\_register\_symbol (const char\* name, void          |
| \*addr);**\                                                              |
| out of\                                                                  |
| **\#if !(TARGET\_IPHONE\_SIMULATOR)\                                     |
| \#endif // !(TARGET\_IPHONE\_SIMULATOR)**                                |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div>                                                                    |
|                                                                          |
| <div                                                                     |
| style="padding-top:10px;padding-bottom:10px;margin-left:0;margin-right:0 |
| ;text-align:center;">                                                    |
|                                                                          |
| [![Picture](Unity4-%20Test%20Unity%20iOS%20plug-in%20on%20iOS%20simulato |
| r_files/472d6c0117ea5e259a33dc8082f88829.png){width="435"                |
| height="264"}]()                                                         |
| <div style="display:block;font-size:90%;">                               |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div                                                                     |
| style="margin:0px;padding:0.5em 0px;line-height:1.5;text-align:left;">   |
|                                                                          |
| In **void RegisterMonoModules()**\                                       |
| Move your "Extern methods" out of\                                       |
| **\#if !(TARGET\_IPHONE\_SIMULATOR)\                                     |
| \#endif // !(TARGET\_IPHONE\_SIMULATOR)** block\                         |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div>                                                                    |
|                                                                          |
| <div                                                                     |
| style="padding-top:10px;padding-bottom:10px;margin-left:0;margin-right:0 |
| ;text-align:center;">                                                    |
|                                                                          |
| [![Picture](Unity4-%20Test%20Unity%20iOS%20plug-in%20on%20iOS%20simulato |
| r_files/41122f8cd3b718c3fc98cec6a73db293.png){width="435"                |
| height="264"}]()                                                         |
| <div style="display:block;font-size:90%;">                               |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div                                                                     |
| style="margin:0px;padding:0.5em 0px;line-height:1.5;text-align:left;">   |
|                                                                          |
| **Result:** my iAd plug-in runs on simulator.                            |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div>                                                                    |
|                                                                          |
| <div                                                                     |
| style="padding-top:10px;padding-bottom:10px;margin-left:0;margin-right:0 |
| ;text-align:center;">                                                    |
|                                                                          |
| [![Picture](Unity4-%20Test%20Unity%20iOS%20plug-in%20on%20iOS%20simulato |
| r_files/81475bc3046900e7a1803f364d0e0adf.png){width="435"                |
| height="336"}]()                                                         |
| <div style="display:block;font-size:90%;">                               |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div                                                                     |
| style="margin:0px;padding:0.5em 0px;line-height:1.5;text-align:left;">   |
|                                                                          |
| **\                                                                      |
| \                                                                        |
| Reference:**\                                                            |
| Building Plugins for iOS\                                                |
| [https://docs.unity3d.com/Documentation/Manual/PluginsForIOS.html\       |
| ](https://docs.unity3d.com/Documentation/Manual/PluginsForIOS.html)Using |
| the Xcode Simulator with a Unity 3 Native iOS Plug-In\                   |
| <http://tech.enekochan.com/2012/05/28/using-the-xcode-simulator-with-a-u |
| nity-3-native-ios-plug-in/>\                                             |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div>                                                                    |
|                                                                          |
| [2                                                                       |
| Comments](http://tzuhsunlu.weebly.com/my-development-blog/unity4-test-un |
| ity-ios-plug-in-on-ios-simulator#comments)                               |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div>                                                                    |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| []()                                                                     |
| <div>                                                                    |
|                                                                          |
| <div>                                                                    |
|                                                                          |
| <div>                                                                    |
|                                                                          |
| <div>                                                                    |
|                                                                          |
| <div>                                                                    |
|                                                                          |
| <div>                                                                    |
|                                                                          |
| <div>                                                                    |
|                                                                          |
| <span>Tuan Anh</span>                                                    |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div>                                                                    |
|                                                                          |
| 10/22/2014 11:07:38                                                      |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div>                                                                    |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div>                                                                    |
|                                                                          |
| Thank you so much                                                        |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div>                                                                    |
|                                                                          |
| <span title="Reply to this comment"> <span>Reply</span> </span>          |
| <div>                                                                    |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div>                                                                    |
|                                                                          |
| <div>                                                                    |
|                                                                          |
| <div>                                                                    |
|                                                                          |
| <div>                                                                    |
|                                                                          |
| <div>                                                                    |
|                                                                          |
| <span>Wallas</span>                                                      |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div>                                                                    |
|                                                                          |
| 1/8/2015 14:34:24                                                        |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div>                                                                    |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div>                                                                    |
|                                                                          |
| Thank you! You saved my day.                                             |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div>                                                                    |
|                                                                          |
| <span title="Reply to this comment"> <span>Reply</span> </span>          |
| <div>                                                                    |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div>                                                                    |
|                                                                          |
| <div>                                                                    |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| \                                                                        |
| \                                                                        |
| \                                                                        |
| Leave a Reply. {#leave-a-reply. style="margin:0px;padding:0.5em 0px 0.2e |
| m;font-size:24px;line-height:1.2;font-family:Rosario, sans-serif;font-we |
| ight:bold;"}                                                             |
| --------------                                                           |
|                                                                          |
| <div>                                                                    |
|                                                                          |
| <div>                                                                    |
|                                                                          |
| <div>                                                                    |
|                                                                          |
| <div style="position:relative;">                                         |
|                                                                          |
| <div style="font-size: 16px">                                            |
|                                                                          |
| <div>                                                                    |
|                                                                          |
| <div                                                                     |
| style="font-family:Arial, Helvetica, sans-serif;margin:0;padding:0 0 0 4 |
| px;font-size:14px;color:rgb(90, 90, 90);background:transparent !importan |
| t;text-align:left;">                                                     |
|                                                                          |
| <div>                                                                    |
|                                                                          |
| <div style="margin:0px;padding:0px;">                                    |
|                                                                          |
| <div>                                                                    |
|                                                                          |
| <div>                                                                    |
|                                                                          |
| <span> <span>Name</span> <span>(required)</span> </span>                 |
| <div>                                                                    |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div>                                                                    |
|                                                                          |
| <span> <span>Email</span> <span>(not published)</span> </span>           |
| <div>                                                                    |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div>                                                                    |
|                                                                          |
| <span> <span>Website</span> </span>                                      |
| <div>                                                                    |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div>                                                                    |
|                                                                          |
| <span> <span>Comments</span> </span>                                     |
| <div>                                                                    |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div>                                                                    |
|                                                                          |
| <span> <span>Notify me of new comments to this post by email</span>      |
| </span>                                                                  |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <span><span>Submit</span></span>                                         |
| <div style="clear:both;">                                                |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div>                                                                    |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| </div>                                                                   |
+--------------------------------------------------------------------------+

</div>

</div>

</div>

</div>

</div>

</div>

\

</div>
