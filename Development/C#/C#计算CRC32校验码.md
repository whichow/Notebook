# C\#计算CRC32校验码
```csharp
Crc32 crc32 = new Crc32();
String hash = String.Empty;
using (FileStream fs = File.Open("c:\\myfile.txt", FileMode.Open))
{
    foreach (byte b in crc32.ComputeHash(fs))
    {
        hash += b.ToString("x2").ToLower();
    }
    Console.WriteLine("CRC-32 is {0}", hash);
}
```

第三方库：

[https://github.com/damieng/DamienGKit/blob/master/CSharp/DamienG.Library/Security/Cryptography/Crc32.cs](http://%20https://github.com/damieng/DamienGKit/blob/master/CSharp/DamienG.Library/Security/Cryptography/Crc32.cs)

