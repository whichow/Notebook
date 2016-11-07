# C\#类型转换
使用**BitConverter**类可以在byte数组和各种基本类型之间进行转换  
例如：
```csharp
int value = 64;
byte[] bytes = BitConverter.GetBytes(v);

int intValue = BitConverter.ToInt32(bytes, 0);
```

