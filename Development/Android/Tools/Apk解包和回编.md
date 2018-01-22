## 解包apk
```
apktool d example.apk
```
## 回编apk
```
apktool b example -o gen.apk
```
## 生成签名文件
```
keytool -genkeypair -keystore (name).keystore -validity 10000 -alias (name)
```
输入密钥库口令并回答一系列问题，生成签名文件(name).keystore
## 对apk签名
```
jarsigner -keystore (name).keystore -verbose gen.apk (name)
```
需要输入密钥库口令