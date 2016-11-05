使用Android Debug Bridge验证意图
<div>

<div>

可以使用adb工具来验证是否支持指定的意图：

</div>

<div>

\

</div>

<div
style="-en-codeblock: true; box-sizing: border-box; padding: 8px; font-family: Monaco, Menlo, Consolas, &quot;Courier New&quot;, monospace; font-size: 12px; color: rgb(51, 51, 51); border-top-left-radius: 4px; border-top-right-radius: 4px; border-bottom-right-radius: 4px; border-bottom-left-radius: 4px; background-color: rgb(251, 250, 248); border: 1px solid rgba(0, 0, 0, 0.14902); background-position: initial initial; background-repeat: initial initial;">

<div>

-
adb shell am start -a &lt;ACTION&gt; -t &lt;MIME\_TYPE&gt; -d &lt;DATA&gt; \\

</div>

<div>

  -e &lt;EXTRA\_NAME&gt; &lt;EXTRA\_VALUE&gt; -n &lt;ACTIVITY&gt;

</div>

</div>

<div>

\

</div>

<div>

For example:

</div>

<div>

\

</div>

<div
style="-en-codeblock: true; box-sizing: border-box; padding: 8px; font-family: Monaco, Menlo, Consolas, &quot;Courier New&quot;, monospace; font-size: 12px; color: rgb(51, 51, 51); border-top-left-radius: 4px; border-top-right-radius: 4px; border-bottom-right-radius: 4px; border-bottom-left-radius: 4px; background-color: rgb(251, 250, 248); border: 1px solid rgba(0, 0, 0, 0.14902); background-position: initial initial; background-repeat: initial initial;">

<div>

adb shell am start -a android.intent.action.DIAL \\

</div>

<div>

  -d tel:555-5555 -n org.example.MyApp/.MyActivity

</div>

</div>

<div>

\

</div>

</div>
