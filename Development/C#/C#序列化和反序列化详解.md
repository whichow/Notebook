# C\#序列化和反序列化详解
例如，有一个这样的xml文本需要反序列化：

```xml

<?xml version="1.0" encoding="utf-8"?>
<UserData xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
    <Clients>
        <Client ipAddress="127.0.0.1">
            <Eyes>
                <Eye scale="-25">
                    <OffsetLeft x="0" y="0" />
                    <OffsetRight x="0" y="0" />
                    <RangeLeft min="-25" max="25" />
                    <RangeRight min="-25" max="25" />
                </Eye>
            </Eyes>
        </Client>
        <Client ipAddress="192.168.1.110">
            <Eyes>
                <Eye scale="-25">
                    <OffsetLeft x="0" y="0" />
                    <OffsetRight x="0" y="0" />
                    <RangeLeft min="-25" max="25" />
                    <RangeRight min="-25" max="25" />
                </Eye>
            </Eyes>
        </Client>
        <Client ipAddress="192.168.1.111">
            <Eyes>
                <Eye scale="-25">
                    <OffsetLeft x="0" y="0" />
                    <OffsetRight x="0" y="0" />
                    <RangeLeft min="-25" max="25" />
                    <RangeRight min="-25" max="25" />
                </Eye>
            </Eyes>
        </Client>
        <Client ipAddress="192.168.1.112">
            <Eyes>
                <Eye scale="-25">
                    <OffsetLeft x="0" y="0" />
                    <OffsetRight x="0" y="0" />
                    <RangeLeft min="-25" max="25" />
                    <RangeRight min="-25" max="25" />
                </Eye>
            </Eyes>
        </Client>
    </Clients>
</UserData>
```

我们需要构建模型类：
```csharp
[Serializable]
public class Offset
{
    public Offset() { }
    [XmlAttribute]
    public float x;
    [XmlAttribute]
    public float y;
}

[Serializable]
public class Range
{
    public Range() { }
    [XmlAttribute]
    public float min;
    [XmlAttribute]
    public float max;
}

[Serializable]
public class Eye
{
    public Eye() { }
    [XmlAttribute]
    public float scale;
    [XmlElement("OffsetLeft")]
    public Offset offsetLeft;
    [XmlElement("OffsetRight")]
    public Offset offsetRight;
    [XmlElement("RangeLeft")]
    public Range rangeLeft;
    [XmlElement("RangeRight")]
    public Range rangeRight;
}

[Serializable]
public class Client
{
    public Client() { }
    [XmlAttribute]
    public string ipAddress = "";
    [XmlAttribute]
    public byte priority = 0;
    [XmlArray("Eyes"), XmlArrayItem("Eye", typeof(Eye))]
    public ArrayList eyes = new ArrayList();
}

[XmlRoot("UserData", Namespace = "", IsNullable = false)]
public class UserData
{
    public UserData()
    {
    }

    [XmlArray("Clients"), XmlArrayItem("Client", typeof(Client))]
    public ArrayList clients = new ArrayList();
}
```


