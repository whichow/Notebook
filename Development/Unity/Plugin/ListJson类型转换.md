LitJson默认整数使用的是long，而浮点数使用的是double，有些时候我们想使用int和float类型可是使用下面这种方式

```c#
LitJson.JsonMapper.RegisterExporter<float>((obj, writer) => writer.Write(Convert.ToDouble(obj)));
LitJson.JsonMapper.RegisterExporter<decimal>((obj, writer) => writer.Write(Convert.ToString(obj)));
//double转float
LitJson.JsonMapper.RegisterImporter<double, float>(input => Convert.ToSingle(input));
//long转int
LitJson.JsonMapper.RegisterImporter<long, int>(input => Convert.ToInt32(input));
//string转decimal
LitJson.JsonMapper.RegisterImporter<string, decimal>(input => Convert.ToDecimal(input));
```

