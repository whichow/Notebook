       在wpf中要将窗口设置为透明，除了将窗口背景色的Alpha分量设置为0以外，**你还必须将窗口的AllowsTransparency属性设置为true**。
       还请注意的是窗体（window）中有一个默认的名为LayoutRoot的Grid对象，您应该将它的背景色的Alpha分量设置为0。 
        这里是一个Demo：它显示了一个圆形的不规则窗体。你可以将以下代码拷贝到XamlPad中查看效果:

&lt;Window

       xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"

       xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"

       xml:lang="zh-CN"

       x:Name="Window"

       Title="Window1"

       Width="420" Height="287" Visibility="Visible" ResizeMode="NoResize" SizeToContent="Manual" WindowStyle="None" Background="\#00FFFFFF" AllowsTransparency="True"&gt;

 

       &lt;Grid x:Name="LayoutRoot" OpacityMask="{x:Null}" Background="\#00000000"&gt;

              &lt;Ellipse Fill="\#FFB7ECDA" Stroke="\#FF172A9C" StrokeThickness="3" HorizontalAlignment="Right" Margin="0,0,140,60" VerticalAlignment="Bottom" Width="138" Height="138"/&gt;

       &lt;/Grid&gt;

&lt;/Window&gt;


