在WPF中自定义窗体标题栏，首先需要将窗体的WindowStyle属性设置为None，隐藏掉WPF窗体的自带标题栏。然后我们可以在窗体内部自定义一个标题栏，比如标题栏如下:

<div class="dp-highlighter bg_html"
style="font-family: Consolas, 'Courier New', Courier, mono, serif; font-size: 12px; width: 940.497px; overflow: hidden; padding-top: 1px; position: relative; border-color: rgb(204, 204, 204); color: rgb(85, 85, 85); font-variant-ligatures: normal; orphans: 2; widows: 2; margin-top: 18px !important; margin-bottom: 18px !important; background-color: rgb(231, 229, 220);">

<div class="bar" style="padding-left: 45px;">

<div class="tools"
style="padding: 3px 8px 10px 10px; font-stretch: normal; font-size: 9px; line-height: normal; font-family: Verdana, Geneva, Arial, Helvetica, sans-serif; color: silver; border-left-width: 3px; border-left-style: solid; border-left-color: rgb(108, 226, 108); background-color: rgb(248, 248, 248);">

**\[html\]** [view
plain](http://blog.csdn.net/iispring/article/details/6888482# "view plain"){.ViewSource}<span
data-mod="popu_168"> [copy](http://blog.csdn.net/iispring/article/details/6888482# "copy"){.CopyToClipboard}</span>
<div
style="position: absolute; left: 661px; top: 652px; width: 18px; height: 18px; z-index: 99;">

</div>

<span data-mod="popu_169"></span>

</div>

</div>

1.  <span
    style="margin: 0px; padding: 0px; border: none; color: black; background-color: inherit;"><span
    class="tag"
    style="margin: 0px; padding: 0px; border: none; color: rgb(153, 51, 0); background-color: inherit; font-weight: bold;">&lt;</span><span
    class="tag-name"
    style="margin: 0px; padding: 0px; border: none; color: rgb(153, 51, 0); background-color: inherit; font-weight: bold;">Grid</span><span
    style="margin: 0px; padding: 0px; border: none; background-color: inherit;"> </span><span
    class="attribute"
    style="margin: 0px; padding: 0px; border: none; color: red; background-color: inherit;">Grid.Row</span><span
    style="margin: 0px; padding: 0px; border: none; background-color: inherit;">=</span><span
    class="attribute-value"
    style="margin: 0px; padding: 0px; border: none; color: blue; background-color: inherit;">" 0"</span><span
    style="margin: 0px; padding: 0px; border: none; background-color: inherit;"> </span><span
    class="attribute"
    style="margin: 0px; padding: 0px; border: none; color: red; background-color: inherit;">x:Name</span><span
    style="margin: 0px; padding: 0px; border: none; background-color: inherit;">=</span><span
    class="attribute-value"
    style="margin: 0px; padding: 0px; border: none; color: blue; background-color: inherit;">"TitleBar"</span><span
    style="margin: 0px; padding: 0px; border: none; background-color: inherit;"> </span><span
    class="attribute"
    style="margin: 0px; padding: 0px; border: none; color: red; background-color: inherit;">MouseMove</span><span
    style="margin: 0px; padding: 0px; border: none; background-color: inherit;">=</span><span
    class="attribute-value"
    style="margin: 0px; padding: 0px; border: none; color: blue; background-color: inherit;">"TitleBar\_MouseMove"</span><span
    style="margin: 0px; padding: 0px; border: none; background-color: inherit;"> </span><span
    class="tag"
    style="margin: 0px; padding: 0px; border: none; color: rgb(153, 51, 0); background-color: inherit; font-weight: bold;">&gt;</span><span
    style="margin: 0px; padding: 0px; border: none; background-color: inherit;">  </span></span>
2.  <span
    style="margin: 0px; padding: 0px; border: none; color: black; background-color: inherit;">            <span
    class="tag"
    style="margin: 0px; padding: 0px; border: none; color: rgb(153, 51, 0); background-color: inherit; font-weight: bold;">&lt;</span><span
    class="tag-name"
    style="margin: 0px; padding: 0px; border: none; color: rgb(153, 51, 0); background-color: inherit; font-weight: bold;">TextBlock</span><span
    style="margin: 0px; padding: 0px; border: none; background-color: inherit;"> </span><span
    class="attribute"
    style="margin: 0px; padding: 0px; border: none; color: red; background-color: inherit;">Text</span><span
    style="margin: 0px; padding: 0px; border: none; background-color: inherit;">=</span><span
    class="attribute-value"
    style="margin: 0px; padding: 0px; border: none; color: blue; background-color: inherit;">"这是标题栏"</span><span
    style="margin: 0px; padding: 0px; border: none; background-color: inherit;"> </span><span
    class="attribute"
    style="margin: 0px; padding: 0px; border: none; color: red; background-color: inherit;">FontSize</span><span
    style="margin: 0px; padding: 0px; border: none; background-color: inherit;">=</span><span
    class="attribute-value"
    style="margin: 0px; padding: 0px; border: none; color: blue; background-color: inherit;">"15"</span><span
    style="margin: 0px; padding: 0px; border: none; background-color: inherit;"> </span><span
    class="tag"
    style="margin: 0px; padding: 0px; border: none; color: rgb(153, 51, 0); background-color: inherit; font-weight: bold;">/&gt;</span><span
    style="margin: 0px; padding: 0px; border: none; background-color: inherit;">  </span></span>
3.  <span
    style="margin: 0px; padding: 0px; border: none; color: black; background-color: inherit;"><span
    class="tag"
    style="margin: 0px; padding: 0px; border: none; color: rgb(153, 51, 0); background-color: inherit; font-weight: bold;">&lt;/</span><span
    class="tag-name"
    style="margin: 0px; padding: 0px; border: none; color: rgb(153, 51, 0); background-color: inherit; font-weight: bold;">Grid</span><span
    class="tag"
    style="margin: 0px; padding: 0px; border: none; color: rgb(153, 51, 0); background-color: inherit; font-weight: bold;">&gt;</span><span
    style="margin: 0px; padding: 0px; border: none; background-color: inherit;">  </span></span>

</div>

<span
style="color: rgb(85, 85, 85); font-family: 'microsoft yahei'; font-variant-ligatures: normal; orphans: 2; widows: 2; background-color: rgb(255, 255, 255);">注意，我们给TitleBar添加了MouseMove事件，后台处理代码:</span>

<div class="dp-highlighter bg_csharp"
style="font-family: Consolas, 'Courier New', Courier, mono, serif; font-size: 12px; width: 940.497px; overflow: hidden; padding-top: 1px; position: relative; border-color: rgb(204, 204, 204); color: rgb(85, 85, 85); font-variant-ligatures: normal; orphans: 2; widows: 2; margin-top: 18px !important; margin-bottom: 18px !important; background-color: rgb(231, 229, 220);">

<div class="bar" style="padding-left: 45px;">

<div class="tools"
style="padding: 3px 8px 10px 10px; font-stretch: normal; font-size: 9px; line-height: normal; font-family: Verdana, Geneva, Arial, Helvetica, sans-serif; color: silver; border-left-width: 3px; border-left-style: solid; border-left-color: rgb(108, 226, 108); background-color: rgb(248, 248, 248);">

**\[csharp\]** [view
plain](http://blog.csdn.net/iispring/article/details/6888482# "view plain"){.ViewSource}<span
data-mod="popu_168"> [copy](http://blog.csdn.net/iispring/article/details/6888482# "copy"){.CopyToClipboard}</span>
<div
style="position: absolute; left: 673px; top: 808px; width: 18px; height: 18px; z-index: 99;">

</div>

<span data-mod="popu_169"></span>

</div>

</div>

1.  <span
    style="margin: 0px; padding: 0px; border: none; color: black; background-color: inherit;"><span
    class="keyword"
    style="margin: 0px; padding: 0px; border: none; color: rgb(0, 102, 153); background-color: inherit; font-weight: bold;">private</span><span
    style="margin: 0px; padding: 0px; border: none; background-color: inherit;"> </span><span
    class="keyword"
    style="margin: 0px; padding: 0px; border: none; color: rgb(0, 102, 153); background-color: inherit; font-weight: bold;">void</span><span
    style="margin: 0px; padding: 0px; border: none; background-color: inherit;"> TitleBar\_MouseMove(</span><span
    class="keyword"
    style="margin: 0px; padding: 0px; border: none; color: rgb(0, 102, 153); background-color: inherit; font-weight: bold;">object</span><span
    style="margin: 0px; padding: 0px; border: none; background-color: inherit;"> sender, MouseEventArgs e)  </span></span>
2.  <span
    style="margin: 0px; padding: 0px; border: none; color: black; background-color: inherit;">        {  </span>
3.  <span
    style="margin: 0px; padding: 0px; border: none; color: black; background-color: inherit;">            <span
    class="keyword"
    style="margin: 0px; padding: 0px; border: none; color: rgb(0, 102, 153); background-color: inherit; font-weight: bold;">if</span><span
    style="margin: 0px; padding: 0px; border: none; background-color: inherit;"> (e.LeftButton == MouseButtonState.Pressed)  </span></span>
4.  <span
    style="margin: 0px; padding: 0px; border: none; color: black; background-color: inherit;">            {  </span>
5.  <span
    style="margin: 0px; padding: 0px; border: none; color: black; background-color: inherit;">                <span
    class="keyword"
    style="margin: 0px; padding: 0px; border: none; color: rgb(0, 102, 153); background-color: inherit; font-weight: bold;">this</span><span
    style="margin: 0px; padding: 0px; border: none; background-color: inherit;">.DragMove();  </span></span>
6.  <span
    style="margin: 0px; padding: 0px; border: none; color: black; background-color: inherit;">            }  </span>
7.  <span
    style="margin: 0px; padding: 0px; border: none; color: black; background-color: inherit;">        }  </span>

</div>

\
<span
style="color: rgb(85, 85, 85); font-family: 'microsoft yahei'; font-variant-ligatures: normal; orphans: 2; widows: 2; background-color: rgb(255, 255, 255);">如果没有为自定义的TitleBar添加MouseMove事件，那么就无法拖动窗体。</span>

当然我写的这个标题栏比较简单，只是为了演示，大家可以扩充，根据需求放置最大化、最小化、关闭按钮等。\
\

前台所有代码:

<div class="dp-highlighter bg_csharp"
style="font-family: Consolas, 'Courier New', Courier, mono, serif; font-size: 12px; width: 940.497px; overflow: hidden; padding-top: 1px; position: relative; border-color: rgb(204, 204, 204); color: rgb(85, 85, 85); font-variant-ligatures: normal; orphans: 2; widows: 2; margin-top: 18px !important; margin-bottom: 18px !important; background-color: rgb(231, 229, 220);">

<div class="bar" style="padding-left: 45px;">

<div class="tools"
style="padding: 3px 8px 10px 10px; font-stretch: normal; font-size: 9px; line-height: normal; font-family: Verdana, Geneva, Arial, Helvetica, sans-serif; color: silver; border-left-width: 3px; border-left-style: solid; border-left-color: rgb(108, 226, 108); background-color: rgb(248, 248, 248);">

**\[csharp\]** [view
plain](http://blog.csdn.net/iispring/article/details/6888482# "view plain"){.ViewSource}<span
data-mod="popu_168"> [copy](http://blog.csdn.net/iispring/article/details/6888482# "copy"){.CopyToClipboard}</span>
<div
style="position: absolute; left: 673px; top: 1170px; width: 18px; height: 18px; z-index: 99;">

</div>

<span data-mod="popu_169"></span>

</div>

</div>

1.  <span
    style="margin: 0px; padding: 0px; border: none; color: black; background-color: inherit;"><span
    style="margin: 0px; padding: 0px; border: none; background-color: inherit;">&lt;Window x:Class=</span><span
    class="string"
    style="margin: 0px; padding: 0px; border: none; color: blue; background-color: inherit;">"WpfStudy.Window1"</span><span
    style="margin: 0px; padding: 0px; border: none; background-color: inherit;">  </span></span>
2.  <span
    style="margin: 0px; padding: 0px; border: none; color: black; background-color: inherit;">    xmlns=<span
    class="string"
    style="margin: 0px; padding: 0px; border: none; color: blue; background-color: inherit;">"http://schemas.microsoft.com/winfx/2006/xaml/presentation"</span><span
    style="margin: 0px; padding: 0px; border: none; background-color: inherit;"> WindowStyle=</span><span
    class="string"
    style="margin: 0px; padding: 0px; border: none; color: blue; background-color: inherit;">"None"</span><span
    style="margin: 0px; padding: 0px; border: none; background-color: inherit;">  </span></span>
3.  <span
    style="margin: 0px; padding: 0px; border: none; color: black; background-color: inherit;">    xmlns:x=<span
    class="string"
    style="margin: 0px; padding: 0px; border: none; color: blue; background-color: inherit;">"http://schemas.microsoft.com/winfx/2006/xaml"</span><span
    style="margin: 0px; padding: 0px; border: none; background-color: inherit;">  WindowStartupLocation=</span><span
    class="string"
    style="margin: 0px; padding: 0px; border: none; color: blue; background-color: inherit;">"CenterScreen"</span><span
    style="margin: 0px; padding: 0px; border: none; background-color: inherit;"> Topmost=</span><span
    class="string"
    style="margin: 0px; padding: 0px; border: none; color: blue; background-color: inherit;">"False"</span><span
    style="margin: 0px; padding: 0px; border: none; background-color: inherit;">  </span></span>
4.  <span
    style="margin: 0px; padding: 0px; border: none; color: black; background-color: inherit;">    SizeToContent=<span
    class="string"
    style="margin: 0px; padding: 0px; border: none; color: blue; background-color: inherit;">"WidthAndHeight"</span><span
    style="margin: 0px; padding: 0px; border: none; background-color: inherit;">     &gt;      </span></span>
5.  <span
    style="margin: 0px; padding: 0px; border: none; color: black; background-color: inherit;">    &lt;Grid &gt;         </span>
6.  <span
    style="margin: 0px; padding: 0px; border: none; color: black; background-color: inherit;">        &lt;Grid.RowDefinitions&gt;  </span>
7.  <span
    style="margin: 0px; padding: 0px; border: none; color: black; background-color: inherit;">            &lt;RowDefinition Height=<span
    class="string"
    style="margin: 0px; padding: 0px; border: none; color: blue; background-color: inherit;">"Auto"</span><span
    style="margin: 0px; padding: 0px; border: none; background-color: inherit;">/&gt;  </span></span>
8.  <span
    style="margin: 0px; padding: 0px; border: none; color: black; background-color: inherit;">            &lt;RowDefinition Height=<span
    class="string"
    style="margin: 0px; padding: 0px; border: none; color: blue; background-color: inherit;">"150"</span><span
    style="margin: 0px; padding: 0px; border: none; background-color: inherit;">/&gt;  </span></span>
9.  <span
    style="margin: 0px; padding: 0px; border: none; color: black; background-color: inherit;">        &lt;/Grid.RowDefinitions&gt;  </span>
10. <span
    style="margin: 0px; padding: 0px; border: none; color: black; background-color: inherit;">        &lt;Grid.ColumnDefinitions&gt;  </span>
11. <span
    style="margin: 0px; padding: 0px; border: none; color: black; background-color: inherit;">            &lt;ColumnDefinition Width=<span
    class="string"
    style="margin: 0px; padding: 0px; border: none; color: blue; background-color: inherit;">"300"</span><span
    style="margin: 0px; padding: 0px; border: none; background-color: inherit;">/&gt;             </span></span>
12. <span
    style="margin: 0px; padding: 0px; border: none; color: black; background-color: inherit;">        &lt;/Grid.ColumnDefinitions&gt;  </span>
13. <span
    style="margin: 0px; padding: 0px; border: none; color: black; background-color: inherit;">        &lt;Grid Grid.Row=<span
    class="string"
    style="margin: 0px; padding: 0px; border: none; color: blue; background-color: inherit;">" 0"</span><span
    style="margin: 0px; padding: 0px; border: none; background-color: inherit;"> x:Name=</span><span
    class="string"
    style="margin: 0px; padding: 0px; border: none; color: blue; background-color: inherit;">"TitleBar"</span><span
    style="margin: 0px; padding: 0px; border: none; background-color: inherit;"> Height=</span><span
    class="string"
    style="margin: 0px; padding: 0px; border: none; color: blue; background-color: inherit;">"Auto"</span><span
    style="margin: 0px; padding: 0px; border: none; background-color: inherit;"> MouseMove=</span><span
    class="string"
    style="margin: 0px; padding: 0px; border: none; color: blue; background-color: inherit;">"TitleBar\_MouseMove"</span><span
    style="margin: 0px; padding: 0px; border: none; background-color: inherit;"> Background=</span><span
    class="string"
    style="margin: 0px; padding: 0px; border: none; color: blue; background-color: inherit;">"Bisque"</span><span
    style="margin: 0px; padding: 0px; border: none; background-color: inherit;">&gt;  </span></span>
14. <span
    style="margin: 0px; padding: 0px; border: none; color: black; background-color: inherit;">            &lt;TextBlock Text=<span
    class="string"
    style="margin: 0px; padding: 0px; border: none; color: blue; background-color: inherit;">"这是标题栏"</span><span
    style="margin: 0px; padding: 0px; border: none; background-color: inherit;"> FontSize=</span><span
    class="string"
    style="margin: 0px; padding: 0px; border: none; color: blue; background-color: inherit;">"15"</span><span
    style="margin: 0px; padding: 0px; border: none; background-color: inherit;"> /&gt;  </span></span>
15. <span
    style="margin: 0px; padding: 0px; border: none; color: black; background-color: inherit;">        &lt;/Grid&gt;  </span>
16. <span
    style="margin: 0px; padding: 0px; border: none; color: black; background-color: inherit;">        &lt;Grid Grid.Row=<span
    class="string"
    style="margin: 0px; padding: 0px; border: none; color: blue; background-color: inherit;">" 1"</span><span
    style="margin: 0px; padding: 0px; border: none; background-color: inherit;"> Background=</span><span
    class="string"
    style="margin: 0px; padding: 0px; border: none; color: blue; background-color: inherit;">"Azure"</span><span
    style="margin: 0px; padding: 0px; border: none; background-color: inherit;">&gt;&lt;/Grid&gt;          </span></span>
17. <span
    style="margin: 0px; padding: 0px; border: none; color: black; background-color: inherit;">    &lt;/Grid&gt;  </span>
18. <span
    style="margin: 0px; padding: 0px; border: none; color: black; background-color: inherit;">&lt;/Window&gt;  </span>

</div>

\
<span
style="color: rgb(85, 85, 85); font-family: 'microsoft yahei'; font-variant-ligatures: normal; orphans: 2; widows: 2; background-color: rgb(255, 255, 255);">效果图:</span>

![](WPF自定义窗体标题栏_files/0.49617458833381534.png)\

这个示例够简单了，实在是不能再简化了\~\~

\

<div style="color:gray">

来源： <http://blog.csdn.net/iispring/article/details/6888482>

</div>
