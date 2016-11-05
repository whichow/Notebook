Unity3D offers a ton of great features for Android projects, but often
there are gaps that must be filled with plugins.

Let’s take the example
of [Toast](http://developer.android.com/guide/topics/ui/notifiers/toasts.html "Toast") popups
for Android.  In your game you might like to show a popup message that
explains an error, or states that you are signed in to a server.

<span></span>

Start by creating a new Android library project.  If you’re like me,
you’ll be using the command line with a text editor instead of an IDE.

<div data-settings=" minimize scroll-mouseover">

<div data-settings=" show">

<span>Terminal</span>
<div>

<div title="Open Code In New Window">

<div>

</div>

</div>

<span>Shell</span>

</div>

</div>

<div>

</div>

<div>

+--------------------------------------+--------------------------------------+
| <div>                                | <div>                                |
|                                      |                                      |
| <div                                 | <div>                                |
| data-line="crayon-5788ae410e6a088152 |                                      |
| 1692-1">                             | <span>android </span><span>create    |
|                                      | </span><span>lib</span><span>-</span |
| 1                                    | ><span>project</span><span>          |
|                                      | </span><span>--</span><span>name     |
| </div>                               | </span><span>TestPlugin</span><span> |
|                                      | </span><span>--</span><span>target</ |
| <div                                 | span><span>                          |
| data-line="crayon-5788ae410e6a088152 | </span><span>9</span><span>          |
| 1692-2">                             | </span><span>--</span><span>path</sp |
|                                      | an><span>                            |
| 2                                    | </span><span>.</span><span>          |
|                                      | </span><span>--</span><span>package< |
| </div>                               | /span><span>                         |
|                                      | </span><span>com</span><span>.nraboy |
| </div>                               | </span><span>.testplugin</span>      |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div>                                |
|                                      |                                      |
|                                      | <span>touch</span><span>             |
|                                      | </span><span>src</span><span>/</span |
|                                      | ><span>com</span><span>/</span><span |
|                                      | >nraboy</span><span>/</span><span>te |
|                                      | stplugin</span><span>/</span><span>T |
|                                      | oastExample</span><span>.java</span> |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+

</div>

</div>

In your newly created ToastExample.java file add the following source
code:

<div data-settings=" minimize scroll-mouseover">

<div data-settings=" show">

<span>ToastExample.java</span>
<div>

<div title="Open Code In New Window">

<div>

</div>

</div>

<span>Java</span>

</div>

</div>

<div>

</div>

<div>

+--------------------------------------+--------------------------------------+
| <div>                                | <div>                                |
|                                      |                                      |
| <div                                 | <div>                                |
| data-line="crayon-5788ae410e6b031826 |                                      |
| 2290-1">                             | <span>package</span><span>           |
|                                      | </span><span>com</span><span>.</span |
| 1                                    | ><span>nraboy</span><span>.</span><s |
|                                      | pan>testplugin</span><span>;</span>  |
| </div>                               |                                      |
|                                      | </div>                               |
| <div                                 |                                      |
| data-line="crayon-5788ae410e6b031826 | <div>                                |
| 2290-2">                             |                                      |
|                                      |                                      |
| 2                                    |                                      |
|                                      | </div>                               |
| </div>                               |                                      |
|                                      | <div>                                |
| <div                                 |                                      |
| data-line="crayon-5788ae410e6b031826 | <span>import</span><span>            |
| 2290-3">                             | </span><span>android</span><span>.</ |
|                                      | span><span>content</span><span>.</sp |
| 3                                    | an><span>Context</span><span>;</span |
|                                      | >                                    |
| </div>                               |                                      |
|                                      | </div>                               |
| <div                                 |                                      |
| data-line="crayon-5788ae410e6b031826 | <div>                                |
| 2290-4">                             |                                      |
|                                      | <span>import</span><span>            |
| 4                                    | </span><span>android</span><span>.</ |
|                                      | span><span>widget</span><span>.</spa |
| </div>                               | n><span>Toast</span><span>;</span>   |
|                                      |                                      |
| <div                                 | </div>                               |
| data-line="crayon-5788ae410e6b031826 |                                      |
| 2290-5">                             | <div>                                |
|                                      |                                      |
| 5                                    |                                      |
|                                      |                                      |
| </div>                               | </div>                               |
|                                      |                                      |
| <div                                 | <div>                                |
| data-line="crayon-5788ae410e6b031826 |                                      |
| 2290-6">                             | <span>public</span><span>            |
|                                      | </span><span>class</span><span>      |
| 6                                    | </span><span>ToastExample</span><spa |
|                                      | n>                                   |
| </div>                               | </span><span>{</span>                |
|                                      |                                      |
| <div                                 | </div>                               |
| data-line="crayon-5788ae410e6b031826 |                                      |
| 2290-7">                             | <div>                                |
|                                      |                                      |
| 7                                    | <span>    </span>                    |
|                                      |                                      |
| </div>                               | </div>                               |
|                                      |                                      |
| <div                                 | <div>                                |
| data-line="crayon-5788ae410e6b031826 |                                      |
| 2290-8">                             | <span>    </span><span>private</span |
|                                      | ><span>                              |
| 8                                    | </span><span>Context                 |
|                                      | </span><span>context</span><span>;</ |
| </div>                               | span>                                |
|                                      |                                      |
| <div                                 | </div>                               |
| data-line="crayon-5788ae410e6b031826 |                                      |
| 2290-9">                             | <div>                                |
|                                      |                                      |
| 9                                    | <span>    </span><span>private</span |
|                                      | ><span>                              |
| </div>                               | </span><span>static</span><span>     |
|                                      | </span><span>ToastExample            |
| <div                                 | </span><span>instance</span><span>;< |
| data-line="crayon-5788ae410e6b031826 | /span>                               |
| 2290-10">                            |                                      |
|                                      | </div>                               |
| 10                                   |                                      |
|                                      | <div>                                |
| </div>                               |                                      |
|                                      |                                      |
| <div                                 |                                      |
| data-line="crayon-5788ae410e6b031826 | </div>                               |
| 2290-11">                            |                                      |
|                                      | <div>                                |
| 11                                   |                                      |
|                                      | <span>    </span><span>public</span> |
| </div>                               | <span>                               |
|                                      | </span><span>ToastExample</span><spa |
| <div                                 | n>(</span><span>)</span><span>       |
| data-line="crayon-5788ae410e6b031826 | </span><span>{</span>                |
| 2290-12">                            |                                      |
|                                      | </div>                               |
| 12                                   |                                      |
|                                      | <div>                                |
| </div>                               |                                      |
|                                      | <span>        </span><span>this</spa |
| <div                                 | n><span>.</span><span>instance</span |
| data-line="crayon-5788ae410e6b031826 | ><span>                              |
| 2290-13">                            | </span><span>=</span><span>          |
|                                      | </span><span>this</span><span>;</spa |
| 13                                   | n>                                   |
|                                      |                                      |
| </div>                               | </div>                               |
|                                      |                                      |
| <div                                 | <div>                                |
| data-line="crayon-5788ae410e6b031826 |                                      |
| 2290-14">                            | <span>    </span><span>}</span>      |
|                                      |                                      |
| 14                                   | </div>                               |
|                                      |                                      |
| </div>                               | <div>                                |
|                                      |                                      |
| <div                                 |                                      |
| data-line="crayon-5788ae410e6b031826 |                                      |
| 2290-15">                            | </div>                               |
|                                      |                                      |
| 15                                   | <div>                                |
|                                      |                                      |
| </div>                               | <span>    </span><span>public</span> |
|                                      | <span>                               |
| <div                                 | </span><span>static</span><span>     |
| data-line="crayon-5788ae410e6b031826 | </span><span>ToastExample            |
| 2290-16">                            | </span><span>instance</span><span>(< |
|                                      | /span><span>)</span><span>           |
| 16                                   | </span><span>{</span>                |
|                                      |                                      |
| </div>                               | </div>                               |
|                                      |                                      |
| <div                                 | <div>                                |
| data-line="crayon-5788ae410e6b031826 |                                      |
| 2290-17">                            | <span>        </span><span>if</span> |
|                                      | <span>(</span><span>instance</span>< |
| 17                                   | span>                                |
|                                      | </span><span>==</span><span>         |
| </div>                               | </span><span>null</span><span>)</spa |
|                                      | n><span>                             |
| <div                                 | </span><span>{</span>                |
| data-line="crayon-5788ae410e6b031826 |                                      |
| 2290-18">                            | </div>                               |
|                                      |                                      |
| 18                                   | <div>                                |
|                                      |                                      |
| </div>                               | <span>            </span><span>insta |
|                                      | nce</span><span>                     |
| <div                                 | </span><span>=</span><span>          |
| data-line="crayon-5788ae410e6b031826 | </span><span>new</span><span>        |
| 2290-19">                            | </span><span>ToastExample</span><spa |
|                                      | n>(</span><span>)</span><span>;</spa |
| 19                                   | n>                                   |
|                                      |                                      |
| </div>                               | </div>                               |
|                                      |                                      |
| <div                                 | <div>                                |
| data-line="crayon-5788ae410e6b031826 |                                      |
| 2290-20">                            | <span>        </span><span>}</span>  |
|                                      |                                      |
| 20                                   | </div>                               |
|                                      |                                      |
| </div>                               | <div>                                |
|                                      |                                      |
| <div                                 | <span>        </span><span>return</s |
| data-line="crayon-5788ae410e6b031826 | pan><span>                           |
| 2290-21">                            | </span><span>instance</span><span>;< |
|                                      | /span>                               |
| 21                                   |                                      |
|                                      | </div>                               |
| </div>                               |                                      |
|                                      | <div>                                |
| <div                                 |                                      |
| data-line="crayon-5788ae410e6b031826 | <span>    </span><span>}</span>      |
| 2290-22">                            |                                      |
|                                      | </div>                               |
| 22                                   |                                      |
|                                      | <div>                                |
| </div>                               |                                      |
|                                      |                                      |
| <div                                 |                                      |
| data-line="crayon-5788ae410e6b031826 | </div>                               |
| 2290-23">                            |                                      |
|                                      | <div>                                |
| 23                                   |                                      |
|                                      | <span>    </span><span>public</span> |
| </div>                               | <span>                               |
|                                      | </span><span>void</span><span>       |
| <div                                 | </span><span>setContext</span><span> |
| data-line="crayon-5788ae410e6b031826 | (</span><span>Context                |
| 2290-24">                            | </span><span>context</span><span>)</ |
|                                      | span><span>                          |
| 24                                   | </span><span>{</span>                |
|                                      |                                      |
| </div>                               | </div>                               |
|                                      |                                      |
| <div                                 | <div>                                |
| data-line="crayon-5788ae410e6b031826 |                                      |
| 2290-25">                            | <span>        </span><span>this</spa |
|                                      | n><span>.</span><span>context</span> |
| 25                                   | <span>                               |
|                                      | </span><span>=</span><span>          |
| </div>                               | </span><span>context</span><span>;</ |
|                                      | span>                                |
| <div                                 |                                      |
| data-line="crayon-5788ae410e6b031826 | </div>                               |
| 2290-26">                            |                                      |
|                                      | <div>                                |
| 26                                   |                                      |
|                                      | <span>    </span><span>}</span>      |
| </div>                               |                                      |
|                                      | </div>                               |
| <div                                 |                                      |
| data-line="crayon-5788ae410e6b031826 | <div>                                |
| 2290-27">                            |                                      |
|                                      |                                      |
| 27                                   |                                      |
|                                      | </div>                               |
| </div>                               |                                      |
|                                      | <div>                                |
| <div                                 |                                      |
| data-line="crayon-5788ae410e6b031826 | <span>    </span><span>public</span> |
| 2290-28">                            | <span>                               |
|                                      | </span><span>void</span><span>       |
| 28                                   | </span><span>showMessage</span><span |
|                                      | >(</span><span>String</span><span>   |
| </div>                               | </span><span>message</span><span>)</ |
|                                      | span><span>                          |
| <div                                 | </span><span>{</span>                |
| data-line="crayon-5788ae410e6b031826 |                                      |
| 2290-29">                            | </div>                               |
|                                      |                                      |
| 29                                   | <div>                                |
|                                      |                                      |
| </div>                               | <span>        </span><span>Toast</sp |
|                                      | an><span>.</span><span>makeText</spa |
| <div                                 | n><span>(</span><span>this</span><sp |
| data-line="crayon-5788ae410e6b031826 | an>.</span><span>context</span><span |
| 2290-30">                            | >,</span><span>                      |
|                                      | </span><span>message</span><span>,</ |
| 30                                   | span><span>                          |
|                                      | </span><span>Toast</span><span>.</sp |
| </div>                               | an><span>LENGTH\_SHORT</span><span>) |
|                                      | </span><span>.</span><span>show</spa |
| </div>                               | n><span>(</span><span>)</span><span> |
|                                      | ;</span>                             |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div>                                |
|                                      |                                      |
|                                      | <span>    </span><span>}</span>      |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div>                                |
|                                      |                                      |
|                                      |                                      |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div>                                |
|                                      |                                      |
|                                      | <span>}</span>                       |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+

</div>

</div>

There are a few things to note in the source code.  Because we will be
making use of the <span>AndroidJavaObject </span>to represent our
instance, we need to create the instance and return it.  The static
function <span>instance()</span> will create our instance if it does not
already exist by calling the class constructor and then returning it for
Unity3D to use.  Beyond the required instance and constructor methods
everything thing else is up to your imagination.  In our case we will be
creating a Toast popup that requires an activity context.  You can
either create a separate function like <span>setContext</span> or
require the context as a parameter for <span>showMessage</span>.

To include the plugin in a Unity3D game you must first compile and
bundle it into a JAR file.  Again if you’re using a command line to
build you can add the following to your <span>build.xml</span> file:

<div data-settings=" minimize scroll-mouseover">

<div data-settings=" show">

<span>build.xml</span>
<div>

<div title="Open Code In New Window">

<div>

</div>

</div>

<span>Shell</span>

</div>

</div>

<div>

</div>

<div>

+--------------------------------------+--------------------------------------+
| <div>                                | <div>                                |
|                                      |                                      |
| <div                                 | <div>                                |
| data-line="crayon-5788ae410e6b857352 |                                      |
| 6082-1">                             | <span>&lt;</span><span>target        |
|                                      | </span><span>name</span><span>=</spa |
| 1                                    | n><span>"jar"</span><span>           |
|                                      | </span><span>depends</span><span>=</ |
| </div>                               | span><span>"debug"</span><span>&gt;< |
|                                      | /span>                               |
| <div                                 |                                      |
| data-line="crayon-5788ae410e6b857352 | </div>                               |
| 6082-2">                             |                                      |
|                                      | <div>                                |
| 2                                    |                                      |
|                                      | <span>    </span><span>&lt;</span><s |
| </div>                               | pan>jar</span>                       |
|                                      |                                      |
| <div                                 | </div>                               |
| data-line="crayon-5788ae410e6b857352 |                                      |
| 6082-3">                             | <div>                                |
|                                      |                                      |
| 3                                    | <span>        </span><span>destfile< |
|                                      | /span><span>=</span><span>"bin/TestP |
| </div>                               | lugin.jar"</span>                    |
|                                      |                                      |
| <div                                 | </div>                               |
| data-line="crayon-5788ae410e6b857352 |                                      |
| 6082-4">                             | <div>                                |
|                                      |                                      |
| 4                                    | <span>        </span><span>basedir</ |
|                                      | span><span>=</span><span>"bin/classe |
| </div>                               | s"</span><span>                      |
|                                      | </span><span>/</span><span>&gt;</spa |
| <div                                 | n>                                   |
| data-line="crayon-5788ae410e6b857352 |                                      |
| 6082-5">                             | </div>                               |
|                                      |                                      |
| 5                                    | <div>                                |
|                                      |                                      |
| </div>                               | <span>&lt;</span><span>/</span><span |
|                                      | >target</span><span>&gt;</span>      |
| </div>                               |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+

</div>

</div>

From this point you can just run <span>ant jar</span> and you will end
up with bin/TestPlugin.jar

Assuming that you got no errors on the Java side of things, you can
proceed to your Unity3D project.  In your project create
Assets/Plugins/Android if it doesn’t already exist.  Unity3D knows to
pick up all Android plugins from this location.  Copy your
TestPlugin.jar to the plugin location.

Inside your Assets/Scripts directory create a new C\# script called
UnityToastExample and include the following code:

<div data-settings=" minimize scroll-mouseover">

<div data-settings=" show">

<span>UnityToastExample.cs</span>
<div>

<div title="Open Code In New Window">

<div>

</div>

</div>

<span>C\#</span>

</div>

</div>

<div>

</div>

<div>

+--------------------------------------+--------------------------------------+
| <div>                                | <div>                                |
|                                      |                                      |
| <div                                 | <div>                                |
| data-line="crayon-5788ae410e6be43605 |                                      |
| 4111-1">                             | <span>public</span><span>            |
|                                      | </span><span>class</span><span>      |
| 1                                    | </span><span>UnityToastExample</span |
|                                      | ><span>                              |
| </div>                               | </span><span>:</span><span>          |
|                                      | </span><span>MonoBehaviour</span><sp |
| <div                                 | an>                                  |
| data-line="crayon-5788ae410e6be43605 | </span><span>{</span>                |
| 4111-2">                             |                                      |
|                                      | </div>                               |
| 2                                    |                                      |
|                                      | <div>                                |
| </div>                               |                                      |
|                                      | <span> </span>                       |
| <div                                 |                                      |
| data-line="crayon-5788ae410e6be43605 | </div>                               |
| 4111-3">                             |                                      |
|                                      | <div>                                |
| 3                                    |                                      |
|                                      | <span>    </span><span>private</span |
| </div>                               | ><span>                              |
|                                      | </span><span>AndroidJavaObject       |
| <div                                 | </span><span>toastExample</span><spa |
| data-line="crayon-5788ae410e6be43605 | n>                                   |
| 4111-4">                             | </span><span>=</span><span>          |
|                                      | </span><span>null</span><span>;</spa |
| 4                                    | n>                                   |
|                                      |                                      |
| </div>                               | </div>                               |
|                                      |                                      |
| <div                                 | <div>                                |
| data-line="crayon-5788ae410e6be43605 |                                      |
| 4111-5">                             | <span>    </span><span>private</span |
|                                      | ><span>                              |
| 5                                    | </span><span>AndroidJavaObject       |
|                                      | </span><span>activityContext</span>< |
| </div>                               | span>                                |
|                                      | </span><span>=</span><span>          |
| <div                                 | </span><span>null</span><span>;</spa |
| data-line="crayon-5788ae410e6be43605 | n>                                   |
| 4111-6">                             |                                      |
|                                      | </div>                               |
| 6                                    |                                      |
|                                      | <div>                                |
| </div>                               |                                      |
|                                      | <span> </span>                       |
| <div                                 |                                      |
| data-line="crayon-5788ae410e6be43605 | </div>                               |
| 4111-7">                             |                                      |
|                                      | <div>                                |
| 7                                    |                                      |
|                                      | <span>    </span><span>void</span><s |
| </div>                               | pan>                                 |
|                                      | </span><span>Start</span><span>(</sp |
| <div                                 | an><span>)</span><span>              |
| data-line="crayon-5788ae410e6be43605 | </span><span>{</span>                |
| 4111-8">                             |                                      |
|                                      | </div>                               |
| 8                                    |                                      |
|                                      | <div>                                |
| </div>                               |                                      |
|                                      | <span>        </span><span>if</span> |
| <div                                 | <span>(</span><span>toastExample</sp |
| data-line="crayon-5788ae410e6be43605 | an><span>                            |
| 4111-9">                             | </span><span>==</span><span>         |
|                                      | </span><span>null</span><span>)</spa |
| 9                                    | n><span>                             |
|                                      | </span><span>{</span>                |
| </div>                               |                                      |
|                                      | </div>                               |
| <div                                 |                                      |
| data-line="crayon-5788ae410e6be43605 | <div>                                |
| 4111-10">                            |                                      |
|                                      | <span>            </span><span>using |
| 10                                   | </span><span>(</span><span>AndroidJa |
|                                      | vaClass                              |
| </div>                               | </span><span>activityClass</span><sp |
|                                      | an>                                  |
| <div                                 | </span><span>=</span><span>          |
| data-line="crayon-5788ae410e6be43605 | </span><span>new</span><span>        |
| 4111-11">                            | </span><span>AndroidJavaClass</span> |
|                                      | <span>(</span><span>"com.unity3d.pla |
| 11                                   | yer.UnityPlayer"</span><span>)</span |
|                                      | ><span>)</span><span>                |
| </div>                               | </span><span>{</span>                |
|                                      |                                      |
| <div                                 | </div>                               |
| data-line="crayon-5788ae410e6be43605 |                                      |
| 4111-12">                            | <div>                                |
|                                      |                                      |
| 12                                   | <span>                </span><span>a |
|                                      | ctivityContext</span><span>          |
| </div>                               | </span><span>=</span><span>          |
|                                      | </span><span>activityClass</span><sp |
| <div                                 | an>.</span><span>GetStatic</span><sp |
| data-line="crayon-5788ae410e6be43605 | an>&lt;</span><span>AndroidJavaObjec |
| 4111-13">                            | t</span><span>&gt;</span><span>(</sp |
|                                      | an><span>"currentActivity"</span><sp |
| 13                                   | an>)</span><span>;</span>            |
|                                      |                                      |
| </div>                               | </div>                               |
|                                      |                                      |
| <div                                 | <div>                                |
| data-line="crayon-5788ae410e6be43605 |                                      |
| 4111-14">                            | <span>            </span><span>}</sp |
|                                      | an>                                  |
| 14                                   |                                      |
|                                      | </div>                               |
| </div>                               |                                      |
|                                      | <div>                                |
| <div                                 |                                      |
| data-line="crayon-5788ae410e6be43605 | <span> </span>                       |
| 4111-15">                            |                                      |
|                                      | </div>                               |
| 15                                   |                                      |
|                                      | <div>                                |
| </div>                               |                                      |
|                                      | <span>            </span><span>using |
| <div                                 | </span><span>(</span><span>AndroidJa |
| data-line="crayon-5788ae410e6be43605 | vaClass                              |
| 4111-16">                            | </span><span>pluginClass</span><span |
|                                      | >                                    |
| 16                                   | </span><span>=</span><span>          |
|                                      | </span><span>new</span><span>        |
| </div>                               | </span><span>AndroidJavaClass</span> |
|                                      | <span>(</span><span>"com.nraboy.test |
| <div                                 | plugin.ToastExample"</span><span>)</ |
| data-line="crayon-5788ae410e6be43605 | span><span>)</span><span>            |
| 4111-17">                            | </span><span>{</span>                |
|                                      |                                      |
| 17                                   | </div>                               |
|                                      |                                      |
| </div>                               | <div>                                |
|                                      |                                      |
| <div                                 | <span>                </span><span>i |
| data-line="crayon-5788ae410e6be43605 | f</span><span>(</span><span>pluginCl |
| 4111-18">                            | ass</span><span>                     |
|                                      | </span><span>!=</span><span>         |
| 18                                   | </span><span>null</span><span>)</spa |
|                                      | n><span>                             |
| </div>                               | </span><span>{</span>                |
|                                      |                                      |
| <div                                 | </div>                               |
| data-line="crayon-5788ae410e6be43605 |                                      |
| 4111-19">                            | <div>                                |
|                                      |                                      |
| 19                                   | <span>                    </span><sp |
|                                      | an>toastExample</span><span>         |
| </div>                               | </span><span>=</span><span>          |
|                                      | </span><span>pluginClass</span><span |
| <div                                 | >.</span><span>CallStatic</span><spa |
| data-line="crayon-5788ae410e6be43605 | n>&lt;</span><span>AndroidJavaObject |
| 4111-20">                            | </span><span>&gt;</span><span>(</spa |
|                                      | n><span>"instance"</span><span>)</sp |
| 20                                   | an><span>;</span>                    |
|                                      |                                      |
| </div>                               | </div>                               |
|                                      |                                      |
| <div                                 | <div>                                |
| data-line="crayon-5788ae410e6be43605 |                                      |
| 4111-21">                            | <span>                    </span><sp |
|                                      | an>toastExample</span><span>.</span> |
| 21                                   | <span>Call</span><span>(</span><span |
|                                      | >"setContext"</span><span>,</span><s |
| </div>                               | pan>                                 |
|                                      | </span><span>activityContext</span>< |
| <div                                 | span>)</span><span>;</span>          |
| data-line="crayon-5788ae410e6be43605 |                                      |
| 4111-22">                            | </div>                               |
|                                      |                                      |
| 22                                   | <div>                                |
|                                      |                                      |
| </div>                               | <span>                    </span><sp |
|                                      | an>activityContext</span><span>.</sp |
| <div                                 | an><span>Call</span><span>(</span><s |
| data-line="crayon-5788ae410e6be43605 | pan>"runOnUiThread"</span><span>,</s |
| 4111-23">                            | pan><span>                           |
|                                      | </span><span>new</span><span>        |
| 23                                   | </span><span>AndroidJavaRunnable</sp |
|                                      | an><span>(</span><span>(</span><span |
| </div>                               | >)</span><span>                      |
|                                      | </span><span>=</span><span>&gt;</spa |
| </div>                               | n><span>                             |
|                                      | </span><span>{</span>                |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div>                                |
|                                      |                                      |
|                                      | <span>                        </span |
|                                      | ><span>toastExample</span><span>.</s |
|                                      | pan><span>Call</span><span>(</span>< |
|                                      | span>"showMessage"</span><span>,</sp |
|                                      | an><span>                            |
|                                      | </span><span>"This is a Toast        |
|                                      | message"</span><span>)</span><span>; |
|                                      | </span>                              |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div>                                |
|                                      |                                      |
|                                      | <span>                    </span><sp |
|                                      | an>}</span><span>)</span><span>)</sp |
|                                      | an><span>;</span>                    |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div>                                |
|                                      |                                      |
|                                      | <span>                </span><span>} |
|                                      | </span>                              |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div>                                |
|                                      |                                      |
|                                      | <span>            </span><span>}</sp |
|                                      | an>                                  |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div>                                |
|                                      |                                      |
|                                      | <span>        </span><span>}</span>  |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div>                                |
|                                      |                                      |
|                                      | <span>    </span><span>}</span>      |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div>                                |
|                                      |                                      |
|                                      | <span>}</span>                       |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+

</div>

</div>

Because we have decided to keep things simple and not extend the
UnityPlayerActivity in our Android code, we need to get the current
activity from the player.  This is the only way to get the activity
context required by our Toast.

Once we have the activity context we can load our class and create the
ToastExample object instance.  When the object instance has been created
we are now able to call any public function from the class.  The first
thing we do is set the context that we got from our current activity.
 This is where it can get confusing.  Toast popups are UI features so
they are required to run on the UI thread.  This can be done many
different ways whether in the Java code or in the Unity code.  In this
example it will be done in the Unity3D code.

<div data-settings=" minimize scroll-mouseover">

<div data-settings=" show">

<span>UnityToastExample.cs</span>
<div>

<div title="Open Code In New Window">

<div>

</div>

</div>

<span>C\#</span>

</div>

</div>

<div>

</div>

<div>

+--------------------------------------+--------------------------------------+
| <div>                                | <div>                                |
|                                      |                                      |
| <div                                 | <div>                                |
| data-line="crayon-5788ae410e6c556627 |                                      |
| 4087-1">                             | <span>activityContext</span><span>.< |
|                                      | /span><span>Call</span><span>(</span |
| 1                                    | ><span>"runOnUiThread"</span><span>, |
|                                      | </span><span>                        |
| </div>                               | </span><span>new</span><span>        |
|                                      | </span><span>AndroidJavaRunnable</sp |
| <div                                 | an><span>(</span><span>(</span><span |
| data-line="crayon-5788ae410e6c556627 | >)</span><span>                      |
| 4087-2">                             | </span><span>=</span><span>&gt;</spa |
|                                      | n><span>                             |
| 2                                    | </span><span>{</span>                |
|                                      |                                      |
| </div>                               | </div>                               |
|                                      |                                      |
| <div                                 | <div>                                |
| data-line="crayon-5788ae410e6c556627 |                                      |
| 4087-3">                             | <span>    </span><span>toastExample< |
|                                      | /span><span>.</span><span>Call</span |
| 3                                    | ><span>(</span><span>"showMessage"</ |
|                                      | span><span>,</span><span>            |
| </div>                               | </span><span>"This is a Toast        |
|                                      | message"</span><span>)</span><span>; |
| </div>                               | </span>                              |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div>                                |
|                                      |                                      |
|                                      | <span>}</span><span>)</span><span>)< |
|                                      | /span><span>;</span>                 |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+

</div>

</div>

Anything in this particular <span>AndroidJavaRunnable</span> will be run
on the UI thread.

Attach the UnityToastExample.cs script to a GameObject and build for
Android.  If everything went smooth, you should see a Toast popup on
your device at launch.  Make sure to only run for Android as you’ll get
errors for other platforms.

<div>

</div>

<div>

</div>
