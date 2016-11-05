C\#序列化和反序列化详解
<div>

<div>

例如，有一个这样的xml文本需要反序列化：

</div>

<div>

\

</div>

+--------------------------------------------------------------------------+
| <div>                                                                    |
|                                                                          |
| &lt;?xml version="1.0" encoding="utf-8"?&gt;                             |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div>                                                                    |
|                                                                          |
| &lt;UserData xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"       |
| xmlns:xsd="http://www.w3.org/2001/XMLSchema"&gt;                         |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div>                                                                    |
|                                                                          |
|     &lt;Clients&gt;                                                      |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div>                                                                    |
|                                                                          |
|         &lt;Client ipAddress="127.0.0.1"&gt;                             |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div>                                                                    |
|                                                                          |
|             &lt;Eyes&gt;                                                 |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div>                                                                    |
|                                                                          |
|                 &lt;Eye scale="-25"&gt;                                  |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div>                                                                    |
|                                                                          |
|                     &lt;OffsetLeft x="0" y="0" /&gt;                     |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div>                                                                    |
|                                                                          |
|                     &lt;OffsetRight x="0" y="0" /&gt;                    |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div>                                                                    |
|                                                                          |
|                     &lt;RangeLeft min="-25" max="25" /&gt;               |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div>                                                                    |
|                                                                          |
|                     &lt;RangeRight min="-25" max="25" /&gt;              |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div>                                                                    |
|                                                                          |
|                 &lt;/Eye&gt;                                             |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div>                                                                    |
|                                                                          |
|             &lt;/Eyes&gt;                                                |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div>                                                                    |
|                                                                          |
|         &lt;/Client&gt;                                                  |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div>                                                                    |
|                                                                          |
|         &lt;Client ipAddress="192.168.1.110"&gt;                         |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div>                                                                    |
|                                                                          |
|             &lt;Eyes&gt;                                                 |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div>                                                                    |
|                                                                          |
|                 &lt;Eye scale="-25"&gt;                                  |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div>                                                                    |
|                                                                          |
|                     &lt;OffsetLeft x="0" y="0" /&gt;                     |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div>                                                                    |
|                                                                          |
|                     &lt;OffsetRight x="0" y="0" /&gt;                    |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div>                                                                    |
|                                                                          |
|                     &lt;RangeLeft min="-25" max="25" /&gt;               |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div>                                                                    |
|                                                                          |
|                     &lt;RangeRight min="-25" max="25" /&gt;              |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div>                                                                    |
|                                                                          |
|                 &lt;/Eye&gt;                                             |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div>                                                                    |
|                                                                          |
|             &lt;/Eyes&gt;                                                |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div>                                                                    |
|                                                                          |
|         &lt;/Client&gt;                                                  |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div>                                                                    |
|                                                                          |
|         &lt;Client ipAddress="192.168.1.111"&gt;                         |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div>                                                                    |
|                                                                          |
|             &lt;Eyes&gt;                                                 |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div>                                                                    |
|                                                                          |
|                 &lt;Eye scale="-25"&gt;                                  |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div>                                                                    |
|                                                                          |
|                     &lt;OffsetLeft x="0" y="0" /&gt;                     |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div>                                                                    |
|                                                                          |
|                     &lt;OffsetRight x="0" y="0" /&gt;                    |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div>                                                                    |
|                                                                          |
|                     &lt;RangeLeft min="-25" max="25" /&gt;               |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div>                                                                    |
|                                                                          |
|                     &lt;RangeRight min="-25" max="25" /&gt;              |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div>                                                                    |
|                                                                          |
|                 &lt;/Eye&gt;                                             |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div>                                                                    |
|                                                                          |
|             &lt;/Eyes&gt;                                                |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div>                                                                    |
|                                                                          |
|         &lt;/Client&gt;                                                  |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div>                                                                    |
|                                                                          |
|         &lt;Client ipAddress="192.168.1.112"&gt;                         |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div>                                                                    |
|                                                                          |
|             &lt;Eyes&gt;                                                 |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div>                                                                    |
|                                                                          |
|                 &lt;Eye scale="-25"&gt;                                  |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div>                                                                    |
|                                                                          |
|                     &lt;OffsetLeft x="0" y="0" /&gt;                     |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div>                                                                    |
|                                                                          |
|                     &lt;OffsetRight x="0" y="0" /&gt;                    |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div>                                                                    |
|                                                                          |
|                     &lt;RangeLeft min="-25" max="25" /&gt;               |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div>                                                                    |
|                                                                          |
|                     &lt;RangeRight min="-25" max="25" /&gt;              |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div>                                                                    |
|                                                                          |
|                 &lt;/Eye&gt;                                             |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div>                                                                    |
|                                                                          |
|             &lt;/Eyes&gt;                                                |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div>                                                                    |
|                                                                          |
|         &lt;/Client&gt;                                                  |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div>                                                                    |
|                                                                          |
|     &lt;/Clients&gt;                                                     |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div>                                                                    |
|                                                                          |
| &lt;/UserData&gt;                                                        |
|                                                                          |
| </div>                                                                   |
+--------------------------------------------------------------------------+

<div>

\

</div>

<div>

我们需要构建模型类：

</div>

<div>

\

</div>

+--------------------------------------------------------------------------+
| <div align="left">                                                       |
|                                                                          |
| \[Serializable\]                                                         |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div align="left">                                                       |
|                                                                          |
| public class Offset                                                      |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div align="left">                                                       |
|                                                                          |
| {                                                                        |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div align="left">                                                       |
|                                                                          |
|     public Offset() { }                                                  |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div align="left">                                                       |
|                                                                          |
|     \[XmlAttribute\]                                                     |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div align="left">                                                       |
|                                                                          |
|     public float x;                                                      |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div align="left">                                                       |
|                                                                          |
|     \[XmlAttribute\]                                                     |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div align="left">                                                       |
|                                                                          |
|     public float y;                                                      |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div align="left">                                                       |
|                                                                          |
| }                                                                        |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div align="left">                                                       |
|                                                                          |
| \                                                                        |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div align="left">                                                       |
|                                                                          |
| \[Serializable\]                                                         |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div align="left">                                                       |
|                                                                          |
| public class Range                                                       |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div align="left">                                                       |
|                                                                          |
| {                                                                        |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div align="left">                                                       |
|                                                                          |
|     public Range() { }                                                   |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div align="left">                                                       |
|                                                                          |
|     \[XmlAttribute\]                                                     |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div align="left">                                                       |
|                                                                          |
|     public float min;                                                    |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div align="left">                                                       |
|                                                                          |
|     \[XmlAttribute\]                                                     |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div align="left">                                                       |
|                                                                          |
|     public float max;                                                    |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div align="left">                                                       |
|                                                                          |
| }                                                                        |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div align="left">                                                       |
|                                                                          |
| \                                                                        |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div align="left">                                                       |
|                                                                          |
| \[Serializable\]                                                         |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div align="left">                                                       |
|                                                                          |
| public class Eye                                                         |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div align="left">                                                       |
|                                                                          |
| {                                                                        |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div align="left">                                                       |
|                                                                          |
|     public Eye() { }                                                     |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div align="left">                                                       |
|                                                                          |
|     \[XmlAttribute\]                                                     |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div align="left">                                                       |
|                                                                          |
|     public float scale;                                                  |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div align="left">                                                       |
|                                                                          |
|     \[XmlElement("OffsetLeft")\]                                         |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div align="left">                                                       |
|                                                                          |
|     public Offset offsetLeft;                                            |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div align="left">                                                       |
|                                                                          |
|     \[XmlElement("OffsetRight")\]                                        |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div align="left">                                                       |
|                                                                          |
|     public Offset offsetRight;                                           |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div align="left">                                                       |
|                                                                          |
|     \[XmlElement("RangeLeft")\]                                          |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div align="left">                                                       |
|                                                                          |
|     public Range rangeLeft;                                              |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div align="left">                                                       |
|                                                                          |
|     \[XmlElement("RangeRight")\]                                         |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div align="left">                                                       |
|                                                                          |
|     public Range rangeRight;                                             |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div align="left">                                                       |
|                                                                          |
| }                                                                        |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div align="left">                                                       |
|                                                                          |
| \                                                                        |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div align="left">                                                       |
|                                                                          |
| \[Serializable\]                                                         |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div align="left">                                                       |
|                                                                          |
| public class Client                                                      |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div align="left">                                                       |
|                                                                          |
| {                                                                        |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div align="left">                                                       |
|                                                                          |
|     public Client() { }                                                  |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div align="left">                                                       |
|                                                                          |
|     \[XmlAttribute\]                                                     |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div align="left">                                                       |
|                                                                          |
|     public string ipAddress = "";                                        |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div align="left">                                                       |
|                                                                          |
|     \[XmlAttribute\]                                                     |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div align="left">                                                       |
|                                                                          |
|     public byte priority = 0;                                            |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div align="left">                                                       |
|                                                                          |
|     \[XmlArray("Eyes"), XmlArrayItem("Eye", typeof(Eye))\]               |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div align="left">                                                       |
|                                                                          |
|     public ArrayList eyes = new ArrayList();                             |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div align="left">                                                       |
|                                                                          |
| }                                                                        |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div align="left">                                                       |
|                                                                          |
| \                                                                        |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div align="left">                                                       |
|                                                                          |
| \[XmlRoot("UserData", Namespace = "", IsNullable = false)\]              |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div align="left">                                                       |
|                                                                          |
| public class UserData                                                    |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div align="left">                                                       |
|                                                                          |
| {                                                                        |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div align="left">                                                       |
|                                                                          |
|     public UserData()                                                    |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div align="left">                                                       |
|                                                                          |
|     {                                                                    |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div align="left">                                                       |
|                                                                          |
|     }                                                                    |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div align="left">                                                       |
|                                                                          |
| \                                                                        |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div align="left">                                                       |
|                                                                          |
|     \[XmlArray("Clients"), XmlArrayItem("Client", typeof(Client))\]      |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div align="left">                                                       |
|                                                                          |
|     public ArrayList clients = new ArrayList();                          |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| <div align="left">                                                       |
|                                                                          |
| }                                                                        |
|                                                                          |
| </div>                                                                   |
+--------------------------------------------------------------------------+

<div>

\

</div>

</div>
