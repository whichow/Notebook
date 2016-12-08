# HTTP请求时URL编码问题

通过自己的服务器验证IAP的receipt时，总是验证不通过，发现是因为使用base64编码后的receipt字符串中含有`+`号，而发送到服务器后接受的字符串中没有`+`号。

像`?,&,+`等一些符号在URL中是有特殊含义的，如`+`号会被解释为空格，所以我们在发送之前需要对参数中的字符串进行URL编码。

使用`NSString`的`stringByAddingPercentEncodingWithAllowedCharacters`这个方法可以对字符串中的内容进行URL编码：
```
NSCharacterSet * queryKVSet = [NSCharacterSet
    characterSetWithCharactersInString:":/?&=;+!@#$()',*"
].invertedSet;

NSString * value = ...;
NSString * valueSafe = [value
    stringByAddingPercentEncodingWithAllowedCharacters:queryKVSet
];
```
会将字符串中的`:/?&=;+!@#$()',*`这些字符转换为`%`表示的格式，如`+`会转换为`%2B`。
