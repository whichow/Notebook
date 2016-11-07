# 使用Android Debug Bridge验证意图
可以使用adb工具来验证是否支持指定的意图：
```shell
adb shell am start -a <ACTION> -t <MIME_TYPE> -d <DATA> -e <EXTRA_NAME> <EXTRA_VALUE> -n <ACTIVITY>
```
For example:
```shell
adb shell am start -a android.intent.action.DIAL -d tel:555-5555 -n org.example.MyApp.MyActivity
```

