\
<span
style="color: rgb(51, 51, 51); font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 13.3333px; font-variant-ligatures: normal; orphans: 2; widows: 2; background-color: rgb(255, 255, 255);">      
在wpf中要将窗口设置为透明，除了将窗口背景色的Alpha分量设置为0以外，</span>**你还必须将窗口的AllowsTransparency属性设置为true**<span
style="color: rgb(51, 51, 51); font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 13.3333px; font-variant-ligatures: normal; orphans: 2; widows: 2; background-color: rgb(255, 255, 255);">。</span>\
<span
style="color: rgb(51, 51, 51); font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 13.3333px; font-variant-ligatures: normal; orphans: 2; widows: 2; background-color: rgb(255, 255, 255);">      
还请注意的是窗体（window）中有一个默认的名为LayoutRoot的Grid对象，您应该将它的背景色的Alpha分量设置为0。 </span>\
\
<span
style="color: rgb(51, 51, 51); font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 13.3333px; font-variant-ligatures: normal; orphans: 2; widows: 2; background-color: rgb(255, 255, 255);">       
这里是一个Demo：它显示了一个圆形的不规则窗体。你可以将以下代码拷贝到XamlPad中查看效果:</span>\
\

<span lang="EN-US" style="margin: 0px; padding: 0px;">&lt;Window</span>

<span lang="EN-US" style="margin: 0px; padding: 0px;"><span
style="margin: 0px; padding: 0px;">       </span>xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"</span>

<span lang="EN-US" style="margin: 0px; padding: 0px;"><span
style="margin: 0px; padding: 0px;">       </span>xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"</span>

<span lang="EN-US" style="margin: 0px; padding: 0px;"><span
style="margin: 0px; padding: 0px;">       </span>xml:lang="zh-CN"<span
style="margin: 0px; padding: 0px;"></span></span>

<span lang="EN-US" style="margin: 0px; padding: 0px;"><span
style="margin: 0px; padding: 0px;">       </span>x:Name="Window"</span>

<span lang="EN-US" style="margin: 0px; padding: 0px;"><span
style="margin: 0px; padding: 0px;">       </span>Title="Window1"</span>

<span lang="EN-US" style="margin: 0px; padding: 0px;"><span
style="margin: 0px; padding: 0px;">       </span>Width="420"
Height="287" Visibility="Visible" ResizeMode="NoResize"
SizeToContent="Manual" WindowStyle="None"
Background="\#00FFFFFF" AllowsTransparency="True"&gt;</span>

<span lang="EN-US" style="margin: 0px; padding: 0px;"> </span>

<span lang="EN-US" style="margin: 0px; padding: 0px;"><span
style="margin: 0px; padding: 0px;">       </span>&lt;Grid
x:Name="LayoutRoot" OpacityMask="{x:Null}"
Background="\#00000000"&gt;</span>

<span lang="EN-US" style="margin: 0px; padding: 0px;"><span
style="margin: 0px; padding: 0px;">              </span>&lt;Ellipse
Fill="\#FFB7ECDA" Stroke="\#FF172A9C" StrokeThickness="3"
HorizontalAlignment="Right" Margin="0,0,140,60"
VerticalAlignment="Bottom" Width="138" Height="138"/&gt;</span>

<span lang="EN-US" style="margin: 0px; padding: 0px;"><span
style="margin: 0px; padding: 0px;">       </span>&lt;/Grid&gt;</span>

<span lang="EN-US"
style="margin: 0px; padding: 0px;">&lt;/Window&gt;</span>

<div style="color:gray">

\

</div>
