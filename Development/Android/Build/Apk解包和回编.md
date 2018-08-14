## 解包apk
```
apktool d example.apk
```
## 回编apk
```
apktool b example -o gen.apk
```
如果指定`-o`参数，生成的apk放在example的dist文件夹中

## 生成签名文件

```
keytool -genkeypair -keystore (name).keystore -validity 10000 -alias (name)
```
输入密钥库口令并回答一系列问题，生成签名文件(name).keystore
## 对apk签名
```
//keystore
jarsigner -keystore (name).keystore -verbose gen.apk (name)
//jks
jarsigner -verbose -keystore xxx.jks -signedjar xxx.apk（签名后的apk名字） xxx.apk（需要签名的apk） xxx（keystore别名)
```
需要输入密钥库口令