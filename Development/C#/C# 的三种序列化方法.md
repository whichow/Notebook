C\# 的三种序列化方法
序列化是将一个对象转换成字节流以达到将其长期保存在内存、数据库或文件中的处理过程。它的主要目的是保存对象的状态以便以后需要的时候使用。与其相反的过程叫做反序列化。

### 序列化一个对象

为了序列化一个对象，我们需要一个被序列化的对象，一个容纳被序列化了的对象的（字节）流和一个格式化器。进行序列化之前我们先看看System.Runtime.Serialization名字空间。ISerializable接口允许我们使任何类成为可序列化的类。

如果我们给自己写的类标识\[Serializable\]特性，我们就能将这些类序列化。除非类的成员标记了\[NonSerializable\]，序列化会将类中的所有成员都序列化。

**序列化的类型**

-   二进制（流）序列化
-   SOAP序列化
-   XML序列化

**二进制（流）序列化：**

**二进制（流）序列化**是一种将数据写到输出流，以使它能够用来自动重构成相应对象的机制。二进制，其名字就暗示它的必要信息是保存在存储介质上，而这些必要信息要求创建一个对象的精确的二进制副本。在二进制（流）序列化中，整个对象的状态都被保存起来，而XML序列化只有部分数据被保存起来。为了使用序列化，我们需要引入**System.Runtime.Serialization.Formatters.Binary**名字空间. 下面的代码使用**BinaryFormatter**类序列化.NET中的string类型的对象。

[?](http://www.oschina.net/translate/serialization-in-csharp#)

[TABLE]

**SOAP序列化：**

**SOAP**协议是一个在异构的应用程序之间进行信息交互的理想的选择。我们需要在应用程序中添加System.Runtime.Serialization.Formatters.Soap名字空间以便在.Net中使用**SOAP序列化**。**SOAP序列化**的主要优势在于可移植性。**SoapFormatter**把对象序列化成**SOAP**消息或解析**SOAP**消息并重构被序列化的对象。下面的代码在.Net中使用**SoapFormatter**类序列化string类的对象。

[?](http://www.oschina.net/translate/serialization-in-csharp#)

[TABLE]

**XML序列化：**

根据MSDN的描述，“**XML序列化**将一个对象或参数的公开字段和属性以及方法的返回值转换（序列化）成遵循XSD文档标准的XML流。因为XML是一个开放的标准，XML能被任何需要的程序处理，而不管在什么平台下，因此XML序列化被用到带有公开的属性和字段的强类型类中，它的这些发生和字段被转换成序列化的格式（在这里是XML）存储或传输。”

我们必须添加**System.XML.Serialization**引用以使用**XML序列化**。使用**XML序列化**的基础是**XmlSerializer**。下面的代码是在.Net中使用**XmlSerializer**类序列化string对象。

[?](http://www.oschina.net/translate/serialization-in-csharp#)

[TABLE]

**什么是格式化器？**

一个**格式化器**用来确定一个对象的序列格式。它们目的是在网络上传输一个对象之前将其序列化成合适的格式。它们提供**IFormatter**接口。在.NET里提供了两个格式化类：**BinaryFormatter**和**SoapFormatter**，它们都继承了**IFormatter**接口。

**使用序列化**

序列化允许开发人员保存一个对象的状态并在需要的时候重构对象，同时很好地支持对象存储和数据交换。通过序列化，开发人员可以利用Web Service发送对象到远端应用程序，从一个域传输对象到另一个域，以XML的格式传输一个对象并能通过防火墙，或者在应用程序间保持安全性或用户特定信息等等。


