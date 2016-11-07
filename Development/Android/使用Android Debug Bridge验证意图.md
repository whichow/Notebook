使用Android Debug Bridge验证意图
可以使用adb工具来验证是否支持指定的意图：

- adb shell am start -a &lt;ACTION&gt; -t &lt;MIME\_TYPE&gt; -d &lt;DATA&gt; \\

  -e &lt;EXTRA\_NAME&gt; &lt;EXTRA\_VALUE&gt; -n &lt;ACTIVITY&gt;

For example:

adb shell am start -a android.intent.action.DIAL \\

  -d tel:555-5555 -n org.example.MyApp/.MyActivity


