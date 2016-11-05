C\# 的三种序列化方法
<div>

<div
style="margin: 0px 0px 5pt; padding: 0px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255);">

<div>

<div
style="margin: 0px 0px 5pt; padding: 0px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255);">

<div>

序列化是将一个对象转换成字节流以达到将其长期保存在内存、数据库或文件中的处理过程。它的主要目的是保存对象的状态以便以后需要的时候使用。与其相反的过程叫做反序列化。

### 序列化一个对象 {#序列化一个对象 style="margin: 0px 0px 10pt; padding: 0px 0px 5px; font-size: 12pt; border-bottom-width: 1px; border-bottom-style: solid; border-bottom-color: rgb(204, 204, 204); color: rgb(0, 0, 0); font-family: 'Microsoft YaHei', Verdana, sans-serif, SimSun; font-style: normal; font-variant: normal; letter-spacing: normal; orphans: auto; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255);"}

为了序列化一个对象，我们需要一个被序列化的对象，一个容纳被序列化了的对象的（字节）流和一个格式化器。进行序列化之前我们先看看System.Runtime.Serialization名字空间。ISerializable接口允许我们使任何类成为可序列化的类。

如果我们给自己写的类标识\[Serializable\]特性，我们就能将这些类序列化。除非类的成员标记了\[NonSerializable\]，序列化会将类中的所有成员都序列化。

**序列化的类型**

-   <span
    style="margin: 0px; padding: 0px; font-size: 10pt;">二进制（流）序列化</span>
-   <span
    style="margin: 0px; padding: 0px; font-size: 10pt;">SOAP序列化</span>
-   <span
    style="margin: 0px; padding: 0px; font-size: 10pt;">XML序列化</span>

</div>

<div>

<span style="font-size: 14px;"><span
style="font-family: 'Microsoft YaHei', Verdana, sans-serif, SimSun;">**二进制（流）序列化：**</span></span>

</div>

</div>

**二进制（流）序列化**是一种将数据写到输出流，以使它能够用来自动重构成相应对象的机制。二进制，其名字就暗示它的必要信息是保存在存储介质上，而这些必要信息要求创建一个对象的精确的二进制副本。在二进制（流）序列化中，整个对象的状态都被保存起来，而XML序列化只有部分数据被保存起来。为了使用序列化，我们需要引入**System.Runtime.Serialization.Formatters.Binary**名字空间.
下面的代码使用**BinaryFormatter**类序列化.NET中的string类型的对象。

<div
style="margin: 0px; padding: 0px; color: rgb(0, 0, 0); font-family: 'Microsoft YaHei', Verdana, sans-serif, SimSun; font-size: 14px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: auto; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255);">

<div
style="margin: 1em 0px !important; padding: 0px; width: 733px; position: relative !important; overflow: auto !important; font-size: 1em !important; background-color: rgb(255, 255, 255) !important;">

<div
style="margin: 0px !important; padding: 5px 0px 5px 5px; border-radius: 0px !important; border: 1px solid rgb(231, 229, 220) !important; bottom: auto !important; float: none !important; height: 11px !important; left: auto !important; outline: 0px !important; overflow: hidden; position: absolute !important; right: 1px !important; text-align: left !important; top: 1px !important; vertical-align: baseline !important; width: 11px !important; box-sizing: content-box !important; font-family: Consolas, 'Bitstream Vera Sans Mono', 'Courier New', Courier, monospace !important; font-weight: normal !important; font-style: normal !important; font-size: 10px !important; min-height: auto !important; color: white !important; z-index: 10 !important; background: rgb(248, 248, 248) !important;">

<div>

<span
style="margin: 0px; padding: 0px;">[?](http://www.oschina.net/translate/serialization-in-csharp#)</span>

</div>

</div>

+--------------------------------------+--------------------------------------+
| <div                                 | <div                                 |
| style="margin: 0px !important; paddi | style="margin: 0px !important; paddi |
| ng: 0px 0.5em 0px 1em !important; bo | ng: 0px !important; border-radius: 0 |
| rder-radius: 0px !important; border- | px !important; border: 0px !importan |
| width: 0px 3px 0px 0px !important; b | t; bottom: auto !important; float: n |
| order-right-style: solid !important; | one !important; height: auto !import |
|  border-right-color: rgb(108, 226, 1 | ant; left: auto !important; outline: |
| 08) !important; bottom: auto !import |  0px !important; overflow: visible ! |
| ant; float: none !important; height: | important; position: relative !impor |
|  auto !important; left: auto !import | tant; right: auto !important; text-a |
| ant; outline: 0px !important; overfl | lign: left !important; top: auto !im |
| ow: visible !important; position: st | portant; vertical-align: baseline !i |
| atic !important; right: auto !import | mportant; width: auto !important; bo |
| ant; text-align: right !important; t | x-sizing: content-box !important; fo |
| op: auto !important; vertical-align: | nt-family: Consolas, 'Bitstream Vera |
|  baseline !important; width: auto !i |  Sans Mono', 'Courier New', Courier, |
| mportant; box-sizing: content-box !i |  monospace !important; font-weight:  |
| mportant; font-family: Consolas, 'Bi | normal !important; font-style: norma |
| tstream Vera Sans Mono', 'Courier Ne | l !important; font-size: 1em !import |
| w', Courier, monospace !important; f | ant; min-height: auto !important; ba |
| ont-weight: normal !important; font- | ckground: none !important;">         |
| style: normal !important; font-size: |                                      |
|  1em !important; min-height: auto !i | <div                                 |
| mportant; white-space: pre !importan | style="margin: 0px !important; paddi |
| t; background: none rgb(248, 248, 24 | ng: 0px 1em !important; border-radiu |
| 8) !important;">                     | s: 0px !important; border: 0px !impo |
|                                      | rtant; bottom: auto !important; floa |
| 1                                    | t: none !important; height: auto !im |
|                                      | portant; left: auto !important; outl |
| </div>                               | ine: 0px !important; overflow: visib |
|                                      | le !important; position: static !imp |
| <div                                 | ortant; right: auto !important; text |
| style="margin: 0px !important; paddi | -align: left !important; top: auto ! |
| ng: 0px 0.5em 0px 1em !important; bo | important; vertical-align: baseline  |
| rder-radius: 0px !important; border- | !important; width: auto !important;  |
| width: 0px 3px 0px 0px !important; b | box-sizing: content-box !important;  |
| order-right-style: solid !important; | font-family: Consolas, 'Bitstream Ve |
|  border-right-color: rgb(108, 226, 1 | ra Sans Mono', 'Courier New', Courie |
| 08) !important; bottom: auto !import | r, monospace !important; font-weight |
| ant; float: none !important; height: | : normal !important; font-style: nor |
|  auto !important; left: auto !import | mal !important; font-size: 1em !impo |
| ant; outline: 0px !important; overfl | rtant; min-height: auto !important;  |
| ow: visible !important; position: st | white-space: pre !important; backgro |
| atic !important; right: auto !import | und: none rgb(248, 248, 248) !import |
| ant; text-align: right !important; t | ant;">                               |
| op: auto !important; vertical-align: |                                      |
|  baseline !important; width: auto !i | `using`{style="margin: 0px !importan |
| mportant; box-sizing: content-box !i | t; padding: 0px !important; white-sp |
| mportant; font-family: Consolas, 'Bi | ace: nowrap; border: 0px !important; |
| tstream Vera Sans Mono', 'Courier Ne |  border-radius: 0px !important; bott |
| w', Courier, monospace !important; f | om: auto !important; float: none !im |
| ont-weight: normal !important; font- | portant; height: auto !important; le |
| style: normal !important; font-size: | ft: auto !important; outline: 0px !i |
|  1em !important; min-height: auto !i | mportant; overflow: visible !importa |
| mportant; white-space: pre !importan | nt; position: static !important; rig |
| t; background: none rgb(255, 255, 25 | ht: auto !important; text-align: lef |
| 5) !important;">                     | t !important; top: auto !important;  |
|                                      | vertical-align: baseline !important; |
| 2                                    |  width: auto !important; box-sizing: |
|                                      |  content-box !important; font-family |
| </div>                               | : Consolas, 'Bitstream Vera Sans Mon |
|                                      | o', 'Courier New', Courier, monospac |
| <div                                 | e !important; font-weight: bold !imp |
| style="margin: 0px !important; paddi | ortant; font-style: normal !importan |
| ng: 0px 0.5em 0px 1em !important; bo | t; font-size: 1em !important; min-he |
| rder-radius: 0px !important; border- | ight: auto !important; color: rgb(0, |
| width: 0px 3px 0px 0px !important; b |  102, 153) !important; background: n |
| order-right-style: solid !important; | one !important;"}                    |
|  border-right-color: rgb(108, 226, 1 | `System;`{style="margin: 0px !import |
| 08) !important; bottom: auto !import | ant; padding: 0px !important; white- |
| ant; float: none !important; height: | space: nowrap; border: 0px !importan |
|  auto !important; left: auto !import | t; border-radius: 0px !important; bo |
| ant; outline: 0px !important; overfl | ttom: auto !important; float: none ! |
| ow: visible !important; position: st | important; height: auto !important;  |
| atic !important; right: auto !import | left: auto !important; outline: 0px  |
| ant; text-align: right !important; t | !important; overflow: visible !impor |
| op: auto !important; vertical-align: | tant; position: static !important; r |
|  baseline !important; width: auto !i | ight: auto !important; text-align: l |
| mportant; box-sizing: content-box !i | eft !important; top: auto !important |
| mportant; font-family: Consolas, 'Bi | ; vertical-align: baseline !importan |
| tstream Vera Sans Mono', 'Courier Ne | t; width: auto !important; box-sizin |
| w', Courier, monospace !important; f | g: content-box !important; font-fami |
| ont-weight: normal !important; font- | ly: Consolas, 'Bitstream Vera Sans M |
| style: normal !important; font-size: | ono', 'Courier New', Courier, monosp |
|  1em !important; min-height: auto !i | ace !important; font-weight: normal  |
| mportant; white-space: pre !importan | !important; font-style: normal !impo |
| t; background: none rgb(248, 248, 24 | rtant; font-size: 1em !important; mi |
| 8) !important;">                     | n-height: auto !important; color: rg |
|                                      | b(0, 0, 0) !important; background: n |
| 3                                    | one !important;"}                    |
|                                      |                                      |
| </div>                               | </div>                               |
|                                      |                                      |
| <div                                 | <div                                 |
| style="margin: 0px !important; paddi | style="margin: 0px !important; paddi |
| ng: 0px 0.5em 0px 1em !important; bo | ng: 0px 1em !important; border-radiu |
| rder-radius: 0px !important; border- | s: 0px !important; border: 0px !impo |
| width: 0px 3px 0px 0px !important; b | rtant; bottom: auto !important; floa |
| order-right-style: solid !important; | t: none !important; height: auto !im |
|  border-right-color: rgb(108, 226, 1 | portant; left: auto !important; outl |
| 08) !important; bottom: auto !import | ine: 0px !important; overflow: visib |
| ant; float: none !important; height: | le !important; position: static !imp |
|  auto !important; left: auto !import | ortant; right: auto !important; text |
| ant; outline: 0px !important; overfl | -align: left !important; top: auto ! |
| ow: visible !important; position: st | important; vertical-align: baseline  |
| atic !important; right: auto !import | !important; width: auto !important;  |
| ant; text-align: right !important; t | box-sizing: content-box !important;  |
| op: auto !important; vertical-align: | font-family: Consolas, 'Bitstream Ve |
|  baseline !important; width: auto !i | ra Sans Mono', 'Courier New', Courie |
| mportant; box-sizing: content-box !i | r, monospace !important; font-weight |
| mportant; font-family: Consolas, 'Bi | : normal !important; font-style: nor |
| tstream Vera Sans Mono', 'Courier Ne | mal !important; font-size: 1em !impo |
| w', Courier, monospace !important; f | rtant; min-height: auto !important;  |
| ont-weight: normal !important; font- | white-space: pre !important; backgro |
| style: normal !important; font-size: | und: none rgb(255, 255, 255) !import |
|  1em !important; min-height: auto !i | ant;">                               |
| mportant; white-space: pre !importan |                                      |
| t; background: none rgb(255, 255, 25 | `using`{style="margin: 0px !importan |
| 5) !important;">                     | t; padding: 0px !important; white-sp |
|                                      | ace: nowrap; border: 0px !important; |
| 4                                    |  border-radius: 0px !important; bott |
|                                      | om: auto !important; float: none !im |
| </div>                               | portant; height: auto !important; le |
|                                      | ft: auto !important; outline: 0px !i |
| <div                                 | mportant; overflow: visible !importa |
| style="margin: 0px !important; paddi | nt; position: static !important; rig |
| ng: 0px 0.5em 0px 1em !important; bo | ht: auto !important; text-align: lef |
| rder-radius: 0px !important; border- | t !important; top: auto !important;  |
| width: 0px 3px 0px 0px !important; b | vertical-align: baseline !important; |
| order-right-style: solid !important; |  width: auto !important; box-sizing: |
|  border-right-color: rgb(108, 226, 1 |  content-box !important; font-family |
| 08) !important; bottom: auto !import | : Consolas, 'Bitstream Vera Sans Mon |
| ant; float: none !important; height: | o', 'Courier New', Courier, monospac |
|  auto !important; left: auto !import | e !important; font-weight: bold !imp |
| ant; outline: 0px !important; overfl | ortant; font-style: normal !importan |
| ow: visible !important; position: st | t; font-size: 1em !important; min-he |
| atic !important; right: auto !import | ight: auto !important; color: rgb(0, |
| ant; text-align: right !important; t |  102, 153) !important; background: n |
| op: auto !important; vertical-align: | one !important;"}                    |
|  baseline !important; width: auto !i | `System.IO;`{style="margin: 0px !imp |
| mportant; box-sizing: content-box !i | ortant; padding: 0px !important; whi |
| mportant; font-family: Consolas, 'Bi | te-space: nowrap; border: 0px !impor |
| tstream Vera Sans Mono', 'Courier Ne | tant; border-radius: 0px !important; |
| w', Courier, monospace !important; f |  bottom: auto !important; float: non |
| ont-weight: normal !important; font- | e !important; height: auto !importan |
| style: normal !important; font-size: | t; left: auto !important; outline: 0 |
|  1em !important; min-height: auto !i | px !important; overflow: visible !im |
| mportant; white-space: pre !importan | portant; position: static !important |
| t; background: none rgb(248, 248, 24 | ; right: auto !important; text-align |
| 8) !important;">                     | : left !important; top: auto !import |
|                                      | ant; vertical-align: baseline !impor |
| 5                                    | tant; width: auto !important; box-si |
|                                      | zing: content-box !important; font-f |
| </div>                               | amily: Consolas, 'Bitstream Vera San |
|                                      | s Mono', 'Courier New', Courier, mon |
| <div                                 | ospace !important; font-weight: norm |
| style="margin: 0px !important; paddi | al !important; font-style: normal !i |
| ng: 0px 0.5em 0px 1em !important; bo | mportant; font-size: 1em !important; |
| rder-radius: 0px !important; border- |  min-height: auto !important; color: |
| width: 0px 3px 0px 0px !important; b |  rgb(0, 0, 0) !important; background |
| order-right-style: solid !important; | : none !important;"}                 |
|  border-right-color: rgb(108, 226, 1 |                                      |
| 08) !important; bottom: auto !import | </div>                               |
| ant; float: none !important; height: |                                      |
|  auto !important; left: auto !import | <div                                 |
| ant; outline: 0px !important; overfl | style="margin: 0px !important; paddi |
| ow: visible !important; position: st | ng: 0px 1em !important; border-radiu |
| atic !important; right: auto !import | s: 0px !important; border: 0px !impo |
| ant; text-align: right !important; t | rtant; bottom: auto !important; floa |
| op: auto !important; vertical-align: | t: none !important; height: auto !im |
|  baseline !important; width: auto !i | portant; left: auto !important; outl |
| mportant; box-sizing: content-box !i | ine: 0px !important; overflow: visib |
| mportant; font-family: Consolas, 'Bi | le !important; position: static !imp |
| tstream Vera Sans Mono', 'Courier Ne | ortant; right: auto !important; text |
| w', Courier, monospace !important; f | -align: left !important; top: auto ! |
| ont-weight: normal !important; font- | important; vertical-align: baseline  |
| style: normal !important; font-size: | !important; width: auto !important;  |
|  1em !important; min-height: auto !i | box-sizing: content-box !important;  |
| mportant; white-space: pre !importan | font-family: Consolas, 'Bitstream Ve |
| t; background: none rgb(255, 255, 25 | ra Sans Mono', 'Courier New', Courie |
| 5) !important;">                     | r, monospace !important; font-weight |
|                                      | : normal !important; font-style: nor |
| 6                                    | mal !important; font-size: 1em !impo |
|                                      | rtant; min-height: auto !important;  |
| </div>                               | white-space: pre !important; backgro |
|                                      | und: none rgb(248, 248, 248) !import |
| <div                                 | ant;">                               |
| style="margin: 0px !important; paddi |                                      |
| ng: 0px 0.5em 0px 1em !important; bo | `using`{style="margin: 0px !importan |
| rder-radius: 0px !important; border- | t; padding: 0px !important; white-sp |
| width: 0px 3px 0px 0px !important; b | ace: nowrap; border: 0px !important; |
| order-right-style: solid !important; |  border-radius: 0px !important; bott |
|  border-right-color: rgb(108, 226, 1 | om: auto !important; float: none !im |
| 08) !important; bottom: auto !import | portant; height: auto !important; le |
| ant; float: none !important; height: | ft: auto !important; outline: 0px !i |
|  auto !important; left: auto !import | mportant; overflow: visible !importa |
| ant; outline: 0px !important; overfl | nt; position: static !important; rig |
| ow: visible !important; position: st | ht: auto !important; text-align: lef |
| atic !important; right: auto !import | t !important; top: auto !important;  |
| ant; text-align: right !important; t | vertical-align: baseline !important; |
| op: auto !important; vertical-align: |  width: auto !important; box-sizing: |
|  baseline !important; width: auto !i |  content-box !important; font-family |
| mportant; box-sizing: content-box !i | : Consolas, 'Bitstream Vera Sans Mon |
| mportant; font-family: Consolas, 'Bi | o', 'Courier New', Courier, monospac |
| tstream Vera Sans Mono', 'Courier Ne | e !important; font-weight: bold !imp |
| w', Courier, monospace !important; f | ortant; font-style: normal !importan |
| ont-weight: normal !important; font- | t; font-size: 1em !important; min-he |
| style: normal !important; font-size: | ight: auto !important; color: rgb(0, |
|  1em !important; min-height: auto !i |  102, 153) !important; background: n |
| mportant; white-space: pre !importan | one !important;"}                    |
| t; background: none rgb(248, 248, 24 | `System.Runtime.Serialization;`{styl |
| 8) !important;">                     | e="margin: 0px !important; padding:  |
|                                      | 0px !important; white-space: nowrap; |
| 7                                    |  border: 0px !important; border-radi |
|                                      | us: 0px !important; bottom: auto !im |
| </div>                               | portant; float: none !important; hei |
|                                      | ght: auto !important; left: auto !im |
| <div                                 | portant; outline: 0px !important; ov |
| style="margin: 0px !important; paddi | erflow: visible !important; position |
| ng: 0px 0.5em 0px 1em !important; bo | : static !important; right: auto !im |
| rder-radius: 0px !important; border- | portant; text-align: left !important |
| width: 0px 3px 0px 0px !important; b | ; top: auto !important; vertical-ali |
| order-right-style: solid !important; | gn: baseline !important; width: auto |
|  border-right-color: rgb(108, 226, 1 |  !important; box-sizing: content-box |
| 08) !important; bottom: auto !import |  !important; font-family: Consolas,  |
| ant; float: none !important; height: | 'Bitstream Vera Sans Mono', 'Courier |
|  auto !important; left: auto !import |  New', Courier, monospace !important |
| ant; outline: 0px !important; overfl | ; font-weight: normal !important; fo |
| ow: visible !important; position: st | nt-style: normal !important; font-si |
| atic !important; right: auto !import | ze: 1em !important; min-height: auto |
| ant; text-align: right !important; t |  !important; color: rgb(0, 0, 0) !im |
| op: auto !important; vertical-align: | portant; background: none !important |
|  baseline !important; width: auto !i | ;"}                                  |
| mportant; box-sizing: content-box !i |                                      |
| mportant; font-family: Consolas, 'Bi | </div>                               |
| tstream Vera Sans Mono', 'Courier Ne |                                      |
| w', Courier, monospace !important; f | <div                                 |
| ont-weight: normal !important; font- | style="margin: 0px !important; paddi |
| style: normal !important; font-size: | ng: 0px 1em !important; border-radiu |
|  1em !important; min-height: auto !i | s: 0px !important; border: 0px !impo |
| mportant; white-space: pre !importan | rtant; bottom: auto !important; floa |
| t; background: none rgb(255, 255, 25 | t: none !important; height: auto !im |
| 5) !important;">                     | portant; left: auto !important; outl |
|                                      | ine: 0px !important; overflow: visib |
| 8                                    | le !important; position: static !imp |
|                                      | ortant; right: auto !important; text |
| </div>                               | -align: left !important; top: auto ! |
|                                      | important; vertical-align: baseline  |
| <div                                 | !important; width: auto !important;  |
| style="margin: 0px !important; paddi | box-sizing: content-box !important;  |
| ng: 0px 0.5em 0px 1em !important; bo | font-family: Consolas, 'Bitstream Ve |
| rder-radius: 0px !important; border- | ra Sans Mono', 'Courier New', Courie |
| width: 0px 3px 0px 0px !important; b | r, monospace !important; font-weight |
| order-right-style: solid !important; | : normal !important; font-style: nor |
|  border-right-color: rgb(108, 226, 1 | mal !important; font-size: 1em !impo |
| 08) !important; bottom: auto !import | rtant; min-height: auto !important;  |
| ant; float: none !important; height: | white-space: pre !important; backgro |
|  auto !important; left: auto !import | und: none rgb(255, 255, 255) !import |
| ant; outline: 0px !important; overfl | ant;">                               |
| ow: visible !important; position: st |                                      |
| atic !important; right: auto !import | `using`{style="margin: 0px !importan |
| ant; text-align: right !important; t | t; padding: 0px !important; white-sp |
| op: auto !important; vertical-align: | ace: nowrap; border: 0px !important; |
|  baseline !important; width: auto !i |  border-radius: 0px !important; bott |
| mportant; box-sizing: content-box !i | om: auto !important; float: none !im |
| mportant; font-family: Consolas, 'Bi | portant; height: auto !important; le |
| tstream Vera Sans Mono', 'Courier Ne | ft: auto !important; outline: 0px !i |
| w', Courier, monospace !important; f | mportant; overflow: visible !importa |
| ont-weight: normal !important; font- | nt; position: static !important; rig |
| style: normal !important; font-size: | ht: auto !important; text-align: lef |
|  1em !important; min-height: auto !i | t !important; top: auto !important;  |
| mportant; white-space: pre !importan | vertical-align: baseline !important; |
| t; background: none rgb(248, 248, 24 |  width: auto !important; box-sizing: |
| 8) !important;">                     |  content-box !important; font-family |
|                                      | : Consolas, 'Bitstream Vera Sans Mon |
| 9                                    | o', 'Courier New', Courier, monospac |
|                                      | e !important; font-weight: bold !imp |
| </div>                               | ortant; font-style: normal !importan |
|                                      | t; font-size: 1em !important; min-he |
| <div                                 | ight: auto !important; color: rgb(0, |
| style="margin: 0px !important; paddi |  102, 153) !important; background: n |
| ng: 0px 0.5em 0px 1em !important; bo | one !important;"}                    |
| rder-radius: 0px !important; border- | `System.Runtime.Serialization.Format |
| width: 0px 3px 0px 0px !important; b | ters.Binary;`{style="margin: 0px !im |
| order-right-style: solid !important; | portant; padding: 0px !important; wh |
|  border-right-color: rgb(108, 226, 1 | ite-space: nowrap; border: 0px !impo |
| 08) !important; bottom: auto !import | rtant; border-radius: 0px !important |
| ant; float: none !important; height: | ; bottom: auto !important; float: no |
|  auto !important; left: auto !import | ne !important; height: auto !importa |
| ant; outline: 0px !important; overfl | nt; left: auto !important; outline:  |
| ow: visible !important; position: st | 0px !important; overflow: visible !i |
| atic !important; right: auto !import | mportant; position: static !importan |
| ant; text-align: right !important; t | t; right: auto !important; text-alig |
| op: auto !important; vertical-align: | n: left !important; top: auto !impor |
|  baseline !important; width: auto !i | tant; vertical-align: baseline !impo |
| mportant; box-sizing: content-box !i | rtant; width: auto !important; box-s |
| mportant; font-family: Consolas, 'Bi | izing: content-box !important; font- |
| tstream Vera Sans Mono', 'Courier Ne | family: Consolas, 'Bitstream Vera Sa |
| w', Courier, monospace !important; f | ns Mono', 'Courier New', Courier, mo |
| ont-weight: normal !important; font- | nospace !important; font-weight: nor |
| style: normal !important; font-size: | mal !important; font-style: normal ! |
|  1em !important; min-height: auto !i | important; font-size: 1em !important |
| mportant; white-space: pre !importan | ; min-height: auto !important; color |
| t; background: none rgb(255, 255, 25 | : rgb(0, 0, 0) !important; backgroun |
| 5) !important;">                     | d: none !important;"}                |
|                                      |                                      |
| 10                                   | </div>                               |
|                                      |                                      |
| </div>                               | <div                                 |
|                                      | style="margin: 0px !important; paddi |
| <div                                 | ng: 0px 1em !important; border-radiu |
| style="margin: 0px !important; paddi | s: 0px !important; border: 0px !impo |
| ng: 0px 0.5em 0px 1em !important; bo | rtant; bottom: auto !important; floa |
| rder-radius: 0px !important; border- | t: none !important; height: auto !im |
| width: 0px 3px 0px 0px !important; b | portant; left: auto !important; outl |
| order-right-style: solid !important; | ine: 0px !important; overflow: visib |
|  border-right-color: rgb(108, 226, 1 | le !important; position: static !imp |
| 08) !important; bottom: auto !import | ortant; right: auto !important; text |
| ant; float: none !important; height: | -align: left !important; top: auto ! |
|  auto !important; left: auto !import | important; vertical-align: baseline  |
| ant; outline: 0px !important; overfl | !important; width: auto !important;  |
| ow: visible !important; position: st | box-sizing: content-box !important;  |
| atic !important; right: auto !import | font-family: Consolas, 'Bitstream Ve |
| ant; text-align: right !important; t | ra Sans Mono', 'Courier New', Courie |
| op: auto !important; vertical-align: | r, monospace !important; font-weight |
|  baseline !important; width: auto !i | : normal !important; font-style: nor |
| mportant; box-sizing: content-box !i | mal !important; font-size: 1em !impo |
| mportant; font-family: Consolas, 'Bi | rtant; min-height: auto !important;  |
| tstream Vera Sans Mono', 'Courier Ne | white-space: pre !important; backgro |
| w', Courier, monospace !important; f | und: none rgb(248, 248, 248) !import |
| ont-weight: normal !important; font- | ant;">                               |
| style: normal !important; font-size: |                                      |
|  1em !important; min-height: auto !i |                                      |
| mportant; white-space: pre !importan |                                      |
| t; background: none rgb(248, 248, 24 | </div>                               |
| 8) !important;">                     |                                      |
|                                      | <div                                 |
| 11                                   | style="margin: 0px !important; paddi |
|                                      | ng: 0px 1em !important; border-radiu |
| </div>                               | s: 0px !important; border: 0px !impo |
|                                      | rtant; bottom: auto !important; floa |
| <div                                 | t: none !important; height: auto !im |
| style="margin: 0px !important; paddi | portant; left: auto !important; outl |
| ng: 0px 0.5em 0px 1em !important; bo | ine: 0px !important; overflow: visib |
| rder-radius: 0px !important; border- | le !important; position: static !imp |
| width: 0px 3px 0px 0px !important; b | ortant; right: auto !important; text |
| order-right-style: solid !important; | -align: left !important; top: auto ! |
|  border-right-color: rgb(108, 226, 1 | important; vertical-align: baseline  |
| 08) !important; bottom: auto !import | !important; width: auto !important;  |
| ant; float: none !important; height: | box-sizing: content-box !important;  |
|  auto !important; left: auto !import | font-family: Consolas, 'Bitstream Ve |
| ant; outline: 0px !important; overfl | ra Sans Mono', 'Courier New', Courie |
| ow: visible !important; position: st | r, monospace !important; font-weight |
| atic !important; right: auto !import | : normal !important; font-style: nor |
| ant; text-align: right !important; t | mal !important; font-size: 1em !impo |
| op: auto !important; vertical-align: | rtant; min-height: auto !important;  |
|  baseline !important; width: auto !i | white-space: pre !important; backgro |
| mportant; box-sizing: content-box !i | und: none rgb(255, 255, 255) !import |
| mportant; font-family: Consolas, 'Bi | ant;">                               |
| tstream Vera Sans Mono', 'Courier Ne |                                      |
| w', Courier, monospace !important; f | `namespace`{style="margin: 0px !impo |
| ont-weight: normal !important; font- | rtant; padding: 0px !important; whit |
| style: normal !important; font-size: | e-space: nowrap; border: 0px !import |
|  1em !important; min-height: auto !i | ant; border-radius: 0px !important;  |
| mportant; white-space: pre !importan | bottom: auto !important; float: none |
| t; background: none rgb(255, 255, 25 |  !important; height: auto !important |
| 5) !important;">                     | ; left: auto !important; outline: 0p |
|                                      | x !important; overflow: visible !imp |
| 12                                   | ortant; position: static !important; |
|                                      |  right: auto !important; text-align: |
| </div>                               |  left !important; top: auto !importa |
|                                      | nt; vertical-align: baseline !import |
| <div                                 | ant; width: auto !important; box-siz |
| style="margin: 0px !important; paddi | ing: content-box !important; font-fa |
| ng: 0px 0.5em 0px 1em !important; bo | mily: Consolas, 'Bitstream Vera Sans |
| rder-radius: 0px !important; border- |  Mono', 'Courier New', Courier, mono |
| width: 0px 3px 0px 0px !important; b | space !important; font-weight: bold  |
| order-right-style: solid !important; | !important; font-style: normal !impo |
|  border-right-color: rgb(108, 226, 1 | rtant; font-size: 1em !important; mi |
| 08) !important; bottom: auto !import | n-height: auto !important; color: rg |
| ant; float: none !important; height: | b(0, 102, 153) !important; backgroun |
|  auto !important; left: auto !import | d: none !important;"}                |
| ant; outline: 0px !important; overfl | `SerializationTest`{style="margin: 0 |
| ow: visible !important; position: st | px !important; padding: 0px !importa |
| atic !important; right: auto !import | nt; white-space: nowrap; border: 0px |
| ant; text-align: right !important; t |  !important; border-radius: 0px !imp |
| op: auto !important; vertical-align: | ortant; bottom: auto !important; flo |
|  baseline !important; width: auto !i | at: none !important; height: auto !i |
| mportant; box-sizing: content-box !i | mportant; left: auto !important; out |
| mportant; font-family: Consolas, 'Bi | line: 0px !important; overflow: visi |
| tstream Vera Sans Mono', 'Courier Ne | ble !important; position: static !im |
| w', Courier, monospace !important; f | portant; right: auto !important; tex |
| ont-weight: normal !important; font- | t-align: left !important; top: auto  |
| style: normal !important; font-size: | !important; vertical-align: baseline |
|  1em !important; min-height: auto !i |  !important; width: auto !important; |
| mportant; white-space: pre !importan |  box-sizing: content-box !important; |
| t; background: none rgb(248, 248, 24 |  font-family: Consolas, 'Bitstream V |
| 8) !important;">                     | era Sans Mono', 'Courier New', Couri |
|                                      | er, monospace !important; font-weigh |
| 13                                   | t: normal !important; font-style: no |
|                                      | rmal !important; font-size: 1em !imp |
| </div>                               | ortant; min-height: auto !important; |
|                                      |  color: rgb(0, 0, 0) !important; bac |
| <div                                 | kground: none !important;"}          |
| style="margin: 0px !important; paddi |                                      |
| ng: 0px 0.5em 0px 1em !important; bo | </div>                               |
| rder-radius: 0px !important; border- |                                      |
| width: 0px 3px 0px 0px !important; b | <div                                 |
| order-right-style: solid !important; | style="margin: 0px !important; paddi |
|  border-right-color: rgb(108, 226, 1 | ng: 0px 1em !important; border-radiu |
| 08) !important; bottom: auto !import | s: 0px !important; border: 0px !impo |
| ant; float: none !important; height: | rtant; bottom: auto !important; floa |
|  auto !important; left: auto !import | t: none !important; height: auto !im |
| ant; outline: 0px !important; overfl | portant; left: auto !important; outl |
| ow: visible !important; position: st | ine: 0px !important; overflow: visib |
| atic !important; right: auto !import | le !important; position: static !imp |
| ant; text-align: right !important; t | ortant; right: auto !important; text |
| op: auto !important; vertical-align: | -align: left !important; top: auto ! |
|  baseline !important; width: auto !i | important; vertical-align: baseline  |
| mportant; box-sizing: content-box !i | !important; width: auto !important;  |
| mportant; font-family: Consolas, 'Bi | box-sizing: content-box !important;  |
| tstream Vera Sans Mono', 'Courier Ne | font-family: Consolas, 'Bitstream Ve |
| w', Courier, monospace !important; f | ra Sans Mono', 'Courier New', Courie |
| ont-weight: normal !important; font- | r, monospace !important; font-weight |
| style: normal !important; font-size: | : normal !important; font-style: nor |
|  1em !important; min-height: auto !i | mal !important; font-size: 1em !impo |
| mportant; white-space: pre !importan | rtant; min-height: auto !important;  |
| t; background: none rgb(255, 255, 25 | white-space: pre !important; backgro |
| 5) !important;">                     | und: none rgb(248, 248, 248) !import |
|                                      | ant;">                               |
| 14                                   |                                      |
|                                      | `{`{style="margin: 0px !important; p |
| </div>                               | adding: 0px !important; white-space: |
|                                      |  nowrap; border: 0px !important; bor |
| <div                                 | der-radius: 0px !important; bottom:  |
| style="margin: 0px !important; paddi | auto !important; float: none !import |
| ng: 0px 0.5em 0px 1em !important; bo | ant; height: auto !important; left:  |
| rder-radius: 0px !important; border- | auto !important; outline: 0px !impor |
| width: 0px 3px 0px 0px !important; b | tant; overflow: visible !important;  |
| order-right-style: solid !important; | position: static !important; right:  |
|  border-right-color: rgb(108, 226, 1 | auto !important; text-align: left !i |
| 08) !important; bottom: auto !import | mportant; top: auto !important; vert |
| ant; float: none !important; height: | ical-align: baseline !important; wid |
|  auto !important; left: auto !import | th: auto !important; box-sizing: con |
| ant; outline: 0px !important; overfl | tent-box !important; font-family: Co |
| ow: visible !important; position: st | nsolas, 'Bitstream Vera Sans Mono',  |
| atic !important; right: auto !import | 'Courier New', Courier, monospace !i |
| ant; text-align: right !important; t | mportant; font-weight: normal !impor |
| op: auto !important; vertical-align: | tant; font-style: normal !important; |
|  baseline !important; width: auto !i |  font-size: 1em !important; min-heig |
| mportant; box-sizing: content-box !i | ht: auto !important; color: rgb(0, 0 |
| mportant; font-family: Consolas, 'Bi | , 0) !important; background: none !i |
| tstream Vera Sans Mono', 'Courier Ne | mportant;"}                          |
| w', Courier, monospace !important; f |                                      |
| ont-weight: normal !important; font- | </div>                               |
| style: normal !important; font-size: |                                      |
|  1em !important; min-height: auto !i | <div                                 |
| mportant; white-space: pre !importan | style="margin: 0px !important; paddi |
| t; background: none rgb(248, 248, 24 | ng: 0px 1em !important; border-radiu |
| 8) !important;">                     | s: 0px !important; border: 0px !impo |
|                                      | rtant; bottom: auto !important; floa |
| 15                                   | t: none !important; height: auto !im |
|                                      | portant; left: auto !important; outl |
| </div>                               | ine: 0px !important; overflow: visib |
|                                      | le !important; position: static !imp |
| <div                                 | ortant; right: auto !important; text |
| style="margin: 0px !important; paddi | -align: left !important; top: auto ! |
| ng: 0px 0.5em 0px 1em !important; bo | important; vertical-align: baseline  |
| rder-radius: 0px !important; border- | !important; width: auto !important;  |
| width: 0px 3px 0px 0px !important; b | box-sizing: content-box !important;  |
| order-right-style: solid !important; | font-family: Consolas, 'Bitstream Ve |
|  border-right-color: rgb(108, 226, 1 | ra Sans Mono', 'Courier New', Courie |
| 08) !important; bottom: auto !import | r, monospace !important; font-weight |
| ant; float: none !important; height: | : normal !important; font-style: nor |
|  auto !important; left: auto !import | mal !important; font-size: 1em !impo |
| ant; outline: 0px !important; overfl | rtant; min-height: auto !important;  |
| ow: visible !important; position: st | white-space: pre !important; backgro |
| atic !important; right: auto !import | und: none rgb(255, 255, 255) !import |
| ant; text-align: right !important; t | ant;">                               |
| op: auto !important; vertical-align: |                                      |
|  baseline !important; width: auto !i | `    `{style="margin: 0px !important |
| mportant; box-sizing: content-box !i | ; padding: 0px !important; white-spa |
| mportant; font-family: Consolas, 'Bi | ce: nowrap; border: 0px !important;  |
| tstream Vera Sans Mono', 'Courier Ne | border-radius: 0px !important; botto |
| w', Courier, monospace !important; f | m: auto !important; float: none !imp |
| ont-weight: normal !important; font- | ortant; height: auto !important; lef |
| style: normal !important; font-size: | t: auto !important; outline: 0px !im |
|  1em !important; min-height: auto !i | portant; overflow: visible !importan |
| mportant; white-space: pre !importan | t; position: static !important; righ |
| t; background: none rgb(255, 255, 25 | t: auto !important; text-align: left |
| 5) !important;">                     |  !important; top: auto !important; v |
|                                      | ertical-align: baseline !important;  |
| 16                                   | width: auto !important; box-sizing:  |
|                                      | content-box !important; font-family: |
| </div>                               |  Consolas, 'Bitstream Vera Sans Mono |
|                                      | ', 'Courier New', Courier, monospace |
| <div                                 |  !important; font-weight: normal !im |
| style="margin: 0px !important; paddi | portant; font-style: normal !importa |
| ng: 0px 0.5em 0px 1em !important; bo | nt; font-size: 1em !important; min-h |
| rder-radius: 0px !important; border- | eight: auto !important; background:  |
| width: 0px 3px 0px 0px !important; b | none !important;"}`class`{style="mar |
| order-right-style: solid !important; | gin: 0px !important; padding: 0px !i |
|  border-right-color: rgb(108, 226, 1 | mportant; white-space: nowrap; borde |
| 08) !important; bottom: auto !import | r: 0px !important; border-radius: 0p |
| ant; float: none !important; height: | x !important; bottom: auto !importan |
|  auto !important; left: auto !import | t; float: none !important; height: a |
| ant; outline: 0px !important; overfl | uto !important; left: auto !importan |
| ow: visible !important; position: st | t; outline: 0px !important; overflow |
| atic !important; right: auto !import | : visible !important; position: stat |
| ant; text-align: right !important; t | ic !important; right: auto !importan |
| op: auto !important; vertical-align: | t; text-align: left !important; top: |
|  baseline !important; width: auto !i |  auto !important; vertical-align: ba |
| mportant; box-sizing: content-box !i | seline !important; width: auto !impo |
| mportant; font-family: Consolas, 'Bi | rtant; box-sizing: content-box !impo |
| tstream Vera Sans Mono', 'Courier Ne | rtant; font-family: Consolas, 'Bitst |
| w', Courier, monospace !important; f | ream Vera Sans Mono', 'Courier New', |
| ont-weight: normal !important; font- |  Courier, monospace !important; font |
| style: normal !important; font-size: | -weight: bold !important; font-style |
|  1em !important; min-height: auto !i | : normal !important; font-size: 1em  |
| mportant; white-space: pre !importan | !important; min-height: auto !import |
| t; background: none rgb(248, 248, 24 | ant; color: rgb(0, 102, 153) !import |
| 8) !important;">                     | ant; background: none !important;"}  |
|                                      | `Program`{style="margin: 0px !import |
| 17                                   | ant; padding: 0px !important; white- |
|                                      | space: nowrap; border: 0px !importan |
| </div>                               | t; border-radius: 0px !important; bo |
|                                      | ttom: auto !important; float: none ! |
| <div                                 | important; height: auto !important;  |
| style="margin: 0px !important; paddi | left: auto !important; outline: 0px  |
| ng: 0px 0.5em 0px 1em !important; bo | !important; overflow: visible !impor |
| rder-radius: 0px !important; border- | tant; position: static !important; r |
| width: 0px 3px 0px 0px !important; b | ight: auto !important; text-align: l |
| order-right-style: solid !important; | eft !important; top: auto !important |
|  border-right-color: rgb(108, 226, 1 | ; vertical-align: baseline !importan |
| 08) !important; bottom: auto !import | t; width: auto !important; box-sizin |
| ant; float: none !important; height: | g: content-box !important; font-fami |
|  auto !important; left: auto !import | ly: Consolas, 'Bitstream Vera Sans M |
| ant; outline: 0px !important; overfl | ono', 'Courier New', Courier, monosp |
| ow: visible !important; position: st | ace !important; font-weight: normal  |
| atic !important; right: auto !import | !important; font-style: normal !impo |
| ant; text-align: right !important; t | rtant; font-size: 1em !important; mi |
| op: auto !important; vertical-align: | n-height: auto !important; color: rg |
|  baseline !important; width: auto !i | b(0, 0, 0) !important; background: n |
| mportant; box-sizing: content-box !i | one !important;"}                    |
| mportant; font-family: Consolas, 'Bi |                                      |
| tstream Vera Sans Mono', 'Courier Ne | </div>                               |
| w', Courier, monospace !important; f |                                      |
| ont-weight: normal !important; font- | <div                                 |
| style: normal !important; font-size: | style="margin: 0px !important; paddi |
|  1em !important; min-height: auto !i | ng: 0px 1em !important; border-radiu |
| mportant; white-space: pre !importan | s: 0px !important; border: 0px !impo |
| t; background: none rgb(255, 255, 25 | rtant; bottom: auto !important; floa |
| 5) !important;">                     | t: none !important; height: auto !im |
|                                      | portant; left: auto !important; outl |
| 18                                   | ine: 0px !important; overflow: visib |
|                                      | le !important; position: static !imp |
| </div>                               | ortant; right: auto !important; text |
|                                      | -align: left !important; top: auto ! |
| <div                                 | important; vertical-align: baseline  |
| style="margin: 0px !important; paddi | !important; width: auto !important;  |
| ng: 0px 0.5em 0px 1em !important; bo | box-sizing: content-box !important;  |
| rder-radius: 0px !important; border- | font-family: Consolas, 'Bitstream Ve |
| width: 0px 3px 0px 0px !important; b | ra Sans Mono', 'Courier New', Courie |
| order-right-style: solid !important; | r, monospace !important; font-weight |
|  border-right-color: rgb(108, 226, 1 | : normal !important; font-style: nor |
| 08) !important; bottom: auto !import | mal !important; font-size: 1em !impo |
| ant; float: none !important; height: | rtant; min-height: auto !important;  |
|  auto !important; left: auto !import | white-space: pre !important; backgro |
| ant; outline: 0px !important; overfl | und: none rgb(248, 248, 248) !import |
| ow: visible !important; position: st | ant;">                               |
| atic !important; right: auto !import |                                      |
| ant; text-align: right !important; t | `    `{style="margin: 0px !important |
| op: auto !important; vertical-align: | ; padding: 0px !important; white-spa |
|  baseline !important; width: auto !i | ce: nowrap; border: 0px !important;  |
| mportant; box-sizing: content-box !i | border-radius: 0px !important; botto |
| mportant; font-family: Consolas, 'Bi | m: auto !important; float: none !imp |
| tstream Vera Sans Mono', 'Courier Ne | ortant; height: auto !important; lef |
| w', Courier, monospace !important; f | t: auto !important; outline: 0px !im |
| ont-weight: normal !important; font- | portant; overflow: visible !importan |
| style: normal !important; font-size: | t; position: static !important; righ |
|  1em !important; min-height: auto !i | t: auto !important; text-align: left |
| mportant; white-space: pre !importan |  !important; top: auto !important; v |
| t; background: none rgb(248, 248, 24 | ertical-align: baseline !important;  |
| 8) !important;">                     | width: auto !important; box-sizing:  |
|                                      | content-box !important; font-family: |
| 19                                   |  Consolas, 'Bitstream Vera Sans Mono |
|                                      | ', 'Courier New', Courier, monospace |
| </div>                               |  !important; font-weight: normal !im |
|                                      | portant; font-style: normal !importa |
| <div                                 | nt; font-size: 1em !important; min-h |
| style="margin: 0px !important; paddi | eight: auto !important; background:  |
| ng: 0px 0.5em 0px 1em !important; bo | none !important;"}`{`{style="margin: |
| rder-radius: 0px !important; border- |  0px !important; padding: 0px !impor |
| width: 0px 3px 0px 0px !important; b | tant; white-space: nowrap; border: 0 |
| order-right-style: solid !important; | px !important; border-radius: 0px !i |
|  border-right-color: rgb(108, 226, 1 | mportant; bottom: auto !important; f |
| 08) !important; bottom: auto !import | loat: none !important; height: auto  |
| ant; float: none !important; height: | !important; left: auto !important; o |
|  auto !important; left: auto !import | utline: 0px !important; overflow: vi |
| ant; outline: 0px !important; overfl | sible !important; position: static ! |
| ow: visible !important; position: st | important; right: auto !important; t |
| atic !important; right: auto !import | ext-align: left !important; top: aut |
| ant; text-align: right !important; t | o !important; vertical-align: baseli |
| op: auto !important; vertical-align: | ne !important; width: auto !importan |
|  baseline !important; width: auto !i | t; box-sizing: content-box !importan |
| mportant; box-sizing: content-box !i | t; font-family: Consolas, 'Bitstream |
| mportant; font-family: Consolas, 'Bi |  Vera Sans Mono', 'Courier New', Cou |
| tstream Vera Sans Mono', 'Courier Ne | rier, monospace !important; font-wei |
| w', Courier, monospace !important; f | ght: normal !important; font-style:  |
| ont-weight: normal !important; font- | normal !important; font-size: 1em !i |
| style: normal !important; font-size: | mportant; min-height: auto !importan |
|  1em !important; min-height: auto !i | t; color: rgb(0, 0, 0) !important; b |
| mportant; white-space: pre !importan | ackground: none !important;"}        |
| t; background: none rgb(255, 255, 25 |                                      |
| 5) !important;">                     | </div>                               |
|                                      |                                      |
| 20                                   | <div                                 |
|                                      | style="margin: 0px !important; paddi |
| </div>                               | ng: 0px 1em !important; border-radiu |
|                                      | s: 0px !important; border: 0px !impo |
| <div                                 | rtant; bottom: auto !important; floa |
| style="margin: 0px !important; paddi | t: none !important; height: auto !im |
| ng: 0px 0.5em 0px 1em !important; bo | portant; left: auto !important; outl |
| rder-radius: 0px !important; border- | ine: 0px !important; overflow: visib |
| width: 0px 3px 0px 0px !important; b | le !important; position: static !imp |
| order-right-style: solid !important; | ortant; right: auto !important; text |
|  border-right-color: rgb(108, 226, 1 | -align: left !important; top: auto ! |
| 08) !important; bottom: auto !import | important; vertical-align: baseline  |
| ant; float: none !important; height: | !important; width: auto !important;  |
|  auto !important; left: auto !import | box-sizing: content-box !important;  |
| ant; outline: 0px !important; overfl | font-family: Consolas, 'Bitstream Ve |
| ow: visible !important; position: st | ra Sans Mono', 'Courier New', Courie |
| atic !important; right: auto !import | r, monospace !important; font-weight |
| ant; text-align: right !important; t | : normal !important; font-style: nor |
| op: auto !important; vertical-align: | mal !important; font-size: 1em !impo |
|  baseline !important; width: auto !i | rtant; min-height: auto !important;  |
| mportant; box-sizing: content-box !i | white-space: pre !important; backgro |
| mportant; font-family: Consolas, 'Bi | und: none rgb(255, 255, 255) !import |
| tstream Vera Sans Mono', 'Courier Ne | ant;">                               |
| w', Courier, monospace !important; f |                                      |
| ont-weight: normal !important; font- | `        `{style="margin: 0px !impor |
| style: normal !important; font-size: | tant; padding: 0px !important; white |
|  1em !important; min-height: auto !i | -space: nowrap; border: 0px !importa |
| mportant; white-space: pre !importan | nt; border-radius: 0px !important; b |
| t; background: none rgb(248, 248, 24 | ottom: auto !important; float: none  |
| 8) !important;">                     | !important; height: auto !important; |
|                                      |  left: auto !important; outline: 0px |
| 21                                   |  !important; overflow: visible !impo |
|                                      | rtant; position: static !important;  |
| </div>                               | right: auto !important; text-align:  |
|                                      | left !important; top: auto !importan |
| <div                                 | t; vertical-align: baseline !importa |
| style="margin: 0px !important; paddi | nt; width: auto !important; box-sizi |
| ng: 0px 0.5em 0px 1em !important; bo | ng: content-box !important; font-fam |
| rder-radius: 0px !important; border- | ily: Consolas, 'Bitstream Vera Sans  |
| width: 0px 3px 0px 0px !important; b | Mono', 'Courier New', Courier, monos |
| order-right-style: solid !important; | pace !important; font-weight: normal |
|  border-right-color: rgb(108, 226, 1 |  !important; font-style: normal !imp |
| 08) !important; bottom: auto !import | ortant; font-size: 1em !important; m |
| ant; float: none !important; height: | in-height: auto !important; backgrou |
|  auto !important; left: auto !import | nd: none !important;"}`static`{style |
| ant; outline: 0px !important; overfl | ="margin: 0px !important; padding: 0 |
| ow: visible !important; position: st | px !important; white-space: nowrap;  |
| atic !important; right: auto !import | border: 0px !important; border-radiu |
| ant; text-align: right !important; t | s: 0px !important; bottom: auto !imp |
| op: auto !important; vertical-align: | ortant; float: none !important; heig |
|  baseline !important; width: auto !i | ht: auto !important; left: auto !imp |
| mportant; box-sizing: content-box !i | ortant; outline: 0px !important; ove |
| mportant; font-family: Consolas, 'Bi | rflow: visible !important; position: |
| tstream Vera Sans Mono', 'Courier Ne |  static !important; right: auto !imp |
| w', Courier, monospace !important; f | ortant; text-align: left !important; |
| ont-weight: normal !important; font- |  top: auto !important; vertical-alig |
| style: normal !important; font-size: | n: baseline !important; width: auto  |
|  1em !important; min-height: auto !i | !important; box-sizing: content-box  |
| mportant; white-space: pre !importan | !important; font-family: Consolas, ' |
| t; background: none rgb(255, 255, 25 | Bitstream Vera Sans Mono', 'Courier  |
| 5) !important;">                     | New', Courier, monospace !important; |
|                                      |  font-weight: bold !important; font- |
| 22                                   | style: normal !important; font-size: |
|                                      |  1em !important; min-height: auto !i |
| </div>                               | mportant; color: rgb(0, 102, 153) !i |
|                                      | mportant; background: none !importan |
| <div                                 | t;"}                                 |
| style="margin: 0px !important; paddi | `void`{style="margin: 0px !important |
| ng: 0px 0.5em 0px 1em !important; bo | ; padding: 0px !important; white-spa |
| rder-radius: 0px !important; border- | ce: nowrap; border: 0px !important;  |
| width: 0px 3px 0px 0px !important; b | border-radius: 0px !important; botto |
| order-right-style: solid !important; | m: auto !important; float: none !imp |
|  border-right-color: rgb(108, 226, 1 | ortant; height: auto !important; lef |
| 08) !important; bottom: auto !import | t: auto !important; outline: 0px !im |
| ant; float: none !important; height: | portant; overflow: visible !importan |
|  auto !important; left: auto !import | t; position: static !important; righ |
| ant; outline: 0px !important; overfl | t: auto !important; text-align: left |
| ow: visible !important; position: st |  !important; top: auto !important; v |
| atic !important; right: auto !import | ertical-align: baseline !important;  |
| ant; text-align: right !important; t | width: auto !important; box-sizing:  |
| op: auto !important; vertical-align: | content-box !important; font-family: |
|  baseline !important; width: auto !i |  Consolas, 'Bitstream Vera Sans Mono |
| mportant; box-sizing: content-box !i | ', 'Courier New', Courier, monospace |
| mportant; font-family: Consolas, 'Bi |  !important; font-weight: bold !impo |
| tstream Vera Sans Mono', 'Courier Ne | rtant; font-style: normal !important |
| w', Courier, monospace !important; f | ; font-size: 1em !important; min-hei |
| ont-weight: normal !important; font- | ght: auto !important; color: rgb(0,  |
| style: normal !important; font-size: | 102, 153) !important; background: no |
|  1em !important; min-height: auto !i | ne !important;"}                     |
| mportant; white-space: pre !importan | `Main(`{style="margin: 0px !importan |
| t; background: none rgb(248, 248, 24 | t; padding: 0px !important; white-sp |
| 8) !important;">                     | ace: nowrap; border: 0px !important; |
|                                      |  border-radius: 0px !important; bott |
| 23                                   | om: auto !important; float: none !im |
|                                      | portant; height: auto !important; le |
| </div>                               | ft: auto !important; outline: 0px !i |
|                                      | mportant; overflow: visible !importa |
| <div                                 | nt; position: static !important; rig |
| style="margin: 0px !important; paddi | ht: auto !important; text-align: lef |
| ng: 0px 0.5em 0px 1em !important; bo | t !important; top: auto !important;  |
| rder-radius: 0px !important; border- | vertical-align: baseline !important; |
| width: 0px 3px 0px 0px !important; b |  width: auto !important; box-sizing: |
| order-right-style: solid !important; |  content-box !important; font-family |
|  border-right-color: rgb(108, 226, 1 | : Consolas, 'Bitstream Vera Sans Mon |
| 08) !important; bottom: auto !import | o', 'Courier New', Courier, monospac |
| ant; float: none !important; height: | e !important; font-weight: normal !i |
|  auto !important; left: auto !import | mportant; font-style: normal !import |
| ant; outline: 0px !important; overfl | ant; font-size: 1em !important; min- |
| ow: visible !important; position: st | height: auto !important; color: rgb( |
| atic !important; right: auto !import | 0, 0, 0) !important; background: non |
| ant; text-align: right !important; t | e !important;"}`string`{style="margi |
| op: auto !important; vertical-align: | n: 0px !important; padding: 0px !imp |
|  baseline !important; width: auto !i | ortant; white-space: nowrap; border: |
| mportant; box-sizing: content-box !i |  0px !important; border-radius: 0px  |
| mportant; font-family: Consolas, 'Bi | !important; bottom: auto !important; |
| tstream Vera Sans Mono', 'Courier Ne |  float: none !important; height: aut |
| w', Courier, monospace !important; f | o !important; left: auto !important; |
| ont-weight: normal !important; font- |  outline: 0px !important; overflow:  |
| style: normal !important; font-size: | visible !important; position: static |
|  1em !important; min-height: auto !i |  !important; right: auto !important; |
| mportant; white-space: pre !importan |  text-align: left !important; top: a |
| t; background: none rgb(255, 255, 25 | uto !important; vertical-align: base |
| 5) !important;">                     | line !important; width: auto !import |
|                                      | ant; box-sizing: content-box !import |
| 24                                   | ant; font-family: Consolas, 'Bitstre |
|                                      | am Vera Sans Mono', 'Courier New', C |
| </div>                               | ourier, monospace !important; font-w |
|                                      | eight: bold !important; font-style:  |
| <div                                 | normal !important; font-size: 1em !i |
| style="margin: 0px !important; paddi | mportant; min-height: auto !importan |
| ng: 0px 0.5em 0px 1em !important; bo | t; color: rgb(0, 102, 153) !importan |
| rder-radius: 0px !important; border- | t; background: none !important;"}`[] |
| width: 0px 3px 0px 0px !important; b |  args)`{style="margin: 0px !importan |
| order-right-style: solid !important; | t; padding: 0px !important; white-sp |
|  border-right-color: rgb(108, 226, 1 | ace: nowrap; border: 0px !important; |
| 08) !important; bottom: auto !import |  border-radius: 0px !important; bott |
| ant; float: none !important; height: | om: auto !important; float: none !im |
|  auto !important; left: auto !import | portant; height: auto !important; le |
| ant; outline: 0px !important; overfl | ft: auto !important; outline: 0px !i |
| ow: visible !important; position: st | mportant; overflow: visible !importa |
| atic !important; right: auto !import | nt; position: static !important; rig |
| ant; text-align: right !important; t | ht: auto !important; text-align: lef |
| op: auto !important; vertical-align: | t !important; top: auto !important;  |
|  baseline !important; width: auto !i | vertical-align: baseline !important; |
| mportant; box-sizing: content-box !i |  width: auto !important; box-sizing: |
| mportant; font-family: Consolas, 'Bi |  content-box !important; font-family |
| tstream Vera Sans Mono', 'Courier Ne | : Consolas, 'Bitstream Vera Sans Mon |
| w', Courier, monospace !important; f | o', 'Courier New', Courier, monospac |
| ont-weight: normal !important; font- | e !important; font-weight: normal !i |
| style: normal !important; font-size: | mportant; font-style: normal !import |
|  1em !important; min-height: auto !i | ant; font-size: 1em !important; min- |
| mportant; white-space: pre !importan | height: auto !important; color: rgb( |
| t; background: none rgb(248, 248, 24 | 0, 0, 0) !important; background: non |
| 8) !important;">                     | e !important;"}                      |
|                                      |                                      |
| 25                                   | </div>                               |
|                                      |                                      |
| </div>                               | <div                                 |
|                                      | style="margin: 0px !important; paddi |
| <div                                 | ng: 0px 1em !important; border-radiu |
| style="margin: 0px !important; paddi | s: 0px !important; border: 0px !impo |
| ng: 0px 0.5em 0px 1em !important; bo | rtant; bottom: auto !important; floa |
| rder-radius: 0px !important; border- | t: none !important; height: auto !im |
| width: 0px 3px 0px 0px !important; b | portant; left: auto !important; outl |
| order-right-style: solid !important; | ine: 0px !important; overflow: visib |
|  border-right-color: rgb(108, 226, 1 | le !important; position: static !imp |
| 08) !important; bottom: auto !import | ortant; right: auto !important; text |
| ant; float: none !important; height: | -align: left !important; top: auto ! |
|  auto !important; left: auto !import | important; vertical-align: baseline  |
| ant; outline: 0px !important; overfl | !important; width: auto !important;  |
| ow: visible !important; position: st | box-sizing: content-box !important;  |
| atic !important; right: auto !import | font-family: Consolas, 'Bitstream Ve |
| ant; text-align: right !important; t | ra Sans Mono', 'Courier New', Courie |
| op: auto !important; vertical-align: | r, monospace !important; font-weight |
|  baseline !important; width: auto !i | : normal !important; font-style: nor |
| mportant; box-sizing: content-box !i | mal !important; font-size: 1em !impo |
| mportant; font-family: Consolas, 'Bi | rtant; min-height: auto !important;  |
| tstream Vera Sans Mono', 'Courier Ne | white-space: pre !important; backgro |
| w', Courier, monospace !important; f | und: none rgb(248, 248, 248) !import |
| ont-weight: normal !important; font- | ant;">                               |
| style: normal !important; font-size: |                                      |
|  1em !important; min-height: auto !i | `        `{style="margin: 0px !impor |
| mportant; white-space: pre !importan | tant; padding: 0px !important; white |
| t; background: none rgb(255, 255, 25 | -space: nowrap; border: 0px !importa |
| 5) !important;">                     | nt; border-radius: 0px !important; b |
|                                      | ottom: auto !important; float: none  |
| 26                                   | !important; height: auto !important; |
|                                      |  left: auto !important; outline: 0px |
| </div>                               |  !important; overflow: visible !impo |
|                                      | rtant; position: static !important;  |
| <div                                 | right: auto !important; text-align:  |
| style="margin: 0px !important; paddi | left !important; top: auto !importan |
| ng: 0px 0.5em 0px 1em !important; bo | t; vertical-align: baseline !importa |
| rder-radius: 0px !important; border- | nt; width: auto !important; box-sizi |
| width: 0px 3px 0px 0px !important; b | ng: content-box !important; font-fam |
| order-right-style: solid !important; | ily: Consolas, 'Bitstream Vera Sans  |
|  border-right-color: rgb(108, 226, 1 | Mono', 'Courier New', Courier, monos |
| 08) !important; bottom: auto !import | pace !important; font-weight: normal |
| ant; float: none !important; height: |  !important; font-style: normal !imp |
|  auto !important; left: auto !import | ortant; font-size: 1em !important; m |
| ant; outline: 0px !important; overfl | in-height: auto !important; backgrou |
| ow: visible !important; position: st | nd: none !important;"}`{`{style="mar |
| atic !important; right: auto !import | gin: 0px !important; padding: 0px !i |
| ant; text-align: right !important; t | mportant; white-space: nowrap; borde |
| op: auto !important; vertical-align: | r: 0px !important; border-radius: 0p |
|  baseline !important; width: auto !i | x !important; bottom: auto !importan |
| mportant; box-sizing: content-box !i | t; float: none !important; height: a |
| mportant; font-family: Consolas, 'Bi | uto !important; left: auto !importan |
| tstream Vera Sans Mono', 'Courier Ne | t; outline: 0px !important; overflow |
| w', Courier, monospace !important; f | : visible !important; position: stat |
| ont-weight: normal !important; font- | ic !important; right: auto !importan |
| style: normal !important; font-size: | t; text-align: left !important; top: |
|  1em !important; min-height: auto !i |  auto !important; vertical-align: ba |
| mportant; white-space: pre !importan | seline !important; width: auto !impo |
| t; background: none rgb(248, 248, 24 | rtant; box-sizing: content-box !impo |
| 8) !important;">                     | rtant; font-family: Consolas, 'Bitst |
|                                      | ream Vera Sans Mono', 'Courier New', |
| 27                                   |  Courier, monospace !important; font |
|                                      | -weight: normal !important; font-sty |
| </div>                               | le: normal !important; font-size: 1e |
|                                      | m !important; min-height: auto !impo |
| <div                                 | rtant; color: rgb(0, 0, 0) !importan |
| style="margin: 0px !important; paddi | t; background: none !important;"}    |
| ng: 0px 0.5em 0px 1em !important; bo |                                      |
| rder-radius: 0px !important; border- | </div>                               |
| width: 0px 3px 0px 0px !important; b |                                      |
| order-right-style: solid !important; | <div                                 |
|  border-right-color: rgb(108, 226, 1 | style="margin: 0px !important; paddi |
| 08) !important; bottom: auto !import | ng: 0px 1em !important; border-radiu |
| ant; float: none !important; height: | s: 0px !important; border: 0px !impo |
|  auto !important; left: auto !import | rtant; bottom: auto !important; floa |
| ant; outline: 0px !important; overfl | t: none !important; height: auto !im |
| ow: visible !important; position: st | portant; left: auto !important; outl |
| atic !important; right: auto !import | ine: 0px !important; overflow: visib |
| ant; text-align: right !important; t | le !important; position: static !imp |
| op: auto !important; vertical-align: | ortant; right: auto !important; text |
|  baseline !important; width: auto !i | -align: left !important; top: auto ! |
| mportant; box-sizing: content-box !i | important; vertical-align: baseline  |
| mportant; font-family: Consolas, 'Bi | !important; width: auto !important;  |
| tstream Vera Sans Mono', 'Courier Ne | box-sizing: content-box !important;  |
| w', Courier, monospace !important; f | font-family: Consolas, 'Bitstream Ve |
| ont-weight: normal !important; font- | ra Sans Mono', 'Courier New', Courie |
| style: normal !important; font-size: | r, monospace !important; font-weight |
|  1em !important; min-height: auto !i | : normal !important; font-style: nor |
| mportant; white-space: pre !importan | mal !important; font-size: 1em !impo |
| t; background: none rgb(255, 255, 25 | rtant; min-height: auto !important;  |
| 5) !important;">                     | white-space: pre !important; backgro |
|                                      | und: none rgb(255, 255, 255) !import |
| 28                                   | ant;">                               |
|                                      |                                      |
| </div>                               | `            `{style="margin: 0px !i |
|                                      | mportant; padding: 0px !important; w |
| <div                                 | hite-space: nowrap; border: 0px !imp |
| style="margin: 0px !important; paddi | ortant; border-radius: 0px !importan |
| ng: 0px 0.5em 0px 1em !important; bo | t; bottom: auto !important; float: n |
| rder-radius: 0px !important; border- | one !important; height: auto !import |
| width: 0px 3px 0px 0px !important; b | ant; left: auto !important; outline: |
| order-right-style: solid !important; |  0px !important; overflow: visible ! |
|  border-right-color: rgb(108, 226, 1 | important; position: static !importa |
| 08) !important; bottom: auto !import | nt; right: auto !important; text-ali |
| ant; float: none !important; height: | gn: left !important; top: auto !impo |
|  auto !important; left: auto !import | rtant; vertical-align: baseline !imp |
| ant; outline: 0px !important; overfl | ortant; width: auto !important; box- |
| ow: visible !important; position: st | sizing: content-box !important; font |
| atic !important; right: auto !import | -family: Consolas, 'Bitstream Vera S |
| ant; text-align: right !important; t | ans Mono', 'Courier New', Courier, m |
| op: auto !important; vertical-align: | onospace !important; font-weight: no |
|  baseline !important; width: auto !i | rmal !important; font-style: normal  |
| mportant; box-sizing: content-box !i | !important; font-size: 1em !importan |
| mportant; font-family: Consolas, 'Bi | t; min-height: auto !important; back |
| tstream Vera Sans Mono', 'Courier Ne | ground: none !important;"}`//Seriali |
| w', Courier, monospace !important; f | zation of String Object         `{st |
| ont-weight: normal !important; font- | yle="margin: 0px !important; padding |
| style: normal !important; font-size: | : 0px !important; white-space: nowra |
|  1em !important; min-height: auto !i | p; border: 0px !important; border-ra |
| mportant; white-space: pre !importan | dius: 0px !important; bottom: auto ! |
| t; background: none rgb(248, 248, 24 | important; float: none !important; h |
| 8) !important;">                     | eight: auto !important; left: auto ! |
|                                      | important; outline: 0px !important;  |
| 29                                   | overflow: visible !important; positi |
|                                      | on: static !important; right: auto ! |
| </div>                               | important; text-align: left !importa |
|                                      | nt; top: auto !important; vertical-a |
| <div                                 | lign: baseline !important; width: au |
| style="margin: 0px !important; paddi | to !important; box-sizing: content-b |
| ng: 0px 0.5em 0px 1em !important; bo | ox !important; font-family: Consolas |
| rder-radius: 0px !important; border- | , 'Bitstream Vera Sans Mono', 'Couri |
| width: 0px 3px 0px 0px !important; b | er New', Courier, monospace !importa |
| order-right-style: solid !important; | nt; font-weight: normal !important;  |
|  border-right-color: rgb(108, 226, 1 | font-style: normal !important; font- |
| 08) !important; bottom: auto !import | size: 1em !important; min-height: au |
| ant; float: none !important; height: | to !important; color: rgb(0, 130, 0) |
|  auto !important; left: auto !import |  !important; background: none !impor |
| ant; outline: 0px !important; overfl | tant;"}                              |
| ow: visible !important; position: st |                                      |
| atic !important; right: auto !import | </div>                               |
| ant; text-align: right !important; t |                                      |
| op: auto !important; vertical-align: | <div                                 |
|  baseline !important; width: auto !i | style="margin: 0px !important; paddi |
| mportant; box-sizing: content-box !i | ng: 0px 1em !important; border-radiu |
| mportant; font-family: Consolas, 'Bi | s: 0px !important; border: 0px !impo |
| tstream Vera Sans Mono', 'Courier Ne | rtant; bottom: auto !important; floa |
| w', Courier, monospace !important; f | t: none !important; height: auto !im |
| ont-weight: normal !important; font- | portant; left: auto !important; outl |
| style: normal !important; font-size: | ine: 0px !important; overflow: visib |
|  1em !important; min-height: auto !i | le !important; position: static !imp |
| mportant; white-space: pre !importan | ortant; right: auto !important; text |
| t; background: none rgb(255, 255, 25 | -align: left !important; top: auto ! |
| 5) !important;">                     | important; vertical-align: baseline  |
|                                      | !important; width: auto !important;  |
| 30                                   | box-sizing: content-box !important;  |
|                                      | font-family: Consolas, 'Bitstream Ve |
| </div>                               | ra Sans Mono', 'Courier New', Courie |
|                                      | r, monospace !important; font-weight |
|                                      | : normal !important; font-style: nor |
|                                      | mal !important; font-size: 1em !impo |
|                                      | rtant; min-height: auto !important;  |
|                                      | white-space: pre !important; backgro |
|                                      | und: none rgb(248, 248, 248) !import |
|                                      | ant;">                               |
|                                      |                                      |
|                                      | `            `{style="margin: 0px !i |
|                                      | mportant; padding: 0px !important; w |
|                                      | hite-space: nowrap; border: 0px !imp |
|                                      | ortant; border-radius: 0px !importan |
|                                      | t; bottom: auto !important; float: n |
|                                      | one !important; height: auto !import |
|                                      | ant; left: auto !important; outline: |
|                                      |  0px !important; overflow: visible ! |
|                                      | important; position: static !importa |
|                                      | nt; right: auto !important; text-ali |
|                                      | gn: left !important; top: auto !impo |
|                                      | rtant; vertical-align: baseline !imp |
|                                      | ortant; width: auto !important; box- |
|                                      | sizing: content-box !important; font |
|                                      | -family: Consolas, 'Bitstream Vera S |
|                                      | ans Mono', 'Courier New', Courier, m |
|                                      | onospace !important; font-weight: no |
|                                      | rmal !important; font-style: normal  |
|                                      | !important; font-size: 1em !importan |
|                                      | t; min-height: auto !important; back |
|                                      | ground: none !important;"}`string`{s |
|                                      | tyle="margin: 0px !important; paddin |
|                                      | g: 0px !important; white-space: nowr |
|                                      | ap; border: 0px !important; border-r |
|                                      | adius: 0px !important; bottom: auto  |
|                                      | !important; float: none !important;  |
|                                      | height: auto !important; left: auto  |
|                                      | !important; outline: 0px !important; |
|                                      |  overflow: visible !important; posit |
|                                      | ion: static !important; right: auto  |
|                                      | !important; text-align: left !import |
|                                      | ant; top: auto !important; vertical- |
|                                      | align: baseline !important; width: a |
|                                      | uto !important; box-sizing: content- |
|                                      | box !important; font-family: Consola |
|                                      | s, 'Bitstream Vera Sans Mono', 'Cour |
|                                      | ier New', Courier, monospace !import |
|                                      | ant; font-weight: bold !important; f |
|                                      | ont-style: normal !important; font-s |
|                                      | ize: 1em !important; min-height: aut |
|                                      | o !important; color: rgb(0, 102, 153 |
|                                      | ) !important; background: none !impo |
|                                      | rtant;"}                             |
|                                      | `strobj = `{style="margin: 0px !impo |
|                                      | rtant; padding: 0px !important; whit |
|                                      | e-space: nowrap; border: 0px !import |
|                                      | ant; border-radius: 0px !important;  |
|                                      | bottom: auto !important; float: none |
|                                      |  !important; height: auto !important |
|                                      | ; left: auto !important; outline: 0p |
|                                      | x !important; overflow: visible !imp |
|                                      | ortant; position: static !important; |
|                                      |  right: auto !important; text-align: |
|                                      |  left !important; top: auto !importa |
|                                      | nt; vertical-align: baseline !import |
|                                      | ant; width: auto !important; box-siz |
|                                      | ing: content-box !important; font-fa |
|                                      | mily: Consolas, 'Bitstream Vera Sans |
|                                      |  Mono', 'Courier New', Courier, mono |
|                                      | space !important; font-weight: norma |
|                                      | l !important; font-style: normal !im |
|                                      | portant; font-size: 1em !important;  |
|                                      | min-height: auto !important; color:  |
|                                      | rgb(0, 0, 0) !important; background: |
|                                      |  none !important;"}`"test string for |
|                                      |  serialization"`{style="margin: 0px  |
|                                      | !important; padding: 0px !important; |
|                                      |  white-space: nowrap; border: 0px !i |
|                                      | mportant; border-radius: 0px !import |
|                                      | ant; bottom: auto !important; float: |
|                                      |  none !important; height: auto !impo |
|                                      | rtant; left: auto !important; outlin |
|                                      | e: 0px !important; overflow: visible |
|                                      |  !important; position: static !impor |
|                                      | tant; right: auto !important; text-a |
|                                      | lign: left !important; top: auto !im |
|                                      | portant; vertical-align: baseline !i |
|                                      | mportant; width: auto !important; bo |
|                                      | x-sizing: content-box !important; fo |
|                                      | nt-family: Consolas, 'Bitstream Vera |
|                                      |  Sans Mono', 'Courier New', Courier, |
|                                      |  monospace !important; font-weight:  |
|                                      | normal !important; font-style: norma |
|                                      | l !important; font-size: 1em !import |
|                                      | ant; min-height: auto !important; co |
|                                      | lor: blue !important; background: no |
|                                      | ne !important;"}`;`{style="margin: 0 |
|                                      | px !important; padding: 0px !importa |
|                                      | nt; white-space: nowrap; border: 0px |
|                                      |  !important; border-radius: 0px !imp |
|                                      | ortant; bottom: auto !important; flo |
|                                      | at: none !important; height: auto !i |
|                                      | mportant; left: auto !important; out |
|                                      | line: 0px !important; overflow: visi |
|                                      | ble !important; position: static !im |
|                                      | portant; right: auto !important; tex |
|                                      | t-align: left !important; top: auto  |
|                                      | !important; vertical-align: baseline |
|                                      |  !important; width: auto !important; |
|                                      |  box-sizing: content-box !important; |
|                                      |  font-family: Consolas, 'Bitstream V |
|                                      | era Sans Mono', 'Courier New', Couri |
|                                      | er, monospace !important; font-weigh |
|                                      | t: normal !important; font-style: no |
|                                      | rmal !important; font-size: 1em !imp |
|                                      | ortant; min-height: auto !important; |
|                                      |  color: rgb(0, 0, 0) !important; bac |
|                                      | kground: none !important;"}          |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="margin: 0px !important; paddi |
|                                      | ng: 0px 1em !important; border-radiu |
|                                      | s: 0px !important; border: 0px !impo |
|                                      | rtant; bottom: auto !important; floa |
|                                      | t: none !important; height: auto !im |
|                                      | portant; left: auto !important; outl |
|                                      | ine: 0px !important; overflow: visib |
|                                      | le !important; position: static !imp |
|                                      | ortant; right: auto !important; text |
|                                      | -align: left !important; top: auto ! |
|                                      | important; vertical-align: baseline  |
|                                      | !important; width: auto !important;  |
|                                      | box-sizing: content-box !important;  |
|                                      | font-family: Consolas, 'Bitstream Ve |
|                                      | ra Sans Mono', 'Courier New', Courie |
|                                      | r, monospace !important; font-weight |
|                                      | : normal !important; font-style: nor |
|                                      | mal !important; font-size: 1em !impo |
|                                      | rtant; min-height: auto !important;  |
|                                      | white-space: pre !important; backgro |
|                                      | und: none rgb(255, 255, 255) !import |
|                                      | ant;">                               |
|                                      |                                      |
|                                      | `            `{style="margin: 0px !i |
|                                      | mportant; padding: 0px !important; w |
|                                      | hite-space: nowrap; border: 0px !imp |
|                                      | ortant; border-radius: 0px !importan |
|                                      | t; bottom: auto !important; float: n |
|                                      | one !important; height: auto !import |
|                                      | ant; left: auto !important; outline: |
|                                      |  0px !important; overflow: visible ! |
|                                      | important; position: static !importa |
|                                      | nt; right: auto !important; text-ali |
|                                      | gn: left !important; top: auto !impo |
|                                      | rtant; vertical-align: baseline !imp |
|                                      | ortant; width: auto !important; box- |
|                                      | sizing: content-box !important; font |
|                                      | -family: Consolas, 'Bitstream Vera S |
|                                      | ans Mono', 'Courier New', Courier, m |
|                                      | onospace !important; font-weight: no |
|                                      | rmal !important; font-style: normal  |
|                                      | !important; font-size: 1em !importan |
|                                      | t; min-height: auto !important; back |
|                                      | ground: none !important;"}`FileStrea |
|                                      | m stream = `{style="margin: 0px !imp |
|                                      | ortant; padding: 0px !important; whi |
|                                      | te-space: nowrap; border: 0px !impor |
|                                      | tant; border-radius: 0px !important; |
|                                      |  bottom: auto !important; float: non |
|                                      | e !important; height: auto !importan |
|                                      | t; left: auto !important; outline: 0 |
|                                      | px !important; overflow: visible !im |
|                                      | portant; position: static !important |
|                                      | ; right: auto !important; text-align |
|                                      | : left !important; top: auto !import |
|                                      | ant; vertical-align: baseline !impor |
|                                      | tant; width: auto !important; box-si |
|                                      | zing: content-box !important; font-f |
|                                      | amily: Consolas, 'Bitstream Vera San |
|                                      | s Mono', 'Courier New', Courier, mon |
|                                      | ospace !important; font-weight: norm |
|                                      | al !important; font-style: normal !i |
|                                      | mportant; font-size: 1em !important; |
|                                      |  min-height: auto !important; color: |
|                                      |  rgb(0, 0, 0) !important; background |
|                                      | : none !important;"}`new`{style="mar |
|                                      | gin: 0px !important; padding: 0px !i |
|                                      | mportant; white-space: nowrap; borde |
|                                      | r: 0px !important; border-radius: 0p |
|                                      | x !important; bottom: auto !importan |
|                                      | t; float: none !important; height: a |
|                                      | uto !important; left: auto !importan |
|                                      | t; outline: 0px !important; overflow |
|                                      | : visible !important; position: stat |
|                                      | ic !important; right: auto !importan |
|                                      | t; text-align: left !important; top: |
|                                      |  auto !important; vertical-align: ba |
|                                      | seline !important; width: auto !impo |
|                                      | rtant; box-sizing: content-box !impo |
|                                      | rtant; font-family: Consolas, 'Bitst |
|                                      | ream Vera Sans Mono', 'Courier New', |
|                                      |  Courier, monospace !important; font |
|                                      | -weight: bold !important; font-style |
|                                      | : normal !important; font-size: 1em  |
|                                      | !important; min-height: auto !import |
|                                      | ant; color: rgb(0, 102, 153) !import |
|                                      | ant; background: none !important;"}  |
|                                      | `FileStream(`{style="margin: 0px !im |
|                                      | portant; padding: 0px !important; wh |
|                                      | ite-space: nowrap; border: 0px !impo |
|                                      | rtant; border-radius: 0px !important |
|                                      | ; bottom: auto !important; float: no |
|                                      | ne !important; height: auto !importa |
|                                      | nt; left: auto !important; outline:  |
|                                      | 0px !important; overflow: visible !i |
|                                      | mportant; position: static !importan |
|                                      | t; right: auto !important; text-alig |
|                                      | n: left !important; top: auto !impor |
|                                      | tant; vertical-align: baseline !impo |
|                                      | rtant; width: auto !important; box-s |
|                                      | izing: content-box !important; font- |
|                                      | family: Consolas, 'Bitstream Vera Sa |
|                                      | ns Mono', 'Courier New', Courier, mo |
|                                      | nospace !important; font-weight: nor |
|                                      | mal !important; font-style: normal ! |
|                                      | important; font-size: 1em !important |
|                                      | ; min-height: auto !important; color |
|                                      | : rgb(0, 0, 0) !important; backgroun |
|                                      | d: none !important;"}`"C:\\StrObj.tx |
|                                      | t"`{style="margin: 0px !important; p |
|                                      | adding: 0px !important; white-space: |
|                                      |  nowrap; border: 0px !important; bor |
|                                      | der-radius: 0px !important; bottom:  |
|                                      | auto !important; float: none !import |
|                                      | ant; height: auto !important; left:  |
|                                      | auto !important; outline: 0px !impor |
|                                      | tant; overflow: visible !important;  |
|                                      | position: static !important; right:  |
|                                      | auto !important; text-align: left !i |
|                                      | mportant; top: auto !important; vert |
|                                      | ical-align: baseline !important; wid |
|                                      | th: auto !important; box-sizing: con |
|                                      | tent-box !important; font-family: Co |
|                                      | nsolas, 'Bitstream Vera Sans Mono',  |
|                                      | 'Courier New', Courier, monospace !i |
|                                      | mportant; font-weight: normal !impor |
|                                      | tant; font-style: normal !important; |
|                                      |  font-size: 1em !important; min-heig |
|                                      | ht: auto !important; color: blue !im |
|                                      | portant; background: none !important |
|                                      | ;"}`, FileMode.Create, FileAccess.Wr |
|                                      | ite ,`{style="margin: 0px !important |
|                                      | ; padding: 0px !important; white-spa |
|                                      | ce: nowrap; border: 0px !important;  |
|                                      | border-radius: 0px !important; botto |
|                                      | m: auto !important; float: none !imp |
|                                      | ortant; height: auto !important; lef |
|                                      | t: auto !important; outline: 0px !im |
|                                      | portant; overflow: visible !importan |
|                                      | t; position: static !important; righ |
|                                      | t: auto !important; text-align: left |
|                                      |  !important; top: auto !important; v |
|                                      | ertical-align: baseline !important;  |
|                                      | width: auto !important; box-sizing:  |
|                                      | content-box !important; font-family: |
|                                      |  Consolas, 'Bitstream Vera Sans Mono |
|                                      | ', 'Courier New', Courier, monospace |
|                                      |  !important; font-weight: normal !im |
|                                      | portant; font-style: normal !importa |
|                                      | nt; font-size: 1em !important; min-h |
|                                      | eight: auto !important; color: rgb(0 |
|                                      | , 0, 0) !important; background: none |
|                                      |  !important;"}                       |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="margin: 0px !important; paddi |
|                                      | ng: 0px 1em !important; border-radiu |
|                                      | s: 0px !important; border: 0px !impo |
|                                      | rtant; bottom: auto !important; floa |
|                                      | t: none !important; height: auto !im |
|                                      | portant; left: auto !important; outl |
|                                      | ine: 0px !important; overflow: visib |
|                                      | le !important; position: static !imp |
|                                      | ortant; right: auto !important; text |
|                                      | -align: left !important; top: auto ! |
|                                      | important; vertical-align: baseline  |
|                                      | !important; width: auto !important;  |
|                                      | box-sizing: content-box !important;  |
|                                      | font-family: Consolas, 'Bitstream Ve |
|                                      | ra Sans Mono', 'Courier New', Courie |
|                                      | r, monospace !important; font-weight |
|                                      | : normal !important; font-style: nor |
|                                      | mal !important; font-size: 1em !impo |
|                                      | rtant; min-height: auto !important;  |
|                                      | white-space: pre !important; backgro |
|                                      | und: none rgb(248, 248, 248) !import |
|                                      | ant;">                               |
|                                      |                                      |
|                                      | `            `{style="margin: 0px !i |
|                                      | mportant; padding: 0px !important; w |
|                                      | hite-space: nowrap; border: 0px !imp |
|                                      | ortant; border-radius: 0px !importan |
|                                      | t; bottom: auto !important; float: n |
|                                      | one !important; height: auto !import |
|                                      | ant; left: auto !important; outline: |
|                                      |  0px !important; overflow: visible ! |
|                                      | important; position: static !importa |
|                                      | nt; right: auto !important; text-ali |
|                                      | gn: left !important; top: auto !impo |
|                                      | rtant; vertical-align: baseline !imp |
|                                      | ortant; width: auto !important; box- |
|                                      | sizing: content-box !important; font |
|                                      | -family: Consolas, 'Bitstream Vera S |
|                                      | ans Mono', 'Courier New', Courier, m |
|                                      | onospace !important; font-weight: no |
|                                      | rmal !important; font-style: normal  |
|                                      | !important; font-size: 1em !importan |
|                                      | t; min-height: auto !important; back |
|                                      | ground: none !important;"}`FileShare |
|                                      | .None);`{style="margin: 0px !importa |
|                                      | nt; padding: 0px !important; white-s |
|                                      | pace: nowrap; border: 0px !important |
|                                      | ; border-radius: 0px !important; bot |
|                                      | tom: auto !important; float: none !i |
|                                      | mportant; height: auto !important; l |
|                                      | eft: auto !important; outline: 0px ! |
|                                      | important; overflow: visible !import |
|                                      | ant; position: static !important; ri |
|                                      | ght: auto !important; text-align: le |
|                                      | ft !important; top: auto !important; |
|                                      |  vertical-align: baseline !important |
|                                      | ; width: auto !important; box-sizing |
|                                      | : content-box !important; font-famil |
|                                      | y: Consolas, 'Bitstream Vera Sans Mo |
|                                      | no', 'Courier New', Courier, monospa |
|                                      | ce !important; font-weight: normal ! |
|                                      | important; font-style: normal !impor |
|                                      | tant; font-size: 1em !important; min |
|                                      | -height: auto !important; color: rgb |
|                                      | (0, 0, 0) !important; background: no |
|                                      | ne !important;"}                     |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="margin: 0px !important; paddi |
|                                      | ng: 0px 1em !important; border-radiu |
|                                      | s: 0px !important; border: 0px !impo |
|                                      | rtant; bottom: auto !important; floa |
|                                      | t: none !important; height: auto !im |
|                                      | portant; left: auto !important; outl |
|                                      | ine: 0px !important; overflow: visib |
|                                      | le !important; position: static !imp |
|                                      | ortant; right: auto !important; text |
|                                      | -align: left !important; top: auto ! |
|                                      | important; vertical-align: baseline  |
|                                      | !important; width: auto !important;  |
|                                      | box-sizing: content-box !important;  |
|                                      | font-family: Consolas, 'Bitstream Ve |
|                                      | ra Sans Mono', 'Courier New', Courie |
|                                      | r, monospace !important; font-weight |
|                                      | : normal !important; font-style: nor |
|                                      | mal !important; font-size: 1em !impo |
|                                      | rtant; min-height: auto !important;  |
|                                      | white-space: pre !important; backgro |
|                                      | und: none rgb(255, 255, 255) !import |
|                                      | ant;">                               |
|                                      |                                      |
|                                      | `            `{style="margin: 0px !i |
|                                      | mportant; padding: 0px !important; w |
|                                      | hite-space: nowrap; border: 0px !imp |
|                                      | ortant; border-radius: 0px !importan |
|                                      | t; bottom: auto !important; float: n |
|                                      | one !important; height: auto !import |
|                                      | ant; left: auto !important; outline: |
|                                      |  0px !important; overflow: visible ! |
|                                      | important; position: static !importa |
|                                      | nt; right: auto !important; text-ali |
|                                      | gn: left !important; top: auto !impo |
|                                      | rtant; vertical-align: baseline !imp |
|                                      | ortant; width: auto !important; box- |
|                                      | sizing: content-box !important; font |
|                                      | -family: Consolas, 'Bitstream Vera S |
|                                      | ans Mono', 'Courier New', Courier, m |
|                                      | onospace !important; font-weight: no |
|                                      | rmal !important; font-style: normal  |
|                                      | !important; font-size: 1em !importan |
|                                      | t; min-height: auto !important; back |
|                                      | ground: none !important;"}`BinaryFor |
|                                      | matter formatter = `{style="margin:  |
|                                      | 0px !important; padding: 0px !import |
|                                      | ant; white-space: nowrap; border: 0p |
|                                      | x !important; border-radius: 0px !im |
|                                      | portant; bottom: auto !important; fl |
|                                      | oat: none !important; height: auto ! |
|                                      | important; left: auto !important; ou |
|                                      | tline: 0px !important; overflow: vis |
|                                      | ible !important; position: static !i |
|                                      | mportant; right: auto !important; te |
|                                      | xt-align: left !important; top: auto |
|                                      |  !important; vertical-align: baselin |
|                                      | e !important; width: auto !important |
|                                      | ; box-sizing: content-box !important |
|                                      | ; font-family: Consolas, 'Bitstream  |
|                                      | Vera Sans Mono', 'Courier New', Cour |
|                                      | ier, monospace !important; font-weig |
|                                      | ht: normal !important; font-style: n |
|                                      | ormal !important; font-size: 1em !im |
|                                      | portant; min-height: auto !important |
|                                      | ; color: rgb(0, 0, 0) !important; ba |
|                                      | ckground: none !important;"}`new`{st |
|                                      | yle="margin: 0px !important; padding |
|                                      | : 0px !important; white-space: nowra |
|                                      | p; border: 0px !important; border-ra |
|                                      | dius: 0px !important; bottom: auto ! |
|                                      | important; float: none !important; h |
|                                      | eight: auto !important; left: auto ! |
|                                      | important; outline: 0px !important;  |
|                                      | overflow: visible !important; positi |
|                                      | on: static !important; right: auto ! |
|                                      | important; text-align: left !importa |
|                                      | nt; top: auto !important; vertical-a |
|                                      | lign: baseline !important; width: au |
|                                      | to !important; box-sizing: content-b |
|                                      | ox !important; font-family: Consolas |
|                                      | , 'Bitstream Vera Sans Mono', 'Couri |
|                                      | er New', Courier, monospace !importa |
|                                      | nt; font-weight: bold !important; fo |
|                                      | nt-style: normal !important; font-si |
|                                      | ze: 1em !important; min-height: auto |
|                                      |  !important; color: rgb(0, 102, 153) |
|                                      |  !important; background: none !impor |
|                                      | tant;"}                              |
|                                      | `BinaryFormatter();`{style="margin:  |
|                                      | 0px !important; padding: 0px !import |
|                                      | ant; white-space: nowrap; border: 0p |
|                                      | x !important; border-radius: 0px !im |
|                                      | portant; bottom: auto !important; fl |
|                                      | oat: none !important; height: auto ! |
|                                      | important; left: auto !important; ou |
|                                      | tline: 0px !important; overflow: vis |
|                                      | ible !important; position: static !i |
|                                      | mportant; right: auto !important; te |
|                                      | xt-align: left !important; top: auto |
|                                      |  !important; vertical-align: baselin |
|                                      | e !important; width: auto !important |
|                                      | ; box-sizing: content-box !important |
|                                      | ; font-family: Consolas, 'Bitstream  |
|                                      | Vera Sans Mono', 'Courier New', Cour |
|                                      | ier, monospace !important; font-weig |
|                                      | ht: normal !important; font-style: n |
|                                      | ormal !important; font-size: 1em !im |
|                                      | portant; min-height: auto !important |
|                                      | ; color: rgb(0, 0, 0) !important; ba |
|                                      | ckground: none !important;"}         |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="margin: 0px !important; paddi |
|                                      | ng: 0px 1em !important; border-radiu |
|                                      | s: 0px !important; border: 0px !impo |
|                                      | rtant; bottom: auto !important; floa |
|                                      | t: none !important; height: auto !im |
|                                      | portant; left: auto !important; outl |
|                                      | ine: 0px !important; overflow: visib |
|                                      | le !important; position: static !imp |
|                                      | ortant; right: auto !important; text |
|                                      | -align: left !important; top: auto ! |
|                                      | important; vertical-align: baseline  |
|                                      | !important; width: auto !important;  |
|                                      | box-sizing: content-box !important;  |
|                                      | font-family: Consolas, 'Bitstream Ve |
|                                      | ra Sans Mono', 'Courier New', Courie |
|                                      | r, monospace !important; font-weight |
|                                      | : normal !important; font-style: nor |
|                                      | mal !important; font-size: 1em !impo |
|                                      | rtant; min-height: auto !important;  |
|                                      | white-space: pre !important; backgro |
|                                      | und: none rgb(248, 248, 248) !import |
|                                      | ant;">                               |
|                                      |                                      |
|                                      | `            `{style="margin: 0px !i |
|                                      | mportant; padding: 0px !important; w |
|                                      | hite-space: nowrap; border: 0px !imp |
|                                      | ortant; border-radius: 0px !importan |
|                                      | t; bottom: auto !important; float: n |
|                                      | one !important; height: auto !import |
|                                      | ant; left: auto !important; outline: |
|                                      |  0px !important; overflow: visible ! |
|                                      | important; position: static !importa |
|                                      | nt; right: auto !important; text-ali |
|                                      | gn: left !important; top: auto !impo |
|                                      | rtant; vertical-align: baseline !imp |
|                                      | ortant; width: auto !important; box- |
|                                      | sizing: content-box !important; font |
|                                      | -family: Consolas, 'Bitstream Vera S |
|                                      | ans Mono', 'Courier New', Courier, m |
|                                      | onospace !important; font-weight: no |
|                                      | rmal !important; font-style: normal  |
|                                      | !important; font-size: 1em !importan |
|                                      | t; min-height: auto !important; back |
|                                      | ground: none !important;"}`formatter |
|                                      | .Serialize(stream, strobj);`{style=" |
|                                      | margin: 0px !important; padding: 0px |
|                                      |  !important; white-space: nowrap; bo |
|                                      | rder: 0px !important; border-radius: |
|                                      |  0px !important; bottom: auto !impor |
|                                      | tant; float: none !important; height |
|                                      | : auto !important; left: auto !impor |
|                                      | tant; outline: 0px !important; overf |
|                                      | low: visible !important; position: s |
|                                      | tatic !important; right: auto !impor |
|                                      | tant; text-align: left !important; t |
|                                      | op: auto !important; vertical-align: |
|                                      |  baseline !important; width: auto !i |
|                                      | mportant; box-sizing: content-box !i |
|                                      | mportant; font-family: Consolas, 'Bi |
|                                      | tstream Vera Sans Mono', 'Courier Ne |
|                                      | w', Courier, monospace !important; f |
|                                      | ont-weight: normal !important; font- |
|                                      | style: normal !important; font-size: |
|                                      |  1em !important; min-height: auto !i |
|                                      | mportant; color: rgb(0, 0, 0) !impor |
|                                      | tant; background: none !important;"} |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="margin: 0px !important; paddi |
|                                      | ng: 0px 1em !important; border-radiu |
|                                      | s: 0px !important; border: 0px !impo |
|                                      | rtant; bottom: auto !important; floa |
|                                      | t: none !important; height: auto !im |
|                                      | portant; left: auto !important; outl |
|                                      | ine: 0px !important; overflow: visib |
|                                      | le !important; position: static !imp |
|                                      | ortant; right: auto !important; text |
|                                      | -align: left !important; top: auto ! |
|                                      | important; vertical-align: baseline  |
|                                      | !important; width: auto !important;  |
|                                      | box-sizing: content-box !important;  |
|                                      | font-family: Consolas, 'Bitstream Ve |
|                                      | ra Sans Mono', 'Courier New', Courie |
|                                      | r, monospace !important; font-weight |
|                                      | : normal !important; font-style: nor |
|                                      | mal !important; font-size: 1em !impo |
|                                      | rtant; min-height: auto !important;  |
|                                      | white-space: pre !important; backgro |
|                                      | und: none rgb(255, 255, 255) !import |
|                                      | ant;">                               |
|                                      |                                      |
|                                      | `            `{style="margin: 0px !i |
|                                      | mportant; padding: 0px !important; w |
|                                      | hite-space: nowrap; border: 0px !imp |
|                                      | ortant; border-radius: 0px !importan |
|                                      | t; bottom: auto !important; float: n |
|                                      | one !important; height: auto !import |
|                                      | ant; left: auto !important; outline: |
|                                      |  0px !important; overflow: visible ! |
|                                      | important; position: static !importa |
|                                      | nt; right: auto !important; text-ali |
|                                      | gn: left !important; top: auto !impo |
|                                      | rtant; vertical-align: baseline !imp |
|                                      | ortant; width: auto !important; box- |
|                                      | sizing: content-box !important; font |
|                                      | -family: Consolas, 'Bitstream Vera S |
|                                      | ans Mono', 'Courier New', Courier, m |
|                                      | onospace !important; font-weight: no |
|                                      | rmal !important; font-style: normal  |
|                                      | !important; font-size: 1em !importan |
|                                      | t; min-height: auto !important; back |
|                                      | ground: none !important;"}`stream.Cl |
|                                      | ose();`{style="margin: 0px !importan |
|                                      | t; padding: 0px !important; white-sp |
|                                      | ace: nowrap; border: 0px !important; |
|                                      |  border-radius: 0px !important; bott |
|                                      | om: auto !important; float: none !im |
|                                      | portant; height: auto !important; le |
|                                      | ft: auto !important; outline: 0px !i |
|                                      | mportant; overflow: visible !importa |
|                                      | nt; position: static !important; rig |
|                                      | ht: auto !important; text-align: lef |
|                                      | t !important; top: auto !important;  |
|                                      | vertical-align: baseline !important; |
|                                      |  width: auto !important; box-sizing: |
|                                      |  content-box !important; font-family |
|                                      | : Consolas, 'Bitstream Vera Sans Mon |
|                                      | o', 'Courier New', Courier, monospac |
|                                      | e !important; font-weight: normal !i |
|                                      | mportant; font-style: normal !import |
|                                      | ant; font-size: 1em !important; min- |
|                                      | height: auto !important; color: rgb( |
|                                      | 0, 0, 0) !important; background: non |
|                                      | e !important;"}                      |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="margin: 0px !important; paddi |
|                                      | ng: 0px 1em !important; border-radiu |
|                                      | s: 0px !important; border: 0px !impo |
|                                      | rtant; bottom: auto !important; floa |
|                                      | t: none !important; height: auto !im |
|                                      | portant; left: auto !important; outl |
|                                      | ine: 0px !important; overflow: visib |
|                                      | le !important; position: static !imp |
|                                      | ortant; right: auto !important; text |
|                                      | -align: left !important; top: auto ! |
|                                      | important; vertical-align: baseline  |
|                                      | !important; width: auto !important;  |
|                                      | box-sizing: content-box !important;  |
|                                      | font-family: Consolas, 'Bitstream Ve |
|                                      | ra Sans Mono', 'Courier New', Courie |
|                                      | r, monospace !important; font-weight |
|                                      | : normal !important; font-style: nor |
|                                      | mal !important; font-size: 1em !impo |
|                                      | rtant; min-height: auto !important;  |
|                                      | white-space: pre !important; backgro |
|                                      | und: none rgb(248, 248, 248) !import |
|                                      | ant;">                               |
|                                      |                                      |
|                                      |                                      |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="margin: 0px !important; paddi |
|                                      | ng: 0px 1em !important; border-radiu |
|                                      | s: 0px !important; border: 0px !impo |
|                                      | rtant; bottom: auto !important; floa |
|                                      | t: none !important; height: auto !im |
|                                      | portant; left: auto !important; outl |
|                                      | ine: 0px !important; overflow: visib |
|                                      | le !important; position: static !imp |
|                                      | ortant; right: auto !important; text |
|                                      | -align: left !important; top: auto ! |
|                                      | important; vertical-align: baseline  |
|                                      | !important; width: auto !important;  |
|                                      | box-sizing: content-box !important;  |
|                                      | font-family: Consolas, 'Bitstream Ve |
|                                      | ra Sans Mono', 'Courier New', Courie |
|                                      | r, monospace !important; font-weight |
|                                      | : normal !important; font-style: nor |
|                                      | mal !important; font-size: 1em !impo |
|                                      | rtant; min-height: auto !important;  |
|                                      | white-space: pre !important; backgro |
|                                      | und: none rgb(255, 255, 255) !import |
|                                      | ant;">                               |
|                                      |                                      |
|                                      | `            `{style="margin: 0px !i |
|                                      | mportant; padding: 0px !important; w |
|                                      | hite-space: nowrap; border: 0px !imp |
|                                      | ortant; border-radius: 0px !importan |
|                                      | t; bottom: auto !important; float: n |
|                                      | one !important; height: auto !import |
|                                      | ant; left: auto !important; outline: |
|                                      |  0px !important; overflow: visible ! |
|                                      | important; position: static !importa |
|                                      | nt; right: auto !important; text-ali |
|                                      | gn: left !important; top: auto !impo |
|                                      | rtant; vertical-align: baseline !imp |
|                                      | ortant; width: auto !important; box- |
|                                      | sizing: content-box !important; font |
|                                      | -family: Consolas, 'Bitstream Vera S |
|                                      | ans Mono', 'Courier New', Courier, m |
|                                      | onospace !important; font-weight: no |
|                                      | rmal !important; font-style: normal  |
|                                      | !important; font-size: 1em !importan |
|                                      | t; min-height: auto !important; back |
|                                      | ground: none !important;"}`//Deseria |
|                                      | lization of String Object`{style="ma |
|                                      | rgin: 0px !important; padding: 0px ! |
|                                      | important; white-space: nowrap; bord |
|                                      | er: 0px !important; border-radius: 0 |
|                                      | px !important; bottom: auto !importa |
|                                      | nt; float: none !important; height:  |
|                                      | auto !important; left: auto !importa |
|                                      | nt; outline: 0px !important; overflo |
|                                      | w: visible !important; position: sta |
|                                      | tic !important; right: auto !importa |
|                                      | nt; text-align: left !important; top |
|                                      | : auto !important; vertical-align: b |
|                                      | aseline !important; width: auto !imp |
|                                      | ortant; box-sizing: content-box !imp |
|                                      | ortant; font-family: Consolas, 'Bits |
|                                      | tream Vera Sans Mono', 'Courier New' |
|                                      | , Courier, monospace !important; fon |
|                                      | t-weight: normal !important; font-st |
|                                      | yle: normal !important; font-size: 1 |
|                                      | em !important; min-height: auto !imp |
|                                      | ortant; color: rgb(0, 130, 0) !impor |
|                                      | tant; background: none !important;"} |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="margin: 0px !important; paddi |
|                                      | ng: 0px 1em !important; border-radiu |
|                                      | s: 0px !important; border: 0px !impo |
|                                      | rtant; bottom: auto !important; floa |
|                                      | t: none !important; height: auto !im |
|                                      | portant; left: auto !important; outl |
|                                      | ine: 0px !important; overflow: visib |
|                                      | le !important; position: static !imp |
|                                      | ortant; right: auto !important; text |
|                                      | -align: left !important; top: auto ! |
|                                      | important; vertical-align: baseline  |
|                                      | !important; width: auto !important;  |
|                                      | box-sizing: content-box !important;  |
|                                      | font-family: Consolas, 'Bitstream Ve |
|                                      | ra Sans Mono', 'Courier New', Courie |
|                                      | r, monospace !important; font-weight |
|                                      | : normal !important; font-style: nor |
|                                      | mal !important; font-size: 1em !impo |
|                                      | rtant; min-height: auto !important;  |
|                                      | white-space: pre !important; backgro |
|                                      | und: none rgb(248, 248, 248) !import |
|                                      | ant;">                               |
|                                      |                                      |
|                                      | `            `{style="margin: 0px !i |
|                                      | mportant; padding: 0px !important; w |
|                                      | hite-space: nowrap; border: 0px !imp |
|                                      | ortant; border-radius: 0px !importan |
|                                      | t; bottom: auto !important; float: n |
|                                      | one !important; height: auto !import |
|                                      | ant; left: auto !important; outline: |
|                                      |  0px !important; overflow: visible ! |
|                                      | important; position: static !importa |
|                                      | nt; right: auto !important; text-ali |
|                                      | gn: left !important; top: auto !impo |
|                                      | rtant; vertical-align: baseline !imp |
|                                      | ortant; width: auto !important; box- |
|                                      | sizing: content-box !important; font |
|                                      | -family: Consolas, 'Bitstream Vera S |
|                                      | ans Mono', 'Courier New', Courier, m |
|                                      | onospace !important; font-weight: no |
|                                      | rmal !important; font-style: normal  |
|                                      | !important; font-size: 1em !importan |
|                                      | t; min-height: auto !important; back |
|                                      | ground: none !important;"}`FileStrea |
|                                      | m readstream = `{style="margin: 0px  |
|                                      | !important; padding: 0px !important; |
|                                      |  white-space: nowrap; border: 0px !i |
|                                      | mportant; border-radius: 0px !import |
|                                      | ant; bottom: auto !important; float: |
|                                      |  none !important; height: auto !impo |
|                                      | rtant; left: auto !important; outlin |
|                                      | e: 0px !important; overflow: visible |
|                                      |  !important; position: static !impor |
|                                      | tant; right: auto !important; text-a |
|                                      | lign: left !important; top: auto !im |
|                                      | portant; vertical-align: baseline !i |
|                                      | mportant; width: auto !important; bo |
|                                      | x-sizing: content-box !important; fo |
|                                      | nt-family: Consolas, 'Bitstream Vera |
|                                      |  Sans Mono', 'Courier New', Courier, |
|                                      |  monospace !important; font-weight:  |
|                                      | normal !important; font-style: norma |
|                                      | l !important; font-size: 1em !import |
|                                      | ant; min-height: auto !important; co |
|                                      | lor: rgb(0, 0, 0) !important; backgr |
|                                      | ound: none !important;"}`new`{style= |
|                                      | "margin: 0px !important; padding: 0p |
|                                      | x !important; white-space: nowrap; b |
|                                      | order: 0px !important; border-radius |
|                                      | : 0px !important; bottom: auto !impo |
|                                      | rtant; float: none !important; heigh |
|                                      | t: auto !important; left: auto !impo |
|                                      | rtant; outline: 0px !important; over |
|                                      | flow: visible !important; position:  |
|                                      | static !important; right: auto !impo |
|                                      | rtant; text-align: left !important;  |
|                                      | top: auto !important; vertical-align |
|                                      | : baseline !important; width: auto ! |
|                                      | important; box-sizing: content-box ! |
|                                      | important; font-family: Consolas, 'B |
|                                      | itstream Vera Sans Mono', 'Courier N |
|                                      | ew', Courier, monospace !important;  |
|                                      | font-weight: bold !important; font-s |
|                                      | tyle: normal !important; font-size:  |
|                                      | 1em !important; min-height: auto !im |
|                                      | portant; color: rgb(0, 102, 153) !im |
|                                      | portant; background: none !important |
|                                      | ;"}                                  |
|                                      | `FileStream(`{style="margin: 0px !im |
|                                      | portant; padding: 0px !important; wh |
|                                      | ite-space: nowrap; border: 0px !impo |
|                                      | rtant; border-radius: 0px !important |
|                                      | ; bottom: auto !important; float: no |
|                                      | ne !important; height: auto !importa |
|                                      | nt; left: auto !important; outline:  |
|                                      | 0px !important; overflow: visible !i |
|                                      | mportant; position: static !importan |
|                                      | t; right: auto !important; text-alig |
|                                      | n: left !important; top: auto !impor |
|                                      | tant; vertical-align: baseline !impo |
|                                      | rtant; width: auto !important; box-s |
|                                      | izing: content-box !important; font- |
|                                      | family: Consolas, 'Bitstream Vera Sa |
|                                      | ns Mono', 'Courier New', Courier, mo |
|                                      | nospace !important; font-weight: nor |
|                                      | mal !important; font-style: normal ! |
|                                      | important; font-size: 1em !important |
|                                      | ; min-height: auto !important; color |
|                                      | : rgb(0, 0, 0) !important; backgroun |
|                                      | d: none !important;"}`"C:\\StrObj.tx |
|                                      | t"`{style="margin: 0px !important; p |
|                                      | adding: 0px !important; white-space: |
|                                      |  nowrap; border: 0px !important; bor |
|                                      | der-radius: 0px !important; bottom:  |
|                                      | auto !important; float: none !import |
|                                      | ant; height: auto !important; left:  |
|                                      | auto !important; outline: 0px !impor |
|                                      | tant; overflow: visible !important;  |
|                                      | position: static !important; right:  |
|                                      | auto !important; text-align: left !i |
|                                      | mportant; top: auto !important; vert |
|                                      | ical-align: baseline !important; wid |
|                                      | th: auto !important; box-sizing: con |
|                                      | tent-box !important; font-family: Co |
|                                      | nsolas, 'Bitstream Vera Sans Mono',  |
|                                      | 'Courier New', Courier, monospace !i |
|                                      | mportant; font-weight: normal !impor |
|                                      | tant; font-style: normal !important; |
|                                      |  font-size: 1em !important; min-heig |
|                                      | ht: auto !important; color: blue !im |
|                                      | portant; background: none !important |
|                                      | ;"}`, FileMode.Open , FileAccess.Rea |
|                                      | d ,`{style="margin: 0px !important;  |
|                                      | padding: 0px !important; white-space |
|                                      | : nowrap; border: 0px !important; bo |
|                                      | rder-radius: 0px !important; bottom: |
|                                      |  auto !important; float: none !impor |
|                                      | tant; height: auto !important; left: |
|                                      |  auto !important; outline: 0px !impo |
|                                      | rtant; overflow: visible !important; |
|                                      |  position: static !important; right: |
|                                      |  auto !important; text-align: left ! |
|                                      | important; top: auto !important; ver |
|                                      | tical-align: baseline !important; wi |
|                                      | dth: auto !important; box-sizing: co |
|                                      | ntent-box !important; font-family: C |
|                                      | onsolas, 'Bitstream Vera Sans Mono', |
|                                      |  'Courier New', Courier, monospace ! |
|                                      | important; font-weight: normal !impo |
|                                      | rtant; font-style: normal !important |
|                                      | ; font-size: 1em !important; min-hei |
|                                      | ght: auto !important; color: rgb(0,  |
|                                      | 0, 0) !important; background: none ! |
|                                      | important;"}                         |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="margin: 0px !important; paddi |
|                                      | ng: 0px 1em !important; border-radiu |
|                                      | s: 0px !important; border: 0px !impo |
|                                      | rtant; bottom: auto !important; floa |
|                                      | t: none !important; height: auto !im |
|                                      | portant; left: auto !important; outl |
|                                      | ine: 0px !important; overflow: visib |
|                                      | le !important; position: static !imp |
|                                      | ortant; right: auto !important; text |
|                                      | -align: left !important; top: auto ! |
|                                      | important; vertical-align: baseline  |
|                                      | !important; width: auto !important;  |
|                                      | box-sizing: content-box !important;  |
|                                      | font-family: Consolas, 'Bitstream Ve |
|                                      | ra Sans Mono', 'Courier New', Courie |
|                                      | r, monospace !important; font-weight |
|                                      | : normal !important; font-style: nor |
|                                      | mal !important; font-size: 1em !impo |
|                                      | rtant; min-height: auto !important;  |
|                                      | white-space: pre !important; backgro |
|                                      | und: none rgb(255, 255, 255) !import |
|                                      | ant;">                               |
|                                      |                                      |
|                                      | `            `{style="margin: 0px !i |
|                                      | mportant; padding: 0px !important; w |
|                                      | hite-space: nowrap; border: 0px !imp |
|                                      | ortant; border-radius: 0px !importan |
|                                      | t; bottom: auto !important; float: n |
|                                      | one !important; height: auto !import |
|                                      | ant; left: auto !important; outline: |
|                                      |  0px !important; overflow: visible ! |
|                                      | important; position: static !importa |
|                                      | nt; right: auto !important; text-ali |
|                                      | gn: left !important; top: auto !impo |
|                                      | rtant; vertical-align: baseline !imp |
|                                      | ortant; width: auto !important; box- |
|                                      | sizing: content-box !important; font |
|                                      | -family: Consolas, 'Bitstream Vera S |
|                                      | ans Mono', 'Courier New', Courier, m |
|                                      | onospace !important; font-weight: no |
|                                      | rmal !important; font-style: normal  |
|                                      | !important; font-size: 1em !importan |
|                                      | t; min-height: auto !important; back |
|                                      | ground: none !important;"}`FileShare |
|                                      | .Read );`{style="margin: 0px !import |
|                                      | ant; padding: 0px !important; white- |
|                                      | space: nowrap; border: 0px !importan |
|                                      | t; border-radius: 0px !important; bo |
|                                      | ttom: auto !important; float: none ! |
|                                      | important; height: auto !important;  |
|                                      | left: auto !important; outline: 0px  |
|                                      | !important; overflow: visible !impor |
|                                      | tant; position: static !important; r |
|                                      | ight: auto !important; text-align: l |
|                                      | eft !important; top: auto !important |
|                                      | ; vertical-align: baseline !importan |
|                                      | t; width: auto !important; box-sizin |
|                                      | g: content-box !important; font-fami |
|                                      | ly: Consolas, 'Bitstream Vera Sans M |
|                                      | ono', 'Courier New', Courier, monosp |
|                                      | ace !important; font-weight: normal  |
|                                      | !important; font-style: normal !impo |
|                                      | rtant; font-size: 1em !important; mi |
|                                      | n-height: auto !important; color: rg |
|                                      | b(0, 0, 0) !important; background: n |
|                                      | one !important;"}                    |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="margin: 0px !important; paddi |
|                                      | ng: 0px 1em !important; border-radiu |
|                                      | s: 0px !important; border: 0px !impo |
|                                      | rtant; bottom: auto !important; floa |
|                                      | t: none !important; height: auto !im |
|                                      | portant; left: auto !important; outl |
|                                      | ine: 0px !important; overflow: visib |
|                                      | le !important; position: static !imp |
|                                      | ortant; right: auto !important; text |
|                                      | -align: left !important; top: auto ! |
|                                      | important; vertical-align: baseline  |
|                                      | !important; width: auto !important;  |
|                                      | box-sizing: content-box !important;  |
|                                      | font-family: Consolas, 'Bitstream Ve |
|                                      | ra Sans Mono', 'Courier New', Courie |
|                                      | r, monospace !important; font-weight |
|                                      | : normal !important; font-style: nor |
|                                      | mal !important; font-size: 1em !impo |
|                                      | rtant; min-height: auto !important;  |
|                                      | white-space: pre !important; backgro |
|                                      | und: none rgb(248, 248, 248) !import |
|                                      | ant;">                               |
|                                      |                                      |
|                                      | `            `{style="margin: 0px !i |
|                                      | mportant; padding: 0px !important; w |
|                                      | hite-space: nowrap; border: 0px !imp |
|                                      | ortant; border-radius: 0px !importan |
|                                      | t; bottom: auto !important; float: n |
|                                      | one !important; height: auto !import |
|                                      | ant; left: auto !important; outline: |
|                                      |  0px !important; overflow: visible ! |
|                                      | important; position: static !importa |
|                                      | nt; right: auto !important; text-ali |
|                                      | gn: left !important; top: auto !impo |
|                                      | rtant; vertical-align: baseline !imp |
|                                      | ortant; width: auto !important; box- |
|                                      | sizing: content-box !important; font |
|                                      | -family: Consolas, 'Bitstream Vera S |
|                                      | ans Mono', 'Courier New', Courier, m |
|                                      | onospace !important; font-weight: no |
|                                      | rmal !important; font-style: normal  |
|                                      | !important; font-size: 1em !importan |
|                                      | t; min-height: auto !important; back |
|                                      | ground: none !important;"}`string`{s |
|                                      | tyle="margin: 0px !important; paddin |
|                                      | g: 0px !important; white-space: nowr |
|                                      | ap; border: 0px !important; border-r |
|                                      | adius: 0px !important; bottom: auto  |
|                                      | !important; float: none !important;  |
|                                      | height: auto !important; left: auto  |
|                                      | !important; outline: 0px !important; |
|                                      |  overflow: visible !important; posit |
|                                      | ion: static !important; right: auto  |
|                                      | !important; text-align: left !import |
|                                      | ant; top: auto !important; vertical- |
|                                      | align: baseline !important; width: a |
|                                      | uto !important; box-sizing: content- |
|                                      | box !important; font-family: Consola |
|                                      | s, 'Bitstream Vera Sans Mono', 'Cour |
|                                      | ier New', Courier, monospace !import |
|                                      | ant; font-weight: bold !important; f |
|                                      | ont-style: normal !important; font-s |
|                                      | ize: 1em !important; min-height: aut |
|                                      | o !important; color: rgb(0, 102, 153 |
|                                      | ) !important; background: none !impo |
|                                      | rtant;"}                             |
|                                      | `readdata = (`{style="margin: 0px !i |
|                                      | mportant; padding: 0px !important; w |
|                                      | hite-space: nowrap; border: 0px !imp |
|                                      | ortant; border-radius: 0px !importan |
|                                      | t; bottom: auto !important; float: n |
|                                      | one !important; height: auto !import |
|                                      | ant; left: auto !important; outline: |
|                                      |  0px !important; overflow: visible ! |
|                                      | important; position: static !importa |
|                                      | nt; right: auto !important; text-ali |
|                                      | gn: left !important; top: auto !impo |
|                                      | rtant; vertical-align: baseline !imp |
|                                      | ortant; width: auto !important; box- |
|                                      | sizing: content-box !important; font |
|                                      | -family: Consolas, 'Bitstream Vera S |
|                                      | ans Mono', 'Courier New', Courier, m |
|                                      | onospace !important; font-weight: no |
|                                      | rmal !important; font-style: normal  |
|                                      | !important; font-size: 1em !importan |
|                                      | t; min-height: auto !important; colo |
|                                      | r: rgb(0, 0, 0) !important; backgrou |
|                                      | nd: none !important;"}`string`{style |
|                                      | ="margin: 0px !important; padding: 0 |
|                                      | px !important; white-space: nowrap;  |
|                                      | border: 0px !important; border-radiu |
|                                      | s: 0px !important; bottom: auto !imp |
|                                      | ortant; float: none !important; heig |
|                                      | ht: auto !important; left: auto !imp |
|                                      | ortant; outline: 0px !important; ove |
|                                      | rflow: visible !important; position: |
|                                      |  static !important; right: auto !imp |
|                                      | ortant; text-align: left !important; |
|                                      |  top: auto !important; vertical-alig |
|                                      | n: baseline !important; width: auto  |
|                                      | !important; box-sizing: content-box  |
|                                      | !important; font-family: Consolas, ' |
|                                      | Bitstream Vera Sans Mono', 'Courier  |
|                                      | New', Courier, monospace !important; |
|                                      |  font-weight: bold !important; font- |
|                                      | style: normal !important; font-size: |
|                                      |  1em !important; min-height: auto !i |
|                                      | mportant; color: rgb(0, 102, 153) !i |
|                                      | mportant; background: none !importan |
|                                      | t;"}`)formatter.Deserialize(readstre |
|                                      | am);`{style="margin: 0px !important; |
|                                      |  padding: 0px !important; white-spac |
|                                      | e: nowrap; border: 0px !important; b |
|                                      | order-radius: 0px !important; bottom |
|                                      | : auto !important; float: none !impo |
|                                      | rtant; height: auto !important; left |
|                                      | : auto !important; outline: 0px !imp |
|                                      | ortant; overflow: visible !important |
|                                      | ; position: static !important; right |
|                                      | : auto !important; text-align: left  |
|                                      | !important; top: auto !important; ve |
|                                      | rtical-align: baseline !important; w |
|                                      | idth: auto !important; box-sizing: c |
|                                      | ontent-box !important; font-family:  |
|                                      | Consolas, 'Bitstream Vera Sans Mono' |
|                                      | , 'Courier New', Courier, monospace  |
|                                      | !important; font-weight: normal !imp |
|                                      | ortant; font-style: normal !importan |
|                                      | t; font-size: 1em !important; min-he |
|                                      | ight: auto !important; color: rgb(0, |
|                                      |  0, 0) !important; background: none  |
|                                      | !important;"}                        |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="margin: 0px !important; paddi |
|                                      | ng: 0px 1em !important; border-radiu |
|                                      | s: 0px !important; border: 0px !impo |
|                                      | rtant; bottom: auto !important; floa |
|                                      | t: none !important; height: auto !im |
|                                      | portant; left: auto !important; outl |
|                                      | ine: 0px !important; overflow: visib |
|                                      | le !important; position: static !imp |
|                                      | ortant; right: auto !important; text |
|                                      | -align: left !important; top: auto ! |
|                                      | important; vertical-align: baseline  |
|                                      | !important; width: auto !important;  |
|                                      | box-sizing: content-box !important;  |
|                                      | font-family: Consolas, 'Bitstream Ve |
|                                      | ra Sans Mono', 'Courier New', Courie |
|                                      | r, monospace !important; font-weight |
|                                      | : normal !important; font-style: nor |
|                                      | mal !important; font-size: 1em !impo |
|                                      | rtant; min-height: auto !important;  |
|                                      | white-space: pre !important; backgro |
|                                      | und: none rgb(255, 255, 255) !import |
|                                      | ant;">                               |
|                                      |                                      |
|                                      | `            `{style="margin: 0px !i |
|                                      | mportant; padding: 0px !important; w |
|                                      | hite-space: nowrap; border: 0px !imp |
|                                      | ortant; border-radius: 0px !importan |
|                                      | t; bottom: auto !important; float: n |
|                                      | one !important; height: auto !import |
|                                      | ant; left: auto !important; outline: |
|                                      |  0px !important; overflow: visible ! |
|                                      | important; position: static !importa |
|                                      | nt; right: auto !important; text-ali |
|                                      | gn: left !important; top: auto !impo |
|                                      | rtant; vertical-align: baseline !imp |
|                                      | ortant; width: auto !important; box- |
|                                      | sizing: content-box !important; font |
|                                      | -family: Consolas, 'Bitstream Vera S |
|                                      | ans Mono', 'Courier New', Courier, m |
|                                      | onospace !important; font-weight: no |
|                                      | rmal !important; font-style: normal  |
|                                      | !important; font-size: 1em !importan |
|                                      | t; min-height: auto !important; back |
|                                      | ground: none !important;"}`readstrea |
|                                      | m.Close();`{style="margin: 0px !impo |
|                                      | rtant; padding: 0px !important; whit |
|                                      | e-space: nowrap; border: 0px !import |
|                                      | ant; border-radius: 0px !important;  |
|                                      | bottom: auto !important; float: none |
|                                      |  !important; height: auto !important |
|                                      | ; left: auto !important; outline: 0p |
|                                      | x !important; overflow: visible !imp |
|                                      | ortant; position: static !important; |
|                                      |  right: auto !important; text-align: |
|                                      |  left !important; top: auto !importa |
|                                      | nt; vertical-align: baseline !import |
|                                      | ant; width: auto !important; box-siz |
|                                      | ing: content-box !important; font-fa |
|                                      | mily: Consolas, 'Bitstream Vera Sans |
|                                      |  Mono', 'Courier New', Courier, mono |
|                                      | space !important; font-weight: norma |
|                                      | l !important; font-style: normal !im |
|                                      | portant; font-size: 1em !important;  |
|                                      | min-height: auto !important; color:  |
|                                      | rgb(0, 0, 0) !important; background: |
|                                      |  none !important;"}                  |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="margin: 0px !important; paddi |
|                                      | ng: 0px 1em !important; border-radiu |
|                                      | s: 0px !important; border: 0px !impo |
|                                      | rtant; bottom: auto !important; floa |
|                                      | t: none !important; height: auto !im |
|                                      | portant; left: auto !important; outl |
|                                      | ine: 0px !important; overflow: visib |
|                                      | le !important; position: static !imp |
|                                      | ortant; right: auto !important; text |
|                                      | -align: left !important; top: auto ! |
|                                      | important; vertical-align: baseline  |
|                                      | !important; width: auto !important;  |
|                                      | box-sizing: content-box !important;  |
|                                      | font-family: Consolas, 'Bitstream Ve |
|                                      | ra Sans Mono', 'Courier New', Courie |
|                                      | r, monospace !important; font-weight |
|                                      | : normal !important; font-style: nor |
|                                      | mal !important; font-size: 1em !impo |
|                                      | rtant; min-height: auto !important;  |
|                                      | white-space: pre !important; backgro |
|                                      | und: none rgb(248, 248, 248) !import |
|                                      | ant;">                               |
|                                      |                                      |
|                                      | `            `{style="margin: 0px !i |
|                                      | mportant; padding: 0px !important; w |
|                                      | hite-space: nowrap; border: 0px !imp |
|                                      | ortant; border-radius: 0px !importan |
|                                      | t; bottom: auto !important; float: n |
|                                      | one !important; height: auto !import |
|                                      | ant; left: auto !important; outline: |
|                                      |  0px !important; overflow: visible ! |
|                                      | important; position: static !importa |
|                                      | nt; right: auto !important; text-ali |
|                                      | gn: left !important; top: auto !impo |
|                                      | rtant; vertical-align: baseline !imp |
|                                      | ortant; width: auto !important; box- |
|                                      | sizing: content-box !important; font |
|                                      | -family: Consolas, 'Bitstream Vera S |
|                                      | ans Mono', 'Courier New', Courier, m |
|                                      | onospace !important; font-weight: no |
|                                      | rmal !important; font-style: normal  |
|                                      | !important; font-size: 1em !importan |
|                                      | t; min-height: auto !important; back |
|                                      | ground: none !important;"}`Console.W |
|                                      | riteLine(readdata);`{style="margin:  |
|                                      | 0px !important; padding: 0px !import |
|                                      | ant; white-space: nowrap; border: 0p |
|                                      | x !important; border-radius: 0px !im |
|                                      | portant; bottom: auto !important; fl |
|                                      | oat: none !important; height: auto ! |
|                                      | important; left: auto !important; ou |
|                                      | tline: 0px !important; overflow: vis |
|                                      | ible !important; position: static !i |
|                                      | mportant; right: auto !important; te |
|                                      | xt-align: left !important; top: auto |
|                                      |  !important; vertical-align: baselin |
|                                      | e !important; width: auto !important |
|                                      | ; box-sizing: content-box !important |
|                                      | ; font-family: Consolas, 'Bitstream  |
|                                      | Vera Sans Mono', 'Courier New', Cour |
|                                      | ier, monospace !important; font-weig |
|                                      | ht: normal !important; font-style: n |
|                                      | ormal !important; font-size: 1em !im |
|                                      | portant; min-height: auto !important |
|                                      | ; color: rgb(0, 0, 0) !important; ba |
|                                      | ckground: none !important;"}         |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="margin: 0px !important; paddi |
|                                      | ng: 0px 1em !important; border-radiu |
|                                      | s: 0px !important; border: 0px !impo |
|                                      | rtant; bottom: auto !important; floa |
|                                      | t: none !important; height: auto !im |
|                                      | portant; left: auto !important; outl |
|                                      | ine: 0px !important; overflow: visib |
|                                      | le !important; position: static !imp |
|                                      | ortant; right: auto !important; text |
|                                      | -align: left !important; top: auto ! |
|                                      | important; vertical-align: baseline  |
|                                      | !important; width: auto !important;  |
|                                      | box-sizing: content-box !important;  |
|                                      | font-family: Consolas, 'Bitstream Ve |
|                                      | ra Sans Mono', 'Courier New', Courie |
|                                      | r, monospace !important; font-weight |
|                                      | : normal !important; font-style: nor |
|                                      | mal !important; font-size: 1em !impo |
|                                      | rtant; min-height: auto !important;  |
|                                      | white-space: pre !important; backgro |
|                                      | und: none rgb(255, 255, 255) !import |
|                                      | ant;">                               |
|                                      |                                      |
|                                      | `            `{style="margin: 0px !i |
|                                      | mportant; padding: 0px !important; w |
|                                      | hite-space: nowrap; border: 0px !imp |
|                                      | ortant; border-radius: 0px !importan |
|                                      | t; bottom: auto !important; float: n |
|                                      | one !important; height: auto !import |
|                                      | ant; left: auto !important; outline: |
|                                      |  0px !important; overflow: visible ! |
|                                      | important; position: static !importa |
|                                      | nt; right: auto !important; text-ali |
|                                      | gn: left !important; top: auto !impo |
|                                      | rtant; vertical-align: baseline !imp |
|                                      | ortant; width: auto !important; box- |
|                                      | sizing: content-box !important; font |
|                                      | -family: Consolas, 'Bitstream Vera S |
|                                      | ans Mono', 'Courier New', Courier, m |
|                                      | onospace !important; font-weight: no |
|                                      | rmal !important; font-style: normal  |
|                                      | !important; font-size: 1em !importan |
|                                      | t; min-height: auto !important; back |
|                                      | ground: none !important;"}`Console.R |
|                                      | eadLine();`{style="margin: 0px !impo |
|                                      | rtant; padding: 0px !important; whit |
|                                      | e-space: nowrap; border: 0px !import |
|                                      | ant; border-radius: 0px !important;  |
|                                      | bottom: auto !important; float: none |
|                                      |  !important; height: auto !important |
|                                      | ; left: auto !important; outline: 0p |
|                                      | x !important; overflow: visible !imp |
|                                      | ortant; position: static !important; |
|                                      |  right: auto !important; text-align: |
|                                      |  left !important; top: auto !importa |
|                                      | nt; vertical-align: baseline !import |
|                                      | ant; width: auto !important; box-siz |
|                                      | ing: content-box !important; font-fa |
|                                      | mily: Consolas, 'Bitstream Vera Sans |
|                                      |  Mono', 'Courier New', Courier, mono |
|                                      | space !important; font-weight: norma |
|                                      | l !important; font-style: normal !im |
|                                      | portant; font-size: 1em !important;  |
|                                      | min-height: auto !important; color:  |
|                                      | rgb(0, 0, 0) !important; background: |
|                                      |  none !important;"}                  |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="margin: 0px !important; paddi |
|                                      | ng: 0px 1em !important; border-radiu |
|                                      | s: 0px !important; border: 0px !impo |
|                                      | rtant; bottom: auto !important; floa |
|                                      | t: none !important; height: auto !im |
|                                      | portant; left: auto !important; outl |
|                                      | ine: 0px !important; overflow: visib |
|                                      | le !important; position: static !imp |
|                                      | ortant; right: auto !important; text |
|                                      | -align: left !important; top: auto ! |
|                                      | important; vertical-align: baseline  |
|                                      | !important; width: auto !important;  |
|                                      | box-sizing: content-box !important;  |
|                                      | font-family: Consolas, 'Bitstream Ve |
|                                      | ra Sans Mono', 'Courier New', Courie |
|                                      | r, monospace !important; font-weight |
|                                      | : normal !important; font-style: nor |
|                                      | mal !important; font-size: 1em !impo |
|                                      | rtant; min-height: auto !important;  |
|                                      | white-space: pre !important; backgro |
|                                      | und: none rgb(248, 248, 248) !import |
|                                      | ant;">                               |
|                                      |                                      |
|                                      |                                      |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="margin: 0px !important; paddi |
|                                      | ng: 0px 1em !important; border-radiu |
|                                      | s: 0px !important; border: 0px !impo |
|                                      | rtant; bottom: auto !important; floa |
|                                      | t: none !important; height: auto !im |
|                                      | portant; left: auto !important; outl |
|                                      | ine: 0px !important; overflow: visib |
|                                      | le !important; position: static !imp |
|                                      | ortant; right: auto !important; text |
|                                      | -align: left !important; top: auto ! |
|                                      | important; vertical-align: baseline  |
|                                      | !important; width: auto !important;  |
|                                      | box-sizing: content-box !important;  |
|                                      | font-family: Consolas, 'Bitstream Ve |
|                                      | ra Sans Mono', 'Courier New', Courie |
|                                      | r, monospace !important; font-weight |
|                                      | : normal !important; font-style: nor |
|                                      | mal !important; font-size: 1em !impo |
|                                      | rtant; min-height: auto !important;  |
|                                      | white-space: pre !important; backgro |
|                                      | und: none rgb(255, 255, 255) !import |
|                                      | ant;">                               |
|                                      |                                      |
|                                      | `        `{style="margin: 0px !impor |
|                                      | tant; padding: 0px !important; white |
|                                      | -space: nowrap; border: 0px !importa |
|                                      | nt; border-radius: 0px !important; b |
|                                      | ottom: auto !important; float: none  |
|                                      | !important; height: auto !important; |
|                                      |  left: auto !important; outline: 0px |
|                                      |  !important; overflow: visible !impo |
|                                      | rtant; position: static !important;  |
|                                      | right: auto !important; text-align:  |
|                                      | left !important; top: auto !importan |
|                                      | t; vertical-align: baseline !importa |
|                                      | nt; width: auto !important; box-sizi |
|                                      | ng: content-box !important; font-fam |
|                                      | ily: Consolas, 'Bitstream Vera Sans  |
|                                      | Mono', 'Courier New', Courier, monos |
|                                      | pace !important; font-weight: normal |
|                                      |  !important; font-style: normal !imp |
|                                      | ortant; font-size: 1em !important; m |
|                                      | in-height: auto !important; backgrou |
|                                      | nd: none !important;"}`}`{style="mar |
|                                      | gin: 0px !important; padding: 0px !i |
|                                      | mportant; white-space: nowrap; borde |
|                                      | r: 0px !important; border-radius: 0p |
|                                      | x !important; bottom: auto !importan |
|                                      | t; float: none !important; height: a |
|                                      | uto !important; left: auto !importan |
|                                      | t; outline: 0px !important; overflow |
|                                      | : visible !important; position: stat |
|                                      | ic !important; right: auto !importan |
|                                      | t; text-align: left !important; top: |
|                                      |  auto !important; vertical-align: ba |
|                                      | seline !important; width: auto !impo |
|                                      | rtant; box-sizing: content-box !impo |
|                                      | rtant; font-family: Consolas, 'Bitst |
|                                      | ream Vera Sans Mono', 'Courier New', |
|                                      |  Courier, monospace !important; font |
|                                      | -weight: normal !important; font-sty |
|                                      | le: normal !important; font-size: 1e |
|                                      | m !important; min-height: auto !impo |
|                                      | rtant; color: rgb(0, 0, 0) !importan |
|                                      | t; background: none !important;"}    |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="margin: 0px !important; paddi |
|                                      | ng: 0px 1em !important; border-radiu |
|                                      | s: 0px !important; border: 0px !impo |
|                                      | rtant; bottom: auto !important; floa |
|                                      | t: none !important; height: auto !im |
|                                      | portant; left: auto !important; outl |
|                                      | ine: 0px !important; overflow: visib |
|                                      | le !important; position: static !imp |
|                                      | ortant; right: auto !important; text |
|                                      | -align: left !important; top: auto ! |
|                                      | important; vertical-align: baseline  |
|                                      | !important; width: auto !important;  |
|                                      | box-sizing: content-box !important;  |
|                                      | font-family: Consolas, 'Bitstream Ve |
|                                      | ra Sans Mono', 'Courier New', Courie |
|                                      | r, monospace !important; font-weight |
|                                      | : normal !important; font-style: nor |
|                                      | mal !important; font-size: 1em !impo |
|                                      | rtant; min-height: auto !important;  |
|                                      | white-space: pre !important; backgro |
|                                      | und: none rgb(248, 248, 248) !import |
|                                      | ant;">                               |
|                                      |                                      |
|                                      | `    `{style="margin: 0px !important |
|                                      | ; padding: 0px !important; white-spa |
|                                      | ce: nowrap; border: 0px !important;  |
|                                      | border-radius: 0px !important; botto |
|                                      | m: auto !important; float: none !imp |
|                                      | ortant; height: auto !important; lef |
|                                      | t: auto !important; outline: 0px !im |
|                                      | portant; overflow: visible !importan |
|                                      | t; position: static !important; righ |
|                                      | t: auto !important; text-align: left |
|                                      |  !important; top: auto !important; v |
|                                      | ertical-align: baseline !important;  |
|                                      | width: auto !important; box-sizing:  |
|                                      | content-box !important; font-family: |
|                                      |  Consolas, 'Bitstream Vera Sans Mono |
|                                      | ', 'Courier New', Courier, monospace |
|                                      |  !important; font-weight: normal !im |
|                                      | portant; font-style: normal !importa |
|                                      | nt; font-size: 1em !important; min-h |
|                                      | eight: auto !important; background:  |
|                                      | none !important;"}`}`{style="margin: |
|                                      |  0px !important; padding: 0px !impor |
|                                      | tant; white-space: nowrap; border: 0 |
|                                      | px !important; border-radius: 0px !i |
|                                      | mportant; bottom: auto !important; f |
|                                      | loat: none !important; height: auto  |
|                                      | !important; left: auto !important; o |
|                                      | utline: 0px !important; overflow: vi |
|                                      | sible !important; position: static ! |
|                                      | important; right: auto !important; t |
|                                      | ext-align: left !important; top: aut |
|                                      | o !important; vertical-align: baseli |
|                                      | ne !important; width: auto !importan |
|                                      | t; box-sizing: content-box !importan |
|                                      | t; font-family: Consolas, 'Bitstream |
|                                      |  Vera Sans Mono', 'Courier New', Cou |
|                                      | rier, monospace !important; font-wei |
|                                      | ght: normal !important; font-style:  |
|                                      | normal !important; font-size: 1em !i |
|                                      | mportant; min-height: auto !importan |
|                                      | t; color: rgb(0, 0, 0) !important; b |
|                                      | ackground: none !important;"}        |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="margin: 0px !important; paddi |
|                                      | ng: 0px 1em !important; border-radiu |
|                                      | s: 0px !important; border: 0px !impo |
|                                      | rtant; bottom: auto !important; floa |
|                                      | t: none !important; height: auto !im |
|                                      | portant; left: auto !important; outl |
|                                      | ine: 0px !important; overflow: visib |
|                                      | le !important; position: static !imp |
|                                      | ortant; right: auto !important; text |
|                                      | -align: left !important; top: auto ! |
|                                      | important; vertical-align: baseline  |
|                                      | !important; width: auto !important;  |
|                                      | box-sizing: content-box !important;  |
|                                      | font-family: Consolas, 'Bitstream Ve |
|                                      | ra Sans Mono', 'Courier New', Courie |
|                                      | r, monospace !important; font-weight |
|                                      | : normal !important; font-style: nor |
|                                      | mal !important; font-size: 1em !impo |
|                                      | rtant; min-height: auto !important;  |
|                                      | white-space: pre !important; backgro |
|                                      | und: none rgb(255, 255, 255) !import |
|                                      | ant;">                               |
|                                      |                                      |
|                                      | <div>                                |
|                                      |                                      |
|                                      | `}`{style="margin: 0px !important; p |
|                                      | adding: 0px !important; white-space: |
|                                      |  nowrap; border: 0px !important; bor |
|                                      | der-radius: 0px !important; bottom:  |
|                                      | auto !important; float: none !import |
|                                      | ant; height: auto !important; left:  |
|                                      | auto !important; outline: 0px !impor |
|                                      | tant; overflow: visible !important;  |
|                                      | position: static !important; right:  |
|                                      | auto !important; text-align: left !i |
|                                      | mportant; top: auto !important; vert |
|                                      | ical-align: baseline !important; wid |
|                                      | th: auto !important; box-sizing: con |
|                                      | tent-box !important; font-family: Co |
|                                      | nsolas, 'Bitstream Vera Sans Mono',  |
|                                      | 'Courier New', Courier, monospace !i |
|                                      | mportant; font-weight: normal !impor |
|                                      | tant; font-style: normal !important; |
|                                      |  font-size: 1em !important; min-heig |
|                                      | ht: auto !important; color: rgb(0, 0 |
|                                      | , 0) !important; background: none !i |
|                                      | mportant;"}                          |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+

</div>

</div>

</div>

<div
style="margin: 0px 0px 5pt; padding: 0px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255);">

<div>

**SOAP序列化：**

**SOAP**协议是一个在异构的应用程序之间进行信息交互的理想的选择。我们需要在应用程序中添加System.Runtime.Serialization.Formatters.Soap名字空间以便在.Net中使用**SOAP序列化**。**SOAP序列化**的主要优势在于可移植性。**SoapFormatter**把对象序列化成**SOAP**消息或解析**SOAP**消息并重构被序列化的对象。下面的代码在.Net中使用**SoapFormatter**类序列化string类的对象。

<div
style="margin: 0px; padding: 0px; color: rgb(0, 0, 0); font-family: 'Microsoft YaHei', Verdana, sans-serif, SimSun; font-size: 14px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: auto; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255);">

<div
style="margin: 1em 0px !important; padding: 0px; width: 733px; position: relative !important; overflow: auto !important; font-size: 1em !important; background-color: rgb(255, 255, 255) !important;">

<div
style="margin: 0px !important; padding: 5px 0px 5px 5px; border-radius: 0px !important; border: 1px solid rgb(231, 229, 220) !important; bottom: auto !important; float: none !important; height: 11px !important; left: auto !important; outline: 0px !important; overflow: hidden; position: absolute !important; right: 1px !important; text-align: left !important; top: 1px !important; vertical-align: baseline !important; width: 11px !important; box-sizing: content-box !important; font-family: Consolas, 'Bitstream Vera Sans Mono', 'Courier New', Courier, monospace !important; font-weight: normal !important; font-style: normal !important; font-size: 10px !important; min-height: auto !important; color: white !important; z-index: 10 !important; background: rgb(248, 248, 248) !important;">

<div>

<span
style="margin: 0px; padding: 0px;">[?](http://www.oschina.net/translate/serialization-in-csharp#)</span>

</div>

</div>

+--------------------------------------+--------------------------------------+
| <div                                 | <div                                 |
| style="margin: 0px !important; paddi | style="margin: 0px !important; paddi |
| ng: 0px 0.5em 0px 1em !important; bo | ng: 0px !important; border-radius: 0 |
| rder-radius: 0px !important; border- | px !important; border: 0px !importan |
| width: 0px 3px 0px 0px !important; b | t; bottom: auto !important; float: n |
| order-right-style: solid !important; | one !important; height: auto !import |
|  border-right-color: rgb(108, 226, 1 | ant; left: auto !important; outline: |
| 08) !important; bottom: auto !import |  0px !important; overflow: visible ! |
| ant; float: none !important; height: | important; position: relative !impor |
|  auto !important; left: auto !import | tant; right: auto !important; text-a |
| ant; outline: 0px !important; overfl | lign: left !important; top: auto !im |
| ow: visible !important; position: st | portant; vertical-align: baseline !i |
| atic !important; right: auto !import | mportant; width: auto !important; bo |
| ant; text-align: right !important; t | x-sizing: content-box !important; fo |
| op: auto !important; vertical-align: | nt-family: Consolas, 'Bitstream Vera |
|  baseline !important; width: auto !i |  Sans Mono', 'Courier New', Courier, |
| mportant; box-sizing: content-box !i |  monospace !important; font-weight:  |
| mportant; font-family: Consolas, 'Bi | normal !important; font-style: norma |
| tstream Vera Sans Mono', 'Courier Ne | l !important; font-size: 1em !import |
| w', Courier, monospace !important; f | ant; min-height: auto !important; ba |
| ont-weight: normal !important; font- | ckground: none !important;">         |
| style: normal !important; font-size: |                                      |
|  1em !important; min-height: auto !i | <div                                 |
| mportant; white-space: pre !importan | style="margin: 0px !important; paddi |
| t; background: none rgb(248, 248, 24 | ng: 0px 1em !important; border-radiu |
| 8) !important;">                     | s: 0px !important; border: 0px !impo |
|                                      | rtant; bottom: auto !important; floa |
| 1                                    | t: none !important; height: auto !im |
|                                      | portant; left: auto !important; outl |
| </div>                               | ine: 0px !important; overflow: visib |
|                                      | le !important; position: static !imp |
| <div                                 | ortant; right: auto !important; text |
| style="margin: 0px !important; paddi | -align: left !important; top: auto ! |
| ng: 0px 0.5em 0px 1em !important; bo | important; vertical-align: baseline  |
| rder-radius: 0px !important; border- | !important; width: auto !important;  |
| width: 0px 3px 0px 0px !important; b | box-sizing: content-box !important;  |
| order-right-style: solid !important; | font-family: Consolas, 'Bitstream Ve |
|  border-right-color: rgb(108, 226, 1 | ra Sans Mono', 'Courier New', Courie |
| 08) !important; bottom: auto !import | r, monospace !important; font-weight |
| ant; float: none !important; height: | : normal !important; font-style: nor |
|  auto !important; left: auto !import | mal !important; font-size: 1em !impo |
| ant; outline: 0px !important; overfl | rtant; min-height: auto !important;  |
| ow: visible !important; position: st | white-space: pre !important; backgro |
| atic !important; right: auto !import | und: none rgb(248, 248, 248) !import |
| ant; text-align: right !important; t | ant;">                               |
| op: auto !important; vertical-align: |                                      |
|  baseline !important; width: auto !i | `using`{style="margin: 0px !importan |
| mportant; box-sizing: content-box !i | t; padding: 0px !important; white-sp |
| mportant; font-family: Consolas, 'Bi | ace: nowrap; border: 0px !important; |
| tstream Vera Sans Mono', 'Courier Ne |  border-radius: 0px !important; bott |
| w', Courier, monospace !important; f | om: auto !important; float: none !im |
| ont-weight: normal !important; font- | portant; height: auto !important; le |
| style: normal !important; font-size: | ft: auto !important; outline: 0px !i |
|  1em !important; min-height: auto !i | mportant; overflow: visible !importa |
| mportant; white-space: pre !importan | nt; position: static !important; rig |
| t; background: none rgb(255, 255, 25 | ht: auto !important; text-align: lef |
| 5) !important;">                     | t !important; top: auto !important;  |
|                                      | vertical-align: baseline !important; |
| 2                                    |  width: auto !important; box-sizing: |
|                                      |  content-box !important; font-family |
| </div>                               | : Consolas, 'Bitstream Vera Sans Mon |
|                                      | o', 'Courier New', Courier, monospac |
| <div                                 | e !important; font-weight: bold !imp |
| style="margin: 0px !important; paddi | ortant; font-style: normal !importan |
| ng: 0px 0.5em 0px 1em !important; bo | t; font-size: 1em !important; min-he |
| rder-radius: 0px !important; border- | ight: auto !important; color: rgb(0, |
| width: 0px 3px 0px 0px !important; b |  102, 153) !important; background: n |
| order-right-style: solid !important; | one !important;"}                    |
|  border-right-color: rgb(108, 226, 1 | `System;`{style="margin: 0px !import |
| 08) !important; bottom: auto !import | ant; padding: 0px !important; white- |
| ant; float: none !important; height: | space: nowrap; border: 0px !importan |
|  auto !important; left: auto !import | t; border-radius: 0px !important; bo |
| ant; outline: 0px !important; overfl | ttom: auto !important; float: none ! |
| ow: visible !important; position: st | important; height: auto !important;  |
| atic !important; right: auto !import | left: auto !important; outline: 0px  |
| ant; text-align: right !important; t | !important; overflow: visible !impor |
| op: auto !important; vertical-align: | tant; position: static !important; r |
|  baseline !important; width: auto !i | ight: auto !important; text-align: l |
| mportant; box-sizing: content-box !i | eft !important; top: auto !important |
| mportant; font-family: Consolas, 'Bi | ; vertical-align: baseline !importan |
| tstream Vera Sans Mono', 'Courier Ne | t; width: auto !important; box-sizin |
| w', Courier, monospace !important; f | g: content-box !important; font-fami |
| ont-weight: normal !important; font- | ly: Consolas, 'Bitstream Vera Sans M |
| style: normal !important; font-size: | ono', 'Courier New', Courier, monosp |
|  1em !important; min-height: auto !i | ace !important; font-weight: normal  |
| mportant; white-space: pre !importan | !important; font-style: normal !impo |
| t; background: none rgb(248, 248, 24 | rtant; font-size: 1em !important; mi |
| 8) !important;">                     | n-height: auto !important; color: rg |
|                                      | b(0, 0, 0) !important; background: n |
| 3                                    | one !important;"}                    |
|                                      |                                      |
| </div>                               | </div>                               |
|                                      |                                      |
| <div                                 | <div                                 |
| style="margin: 0px !important; paddi | style="margin: 0px !important; paddi |
| ng: 0px 0.5em 0px 1em !important; bo | ng: 0px 1em !important; border-radiu |
| rder-radius: 0px !important; border- | s: 0px !important; border: 0px !impo |
| width: 0px 3px 0px 0px !important; b | rtant; bottom: auto !important; floa |
| order-right-style: solid !important; | t: none !important; height: auto !im |
|  border-right-color: rgb(108, 226, 1 | portant; left: auto !important; outl |
| 08) !important; bottom: auto !import | ine: 0px !important; overflow: visib |
| ant; float: none !important; height: | le !important; position: static !imp |
|  auto !important; left: auto !import | ortant; right: auto !important; text |
| ant; outline: 0px !important; overfl | -align: left !important; top: auto ! |
| ow: visible !important; position: st | important; vertical-align: baseline  |
| atic !important; right: auto !import | !important; width: auto !important;  |
| ant; text-align: right !important; t | box-sizing: content-box !important;  |
| op: auto !important; vertical-align: | font-family: Consolas, 'Bitstream Ve |
|  baseline !important; width: auto !i | ra Sans Mono', 'Courier New', Courie |
| mportant; box-sizing: content-box !i | r, monospace !important; font-weight |
| mportant; font-family: Consolas, 'Bi | : normal !important; font-style: nor |
| tstream Vera Sans Mono', 'Courier Ne | mal !important; font-size: 1em !impo |
| w', Courier, monospace !important; f | rtant; min-height: auto !important;  |
| ont-weight: normal !important; font- | white-space: pre !important; backgro |
| style: normal !important; font-size: | und: none rgb(255, 255, 255) !import |
|  1em !important; min-height: auto !i | ant;">                               |
| mportant; white-space: pre !importan |                                      |
| t; background: none rgb(255, 255, 25 | `using`{style="margin: 0px !importan |
| 5) !important;">                     | t; padding: 0px !important; white-sp |
|                                      | ace: nowrap; border: 0px !important; |
| 4                                    |  border-radius: 0px !important; bott |
|                                      | om: auto !important; float: none !im |
| </div>                               | portant; height: auto !important; le |
|                                      | ft: auto !important; outline: 0px !i |
| <div                                 | mportant; overflow: visible !importa |
| style="margin: 0px !important; paddi | nt; position: static !important; rig |
| ng: 0px 0.5em 0px 1em !important; bo | ht: auto !important; text-align: lef |
| rder-radius: 0px !important; border- | t !important; top: auto !important;  |
| width: 0px 3px 0px 0px !important; b | vertical-align: baseline !important; |
| order-right-style: solid !important; |  width: auto !important; box-sizing: |
|  border-right-color: rgb(108, 226, 1 |  content-box !important; font-family |
| 08) !important; bottom: auto !import | : Consolas, 'Bitstream Vera Sans Mon |
| ant; float: none !important; height: | o', 'Courier New', Courier, monospac |
|  auto !important; left: auto !import | e !important; font-weight: bold !imp |
| ant; outline: 0px !important; overfl | ortant; font-style: normal !importan |
| ow: visible !important; position: st | t; font-size: 1em !important; min-he |
| atic !important; right: auto !import | ight: auto !important; color: rgb(0, |
| ant; text-align: right !important; t |  102, 153) !important; background: n |
| op: auto !important; vertical-align: | one !important;"}                    |
|  baseline !important; width: auto !i | `System.IO;`{style="margin: 0px !imp |
| mportant; box-sizing: content-box !i | ortant; padding: 0px !important; whi |
| mportant; font-family: Consolas, 'Bi | te-space: nowrap; border: 0px !impor |
| tstream Vera Sans Mono', 'Courier Ne | tant; border-radius: 0px !important; |
| w', Courier, monospace !important; f |  bottom: auto !important; float: non |
| ont-weight: normal !important; font- | e !important; height: auto !importan |
| style: normal !important; font-size: | t; left: auto !important; outline: 0 |
|  1em !important; min-height: auto !i | px !important; overflow: visible !im |
| mportant; white-space: pre !importan | portant; position: static !important |
| t; background: none rgb(248, 248, 24 | ; right: auto !important; text-align |
| 8) !important;">                     | : left !important; top: auto !import |
|                                      | ant; vertical-align: baseline !impor |
| 5                                    | tant; width: auto !important; box-si |
|                                      | zing: content-box !important; font-f |
| </div>                               | amily: Consolas, 'Bitstream Vera San |
|                                      | s Mono', 'Courier New', Courier, mon |
| <div                                 | ospace !important; font-weight: norm |
| style="margin: 0px !important; paddi | al !important; font-style: normal !i |
| ng: 0px 0.5em 0px 1em !important; bo | mportant; font-size: 1em !important; |
| rder-radius: 0px !important; border- |  min-height: auto !important; color: |
| width: 0px 3px 0px 0px !important; b |  rgb(0, 0, 0) !important; background |
| order-right-style: solid !important; | : none !important;"}                 |
|  border-right-color: rgb(108, 226, 1 |                                      |
| 08) !important; bottom: auto !import | </div>                               |
| ant; float: none !important; height: |                                      |
|  auto !important; left: auto !import | <div                                 |
| ant; outline: 0px !important; overfl | style="margin: 0px !important; paddi |
| ow: visible !important; position: st | ng: 0px 1em !important; border-radiu |
| atic !important; right: auto !import | s: 0px !important; border: 0px !impo |
| ant; text-align: right !important; t | rtant; bottom: auto !important; floa |
| op: auto !important; vertical-align: | t: none !important; height: auto !im |
|  baseline !important; width: auto !i | portant; left: auto !important; outl |
| mportant; box-sizing: content-box !i | ine: 0px !important; overflow: visib |
| mportant; font-family: Consolas, 'Bi | le !important; position: static !imp |
| tstream Vera Sans Mono', 'Courier Ne | ortant; right: auto !important; text |
| w', Courier, monospace !important; f | -align: left !important; top: auto ! |
| ont-weight: normal !important; font- | important; vertical-align: baseline  |
| style: normal !important; font-size: | !important; width: auto !important;  |
|  1em !important; min-height: auto !i | box-sizing: content-box !important;  |
| mportant; white-space: pre !importan | font-family: Consolas, 'Bitstream Ve |
| t; background: none rgb(255, 255, 25 | ra Sans Mono', 'Courier New', Courie |
| 5) !important;">                     | r, monospace !important; font-weight |
|                                      | : normal !important; font-style: nor |
| 6                                    | mal !important; font-size: 1em !impo |
|                                      | rtant; min-height: auto !important;  |
| </div>                               | white-space: pre !important; backgro |
|                                      | und: none rgb(248, 248, 248) !import |
| <div                                 | ant;">                               |
| style="margin: 0px !important; paddi |                                      |
| ng: 0px 0.5em 0px 1em !important; bo | `using`{style="margin: 0px !importan |
| rder-radius: 0px !important; border- | t; padding: 0px !important; white-sp |
| width: 0px 3px 0px 0px !important; b | ace: nowrap; border: 0px !important; |
| order-right-style: solid !important; |  border-radius: 0px !important; bott |
|  border-right-color: rgb(108, 226, 1 | om: auto !important; float: none !im |
| 08) !important; bottom: auto !import | portant; height: auto !important; le |
| ant; float: none !important; height: | ft: auto !important; outline: 0px !i |
|  auto !important; left: auto !import | mportant; overflow: visible !importa |
| ant; outline: 0px !important; overfl | nt; position: static !important; rig |
| ow: visible !important; position: st | ht: auto !important; text-align: lef |
| atic !important; right: auto !import | t !important; top: auto !important;  |
| ant; text-align: right !important; t | vertical-align: baseline !important; |
| op: auto !important; vertical-align: |  width: auto !important; box-sizing: |
|  baseline !important; width: auto !i |  content-box !important; font-family |
| mportant; box-sizing: content-box !i | : Consolas, 'Bitstream Vera Sans Mon |
| mportant; font-family: Consolas, 'Bi | o', 'Courier New', Courier, monospac |
| tstream Vera Sans Mono', 'Courier Ne | e !important; font-weight: bold !imp |
| w', Courier, monospace !important; f | ortant; font-style: normal !importan |
| ont-weight: normal !important; font- | t; font-size: 1em !important; min-he |
| style: normal !important; font-size: | ight: auto !important; color: rgb(0, |
|  1em !important; min-height: auto !i |  102, 153) !important; background: n |
| mportant; white-space: pre !importan | one !important;"}                    |
| t; background: none rgb(248, 248, 24 | `System.Runtime.Serialization;`{styl |
| 8) !important;">                     | e="margin: 0px !important; padding:  |
|                                      | 0px !important; white-space: nowrap; |
| 7                                    |  border: 0px !important; border-radi |
|                                      | us: 0px !important; bottom: auto !im |
| </div>                               | portant; float: none !important; hei |
|                                      | ght: auto !important; left: auto !im |
| <div                                 | portant; outline: 0px !important; ov |
| style="margin: 0px !important; paddi | erflow: visible !important; position |
| ng: 0px 0.5em 0px 1em !important; bo | : static !important; right: auto !im |
| rder-radius: 0px !important; border- | portant; text-align: left !important |
| width: 0px 3px 0px 0px !important; b | ; top: auto !important; vertical-ali |
| order-right-style: solid !important; | gn: baseline !important; width: auto |
|  border-right-color: rgb(108, 226, 1 |  !important; box-sizing: content-box |
| 08) !important; bottom: auto !import |  !important; font-family: Consolas,  |
| ant; float: none !important; height: | 'Bitstream Vera Sans Mono', 'Courier |
|  auto !important; left: auto !import |  New', Courier, monospace !important |
| ant; outline: 0px !important; overfl | ; font-weight: normal !important; fo |
| ow: visible !important; position: st | nt-style: normal !important; font-si |
| atic !important; right: auto !import | ze: 1em !important; min-height: auto |
| ant; text-align: right !important; t |  !important; color: rgb(0, 0, 0) !im |
| op: auto !important; vertical-align: | portant; background: none !important |
|  baseline !important; width: auto !i | ;"}                                  |
| mportant; box-sizing: content-box !i |                                      |
| mportant; font-family: Consolas, 'Bi | </div>                               |
| tstream Vera Sans Mono', 'Courier Ne |                                      |
| w', Courier, monospace !important; f | <div                                 |
| ont-weight: normal !important; font- | style="margin: 0px !important; paddi |
| style: normal !important; font-size: | ng: 0px 1em !important; border-radiu |
|  1em !important; min-height: auto !i | s: 0px !important; border: 0px !impo |
| mportant; white-space: pre !importan | rtant; bottom: auto !important; floa |
| t; background: none rgb(255, 255, 25 | t: none !important; height: auto !im |
| 5) !important;">                     | portant; left: auto !important; outl |
|                                      | ine: 0px !important; overflow: visib |
| 8                                    | le !important; position: static !imp |
|                                      | ortant; right: auto !important; text |
| </div>                               | -align: left !important; top: auto ! |
|                                      | important; vertical-align: baseline  |
| <div                                 | !important; width: auto !important;  |
| style="margin: 0px !important; paddi | box-sizing: content-box !important;  |
| ng: 0px 0.5em 0px 1em !important; bo | font-family: Consolas, 'Bitstream Ve |
| rder-radius: 0px !important; border- | ra Sans Mono', 'Courier New', Courie |
| width: 0px 3px 0px 0px !important; b | r, monospace !important; font-weight |
| order-right-style: solid !important; | : normal !important; font-style: nor |
|  border-right-color: rgb(108, 226, 1 | mal !important; font-size: 1em !impo |
| 08) !important; bottom: auto !import | rtant; min-height: auto !important;  |
| ant; float: none !important; height: | white-space: pre !important; backgro |
|  auto !important; left: auto !import | und: none rgb(255, 255, 255) !import |
| ant; outline: 0px !important; overfl | ant;">                               |
| ow: visible !important; position: st |                                      |
| atic !important; right: auto !import | `using`{style="margin: 0px !importan |
| ant; text-align: right !important; t | t; padding: 0px !important; white-sp |
| op: auto !important; vertical-align: | ace: nowrap; border: 0px !important; |
|  baseline !important; width: auto !i |  border-radius: 0px !important; bott |
| mportant; box-sizing: content-box !i | om: auto !important; float: none !im |
| mportant; font-family: Consolas, 'Bi | portant; height: auto !important; le |
| tstream Vera Sans Mono', 'Courier Ne | ft: auto !important; outline: 0px !i |
| w', Courier, monospace !important; f | mportant; overflow: visible !importa |
| ont-weight: normal !important; font- | nt; position: static !important; rig |
| style: normal !important; font-size: | ht: auto !important; text-align: lef |
|  1em !important; min-height: auto !i | t !important; top: auto !important;  |
| mportant; white-space: pre !importan | vertical-align: baseline !important; |
| t; background: none rgb(248, 248, 24 |  width: auto !important; box-sizing: |
| 8) !important;">                     |  content-box !important; font-family |
|                                      | : Consolas, 'Bitstream Vera Sans Mon |
| 9                                    | o', 'Courier New', Courier, monospac |
|                                      | e !important; font-weight: bold !imp |
| </div>                               | ortant; font-style: normal !importan |
|                                      | t; font-size: 1em !important; min-he |
| <div                                 | ight: auto !important; color: rgb(0, |
| style="margin: 0px !important; paddi |  102, 153) !important; background: n |
| ng: 0px 0.5em 0px 1em !important; bo | one !important;"}                    |
| rder-radius: 0px !important; border- | `System.Runtime.Serialization.Format |
| width: 0px 3px 0px 0px !important; b | ters.Soap ;`{style="margin: 0px !imp |
| order-right-style: solid !important; | ortant; padding: 0px !important; whi |
|  border-right-color: rgb(108, 226, 1 | te-space: nowrap; border: 0px !impor |
| 08) !important; bottom: auto !import | tant; border-radius: 0px !important; |
| ant; float: none !important; height: |  bottom: auto !important; float: non |
|  auto !important; left: auto !import | e !important; height: auto !importan |
| ant; outline: 0px !important; overfl | t; left: auto !important; outline: 0 |
| ow: visible !important; position: st | px !important; overflow: visible !im |
| atic !important; right: auto !import | portant; position: static !important |
| ant; text-align: right !important; t | ; right: auto !important; text-align |
| op: auto !important; vertical-align: | : left !important; top: auto !import |
|  baseline !important; width: auto !i | ant; vertical-align: baseline !impor |
| mportant; box-sizing: content-box !i | tant; width: auto !important; box-si |
| mportant; font-family: Consolas, 'Bi | zing: content-box !important; font-f |
| tstream Vera Sans Mono', 'Courier Ne | amily: Consolas, 'Bitstream Vera San |
| w', Courier, monospace !important; f | s Mono', 'Courier New', Courier, mon |
| ont-weight: normal !important; font- | ospace !important; font-weight: norm |
| style: normal !important; font-size: | al !important; font-style: normal !i |
|  1em !important; min-height: auto !i | mportant; font-size: 1em !important; |
| mportant; white-space: pre !importan |  min-height: auto !important; color: |
| t; background: none rgb(255, 255, 25 |  rgb(0, 0, 0) !important; background |
| 5) !important;">                     | : none !important;"}                 |
|                                      |                                      |
| 10                                   | </div>                               |
|                                      |                                      |
| </div>                               | <div                                 |
|                                      | style="margin: 0px !important; paddi |
| <div                                 | ng: 0px 1em !important; border-radiu |
| style="margin: 0px !important; paddi | s: 0px !important; border: 0px !impo |
| ng: 0px 0.5em 0px 1em !important; bo | rtant; bottom: auto !important; floa |
| rder-radius: 0px !important; border- | t: none !important; height: auto !im |
| width: 0px 3px 0px 0px !important; b | portant; left: auto !important; outl |
| order-right-style: solid !important; | ine: 0px !important; overflow: visib |
|  border-right-color: rgb(108, 226, 1 | le !important; position: static !imp |
| 08) !important; bottom: auto !import | ortant; right: auto !important; text |
| ant; float: none !important; height: | -align: left !important; top: auto ! |
|  auto !important; left: auto !import | important; vertical-align: baseline  |
| ant; outline: 0px !important; overfl | !important; width: auto !important;  |
| ow: visible !important; position: st | box-sizing: content-box !important;  |
| atic !important; right: auto !import | font-family: Consolas, 'Bitstream Ve |
| ant; text-align: right !important; t | ra Sans Mono', 'Courier New', Courie |
| op: auto !important; vertical-align: | r, monospace !important; font-weight |
|  baseline !important; width: auto !i | : normal !important; font-style: nor |
| mportant; box-sizing: content-box !i | mal !important; font-size: 1em !impo |
| mportant; font-family: Consolas, 'Bi | rtant; min-height: auto !important;  |
| tstream Vera Sans Mono', 'Courier Ne | white-space: pre !important; backgro |
| w', Courier, monospace !important; f | und: none rgb(248, 248, 248) !import |
| ont-weight: normal !important; font- | ant;">                               |
| style: normal !important; font-size: |                                      |
|  1em !important; min-height: auto !i |                                      |
| mportant; white-space: pre !importan |                                      |
| t; background: none rgb(248, 248, 24 | </div>                               |
| 8) !important;">                     |                                      |
|                                      | <div                                 |
| 11                                   | style="margin: 0px !important; paddi |
|                                      | ng: 0px 1em !important; border-radiu |
| </div>                               | s: 0px !important; border: 0px !impo |
|                                      | rtant; bottom: auto !important; floa |
| <div                                 | t: none !important; height: auto !im |
| style="margin: 0px !important; paddi | portant; left: auto !important; outl |
| ng: 0px 0.5em 0px 1em !important; bo | ine: 0px !important; overflow: visib |
| rder-radius: 0px !important; border- | le !important; position: static !imp |
| width: 0px 3px 0px 0px !important; b | ortant; right: auto !important; text |
| order-right-style: solid !important; | -align: left !important; top: auto ! |
|  border-right-color: rgb(108, 226, 1 | important; vertical-align: baseline  |
| 08) !important; bottom: auto !import | !important; width: auto !important;  |
| ant; float: none !important; height: | box-sizing: content-box !important;  |
|  auto !important; left: auto !import | font-family: Consolas, 'Bitstream Ve |
| ant; outline: 0px !important; overfl | ra Sans Mono', 'Courier New', Courie |
| ow: visible !important; position: st | r, monospace !important; font-weight |
| atic !important; right: auto !import | : normal !important; font-style: nor |
| ant; text-align: right !important; t | mal !important; font-size: 1em !impo |
| op: auto !important; vertical-align: | rtant; min-height: auto !important;  |
|  baseline !important; width: auto !i | white-space: pre !important; backgro |
| mportant; box-sizing: content-box !i | und: none rgb(255, 255, 255) !import |
| mportant; font-family: Consolas, 'Bi | ant;">                               |
| tstream Vera Sans Mono', 'Courier Ne |                                      |
| w', Courier, monospace !important; f | `namespace`{style="margin: 0px !impo |
| ont-weight: normal !important; font- | rtant; padding: 0px !important; whit |
| style: normal !important; font-size: | e-space: nowrap; border: 0px !import |
|  1em !important; min-height: auto !i | ant; border-radius: 0px !important;  |
| mportant; white-space: pre !importan | bottom: auto !important; float: none |
| t; background: none rgb(255, 255, 25 |  !important; height: auto !important |
| 5) !important;">                     | ; left: auto !important; outline: 0p |
|                                      | x !important; overflow: visible !imp |
| 12                                   | ortant; position: static !important; |
|                                      |  right: auto !important; text-align: |
| </div>                               |  left !important; top: auto !importa |
|                                      | nt; vertical-align: baseline !import |
| <div                                 | ant; width: auto !important; box-siz |
| style="margin: 0px !important; paddi | ing: content-box !important; font-fa |
| ng: 0px 0.5em 0px 1em !important; bo | mily: Consolas, 'Bitstream Vera Sans |
| rder-radius: 0px !important; border- |  Mono', 'Courier New', Courier, mono |
| width: 0px 3px 0px 0px !important; b | space !important; font-weight: bold  |
| order-right-style: solid !important; | !important; font-style: normal !impo |
|  border-right-color: rgb(108, 226, 1 | rtant; font-size: 1em !important; mi |
| 08) !important; bottom: auto !import | n-height: auto !important; color: rg |
| ant; float: none !important; height: | b(0, 102, 153) !important; backgroun |
|  auto !important; left: auto !import | d: none !important;"}                |
| ant; outline: 0px !important; overfl | `SerializationTest`{style="margin: 0 |
| ow: visible !important; position: st | px !important; padding: 0px !importa |
| atic !important; right: auto !import | nt; white-space: nowrap; border: 0px |
| ant; text-align: right !important; t |  !important; border-radius: 0px !imp |
| op: auto !important; vertical-align: | ortant; bottom: auto !important; flo |
|  baseline !important; width: auto !i | at: none !important; height: auto !i |
| mportant; box-sizing: content-box !i | mportant; left: auto !important; out |
| mportant; font-family: Consolas, 'Bi | line: 0px !important; overflow: visi |
| tstream Vera Sans Mono', 'Courier Ne | ble !important; position: static !im |
| w', Courier, monospace !important; f | portant; right: auto !important; tex |
| ont-weight: normal !important; font- | t-align: left !important; top: auto  |
| style: normal !important; font-size: | !important; vertical-align: baseline |
|  1em !important; min-height: auto !i |  !important; width: auto !important; |
| mportant; white-space: pre !importan |  box-sizing: content-box !important; |
| t; background: none rgb(248, 248, 24 |  font-family: Consolas, 'Bitstream V |
| 8) !important;">                     | era Sans Mono', 'Courier New', Couri |
|                                      | er, monospace !important; font-weigh |
| 13                                   | t: normal !important; font-style: no |
|                                      | rmal !important; font-size: 1em !imp |
| </div>                               | ortant; min-height: auto !important; |
|                                      |  color: rgb(0, 0, 0) !important; bac |
| <div                                 | kground: none !important;"}          |
| style="margin: 0px !important; paddi |                                      |
| ng: 0px 0.5em 0px 1em !important; bo | </div>                               |
| rder-radius: 0px !important; border- |                                      |
| width: 0px 3px 0px 0px !important; b | <div                                 |
| order-right-style: solid !important; | style="margin: 0px !important; paddi |
|  border-right-color: rgb(108, 226, 1 | ng: 0px 1em !important; border-radiu |
| 08) !important; bottom: auto !import | s: 0px !important; border: 0px !impo |
| ant; float: none !important; height: | rtant; bottom: auto !important; floa |
|  auto !important; left: auto !import | t: none !important; height: auto !im |
| ant; outline: 0px !important; overfl | portant; left: auto !important; outl |
| ow: visible !important; position: st | ine: 0px !important; overflow: visib |
| atic !important; right: auto !import | le !important; position: static !imp |
| ant; text-align: right !important; t | ortant; right: auto !important; text |
| op: auto !important; vertical-align: | -align: left !important; top: auto ! |
|  baseline !important; width: auto !i | important; vertical-align: baseline  |
| mportant; box-sizing: content-box !i | !important; width: auto !important;  |
| mportant; font-family: Consolas, 'Bi | box-sizing: content-box !important;  |
| tstream Vera Sans Mono', 'Courier Ne | font-family: Consolas, 'Bitstream Ve |
| w', Courier, monospace !important; f | ra Sans Mono', 'Courier New', Courie |
| ont-weight: normal !important; font- | r, monospace !important; font-weight |
| style: normal !important; font-size: | : normal !important; font-style: nor |
|  1em !important; min-height: auto !i | mal !important; font-size: 1em !impo |
| mportant; white-space: pre !importan | rtant; min-height: auto !important;  |
| t; background: none rgb(255, 255, 25 | white-space: pre !important; backgro |
| 5) !important;">                     | und: none rgb(248, 248, 248) !import |
|                                      | ant;">                               |
| 14                                   |                                      |
|                                      | ` `{style="margin: 0px !important; p |
| </div>                               | adding: 0px !important; white-space: |
|                                      |  nowrap; border: 0px !important; bor |
| <div                                 | der-radius: 0px !important; bottom:  |
| style="margin: 0px !important; paddi | auto !important; float: none !import |
| ng: 0px 0.5em 0px 1em !important; bo | ant; height: auto !important; left:  |
| rder-radius: 0px !important; border- | auto !important; outline: 0px !impor |
| width: 0px 3px 0px 0px !important; b | tant; overflow: visible !important;  |
| order-right-style: solid !important; | position: static !important; right:  |
|  border-right-color: rgb(108, 226, 1 | auto !important; text-align: left !i |
| 08) !important; bottom: auto !import | mportant; top: auto !important; vert |
| ant; float: none !important; height: | ical-align: baseline !important; wid |
|  auto !important; left: auto !import | th: auto !important; box-sizing: con |
| ant; outline: 0px !important; overfl | tent-box !important; font-family: Co |
| ow: visible !important; position: st | nsolas, 'Bitstream Vera Sans Mono',  |
| atic !important; right: auto !import | 'Courier New', Courier, monospace !i |
| ant; text-align: right !important; t | mportant; font-weight: normal !impor |
| op: auto !important; vertical-align: | tant; font-style: normal !important; |
|  baseline !important; width: auto !i |  font-size: 1em !important; min-heig |
| mportant; box-sizing: content-box !i | ht: auto !important; background: non |
| mportant; font-family: Consolas, 'Bi | e !important;"}`{`{style="margin: 0p |
| tstream Vera Sans Mono', 'Courier Ne | x !important; padding: 0px !importan |
| w', Courier, monospace !important; f | t; white-space: nowrap; border: 0px  |
| ont-weight: normal !important; font- | !important; border-radius: 0px !impo |
| style: normal !important; font-size: | rtant; bottom: auto !important; floa |
|  1em !important; min-height: auto !i | t: none !important; height: auto !im |
| mportant; white-space: pre !importan | portant; left: auto !important; outl |
| t; background: none rgb(248, 248, 24 | ine: 0px !important; overflow: visib |
| 8) !important;">                     | le !important; position: static !imp |
|                                      | ortant; right: auto !important; text |
| 15                                   | -align: left !important; top: auto ! |
|                                      | important; vertical-align: baseline  |
| </div>                               | !important; width: auto !important;  |
|                                      | box-sizing: content-box !important;  |
| <div                                 | font-family: Consolas, 'Bitstream Ve |
| style="margin: 0px !important; paddi | ra Sans Mono', 'Courier New', Courie |
| ng: 0px 0.5em 0px 1em !important; bo | r, monospace !important; font-weight |
| rder-radius: 0px !important; border- | : normal !important; font-style: nor |
| width: 0px 3px 0px 0px !important; b | mal !important; font-size: 1em !impo |
| order-right-style: solid !important; | rtant; min-height: auto !important;  |
|  border-right-color: rgb(108, 226, 1 | color: rgb(0, 0, 0) !important; back |
| 08) !important; bottom: auto !import | ground: none !important;"}           |
| ant; float: none !important; height: |                                      |
|  auto !important; left: auto !import | </div>                               |
| ant; outline: 0px !important; overfl |                                      |
| ow: visible !important; position: st | <div                                 |
| atic !important; right: auto !import | style="margin: 0px !important; paddi |
| ant; text-align: right !important; t | ng: 0px 1em !important; border-radiu |
| op: auto !important; vertical-align: | s: 0px !important; border: 0px !impo |
|  baseline !important; width: auto !i | rtant; bottom: auto !important; floa |
| mportant; box-sizing: content-box !i | t: none !important; height: auto !im |
| mportant; font-family: Consolas, 'Bi | portant; left: auto !important; outl |
| tstream Vera Sans Mono', 'Courier Ne | ine: 0px !important; overflow: visib |
| w', Courier, monospace !important; f | le !important; position: static !imp |
| ont-weight: normal !important; font- | ortant; right: auto !important; text |
| style: normal !important; font-size: | -align: left !important; top: auto ! |
|  1em !important; min-height: auto !i | important; vertical-align: baseline  |
| mportant; white-space: pre !importan | !important; width: auto !important;  |
| t; background: none rgb(255, 255, 25 | box-sizing: content-box !important;  |
| 5) !important;">                     | font-family: Consolas, 'Bitstream Ve |
|                                      | ra Sans Mono', 'Courier New', Courie |
| 16                                   | r, monospace !important; font-weight |
|                                      | : normal !important; font-style: nor |
| </div>                               | mal !important; font-size: 1em !impo |
|                                      | rtant; min-height: auto !important;  |
| <div                                 | white-space: pre !important; backgro |
| style="margin: 0px !important; paddi | und: none rgb(255, 255, 255) !import |
| ng: 0px 0.5em 0px 1em !important; bo | ant;">                               |
| rder-radius: 0px !important; border- |                                      |
| width: 0px 3px 0px 0px !important; b | `    `{style="margin: 0px !important |
| order-right-style: solid !important; | ; padding: 0px !important; white-spa |
|  border-right-color: rgb(108, 226, 1 | ce: nowrap; border: 0px !important;  |
| 08) !important; bottom: auto !import | border-radius: 0px !important; botto |
| ant; float: none !important; height: | m: auto !important; float: none !imp |
|  auto !important; left: auto !import | ortant; height: auto !important; lef |
| ant; outline: 0px !important; overfl | t: auto !important; outline: 0px !im |
| ow: visible !important; position: st | portant; overflow: visible !importan |
| atic !important; right: auto !import | t; position: static !important; righ |
| ant; text-align: right !important; t | t: auto !important; text-align: left |
| op: auto !important; vertical-align: |  !important; top: auto !important; v |
|  baseline !important; width: auto !i | ertical-align: baseline !important;  |
| mportant; box-sizing: content-box !i | width: auto !important; box-sizing:  |
| mportant; font-family: Consolas, 'Bi | content-box !important; font-family: |
| tstream Vera Sans Mono', 'Courier Ne |  Consolas, 'Bitstream Vera Sans Mono |
| w', Courier, monospace !important; f | ', 'Courier New', Courier, monospace |
| ont-weight: normal !important; font- |  !important; font-weight: normal !im |
| style: normal !important; font-size: | portant; font-style: normal !importa |
|  1em !important; min-height: auto !i | nt; font-size: 1em !important; min-h |
| mportant; white-space: pre !importan | eight: auto !important; background:  |
| t; background: none rgb(248, 248, 24 | none !important;"}`class`{style="mar |
| 8) !important;">                     | gin: 0px !important; padding: 0px !i |
|                                      | mportant; white-space: nowrap; borde |
| 17                                   | r: 0px !important; border-radius: 0p |
|                                      | x !important; bottom: auto !importan |
| </div>                               | t; float: none !important; height: a |
|                                      | uto !important; left: auto !importan |
| <div                                 | t; outline: 0px !important; overflow |
| style="margin: 0px !important; paddi | : visible !important; position: stat |
| ng: 0px 0.5em 0px 1em !important; bo | ic !important; right: auto !importan |
| rder-radius: 0px !important; border- | t; text-align: left !important; top: |
| width: 0px 3px 0px 0px !important; b |  auto !important; vertical-align: ba |
| order-right-style: solid !important; | seline !important; width: auto !impo |
|  border-right-color: rgb(108, 226, 1 | rtant; box-sizing: content-box !impo |
| 08) !important; bottom: auto !import | rtant; font-family: Consolas, 'Bitst |
| ant; float: none !important; height: | ream Vera Sans Mono', 'Courier New', |
|  auto !important; left: auto !import |  Courier, monospace !important; font |
| ant; outline: 0px !important; overfl | -weight: bold !important; font-style |
| ow: visible !important; position: st | : normal !important; font-size: 1em  |
| atic !important; right: auto !import | !important; min-height: auto !import |
| ant; text-align: right !important; t | ant; color: rgb(0, 102, 153) !import |
| op: auto !important; vertical-align: | ant; background: none !important;"}  |
|  baseline !important; width: auto !i | `Program`{style="margin: 0px !import |
| mportant; box-sizing: content-box !i | ant; padding: 0px !important; white- |
| mportant; font-family: Consolas, 'Bi | space: nowrap; border: 0px !importan |
| tstream Vera Sans Mono', 'Courier Ne | t; border-radius: 0px !important; bo |
| w', Courier, monospace !important; f | ttom: auto !important; float: none ! |
| ont-weight: normal !important; font- | important; height: auto !important;  |
| style: normal !important; font-size: | left: auto !important; outline: 0px  |
|  1em !important; min-height: auto !i | !important; overflow: visible !impor |
| mportant; white-space: pre !importan | tant; position: static !important; r |
| t; background: none rgb(255, 255, 25 | ight: auto !important; text-align: l |
| 5) !important;">                     | eft !important; top: auto !important |
|                                      | ; vertical-align: baseline !importan |
| 18                                   | t; width: auto !important; box-sizin |
|                                      | g: content-box !important; font-fami |
| </div>                               | ly: Consolas, 'Bitstream Vera Sans M |
|                                      | ono', 'Courier New', Courier, monosp |
| <div                                 | ace !important; font-weight: normal  |
| style="margin: 0px !important; paddi | !important; font-style: normal !impo |
| ng: 0px 0.5em 0px 1em !important; bo | rtant; font-size: 1em !important; mi |
| rder-radius: 0px !important; border- | n-height: auto !important; color: rg |
| width: 0px 3px 0px 0px !important; b | b(0, 0, 0) !important; background: n |
| order-right-style: solid !important; | one !important;"}                    |
|  border-right-color: rgb(108, 226, 1 |                                      |
| 08) !important; bottom: auto !import | </div>                               |
| ant; float: none !important; height: |                                      |
|  auto !important; left: auto !import | <div                                 |
| ant; outline: 0px !important; overfl | style="margin: 0px !important; paddi |
| ow: visible !important; position: st | ng: 0px 1em !important; border-radiu |
| atic !important; right: auto !import | s: 0px !important; border: 0px !impo |
| ant; text-align: right !important; t | rtant; bottom: auto !important; floa |
| op: auto !important; vertical-align: | t: none !important; height: auto !im |
|  baseline !important; width: auto !i | portant; left: auto !important; outl |
| mportant; box-sizing: content-box !i | ine: 0px !important; overflow: visib |
| mportant; font-family: Consolas, 'Bi | le !important; position: static !imp |
| tstream Vera Sans Mono', 'Courier Ne | ortant; right: auto !important; text |
| w', Courier, monospace !important; f | -align: left !important; top: auto ! |
| ont-weight: normal !important; font- | important; vertical-align: baseline  |
| style: normal !important; font-size: | !important; width: auto !important;  |
|  1em !important; min-height: auto !i | box-sizing: content-box !important;  |
| mportant; white-space: pre !importan | font-family: Consolas, 'Bitstream Ve |
| t; background: none rgb(248, 248, 24 | ra Sans Mono', 'Courier New', Courie |
| 8) !important;">                     | r, monospace !important; font-weight |
|                                      | : normal !important; font-style: nor |
| 19                                   | mal !important; font-size: 1em !impo |
|                                      | rtant; min-height: auto !important;  |
| </div>                               | white-space: pre !important; backgro |
|                                      | und: none rgb(248, 248, 248) !import |
| <div                                 | ant;">                               |
| style="margin: 0px !important; paddi |                                      |
| ng: 0px 0.5em 0px 1em !important; bo | `    `{style="margin: 0px !important |
| rder-radius: 0px !important; border- | ; padding: 0px !important; white-spa |
| width: 0px 3px 0px 0px !important; b | ce: nowrap; border: 0px !important;  |
| order-right-style: solid !important; | border-radius: 0px !important; botto |
|  border-right-color: rgb(108, 226, 1 | m: auto !important; float: none !imp |
| 08) !important; bottom: auto !import | ortant; height: auto !important; lef |
| ant; float: none !important; height: | t: auto !important; outline: 0px !im |
|  auto !important; left: auto !import | portant; overflow: visible !importan |
| ant; outline: 0px !important; overfl | t; position: static !important; righ |
| ow: visible !important; position: st | t: auto !important; text-align: left |
| atic !important; right: auto !import |  !important; top: auto !important; v |
| ant; text-align: right !important; t | ertical-align: baseline !important;  |
| op: auto !important; vertical-align: | width: auto !important; box-sizing:  |
|  baseline !important; width: auto !i | content-box !important; font-family: |
| mportant; box-sizing: content-box !i |  Consolas, 'Bitstream Vera Sans Mono |
| mportant; font-family: Consolas, 'Bi | ', 'Courier New', Courier, monospace |
| tstream Vera Sans Mono', 'Courier Ne |  !important; font-weight: normal !im |
| w', Courier, monospace !important; f | portant; font-style: normal !importa |
| ont-weight: normal !important; font- | nt; font-size: 1em !important; min-h |
| style: normal !important; font-size: | eight: auto !important; background:  |
|  1em !important; min-height: auto !i | none !important;"}`{`{style="margin: |
| mportant; white-space: pre !importan |  0px !important; padding: 0px !impor |
| t; background: none rgb(255, 255, 25 | tant; white-space: nowrap; border: 0 |
| 5) !important;">                     | px !important; border-radius: 0px !i |
|                                      | mportant; bottom: auto !important; f |
| 20                                   | loat: none !important; height: auto  |
|                                      | !important; left: auto !important; o |
| </div>                               | utline: 0px !important; overflow: vi |
|                                      | sible !important; position: static ! |
| <div                                 | important; right: auto !important; t |
| style="margin: 0px !important; paddi | ext-align: left !important; top: aut |
| ng: 0px 0.5em 0px 1em !important; bo | o !important; vertical-align: baseli |
| rder-radius: 0px !important; border- | ne !important; width: auto !importan |
| width: 0px 3px 0px 0px !important; b | t; box-sizing: content-box !importan |
| order-right-style: solid !important; | t; font-family: Consolas, 'Bitstream |
|  border-right-color: rgb(108, 226, 1 |  Vera Sans Mono', 'Courier New', Cou |
| 08) !important; bottom: auto !import | rier, monospace !important; font-wei |
| ant; float: none !important; height: | ght: normal !important; font-style:  |
|  auto !important; left: auto !import | normal !important; font-size: 1em !i |
| ant; outline: 0px !important; overfl | mportant; min-height: auto !importan |
| ow: visible !important; position: st | t; color: rgb(0, 0, 0) !important; b |
| atic !important; right: auto !import | ackground: none !important;"}        |
| ant; text-align: right !important; t |                                      |
| op: auto !important; vertical-align: | </div>                               |
|  baseline !important; width: auto !i |                                      |
| mportant; box-sizing: content-box !i | <div                                 |
| mportant; font-family: Consolas, 'Bi | style="margin: 0px !important; paddi |
| tstream Vera Sans Mono', 'Courier Ne | ng: 0px 1em !important; border-radiu |
| w', Courier, monospace !important; f | s: 0px !important; border: 0px !impo |
| ont-weight: normal !important; font- | rtant; bottom: auto !important; floa |
| style: normal !important; font-size: | t: none !important; height: auto !im |
|  1em !important; min-height: auto !i | portant; left: auto !important; outl |
| mportant; white-space: pre !importan | ine: 0px !important; overflow: visib |
| t; background: none rgb(248, 248, 24 | le !important; position: static !imp |
| 8) !important;">                     | ortant; right: auto !important; text |
|                                      | -align: left !important; top: auto ! |
| 21                                   | important; vertical-align: baseline  |
|                                      | !important; width: auto !important;  |
| </div>                               | box-sizing: content-box !important;  |
|                                      | font-family: Consolas, 'Bitstream Ve |
| <div                                 | ra Sans Mono', 'Courier New', Courie |
| style="margin: 0px !important; paddi | r, monospace !important; font-weight |
| ng: 0px 0.5em 0px 1em !important; bo | : normal !important; font-style: nor |
| rder-radius: 0px !important; border- | mal !important; font-size: 1em !impo |
| width: 0px 3px 0px 0px !important; b | rtant; min-height: auto !important;  |
| order-right-style: solid !important; | white-space: pre !important; backgro |
|  border-right-color: rgb(108, 226, 1 | und: none rgb(255, 255, 255) !import |
| 08) !important; bottom: auto !import | ant;">                               |
| ant; float: none !important; height: |                                      |
|  auto !important; left: auto !import | `        `{style="margin: 0px !impor |
| ant; outline: 0px !important; overfl | tant; padding: 0px !important; white |
| ow: visible !important; position: st | -space: nowrap; border: 0px !importa |
| atic !important; right: auto !import | nt; border-radius: 0px !important; b |
| ant; text-align: right !important; t | ottom: auto !important; float: none  |
| op: auto !important; vertical-align: | !important; height: auto !important; |
|  baseline !important; width: auto !i |  left: auto !important; outline: 0px |
| mportant; box-sizing: content-box !i |  !important; overflow: visible !impo |
| mportant; font-family: Consolas, 'Bi | rtant; position: static !important;  |
| tstream Vera Sans Mono', 'Courier Ne | right: auto !important; text-align:  |
| w', Courier, monospace !important; f | left !important; top: auto !importan |
| ont-weight: normal !important; font- | t; vertical-align: baseline !importa |
| style: normal !important; font-size: | nt; width: auto !important; box-sizi |
|  1em !important; min-height: auto !i | ng: content-box !important; font-fam |
| mportant; white-space: pre !importan | ily: Consolas, 'Bitstream Vera Sans  |
| t; background: none rgb(255, 255, 25 | Mono', 'Courier New', Courier, monos |
| 5) !important;">                     | pace !important; font-weight: normal |
|                                      |  !important; font-style: normal !imp |
| 22                                   | ortant; font-size: 1em !important; m |
|                                      | in-height: auto !important; backgrou |
| </div>                               | nd: none !important;"}`static`{style |
|                                      | ="margin: 0px !important; padding: 0 |
| <div                                 | px !important; white-space: nowrap;  |
| style="margin: 0px !important; paddi | border: 0px !important; border-radiu |
| ng: 0px 0.5em 0px 1em !important; bo | s: 0px !important; bottom: auto !imp |
| rder-radius: 0px !important; border- | ortant; float: none !important; heig |
| width: 0px 3px 0px 0px !important; b | ht: auto !important; left: auto !imp |
| order-right-style: solid !important; | ortant; outline: 0px !important; ove |
|  border-right-color: rgb(108, 226, 1 | rflow: visible !important; position: |
| 08) !important; bottom: auto !import |  static !important; right: auto !imp |
| ant; float: none !important; height: | ortant; text-align: left !important; |
|  auto !important; left: auto !import |  top: auto !important; vertical-alig |
| ant; outline: 0px !important; overfl | n: baseline !important; width: auto  |
| ow: visible !important; position: st | !important; box-sizing: content-box  |
| atic !important; right: auto !import | !important; font-family: Consolas, ' |
| ant; text-align: right !important; t | Bitstream Vera Sans Mono', 'Courier  |
| op: auto !important; vertical-align: | New', Courier, monospace !important; |
|  baseline !important; width: auto !i |  font-weight: bold !important; font- |
| mportant; box-sizing: content-box !i | style: normal !important; font-size: |
| mportant; font-family: Consolas, 'Bi |  1em !important; min-height: auto !i |
| tstream Vera Sans Mono', 'Courier Ne | mportant; color: rgb(0, 102, 153) !i |
| w', Courier, monospace !important; f | mportant; background: none !importan |
| ont-weight: normal !important; font- | t;"}                                 |
| style: normal !important; font-size: | `void`{style="margin: 0px !important |
|  1em !important; min-height: auto !i | ; padding: 0px !important; white-spa |
| mportant; white-space: pre !importan | ce: nowrap; border: 0px !important;  |
| t; background: none rgb(248, 248, 24 | border-radius: 0px !important; botto |
| 8) !important;">                     | m: auto !important; float: none !imp |
|                                      | ortant; height: auto !important; lef |
| 23                                   | t: auto !important; outline: 0px !im |
|                                      | portant; overflow: visible !importan |
| </div>                               | t; position: static !important; righ |
|                                      | t: auto !important; text-align: left |
| <div                                 |  !important; top: auto !important; v |
| style="margin: 0px !important; paddi | ertical-align: baseline !important;  |
| ng: 0px 0.5em 0px 1em !important; bo | width: auto !important; box-sizing:  |
| rder-radius: 0px !important; border- | content-box !important; font-family: |
| width: 0px 3px 0px 0px !important; b |  Consolas, 'Bitstream Vera Sans Mono |
| order-right-style: solid !important; | ', 'Courier New', Courier, monospace |
|  border-right-color: rgb(108, 226, 1 |  !important; font-weight: bold !impo |
| 08) !important; bottom: auto !import | rtant; font-style: normal !important |
| ant; float: none !important; height: | ; font-size: 1em !important; min-hei |
|  auto !important; left: auto !import | ght: auto !important; color: rgb(0,  |
| ant; outline: 0px !important; overfl | 102, 153) !important; background: no |
| ow: visible !important; position: st | ne !important;"}                     |
| atic !important; right: auto !import | `Main(`{style="margin: 0px !importan |
| ant; text-align: right !important; t | t; padding: 0px !important; white-sp |
| op: auto !important; vertical-align: | ace: nowrap; border: 0px !important; |
|  baseline !important; width: auto !i |  border-radius: 0px !important; bott |
| mportant; box-sizing: content-box !i | om: auto !important; float: none !im |
| mportant; font-family: Consolas, 'Bi | portant; height: auto !important; le |
| tstream Vera Sans Mono', 'Courier Ne | ft: auto !important; outline: 0px !i |
| w', Courier, monospace !important; f | mportant; overflow: visible !importa |
| ont-weight: normal !important; font- | nt; position: static !important; rig |
| style: normal !important; font-size: | ht: auto !important; text-align: lef |
|  1em !important; min-height: auto !i | t !important; top: auto !important;  |
| mportant; white-space: pre !importan | vertical-align: baseline !important; |
| t; background: none rgb(255, 255, 25 |  width: auto !important; box-sizing: |
| 5) !important;">                     |  content-box !important; font-family |
|                                      | : Consolas, 'Bitstream Vera Sans Mon |
| 24                                   | o', 'Courier New', Courier, monospac |
|                                      | e !important; font-weight: normal !i |
| </div>                               | mportant; font-style: normal !import |
|                                      | ant; font-size: 1em !important; min- |
| <div                                 | height: auto !important; color: rgb( |
| style="margin: 0px !important; paddi | 0, 0, 0) !important; background: non |
| ng: 0px 0.5em 0px 1em !important; bo | e !important;"}`string`{style="margi |
| rder-radius: 0px !important; border- | n: 0px !important; padding: 0px !imp |
| width: 0px 3px 0px 0px !important; b | ortant; white-space: nowrap; border: |
| order-right-style: solid !important; |  0px !important; border-radius: 0px  |
|  border-right-color: rgb(108, 226, 1 | !important; bottom: auto !important; |
| 08) !important; bottom: auto !import |  float: none !important; height: aut |
| ant; float: none !important; height: | o !important; left: auto !important; |
|  auto !important; left: auto !import |  outline: 0px !important; overflow:  |
| ant; outline: 0px !important; overfl | visible !important; position: static |
| ow: visible !important; position: st |  !important; right: auto !important; |
| atic !important; right: auto !import |  text-align: left !important; top: a |
| ant; text-align: right !important; t | uto !important; vertical-align: base |
| op: auto !important; vertical-align: | line !important; width: auto !import |
|  baseline !important; width: auto !i | ant; box-sizing: content-box !import |
| mportant; box-sizing: content-box !i | ant; font-family: Consolas, 'Bitstre |
| mportant; font-family: Consolas, 'Bi | am Vera Sans Mono', 'Courier New', C |
| tstream Vera Sans Mono', 'Courier Ne | ourier, monospace !important; font-w |
| w', Courier, monospace !important; f | eight: bold !important; font-style:  |
| ont-weight: normal !important; font- | normal !important; font-size: 1em !i |
| style: normal !important; font-size: | mportant; min-height: auto !importan |
|  1em !important; min-height: auto !i | t; color: rgb(0, 102, 153) !importan |
| mportant; white-space: pre !importan | t; background: none !important;"}`[] |
| t; background: none rgb(248, 248, 24 |  args)`{style="margin: 0px !importan |
| 8) !important;">                     | t; padding: 0px !important; white-sp |
|                                      | ace: nowrap; border: 0px !important; |
| 25                                   |  border-radius: 0px !important; bott |
|                                      | om: auto !important; float: none !im |
| </div>                               | portant; height: auto !important; le |
|                                      | ft: auto !important; outline: 0px !i |
| <div                                 | mportant; overflow: visible !importa |
| style="margin: 0px !important; paddi | nt; position: static !important; rig |
| ng: 0px 0.5em 0px 1em !important; bo | ht: auto !important; text-align: lef |
| rder-radius: 0px !important; border- | t !important; top: auto !important;  |
| width: 0px 3px 0px 0px !important; b | vertical-align: baseline !important; |
| order-right-style: solid !important; |  width: auto !important; box-sizing: |
|  border-right-color: rgb(108, 226, 1 |  content-box !important; font-family |
| 08) !important; bottom: auto !import | : Consolas, 'Bitstream Vera Sans Mon |
| ant; float: none !important; height: | o', 'Courier New', Courier, monospac |
|  auto !important; left: auto !import | e !important; font-weight: normal !i |
| ant; outline: 0px !important; overfl | mportant; font-style: normal !import |
| ow: visible !important; position: st | ant; font-size: 1em !important; min- |
| atic !important; right: auto !import | height: auto !important; color: rgb( |
| ant; text-align: right !important; t | 0, 0, 0) !important; background: non |
| op: auto !important; vertical-align: | e !important;"}                      |
|  baseline !important; width: auto !i |                                      |
| mportant; box-sizing: content-box !i | </div>                               |
| mportant; font-family: Consolas, 'Bi |                                      |
| tstream Vera Sans Mono', 'Courier Ne | <div                                 |
| w', Courier, monospace !important; f | style="margin: 0px !important; paddi |
| ont-weight: normal !important; font- | ng: 0px 1em !important; border-radiu |
| style: normal !important; font-size: | s: 0px !important; border: 0px !impo |
|  1em !important; min-height: auto !i | rtant; bottom: auto !important; floa |
| mportant; white-space: pre !importan | t: none !important; height: auto !im |
| t; background: none rgb(255, 255, 25 | portant; left: auto !important; outl |
| 5) !important;">                     | ine: 0px !important; overflow: visib |
|                                      | le !important; position: static !imp |
| 26                                   | ortant; right: auto !important; text |
|                                      | -align: left !important; top: auto ! |
| </div>                               | important; vertical-align: baseline  |
|                                      | !important; width: auto !important;  |
| <div                                 | box-sizing: content-box !important;  |
| style="margin: 0px !important; paddi | font-family: Consolas, 'Bitstream Ve |
| ng: 0px 0.5em 0px 1em !important; bo | ra Sans Mono', 'Courier New', Courie |
| rder-radius: 0px !important; border- | r, monospace !important; font-weight |
| width: 0px 3px 0px 0px !important; b | : normal !important; font-style: nor |
| order-right-style: solid !important; | mal !important; font-size: 1em !impo |
|  border-right-color: rgb(108, 226, 1 | rtant; min-height: auto !important;  |
| 08) !important; bottom: auto !import | white-space: pre !important; backgro |
| ant; float: none !important; height: | und: none rgb(248, 248, 248) !import |
|  auto !important; left: auto !import | ant;">                               |
| ant; outline: 0px !important; overfl |                                      |
| ow: visible !important; position: st | `        `{style="margin: 0px !impor |
| atic !important; right: auto !import | tant; padding: 0px !important; white |
| ant; text-align: right !important; t | -space: nowrap; border: 0px !importa |
| op: auto !important; vertical-align: | nt; border-radius: 0px !important; b |
|  baseline !important; width: auto !i | ottom: auto !important; float: none  |
| mportant; box-sizing: content-box !i | !important; height: auto !important; |
| mportant; font-family: Consolas, 'Bi |  left: auto !important; outline: 0px |
| tstream Vera Sans Mono', 'Courier Ne |  !important; overflow: visible !impo |
| w', Courier, monospace !important; f | rtant; position: static !important;  |
| ont-weight: normal !important; font- | right: auto !important; text-align:  |
| style: normal !important; font-size: | left !important; top: auto !importan |
|  1em !important; min-height: auto !i | t; vertical-align: baseline !importa |
| mportant; white-space: pre !importan | nt; width: auto !important; box-sizi |
| t; background: none rgb(248, 248, 24 | ng: content-box !important; font-fam |
| 8) !important;">                     | ily: Consolas, 'Bitstream Vera Sans  |
|                                      | Mono', 'Courier New', Courier, monos |
| 27                                   | pace !important; font-weight: normal |
|                                      |  !important; font-style: normal !imp |
| </div>                               | ortant; font-size: 1em !important; m |
|                                      | in-height: auto !important; backgrou |
| <div                                 | nd: none !important;"}`{`{style="mar |
| style="margin: 0px !important; paddi | gin: 0px !important; padding: 0px !i |
| ng: 0px 0.5em 0px 1em !important; bo | mportant; white-space: nowrap; borde |
| rder-radius: 0px !important; border- | r: 0px !important; border-radius: 0p |
| width: 0px 3px 0px 0px !important; b | x !important; bottom: auto !importan |
| order-right-style: solid !important; | t; float: none !important; height: a |
|  border-right-color: rgb(108, 226, 1 | uto !important; left: auto !importan |
| 08) !important; bottom: auto !import | t; outline: 0px !important; overflow |
| ant; float: none !important; height: | : visible !important; position: stat |
|  auto !important; left: auto !import | ic !important; right: auto !importan |
| ant; outline: 0px !important; overfl | t; text-align: left !important; top: |
| ow: visible !important; position: st |  auto !important; vertical-align: ba |
| atic !important; right: auto !import | seline !important; width: auto !impo |
| ant; text-align: right !important; t | rtant; box-sizing: content-box !impo |
| op: auto !important; vertical-align: | rtant; font-family: Consolas, 'Bitst |
|  baseline !important; width: auto !i | ream Vera Sans Mono', 'Courier New', |
| mportant; box-sizing: content-box !i |  Courier, monospace !important; font |
| mportant; font-family: Consolas, 'Bi | -weight: normal !important; font-sty |
| tstream Vera Sans Mono', 'Courier Ne | le: normal !important; font-size: 1e |
| w', Courier, monospace !important; f | m !important; min-height: auto !impo |
| ont-weight: normal !important; font- | rtant; color: rgb(0, 0, 0) !importan |
| style: normal !important; font-size: | t; background: none !important;"}    |
|  1em !important; min-height: auto !i |                                      |
| mportant; white-space: pre !importan | </div>                               |
| t; background: none rgb(255, 255, 25 |                                      |
| 5) !important;">                     | <div                                 |
|                                      | style="margin: 0px !important; paddi |
| 28                                   | ng: 0px 1em !important; border-radiu |
|                                      | s: 0px !important; border: 0px !impo |
| </div>                               | rtant; bottom: auto !important; floa |
|                                      | t: none !important; height: auto !im |
|                                      | portant; left: auto !important; outl |
|                                      | ine: 0px !important; overflow: visib |
|                                      | le !important; position: static !imp |
|                                      | ortant; right: auto !important; text |
|                                      | -align: left !important; top: auto ! |
|                                      | important; vertical-align: baseline  |
|                                      | !important; width: auto !important;  |
|                                      | box-sizing: content-box !important;  |
|                                      | font-family: Consolas, 'Bitstream Ve |
|                                      | ra Sans Mono', 'Courier New', Courie |
|                                      | r, monospace !important; font-weight |
|                                      | : normal !important; font-style: nor |
|                                      | mal !important; font-size: 1em !impo |
|                                      | rtant; min-height: auto !important;  |
|                                      | white-space: pre !important; backgro |
|                                      | und: none rgb(255, 255, 255) !import |
|                                      | ant;">                               |
|                                      |                                      |
|                                      | `            `{style="margin: 0px !i |
|                                      | mportant; padding: 0px !important; w |
|                                      | hite-space: nowrap; border: 0px !imp |
|                                      | ortant; border-radius: 0px !importan |
|                                      | t; bottom: auto !important; float: n |
|                                      | one !important; height: auto !import |
|                                      | ant; left: auto !important; outline: |
|                                      |  0px !important; overflow: visible ! |
|                                      | important; position: static !importa |
|                                      | nt; right: auto !important; text-ali |
|                                      | gn: left !important; top: auto !impo |
|                                      | rtant; vertical-align: baseline !imp |
|                                      | ortant; width: auto !important; box- |
|                                      | sizing: content-box !important; font |
|                                      | -family: Consolas, 'Bitstream Vera S |
|                                      | ans Mono', 'Courier New', Courier, m |
|                                      | onospace !important; font-weight: no |
|                                      | rmal !important; font-style: normal  |
|                                      | !important; font-size: 1em !importan |
|                                      | t; min-height: auto !important; back |
|                                      | ground: none !important;"}`//Seriali |
|                                      | zation of String Object           `{ |
|                                      | style="margin: 0px !important; paddi |
|                                      | ng: 0px !important; white-space: now |
|                                      | rap; border: 0px !important; border- |
|                                      | radius: 0px !important; bottom: auto |
|                                      |  !important; float: none !important; |
|                                      |  height: auto !important; left: auto |
|                                      |  !important; outline: 0px !important |
|                                      | ; overflow: visible !important; posi |
|                                      | tion: static !important; right: auto |
|                                      |  !important; text-align: left !impor |
|                                      | tant; top: auto !important; vertical |
|                                      | -align: baseline !important; width:  |
|                                      | auto !important; box-sizing: content |
|                                      | -box !important; font-family: Consol |
|                                      | as, 'Bitstream Vera Sans Mono', 'Cou |
|                                      | rier New', Courier, monospace !impor |
|                                      | tant; font-weight: normal !important |
|                                      | ; font-style: normal !important; fon |
|                                      | t-size: 1em !important; min-height:  |
|                                      | auto !important; color: rgb(0, 130,  |
|                                      | 0) !important; background: none !imp |
|                                      | ortant;"}                            |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="margin: 0px !important; paddi |
|                                      | ng: 0px 1em !important; border-radiu |
|                                      | s: 0px !important; border: 0px !impo |
|                                      | rtant; bottom: auto !important; floa |
|                                      | t: none !important; height: auto !im |
|                                      | portant; left: auto !important; outl |
|                                      | ine: 0px !important; overflow: visib |
|                                      | le !important; position: static !imp |
|                                      | ortant; right: auto !important; text |
|                                      | -align: left !important; top: auto ! |
|                                      | important; vertical-align: baseline  |
|                                      | !important; width: auto !important;  |
|                                      | box-sizing: content-box !important;  |
|                                      | font-family: Consolas, 'Bitstream Ve |
|                                      | ra Sans Mono', 'Courier New', Courie |
|                                      | r, monospace !important; font-weight |
|                                      | : normal !important; font-style: nor |
|                                      | mal !important; font-size: 1em !impo |
|                                      | rtant; min-height: auto !important;  |
|                                      | white-space: pre !important; backgro |
|                                      | und: none rgb(248, 248, 248) !import |
|                                      | ant;">                               |
|                                      |                                      |
|                                      | `            `{style="margin: 0px !i |
|                                      | mportant; padding: 0px !important; w |
|                                      | hite-space: nowrap; border: 0px !imp |
|                                      | ortant; border-radius: 0px !importan |
|                                      | t; bottom: auto !important; float: n |
|                                      | one !important; height: auto !import |
|                                      | ant; left: auto !important; outline: |
|                                      |  0px !important; overflow: visible ! |
|                                      | important; position: static !importa |
|                                      | nt; right: auto !important; text-ali |
|                                      | gn: left !important; top: auto !impo |
|                                      | rtant; vertical-align: baseline !imp |
|                                      | ortant; width: auto !important; box- |
|                                      | sizing: content-box !important; font |
|                                      | -family: Consolas, 'Bitstream Vera S |
|                                      | ans Mono', 'Courier New', Courier, m |
|                                      | onospace !important; font-weight: no |
|                                      | rmal !important; font-style: normal  |
|                                      | !important; font-size: 1em !importan |
|                                      | t; min-height: auto !important; back |
|                                      | ground: none !important;"}`string`{s |
|                                      | tyle="margin: 0px !important; paddin |
|                                      | g: 0px !important; white-space: nowr |
|                                      | ap; border: 0px !important; border-r |
|                                      | adius: 0px !important; bottom: auto  |
|                                      | !important; float: none !important;  |
|                                      | height: auto !important; left: auto  |
|                                      | !important; outline: 0px !important; |
|                                      |  overflow: visible !important; posit |
|                                      | ion: static !important; right: auto  |
|                                      | !important; text-align: left !import |
|                                      | ant; top: auto !important; vertical- |
|                                      | align: baseline !important; width: a |
|                                      | uto !important; box-sizing: content- |
|                                      | box !important; font-family: Consola |
|                                      | s, 'Bitstream Vera Sans Mono', 'Cour |
|                                      | ier New', Courier, monospace !import |
|                                      | ant; font-weight: bold !important; f |
|                                      | ont-style: normal !important; font-s |
|                                      | ize: 1em !important; min-height: aut |
|                                      | o !important; color: rgb(0, 102, 153 |
|                                      | ) !important; background: none !impo |
|                                      | rtant;"}                             |
|                                      | `strobj = `{style="margin: 0px !impo |
|                                      | rtant; padding: 0px !important; whit |
|                                      | e-space: nowrap; border: 0px !import |
|                                      | ant; border-radius: 0px !important;  |
|                                      | bottom: auto !important; float: none |
|                                      |  !important; height: auto !important |
|                                      | ; left: auto !important; outline: 0p |
|                                      | x !important; overflow: visible !imp |
|                                      | ortant; position: static !important; |
|                                      |  right: auto !important; text-align: |
|                                      |  left !important; top: auto !importa |
|                                      | nt; vertical-align: baseline !import |
|                                      | ant; width: auto !important; box-siz |
|                                      | ing: content-box !important; font-fa |
|                                      | mily: Consolas, 'Bitstream Vera Sans |
|                                      |  Mono', 'Courier New', Courier, mono |
|                                      | space !important; font-weight: norma |
|                                      | l !important; font-style: normal !im |
|                                      | portant; font-size: 1em !important;  |
|                                      | min-height: auto !important; color:  |
|                                      | rgb(0, 0, 0) !important; background: |
|                                      |  none !important;"}`"test string for |
|                                      |  serialization"`{style="margin: 0px  |
|                                      | !important; padding: 0px !important; |
|                                      |  white-space: nowrap; border: 0px !i |
|                                      | mportant; border-radius: 0px !import |
|                                      | ant; bottom: auto !important; float: |
|                                      |  none !important; height: auto !impo |
|                                      | rtant; left: auto !important; outlin |
|                                      | e: 0px !important; overflow: visible |
|                                      |  !important; position: static !impor |
|                                      | tant; right: auto !important; text-a |
|                                      | lign: left !important; top: auto !im |
|                                      | portant; vertical-align: baseline !i |
|                                      | mportant; width: auto !important; bo |
|                                      | x-sizing: content-box !important; fo |
|                                      | nt-family: Consolas, 'Bitstream Vera |
|                                      |  Sans Mono', 'Courier New', Courier, |
|                                      |  monospace !important; font-weight:  |
|                                      | normal !important; font-style: norma |
|                                      | l !important; font-size: 1em !import |
|                                      | ant; min-height: auto !important; co |
|                                      | lor: blue !important; background: no |
|                                      | ne !important;"}`;`{style="margin: 0 |
|                                      | px !important; padding: 0px !importa |
|                                      | nt; white-space: nowrap; border: 0px |
|                                      |  !important; border-radius: 0px !imp |
|                                      | ortant; bottom: auto !important; flo |
|                                      | at: none !important; height: auto !i |
|                                      | mportant; left: auto !important; out |
|                                      | line: 0px !important; overflow: visi |
|                                      | ble !important; position: static !im |
|                                      | portant; right: auto !important; tex |
|                                      | t-align: left !important; top: auto  |
|                                      | !important; vertical-align: baseline |
|                                      |  !important; width: auto !important; |
|                                      |  box-sizing: content-box !important; |
|                                      |  font-family: Consolas, 'Bitstream V |
|                                      | era Sans Mono', 'Courier New', Couri |
|                                      | er, monospace !important; font-weigh |
|                                      | t: normal !important; font-style: no |
|                                      | rmal !important; font-size: 1em !imp |
|                                      | ortant; min-height: auto !important; |
|                                      |  color: rgb(0, 0, 0) !important; bac |
|                                      | kground: none !important;"}          |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="margin: 0px !important; paddi |
|                                      | ng: 0px 1em !important; border-radiu |
|                                      | s: 0px !important; border: 0px !impo |
|                                      | rtant; bottom: auto !important; floa |
|                                      | t: none !important; height: auto !im |
|                                      | portant; left: auto !important; outl |
|                                      | ine: 0px !important; overflow: visib |
|                                      | le !important; position: static !imp |
|                                      | ortant; right: auto !important; text |
|                                      | -align: left !important; top: auto ! |
|                                      | important; vertical-align: baseline  |
|                                      | !important; width: auto !important;  |
|                                      | box-sizing: content-box !important;  |
|                                      | font-family: Consolas, 'Bitstream Ve |
|                                      | ra Sans Mono', 'Courier New', Courie |
|                                      | r, monospace !important; font-weight |
|                                      | : normal !important; font-style: nor |
|                                      | mal !important; font-size: 1em !impo |
|                                      | rtant; min-height: auto !important;  |
|                                      | white-space: pre !important; backgro |
|                                      | und: none rgb(255, 255, 255) !import |
|                                      | ant;">                               |
|                                      |                                      |
|                                      | `            `{style="margin: 0px !i |
|                                      | mportant; padding: 0px !important; w |
|                                      | hite-space: nowrap; border: 0px !imp |
|                                      | ortant; border-radius: 0px !importan |
|                                      | t; bottom: auto !important; float: n |
|                                      | one !important; height: auto !import |
|                                      | ant; left: auto !important; outline: |
|                                      |  0px !important; overflow: visible ! |
|                                      | important; position: static !importa |
|                                      | nt; right: auto !important; text-ali |
|                                      | gn: left !important; top: auto !impo |
|                                      | rtant; vertical-align: baseline !imp |
|                                      | ortant; width: auto !important; box- |
|                                      | sizing: content-box !important; font |
|                                      | -family: Consolas, 'Bitstream Vera S |
|                                      | ans Mono', 'Courier New', Courier, m |
|                                      | onospace !important; font-weight: no |
|                                      | rmal !important; font-style: normal  |
|                                      | !important; font-size: 1em !importan |
|                                      | t; min-height: auto !important; back |
|                                      | ground: none !important;"}`FileStrea |
|                                      | m stream = `{style="margin: 0px !imp |
|                                      | ortant; padding: 0px !important; whi |
|                                      | te-space: nowrap; border: 0px !impor |
|                                      | tant; border-radius: 0px !important; |
|                                      |  bottom: auto !important; float: non |
|                                      | e !important; height: auto !importan |
|                                      | t; left: auto !important; outline: 0 |
|                                      | px !important; overflow: visible !im |
|                                      | portant; position: static !important |
|                                      | ; right: auto !important; text-align |
|                                      | : left !important; top: auto !import |
|                                      | ant; vertical-align: baseline !impor |
|                                      | tant; width: auto !important; box-si |
|                                      | zing: content-box !important; font-f |
|                                      | amily: Consolas, 'Bitstream Vera San |
|                                      | s Mono', 'Courier New', Courier, mon |
|                                      | ospace !important; font-weight: norm |
|                                      | al !important; font-style: normal !i |
|                                      | mportant; font-size: 1em !important; |
|                                      |  min-height: auto !important; color: |
|                                      |  rgb(0, 0, 0) !important; background |
|                                      | : none !important;"}`new`{style="mar |
|                                      | gin: 0px !important; padding: 0px !i |
|                                      | mportant; white-space: nowrap; borde |
|                                      | r: 0px !important; border-radius: 0p |
|                                      | x !important; bottom: auto !importan |
|                                      | t; float: none !important; height: a |
|                                      | uto !important; left: auto !importan |
|                                      | t; outline: 0px !important; overflow |
|                                      | : visible !important; position: stat |
|                                      | ic !important; right: auto !importan |
|                                      | t; text-align: left !important; top: |
|                                      |  auto !important; vertical-align: ba |
|                                      | seline !important; width: auto !impo |
|                                      | rtant; box-sizing: content-box !impo |
|                                      | rtant; font-family: Consolas, 'Bitst |
|                                      | ream Vera Sans Mono', 'Courier New', |
|                                      |  Courier, monospace !important; font |
|                                      | -weight: bold !important; font-style |
|                                      | : normal !important; font-size: 1em  |
|                                      | !important; min-height: auto !import |
|                                      | ant; color: rgb(0, 102, 153) !import |
|                                      | ant; background: none !important;"}  |
|                                      | `FileStream(`{style="margin: 0px !im |
|                                      | portant; padding: 0px !important; wh |
|                                      | ite-space: nowrap; border: 0px !impo |
|                                      | rtant; border-radius: 0px !important |
|                                      | ; bottom: auto !important; float: no |
|                                      | ne !important; height: auto !importa |
|                                      | nt; left: auto !important; outline:  |
|                                      | 0px !important; overflow: visible !i |
|                                      | mportant; position: static !importan |
|                                      | t; right: auto !important; text-alig |
|                                      | n: left !important; top: auto !impor |
|                                      | tant; vertical-align: baseline !impo |
|                                      | rtant; width: auto !important; box-s |
|                                      | izing: content-box !important; font- |
|                                      | family: Consolas, 'Bitstream Vera Sa |
|                                      | ns Mono', 'Courier New', Courier, mo |
|                                      | nospace !important; font-weight: nor |
|                                      | mal !important; font-style: normal ! |
|                                      | important; font-size: 1em !important |
|                                      | ; min-height: auto !important; color |
|                                      | : rgb(0, 0, 0) !important; backgroun |
|                                      | d: none !important;"}`"C:\\StrObj.tx |
|                                      | t"`{style="margin: 0px !important; p |
|                                      | adding: 0px !important; white-space: |
|                                      |  nowrap; border: 0px !important; bor |
|                                      | der-radius: 0px !important; bottom:  |
|                                      | auto !important; float: none !import |
|                                      | ant; height: auto !important; left:  |
|                                      | auto !important; outline: 0px !impor |
|                                      | tant; overflow: visible !important;  |
|                                      | position: static !important; right:  |
|                                      | auto !important; text-align: left !i |
|                                      | mportant; top: auto !important; vert |
|                                      | ical-align: baseline !important; wid |
|                                      | th: auto !important; box-sizing: con |
|                                      | tent-box !important; font-family: Co |
|                                      | nsolas, 'Bitstream Vera Sans Mono',  |
|                                      | 'Courier New', Courier, monospace !i |
|                                      | mportant; font-weight: normal !impor |
|                                      | tant; font-style: normal !important; |
|                                      |  font-size: 1em !important; min-heig |
|                                      | ht: auto !important; color: blue !im |
|                                      | portant; background: none !important |
|                                      | ;"}`, FileMode.Create, FileAccess.Wr |
|                                      | ite ,`{style="margin: 0px !important |
|                                      | ; padding: 0px !important; white-spa |
|                                      | ce: nowrap; border: 0px !important;  |
|                                      | border-radius: 0px !important; botto |
|                                      | m: auto !important; float: none !imp |
|                                      | ortant; height: auto !important; lef |
|                                      | t: auto !important; outline: 0px !im |
|                                      | portant; overflow: visible !importan |
|                                      | t; position: static !important; righ |
|                                      | t: auto !important; text-align: left |
|                                      |  !important; top: auto !important; v |
|                                      | ertical-align: baseline !important;  |
|                                      | width: auto !important; box-sizing:  |
|                                      | content-box !important; font-family: |
|                                      |  Consolas, 'Bitstream Vera Sans Mono |
|                                      | ', 'Courier New', Courier, monospace |
|                                      |  !important; font-weight: normal !im |
|                                      | portant; font-style: normal !importa |
|                                      | nt; font-size: 1em !important; min-h |
|                                      | eight: auto !important; color: rgb(0 |
|                                      | , 0, 0) !important; background: none |
|                                      |  !important;"}                       |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="margin: 0px !important; paddi |
|                                      | ng: 0px 1em !important; border-radiu |
|                                      | s: 0px !important; border: 0px !impo |
|                                      | rtant; bottom: auto !important; floa |
|                                      | t: none !important; height: auto !im |
|                                      | portant; left: auto !important; outl |
|                                      | ine: 0px !important; overflow: visib |
|                                      | le !important; position: static !imp |
|                                      | ortant; right: auto !important; text |
|                                      | -align: left !important; top: auto ! |
|                                      | important; vertical-align: baseline  |
|                                      | !important; width: auto !important;  |
|                                      | box-sizing: content-box !important;  |
|                                      | font-family: Consolas, 'Bitstream Ve |
|                                      | ra Sans Mono', 'Courier New', Courie |
|                                      | r, monospace !important; font-weight |
|                                      | : normal !important; font-style: nor |
|                                      | mal !important; font-size: 1em !impo |
|                                      | rtant; min-height: auto !important;  |
|                                      | white-space: pre !important; backgro |
|                                      | und: none rgb(248, 248, 248) !import |
|                                      | ant;">                               |
|                                      |                                      |
|                                      | `            `{style="margin: 0px !i |
|                                      | mportant; padding: 0px !important; w |
|                                      | hite-space: nowrap; border: 0px !imp |
|                                      | ortant; border-radius: 0px !importan |
|                                      | t; bottom: auto !important; float: n |
|                                      | one !important; height: auto !import |
|                                      | ant; left: auto !important; outline: |
|                                      |  0px !important; overflow: visible ! |
|                                      | important; position: static !importa |
|                                      | nt; right: auto !important; text-ali |
|                                      | gn: left !important; top: auto !impo |
|                                      | rtant; vertical-align: baseline !imp |
|                                      | ortant; width: auto !important; box- |
|                                      | sizing: content-box !important; font |
|                                      | -family: Consolas, 'Bitstream Vera S |
|                                      | ans Mono', 'Courier New', Courier, m |
|                                      | onospace !important; font-weight: no |
|                                      | rmal !important; font-style: normal  |
|                                      | !important; font-size: 1em !importan |
|                                      | t; min-height: auto !important; back |
|                                      | ground: none !important;"}`FileShare |
|                                      | .None);`{style="margin: 0px !importa |
|                                      | nt; padding: 0px !important; white-s |
|                                      | pace: nowrap; border: 0px !important |
|                                      | ; border-radius: 0px !important; bot |
|                                      | tom: auto !important; float: none !i |
|                                      | mportant; height: auto !important; l |
|                                      | eft: auto !important; outline: 0px ! |
|                                      | important; overflow: visible !import |
|                                      | ant; position: static !important; ri |
|                                      | ght: auto !important; text-align: le |
|                                      | ft !important; top: auto !important; |
|                                      |  vertical-align: baseline !important |
|                                      | ; width: auto !important; box-sizing |
|                                      | : content-box !important; font-famil |
|                                      | y: Consolas, 'Bitstream Vera Sans Mo |
|                                      | no', 'Courier New', Courier, monospa |
|                                      | ce !important; font-weight: normal ! |
|                                      | important; font-style: normal !impor |
|                                      | tant; font-size: 1em !important; min |
|                                      | -height: auto !important; color: rgb |
|                                      | (0, 0, 0) !important; background: no |
|                                      | ne !important;"}                     |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="margin: 0px !important; paddi |
|                                      | ng: 0px 1em !important; border-radiu |
|                                      | s: 0px !important; border: 0px !impo |
|                                      | rtant; bottom: auto !important; floa |
|                                      | t: none !important; height: auto !im |
|                                      | portant; left: auto !important; outl |
|                                      | ine: 0px !important; overflow: visib |
|                                      | le !important; position: static !imp |
|                                      | ortant; right: auto !important; text |
|                                      | -align: left !important; top: auto ! |
|                                      | important; vertical-align: baseline  |
|                                      | !important; width: auto !important;  |
|                                      | box-sizing: content-box !important;  |
|                                      | font-family: Consolas, 'Bitstream Ve |
|                                      | ra Sans Mono', 'Courier New', Courie |
|                                      | r, monospace !important; font-weight |
|                                      | : normal !important; font-style: nor |
|                                      | mal !important; font-size: 1em !impo |
|                                      | rtant; min-height: auto !important;  |
|                                      | white-space: pre !important; backgro |
|                                      | und: none rgb(255, 255, 255) !import |
|                                      | ant;">                               |
|                                      |                                      |
|                                      | `            `{style="margin: 0px !i |
|                                      | mportant; padding: 0px !important; w |
|                                      | hite-space: nowrap; border: 0px !imp |
|                                      | ortant; border-radius: 0px !importan |
|                                      | t; bottom: auto !important; float: n |
|                                      | one !important; height: auto !import |
|                                      | ant; left: auto !important; outline: |
|                                      |  0px !important; overflow: visible ! |
|                                      | important; position: static !importa |
|                                      | nt; right: auto !important; text-ali |
|                                      | gn: left !important; top: auto !impo |
|                                      | rtant; vertical-align: baseline !imp |
|                                      | ortant; width: auto !important; box- |
|                                      | sizing: content-box !important; font |
|                                      | -family: Consolas, 'Bitstream Vera S |
|                                      | ans Mono', 'Courier New', Courier, m |
|                                      | onospace !important; font-weight: no |
|                                      | rmal !important; font-style: normal  |
|                                      | !important; font-size: 1em !importan |
|                                      | t; min-height: auto !important; back |
|                                      | ground: none !important;"}`SoapForma |
|                                      | tter formatter = `{style="margin: 0p |
|                                      | x !important; padding: 0px !importan |
|                                      | t; white-space: nowrap; border: 0px  |
|                                      | !important; border-radius: 0px !impo |
|                                      | rtant; bottom: auto !important; floa |
|                                      | t: none !important; height: auto !im |
|                                      | portant; left: auto !important; outl |
|                                      | ine: 0px !important; overflow: visib |
|                                      | le !important; position: static !imp |
|                                      | ortant; right: auto !important; text |
|                                      | -align: left !important; top: auto ! |
|                                      | important; vertical-align: baseline  |
|                                      | !important; width: auto !important;  |
|                                      | box-sizing: content-box !important;  |
|                                      | font-family: Consolas, 'Bitstream Ve |
|                                      | ra Sans Mono', 'Courier New', Courie |
|                                      | r, monospace !important; font-weight |
|                                      | : normal !important; font-style: nor |
|                                      | mal !important; font-size: 1em !impo |
|                                      | rtant; min-height: auto !important;  |
|                                      | color: rgb(0, 0, 0) !important; back |
|                                      | ground: none !important;"}`new`{styl |
|                                      | e="margin: 0px !important; padding:  |
|                                      | 0px !important; white-space: nowrap; |
|                                      |  border: 0px !important; border-radi |
|                                      | us: 0px !important; bottom: auto !im |
|                                      | portant; float: none !important; hei |
|                                      | ght: auto !important; left: auto !im |
|                                      | portant; outline: 0px !important; ov |
|                                      | erflow: visible !important; position |
|                                      | : static !important; right: auto !im |
|                                      | portant; text-align: left !important |
|                                      | ; top: auto !important; vertical-ali |
|                                      | gn: baseline !important; width: auto |
|                                      |  !important; box-sizing: content-box |
|                                      |  !important; font-family: Consolas,  |
|                                      | 'Bitstream Vera Sans Mono', 'Courier |
|                                      |  New', Courier, monospace !important |
|                                      | ; font-weight: bold !important; font |
|                                      | -style: normal !important; font-size |
|                                      | : 1em !important; min-height: auto ! |
|                                      | important; color: rgb(0, 102, 153) ! |
|                                      | important; background: none !importa |
|                                      | nt;"}                                |
|                                      | `SoapFormatter();`{style="margin: 0p |
|                                      | x !important; padding: 0px !importan |
|                                      | t; white-space: nowrap; border: 0px  |
|                                      | !important; border-radius: 0px !impo |
|                                      | rtant; bottom: auto !important; floa |
|                                      | t: none !important; height: auto !im |
|                                      | portant; left: auto !important; outl |
|                                      | ine: 0px !important; overflow: visib |
|                                      | le !important; position: static !imp |
|                                      | ortant; right: auto !important; text |
|                                      | -align: left !important; top: auto ! |
|                                      | important; vertical-align: baseline  |
|                                      | !important; width: auto !important;  |
|                                      | box-sizing: content-box !important;  |
|                                      | font-family: Consolas, 'Bitstream Ve |
|                                      | ra Sans Mono', 'Courier New', Courie |
|                                      | r, monospace !important; font-weight |
|                                      | : normal !important; font-style: nor |
|                                      | mal !important; font-size: 1em !impo |
|                                      | rtant; min-height: auto !important;  |
|                                      | color: rgb(0, 0, 0) !important; back |
|                                      | ground: none !important;"}           |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="margin: 0px !important; paddi |
|                                      | ng: 0px 1em !important; border-radiu |
|                                      | s: 0px !important; border: 0px !impo |
|                                      | rtant; bottom: auto !important; floa |
|                                      | t: none !important; height: auto !im |
|                                      | portant; left: auto !important; outl |
|                                      | ine: 0px !important; overflow: visib |
|                                      | le !important; position: static !imp |
|                                      | ortant; right: auto !important; text |
|                                      | -align: left !important; top: auto ! |
|                                      | important; vertical-align: baseline  |
|                                      | !important; width: auto !important;  |
|                                      | box-sizing: content-box !important;  |
|                                      | font-family: Consolas, 'Bitstream Ve |
|                                      | ra Sans Mono', 'Courier New', Courie |
|                                      | r, monospace !important; font-weight |
|                                      | : normal !important; font-style: nor |
|                                      | mal !important; font-size: 1em !impo |
|                                      | rtant; min-height: auto !important;  |
|                                      | white-space: pre !important; backgro |
|                                      | und: none rgb(248, 248, 248) !import |
|                                      | ant;">                               |
|                                      |                                      |
|                                      | `            `{style="margin: 0px !i |
|                                      | mportant; padding: 0px !important; w |
|                                      | hite-space: nowrap; border: 0px !imp |
|                                      | ortant; border-radius: 0px !importan |
|                                      | t; bottom: auto !important; float: n |
|                                      | one !important; height: auto !import |
|                                      | ant; left: auto !important; outline: |
|                                      |  0px !important; overflow: visible ! |
|                                      | important; position: static !importa |
|                                      | nt; right: auto !important; text-ali |
|                                      | gn: left !important; top: auto !impo |
|                                      | rtant; vertical-align: baseline !imp |
|                                      | ortant; width: auto !important; box- |
|                                      | sizing: content-box !important; font |
|                                      | -family: Consolas, 'Bitstream Vera S |
|                                      | ans Mono', 'Courier New', Courier, m |
|                                      | onospace !important; font-weight: no |
|                                      | rmal !important; font-style: normal  |
|                                      | !important; font-size: 1em !importan |
|                                      | t; min-height: auto !important; back |
|                                      | ground: none !important;"}`formatter |
|                                      | .Serialize(stream, strobj);`{style=" |
|                                      | margin: 0px !important; padding: 0px |
|                                      |  !important; white-space: nowrap; bo |
|                                      | rder: 0px !important; border-radius: |
|                                      |  0px !important; bottom: auto !impor |
|                                      | tant; float: none !important; height |
|                                      | : auto !important; left: auto !impor |
|                                      | tant; outline: 0px !important; overf |
|                                      | low: visible !important; position: s |
|                                      | tatic !important; right: auto !impor |
|                                      | tant; text-align: left !important; t |
|                                      | op: auto !important; vertical-align: |
|                                      |  baseline !important; width: auto !i |
|                                      | mportant; box-sizing: content-box !i |
|                                      | mportant; font-family: Consolas, 'Bi |
|                                      | tstream Vera Sans Mono', 'Courier Ne |
|                                      | w', Courier, monospace !important; f |
|                                      | ont-weight: normal !important; font- |
|                                      | style: normal !important; font-size: |
|                                      |  1em !important; min-height: auto !i |
|                                      | mportant; color: rgb(0, 0, 0) !impor |
|                                      | tant; background: none !important;"} |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="margin: 0px !important; paddi |
|                                      | ng: 0px 1em !important; border-radiu |
|                                      | s: 0px !important; border: 0px !impo |
|                                      | rtant; bottom: auto !important; floa |
|                                      | t: none !important; height: auto !im |
|                                      | portant; left: auto !important; outl |
|                                      | ine: 0px !important; overflow: visib |
|                                      | le !important; position: static !imp |
|                                      | ortant; right: auto !important; text |
|                                      | -align: left !important; top: auto ! |
|                                      | important; vertical-align: baseline  |
|                                      | !important; width: auto !important;  |
|                                      | box-sizing: content-box !important;  |
|                                      | font-family: Consolas, 'Bitstream Ve |
|                                      | ra Sans Mono', 'Courier New', Courie |
|                                      | r, monospace !important; font-weight |
|                                      | : normal !important; font-style: nor |
|                                      | mal !important; font-size: 1em !impo |
|                                      | rtant; min-height: auto !important;  |
|                                      | white-space: pre !important; backgro |
|                                      | und: none rgb(255, 255, 255) !import |
|                                      | ant;">                               |
|                                      |                                      |
|                                      | `            `{style="margin: 0px !i |
|                                      | mportant; padding: 0px !important; w |
|                                      | hite-space: nowrap; border: 0px !imp |
|                                      | ortant; border-radius: 0px !importan |
|                                      | t; bottom: auto !important; float: n |
|                                      | one !important; height: auto !import |
|                                      | ant; left: auto !important; outline: |
|                                      |  0px !important; overflow: visible ! |
|                                      | important; position: static !importa |
|                                      | nt; right: auto !important; text-ali |
|                                      | gn: left !important; top: auto !impo |
|                                      | rtant; vertical-align: baseline !imp |
|                                      | ortant; width: auto !important; box- |
|                                      | sizing: content-box !important; font |
|                                      | -family: Consolas, 'Bitstream Vera S |
|                                      | ans Mono', 'Courier New', Courier, m |
|                                      | onospace !important; font-weight: no |
|                                      | rmal !important; font-style: normal  |
|                                      | !important; font-size: 1em !importan |
|                                      | t; min-height: auto !important; back |
|                                      | ground: none !important;"}`stream.Cl |
|                                      | ose();`{style="margin: 0px !importan |
|                                      | t; padding: 0px !important; white-sp |
|                                      | ace: nowrap; border: 0px !important; |
|                                      |  border-radius: 0px !important; bott |
|                                      | om: auto !important; float: none !im |
|                                      | portant; height: auto !important; le |
|                                      | ft: auto !important; outline: 0px !i |
|                                      | mportant; overflow: visible !importa |
|                                      | nt; position: static !important; rig |
|                                      | ht: auto !important; text-align: lef |
|                                      | t !important; top: auto !important;  |
|                                      | vertical-align: baseline !important; |
|                                      |  width: auto !important; box-sizing: |
|                                      |  content-box !important; font-family |
|                                      | : Consolas, 'Bitstream Vera Sans Mon |
|                                      | o', 'Courier New', Courier, monospac |
|                                      | e !important; font-weight: normal !i |
|                                      | mportant; font-style: normal !import |
|                                      | ant; font-size: 1em !important; min- |
|                                      | height: auto !important; color: rgb( |
|                                      | 0, 0, 0) !important; background: non |
|                                      | e !important;"}                      |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="margin: 0px !important; paddi |
|                                      | ng: 0px 1em !important; border-radiu |
|                                      | s: 0px !important; border: 0px !impo |
|                                      | rtant; bottom: auto !important; floa |
|                                      | t: none !important; height: auto !im |
|                                      | portant; left: auto !important; outl |
|                                      | ine: 0px !important; overflow: visib |
|                                      | le !important; position: static !imp |
|                                      | ortant; right: auto !important; text |
|                                      | -align: left !important; top: auto ! |
|                                      | important; vertical-align: baseline  |
|                                      | !important; width: auto !important;  |
|                                      | box-sizing: content-box !important;  |
|                                      | font-family: Consolas, 'Bitstream Ve |
|                                      | ra Sans Mono', 'Courier New', Courie |
|                                      | r, monospace !important; font-weight |
|                                      | : normal !important; font-style: nor |
|                                      | mal !important; font-size: 1em !impo |
|                                      | rtant; min-height: auto !important;  |
|                                      | white-space: pre !important; backgro |
|                                      | und: none rgb(248, 248, 248) !import |
|                                      | ant;">                               |
|                                      |                                      |
|                                      | `            `{style="margin: 0px !i |
|                                      | mportant; padding: 0px !important; w |
|                                      | hite-space: nowrap; border: 0px !imp |
|                                      | ortant; border-radius: 0px !importan |
|                                      | t; bottom: auto !important; float: n |
|                                      | one !important; height: auto !import |
|                                      | ant; left: auto !important; outline: |
|                                      |  0px !important; overflow: visible ! |
|                                      | important; position: static !importa |
|                                      | nt; right: auto !important; text-ali |
|                                      | gn: left !important; top: auto !impo |
|                                      | rtant; vertical-align: baseline !imp |
|                                      | ortant; width: auto !important; box- |
|                                      | sizing: content-box !important; font |
|                                      | -family: Consolas, 'Bitstream Vera S |
|                                      | ans Mono', 'Courier New', Courier, m |
|                                      | onospace !important; font-weight: no |
|                                      | rmal !important; font-style: normal  |
|                                      | !important; font-size: 1em !importan |
|                                      | t; min-height: auto !important; back |
|                                      | ground: none !important;"}`//Deseria |
|                                      | lization of String Object`{style="ma |
|                                      | rgin: 0px !important; padding: 0px ! |
|                                      | important; white-space: nowrap; bord |
|                                      | er: 0px !important; border-radius: 0 |
|                                      | px !important; bottom: auto !importa |
|                                      | nt; float: none !important; height:  |
|                                      | auto !important; left: auto !importa |
|                                      | nt; outline: 0px !important; overflo |
|                                      | w: visible !important; position: sta |
|                                      | tic !important; right: auto !importa |
|                                      | nt; text-align: left !important; top |
|                                      | : auto !important; vertical-align: b |
|                                      | aseline !important; width: auto !imp |
|                                      | ortant; box-sizing: content-box !imp |
|                                      | ortant; font-family: Consolas, 'Bits |
|                                      | tream Vera Sans Mono', 'Courier New' |
|                                      | , Courier, monospace !important; fon |
|                                      | t-weight: normal !important; font-st |
|                                      | yle: normal !important; font-size: 1 |
|                                      | em !important; min-height: auto !imp |
|                                      | ortant; color: rgb(0, 130, 0) !impor |
|                                      | tant; background: none !important;"} |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="margin: 0px !important; paddi |
|                                      | ng: 0px 1em !important; border-radiu |
|                                      | s: 0px !important; border: 0px !impo |
|                                      | rtant; bottom: auto !important; floa |
|                                      | t: none !important; height: auto !im |
|                                      | portant; left: auto !important; outl |
|                                      | ine: 0px !important; overflow: visib |
|                                      | le !important; position: static !imp |
|                                      | ortant; right: auto !important; text |
|                                      | -align: left !important; top: auto ! |
|                                      | important; vertical-align: baseline  |
|                                      | !important; width: auto !important;  |
|                                      | box-sizing: content-box !important;  |
|                                      | font-family: Consolas, 'Bitstream Ve |
|                                      | ra Sans Mono', 'Courier New', Courie |
|                                      | r, monospace !important; font-weight |
|                                      | : normal !important; font-style: nor |
|                                      | mal !important; font-size: 1em !impo |
|                                      | rtant; min-height: auto !important;  |
|                                      | white-space: pre !important; backgro |
|                                      | und: none rgb(255, 255, 255) !import |
|                                      | ant;">                               |
|                                      |                                      |
|                                      | `            `{style="margin: 0px !i |
|                                      | mportant; padding: 0px !important; w |
|                                      | hite-space: nowrap; border: 0px !imp |
|                                      | ortant; border-radius: 0px !importan |
|                                      | t; bottom: auto !important; float: n |
|                                      | one !important; height: auto !import |
|                                      | ant; left: auto !important; outline: |
|                                      |  0px !important; overflow: visible ! |
|                                      | important; position: static !importa |
|                                      | nt; right: auto !important; text-ali |
|                                      | gn: left !important; top: auto !impo |
|                                      | rtant; vertical-align: baseline !imp |
|                                      | ortant; width: auto !important; box- |
|                                      | sizing: content-box !important; font |
|                                      | -family: Consolas, 'Bitstream Vera S |
|                                      | ans Mono', 'Courier New', Courier, m |
|                                      | onospace !important; font-weight: no |
|                                      | rmal !important; font-style: normal  |
|                                      | !important; font-size: 1em !importan |
|                                      | t; min-height: auto !important; back |
|                                      | ground: none !important;"}`FileStrea |
|                                      | m readstream = `{style="margin: 0px  |
|                                      | !important; padding: 0px !important; |
|                                      |  white-space: nowrap; border: 0px !i |
|                                      | mportant; border-radius: 0px !import |
|                                      | ant; bottom: auto !important; float: |
|                                      |  none !important; height: auto !impo |
|                                      | rtant; left: auto !important; outlin |
|                                      | e: 0px !important; overflow: visible |
|                                      |  !important; position: static !impor |
|                                      | tant; right: auto !important; text-a |
|                                      | lign: left !important; top: auto !im |
|                                      | portant; vertical-align: baseline !i |
|                                      | mportant; width: auto !important; bo |
|                                      | x-sizing: content-box !important; fo |
|                                      | nt-family: Consolas, 'Bitstream Vera |
|                                      |  Sans Mono', 'Courier New', Courier, |
|                                      |  monospace !important; font-weight:  |
|                                      | normal !important; font-style: norma |
|                                      | l !important; font-size: 1em !import |
|                                      | ant; min-height: auto !important; co |
|                                      | lor: rgb(0, 0, 0) !important; backgr |
|                                      | ound: none !important;"}`new`{style= |
|                                      | "margin: 0px !important; padding: 0p |
|                                      | x !important; white-space: nowrap; b |
|                                      | order: 0px !important; border-radius |
|                                      | : 0px !important; bottom: auto !impo |
|                                      | rtant; float: none !important; heigh |
|                                      | t: auto !important; left: auto !impo |
|                                      | rtant; outline: 0px !important; over |
|                                      | flow: visible !important; position:  |
|                                      | static !important; right: auto !impo |
|                                      | rtant; text-align: left !important;  |
|                                      | top: auto !important; vertical-align |
|                                      | : baseline !important; width: auto ! |
|                                      | important; box-sizing: content-box ! |
|                                      | important; font-family: Consolas, 'B |
|                                      | itstream Vera Sans Mono', 'Courier N |
|                                      | ew', Courier, monospace !important;  |
|                                      | font-weight: bold !important; font-s |
|                                      | tyle: normal !important; font-size:  |
|                                      | 1em !important; min-height: auto !im |
|                                      | portant; color: rgb(0, 102, 153) !im |
|                                      | portant; background: none !important |
|                                      | ;"}                                  |
|                                      | `FileStream(`{style="margin: 0px !im |
|                                      | portant; padding: 0px !important; wh |
|                                      | ite-space: nowrap; border: 0px !impo |
|                                      | rtant; border-radius: 0px !important |
|                                      | ; bottom: auto !important; float: no |
|                                      | ne !important; height: auto !importa |
|                                      | nt; left: auto !important; outline:  |
|                                      | 0px !important; overflow: visible !i |
|                                      | mportant; position: static !importan |
|                                      | t; right: auto !important; text-alig |
|                                      | n: left !important; top: auto !impor |
|                                      | tant; vertical-align: baseline !impo |
|                                      | rtant; width: auto !important; box-s |
|                                      | izing: content-box !important; font- |
|                                      | family: Consolas, 'Bitstream Vera Sa |
|                                      | ns Mono', 'Courier New', Courier, mo |
|                                      | nospace !important; font-weight: nor |
|                                      | mal !important; font-style: normal ! |
|                                      | important; font-size: 1em !important |
|                                      | ; min-height: auto !important; color |
|                                      | : rgb(0, 0, 0) !important; backgroun |
|                                      | d: none !important;"}`"C:\\StrObj.tx |
|                                      | t"`{style="margin: 0px !important; p |
|                                      | adding: 0px !important; white-space: |
|                                      |  nowrap; border: 0px !important; bor |
|                                      | der-radius: 0px !important; bottom:  |
|                                      | auto !important; float: none !import |
|                                      | ant; height: auto !important; left:  |
|                                      | auto !important; outline: 0px !impor |
|                                      | tant; overflow: visible !important;  |
|                                      | position: static !important; right:  |
|                                      | auto !important; text-align: left !i |
|                                      | mportant; top: auto !important; vert |
|                                      | ical-align: baseline !important; wid |
|                                      | th: auto !important; box-sizing: con |
|                                      | tent-box !important; font-family: Co |
|                                      | nsolas, 'Bitstream Vera Sans Mono',  |
|                                      | 'Courier New', Courier, monospace !i |
|                                      | mportant; font-weight: normal !impor |
|                                      | tant; font-style: normal !important; |
|                                      |  font-size: 1em !important; min-heig |
|                                      | ht: auto !important; color: blue !im |
|                                      | portant; background: none !important |
|                                      | ;"}`, FileMode.Open , FileAccess.Rea |
|                                      | d ,`{style="margin: 0px !important;  |
|                                      | padding: 0px !important; white-space |
|                                      | : nowrap; border: 0px !important; bo |
|                                      | rder-radius: 0px !important; bottom: |
|                                      |  auto !important; float: none !impor |
|                                      | tant; height: auto !important; left: |
|                                      |  auto !important; outline: 0px !impo |
|                                      | rtant; overflow: visible !important; |
|                                      |  position: static !important; right: |
|                                      |  auto !important; text-align: left ! |
|                                      | important; top: auto !important; ver |
|                                      | tical-align: baseline !important; wi |
|                                      | dth: auto !important; box-sizing: co |
|                                      | ntent-box !important; font-family: C |
|                                      | onsolas, 'Bitstream Vera Sans Mono', |
|                                      |  'Courier New', Courier, monospace ! |
|                                      | important; font-weight: normal !impo |
|                                      | rtant; font-style: normal !important |
|                                      | ; font-size: 1em !important; min-hei |
|                                      | ght: auto !important; color: rgb(0,  |
|                                      | 0, 0) !important; background: none ! |
|                                      | important;"}                         |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="margin: 0px !important; paddi |
|                                      | ng: 0px 1em !important; border-radiu |
|                                      | s: 0px !important; border: 0px !impo |
|                                      | rtant; bottom: auto !important; floa |
|                                      | t: none !important; height: auto !im |
|                                      | portant; left: auto !important; outl |
|                                      | ine: 0px !important; overflow: visib |
|                                      | le !important; position: static !imp |
|                                      | ortant; right: auto !important; text |
|                                      | -align: left !important; top: auto ! |
|                                      | important; vertical-align: baseline  |
|                                      | !important; width: auto !important;  |
|                                      | box-sizing: content-box !important;  |
|                                      | font-family: Consolas, 'Bitstream Ve |
|                                      | ra Sans Mono', 'Courier New', Courie |
|                                      | r, monospace !important; font-weight |
|                                      | : normal !important; font-style: nor |
|                                      | mal !important; font-size: 1em !impo |
|                                      | rtant; min-height: auto !important;  |
|                                      | white-space: pre !important; backgro |
|                                      | und: none rgb(248, 248, 248) !import |
|                                      | ant;">                               |
|                                      |                                      |
|                                      | `            `{style="margin: 0px !i |
|                                      | mportant; padding: 0px !important; w |
|                                      | hite-space: nowrap; border: 0px !imp |
|                                      | ortant; border-radius: 0px !importan |
|                                      | t; bottom: auto !important; float: n |
|                                      | one !important; height: auto !import |
|                                      | ant; left: auto !important; outline: |
|                                      |  0px !important; overflow: visible ! |
|                                      | important; position: static !importa |
|                                      | nt; right: auto !important; text-ali |
|                                      | gn: left !important; top: auto !impo |
|                                      | rtant; vertical-align: baseline !imp |
|                                      | ortant; width: auto !important; box- |
|                                      | sizing: content-box !important; font |
|                                      | -family: Consolas, 'Bitstream Vera S |
|                                      | ans Mono', 'Courier New', Courier, m |
|                                      | onospace !important; font-weight: no |
|                                      | rmal !important; font-style: normal  |
|                                      | !important; font-size: 1em !importan |
|                                      | t; min-height: auto !important; back |
|                                      | ground: none !important;"}`FileShare |
|                                      | .Read );`{style="margin: 0px !import |
|                                      | ant; padding: 0px !important; white- |
|                                      | space: nowrap; border: 0px !importan |
|                                      | t; border-radius: 0px !important; bo |
|                                      | ttom: auto !important; float: none ! |
|                                      | important; height: auto !important;  |
|                                      | left: auto !important; outline: 0px  |
|                                      | !important; overflow: visible !impor |
|                                      | tant; position: static !important; r |
|                                      | ight: auto !important; text-align: l |
|                                      | eft !important; top: auto !important |
|                                      | ; vertical-align: baseline !importan |
|                                      | t; width: auto !important; box-sizin |
|                                      | g: content-box !important; font-fami |
|                                      | ly: Consolas, 'Bitstream Vera Sans M |
|                                      | ono', 'Courier New', Courier, monosp |
|                                      | ace !important; font-weight: normal  |
|                                      | !important; font-style: normal !impo |
|                                      | rtant; font-size: 1em !important; mi |
|                                      | n-height: auto !important; color: rg |
|                                      | b(0, 0, 0) !important; background: n |
|                                      | one !important;"}                    |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="margin: 0px !important; paddi |
|                                      | ng: 0px 1em !important; border-radiu |
|                                      | s: 0px !important; border: 0px !impo |
|                                      | rtant; bottom: auto !important; floa |
|                                      | t: none !important; height: auto !im |
|                                      | portant; left: auto !important; outl |
|                                      | ine: 0px !important; overflow: visib |
|                                      | le !important; position: static !imp |
|                                      | ortant; right: auto !important; text |
|                                      | -align: left !important; top: auto ! |
|                                      | important; vertical-align: baseline  |
|                                      | !important; width: auto !important;  |
|                                      | box-sizing: content-box !important;  |
|                                      | font-family: Consolas, 'Bitstream Ve |
|                                      | ra Sans Mono', 'Courier New', Courie |
|                                      | r, monospace !important; font-weight |
|                                      | : normal !important; font-style: nor |
|                                      | mal !important; font-size: 1em !impo |
|                                      | rtant; min-height: auto !important;  |
|                                      | white-space: pre !important; backgro |
|                                      | und: none rgb(255, 255, 255) !import |
|                                      | ant;">                               |
|                                      |                                      |
|                                      | `            `{style="margin: 0px !i |
|                                      | mportant; padding: 0px !important; w |
|                                      | hite-space: nowrap; border: 0px !imp |
|                                      | ortant; border-radius: 0px !importan |
|                                      | t; bottom: auto !important; float: n |
|                                      | one !important; height: auto !import |
|                                      | ant; left: auto !important; outline: |
|                                      |  0px !important; overflow: visible ! |
|                                      | important; position: static !importa |
|                                      | nt; right: auto !important; text-ali |
|                                      | gn: left !important; top: auto !impo |
|                                      | rtant; vertical-align: baseline !imp |
|                                      | ortant; width: auto !important; box- |
|                                      | sizing: content-box !important; font |
|                                      | -family: Consolas, 'Bitstream Vera S |
|                                      | ans Mono', 'Courier New', Courier, m |
|                                      | onospace !important; font-weight: no |
|                                      | rmal !important; font-style: normal  |
|                                      | !important; font-size: 1em !importan |
|                                      | t; min-height: auto !important; back |
|                                      | ground: none !important;"}`string`{s |
|                                      | tyle="margin: 0px !important; paddin |
|                                      | g: 0px !important; white-space: nowr |
|                                      | ap; border: 0px !important; border-r |
|                                      | adius: 0px !important; bottom: auto  |
|                                      | !important; float: none !important;  |
|                                      | height: auto !important; left: auto  |
|                                      | !important; outline: 0px !important; |
|                                      |  overflow: visible !important; posit |
|                                      | ion: static !important; right: auto  |
|                                      | !important; text-align: left !import |
|                                      | ant; top: auto !important; vertical- |
|                                      | align: baseline !important; width: a |
|                                      | uto !important; box-sizing: content- |
|                                      | box !important; font-family: Consola |
|                                      | s, 'Bitstream Vera Sans Mono', 'Cour |
|                                      | ier New', Courier, monospace !import |
|                                      | ant; font-weight: bold !important; f |
|                                      | ont-style: normal !important; font-s |
|                                      | ize: 1em !important; min-height: aut |
|                                      | o !important; color: rgb(0, 102, 153 |
|                                      | ) !important; background: none !impo |
|                                      | rtant;"}                             |
|                                      | `readdata = (`{style="margin: 0px !i |
|                                      | mportant; padding: 0px !important; w |
|                                      | hite-space: nowrap; border: 0px !imp |
|                                      | ortant; border-radius: 0px !importan |
|                                      | t; bottom: auto !important; float: n |
|                                      | one !important; height: auto !import |
|                                      | ant; left: auto !important; outline: |
|                                      |  0px !important; overflow: visible ! |
|                                      | important; position: static !importa |
|                                      | nt; right: auto !important; text-ali |
|                                      | gn: left !important; top: auto !impo |
|                                      | rtant; vertical-align: baseline !imp |
|                                      | ortant; width: auto !important; box- |
|                                      | sizing: content-box !important; font |
|                                      | -family: Consolas, 'Bitstream Vera S |
|                                      | ans Mono', 'Courier New', Courier, m |
|                                      | onospace !important; font-weight: no |
|                                      | rmal !important; font-style: normal  |
|                                      | !important; font-size: 1em !importan |
|                                      | t; min-height: auto !important; colo |
|                                      | r: rgb(0, 0, 0) !important; backgrou |
|                                      | nd: none !important;"}`string`{style |
|                                      | ="margin: 0px !important; padding: 0 |
|                                      | px !important; white-space: nowrap;  |
|                                      | border: 0px !important; border-radiu |
|                                      | s: 0px !important; bottom: auto !imp |
|                                      | ortant; float: none !important; heig |
|                                      | ht: auto !important; left: auto !imp |
|                                      | ortant; outline: 0px !important; ove |
|                                      | rflow: visible !important; position: |
|                                      |  static !important; right: auto !imp |
|                                      | ortant; text-align: left !important; |
|                                      |  top: auto !important; vertical-alig |
|                                      | n: baseline !important; width: auto  |
|                                      | !important; box-sizing: content-box  |
|                                      | !important; font-family: Consolas, ' |
|                                      | Bitstream Vera Sans Mono', 'Courier  |
|                                      | New', Courier, monospace !important; |
|                                      |  font-weight: bold !important; font- |
|                                      | style: normal !important; font-size: |
|                                      |  1em !important; min-height: auto !i |
|                                      | mportant; color: rgb(0, 102, 153) !i |
|                                      | mportant; background: none !importan |
|                                      | t;"}`)formatter.Deserialize(readstre |
|                                      | am);`{style="margin: 0px !important; |
|                                      |  padding: 0px !important; white-spac |
|                                      | e: nowrap; border: 0px !important; b |
|                                      | order-radius: 0px !important; bottom |
|                                      | : auto !important; float: none !impo |
|                                      | rtant; height: auto !important; left |
|                                      | : auto !important; outline: 0px !imp |
|                                      | ortant; overflow: visible !important |
|                                      | ; position: static !important; right |
|                                      | : auto !important; text-align: left  |
|                                      | !important; top: auto !important; ve |
|                                      | rtical-align: baseline !important; w |
|                                      | idth: auto !important; box-sizing: c |
|                                      | ontent-box !important; font-family:  |
|                                      | Consolas, 'Bitstream Vera Sans Mono' |
|                                      | , 'Courier New', Courier, monospace  |
|                                      | !important; font-weight: normal !imp |
|                                      | ortant; font-style: normal !importan |
|                                      | t; font-size: 1em !important; min-he |
|                                      | ight: auto !important; color: rgb(0, |
|                                      |  0, 0) !important; background: none  |
|                                      | !important;"}                        |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="margin: 0px !important; paddi |
|                                      | ng: 0px 1em !important; border-radiu |
|                                      | s: 0px !important; border: 0px !impo |
|                                      | rtant; bottom: auto !important; floa |
|                                      | t: none !important; height: auto !im |
|                                      | portant; left: auto !important; outl |
|                                      | ine: 0px !important; overflow: visib |
|                                      | le !important; position: static !imp |
|                                      | ortant; right: auto !important; text |
|                                      | -align: left !important; top: auto ! |
|                                      | important; vertical-align: baseline  |
|                                      | !important; width: auto !important;  |
|                                      | box-sizing: content-box !important;  |
|                                      | font-family: Consolas, 'Bitstream Ve |
|                                      | ra Sans Mono', 'Courier New', Courie |
|                                      | r, monospace !important; font-weight |
|                                      | : normal !important; font-style: nor |
|                                      | mal !important; font-size: 1em !impo |
|                                      | rtant; min-height: auto !important;  |
|                                      | white-space: pre !important; backgro |
|                                      | und: none rgb(248, 248, 248) !import |
|                                      | ant;">                               |
|                                      |                                      |
|                                      | `            `{style="margin: 0px !i |
|                                      | mportant; padding: 0px !important; w |
|                                      | hite-space: nowrap; border: 0px !imp |
|                                      | ortant; border-radius: 0px !importan |
|                                      | t; bottom: auto !important; float: n |
|                                      | one !important; height: auto !import |
|                                      | ant; left: auto !important; outline: |
|                                      |  0px !important; overflow: visible ! |
|                                      | important; position: static !importa |
|                                      | nt; right: auto !important; text-ali |
|                                      | gn: left !important; top: auto !impo |
|                                      | rtant; vertical-align: baseline !imp |
|                                      | ortant; width: auto !important; box- |
|                                      | sizing: content-box !important; font |
|                                      | -family: Consolas, 'Bitstream Vera S |
|                                      | ans Mono', 'Courier New', Courier, m |
|                                      | onospace !important; font-weight: no |
|                                      | rmal !important; font-style: normal  |
|                                      | !important; font-size: 1em !importan |
|                                      | t; min-height: auto !important; back |
|                                      | ground: none !important;"}`readstrea |
|                                      | m.Close();`{style="margin: 0px !impo |
|                                      | rtant; padding: 0px !important; whit |
|                                      | e-space: nowrap; border: 0px !import |
|                                      | ant; border-radius: 0px !important;  |
|                                      | bottom: auto !important; float: none |
|                                      |  !important; height: auto !important |
|                                      | ; left: auto !important; outline: 0p |
|                                      | x !important; overflow: visible !imp |
|                                      | ortant; position: static !important; |
|                                      |  right: auto !important; text-align: |
|                                      |  left !important; top: auto !importa |
|                                      | nt; vertical-align: baseline !import |
|                                      | ant; width: auto !important; box-siz |
|                                      | ing: content-box !important; font-fa |
|                                      | mily: Consolas, 'Bitstream Vera Sans |
|                                      |  Mono', 'Courier New', Courier, mono |
|                                      | space !important; font-weight: norma |
|                                      | l !important; font-style: normal !im |
|                                      | portant; font-size: 1em !important;  |
|                                      | min-height: auto !important; color:  |
|                                      | rgb(0, 0, 0) !important; background: |
|                                      |  none !important;"}                  |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="margin: 0px !important; paddi |
|                                      | ng: 0px 1em !important; border-radiu |
|                                      | s: 0px !important; border: 0px !impo |
|                                      | rtant; bottom: auto !important; floa |
|                                      | t: none !important; height: auto !im |
|                                      | portant; left: auto !important; outl |
|                                      | ine: 0px !important; overflow: visib |
|                                      | le !important; position: static !imp |
|                                      | ortant; right: auto !important; text |
|                                      | -align: left !important; top: auto ! |
|                                      | important; vertical-align: baseline  |
|                                      | !important; width: auto !important;  |
|                                      | box-sizing: content-box !important;  |
|                                      | font-family: Consolas, 'Bitstream Ve |
|                                      | ra Sans Mono', 'Courier New', Courie |
|                                      | r, monospace !important; font-weight |
|                                      | : normal !important; font-style: nor |
|                                      | mal !important; font-size: 1em !impo |
|                                      | rtant; min-height: auto !important;  |
|                                      | white-space: pre !important; backgro |
|                                      | und: none rgb(255, 255, 255) !import |
|                                      | ant;">                               |
|                                      |                                      |
|                                      | `            `{style="margin: 0px !i |
|                                      | mportant; padding: 0px !important; w |
|                                      | hite-space: nowrap; border: 0px !imp |
|                                      | ortant; border-radius: 0px !importan |
|                                      | t; bottom: auto !important; float: n |
|                                      | one !important; height: auto !import |
|                                      | ant; left: auto !important; outline: |
|                                      |  0px !important; overflow: visible ! |
|                                      | important; position: static !importa |
|                                      | nt; right: auto !important; text-ali |
|                                      | gn: left !important; top: auto !impo |
|                                      | rtant; vertical-align: baseline !imp |
|                                      | ortant; width: auto !important; box- |
|                                      | sizing: content-box !important; font |
|                                      | -family: Consolas, 'Bitstream Vera S |
|                                      | ans Mono', 'Courier New', Courier, m |
|                                      | onospace !important; font-weight: no |
|                                      | rmal !important; font-style: normal  |
|                                      | !important; font-size: 1em !importan |
|                                      | t; min-height: auto !important; back |
|                                      | ground: none !important;"}`Console.W |
|                                      | riteLine(readdata);`{style="margin:  |
|                                      | 0px !important; padding: 0px !import |
|                                      | ant; white-space: nowrap; border: 0p |
|                                      | x !important; border-radius: 0px !im |
|                                      | portant; bottom: auto !important; fl |
|                                      | oat: none !important; height: auto ! |
|                                      | important; left: auto !important; ou |
|                                      | tline: 0px !important; overflow: vis |
|                                      | ible !important; position: static !i |
|                                      | mportant; right: auto !important; te |
|                                      | xt-align: left !important; top: auto |
|                                      |  !important; vertical-align: baselin |
|                                      | e !important; width: auto !important |
|                                      | ; box-sizing: content-box !important |
|                                      | ; font-family: Consolas, 'Bitstream  |
|                                      | Vera Sans Mono', 'Courier New', Cour |
|                                      | ier, monospace !important; font-weig |
|                                      | ht: normal !important; font-style: n |
|                                      | ormal !important; font-size: 1em !im |
|                                      | portant; min-height: auto !important |
|                                      | ; color: rgb(0, 0, 0) !important; ba |
|                                      | ckground: none !important;"}         |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="margin: 0px !important; paddi |
|                                      | ng: 0px 1em !important; border-radiu |
|                                      | s: 0px !important; border: 0px !impo |
|                                      | rtant; bottom: auto !important; floa |
|                                      | t: none !important; height: auto !im |
|                                      | portant; left: auto !important; outl |
|                                      | ine: 0px !important; overflow: visib |
|                                      | le !important; position: static !imp |
|                                      | ortant; right: auto !important; text |
|                                      | -align: left !important; top: auto ! |
|                                      | important; vertical-align: baseline  |
|                                      | !important; width: auto !important;  |
|                                      | box-sizing: content-box !important;  |
|                                      | font-family: Consolas, 'Bitstream Ve |
|                                      | ra Sans Mono', 'Courier New', Courie |
|                                      | r, monospace !important; font-weight |
|                                      | : normal !important; font-style: nor |
|                                      | mal !important; font-size: 1em !impo |
|                                      | rtant; min-height: auto !important;  |
|                                      | white-space: pre !important; backgro |
|                                      | und: none rgb(248, 248, 248) !import |
|                                      | ant;">                               |
|                                      |                                      |
|                                      | `            `{style="margin: 0px !i |
|                                      | mportant; padding: 0px !important; w |
|                                      | hite-space: nowrap; border: 0px !imp |
|                                      | ortant; border-radius: 0px !importan |
|                                      | t; bottom: auto !important; float: n |
|                                      | one !important; height: auto !import |
|                                      | ant; left: auto !important; outline: |
|                                      |  0px !important; overflow: visible ! |
|                                      | important; position: static !importa |
|                                      | nt; right: auto !important; text-ali |
|                                      | gn: left !important; top: auto !impo |
|                                      | rtant; vertical-align: baseline !imp |
|                                      | ortant; width: auto !important; box- |
|                                      | sizing: content-box !important; font |
|                                      | -family: Consolas, 'Bitstream Vera S |
|                                      | ans Mono', 'Courier New', Courier, m |
|                                      | onospace !important; font-weight: no |
|                                      | rmal !important; font-style: normal  |
|                                      | !important; font-size: 1em !importan |
|                                      | t; min-height: auto !important; back |
|                                      | ground: none !important;"}`Console.R |
|                                      | eadLine();`{style="margin: 0px !impo |
|                                      | rtant; padding: 0px !important; whit |
|                                      | e-space: nowrap; border: 0px !import |
|                                      | ant; border-radius: 0px !important;  |
|                                      | bottom: auto !important; float: none |
|                                      |  !important; height: auto !important |
|                                      | ; left: auto !important; outline: 0p |
|                                      | x !important; overflow: visible !imp |
|                                      | ortant; position: static !important; |
|                                      |  right: auto !important; text-align: |
|                                      |  left !important; top: auto !importa |
|                                      | nt; vertical-align: baseline !import |
|                                      | ant; width: auto !important; box-siz |
|                                      | ing: content-box !important; font-fa |
|                                      | mily: Consolas, 'Bitstream Vera Sans |
|                                      |  Mono', 'Courier New', Courier, mono |
|                                      | space !important; font-weight: norma |
|                                      | l !important; font-style: normal !im |
|                                      | portant; font-size: 1em !important;  |
|                                      | min-height: auto !important; color:  |
|                                      | rgb(0, 0, 0) !important; background: |
|                                      |  none !important;"}                  |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="margin: 0px !important; paddi |
|                                      | ng: 0px 1em !important; border-radiu |
|                                      | s: 0px !important; border: 0px !impo |
|                                      | rtant; bottom: auto !important; floa |
|                                      | t: none !important; height: auto !im |
|                                      | portant; left: auto !important; outl |
|                                      | ine: 0px !important; overflow: visib |
|                                      | le !important; position: static !imp |
|                                      | ortant; right: auto !important; text |
|                                      | -align: left !important; top: auto ! |
|                                      | important; vertical-align: baseline  |
|                                      | !important; width: auto !important;  |
|                                      | box-sizing: content-box !important;  |
|                                      | font-family: Consolas, 'Bitstream Ve |
|                                      | ra Sans Mono', 'Courier New', Courie |
|                                      | r, monospace !important; font-weight |
|                                      | : normal !important; font-style: nor |
|                                      | mal !important; font-size: 1em !impo |
|                                      | rtant; min-height: auto !important;  |
|                                      | white-space: pre !important; backgro |
|                                      | und: none rgb(255, 255, 255) !import |
|                                      | ant;">                               |
|                                      |                                      |
|                                      | `        `{style="margin: 0px !impor |
|                                      | tant; padding: 0px !important; white |
|                                      | -space: nowrap; border: 0px !importa |
|                                      | nt; border-radius: 0px !important; b |
|                                      | ottom: auto !important; float: none  |
|                                      | !important; height: auto !important; |
|                                      |  left: auto !important; outline: 0px |
|                                      |  !important; overflow: visible !impo |
|                                      | rtant; position: static !important;  |
|                                      | right: auto !important; text-align:  |
|                                      | left !important; top: auto !importan |
|                                      | t; vertical-align: baseline !importa |
|                                      | nt; width: auto !important; box-sizi |
|                                      | ng: content-box !important; font-fam |
|                                      | ily: Consolas, 'Bitstream Vera Sans  |
|                                      | Mono', 'Courier New', Courier, monos |
|                                      | pace !important; font-weight: normal |
|                                      |  !important; font-style: normal !imp |
|                                      | ortant; font-size: 1em !important; m |
|                                      | in-height: auto !important; backgrou |
|                                      | nd: none !important;"}`}`{style="mar |
|                                      | gin: 0px !important; padding: 0px !i |
|                                      | mportant; white-space: nowrap; borde |
|                                      | r: 0px !important; border-radius: 0p |
|                                      | x !important; bottom: auto !importan |
|                                      | t; float: none !important; height: a |
|                                      | uto !important; left: auto !importan |
|                                      | t; outline: 0px !important; overflow |
|                                      | : visible !important; position: stat |
|                                      | ic !important; right: auto !importan |
|                                      | t; text-align: left !important; top: |
|                                      |  auto !important; vertical-align: ba |
|                                      | seline !important; width: auto !impo |
|                                      | rtant; box-sizing: content-box !impo |
|                                      | rtant; font-family: Consolas, 'Bitst |
|                                      | ream Vera Sans Mono', 'Courier New', |
|                                      |  Courier, monospace !important; font |
|                                      | -weight: normal !important; font-sty |
|                                      | le: normal !important; font-size: 1e |
|                                      | m !important; min-height: auto !impo |
|                                      | rtant; color: rgb(0, 0, 0) !importan |
|                                      | t; background: none !important;"}    |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="margin: 0px !important; paddi |
|                                      | ng: 0px 1em !important; border-radiu |
|                                      | s: 0px !important; border: 0px !impo |
|                                      | rtant; bottom: auto !important; floa |
|                                      | t: none !important; height: auto !im |
|                                      | portant; left: auto !important; outl |
|                                      | ine: 0px !important; overflow: visib |
|                                      | le !important; position: static !imp |
|                                      | ortant; right: auto !important; text |
|                                      | -align: left !important; top: auto ! |
|                                      | important; vertical-align: baseline  |
|                                      | !important; width: auto !important;  |
|                                      | box-sizing: content-box !important;  |
|                                      | font-family: Consolas, 'Bitstream Ve |
|                                      | ra Sans Mono', 'Courier New', Courie |
|                                      | r, monospace !important; font-weight |
|                                      | : normal !important; font-style: nor |
|                                      | mal !important; font-size: 1em !impo |
|                                      | rtant; min-height: auto !important;  |
|                                      | white-space: pre !important; backgro |
|                                      | und: none rgb(248, 248, 248) !import |
|                                      | ant;">                               |
|                                      |                                      |
|                                      | `    `{style="margin: 0px !important |
|                                      | ; padding: 0px !important; white-spa |
|                                      | ce: nowrap; border: 0px !important;  |
|                                      | border-radius: 0px !important; botto |
|                                      | m: auto !important; float: none !imp |
|                                      | ortant; height: auto !important; lef |
|                                      | t: auto !important; outline: 0px !im |
|                                      | portant; overflow: visible !importan |
|                                      | t; position: static !important; righ |
|                                      | t: auto !important; text-align: left |
|                                      |  !important; top: auto !important; v |
|                                      | ertical-align: baseline !important;  |
|                                      | width: auto !important; box-sizing:  |
|                                      | content-box !important; font-family: |
|                                      |  Consolas, 'Bitstream Vera Sans Mono |
|                                      | ', 'Courier New', Courier, monospace |
|                                      |  !important; font-weight: normal !im |
|                                      | portant; font-style: normal !importa |
|                                      | nt; font-size: 1em !important; min-h |
|                                      | eight: auto !important; background:  |
|                                      | none !important;"}`}`{style="margin: |
|                                      |  0px !important; padding: 0px !impor |
|                                      | tant; white-space: nowrap; border: 0 |
|                                      | px !important; border-radius: 0px !i |
|                                      | mportant; bottom: auto !important; f |
|                                      | loat: none !important; height: auto  |
|                                      | !important; left: auto !important; o |
|                                      | utline: 0px !important; overflow: vi |
|                                      | sible !important; position: static ! |
|                                      | important; right: auto !important; t |
|                                      | ext-align: left !important; top: aut |
|                                      | o !important; vertical-align: baseli |
|                                      | ne !important; width: auto !importan |
|                                      | t; box-sizing: content-box !importan |
|                                      | t; font-family: Consolas, 'Bitstream |
|                                      |  Vera Sans Mono', 'Courier New', Cou |
|                                      | rier, monospace !important; font-wei |
|                                      | ght: normal !important; font-style:  |
|                                      | normal !important; font-size: 1em !i |
|                                      | mportant; min-height: auto !importan |
|                                      | t; color: rgb(0, 0, 0) !important; b |
|                                      | ackground: none !important;"}        |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="margin: 0px !important; paddi |
|                                      | ng: 0px 1em !important; border-radiu |
|                                      | s: 0px !important; border: 0px !impo |
|                                      | rtant; bottom: auto !important; floa |
|                                      | t: none !important; height: auto !im |
|                                      | portant; left: auto !important; outl |
|                                      | ine: 0px !important; overflow: visib |
|                                      | le !important; position: static !imp |
|                                      | ortant; right: auto !important; text |
|                                      | -align: left !important; top: auto ! |
|                                      | important; vertical-align: baseline  |
|                                      | !important; width: auto !important;  |
|                                      | box-sizing: content-box !important;  |
|                                      | font-family: Consolas, 'Bitstream Ve |
|                                      | ra Sans Mono', 'Courier New', Courie |
|                                      | r, monospace !important; font-weight |
|                                      | : normal !important; font-style: nor |
|                                      | mal !important; font-size: 1em !impo |
|                                      | rtant; min-height: auto !important;  |
|                                      | white-space: pre !important; backgro |
|                                      | und: none rgb(255, 255, 255) !import |
|                                      | ant;">                               |
|                                      |                                      |
|                                      | `}`{style="margin: 0px !important; p |
|                                      | adding: 0px !important; white-space: |
|                                      |  nowrap; border: 0px !important; bor |
|                                      | der-radius: 0px !important; bottom:  |
|                                      | auto !important; float: none !import |
|                                      | ant; height: auto !important; left:  |
|                                      | auto !important; outline: 0px !impor |
|                                      | tant; overflow: visible !important;  |
|                                      | position: static !important; right:  |
|                                      | auto !important; text-align: left !i |
|                                      | mportant; top: auto !important; vert |
|                                      | ical-align: baseline !important; wid |
|                                      | th: auto !important; box-sizing: con |
|                                      | tent-box !important; font-family: Co |
|                                      | nsolas, 'Bitstream Vera Sans Mono',  |
|                                      | 'Courier New', Courier, monospace !i |
|                                      | mportant; font-weight: normal !impor |
|                                      | tant; font-style: normal !important; |
|                                      |  font-size: 1em !important; min-heig |
|                                      | ht: auto !important; color: rgb(0, 0 |
|                                      | , 0) !important; background: none !i |
|                                      | mportant;"}                          |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+

</div>

</div>

</div>

<div
style="margin: 0px 0px 5pt; padding: 0px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255);">

<div>

**XML序列化：**

根据MSDN的描述，“**XML序列化**将一个对象或参数的公开字段和属性以及方法的返回值转换（序列化）成遵循XSD文档标准的XML流。因为XML是一个开放的标准，XML能被任何需要的程序处理，而不管在什么平台下，因此XML序列化被用到带有公开的属性和字段的强类型类中，它的这些发生和字段被转换成序列化的格式（在这里是XML）存储或传输。”

我们必须添加**System.XML.Serialization**引用以使用**XML序列化**。使用**XML序列化**的基础是**XmlSerializer**。下面的代码是在.Net中使用**XmlSerializer**类序列化string对象。

<div
style="margin: 0px; padding: 0px; color: rgb(0, 0, 0); font-family: 'Microsoft YaHei', Verdana, sans-serif, SimSun; font-size: 14px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: auto; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255);">

<div
style="margin: 1em 0px !important; padding: 0px; width: 733px; position: relative !important; overflow: auto !important; font-size: 1em !important; background-color: rgb(255, 255, 255) !important;">

<div
style="margin: 0px !important; padding: 5px 0px 5px 5px; border-radius: 0px !important; border: 1px solid rgb(231, 229, 220) !important; bottom: auto !important; float: none !important; height: 11px !important; left: auto !important; outline: 0px !important; overflow: hidden; position: absolute !important; right: 1px !important; text-align: left !important; top: 1px !important; vertical-align: baseline !important; width: 11px !important; box-sizing: content-box !important; font-family: Consolas, 'Bitstream Vera Sans Mono', 'Courier New', Courier, monospace !important; font-weight: normal !important; font-style: normal !important; font-size: 10px !important; min-height: auto !important; color: white !important; z-index: 10 !important; background: rgb(248, 248, 248) !important;">

<div>

<span
style="margin: 0px; padding: 0px;">[?](http://www.oschina.net/translate/serialization-in-csharp#)</span>

</div>

</div>

+--------------------------------------+--------------------------------------+
| <div                                 | <div                                 |
| style="margin: 0px !important; paddi | style="margin: 0px !important; paddi |
| ng: 0px 0.5em 0px 1em !important; bo | ng: 0px !important; border-radius: 0 |
| rder-radius: 0px !important; border- | px !important; border: 0px !importan |
| width: 0px 3px 0px 0px !important; b | t; bottom: auto !important; float: n |
| order-right-style: solid !important; | one !important; height: auto !import |
|  border-right-color: rgb(108, 226, 1 | ant; left: auto !important; outline: |
| 08) !important; bottom: auto !import |  0px !important; overflow: visible ! |
| ant; float: none !important; height: | important; position: relative !impor |
|  auto !important; left: auto !import | tant; right: auto !important; text-a |
| ant; outline: 0px !important; overfl | lign: left !important; top: auto !im |
| ow: visible !important; position: st | portant; vertical-align: baseline !i |
| atic !important; right: auto !import | mportant; width: auto !important; bo |
| ant; text-align: right !important; t | x-sizing: content-box !important; fo |
| op: auto !important; vertical-align: | nt-family: Consolas, 'Bitstream Vera |
|  baseline !important; width: auto !i |  Sans Mono', 'Courier New', Courier, |
| mportant; box-sizing: content-box !i |  monospace !important; font-weight:  |
| mportant; font-family: Consolas, 'Bi | normal !important; font-style: norma |
| tstream Vera Sans Mono', 'Courier Ne | l !important; font-size: 1em !import |
| w', Courier, monospace !important; f | ant; min-height: auto !important; ba |
| ont-weight: normal !important; font- | ckground: none !important;">         |
| style: normal !important; font-size: |                                      |
|  1em !important; min-height: auto !i | <div                                 |
| mportant; white-space: pre !importan | style="margin: 0px !important; paddi |
| t; background: none rgb(248, 248, 24 | ng: 0px 1em !important; border-radiu |
| 8) !important;">                     | s: 0px !important; border: 0px !impo |
|                                      | rtant; bottom: auto !important; floa |
| 1                                    | t: none !important; height: auto !im |
|                                      | portant; left: auto !important; outl |
| </div>                               | ine: 0px !important; overflow: visib |
|                                      | le !important; position: static !imp |
| <div                                 | ortant; right: auto !important; text |
| style="margin: 0px !important; paddi | -align: left !important; top: auto ! |
| ng: 0px 0.5em 0px 1em !important; bo | important; vertical-align: baseline  |
| rder-radius: 0px !important; border- | !important; width: auto !important;  |
| width: 0px 3px 0px 0px !important; b | box-sizing: content-box !important;  |
| order-right-style: solid !important; | font-family: Consolas, 'Bitstream Ve |
|  border-right-color: rgb(108, 226, 1 | ra Sans Mono', 'Courier New', Courie |
| 08) !important; bottom: auto !import | r, monospace !important; font-weight |
| ant; float: none !important; height: | : normal !important; font-style: nor |
|  auto !important; left: auto !import | mal !important; font-size: 1em !impo |
| ant; outline: 0px !important; overfl | rtant; min-height: auto !important;  |
| ow: visible !important; position: st | white-space: pre !important; backgro |
| atic !important; right: auto !import | und: none rgb(248, 248, 248) !import |
| ant; text-align: right !important; t | ant;">                               |
| op: auto !important; vertical-align: |                                      |
|  baseline !important; width: auto !i | `using`{style="margin: 0px !importan |
| mportant; box-sizing: content-box !i | t; padding: 0px !important; white-sp |
| mportant; font-family: Consolas, 'Bi | ace: nowrap; border: 0px !important; |
| tstream Vera Sans Mono', 'Courier Ne |  border-radius: 0px !important; bott |
| w', Courier, monospace !important; f | om: auto !important; float: none !im |
| ont-weight: normal !important; font- | portant; height: auto !important; le |
| style: normal !important; font-size: | ft: auto !important; outline: 0px !i |
|  1em !important; min-height: auto !i | mportant; overflow: visible !importa |
| mportant; white-space: pre !importan | nt; position: static !important; rig |
| t; background: none rgb(255, 255, 25 | ht: auto !important; text-align: lef |
| 5) !important;">                     | t !important; top: auto !important;  |
|                                      | vertical-align: baseline !important; |
| 2                                    |  width: auto !important; box-sizing: |
|                                      |  content-box !important; font-family |
| </div>                               | : Consolas, 'Bitstream Vera Sans Mon |
|                                      | o', 'Courier New', Courier, monospac |
| <div                                 | e !important; font-weight: bold !imp |
| style="margin: 0px !important; paddi | ortant; font-style: normal !importan |
| ng: 0px 0.5em 0px 1em !important; bo | t; font-size: 1em !important; min-he |
| rder-radius: 0px !important; border- | ight: auto !important; color: rgb(0, |
| width: 0px 3px 0px 0px !important; b |  102, 153) !important; background: n |
| order-right-style: solid !important; | one !important;"}                    |
|  border-right-color: rgb(108, 226, 1 | `System;`{style="margin: 0px !import |
| 08) !important; bottom: auto !import | ant; padding: 0px !important; white- |
| ant; float: none !important; height: | space: nowrap; border: 0px !importan |
|  auto !important; left: auto !import | t; border-radius: 0px !important; bo |
| ant; outline: 0px !important; overfl | ttom: auto !important; float: none ! |
| ow: visible !important; position: st | important; height: auto !important;  |
| atic !important; right: auto !import | left: auto !important; outline: 0px  |
| ant; text-align: right !important; t | !important; overflow: visible !impor |
| op: auto !important; vertical-align: | tant; position: static !important; r |
|  baseline !important; width: auto !i | ight: auto !important; text-align: l |
| mportant; box-sizing: content-box !i | eft !important; top: auto !important |
| mportant; font-family: Consolas, 'Bi | ; vertical-align: baseline !importan |
| tstream Vera Sans Mono', 'Courier Ne | t; width: auto !important; box-sizin |
| w', Courier, monospace !important; f | g: content-box !important; font-fami |
| ont-weight: normal !important; font- | ly: Consolas, 'Bitstream Vera Sans M |
| style: normal !important; font-size: | ono', 'Courier New', Courier, monosp |
|  1em !important; min-height: auto !i | ace !important; font-weight: normal  |
| mportant; white-space: pre !importan | !important; font-style: normal !impo |
| t; background: none rgb(248, 248, 24 | rtant; font-size: 1em !important; mi |
| 8) !important;">                     | n-height: auto !important; color: rg |
|                                      | b(0, 0, 0) !important; background: n |
| 3                                    | one !important;"}                    |
|                                      |                                      |
| </div>                               | </div>                               |
|                                      |                                      |
| <div                                 | <div                                 |
| style="margin: 0px !important; paddi | style="margin: 0px !important; paddi |
| ng: 0px 0.5em 0px 1em !important; bo | ng: 0px 1em !important; border-radiu |
| rder-radius: 0px !important; border- | s: 0px !important; border: 0px !impo |
| width: 0px 3px 0px 0px !important; b | rtant; bottom: auto !important; floa |
| order-right-style: solid !important; | t: none !important; height: auto !im |
|  border-right-color: rgb(108, 226, 1 | portant; left: auto !important; outl |
| 08) !important; bottom: auto !import | ine: 0px !important; overflow: visib |
| ant; float: none !important; height: | le !important; position: static !imp |
|  auto !important; left: auto !import | ortant; right: auto !important; text |
| ant; outline: 0px !important; overfl | -align: left !important; top: auto ! |
| ow: visible !important; position: st | important; vertical-align: baseline  |
| atic !important; right: auto !import | !important; width: auto !important;  |
| ant; text-align: right !important; t | box-sizing: content-box !important;  |
| op: auto !important; vertical-align: | font-family: Consolas, 'Bitstream Ve |
|  baseline !important; width: auto !i | ra Sans Mono', 'Courier New', Courie |
| mportant; box-sizing: content-box !i | r, monospace !important; font-weight |
| mportant; font-family: Consolas, 'Bi | : normal !important; font-style: nor |
| tstream Vera Sans Mono', 'Courier Ne | mal !important; font-size: 1em !impo |
| w', Courier, monospace !important; f | rtant; min-height: auto !important;  |
| ont-weight: normal !important; font- | white-space: pre !important; backgro |
| style: normal !important; font-size: | und: none rgb(255, 255, 255) !import |
|  1em !important; min-height: auto !i | ant;">                               |
| mportant; white-space: pre !importan |                                      |
| t; background: none rgb(255, 255, 25 | `using`{style="margin: 0px !importan |
| 5) !important;">                     | t; padding: 0px !important; white-sp |
|                                      | ace: nowrap; border: 0px !important; |
| 4                                    |  border-radius: 0px !important; bott |
|                                      | om: auto !important; float: none !im |
| </div>                               | portant; height: auto !important; le |
|                                      | ft: auto !important; outline: 0px !i |
| <div                                 | mportant; overflow: visible !importa |
| style="margin: 0px !important; paddi | nt; position: static !important; rig |
| ng: 0px 0.5em 0px 1em !important; bo | ht: auto !important; text-align: lef |
| rder-radius: 0px !important; border- | t !important; top: auto !important;  |
| width: 0px 3px 0px 0px !important; b | vertical-align: baseline !important; |
| order-right-style: solid !important; |  width: auto !important; box-sizing: |
|  border-right-color: rgb(108, 226, 1 |  content-box !important; font-family |
| 08) !important; bottom: auto !import | : Consolas, 'Bitstream Vera Sans Mon |
| ant; float: none !important; height: | o', 'Courier New', Courier, monospac |
|  auto !important; left: auto !import | e !important; font-weight: bold !imp |
| ant; outline: 0px !important; overfl | ortant; font-style: normal !importan |
| ow: visible !important; position: st | t; font-size: 1em !important; min-he |
| atic !important; right: auto !import | ight: auto !important; color: rgb(0, |
| ant; text-align: right !important; t |  102, 153) !important; background: n |
| op: auto !important; vertical-align: | one !important;"}                    |
|  baseline !important; width: auto !i | `System.IO;`{style="margin: 0px !imp |
| mportant; box-sizing: content-box !i | ortant; padding: 0px !important; whi |
| mportant; font-family: Consolas, 'Bi | te-space: nowrap; border: 0px !impor |
| tstream Vera Sans Mono', 'Courier Ne | tant; border-radius: 0px !important; |
| w', Courier, monospace !important; f |  bottom: auto !important; float: non |
| ont-weight: normal !important; font- | e !important; height: auto !importan |
| style: normal !important; font-size: | t; left: auto !important; outline: 0 |
|  1em !important; min-height: auto !i | px !important; overflow: visible !im |
| mportant; white-space: pre !importan | portant; position: static !important |
| t; background: none rgb(248, 248, 24 | ; right: auto !important; text-align |
| 8) !important;">                     | : left !important; top: auto !import |
|                                      | ant; vertical-align: baseline !impor |
| 5                                    | tant; width: auto !important; box-si |
|                                      | zing: content-box !important; font-f |
| </div>                               | amily: Consolas, 'Bitstream Vera San |
|                                      | s Mono', 'Courier New', Courier, mon |
| <div                                 | ospace !important; font-weight: norm |
| style="margin: 0px !important; paddi | al !important; font-style: normal !i |
| ng: 0px 0.5em 0px 1em !important; bo | mportant; font-size: 1em !important; |
| rder-radius: 0px !important; border- |  min-height: auto !important; color: |
| width: 0px 3px 0px 0px !important; b |  rgb(0, 0, 0) !important; background |
| order-right-style: solid !important; | : none !important;"}                 |
|  border-right-color: rgb(108, 226, 1 |                                      |
| 08) !important; bottom: auto !import | </div>                               |
| ant; float: none !important; height: |                                      |
|  auto !important; left: auto !import | <div                                 |
| ant; outline: 0px !important; overfl | style="margin: 0px !important; paddi |
| ow: visible !important; position: st | ng: 0px 1em !important; border-radiu |
| atic !important; right: auto !import | s: 0px !important; border: 0px !impo |
| ant; text-align: right !important; t | rtant; bottom: auto !important; floa |
| op: auto !important; vertical-align: | t: none !important; height: auto !im |
|  baseline !important; width: auto !i | portant; left: auto !important; outl |
| mportant; box-sizing: content-box !i | ine: 0px !important; overflow: visib |
| mportant; font-family: Consolas, 'Bi | le !important; position: static !imp |
| tstream Vera Sans Mono', 'Courier Ne | ortant; right: auto !important; text |
| w', Courier, monospace !important; f | -align: left !important; top: auto ! |
| ont-weight: normal !important; font- | important; vertical-align: baseline  |
| style: normal !important; font-size: | !important; width: auto !important;  |
|  1em !important; min-height: auto !i | box-sizing: content-box !important;  |
| mportant; white-space: pre !importan | font-family: Consolas, 'Bitstream Ve |
| t; background: none rgb(255, 255, 25 | ra Sans Mono', 'Courier New', Courie |
| 5) !important;">                     | r, monospace !important; font-weight |
|                                      | : normal !important; font-style: nor |
| 6                                    | mal !important; font-size: 1em !impo |
|                                      | rtant; min-height: auto !important;  |
| </div>                               | white-space: pre !important; backgro |
|                                      | und: none rgb(248, 248, 248) !import |
| <div                                 | ant;">                               |
| style="margin: 0px !important; paddi |                                      |
| ng: 0px 0.5em 0px 1em !important; bo | `using`{style="margin: 0px !importan |
| rder-radius: 0px !important; border- | t; padding: 0px !important; white-sp |
| width: 0px 3px 0px 0px !important; b | ace: nowrap; border: 0px !important; |
| order-right-style: solid !important; |  border-radius: 0px !important; bott |
|  border-right-color: rgb(108, 226, 1 | om: auto !important; float: none !im |
| 08) !important; bottom: auto !import | portant; height: auto !important; le |
| ant; float: none !important; height: | ft: auto !important; outline: 0px !i |
|  auto !important; left: auto !import | mportant; overflow: visible !importa |
| ant; outline: 0px !important; overfl | nt; position: static !important; rig |
| ow: visible !important; position: st | ht: auto !important; text-align: lef |
| atic !important; right: auto !import | t !important; top: auto !important;  |
| ant; text-align: right !important; t | vertical-align: baseline !important; |
| op: auto !important; vertical-align: |  width: auto !important; box-sizing: |
|  baseline !important; width: auto !i |  content-box !important; font-family |
| mportant; box-sizing: content-box !i | : Consolas, 'Bitstream Vera Sans Mon |
| mportant; font-family: Consolas, 'Bi | o', 'Courier New', Courier, monospac |
| tstream Vera Sans Mono', 'Courier Ne | e !important; font-weight: bold !imp |
| w', Courier, monospace !important; f | ortant; font-style: normal !importan |
| ont-weight: normal !important; font- | t; font-size: 1em !important; min-he |
| style: normal !important; font-size: | ight: auto !important; color: rgb(0, |
|  1em !important; min-height: auto !i |  102, 153) !important; background: n |
| mportant; white-space: pre !importan | one !important;"}                    |
| t; background: none rgb(248, 248, 24 | `System.Xml.Serialization;`{style="m |
| 8) !important;">                     | argin: 0px !important; padding: 0px  |
|                                      | !important; white-space: nowrap; bor |
| 7                                    | der: 0px !important; border-radius:  |
|                                      | 0px !important; bottom: auto !import |
| </div>                               | ant; float: none !important; height: |
|                                      |  auto !important; left: auto !import |
| <div                                 | ant; outline: 0px !important; overfl |
| style="margin: 0px !important; paddi | ow: visible !important; position: st |
| ng: 0px 0.5em 0px 1em !important; bo | atic !important; right: auto !import |
| rder-radius: 0px !important; border- | ant; text-align: left !important; to |
| width: 0px 3px 0px 0px !important; b | p: auto !important; vertical-align:  |
| order-right-style: solid !important; | baseline !important; width: auto !im |
|  border-right-color: rgb(108, 226, 1 | portant; box-sizing: content-box !im |
| 08) !important; bottom: auto !import | portant; font-family: Consolas, 'Bit |
| ant; float: none !important; height: | stream Vera Sans Mono', 'Courier New |
|  auto !important; left: auto !import | ', Courier, monospace !important; fo |
| ant; outline: 0px !important; overfl | nt-weight: normal !important; font-s |
| ow: visible !important; position: st | tyle: normal !important; font-size:  |
| atic !important; right: auto !import | 1em !important; min-height: auto !im |
| ant; text-align: right !important; t | portant; color: rgb(0, 0, 0) !import |
| op: auto !important; vertical-align: | ant; background: none !important;"}  |
|  baseline !important; width: auto !i |                                      |
| mportant; box-sizing: content-box !i | </div>                               |
| mportant; font-family: Consolas, 'Bi |                                      |
| tstream Vera Sans Mono', 'Courier Ne | <div                                 |
| w', Courier, monospace !important; f | style="margin: 0px !important; paddi |
| ont-weight: normal !important; font- | ng: 0px 1em !important; border-radiu |
| style: normal !important; font-size: | s: 0px !important; border: 0px !impo |
|  1em !important; min-height: auto !i | rtant; bottom: auto !important; floa |
| mportant; white-space: pre !importan | t: none !important; height: auto !im |
| t; background: none rgb(255, 255, 25 | portant; left: auto !important; outl |
| 5) !important;">                     | ine: 0px !important; overflow: visib |
|                                      | le !important; position: static !imp |
| 8                                    | ortant; right: auto !important; text |
|                                      | -align: left !important; top: auto ! |
| </div>                               | important; vertical-align: baseline  |
|                                      | !important; width: auto !important;  |
| <div                                 | box-sizing: content-box !important;  |
| style="margin: 0px !important; paddi | font-family: Consolas, 'Bitstream Ve |
| ng: 0px 0.5em 0px 1em !important; bo | ra Sans Mono', 'Courier New', Courie |
| rder-radius: 0px !important; border- | r, monospace !important; font-weight |
| width: 0px 3px 0px 0px !important; b | : normal !important; font-style: nor |
| order-right-style: solid !important; | mal !important; font-size: 1em !impo |
|  border-right-color: rgb(108, 226, 1 | rtant; min-height: auto !important;  |
| 08) !important; bottom: auto !import | white-space: pre !important; backgro |
| ant; float: none !important; height: | und: none rgb(255, 255, 255) !import |
|  auto !important; left: auto !import | ant;">                               |
| ant; outline: 0px !important; overfl |                                      |
| ow: visible !important; position: st |                                      |
| atic !important; right: auto !import |                                      |
| ant; text-align: right !important; t | </div>                               |
| op: auto !important; vertical-align: |                                      |
|  baseline !important; width: auto !i | <div                                 |
| mportant; box-sizing: content-box !i | style="margin: 0px !important; paddi |
| mportant; font-family: Consolas, 'Bi | ng: 0px 1em !important; border-radiu |
| tstream Vera Sans Mono', 'Courier Ne | s: 0px !important; border: 0px !impo |
| w', Courier, monospace !important; f | rtant; bottom: auto !important; floa |
| ont-weight: normal !important; font- | t: none !important; height: auto !im |
| style: normal !important; font-size: | portant; left: auto !important; outl |
|  1em !important; min-height: auto !i | ine: 0px !important; overflow: visib |
| mportant; white-space: pre !importan | le !important; position: static !imp |
| t; background: none rgb(248, 248, 24 | ortant; right: auto !important; text |
| 8) !important;">                     | -align: left !important; top: auto ! |
|                                      | important; vertical-align: baseline  |
| 9                                    | !important; width: auto !important;  |
|                                      | box-sizing: content-box !important;  |
| </div>                               | font-family: Consolas, 'Bitstream Ve |
|                                      | ra Sans Mono', 'Courier New', Courie |
| <div                                 | r, monospace !important; font-weight |
| style="margin: 0px !important; paddi | : normal !important; font-style: nor |
| ng: 0px 0.5em 0px 1em !important; bo | mal !important; font-size: 1em !impo |
| rder-radius: 0px !important; border- | rtant; min-height: auto !important;  |
| width: 0px 3px 0px 0px !important; b | white-space: pre !important; backgro |
| order-right-style: solid !important; | und: none rgb(248, 248, 248) !import |
|  border-right-color: rgb(108, 226, 1 | ant;">                               |
| 08) !important; bottom: auto !import |                                      |
| ant; float: none !important; height: |                                      |
|  auto !important; left: auto !import |                                      |
| ant; outline: 0px !important; overfl | </div>                               |
| ow: visible !important; position: st |                                      |
| atic !important; right: auto !import | <div                                 |
| ant; text-align: right !important; t | style="margin: 0px !important; paddi |
| op: auto !important; vertical-align: | ng: 0px 1em !important; border-radiu |
|  baseline !important; width: auto !i | s: 0px !important; border: 0px !impo |
| mportant; box-sizing: content-box !i | rtant; bottom: auto !important; floa |
| mportant; font-family: Consolas, 'Bi | t: none !important; height: auto !im |
| tstream Vera Sans Mono', 'Courier Ne | portant; left: auto !important; outl |
| w', Courier, monospace !important; f | ine: 0px !important; overflow: visib |
| ont-weight: normal !important; font- | le !important; position: static !imp |
| style: normal !important; font-size: | ortant; right: auto !important; text |
|  1em !important; min-height: auto !i | -align: left !important; top: auto ! |
| mportant; white-space: pre !importan | important; vertical-align: baseline  |
| t; background: none rgb(255, 255, 25 | !important; width: auto !important;  |
| 5) !important;">                     | box-sizing: content-box !important;  |
|                                      | font-family: Consolas, 'Bitstream Ve |
| 10                                   | ra Sans Mono', 'Courier New', Courie |
|                                      | r, monospace !important; font-weight |
| </div>                               | : normal !important; font-style: nor |
|                                      | mal !important; font-size: 1em !impo |
| <div                                 | rtant; min-height: auto !important;  |
| style="margin: 0px !important; paddi | white-space: pre !important; backgro |
| ng: 0px 0.5em 0px 1em !important; bo | und: none rgb(255, 255, 255) !import |
| rder-radius: 0px !important; border- | ant;">                               |
| width: 0px 3px 0px 0px !important; b |                                      |
| order-right-style: solid !important; | `namespace`{style="margin: 0px !impo |
|  border-right-color: rgb(108, 226, 1 | rtant; padding: 0px !important; whit |
| 08) !important; bottom: auto !import | e-space: nowrap; border: 0px !import |
| ant; float: none !important; height: | ant; border-radius: 0px !important;  |
|  auto !important; left: auto !import | bottom: auto !important; float: none |
| ant; outline: 0px !important; overfl |  !important; height: auto !important |
| ow: visible !important; position: st | ; left: auto !important; outline: 0p |
| atic !important; right: auto !import | x !important; overflow: visible !imp |
| ant; text-align: right !important; t | ortant; position: static !important; |
| op: auto !important; vertical-align: |  right: auto !important; text-align: |
|  baseline !important; width: auto !i |  left !important; top: auto !importa |
| mportant; box-sizing: content-box !i | nt; vertical-align: baseline !import |
| mportant; font-family: Consolas, 'Bi | ant; width: auto !important; box-siz |
| tstream Vera Sans Mono', 'Courier Ne | ing: content-box !important; font-fa |
| w', Courier, monospace !important; f | mily: Consolas, 'Bitstream Vera Sans |
| ont-weight: normal !important; font- |  Mono', 'Courier New', Courier, mono |
| style: normal !important; font-size: | space !important; font-weight: bold  |
|  1em !important; min-height: auto !i | !important; font-style: normal !impo |
| mportant; white-space: pre !importan | rtant; font-size: 1em !important; mi |
| t; background: none rgb(248, 248, 24 | n-height: auto !important; color: rg |
| 8) !important;">                     | b(0, 102, 153) !important; backgroun |
|                                      | d: none !important;"}                |
| 11                                   | `SerializationTest`{style="margin: 0 |
|                                      | px !important; padding: 0px !importa |
| </div>                               | nt; white-space: nowrap; border: 0px |
|                                      |  !important; border-radius: 0px !imp |
| <div                                 | ortant; bottom: auto !important; flo |
| style="margin: 0px !important; paddi | at: none !important; height: auto !i |
| ng: 0px 0.5em 0px 1em !important; bo | mportant; left: auto !important; out |
| rder-radius: 0px !important; border- | line: 0px !important; overflow: visi |
| width: 0px 3px 0px 0px !important; b | ble !important; position: static !im |
| order-right-style: solid !important; | portant; right: auto !important; tex |
|  border-right-color: rgb(108, 226, 1 | t-align: left !important; top: auto  |
| 08) !important; bottom: auto !import | !important; vertical-align: baseline |
| ant; float: none !important; height: |  !important; width: auto !important; |
|  auto !important; left: auto !import |  box-sizing: content-box !important; |
| ant; outline: 0px !important; overfl |  font-family: Consolas, 'Bitstream V |
| ow: visible !important; position: st | era Sans Mono', 'Courier New', Couri |
| atic !important; right: auto !import | er, monospace !important; font-weigh |
| ant; text-align: right !important; t | t: normal !important; font-style: no |
| op: auto !important; vertical-align: | rmal !important; font-size: 1em !imp |
|  baseline !important; width: auto !i | ortant; min-height: auto !important; |
| mportant; box-sizing: content-box !i |  color: rgb(0, 0, 0) !important; bac |
| mportant; font-family: Consolas, 'Bi | kground: none !important;"}          |
| tstream Vera Sans Mono', 'Courier Ne |                                      |
| w', Courier, monospace !important; f | </div>                               |
| ont-weight: normal !important; font- |                                      |
| style: normal !important; font-size: | <div                                 |
|  1em !important; min-height: auto !i | style="margin: 0px !important; paddi |
| mportant; white-space: pre !importan | ng: 0px 1em !important; border-radiu |
| t; background: none rgb(255, 255, 25 | s: 0px !important; border: 0px !impo |
| 5) !important;">                     | rtant; bottom: auto !important; floa |
|                                      | t: none !important; height: auto !im |
| 12                                   | portant; left: auto !important; outl |
|                                      | ine: 0px !important; overflow: visib |
| </div>                               | le !important; position: static !imp |
|                                      | ortant; right: auto !important; text |
| <div                                 | -align: left !important; top: auto ! |
| style="margin: 0px !important; paddi | important; vertical-align: baseline  |
| ng: 0px 0.5em 0px 1em !important; bo | !important; width: auto !important;  |
| rder-radius: 0px !important; border- | box-sizing: content-box !important;  |
| width: 0px 3px 0px 0px !important; b | font-family: Consolas, 'Bitstream Ve |
| order-right-style: solid !important; | ra Sans Mono', 'Courier New', Courie |
|  border-right-color: rgb(108, 226, 1 | r, monospace !important; font-weight |
| 08) !important; bottom: auto !import | : normal !important; font-style: nor |
| ant; float: none !important; height: | mal !important; font-size: 1em !impo |
|  auto !important; left: auto !import | rtant; min-height: auto !important;  |
| ant; outline: 0px !important; overfl | white-space: pre !important; backgro |
| ow: visible !important; position: st | und: none rgb(248, 248, 248) !import |
| atic !important; right: auto !import | ant;">                               |
| ant; text-align: right !important; t |                                      |
| op: auto !important; vertical-align: | `{`{style="margin: 0px !important; p |
|  baseline !important; width: auto !i | adding: 0px !important; white-space: |
| mportant; box-sizing: content-box !i |  nowrap; border: 0px !important; bor |
| mportant; font-family: Consolas, 'Bi | der-radius: 0px !important; bottom:  |
| tstream Vera Sans Mono', 'Courier Ne | auto !important; float: none !import |
| w', Courier, monospace !important; f | ant; height: auto !important; left:  |
| ont-weight: normal !important; font- | auto !important; outline: 0px !impor |
| style: normal !important; font-size: | tant; overflow: visible !important;  |
|  1em !important; min-height: auto !i | position: static !important; right:  |
| mportant; white-space: pre !importan | auto !important; text-align: left !i |
| t; background: none rgb(248, 248, 24 | mportant; top: auto !important; vert |
| 8) !important;">                     | ical-align: baseline !important; wid |
|                                      | th: auto !important; box-sizing: con |
| 13                                   | tent-box !important; font-family: Co |
|                                      | nsolas, 'Bitstream Vera Sans Mono',  |
| </div>                               | 'Courier New', Courier, monospace !i |
|                                      | mportant; font-weight: normal !impor |
| <div                                 | tant; font-style: normal !important; |
| style="margin: 0px !important; paddi |  font-size: 1em !important; min-heig |
| ng: 0px 0.5em 0px 1em !important; bo | ht: auto !important; color: rgb(0, 0 |
| rder-radius: 0px !important; border- | , 0) !important; background: none !i |
| width: 0px 3px 0px 0px !important; b | mportant;"}                          |
| order-right-style: solid !important; |                                      |
|  border-right-color: rgb(108, 226, 1 | </div>                               |
| 08) !important; bottom: auto !import |                                      |
| ant; float: none !important; height: | <div                                 |
|  auto !important; left: auto !import | style="margin: 0px !important; paddi |
| ant; outline: 0px !important; overfl | ng: 0px 1em !important; border-radiu |
| ow: visible !important; position: st | s: 0px !important; border: 0px !impo |
| atic !important; right: auto !import | rtant; bottom: auto !important; floa |
| ant; text-align: right !important; t | t: none !important; height: auto !im |
| op: auto !important; vertical-align: | portant; left: auto !important; outl |
|  baseline !important; width: auto !i | ine: 0px !important; overflow: visib |
| mportant; box-sizing: content-box !i | le !important; position: static !imp |
| mportant; font-family: Consolas, 'Bi | ortant; right: auto !important; text |
| tstream Vera Sans Mono', 'Courier Ne | -align: left !important; top: auto ! |
| w', Courier, monospace !important; f | important; vertical-align: baseline  |
| ont-weight: normal !important; font- | !important; width: auto !important;  |
| style: normal !important; font-size: | box-sizing: content-box !important;  |
|  1em !important; min-height: auto !i | font-family: Consolas, 'Bitstream Ve |
| mportant; white-space: pre !importan | ra Sans Mono', 'Courier New', Courie |
| t; background: none rgb(255, 255, 25 | r, monospace !important; font-weight |
| 5) !important;">                     | : normal !important; font-style: nor |
|                                      | mal !important; font-size: 1em !impo |
| 14                                   | rtant; min-height: auto !important;  |
|                                      | white-space: pre !important; backgro |
| </div>                               | und: none rgb(255, 255, 255) !import |
|                                      | ant;">                               |
| <div                                 |                                      |
| style="margin: 0px !important; paddi | `    `{style="margin: 0px !important |
| ng: 0px 0.5em 0px 1em !important; bo | ; padding: 0px !important; white-spa |
| rder-radius: 0px !important; border- | ce: nowrap; border: 0px !important;  |
| width: 0px 3px 0px 0px !important; b | border-radius: 0px !important; botto |
| order-right-style: solid !important; | m: auto !important; float: none !imp |
|  border-right-color: rgb(108, 226, 1 | ortant; height: auto !important; lef |
| 08) !important; bottom: auto !import | t: auto !important; outline: 0px !im |
| ant; float: none !important; height: | portant; overflow: visible !importan |
|  auto !important; left: auto !import | t; position: static !important; righ |
| ant; outline: 0px !important; overfl | t: auto !important; text-align: left |
| ow: visible !important; position: st |  !important; top: auto !important; v |
| atic !important; right: auto !import | ertical-align: baseline !important;  |
| ant; text-align: right !important; t | width: auto !important; box-sizing:  |
| op: auto !important; vertical-align: | content-box !important; font-family: |
|  baseline !important; width: auto !i |  Consolas, 'Bitstream Vera Sans Mono |
| mportant; box-sizing: content-box !i | ', 'Courier New', Courier, monospace |
| mportant; font-family: Consolas, 'Bi |  !important; font-weight: normal !im |
| tstream Vera Sans Mono', 'Courier Ne | portant; font-style: normal !importa |
| w', Courier, monospace !important; f | nt; font-size: 1em !important; min-h |
| ont-weight: normal !important; font- | eight: auto !important; background:  |
| style: normal !important; font-size: | none !important;"}`class`{style="mar |
|  1em !important; min-height: auto !i | gin: 0px !important; padding: 0px !i |
| mportant; white-space: pre !importan | mportant; white-space: nowrap; borde |
| t; background: none rgb(248, 248, 24 | r: 0px !important; border-radius: 0p |
| 8) !important;">                     | x !important; bottom: auto !importan |
|                                      | t; float: none !important; height: a |
| 15                                   | uto !important; left: auto !importan |
|                                      | t; outline: 0px !important; overflow |
| </div>                               | : visible !important; position: stat |
|                                      | ic !important; right: auto !importan |
| <div                                 | t; text-align: left !important; top: |
| style="margin: 0px !important; paddi |  auto !important; vertical-align: ba |
| ng: 0px 0.5em 0px 1em !important; bo | seline !important; width: auto !impo |
| rder-radius: 0px !important; border- | rtant; box-sizing: content-box !impo |
| width: 0px 3px 0px 0px !important; b | rtant; font-family: Consolas, 'Bitst |
| order-right-style: solid !important; | ream Vera Sans Mono', 'Courier New', |
|  border-right-color: rgb(108, 226, 1 |  Courier, monospace !important; font |
| 08) !important; bottom: auto !import | -weight: bold !important; font-style |
| ant; float: none !important; height: | : normal !important; font-size: 1em  |
|  auto !important; left: auto !import | !important; min-height: auto !import |
| ant; outline: 0px !important; overfl | ant; color: rgb(0, 102, 153) !import |
| ow: visible !important; position: st | ant; background: none !important;"}  |
| atic !important; right: auto !import | `Program`{style="margin: 0px !import |
| ant; text-align: right !important; t | ant; padding: 0px !important; white- |
| op: auto !important; vertical-align: | space: nowrap; border: 0px !importan |
|  baseline !important; width: auto !i | t; border-radius: 0px !important; bo |
| mportant; box-sizing: content-box !i | ttom: auto !important; float: none ! |
| mportant; font-family: Consolas, 'Bi | important; height: auto !important;  |
| tstream Vera Sans Mono', 'Courier Ne | left: auto !important; outline: 0px  |
| w', Courier, monospace !important; f | !important; overflow: visible !impor |
| ont-weight: normal !important; font- | tant; position: static !important; r |
| style: normal !important; font-size: | ight: auto !important; text-align: l |
|  1em !important; min-height: auto !i | eft !important; top: auto !important |
| mportant; white-space: pre !importan | ; vertical-align: baseline !importan |
| t; background: none rgb(255, 255, 25 | t; width: auto !important; box-sizin |
| 5) !important;">                     | g: content-box !important; font-fami |
|                                      | ly: Consolas, 'Bitstream Vera Sans M |
| 16                                   | ono', 'Courier New', Courier, monosp |
|                                      | ace !important; font-weight: normal  |
| </div>                               | !important; font-style: normal !impo |
|                                      | rtant; font-size: 1em !important; mi |
| <div                                 | n-height: auto !important; color: rg |
| style="margin: 0px !important; paddi | b(0, 0, 0) !important; background: n |
| ng: 0px 0.5em 0px 1em !important; bo | one !important;"}                    |
| rder-radius: 0px !important; border- |                                      |
| width: 0px 3px 0px 0px !important; b | </div>                               |
| order-right-style: solid !important; |                                      |
|  border-right-color: rgb(108, 226, 1 | <div                                 |
| 08) !important; bottom: auto !import | style="margin: 0px !important; paddi |
| ant; float: none !important; height: | ng: 0px 1em !important; border-radiu |
|  auto !important; left: auto !import | s: 0px !important; border: 0px !impo |
| ant; outline: 0px !important; overfl | rtant; bottom: auto !important; floa |
| ow: visible !important; position: st | t: none !important; height: auto !im |
| atic !important; right: auto !import | portant; left: auto !important; outl |
| ant; text-align: right !important; t | ine: 0px !important; overflow: visib |
| op: auto !important; vertical-align: | le !important; position: static !imp |
|  baseline !important; width: auto !i | ortant; right: auto !important; text |
| mportant; box-sizing: content-box !i | -align: left !important; top: auto ! |
| mportant; font-family: Consolas, 'Bi | important; vertical-align: baseline  |
| tstream Vera Sans Mono', 'Courier Ne | !important; width: auto !important;  |
| w', Courier, monospace !important; f | box-sizing: content-box !important;  |
| ont-weight: normal !important; font- | font-family: Consolas, 'Bitstream Ve |
| style: normal !important; font-size: | ra Sans Mono', 'Courier New', Courie |
|  1em !important; min-height: auto !i | r, monospace !important; font-weight |
| mportant; white-space: pre !importan | : normal !important; font-style: nor |
| t; background: none rgb(248, 248, 24 | mal !important; font-size: 1em !impo |
| 8) !important;">                     | rtant; min-height: auto !important;  |
|                                      | white-space: pre !important; backgro |
| 17                                   | und: none rgb(248, 248, 248) !import |
|                                      | ant;">                               |
| </div>                               |                                      |
|                                      | `    `{style="margin: 0px !important |
| <div                                 | ; padding: 0px !important; white-spa |
| style="margin: 0px !important; paddi | ce: nowrap; border: 0px !important;  |
| ng: 0px 0.5em 0px 1em !important; bo | border-radius: 0px !important; botto |
| rder-radius: 0px !important; border- | m: auto !important; float: none !imp |
| width: 0px 3px 0px 0px !important; b | ortant; height: auto !important; lef |
| order-right-style: solid !important; | t: auto !important; outline: 0px !im |
|  border-right-color: rgb(108, 226, 1 | portant; overflow: visible !importan |
| 08) !important; bottom: auto !import | t; position: static !important; righ |
| ant; float: none !important; height: | t: auto !important; text-align: left |
|  auto !important; left: auto !import |  !important; top: auto !important; v |
| ant; outline: 0px !important; overfl | ertical-align: baseline !important;  |
| ow: visible !important; position: st | width: auto !important; box-sizing:  |
| atic !important; right: auto !import | content-box !important; font-family: |
| ant; text-align: right !important; t |  Consolas, 'Bitstream Vera Sans Mono |
| op: auto !important; vertical-align: | ', 'Courier New', Courier, monospace |
|  baseline !important; width: auto !i |  !important; font-weight: normal !im |
| mportant; box-sizing: content-box !i | portant; font-style: normal !importa |
| mportant; font-family: Consolas, 'Bi | nt; font-size: 1em !important; min-h |
| tstream Vera Sans Mono', 'Courier Ne | eight: auto !important; background:  |
| w', Courier, monospace !important; f | none !important;"}`{`{style="margin: |
| ont-weight: normal !important; font- |  0px !important; padding: 0px !impor |
| style: normal !important; font-size: | tant; white-space: nowrap; border: 0 |
|  1em !important; min-height: auto !i | px !important; border-radius: 0px !i |
| mportant; white-space: pre !importan | mportant; bottom: auto !important; f |
| t; background: none rgb(255, 255, 25 | loat: none !important; height: auto  |
| 5) !important;">                     | !important; left: auto !important; o |
|                                      | utline: 0px !important; overflow: vi |
| 18                                   | sible !important; position: static ! |
|                                      | important; right: auto !important; t |
| </div>                               | ext-align: left !important; top: aut |
|                                      | o !important; vertical-align: baseli |
| <div                                 | ne !important; width: auto !importan |
| style="margin: 0px !important; paddi | t; box-sizing: content-box !importan |
| ng: 0px 0.5em 0px 1em !important; bo | t; font-family: Consolas, 'Bitstream |
| rder-radius: 0px !important; border- |  Vera Sans Mono', 'Courier New', Cou |
| width: 0px 3px 0px 0px !important; b | rier, monospace !important; font-wei |
| order-right-style: solid !important; | ght: normal !important; font-style:  |
|  border-right-color: rgb(108, 226, 1 | normal !important; font-size: 1em !i |
| 08) !important; bottom: auto !import | mportant; min-height: auto !importan |
| ant; float: none !important; height: | t; color: rgb(0, 0, 0) !important; b |
|  auto !important; left: auto !import | ackground: none !important;"}        |
| ant; outline: 0px !important; overfl |                                      |
| ow: visible !important; position: st | </div>                               |
| atic !important; right: auto !import |                                      |
| ant; text-align: right !important; t | <div                                 |
| op: auto !important; vertical-align: | style="margin: 0px !important; paddi |
|  baseline !important; width: auto !i | ng: 0px 1em !important; border-radiu |
| mportant; box-sizing: content-box !i | s: 0px !important; border: 0px !impo |
| mportant; font-family: Consolas, 'Bi | rtant; bottom: auto !important; floa |
| tstream Vera Sans Mono', 'Courier Ne | t: none !important; height: auto !im |
| w', Courier, monospace !important; f | portant; left: auto !important; outl |
| ont-weight: normal !important; font- | ine: 0px !important; overflow: visib |
| style: normal !important; font-size: | le !important; position: static !imp |
|  1em !important; min-height: auto !i | ortant; right: auto !important; text |
| mportant; white-space: pre !importan | -align: left !important; top: auto ! |
| t; background: none rgb(248, 248, 24 | important; vertical-align: baseline  |
| 8) !important;">                     | !important; width: auto !important;  |
|                                      | box-sizing: content-box !important;  |
| 19                                   | font-family: Consolas, 'Bitstream Ve |
|                                      | ra Sans Mono', 'Courier New', Courie |
| </div>                               | r, monospace !important; font-weight |
|                                      | : normal !important; font-style: nor |
| <div                                 | mal !important; font-size: 1em !impo |
| style="margin: 0px !important; paddi | rtant; min-height: auto !important;  |
| ng: 0px 0.5em 0px 1em !important; bo | white-space: pre !important; backgro |
| rder-radius: 0px !important; border- | und: none rgb(255, 255, 255) !import |
| width: 0px 3px 0px 0px !important; b | ant;">                               |
| order-right-style: solid !important; |                                      |
|  border-right-color: rgb(108, 226, 1 | `        `{style="margin: 0px !impor |
| 08) !important; bottom: auto !import | tant; padding: 0px !important; white |
| ant; float: none !important; height: | -space: nowrap; border: 0px !importa |
|  auto !important; left: auto !import | nt; border-radius: 0px !important; b |
| ant; outline: 0px !important; overfl | ottom: auto !important; float: none  |
| ow: visible !important; position: st | !important; height: auto !important; |
| atic !important; right: auto !import |  left: auto !important; outline: 0px |
| ant; text-align: right !important; t |  !important; overflow: visible !impo |
| op: auto !important; vertical-align: | rtant; position: static !important;  |
|  baseline !important; width: auto !i | right: auto !important; text-align:  |
| mportant; box-sizing: content-box !i | left !important; top: auto !importan |
| mportant; font-family: Consolas, 'Bi | t; vertical-align: baseline !importa |
| tstream Vera Sans Mono', 'Courier Ne | nt; width: auto !important; box-sizi |
| w', Courier, monospace !important; f | ng: content-box !important; font-fam |
| ont-weight: normal !important; font- | ily: Consolas, 'Bitstream Vera Sans  |
| style: normal !important; font-size: | Mono', 'Courier New', Courier, monos |
|  1em !important; min-height: auto !i | pace !important; font-weight: normal |
| mportant; white-space: pre !importan |  !important; font-style: normal !imp |
| t; background: none rgb(255, 255, 25 | ortant; font-size: 1em !important; m |
| 5) !important;">                     | in-height: auto !important; backgrou |
|                                      | nd: none !important;"}`static`{style |
| 20                                   | ="margin: 0px !important; padding: 0 |
|                                      | px !important; white-space: nowrap;  |
| </div>                               | border: 0px !important; border-radiu |
|                                      | s: 0px !important; bottom: auto !imp |
| <div                                 | ortant; float: none !important; heig |
| style="margin: 0px !important; paddi | ht: auto !important; left: auto !imp |
| ng: 0px 0.5em 0px 1em !important; bo | ortant; outline: 0px !important; ove |
| rder-radius: 0px !important; border- | rflow: visible !important; position: |
| width: 0px 3px 0px 0px !important; b |  static !important; right: auto !imp |
| order-right-style: solid !important; | ortant; text-align: left !important; |
|  border-right-color: rgb(108, 226, 1 |  top: auto !important; vertical-alig |
| 08) !important; bottom: auto !import | n: baseline !important; width: auto  |
| ant; float: none !important; height: | !important; box-sizing: content-box  |
|  auto !important; left: auto !import | !important; font-family: Consolas, ' |
| ant; outline: 0px !important; overfl | Bitstream Vera Sans Mono', 'Courier  |
| ow: visible !important; position: st | New', Courier, monospace !important; |
| atic !important; right: auto !import |  font-weight: bold !important; font- |
| ant; text-align: right !important; t | style: normal !important; font-size: |
| op: auto !important; vertical-align: |  1em !important; min-height: auto !i |
|  baseline !important; width: auto !i | mportant; color: rgb(0, 102, 153) !i |
| mportant; box-sizing: content-box !i | mportant; background: none !importan |
| mportant; font-family: Consolas, 'Bi | t;"}                                 |
| tstream Vera Sans Mono', 'Courier Ne | `void`{style="margin: 0px !important |
| w', Courier, monospace !important; f | ; padding: 0px !important; white-spa |
| ont-weight: normal !important; font- | ce: nowrap; border: 0px !important;  |
| style: normal !important; font-size: | border-radius: 0px !important; botto |
|  1em !important; min-height: auto !i | m: auto !important; float: none !imp |
| mportant; white-space: pre !importan | ortant; height: auto !important; lef |
| t; background: none rgb(248, 248, 24 | t: auto !important; outline: 0px !im |
| 8) !important;">                     | portant; overflow: visible !importan |
|                                      | t; position: static !important; righ |
| 21                                   | t: auto !important; text-align: left |
|                                      |  !important; top: auto !important; v |
| </div>                               | ertical-align: baseline !important;  |
|                                      | width: auto !important; box-sizing:  |
| <div                                 | content-box !important; font-family: |
| style="margin: 0px !important; paddi |  Consolas, 'Bitstream Vera Sans Mono |
| ng: 0px 0.5em 0px 1em !important; bo | ', 'Courier New', Courier, monospace |
| rder-radius: 0px !important; border- |  !important; font-weight: bold !impo |
| width: 0px 3px 0px 0px !important; b | rtant; font-style: normal !important |
| order-right-style: solid !important; | ; font-size: 1em !important; min-hei |
|  border-right-color: rgb(108, 226, 1 | ght: auto !important; color: rgb(0,  |
| 08) !important; bottom: auto !import | 102, 153) !important; background: no |
| ant; float: none !important; height: | ne !important;"}                     |
|  auto !important; left: auto !import | `Main(`{style="margin: 0px !importan |
| ant; outline: 0px !important; overfl | t; padding: 0px !important; white-sp |
| ow: visible !important; position: st | ace: nowrap; border: 0px !important; |
| atic !important; right: auto !import |  border-radius: 0px !important; bott |
| ant; text-align: right !important; t | om: auto !important; float: none !im |
| op: auto !important; vertical-align: | portant; height: auto !important; le |
|  baseline !important; width: auto !i | ft: auto !important; outline: 0px !i |
| mportant; box-sizing: content-box !i | mportant; overflow: visible !importa |
| mportant; font-family: Consolas, 'Bi | nt; position: static !important; rig |
| tstream Vera Sans Mono', 'Courier Ne | ht: auto !important; text-align: lef |
| w', Courier, monospace !important; f | t !important; top: auto !important;  |
| ont-weight: normal !important; font- | vertical-align: baseline !important; |
| style: normal !important; font-size: |  width: auto !important; box-sizing: |
|  1em !important; min-height: auto !i |  content-box !important; font-family |
| mportant; white-space: pre !importan | : Consolas, 'Bitstream Vera Sans Mon |
| t; background: none rgb(255, 255, 25 | o', 'Courier New', Courier, monospac |
| 5) !important;">                     | e !important; font-weight: normal !i |
|                                      | mportant; font-style: normal !import |
| 22                                   | ant; font-size: 1em !important; min- |
|                                      | height: auto !important; color: rgb( |
| </div>                               | 0, 0, 0) !important; background: non |
|                                      | e !important;"}`string`{style="margi |
| <div                                 | n: 0px !important; padding: 0px !imp |
| style="margin: 0px !important; paddi | ortant; white-space: nowrap; border: |
| ng: 0px 0.5em 0px 1em !important; bo |  0px !important; border-radius: 0px  |
| rder-radius: 0px !important; border- | !important; bottom: auto !important; |
| width: 0px 3px 0px 0px !important; b |  float: none !important; height: aut |
| order-right-style: solid !important; | o !important; left: auto !important; |
|  border-right-color: rgb(108, 226, 1 |  outline: 0px !important; overflow:  |
| 08) !important; bottom: auto !import | visible !important; position: static |
| ant; float: none !important; height: |  !important; right: auto !important; |
|  auto !important; left: auto !import |  text-align: left !important; top: a |
| ant; outline: 0px !important; overfl | uto !important; vertical-align: base |
| ow: visible !important; position: st | line !important; width: auto !import |
| atic !important; right: auto !import | ant; box-sizing: content-box !import |
| ant; text-align: right !important; t | ant; font-family: Consolas, 'Bitstre |
| op: auto !important; vertical-align: | am Vera Sans Mono', 'Courier New', C |
|  baseline !important; width: auto !i | ourier, monospace !important; font-w |
| mportant; box-sizing: content-box !i | eight: bold !important; font-style:  |
| mportant; font-family: Consolas, 'Bi | normal !important; font-size: 1em !i |
| tstream Vera Sans Mono', 'Courier Ne | mportant; min-height: auto !importan |
| w', Courier, monospace !important; f | t; color: rgb(0, 102, 153) !importan |
| ont-weight: normal !important; font- | t; background: none !important;"}`[] |
| style: normal !important; font-size: |  args)`{style="margin: 0px !importan |
|  1em !important; min-height: auto !i | t; padding: 0px !important; white-sp |
| mportant; white-space: pre !importan | ace: nowrap; border: 0px !important; |
| t; background: none rgb(248, 248, 24 |  border-radius: 0px !important; bott |
| 8) !important;">                     | om: auto !important; float: none !im |
|                                      | portant; height: auto !important; le |
| 23                                   | ft: auto !important; outline: 0px !i |
|                                      | mportant; overflow: visible !importa |
| </div>                               | nt; position: static !important; rig |
|                                      | ht: auto !important; text-align: lef |
| <div                                 | t !important; top: auto !important;  |
| style="margin: 0px !important; paddi | vertical-align: baseline !important; |
| ng: 0px 0.5em 0px 1em !important; bo |  width: auto !important; box-sizing: |
| rder-radius: 0px !important; border- |  content-box !important; font-family |
| width: 0px 3px 0px 0px !important; b | : Consolas, 'Bitstream Vera Sans Mon |
| order-right-style: solid !important; | o', 'Courier New', Courier, monospac |
|  border-right-color: rgb(108, 226, 1 | e !important; font-weight: normal !i |
| 08) !important; bottom: auto !import | mportant; font-style: normal !import |
| ant; float: none !important; height: | ant; font-size: 1em !important; min- |
|  auto !important; left: auto !import | height: auto !important; color: rgb( |
| ant; outline: 0px !important; overfl | 0, 0, 0) !important; background: non |
| ow: visible !important; position: st | e !important;"}                      |
| atic !important; right: auto !import |                                      |
| ant; text-align: right !important; t | </div>                               |
| op: auto !important; vertical-align: |                                      |
|  baseline !important; width: auto !i | <div                                 |
| mportant; box-sizing: content-box !i | style="margin: 0px !important; paddi |
| mportant; font-family: Consolas, 'Bi | ng: 0px 1em !important; border-radiu |
| tstream Vera Sans Mono', 'Courier Ne | s: 0px !important; border: 0px !impo |
| w', Courier, monospace !important; f | rtant; bottom: auto !important; floa |
| ont-weight: normal !important; font- | t: none !important; height: auto !im |
| style: normal !important; font-size: | portant; left: auto !important; outl |
|  1em !important; min-height: auto !i | ine: 0px !important; overflow: visib |
| mportant; white-space: pre !importan | le !important; position: static !imp |
| t; background: none rgb(255, 255, 25 | ortant; right: auto !important; text |
| 5) !important;">                     | -align: left !important; top: auto ! |
|                                      | important; vertical-align: baseline  |
| 24                                   | !important; width: auto !important;  |
|                                      | box-sizing: content-box !important;  |
| </div>                               | font-family: Consolas, 'Bitstream Ve |
|                                      | ra Sans Mono', 'Courier New', Courie |
| <div                                 | r, monospace !important; font-weight |
| style="margin: 0px !important; paddi | : normal !important; font-style: nor |
| ng: 0px 0.5em 0px 1em !important; bo | mal !important; font-size: 1em !impo |
| rder-radius: 0px !important; border- | rtant; min-height: auto !important;  |
| width: 0px 3px 0px 0px !important; b | white-space: pre !important; backgro |
| order-right-style: solid !important; | und: none rgb(248, 248, 248) !import |
|  border-right-color: rgb(108, 226, 1 | ant;">                               |
| 08) !important; bottom: auto !import |                                      |
| ant; float: none !important; height: | `        `{style="margin: 0px !impor |
|  auto !important; left: auto !import | tant; padding: 0px !important; white |
| ant; outline: 0px !important; overfl | -space: nowrap; border: 0px !importa |
| ow: visible !important; position: st | nt; border-radius: 0px !important; b |
| atic !important; right: auto !import | ottom: auto !important; float: none  |
| ant; text-align: right !important; t | !important; height: auto !important; |
| op: auto !important; vertical-align: |  left: auto !important; outline: 0px |
|  baseline !important; width: auto !i |  !important; overflow: visible !impo |
| mportant; box-sizing: content-box !i | rtant; position: static !important;  |
| mportant; font-family: Consolas, 'Bi | right: auto !important; text-align:  |
| tstream Vera Sans Mono', 'Courier Ne | left !important; top: auto !importan |
| w', Courier, monospace !important; f | t; vertical-align: baseline !importa |
| ont-weight: normal !important; font- | nt; width: auto !important; box-sizi |
| style: normal !important; font-size: | ng: content-box !important; font-fam |
|  1em !important; min-height: auto !i | ily: Consolas, 'Bitstream Vera Sans  |
| mportant; white-space: pre !importan | Mono', 'Courier New', Courier, monos |
| t; background: none rgb(248, 248, 24 | pace !important; font-weight: normal |
| 8) !important;">                     |  !important; font-style: normal !imp |
|                                      | ortant; font-size: 1em !important; m |
| 25                                   | in-height: auto !important; backgrou |
|                                      | nd: none !important;"}`{`{style="mar |
| </div>                               | gin: 0px !important; padding: 0px !i |
|                                      | mportant; white-space: nowrap; borde |
| <div                                 | r: 0px !important; border-radius: 0p |
| style="margin: 0px !important; paddi | x !important; bottom: auto !importan |
| ng: 0px 0.5em 0px 1em !important; bo | t; float: none !important; height: a |
| rder-radius: 0px !important; border- | uto !important; left: auto !importan |
| width: 0px 3px 0px 0px !important; b | t; outline: 0px !important; overflow |
| order-right-style: solid !important; | : visible !important; position: stat |
|  border-right-color: rgb(108, 226, 1 | ic !important; right: auto !importan |
| 08) !important; bottom: auto !import | t; text-align: left !important; top: |
| ant; float: none !important; height: |  auto !important; vertical-align: ba |
|  auto !important; left: auto !import | seline !important; width: auto !impo |
| ant; outline: 0px !important; overfl | rtant; box-sizing: content-box !impo |
| ow: visible !important; position: st | rtant; font-family: Consolas, 'Bitst |
| atic !important; right: auto !import | ream Vera Sans Mono', 'Courier New', |
| ant; text-align: right !important; t |  Courier, monospace !important; font |
| op: auto !important; vertical-align: | -weight: normal !important; font-sty |
|  baseline !important; width: auto !i | le: normal !important; font-size: 1e |
| mportant; box-sizing: content-box !i | m !important; min-height: auto !impo |
| mportant; font-family: Consolas, 'Bi | rtant; color: rgb(0, 0, 0) !importan |
| tstream Vera Sans Mono', 'Courier Ne | t; background: none !important;"}    |
| w', Courier, monospace !important; f |                                      |
| ont-weight: normal !important; font- | </div>                               |
| style: normal !important; font-size: |                                      |
|  1em !important; min-height: auto !i | <div                                 |
| mportant; white-space: pre !importan | style="margin: 0px !important; paddi |
| t; background: none rgb(255, 255, 25 | ng: 0px 1em !important; border-radiu |
| 5) !important;">                     | s: 0px !important; border: 0px !impo |
|                                      | rtant; bottom: auto !important; floa |
| 26                                   | t: none !important; height: auto !im |
|                                      | portant; left: auto !important; outl |
| </div>                               | ine: 0px !important; overflow: visib |
|                                      | le !important; position: static !imp |
| <div                                 | ortant; right: auto !important; text |
| style="margin: 0px !important; paddi | -align: left !important; top: auto ! |
| ng: 0px 0.5em 0px 1em !important; bo | important; vertical-align: baseline  |
| rder-radius: 0px !important; border- | !important; width: auto !important;  |
| width: 0px 3px 0px 0px !important; b | box-sizing: content-box !important;  |
| order-right-style: solid !important; | font-family: Consolas, 'Bitstream Ve |
|  border-right-color: rgb(108, 226, 1 | ra Sans Mono', 'Courier New', Courie |
| 08) !important; bottom: auto !import | r, monospace !important; font-weight |
| ant; float: none !important; height: | : normal !important; font-style: nor |
|  auto !important; left: auto !import | mal !important; font-size: 1em !impo |
| ant; outline: 0px !important; overfl | rtant; min-height: auto !important;  |
| ow: visible !important; position: st | white-space: pre !important; backgro |
| atic !important; right: auto !import | und: none rgb(255, 255, 255) !import |
| ant; text-align: right !important; t | ant;">                               |
| op: auto !important; vertical-align: |                                      |
|  baseline !important; width: auto !i | `            `{style="margin: 0px !i |
| mportant; box-sizing: content-box !i | mportant; padding: 0px !important; w |
| mportant; font-family: Consolas, 'Bi | hite-space: nowrap; border: 0px !imp |
| tstream Vera Sans Mono', 'Courier Ne | ortant; border-radius: 0px !importan |
| w', Courier, monospace !important; f | t; bottom: auto !important; float: n |
| ont-weight: normal !important; font- | one !important; height: auto !import |
| style: normal !important; font-size: | ant; left: auto !important; outline: |
|  1em !important; min-height: auto !i |  0px !important; overflow: visible ! |
| mportant; white-space: pre !importan | important; position: static !importa |
| t; background: none rgb(248, 248, 24 | nt; right: auto !important; text-ali |
| 8) !important;">                     | gn: left !important; top: auto !impo |
|                                      | rtant; vertical-align: baseline !imp |
| 27                                   | ortant; width: auto !important; box- |
|                                      | sizing: content-box !important; font |
| </div>                               | -family: Consolas, 'Bitstream Vera S |
|                                      | ans Mono', 'Courier New', Courier, m |
| <div                                 | onospace !important; font-weight: no |
| style="margin: 0px !important; paddi | rmal !important; font-style: normal  |
| ng: 0px 0.5em 0px 1em !important; bo | !important; font-size: 1em !importan |
| rder-radius: 0px !important; border- | t; min-height: auto !important; back |
| width: 0px 3px 0px 0px !important; b | ground: none !important;"}`//Seriali |
| order-right-style: solid !important; | zation of String Object           `{ |
|  border-right-color: rgb(108, 226, 1 | style="margin: 0px !important; paddi |
| 08) !important; bottom: auto !import | ng: 0px !important; white-space: now |
| ant; float: none !important; height: | rap; border: 0px !important; border- |
|  auto !important; left: auto !import | radius: 0px !important; bottom: auto |
| ant; outline: 0px !important; overfl |  !important; float: none !important; |
| ow: visible !important; position: st |  height: auto !important; left: auto |
| atic !important; right: auto !import |  !important; outline: 0px !important |
| ant; text-align: right !important; t | ; overflow: visible !important; posi |
| op: auto !important; vertical-align: | tion: static !important; right: auto |
|  baseline !important; width: auto !i |  !important; text-align: left !impor |
| mportant; box-sizing: content-box !i | tant; top: auto !important; vertical |
| mportant; font-family: Consolas, 'Bi | -align: baseline !important; width:  |
| tstream Vera Sans Mono', 'Courier Ne | auto !important; box-sizing: content |
| w', Courier, monospace !important; f | -box !important; font-family: Consol |
| ont-weight: normal !important; font- | as, 'Bitstream Vera Sans Mono', 'Cou |
| style: normal !important; font-size: | rier New', Courier, monospace !impor |
|  1em !important; min-height: auto !i | tant; font-weight: normal !important |
| mportant; white-space: pre !importan | ; font-style: normal !important; fon |
| t; background: none rgb(255, 255, 25 | t-size: 1em !important; min-height:  |
| 5) !important;">                     | auto !important; color: rgb(0, 130,  |
|                                      | 0) !important; background: none !imp |
| 28                                   | ortant;"}                            |
|                                      |                                      |
| </div>                               | </div>                               |
|                                      |                                      |
| <div                                 | <div                                 |
| style="margin: 0px !important; paddi | style="margin: 0px !important; paddi |
| ng: 0px 0.5em 0px 1em !important; bo | ng: 0px 1em !important; border-radiu |
| rder-radius: 0px !important; border- | s: 0px !important; border: 0px !impo |
| width: 0px 3px 0px 0px !important; b | rtant; bottom: auto !important; floa |
| order-right-style: solid !important; | t: none !important; height: auto !im |
|  border-right-color: rgb(108, 226, 1 | portant; left: auto !important; outl |
| 08) !important; bottom: auto !import | ine: 0px !important; overflow: visib |
| ant; float: none !important; height: | le !important; position: static !imp |
|  auto !important; left: auto !import | ortant; right: auto !important; text |
| ant; outline: 0px !important; overfl | -align: left !important; top: auto ! |
| ow: visible !important; position: st | important; vertical-align: baseline  |
| atic !important; right: auto !import | !important; width: auto !important;  |
| ant; text-align: right !important; t | box-sizing: content-box !important;  |
| op: auto !important; vertical-align: | font-family: Consolas, 'Bitstream Ve |
|  baseline !important; width: auto !i | ra Sans Mono', 'Courier New', Courie |
| mportant; box-sizing: content-box !i | r, monospace !important; font-weight |
| mportant; font-family: Consolas, 'Bi | : normal !important; font-style: nor |
| tstream Vera Sans Mono', 'Courier Ne | mal !important; font-size: 1em !impo |
| w', Courier, monospace !important; f | rtant; min-height: auto !important;  |
| ont-weight: normal !important; font- | white-space: pre !important; backgro |
| style: normal !important; font-size: | und: none rgb(248, 248, 248) !import |
|  1em !important; min-height: auto !i | ant;">                               |
| mportant; white-space: pre !importan |                                      |
| t; background: none rgb(248, 248, 24 | `            `{style="margin: 0px !i |
| 8) !important;">                     | mportant; padding: 0px !important; w |
|                                      | hite-space: nowrap; border: 0px !imp |
| 29                                   | ortant; border-radius: 0px !importan |
|                                      | t; bottom: auto !important; float: n |
| </div>                               | one !important; height: auto !import |
|                                      | ant; left: auto !important; outline: |
| <div                                 |  0px !important; overflow: visible ! |
| style="margin: 0px !important; paddi | important; position: static !importa |
| ng: 0px 0.5em 0px 1em !important; bo | nt; right: auto !important; text-ali |
| rder-radius: 0px !important; border- | gn: left !important; top: auto !impo |
| width: 0px 3px 0px 0px !important; b | rtant; vertical-align: baseline !imp |
| order-right-style: solid !important; | ortant; width: auto !important; box- |
|  border-right-color: rgb(108, 226, 1 | sizing: content-box !important; font |
| 08) !important; bottom: auto !import | -family: Consolas, 'Bitstream Vera S |
| ant; float: none !important; height: | ans Mono', 'Courier New', Courier, m |
|  auto !important; left: auto !import | onospace !important; font-weight: no |
| ant; outline: 0px !important; overfl | rmal !important; font-style: normal  |
| ow: visible !important; position: st | !important; font-size: 1em !importan |
| atic !important; right: auto !import | t; min-height: auto !important; back |
| ant; text-align: right !important; t | ground: none !important;"}`string`{s |
| op: auto !important; vertical-align: | tyle="margin: 0px !important; paddin |
|  baseline !important; width: auto !i | g: 0px !important; white-space: nowr |
| mportant; box-sizing: content-box !i | ap; border: 0px !important; border-r |
| mportant; font-family: Consolas, 'Bi | adius: 0px !important; bottom: auto  |
| tstream Vera Sans Mono', 'Courier Ne | !important; float: none !important;  |
| w', Courier, monospace !important; f | height: auto !important; left: auto  |
| ont-weight: normal !important; font- | !important; outline: 0px !important; |
| style: normal !important; font-size: |  overflow: visible !important; posit |
|  1em !important; min-height: auto !i | ion: static !important; right: auto  |
| mportant; white-space: pre !importan | !important; text-align: left !import |
| t; background: none rgb(255, 255, 25 | ant; top: auto !important; vertical- |
| 5) !important;">                     | align: baseline !important; width: a |
|                                      | uto !important; box-sizing: content- |
| 30                                   | box !important; font-family: Consola |
|                                      | s, 'Bitstream Vera Sans Mono', 'Cour |
| </div>                               | ier New', Courier, monospace !import |
|                                      | ant; font-weight: bold !important; f |
| <div                                 | ont-style: normal !important; font-s |
| style="margin: 0px !important; paddi | ize: 1em !important; min-height: aut |
| ng: 0px 0.5em 0px 1em !important; bo | o !important; color: rgb(0, 102, 153 |
| rder-radius: 0px !important; border- | ) !important; background: none !impo |
| width: 0px 3px 0px 0px !important; b | rtant;"}                             |
| order-right-style: solid !important; | `strobj = `{style="margin: 0px !impo |
|  border-right-color: rgb(108, 226, 1 | rtant; padding: 0px !important; whit |
| 08) !important; bottom: auto !import | e-space: nowrap; border: 0px !import |
| ant; float: none !important; height: | ant; border-radius: 0px !important;  |
|  auto !important; left: auto !import | bottom: auto !important; float: none |
| ant; outline: 0px !important; overfl |  !important; height: auto !important |
| ow: visible !important; position: st | ; left: auto !important; outline: 0p |
| atic !important; right: auto !import | x !important; overflow: visible !imp |
| ant; text-align: right !important; t | ortant; position: static !important; |
| op: auto !important; vertical-align: |  right: auto !important; text-align: |
|  baseline !important; width: auto !i |  left !important; top: auto !importa |
| mportant; box-sizing: content-box !i | nt; vertical-align: baseline !import |
| mportant; font-family: Consolas, 'Bi | ant; width: auto !important; box-siz |
| tstream Vera Sans Mono', 'Courier Ne | ing: content-box !important; font-fa |
| w', Courier, monospace !important; f | mily: Consolas, 'Bitstream Vera Sans |
| ont-weight: normal !important; font- |  Mono', 'Courier New', Courier, mono |
| style: normal !important; font-size: | space !important; font-weight: norma |
|  1em !important; min-height: auto !i | l !important; font-style: normal !im |
| mportant; white-space: pre !importan | portant; font-size: 1em !important;  |
| t; background: none rgb(248, 248, 24 | min-height: auto !important; color:  |
| 8) !important;">                     | rgb(0, 0, 0) !important; background: |
|                                      |  none !important;"}`"test string for |
| 31                                   |  serialization"`{style="margin: 0px  |
|                                      | !important; padding: 0px !important; |
| </div>                               |  white-space: nowrap; border: 0px !i |
|                                      | mportant; border-radius: 0px !import |
| <div                                 | ant; bottom: auto !important; float: |
| style="margin: 0px !important; paddi |  none !important; height: auto !impo |
| ng: 0px 0.5em 0px 1em !important; bo | rtant; left: auto !important; outlin |
| rder-radius: 0px !important; border- | e: 0px !important; overflow: visible |
| width: 0px 3px 0px 0px !important; b |  !important; position: static !impor |
| order-right-style: solid !important; | tant; right: auto !important; text-a |
|  border-right-color: rgb(108, 226, 1 | lign: left !important; top: auto !im |
| 08) !important; bottom: auto !import | portant; vertical-align: baseline !i |
| ant; float: none !important; height: | mportant; width: auto !important; bo |
|  auto !important; left: auto !import | x-sizing: content-box !important; fo |
| ant; outline: 0px !important; overfl | nt-family: Consolas, 'Bitstream Vera |
| ow: visible !important; position: st |  Sans Mono', 'Courier New', Courier, |
| atic !important; right: auto !import |  monospace !important; font-weight:  |
| ant; text-align: right !important; t | normal !important; font-style: norma |
| op: auto !important; vertical-align: | l !important; font-size: 1em !import |
|  baseline !important; width: auto !i | ant; min-height: auto !important; co |
| mportant; box-sizing: content-box !i | lor: blue !important; background: no |
| mportant; font-family: Consolas, 'Bi | ne !important;"}`;`{style="margin: 0 |
| tstream Vera Sans Mono', 'Courier Ne | px !important; padding: 0px !importa |
| w', Courier, monospace !important; f | nt; white-space: nowrap; border: 0px |
| ont-weight: normal !important; font- |  !important; border-radius: 0px !imp |
| style: normal !important; font-size: | ortant; bottom: auto !important; flo |
|  1em !important; min-height: auto !i | at: none !important; height: auto !i |
| mportant; white-space: pre !importan | mportant; left: auto !important; out |
| t; background: none rgb(255, 255, 25 | line: 0px !important; overflow: visi |
| 5) !important;">                     | ble !important; position: static !im |
|                                      | portant; right: auto !important; tex |
| 32                                   | t-align: left !important; top: auto  |
|                                      | !important; vertical-align: baseline |
| </div>                               |  !important; width: auto !important; |
|                                      |  box-sizing: content-box !important; |
|                                      |  font-family: Consolas, 'Bitstream V |
|                                      | era Sans Mono', 'Courier New', Couri |
|                                      | er, monospace !important; font-weigh |
|                                      | t: normal !important; font-style: no |
|                                      | rmal !important; font-size: 1em !imp |
|                                      | ortant; min-height: auto !important; |
|                                      |  color: rgb(0, 0, 0) !important; bac |
|                                      | kground: none !important;"}          |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="margin: 0px !important; paddi |
|                                      | ng: 0px 1em !important; border-radiu |
|                                      | s: 0px !important; border: 0px !impo |
|                                      | rtant; bottom: auto !important; floa |
|                                      | t: none !important; height: auto !im |
|                                      | portant; left: auto !important; outl |
|                                      | ine: 0px !important; overflow: visib |
|                                      | le !important; position: static !imp |
|                                      | ortant; right: auto !important; text |
|                                      | -align: left !important; top: auto ! |
|                                      | important; vertical-align: baseline  |
|                                      | !important; width: auto !important;  |
|                                      | box-sizing: content-box !important;  |
|                                      | font-family: Consolas, 'Bitstream Ve |
|                                      | ra Sans Mono', 'Courier New', Courie |
|                                      | r, monospace !important; font-weight |
|                                      | : normal !important; font-style: nor |
|                                      | mal !important; font-size: 1em !impo |
|                                      | rtant; min-height: auto !important;  |
|                                      | white-space: pre !important; backgro |
|                                      | und: none rgb(255, 255, 255) !import |
|                                      | ant;">                               |
|                                      |                                      |
|                                      | `            `{style="margin: 0px !i |
|                                      | mportant; padding: 0px !important; w |
|                                      | hite-space: nowrap; border: 0px !imp |
|                                      | ortant; border-radius: 0px !importan |
|                                      | t; bottom: auto !important; float: n |
|                                      | one !important; height: auto !import |
|                                      | ant; left: auto !important; outline: |
|                                      |  0px !important; overflow: visible ! |
|                                      | important; position: static !importa |
|                                      | nt; right: auto !important; text-ali |
|                                      | gn: left !important; top: auto !impo |
|                                      | rtant; vertical-align: baseline !imp |
|                                      | ortant; width: auto !important; box- |
|                                      | sizing: content-box !important; font |
|                                      | -family: Consolas, 'Bitstream Vera S |
|                                      | ans Mono', 'Courier New', Courier, m |
|                                      | onospace !important; font-weight: no |
|                                      | rmal !important; font-style: normal  |
|                                      | !important; font-size: 1em !importan |
|                                      | t; min-height: auto !important; back |
|                                      | ground: none !important;"}`FileStrea |
|                                      | m stream = `{style="margin: 0px !imp |
|                                      | ortant; padding: 0px !important; whi |
|                                      | te-space: nowrap; border: 0px !impor |
|                                      | tant; border-radius: 0px !important; |
|                                      |  bottom: auto !important; float: non |
|                                      | e !important; height: auto !importan |
|                                      | t; left: auto !important; outline: 0 |
|                                      | px !important; overflow: visible !im |
|                                      | portant; position: static !important |
|                                      | ; right: auto !important; text-align |
|                                      | : left !important; top: auto !import |
|                                      | ant; vertical-align: baseline !impor |
|                                      | tant; width: auto !important; box-si |
|                                      | zing: content-box !important; font-f |
|                                      | amily: Consolas, 'Bitstream Vera San |
|                                      | s Mono', 'Courier New', Courier, mon |
|                                      | ospace !important; font-weight: norm |
|                                      | al !important; font-style: normal !i |
|                                      | mportant; font-size: 1em !important; |
|                                      |  min-height: auto !important; color: |
|                                      |  rgb(0, 0, 0) !important; background |
|                                      | : none !important;"}`new`{style="mar |
|                                      | gin: 0px !important; padding: 0px !i |
|                                      | mportant; white-space: nowrap; borde |
|                                      | r: 0px !important; border-radius: 0p |
|                                      | x !important; bottom: auto !importan |
|                                      | t; float: none !important; height: a |
|                                      | uto !important; left: auto !importan |
|                                      | t; outline: 0px !important; overflow |
|                                      | : visible !important; position: stat |
|                                      | ic !important; right: auto !importan |
|                                      | t; text-align: left !important; top: |
|                                      |  auto !important; vertical-align: ba |
|                                      | seline !important; width: auto !impo |
|                                      | rtant; box-sizing: content-box !impo |
|                                      | rtant; font-family: Consolas, 'Bitst |
|                                      | ream Vera Sans Mono', 'Courier New', |
|                                      |  Courier, monospace !important; font |
|                                      | -weight: bold !important; font-style |
|                                      | : normal !important; font-size: 1em  |
|                                      | !important; min-height: auto !import |
|                                      | ant; color: rgb(0, 102, 153) !import |
|                                      | ant; background: none !important;"}  |
|                                      | `FileStream(`{style="margin: 0px !im |
|                                      | portant; padding: 0px !important; wh |
|                                      | ite-space: nowrap; border: 0px !impo |
|                                      | rtant; border-radius: 0px !important |
|                                      | ; bottom: auto !important; float: no |
|                                      | ne !important; height: auto !importa |
|                                      | nt; left: auto !important; outline:  |
|                                      | 0px !important; overflow: visible !i |
|                                      | mportant; position: static !importan |
|                                      | t; right: auto !important; text-alig |
|                                      | n: left !important; top: auto !impor |
|                                      | tant; vertical-align: baseline !impo |
|                                      | rtant; width: auto !important; box-s |
|                                      | izing: content-box !important; font- |
|                                      | family: Consolas, 'Bitstream Vera Sa |
|                                      | ns Mono', 'Courier New', Courier, mo |
|                                      | nospace !important; font-weight: nor |
|                                      | mal !important; font-style: normal ! |
|                                      | important; font-size: 1em !important |
|                                      | ; min-height: auto !important; color |
|                                      | : rgb(0, 0, 0) !important; backgroun |
|                                      | d: none !important;"}`"C:\\StrObj.tx |
|                                      | t"`{style="margin: 0px !important; p |
|                                      | adding: 0px !important; white-space: |
|                                      |  nowrap; border: 0px !important; bor |
|                                      | der-radius: 0px !important; bottom:  |
|                                      | auto !important; float: none !import |
|                                      | ant; height: auto !important; left:  |
|                                      | auto !important; outline: 0px !impor |
|                                      | tant; overflow: visible !important;  |
|                                      | position: static !important; right:  |
|                                      | auto !important; text-align: left !i |
|                                      | mportant; top: auto !important; vert |
|                                      | ical-align: baseline !important; wid |
|                                      | th: auto !important; box-sizing: con |
|                                      | tent-box !important; font-family: Co |
|                                      | nsolas, 'Bitstream Vera Sans Mono',  |
|                                      | 'Courier New', Courier, monospace !i |
|                                      | mportant; font-weight: normal !impor |
|                                      | tant; font-style: normal !important; |
|                                      |  font-size: 1em !important; min-heig |
|                                      | ht: auto !important; color: blue !im |
|                                      | portant; background: none !important |
|                                      | ;"}`, FileMode.Create, FileAccess.Wr |
|                                      | ite ,`{style="margin: 0px !important |
|                                      | ; padding: 0px !important; white-spa |
|                                      | ce: nowrap; border: 0px !important;  |
|                                      | border-radius: 0px !important; botto |
|                                      | m: auto !important; float: none !imp |
|                                      | ortant; height: auto !important; lef |
|                                      | t: auto !important; outline: 0px !im |
|                                      | portant; overflow: visible !importan |
|                                      | t; position: static !important; righ |
|                                      | t: auto !important; text-align: left |
|                                      |  !important; top: auto !important; v |
|                                      | ertical-align: baseline !important;  |
|                                      | width: auto !important; box-sizing:  |
|                                      | content-box !important; font-family: |
|                                      |  Consolas, 'Bitstream Vera Sans Mono |
|                                      | ', 'Courier New', Courier, monospace |
|                                      |  !important; font-weight: normal !im |
|                                      | portant; font-style: normal !importa |
|                                      | nt; font-size: 1em !important; min-h |
|                                      | eight: auto !important; color: rgb(0 |
|                                      | , 0, 0) !important; background: none |
|                                      |  !important;"}                       |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="margin: 0px !important; paddi |
|                                      | ng: 0px 1em !important; border-radiu |
|                                      | s: 0px !important; border: 0px !impo |
|                                      | rtant; bottom: auto !important; floa |
|                                      | t: none !important; height: auto !im |
|                                      | portant; left: auto !important; outl |
|                                      | ine: 0px !important; overflow: visib |
|                                      | le !important; position: static !imp |
|                                      | ortant; right: auto !important; text |
|                                      | -align: left !important; top: auto ! |
|                                      | important; vertical-align: baseline  |
|                                      | !important; width: auto !important;  |
|                                      | box-sizing: content-box !important;  |
|                                      | font-family: Consolas, 'Bitstream Ve |
|                                      | ra Sans Mono', 'Courier New', Courie |
|                                      | r, monospace !important; font-weight |
|                                      | : normal !important; font-style: nor |
|                                      | mal !important; font-size: 1em !impo |
|                                      | rtant; min-height: auto !important;  |
|                                      | white-space: pre !important; backgro |
|                                      | und: none rgb(248, 248, 248) !import |
|                                      | ant;">                               |
|                                      |                                      |
|                                      | `            `{style="margin: 0px !i |
|                                      | mportant; padding: 0px !important; w |
|                                      | hite-space: nowrap; border: 0px !imp |
|                                      | ortant; border-radius: 0px !importan |
|                                      | t; bottom: auto !important; float: n |
|                                      | one !important; height: auto !import |
|                                      | ant; left: auto !important; outline: |
|                                      |  0px !important; overflow: visible ! |
|                                      | important; position: static !importa |
|                                      | nt; right: auto !important; text-ali |
|                                      | gn: left !important; top: auto !impo |
|                                      | rtant; vertical-align: baseline !imp |
|                                      | ortant; width: auto !important; box- |
|                                      | sizing: content-box !important; font |
|                                      | -family: Consolas, 'Bitstream Vera S |
|                                      | ans Mono', 'Courier New', Courier, m |
|                                      | onospace !important; font-weight: no |
|                                      | rmal !important; font-style: normal  |
|                                      | !important; font-size: 1em !importan |
|                                      | t; min-height: auto !important; back |
|                                      | ground: none !important;"}`FileShare |
|                                      | .None);`{style="margin: 0px !importa |
|                                      | nt; padding: 0px !important; white-s |
|                                      | pace: nowrap; border: 0px !important |
|                                      | ; border-radius: 0px !important; bot |
|                                      | tom: auto !important; float: none !i |
|                                      | mportant; height: auto !important; l |
|                                      | eft: auto !important; outline: 0px ! |
|                                      | important; overflow: visible !import |
|                                      | ant; position: static !important; ri |
|                                      | ght: auto !important; text-align: le |
|                                      | ft !important; top: auto !important; |
|                                      |  vertical-align: baseline !important |
|                                      | ; width: auto !important; box-sizing |
|                                      | : content-box !important; font-famil |
|                                      | y: Consolas, 'Bitstream Vera Sans Mo |
|                                      | no', 'Courier New', Courier, monospa |
|                                      | ce !important; font-weight: normal ! |
|                                      | important; font-style: normal !impor |
|                                      | tant; font-size: 1em !important; min |
|                                      | -height: auto !important; color: rgb |
|                                      | (0, 0, 0) !important; background: no |
|                                      | ne !important;"}                     |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="margin: 0px !important; paddi |
|                                      | ng: 0px 1em !important; border-radiu |
|                                      | s: 0px !important; border: 0px !impo |
|                                      | rtant; bottom: auto !important; floa |
|                                      | t: none !important; height: auto !im |
|                                      | portant; left: auto !important; outl |
|                                      | ine: 0px !important; overflow: visib |
|                                      | le !important; position: static !imp |
|                                      | ortant; right: auto !important; text |
|                                      | -align: left !important; top: auto ! |
|                                      | important; vertical-align: baseline  |
|                                      | !important; width: auto !important;  |
|                                      | box-sizing: content-box !important;  |
|                                      | font-family: Consolas, 'Bitstream Ve |
|                                      | ra Sans Mono', 'Courier New', Courie |
|                                      | r, monospace !important; font-weight |
|                                      | : normal !important; font-style: nor |
|                                      | mal !important; font-size: 1em !impo |
|                                      | rtant; min-height: auto !important;  |
|                                      | white-space: pre !important; backgro |
|                                      | und: none rgb(255, 255, 255) !import |
|                                      | ant;">                               |
|                                      |                                      |
|                                      | `            `{style="margin: 0px !i |
|                                      | mportant; padding: 0px !important; w |
|                                      | hite-space: nowrap; border: 0px !imp |
|                                      | ortant; border-radius: 0px !importan |
|                                      | t; bottom: auto !important; float: n |
|                                      | one !important; height: auto !import |
|                                      | ant; left: auto !important; outline: |
|                                      |  0px !important; overflow: visible ! |
|                                      | important; position: static !importa |
|                                      | nt; right: auto !important; text-ali |
|                                      | gn: left !important; top: auto !impo |
|                                      | rtant; vertical-align: baseline !imp |
|                                      | ortant; width: auto !important; box- |
|                                      | sizing: content-box !important; font |
|                                      | -family: Consolas, 'Bitstream Vera S |
|                                      | ans Mono', 'Courier New', Courier, m |
|                                      | onospace !important; font-weight: no |
|                                      | rmal !important; font-style: normal  |
|                                      | !important; font-size: 1em !importan |
|                                      | t; min-height: auto !important; back |
|                                      | ground: none !important;"}`XmlSerial |
|                                      | izer  xmlserializer = `{style="margi |
|                                      | n: 0px !important; padding: 0px !imp |
|                                      | ortant; white-space: nowrap; border: |
|                                      |  0px !important; border-radius: 0px  |
|                                      | !important; bottom: auto !important; |
|                                      |  float: none !important; height: aut |
|                                      | o !important; left: auto !important; |
|                                      |  outline: 0px !important; overflow:  |
|                                      | visible !important; position: static |
|                                      |  !important; right: auto !important; |
|                                      |  text-align: left !important; top: a |
|                                      | uto !important; vertical-align: base |
|                                      | line !important; width: auto !import |
|                                      | ant; box-sizing: content-box !import |
|                                      | ant; font-family: Consolas, 'Bitstre |
|                                      | am Vera Sans Mono', 'Courier New', C |
|                                      | ourier, monospace !important; font-w |
|                                      | eight: normal !important; font-style |
|                                      | : normal !important; font-size: 1em  |
|                                      | !important; min-height: auto !import |
|                                      | ant; color: rgb(0, 0, 0) !important; |
|                                      |  background: none !important;"}`new` |
|                                      | {style="margin: 0px !important; padd |
|                                      | ing: 0px !important; white-space: no |
|                                      | wrap; border: 0px !important; border |
|                                      | -radius: 0px !important; bottom: aut |
|                                      | o !important; float: none !important |
|                                      | ; height: auto !important; left: aut |
|                                      | o !important; outline: 0px !importan |
|                                      | t; overflow: visible !important; pos |
|                                      | ition: static !important; right: aut |
|                                      | o !important; text-align: left !impo |
|                                      | rtant; top: auto !important; vertica |
|                                      | l-align: baseline !important; width: |
|                                      |  auto !important; box-sizing: conten |
|                                      | t-box !important; font-family: Conso |
|                                      | las, 'Bitstream Vera Sans Mono', 'Co |
|                                      | urier New', Courier, monospace !impo |
|                                      | rtant; font-weight: bold !important; |
|                                      |  font-style: normal !important; font |
|                                      | -size: 1em !important; min-height: a |
|                                      | uto !important; color: rgb(0, 102, 1 |
|                                      | 53) !important; background: none !im |
|                                      | portant;"}                           |
|                                      | `XmlSerializer(`{style="margin: 0px  |
|                                      | !important; padding: 0px !important; |
|                                      |  white-space: nowrap; border: 0px !i |
|                                      | mportant; border-radius: 0px !import |
|                                      | ant; bottom: auto !important; float: |
|                                      |  none !important; height: auto !impo |
|                                      | rtant; left: auto !important; outlin |
|                                      | e: 0px !important; overflow: visible |
|                                      |  !important; position: static !impor |
|                                      | tant; right: auto !important; text-a |
|                                      | lign: left !important; top: auto !im |
|                                      | portant; vertical-align: baseline !i |
|                                      | mportant; width: auto !important; bo |
|                                      | x-sizing: content-box !important; fo |
|                                      | nt-family: Consolas, 'Bitstream Vera |
|                                      |  Sans Mono', 'Courier New', Courier, |
|                                      |  monospace !important; font-weight:  |
|                                      | normal !important; font-style: norma |
|                                      | l !important; font-size: 1em !import |
|                                      | ant; min-height: auto !important; co |
|                                      | lor: rgb(0, 0, 0) !important; backgr |
|                                      | ound: none !important;"}`typeof`{sty |
|                                      | le="margin: 0px !important; padding: |
|                                      |  0px !important; white-space: nowrap |
|                                      | ; border: 0px !important; border-rad |
|                                      | ius: 0px !important; bottom: auto !i |
|                                      | mportant; float: none !important; he |
|                                      | ight: auto !important; left: auto !i |
|                                      | mportant; outline: 0px !important; o |
|                                      | verflow: visible !important; positio |
|                                      | n: static !important; right: auto !i |
|                                      | mportant; text-align: left !importan |
|                                      | t; top: auto !important; vertical-al |
|                                      | ign: baseline !important; width: aut |
|                                      | o !important; box-sizing: content-bo |
|                                      | x !important; font-family: Consolas, |
|                                      |  'Bitstream Vera Sans Mono', 'Courie |
|                                      | r New', Courier, monospace !importan |
|                                      | t; font-weight: bold !important; fon |
|                                      | t-style: normal !important; font-siz |
|                                      | e: 1em !important; min-height: auto  |
|                                      | !important; color: rgb(0, 102, 153)  |
|                                      | !important; background: none !import |
|                                      | ant;"}`(`{style="margin: 0px !import |
|                                      | ant; padding: 0px !important; white- |
|                                      | space: nowrap; border: 0px !importan |
|                                      | t; border-radius: 0px !important; bo |
|                                      | ttom: auto !important; float: none ! |
|                                      | important; height: auto !important;  |
|                                      | left: auto !important; outline: 0px  |
|                                      | !important; overflow: visible !impor |
|                                      | tant; position: static !important; r |
|                                      | ight: auto !important; text-align: l |
|                                      | eft !important; top: auto !important |
|                                      | ; vertical-align: baseline !importan |
|                                      | t; width: auto !important; box-sizin |
|                                      | g: content-box !important; font-fami |
|                                      | ly: Consolas, 'Bitstream Vera Sans M |
|                                      | ono', 'Courier New', Courier, monosp |
|                                      | ace !important; font-weight: normal  |
|                                      | !important; font-style: normal !impo |
|                                      | rtant; font-size: 1em !important; mi |
|                                      | n-height: auto !important; color: rg |
|                                      | b(0, 0, 0) !important; background: n |
|                                      | one !important;"}`string`{style="mar |
|                                      | gin: 0px !important; padding: 0px !i |
|                                      | mportant; white-space: nowrap; borde |
|                                      | r: 0px !important; border-radius: 0p |
|                                      | x !important; bottom: auto !importan |
|                                      | t; float: none !important; height: a |
|                                      | uto !important; left: auto !importan |
|                                      | t; outline: 0px !important; overflow |
|                                      | : visible !important; position: stat |
|                                      | ic !important; right: auto !importan |
|                                      | t; text-align: left !important; top: |
|                                      |  auto !important; vertical-align: ba |
|                                      | seline !important; width: auto !impo |
|                                      | rtant; box-sizing: content-box !impo |
|                                      | rtant; font-family: Consolas, 'Bitst |
|                                      | ream Vera Sans Mono', 'Courier New', |
|                                      |  Courier, monospace !important; font |
|                                      | -weight: bold !important; font-style |
|                                      | : normal !important; font-size: 1em  |
|                                      | !important; min-height: auto !import |
|                                      | ant; color: rgb(0, 102, 153) !import |
|                                      | ant; background: none !important;"}` |
|                                      | ));`{style="margin: 0px !important;  |
|                                      | padding: 0px !important; white-space |
|                                      | : nowrap; border: 0px !important; bo |
|                                      | rder-radius: 0px !important; bottom: |
|                                      |  auto !important; float: none !impor |
|                                      | tant; height: auto !important; left: |
|                                      |  auto !important; outline: 0px !impo |
|                                      | rtant; overflow: visible !important; |
|                                      |  position: static !important; right: |
|                                      |  auto !important; text-align: left ! |
|                                      | important; top: auto !important; ver |
|                                      | tical-align: baseline !important; wi |
|                                      | dth: auto !important; box-sizing: co |
|                                      | ntent-box !important; font-family: C |
|                                      | onsolas, 'Bitstream Vera Sans Mono', |
|                                      |  'Courier New', Courier, monospace ! |
|                                      | important; font-weight: normal !impo |
|                                      | rtant; font-style: normal !important |
|                                      | ; font-size: 1em !important; min-hei |
|                                      | ght: auto !important; color: rgb(0,  |
|                                      | 0, 0) !important; background: none ! |
|                                      | important;"}                         |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="margin: 0px !important; paddi |
|                                      | ng: 0px 1em !important; border-radiu |
|                                      | s: 0px !important; border: 0px !impo |
|                                      | rtant; bottom: auto !important; floa |
|                                      | t: none !important; height: auto !im |
|                                      | portant; left: auto !important; outl |
|                                      | ine: 0px !important; overflow: visib |
|                                      | le !important; position: static !imp |
|                                      | ortant; right: auto !important; text |
|                                      | -align: left !important; top: auto ! |
|                                      | important; vertical-align: baseline  |
|                                      | !important; width: auto !important;  |
|                                      | box-sizing: content-box !important;  |
|                                      | font-family: Consolas, 'Bitstream Ve |
|                                      | ra Sans Mono', 'Courier New', Courie |
|                                      | r, monospace !important; font-weight |
|                                      | : normal !important; font-style: nor |
|                                      | mal !important; font-size: 1em !impo |
|                                      | rtant; min-height: auto !important;  |
|                                      | white-space: pre !important; backgro |
|                                      | und: none rgb(248, 248, 248) !import |
|                                      | ant;">                               |
|                                      |                                      |
|                                      | `            `{style="margin: 0px !i |
|                                      | mportant; padding: 0px !important; w |
|                                      | hite-space: nowrap; border: 0px !imp |
|                                      | ortant; border-radius: 0px !importan |
|                                      | t; bottom: auto !important; float: n |
|                                      | one !important; height: auto !import |
|                                      | ant; left: auto !important; outline: |
|                                      |  0px !important; overflow: visible ! |
|                                      | important; position: static !importa |
|                                      | nt; right: auto !important; text-ali |
|                                      | gn: left !important; top: auto !impo |
|                                      | rtant; vertical-align: baseline !imp |
|                                      | ortant; width: auto !important; box- |
|                                      | sizing: content-box !important; font |
|                                      | -family: Consolas, 'Bitstream Vera S |
|                                      | ans Mono', 'Courier New', Courier, m |
|                                      | onospace !important; font-weight: no |
|                                      | rmal !important; font-style: normal  |
|                                      | !important; font-size: 1em !importan |
|                                      | t; min-height: auto !important; back |
|                                      | ground: none !important;"}`xmlserial |
|                                      | izer.Serialize(stream, strobj);`{sty |
|                                      | le="margin: 0px !important; padding: |
|                                      |  0px !important; white-space: nowrap |
|                                      | ; border: 0px !important; border-rad |
|                                      | ius: 0px !important; bottom: auto !i |
|                                      | mportant; float: none !important; he |
|                                      | ight: auto !important; left: auto !i |
|                                      | mportant; outline: 0px !important; o |
|                                      | verflow: visible !important; positio |
|                                      | n: static !important; right: auto !i |
|                                      | mportant; text-align: left !importan |
|                                      | t; top: auto !important; vertical-al |
|                                      | ign: baseline !important; width: aut |
|                                      | o !important; box-sizing: content-bo |
|                                      | x !important; font-family: Consolas, |
|                                      |  'Bitstream Vera Sans Mono', 'Courie |
|                                      | r New', Courier, monospace !importan |
|                                      | t; font-weight: normal !important; f |
|                                      | ont-style: normal !important; font-s |
|                                      | ize: 1em !important; min-height: aut |
|                                      | o !important; color: rgb(0, 0, 0) !i |
|                                      | mportant; background: none !importan |
|                                      | t;"}                                 |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="margin: 0px !important; paddi |
|                                      | ng: 0px 1em !important; border-radiu |
|                                      | s: 0px !important; border: 0px !impo |
|                                      | rtant; bottom: auto !important; floa |
|                                      | t: none !important; height: auto !im |
|                                      | portant; left: auto !important; outl |
|                                      | ine: 0px !important; overflow: visib |
|                                      | le !important; position: static !imp |
|                                      | ortant; right: auto !important; text |
|                                      | -align: left !important; top: auto ! |
|                                      | important; vertical-align: baseline  |
|                                      | !important; width: auto !important;  |
|                                      | box-sizing: content-box !important;  |
|                                      | font-family: Consolas, 'Bitstream Ve |
|                                      | ra Sans Mono', 'Courier New', Courie |
|                                      | r, monospace !important; font-weight |
|                                      | : normal !important; font-style: nor |
|                                      | mal !important; font-size: 1em !impo |
|                                      | rtant; min-height: auto !important;  |
|                                      | white-space: pre !important; backgro |
|                                      | und: none rgb(255, 255, 255) !import |
|                                      | ant;">                               |
|                                      |                                      |
|                                      | `            `{style="margin: 0px !i |
|                                      | mportant; padding: 0px !important; w |
|                                      | hite-space: nowrap; border: 0px !imp |
|                                      | ortant; border-radius: 0px !importan |
|                                      | t; bottom: auto !important; float: n |
|                                      | one !important; height: auto !import |
|                                      | ant; left: auto !important; outline: |
|                                      |  0px !important; overflow: visible ! |
|                                      | important; position: static !importa |
|                                      | nt; right: auto !important; text-ali |
|                                      | gn: left !important; top: auto !impo |
|                                      | rtant; vertical-align: baseline !imp |
|                                      | ortant; width: auto !important; box- |
|                                      | sizing: content-box !important; font |
|                                      | -family: Consolas, 'Bitstream Vera S |
|                                      | ans Mono', 'Courier New', Courier, m |
|                                      | onospace !important; font-weight: no |
|                                      | rmal !important; font-style: normal  |
|                                      | !important; font-size: 1em !importan |
|                                      | t; min-height: auto !important; back |
|                                      | ground: none !important;"}`stream.Cl |
|                                      | ose();`{style="margin: 0px !importan |
|                                      | t; padding: 0px !important; white-sp |
|                                      | ace: nowrap; border: 0px !important; |
|                                      |  border-radius: 0px !important; bott |
|                                      | om: auto !important; float: none !im |
|                                      | portant; height: auto !important; le |
|                                      | ft: auto !important; outline: 0px !i |
|                                      | mportant; overflow: visible !importa |
|                                      | nt; position: static !important; rig |
|                                      | ht: auto !important; text-align: lef |
|                                      | t !important; top: auto !important;  |
|                                      | vertical-align: baseline !important; |
|                                      |  width: auto !important; box-sizing: |
|                                      |  content-box !important; font-family |
|                                      | : Consolas, 'Bitstream Vera Sans Mon |
|                                      | o', 'Courier New', Courier, monospac |
|                                      | e !important; font-weight: normal !i |
|                                      | mportant; font-style: normal !import |
|                                      | ant; font-size: 1em !important; min- |
|                                      | height: auto !important; color: rgb( |
|                                      | 0, 0, 0) !important; background: non |
|                                      | e !important;"}                      |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="margin: 0px !important; paddi |
|                                      | ng: 0px 1em !important; border-radiu |
|                                      | s: 0px !important; border: 0px !impo |
|                                      | rtant; bottom: auto !important; floa |
|                                      | t: none !important; height: auto !im |
|                                      | portant; left: auto !important; outl |
|                                      | ine: 0px !important; overflow: visib |
|                                      | le !important; position: static !imp |
|                                      | ortant; right: auto !important; text |
|                                      | -align: left !important; top: auto ! |
|                                      | important; vertical-align: baseline  |
|                                      | !important; width: auto !important;  |
|                                      | box-sizing: content-box !important;  |
|                                      | font-family: Consolas, 'Bitstream Ve |
|                                      | ra Sans Mono', 'Courier New', Courie |
|                                      | r, monospace !important; font-weight |
|                                      | : normal !important; font-style: nor |
|                                      | mal !important; font-size: 1em !impo |
|                                      | rtant; min-height: auto !important;  |
|                                      | white-space: pre !important; backgro |
|                                      | und: none rgb(248, 248, 248) !import |
|                                      | ant;">                               |
|                                      |                                      |
|                                      |                                      |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="margin: 0px !important; paddi |
|                                      | ng: 0px 1em !important; border-radiu |
|                                      | s: 0px !important; border: 0px !impo |
|                                      | rtant; bottom: auto !important; floa |
|                                      | t: none !important; height: auto !im |
|                                      | portant; left: auto !important; outl |
|                                      | ine: 0px !important; overflow: visib |
|                                      | le !important; position: static !imp |
|                                      | ortant; right: auto !important; text |
|                                      | -align: left !important; top: auto ! |
|                                      | important; vertical-align: baseline  |
|                                      | !important; width: auto !important;  |
|                                      | box-sizing: content-box !important;  |
|                                      | font-family: Consolas, 'Bitstream Ve |
|                                      | ra Sans Mono', 'Courier New', Courie |
|                                      | r, monospace !important; font-weight |
|                                      | : normal !important; font-style: nor |
|                                      | mal !important; font-size: 1em !impo |
|                                      | rtant; min-height: auto !important;  |
|                                      | white-space: pre !important; backgro |
|                                      | und: none rgb(255, 255, 255) !import |
|                                      | ant;">                               |
|                                      |                                      |
|                                      |                                      |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="margin: 0px !important; paddi |
|                                      | ng: 0px 1em !important; border-radiu |
|                                      | s: 0px !important; border: 0px !impo |
|                                      | rtant; bottom: auto !important; floa |
|                                      | t: none !important; height: auto !im |
|                                      | portant; left: auto !important; outl |
|                                      | ine: 0px !important; overflow: visib |
|                                      | le !important; position: static !imp |
|                                      | ortant; right: auto !important; text |
|                                      | -align: left !important; top: auto ! |
|                                      | important; vertical-align: baseline  |
|                                      | !important; width: auto !important;  |
|                                      | box-sizing: content-box !important;  |
|                                      | font-family: Consolas, 'Bitstream Ve |
|                                      | ra Sans Mono', 'Courier New', Courie |
|                                      | r, monospace !important; font-weight |
|                                      | : normal !important; font-style: nor |
|                                      | mal !important; font-size: 1em !impo |
|                                      | rtant; min-height: auto !important;  |
|                                      | white-space: pre !important; backgro |
|                                      | und: none rgb(248, 248, 248) !import |
|                                      | ant;">                               |
|                                      |                                      |
|                                      | `            `{style="margin: 0px !i |
|                                      | mportant; padding: 0px !important; w |
|                                      | hite-space: nowrap; border: 0px !imp |
|                                      | ortant; border-radius: 0px !importan |
|                                      | t; bottom: auto !important; float: n |
|                                      | one !important; height: auto !import |
|                                      | ant; left: auto !important; outline: |
|                                      |  0px !important; overflow: visible ! |
|                                      | important; position: static !importa |
|                                      | nt; right: auto !important; text-ali |
|                                      | gn: left !important; top: auto !impo |
|                                      | rtant; vertical-align: baseline !imp |
|                                      | ortant; width: auto !important; box- |
|                                      | sizing: content-box !important; font |
|                                      | -family: Consolas, 'Bitstream Vera S |
|                                      | ans Mono', 'Courier New', Courier, m |
|                                      | onospace !important; font-weight: no |
|                                      | rmal !important; font-style: normal  |
|                                      | !important; font-size: 1em !importan |
|                                      | t; min-height: auto !important; back |
|                                      | ground: none !important;"}`//Deseria |
|                                      | lization of String Object`{style="ma |
|                                      | rgin: 0px !important; padding: 0px ! |
|                                      | important; white-space: nowrap; bord |
|                                      | er: 0px !important; border-radius: 0 |
|                                      | px !important; bottom: auto !importa |
|                                      | nt; float: none !important; height:  |
|                                      | auto !important; left: auto !importa |
|                                      | nt; outline: 0px !important; overflo |
|                                      | w: visible !important; position: sta |
|                                      | tic !important; right: auto !importa |
|                                      | nt; text-align: left !important; top |
|                                      | : auto !important; vertical-align: b |
|                                      | aseline !important; width: auto !imp |
|                                      | ortant; box-sizing: content-box !imp |
|                                      | ortant; font-family: Consolas, 'Bits |
|                                      | tream Vera Sans Mono', 'Courier New' |
|                                      | , Courier, monospace !important; fon |
|                                      | t-weight: normal !important; font-st |
|                                      | yle: normal !important; font-size: 1 |
|                                      | em !important; min-height: auto !imp |
|                                      | ortant; color: rgb(0, 130, 0) !impor |
|                                      | tant; background: none !important;"} |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="margin: 0px !important; paddi |
|                                      | ng: 0px 1em !important; border-radiu |
|                                      | s: 0px !important; border: 0px !impo |
|                                      | rtant; bottom: auto !important; floa |
|                                      | t: none !important; height: auto !im |
|                                      | portant; left: auto !important; outl |
|                                      | ine: 0px !important; overflow: visib |
|                                      | le !important; position: static !imp |
|                                      | ortant; right: auto !important; text |
|                                      | -align: left !important; top: auto ! |
|                                      | important; vertical-align: baseline  |
|                                      | !important; width: auto !important;  |
|                                      | box-sizing: content-box !important;  |
|                                      | font-family: Consolas, 'Bitstream Ve |
|                                      | ra Sans Mono', 'Courier New', Courie |
|                                      | r, monospace !important; font-weight |
|                                      | : normal !important; font-style: nor |
|                                      | mal !important; font-size: 1em !impo |
|                                      | rtant; min-height: auto !important;  |
|                                      | white-space: pre !important; backgro |
|                                      | und: none rgb(255, 255, 255) !import |
|                                      | ant;">                               |
|                                      |                                      |
|                                      | `            `{style="margin: 0px !i |
|                                      | mportant; padding: 0px !important; w |
|                                      | hite-space: nowrap; border: 0px !imp |
|                                      | ortant; border-radius: 0px !importan |
|                                      | t; bottom: auto !important; float: n |
|                                      | one !important; height: auto !import |
|                                      | ant; left: auto !important; outline: |
|                                      |  0px !important; overflow: visible ! |
|                                      | important; position: static !importa |
|                                      | nt; right: auto !important; text-ali |
|                                      | gn: left !important; top: auto !impo |
|                                      | rtant; vertical-align: baseline !imp |
|                                      | ortant; width: auto !important; box- |
|                                      | sizing: content-box !important; font |
|                                      | -family: Consolas, 'Bitstream Vera S |
|                                      | ans Mono', 'Courier New', Courier, m |
|                                      | onospace !important; font-weight: no |
|                                      | rmal !important; font-style: normal  |
|                                      | !important; font-size: 1em !importan |
|                                      | t; min-height: auto !important; back |
|                                      | ground: none !important;"}`FileStrea |
|                                      | m readstream = `{style="margin: 0px  |
|                                      | !important; padding: 0px !important; |
|                                      |  white-space: nowrap; border: 0px !i |
|                                      | mportant; border-radius: 0px !import |
|                                      | ant; bottom: auto !important; float: |
|                                      |  none !important; height: auto !impo |
|                                      | rtant; left: auto !important; outlin |
|                                      | e: 0px !important; overflow: visible |
|                                      |  !important; position: static !impor |
|                                      | tant; right: auto !important; text-a |
|                                      | lign: left !important; top: auto !im |
|                                      | portant; vertical-align: baseline !i |
|                                      | mportant; width: auto !important; bo |
|                                      | x-sizing: content-box !important; fo |
|                                      | nt-family: Consolas, 'Bitstream Vera |
|                                      |  Sans Mono', 'Courier New', Courier, |
|                                      |  monospace !important; font-weight:  |
|                                      | normal !important; font-style: norma |
|                                      | l !important; font-size: 1em !import |
|                                      | ant; min-height: auto !important; co |
|                                      | lor: rgb(0, 0, 0) !important; backgr |
|                                      | ound: none !important;"}`new`{style= |
|                                      | "margin: 0px !important; padding: 0p |
|                                      | x !important; white-space: nowrap; b |
|                                      | order: 0px !important; border-radius |
|                                      | : 0px !important; bottom: auto !impo |
|                                      | rtant; float: none !important; heigh |
|                                      | t: auto !important; left: auto !impo |
|                                      | rtant; outline: 0px !important; over |
|                                      | flow: visible !important; position:  |
|                                      | static !important; right: auto !impo |
|                                      | rtant; text-align: left !important;  |
|                                      | top: auto !important; vertical-align |
|                                      | : baseline !important; width: auto ! |
|                                      | important; box-sizing: content-box ! |
|                                      | important; font-family: Consolas, 'B |
|                                      | itstream Vera Sans Mono', 'Courier N |
|                                      | ew', Courier, monospace !important;  |
|                                      | font-weight: bold !important; font-s |
|                                      | tyle: normal !important; font-size:  |
|                                      | 1em !important; min-height: auto !im |
|                                      | portant; color: rgb(0, 102, 153) !im |
|                                      | portant; background: none !important |
|                                      | ;"}                                  |
|                                      | `FileStream(`{style="margin: 0px !im |
|                                      | portant; padding: 0px !important; wh |
|                                      | ite-space: nowrap; border: 0px !impo |
|                                      | rtant; border-radius: 0px !important |
|                                      | ; bottom: auto !important; float: no |
|                                      | ne !important; height: auto !importa |
|                                      | nt; left: auto !important; outline:  |
|                                      | 0px !important; overflow: visible !i |
|                                      | mportant; position: static !importan |
|                                      | t; right: auto !important; text-alig |
|                                      | n: left !important; top: auto !impor |
|                                      | tant; vertical-align: baseline !impo |
|                                      | rtant; width: auto !important; box-s |
|                                      | izing: content-box !important; font- |
|                                      | family: Consolas, 'Bitstream Vera Sa |
|                                      | ns Mono', 'Courier New', Courier, mo |
|                                      | nospace !important; font-weight: nor |
|                                      | mal !important; font-style: normal ! |
|                                      | important; font-size: 1em !important |
|                                      | ; min-height: auto !important; color |
|                                      | : rgb(0, 0, 0) !important; backgroun |
|                                      | d: none !important;"}`"C:\\StrObj.tx |
|                                      | t"`{style="margin: 0px !important; p |
|                                      | adding: 0px !important; white-space: |
|                                      |  nowrap; border: 0px !important; bor |
|                                      | der-radius: 0px !important; bottom:  |
|                                      | auto !important; float: none !import |
|                                      | ant; height: auto !important; left:  |
|                                      | auto !important; outline: 0px !impor |
|                                      | tant; overflow: visible !important;  |
|                                      | position: static !important; right:  |
|                                      | auto !important; text-align: left !i |
|                                      | mportant; top: auto !important; vert |
|                                      | ical-align: baseline !important; wid |
|                                      | th: auto !important; box-sizing: con |
|                                      | tent-box !important; font-family: Co |
|                                      | nsolas, 'Bitstream Vera Sans Mono',  |
|                                      | 'Courier New', Courier, monospace !i |
|                                      | mportant; font-weight: normal !impor |
|                                      | tant; font-style: normal !important; |
|                                      |  font-size: 1em !important; min-heig |
|                                      | ht: auto !important; color: blue !im |
|                                      | portant; background: none !important |
|                                      | ;"}`, FileMode.Open , FileAccess.Rea |
|                                      | d ,`{style="margin: 0px !important;  |
|                                      | padding: 0px !important; white-space |
|                                      | : nowrap; border: 0px !important; bo |
|                                      | rder-radius: 0px !important; bottom: |
|                                      |  auto !important; float: none !impor |
|                                      | tant; height: auto !important; left: |
|                                      |  auto !important; outline: 0px !impo |
|                                      | rtant; overflow: visible !important; |
|                                      |  position: static !important; right: |
|                                      |  auto !important; text-align: left ! |
|                                      | important; top: auto !important; ver |
|                                      | tical-align: baseline !important; wi |
|                                      | dth: auto !important; box-sizing: co |
|                                      | ntent-box !important; font-family: C |
|                                      | onsolas, 'Bitstream Vera Sans Mono', |
|                                      |  'Courier New', Courier, monospace ! |
|                                      | important; font-weight: normal !impo |
|                                      | rtant; font-style: normal !important |
|                                      | ; font-size: 1em !important; min-hei |
|                                      | ght: auto !important; color: rgb(0,  |
|                                      | 0, 0) !important; background: none ! |
|                                      | important;"}                         |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="margin: 0px !important; paddi |
|                                      | ng: 0px 1em !important; border-radiu |
|                                      | s: 0px !important; border: 0px !impo |
|                                      | rtant; bottom: auto !important; floa |
|                                      | t: none !important; height: auto !im |
|                                      | portant; left: auto !important; outl |
|                                      | ine: 0px !important; overflow: visib |
|                                      | le !important; position: static !imp |
|                                      | ortant; right: auto !important; text |
|                                      | -align: left !important; top: auto ! |
|                                      | important; vertical-align: baseline  |
|                                      | !important; width: auto !important;  |
|                                      | box-sizing: content-box !important;  |
|                                      | font-family: Consolas, 'Bitstream Ve |
|                                      | ra Sans Mono', 'Courier New', Courie |
|                                      | r, monospace !important; font-weight |
|                                      | : normal !important; font-style: nor |
|                                      | mal !important; font-size: 1em !impo |
|                                      | rtant; min-height: auto !important;  |
|                                      | white-space: pre !important; backgro |
|                                      | und: none rgb(248, 248, 248) !import |
|                                      | ant;">                               |
|                                      |                                      |
|                                      | `            `{style="margin: 0px !i |
|                                      | mportant; padding: 0px !important; w |
|                                      | hite-space: nowrap; border: 0px !imp |
|                                      | ortant; border-radius: 0px !importan |
|                                      | t; bottom: auto !important; float: n |
|                                      | one !important; height: auto !import |
|                                      | ant; left: auto !important; outline: |
|                                      |  0px !important; overflow: visible ! |
|                                      | important; position: static !importa |
|                                      | nt; right: auto !important; text-ali |
|                                      | gn: left !important; top: auto !impo |
|                                      | rtant; vertical-align: baseline !imp |
|                                      | ortant; width: auto !important; box- |
|                                      | sizing: content-box !important; font |
|                                      | -family: Consolas, 'Bitstream Vera S |
|                                      | ans Mono', 'Courier New', Courier, m |
|                                      | onospace !important; font-weight: no |
|                                      | rmal !important; font-style: normal  |
|                                      | !important; font-size: 1em !importan |
|                                      | t; min-height: auto !important; back |
|                                      | ground: none !important;"}`FileShare |
|                                      | .Read );`{style="margin: 0px !import |
|                                      | ant; padding: 0px !important; white- |
|                                      | space: nowrap; border: 0px !importan |
|                                      | t; border-radius: 0px !important; bo |
|                                      | ttom: auto !important; float: none ! |
|                                      | important; height: auto !important;  |
|                                      | left: auto !important; outline: 0px  |
|                                      | !important; overflow: visible !impor |
|                                      | tant; position: static !important; r |
|                                      | ight: auto !important; text-align: l |
|                                      | eft !important; top: auto !important |
|                                      | ; vertical-align: baseline !importan |
|                                      | t; width: auto !important; box-sizin |
|                                      | g: content-box !important; font-fami |
|                                      | ly: Consolas, 'Bitstream Vera Sans M |
|                                      | ono', 'Courier New', Courier, monosp |
|                                      | ace !important; font-weight: normal  |
|                                      | !important; font-style: normal !impo |
|                                      | rtant; font-size: 1em !important; mi |
|                                      | n-height: auto !important; color: rg |
|                                      | b(0, 0, 0) !important; background: n |
|                                      | one !important;"}                    |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="margin: 0px !important; paddi |
|                                      | ng: 0px 1em !important; border-radiu |
|                                      | s: 0px !important; border: 0px !impo |
|                                      | rtant; bottom: auto !important; floa |
|                                      | t: none !important; height: auto !im |
|                                      | portant; left: auto !important; outl |
|                                      | ine: 0px !important; overflow: visib |
|                                      | le !important; position: static !imp |
|                                      | ortant; right: auto !important; text |
|                                      | -align: left !important; top: auto ! |
|                                      | important; vertical-align: baseline  |
|                                      | !important; width: auto !important;  |
|                                      | box-sizing: content-box !important;  |
|                                      | font-family: Consolas, 'Bitstream Ve |
|                                      | ra Sans Mono', 'Courier New', Courie |
|                                      | r, monospace !important; font-weight |
|                                      | : normal !important; font-style: nor |
|                                      | mal !important; font-size: 1em !impo |
|                                      | rtant; min-height: auto !important;  |
|                                      | white-space: pre !important; backgro |
|                                      | und: none rgb(255, 255, 255) !import |
|                                      | ant;">                               |
|                                      |                                      |
|                                      | `            `{style="margin: 0px !i |
|                                      | mportant; padding: 0px !important; w |
|                                      | hite-space: nowrap; border: 0px !imp |
|                                      | ortant; border-radius: 0px !importan |
|                                      | t; bottom: auto !important; float: n |
|                                      | one !important; height: auto !import |
|                                      | ant; left: auto !important; outline: |
|                                      |  0px !important; overflow: visible ! |
|                                      | important; position: static !importa |
|                                      | nt; right: auto !important; text-ali |
|                                      | gn: left !important; top: auto !impo |
|                                      | rtant; vertical-align: baseline !imp |
|                                      | ortant; width: auto !important; box- |
|                                      | sizing: content-box !important; font |
|                                      | -family: Consolas, 'Bitstream Vera S |
|                                      | ans Mono', 'Courier New', Courier, m |
|                                      | onospace !important; font-weight: no |
|                                      | rmal !important; font-style: normal  |
|                                      | !important; font-size: 1em !importan |
|                                      | t; min-height: auto !important; back |
|                                      | ground: none !important;"}`string`{s |
|                                      | tyle="margin: 0px !important; paddin |
|                                      | g: 0px !important; white-space: nowr |
|                                      | ap; border: 0px !important; border-r |
|                                      | adius: 0px !important; bottom: auto  |
|                                      | !important; float: none !important;  |
|                                      | height: auto !important; left: auto  |
|                                      | !important; outline: 0px !important; |
|                                      |  overflow: visible !important; posit |
|                                      | ion: static !important; right: auto  |
|                                      | !important; text-align: left !import |
|                                      | ant; top: auto !important; vertical- |
|                                      | align: baseline !important; width: a |
|                                      | uto !important; box-sizing: content- |
|                                      | box !important; font-family: Consola |
|                                      | s, 'Bitstream Vera Sans Mono', 'Cour |
|                                      | ier New', Courier, monospace !import |
|                                      | ant; font-weight: bold !important; f |
|                                      | ont-style: normal !important; font-s |
|                                      | ize: 1em !important; min-height: aut |
|                                      | o !important; color: rgb(0, 102, 153 |
|                                      | ) !important; background: none !impo |
|                                      | rtant;"}                             |
|                                      | `readdata = (`{style="margin: 0px !i |
|                                      | mportant; padding: 0px !important; w |
|                                      | hite-space: nowrap; border: 0px !imp |
|                                      | ortant; border-radius: 0px !importan |
|                                      | t; bottom: auto !important; float: n |
|                                      | one !important; height: auto !import |
|                                      | ant; left: auto !important; outline: |
|                                      |  0px !important; overflow: visible ! |
|                                      | important; position: static !importa |
|                                      | nt; right: auto !important; text-ali |
|                                      | gn: left !important; top: auto !impo |
|                                      | rtant; vertical-align: baseline !imp |
|                                      | ortant; width: auto !important; box- |
|                                      | sizing: content-box !important; font |
|                                      | -family: Consolas, 'Bitstream Vera S |
|                                      | ans Mono', 'Courier New', Courier, m |
|                                      | onospace !important; font-weight: no |
|                                      | rmal !important; font-style: normal  |
|                                      | !important; font-size: 1em !importan |
|                                      | t; min-height: auto !important; colo |
|                                      | r: rgb(0, 0, 0) !important; backgrou |
|                                      | nd: none !important;"}`string`{style |
|                                      | ="margin: 0px !important; padding: 0 |
|                                      | px !important; white-space: nowrap;  |
|                                      | border: 0px !important; border-radiu |
|                                      | s: 0px !important; bottom: auto !imp |
|                                      | ortant; float: none !important; heig |
|                                      | ht: auto !important; left: auto !imp |
|                                      | ortant; outline: 0px !important; ove |
|                                      | rflow: visible !important; position: |
|                                      |  static !important; right: auto !imp |
|                                      | ortant; text-align: left !important; |
|                                      |  top: auto !important; vertical-alig |
|                                      | n: baseline !important; width: auto  |
|                                      | !important; box-sizing: content-box  |
|                                      | !important; font-family: Consolas, ' |
|                                      | Bitstream Vera Sans Mono', 'Courier  |
|                                      | New', Courier, monospace !important; |
|                                      |  font-weight: bold !important; font- |
|                                      | style: normal !important; font-size: |
|                                      |  1em !important; min-height: auto !i |
|                                      | mportant; color: rgb(0, 102, 153) !i |
|                                      | mportant; background: none !importan |
|                                      | t;"}`)xmlserializer.Deserialize(read |
|                                      | stream);`{style="margin: 0px !import |
|                                      | ant; padding: 0px !important; white- |
|                                      | space: nowrap; border: 0px !importan |
|                                      | t; border-radius: 0px !important; bo |
|                                      | ttom: auto !important; float: none ! |
|                                      | important; height: auto !important;  |
|                                      | left: auto !important; outline: 0px  |
|                                      | !important; overflow: visible !impor |
|                                      | tant; position: static !important; r |
|                                      | ight: auto !important; text-align: l |
|                                      | eft !important; top: auto !important |
|                                      | ; vertical-align: baseline !importan |
|                                      | t; width: auto !important; box-sizin |
|                                      | g: content-box !important; font-fami |
|                                      | ly: Consolas, 'Bitstream Vera Sans M |
|                                      | ono', 'Courier New', Courier, monosp |
|                                      | ace !important; font-weight: normal  |
|                                      | !important; font-style: normal !impo |
|                                      | rtant; font-size: 1em !important; mi |
|                                      | n-height: auto !important; color: rg |
|                                      | b(0, 0, 0) !important; background: n |
|                                      | one !important;"}                    |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="margin: 0px !important; paddi |
|                                      | ng: 0px 1em !important; border-radiu |
|                                      | s: 0px !important; border: 0px !impo |
|                                      | rtant; bottom: auto !important; floa |
|                                      | t: none !important; height: auto !im |
|                                      | portant; left: auto !important; outl |
|                                      | ine: 0px !important; overflow: visib |
|                                      | le !important; position: static !imp |
|                                      | ortant; right: auto !important; text |
|                                      | -align: left !important; top: auto ! |
|                                      | important; vertical-align: baseline  |
|                                      | !important; width: auto !important;  |
|                                      | box-sizing: content-box !important;  |
|                                      | font-family: Consolas, 'Bitstream Ve |
|                                      | ra Sans Mono', 'Courier New', Courie |
|                                      | r, monospace !important; font-weight |
|                                      | : normal !important; font-style: nor |
|                                      | mal !important; font-size: 1em !impo |
|                                      | rtant; min-height: auto !important;  |
|                                      | white-space: pre !important; backgro |
|                                      | und: none rgb(248, 248, 248) !import |
|                                      | ant;">                               |
|                                      |                                      |
|                                      | `            `{style="margin: 0px !i |
|                                      | mportant; padding: 0px !important; w |
|                                      | hite-space: nowrap; border: 0px !imp |
|                                      | ortant; border-radius: 0px !importan |
|                                      | t; bottom: auto !important; float: n |
|                                      | one !important; height: auto !import |
|                                      | ant; left: auto !important; outline: |
|                                      |  0px !important; overflow: visible ! |
|                                      | important; position: static !importa |
|                                      | nt; right: auto !important; text-ali |
|                                      | gn: left !important; top: auto !impo |
|                                      | rtant; vertical-align: baseline !imp |
|                                      | ortant; width: auto !important; box- |
|                                      | sizing: content-box !important; font |
|                                      | -family: Consolas, 'Bitstream Vera S |
|                                      | ans Mono', 'Courier New', Courier, m |
|                                      | onospace !important; font-weight: no |
|                                      | rmal !important; font-style: normal  |
|                                      | !important; font-size: 1em !importan |
|                                      | t; min-height: auto !important; back |
|                                      | ground: none !important;"}`readstrea |
|                                      | m.Close();`{style="margin: 0px !impo |
|                                      | rtant; padding: 0px !important; whit |
|                                      | e-space: nowrap; border: 0px !import |
|                                      | ant; border-radius: 0px !important;  |
|                                      | bottom: auto !important; float: none |
|                                      |  !important; height: auto !important |
|                                      | ; left: auto !important; outline: 0p |
|                                      | x !important; overflow: visible !imp |
|                                      | ortant; position: static !important; |
|                                      |  right: auto !important; text-align: |
|                                      |  left !important; top: auto !importa |
|                                      | nt; vertical-align: baseline !import |
|                                      | ant; width: auto !important; box-siz |
|                                      | ing: content-box !important; font-fa |
|                                      | mily: Consolas, 'Bitstream Vera Sans |
|                                      |  Mono', 'Courier New', Courier, mono |
|                                      | space !important; font-weight: norma |
|                                      | l !important; font-style: normal !im |
|                                      | portant; font-size: 1em !important;  |
|                                      | min-height: auto !important; color:  |
|                                      | rgb(0, 0, 0) !important; background: |
|                                      |  none !important;"}                  |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="margin: 0px !important; paddi |
|                                      | ng: 0px 1em !important; border-radiu |
|                                      | s: 0px !important; border: 0px !impo |
|                                      | rtant; bottom: auto !important; floa |
|                                      | t: none !important; height: auto !im |
|                                      | portant; left: auto !important; outl |
|                                      | ine: 0px !important; overflow: visib |
|                                      | le !important; position: static !imp |
|                                      | ortant; right: auto !important; text |
|                                      | -align: left !important; top: auto ! |
|                                      | important; vertical-align: baseline  |
|                                      | !important; width: auto !important;  |
|                                      | box-sizing: content-box !important;  |
|                                      | font-family: Consolas, 'Bitstream Ve |
|                                      | ra Sans Mono', 'Courier New', Courie |
|                                      | r, monospace !important; font-weight |
|                                      | : normal !important; font-style: nor |
|                                      | mal !important; font-size: 1em !impo |
|                                      | rtant; min-height: auto !important;  |
|                                      | white-space: pre !important; backgro |
|                                      | und: none rgb(255, 255, 255) !import |
|                                      | ant;">                               |
|                                      |                                      |
|                                      | `            `{style="margin: 0px !i |
|                                      | mportant; padding: 0px !important; w |
|                                      | hite-space: nowrap; border: 0px !imp |
|                                      | ortant; border-radius: 0px !importan |
|                                      | t; bottom: auto !important; float: n |
|                                      | one !important; height: auto !import |
|                                      | ant; left: auto !important; outline: |
|                                      |  0px !important; overflow: visible ! |
|                                      | important; position: static !importa |
|                                      | nt; right: auto !important; text-ali |
|                                      | gn: left !important; top: auto !impo |
|                                      | rtant; vertical-align: baseline !imp |
|                                      | ortant; width: auto !important; box- |
|                                      | sizing: content-box !important; font |
|                                      | -family: Consolas, 'Bitstream Vera S |
|                                      | ans Mono', 'Courier New', Courier, m |
|                                      | onospace !important; font-weight: no |
|                                      | rmal !important; font-style: normal  |
|                                      | !important; font-size: 1em !importan |
|                                      | t; min-height: auto !important; back |
|                                      | ground: none !important;"}`Console.W |
|                                      | riteLine(readdata);`{style="margin:  |
|                                      | 0px !important; padding: 0px !import |
|                                      | ant; white-space: nowrap; border: 0p |
|                                      | x !important; border-radius: 0px !im |
|                                      | portant; bottom: auto !important; fl |
|                                      | oat: none !important; height: auto ! |
|                                      | important; left: auto !important; ou |
|                                      | tline: 0px !important; overflow: vis |
|                                      | ible !important; position: static !i |
|                                      | mportant; right: auto !important; te |
|                                      | xt-align: left !important; top: auto |
|                                      |  !important; vertical-align: baselin |
|                                      | e !important; width: auto !important |
|                                      | ; box-sizing: content-box !important |
|                                      | ; font-family: Consolas, 'Bitstream  |
|                                      | Vera Sans Mono', 'Courier New', Cour |
|                                      | ier, monospace !important; font-weig |
|                                      | ht: normal !important; font-style: n |
|                                      | ormal !important; font-size: 1em !im |
|                                      | portant; min-height: auto !important |
|                                      | ; color: rgb(0, 0, 0) !important; ba |
|                                      | ckground: none !important;"}         |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="margin: 0px !important; paddi |
|                                      | ng: 0px 1em !important; border-radiu |
|                                      | s: 0px !important; border: 0px !impo |
|                                      | rtant; bottom: auto !important; floa |
|                                      | t: none !important; height: auto !im |
|                                      | portant; left: auto !important; outl |
|                                      | ine: 0px !important; overflow: visib |
|                                      | le !important; position: static !imp |
|                                      | ortant; right: auto !important; text |
|                                      | -align: left !important; top: auto ! |
|                                      | important; vertical-align: baseline  |
|                                      | !important; width: auto !important;  |
|                                      | box-sizing: content-box !important;  |
|                                      | font-family: Consolas, 'Bitstream Ve |
|                                      | ra Sans Mono', 'Courier New', Courie |
|                                      | r, monospace !important; font-weight |
|                                      | : normal !important; font-style: nor |
|                                      | mal !important; font-size: 1em !impo |
|                                      | rtant; min-height: auto !important;  |
|                                      | white-space: pre !important; backgro |
|                                      | und: none rgb(248, 248, 248) !import |
|                                      | ant;">                               |
|                                      |                                      |
|                                      | `            `{style="margin: 0px !i |
|                                      | mportant; padding: 0px !important; w |
|                                      | hite-space: nowrap; border: 0px !imp |
|                                      | ortant; border-radius: 0px !importan |
|                                      | t; bottom: auto !important; float: n |
|                                      | one !important; height: auto !import |
|                                      | ant; left: auto !important; outline: |
|                                      |  0px !important; overflow: visible ! |
|                                      | important; position: static !importa |
|                                      | nt; right: auto !important; text-ali |
|                                      | gn: left !important; top: auto !impo |
|                                      | rtant; vertical-align: baseline !imp |
|                                      | ortant; width: auto !important; box- |
|                                      | sizing: content-box !important; font |
|                                      | -family: Consolas, 'Bitstream Vera S |
|                                      | ans Mono', 'Courier New', Courier, m |
|                                      | onospace !important; font-weight: no |
|                                      | rmal !important; font-style: normal  |
|                                      | !important; font-size: 1em !importan |
|                                      | t; min-height: auto !important; back |
|                                      | ground: none !important;"}`Console.R |
|                                      | eadLine();`{style="margin: 0px !impo |
|                                      | rtant; padding: 0px !important; whit |
|                                      | e-space: nowrap; border: 0px !import |
|                                      | ant; border-radius: 0px !important;  |
|                                      | bottom: auto !important; float: none |
|                                      |  !important; height: auto !important |
|                                      | ; left: auto !important; outline: 0p |
|                                      | x !important; overflow: visible !imp |
|                                      | ortant; position: static !important; |
|                                      |  right: auto !important; text-align: |
|                                      |  left !important; top: auto !importa |
|                                      | nt; vertical-align: baseline !import |
|                                      | ant; width: auto !important; box-siz |
|                                      | ing: content-box !important; font-fa |
|                                      | mily: Consolas, 'Bitstream Vera Sans |
|                                      |  Mono', 'Courier New', Courier, mono |
|                                      | space !important; font-weight: norma |
|                                      | l !important; font-style: normal !im |
|                                      | portant; font-size: 1em !important;  |
|                                      | min-height: auto !important; color:  |
|                                      | rgb(0, 0, 0) !important; background: |
|                                      |  none !important;"}                  |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="margin: 0px !important; paddi |
|                                      | ng: 0px 1em !important; border-radiu |
|                                      | s: 0px !important; border: 0px !impo |
|                                      | rtant; bottom: auto !important; floa |
|                                      | t: none !important; height: auto !im |
|                                      | portant; left: auto !important; outl |
|                                      | ine: 0px !important; overflow: visib |
|                                      | le !important; position: static !imp |
|                                      | ortant; right: auto !important; text |
|                                      | -align: left !important; top: auto ! |
|                                      | important; vertical-align: baseline  |
|                                      | !important; width: auto !important;  |
|                                      | box-sizing: content-box !important;  |
|                                      | font-family: Consolas, 'Bitstream Ve |
|                                      | ra Sans Mono', 'Courier New', Courie |
|                                      | r, monospace !important; font-weight |
|                                      | : normal !important; font-style: nor |
|                                      | mal !important; font-size: 1em !impo |
|                                      | rtant; min-height: auto !important;  |
|                                      | white-space: pre !important; backgro |
|                                      | und: none rgb(255, 255, 255) !import |
|                                      | ant;">                               |
|                                      |                                      |
|                                      |                                      |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="margin: 0px !important; paddi |
|                                      | ng: 0px 1em !important; border-radiu |
|                                      | s: 0px !important; border: 0px !impo |
|                                      | rtant; bottom: auto !important; floa |
|                                      | t: none !important; height: auto !im |
|                                      | portant; left: auto !important; outl |
|                                      | ine: 0px !important; overflow: visib |
|                                      | le !important; position: static !imp |
|                                      | ortant; right: auto !important; text |
|                                      | -align: left !important; top: auto ! |
|                                      | important; vertical-align: baseline  |
|                                      | !important; width: auto !important;  |
|                                      | box-sizing: content-box !important;  |
|                                      | font-family: Consolas, 'Bitstream Ve |
|                                      | ra Sans Mono', 'Courier New', Courie |
|                                      | r, monospace !important; font-weight |
|                                      | : normal !important; font-style: nor |
|                                      | mal !important; font-size: 1em !impo |
|                                      | rtant; min-height: auto !important;  |
|                                      | white-space: pre !important; backgro |
|                                      | und: none rgb(248, 248, 248) !import |
|                                      | ant;">                               |
|                                      |                                      |
|                                      |                                      |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="margin: 0px !important; paddi |
|                                      | ng: 0px 1em !important; border-radiu |
|                                      | s: 0px !important; border: 0px !impo |
|                                      | rtant; bottom: auto !important; floa |
|                                      | t: none !important; height: auto !im |
|                                      | portant; left: auto !important; outl |
|                                      | ine: 0px !important; overflow: visib |
|                                      | le !important; position: static !imp |
|                                      | ortant; right: auto !important; text |
|                                      | -align: left !important; top: auto ! |
|                                      | important; vertical-align: baseline  |
|                                      | !important; width: auto !important;  |
|                                      | box-sizing: content-box !important;  |
|                                      | font-family: Consolas, 'Bitstream Ve |
|                                      | ra Sans Mono', 'Courier New', Courie |
|                                      | r, monospace !important; font-weight |
|                                      | : normal !important; font-style: nor |
|                                      | mal !important; font-size: 1em !impo |
|                                      | rtant; min-height: auto !important;  |
|                                      | white-space: pre !important; backgro |
|                                      | und: none rgb(255, 255, 255) !import |
|                                      | ant;">                               |
|                                      |                                      |
|                                      | `        `{style="margin: 0px !impor |
|                                      | tant; padding: 0px !important; white |
|                                      | -space: nowrap; border: 0px !importa |
|                                      | nt; border-radius: 0px !important; b |
|                                      | ottom: auto !important; float: none  |
|                                      | !important; height: auto !important; |
|                                      |  left: auto !important; outline: 0px |
|                                      |  !important; overflow: visible !impo |
|                                      | rtant; position: static !important;  |
|                                      | right: auto !important; text-align:  |
|                                      | left !important; top: auto !importan |
|                                      | t; vertical-align: baseline !importa |
|                                      | nt; width: auto !important; box-sizi |
|                                      | ng: content-box !important; font-fam |
|                                      | ily: Consolas, 'Bitstream Vera Sans  |
|                                      | Mono', 'Courier New', Courier, monos |
|                                      | pace !important; font-weight: normal |
|                                      |  !important; font-style: normal !imp |
|                                      | ortant; font-size: 1em !important; m |
|                                      | in-height: auto !important; backgrou |
|                                      | nd: none !important;"}`}`{style="mar |
|                                      | gin: 0px !important; padding: 0px !i |
|                                      | mportant; white-space: nowrap; borde |
|                                      | r: 0px !important; border-radius: 0p |
|                                      | x !important; bottom: auto !importan |
|                                      | t; float: none !important; height: a |
|                                      | uto !important; left: auto !importan |
|                                      | t; outline: 0px !important; overflow |
|                                      | : visible !important; position: stat |
|                                      | ic !important; right: auto !importan |
|                                      | t; text-align: left !important; top: |
|                                      |  auto !important; vertical-align: ba |
|                                      | seline !important; width: auto !impo |
|                                      | rtant; box-sizing: content-box !impo |
|                                      | rtant; font-family: Consolas, 'Bitst |
|                                      | ream Vera Sans Mono', 'Courier New', |
|                                      |  Courier, monospace !important; font |
|                                      | -weight: normal !important; font-sty |
|                                      | le: normal !important; font-size: 1e |
|                                      | m !important; min-height: auto !impo |
|                                      | rtant; color: rgb(0, 0, 0) !importan |
|                                      | t; background: none !important;"}    |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="margin: 0px !important; paddi |
|                                      | ng: 0px 1em !important; border-radiu |
|                                      | s: 0px !important; border: 0px !impo |
|                                      | rtant; bottom: auto !important; floa |
|                                      | t: none !important; height: auto !im |
|                                      | portant; left: auto !important; outl |
|                                      | ine: 0px !important; overflow: visib |
|                                      | le !important; position: static !imp |
|                                      | ortant; right: auto !important; text |
|                                      | -align: left !important; top: auto ! |
|                                      | important; vertical-align: baseline  |
|                                      | !important; width: auto !important;  |
|                                      | box-sizing: content-box !important;  |
|                                      | font-family: Consolas, 'Bitstream Ve |
|                                      | ra Sans Mono', 'Courier New', Courie |
|                                      | r, monospace !important; font-weight |
|                                      | : normal !important; font-style: nor |
|                                      | mal !important; font-size: 1em !impo |
|                                      | rtant; min-height: auto !important;  |
|                                      | white-space: pre !important; backgro |
|                                      | und: none rgb(248, 248, 248) !import |
|                                      | ant;">                               |
|                                      |                                      |
|                                      | `    `{style="margin: 0px !important |
|                                      | ; padding: 0px !important; white-spa |
|                                      | ce: nowrap; border: 0px !important;  |
|                                      | border-radius: 0px !important; botto |
|                                      | m: auto !important; float: none !imp |
|                                      | ortant; height: auto !important; lef |
|                                      | t: auto !important; outline: 0px !im |
|                                      | portant; overflow: visible !importan |
|                                      | t; position: static !important; righ |
|                                      | t: auto !important; text-align: left |
|                                      |  !important; top: auto !important; v |
|                                      | ertical-align: baseline !important;  |
|                                      | width: auto !important; box-sizing:  |
|                                      | content-box !important; font-family: |
|                                      |  Consolas, 'Bitstream Vera Sans Mono |
|                                      | ', 'Courier New', Courier, monospace |
|                                      |  !important; font-weight: normal !im |
|                                      | portant; font-style: normal !importa |
|                                      | nt; font-size: 1em !important; min-h |
|                                      | eight: auto !important; background:  |
|                                      | none !important;"}`}`{style="margin: |
|                                      |  0px !important; padding: 0px !impor |
|                                      | tant; white-space: nowrap; border: 0 |
|                                      | px !important; border-radius: 0px !i |
|                                      | mportant; bottom: auto !important; f |
|                                      | loat: none !important; height: auto  |
|                                      | !important; left: auto !important; o |
|                                      | utline: 0px !important; overflow: vi |
|                                      | sible !important; position: static ! |
|                                      | important; right: auto !important; t |
|                                      | ext-align: left !important; top: aut |
|                                      | o !important; vertical-align: baseli |
|                                      | ne !important; width: auto !importan |
|                                      | t; box-sizing: content-box !importan |
|                                      | t; font-family: Consolas, 'Bitstream |
|                                      |  Vera Sans Mono', 'Courier New', Cou |
|                                      | rier, monospace !important; font-wei |
|                                      | ght: normal !important; font-style:  |
|                                      | normal !important; font-size: 1em !i |
|                                      | mportant; min-height: auto !importan |
|                                      | t; color: rgb(0, 0, 0) !important; b |
|                                      | ackground: none !important;"}        |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="margin: 0px !important; paddi |
|                                      | ng: 0px 1em !important; border-radiu |
|                                      | s: 0px !important; border: 0px !impo |
|                                      | rtant; bottom: auto !important; floa |
|                                      | t: none !important; height: auto !im |
|                                      | portant; left: auto !important; outl |
|                                      | ine: 0px !important; overflow: visib |
|                                      | le !important; position: static !imp |
|                                      | ortant; right: auto !important; text |
|                                      | -align: left !important; top: auto ! |
|                                      | important; vertical-align: baseline  |
|                                      | !important; width: auto !important;  |
|                                      | box-sizing: content-box !important;  |
|                                      | font-family: Consolas, 'Bitstream Ve |
|                                      | ra Sans Mono', 'Courier New', Courie |
|                                      | r, monospace !important; font-weight |
|                                      | : normal !important; font-style: nor |
|                                      | mal !important; font-size: 1em !impo |
|                                      | rtant; min-height: auto !important;  |
|                                      | white-space: pre !important; backgro |
|                                      | und: none rgb(255, 255, 255) !import |
|                                      | ant;">                               |
|                                      |                                      |
|                                      | `}`{style="margin: 0px !important; p |
|                                      | adding: 0px !important; white-space: |
|                                      |  nowrap; border: 0px !important; bor |
|                                      | der-radius: 0px !important; bottom:  |
|                                      | auto !important; float: none !import |
|                                      | ant; height: auto !important; left:  |
|                                      | auto !important; outline: 0px !impor |
|                                      | tant; overflow: visible !important;  |
|                                      | position: static !important; right:  |
|                                      | auto !important; text-align: left !i |
|                                      | mportant; top: auto !important; vert |
|                                      | ical-align: baseline !important; wid |
|                                      | th: auto !important; box-sizing: con |
|                                      | tent-box !important; font-family: Co |
|                                      | nsolas, 'Bitstream Vera Sans Mono',  |
|                                      | 'Courier New', Courier, monospace !i |
|                                      | mportant; font-weight: normal !impor |
|                                      | tant; font-style: normal !important; |
|                                      |  font-size: 1em !important; min-heig |
|                                      | ht: auto !important; color: rgb(0, 0 |
|                                      | , 0) !important; background: none !i |
|                                      | mportant;"}                          |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+

</div>

</div>

</div>

<div>

**什么是格式化器？**

一个**格式化器**用来确定一个对象的序列格式。它们目的是在网络上传输一个对象之前将其序列化成合适的格式。它们提供**IFormatter**接口。在.NET里提供了两个格式化类：**BinaryFormatter**和**SoapFormatter**，它们都继承了**IFormatter**接口。

**使用序列化**

<div
style="margin: 0px 0px 5pt; padding: 0px; color: rgb(0, 0, 0); font-family: 'Microsoft YaHei', Verdana, sans-serif, SimSun; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); font-size: 14px;">

<div>

序列化允许开发人员保存一个对象的状态并在需要的时候重构对象，同时很好地支持对象存储和数据交换。通过序列化，开发人员可以利用Web
Service发送对象到远端应用程序，从一个域传输对象到另一个域，以XML的格式传输一个对象并能通过防火墙，或者在应用程序间保持安全性或用户特定信息等等。

</div>

</div>

</div>

</div>

</div>

</div>

</div>
