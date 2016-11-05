<div class="middle clearfix">

<div class="m-wrap">

<div class="detail-left float-l">

<div class="detail-main">

<div
style="border: 0px none rgb(37, 37, 37); color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 9028px; line-height: 28px; margin: 0px; outline: rgb(37, 37, 37) none 0px; padding: 0px; text-decoration: none; width: 720px;">

![insane\_productivity-730x310.jpg](iOS中的谓词（NSPredicate）使用%20-%20CocoaChina_让移动开发更简单_files/1452223300548565.jpg "1452223300548565.jpg"){width="599"
height="287"}

本文为投稿文章，作者：[sunny\_zl](http://www.jianshu.com/users/c2f0de304708/latest_articles) 

首先，我们需要知道何谓谓词，让我们看看官方的解释:

<span
style="border: 0px none rgb(127, 127, 127); color: rgb(127, 127, 127); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; line-height: 28px; margin: 0px; outline: rgb(127, 127, 127) none 0px; padding: 0px; text-decoration: none;">The
NSPredicate class is used to define logical conditions used to constrain
a search either for a fetch or for in-memory filtering.</span>

NSPredicate类是用来定义逻辑条件约束的获取或内存中的过滤搜索。

可以使用谓词来表示逻辑条件，用于描述对象持久性存储在内存中的对象过滤。其实意思就是：我是一个过滤器，不符合条件的都滚开。

**一、NSPredicate的基本语法**

我们使用一门语言，无论是外语还是计算机语言，总是从语法开始的，这样我们才能正确的把握逻辑。所以我们从语法开始说起。在这部分我们仅关心其语法的使用

只要我们使用谓词（NSPredicate）都需要为谓词定义谓词表达式,而这个表达式必须是一个返回BOOL的值。

谓词表达式由表达式、运算符和值构成。

<span
style="border: 0px none rgb(149, 55, 52); color: rgb(149, 55, 52); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; line-height: 28px; margin: 0px; outline: rgb(149, 55, 52) none 0px; padding: 0px; text-decoration: none;">1.比较运算符</span>

比较运算符如下

-   =、==：判断两个表达式是否相等，在谓词中=和==是相同的意思都是判断，而没有赋值这一说

<div
style="border: 0px none rgb(37, 37, 37); color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 75px; line-height: 28px; margin: 0px; outline: rgb(37, 37, 37) none 0px; padding: 0px; text-decoration: none; width: 720px;">

<div
style="background: none 0% 0% / auto repeat scroll padding-box border-box rgb(255, 255, 255); border: 0px none rgb(37, 37, 37); bottom: 0px; color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 75px; left: 0px; line-height: 28px; margin: 14px 0px; outline: rgb(37, 37, 37) none 0px; overflow: auto; padding: 0px; position: relative; right: 0px; text-decoration: none; top: 0px; width: 703px;">

+--------------------------------------+--------------------------------------+
| <div                                 | <div                                 |
| style="background: none 0% 0% / auto | style="border: 0px none rgb(37, 37,  |
|  repeat scroll padding-box border-bo | 37); bottom: 0px; color: rgb(37, 37, |
| x rgb(255, 255, 255); color: rgb(175 |  37); display: block; font-style: no |
| , 175, 175); display: block; font-st | rmal; font-variant: normal; font-wei |
| yle: normal; font-variant: normal; f | ght: normal; font-stretch: normal; f |
| ont-weight: normal; font-stretch: no | ont-size: 14px; font-family: Consola |
| rmal; font-size: 14px; font-family:  | s, &quot;Bitstream Vera Sans Mono&qu |
| Consolas, &quot;Bitstream Vera Sans  | ot;, &quot;Courier New&quot;, Courie |
| Mono&quot;, &quot;Courier New&quot;, | r, monospace; height: 75px; left: 0p |
|  Courier, monospace; height: 15px; l | x; line-height: 15.4px; margin: 0px; |
| ine-height: 15.4px; margin: 0px; out |  outline: rgb(37, 37, 37) none 0px;  |
| line: rgb(175, 175, 175) none 0px; p | padding: 0px; position: relative; ri |
| adding: 0px 7px 0px 14px; text-align | ght: 0px; text-align: left; text-dec |
| : right; text-decoration: none; whit | oration: none; top: 0px; width: 671p |
| e-space: pre; width: 8px;">          | x;">                                 |
|                                      |                                      |
| 1                                    | <div                                 |
|                                      | style="background: none 0% 0% / auto |
| </div>                               |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
| <div                                 | ne rgb(37, 37, 37); color: rgb(37, 3 |
| style="background: none 0% 0% / auto | 7, 37); display: block; font-style:  |
|  repeat scroll padding-box border-bo | normal; font-variant: normal; font-w |
| x rgb(255, 255, 255); color: rgb(175 | eight: normal; font-stretch: normal; |
| , 175, 175); display: block; font-st |  font-size: 14px; font-family: Conso |
| yle: normal; font-variant: normal; f | las, &quot;Bitstream Vera Sans Mono& |
| ont-weight: normal; font-stretch: no | quot;, &quot;Courier New&quot;, Cour |
| rmal; font-size: 14px; font-family:  | ier, monospace; height: 15px; line-h |
| Consolas, &quot;Bitstream Vera Sans  | eight: 15.4px; margin: 0px; outline: |
| Mono&quot;, &quot;Courier New&quot;, |  rgb(37, 37, 37) none 0px; padding:  |
|  Courier, monospace; height: 15px; l | 0px 14px; text-align: left; text-dec |
| ine-height: 15.4px; margin: 0px; out | oration: none; white-space: pre; wid |
| line: rgb(175, 175, 175) none 0px; p | th: 643px;">                         |
| adding: 0px 7px 0px 14px; text-align |                                      |
| : right; text-decoration: none; whit | `NSNumber *testNumber = @123;`{style |
| e-space: pre; width: 8px;">          | ="display: inline; font-style: norma |
|                                      | l; font-variant: normal; font-weight |
| 2                                    | : normal; font-stretch: normal; font |
|                                      | -size: 14px; font-family: Consolas,  |
| </div>                               | "Bitstream Vera Sans Mono", "Courier |
|                                      |  New", Courier, monospace; line-heig |
| <div                                 | ht: 15.4px; margin: 0px; padding: 0p |
| style="background: none 0% 0% / auto | x; text-align: left; text-decoration |
|  repeat scroll padding-box border-bo | : none; white-space: pre;"}          |
| x rgb(255, 255, 255); color: rgb(175 |                                      |
| , 175, 175); display: block; font-st | </div>                               |
| yle: normal; font-variant: normal; f |                                      |
| ont-weight: normal; font-stretch: no | <div                                 |
| rmal; font-size: 14px; font-family:  | style="background: none 0% 0% / auto |
| Consolas, &quot;Bitstream Vera Sans  |  repeat scroll padding-box border-bo |
| Mono&quot;, &quot;Courier New&quot;, | x rgb(255, 255, 255); border: 0px no |
|  Courier, monospace; height: 15px; l | ne rgb(37, 37, 37); color: rgb(37, 3 |
| ine-height: 15.4px; margin: 0px; out | 7, 37); display: block; font-style:  |
| line: rgb(175, 175, 175) none 0px; p | normal; font-variant: normal; font-w |
| adding: 0px 7px 0px 14px; text-align | eight: normal; font-stretch: normal; |
| : right; text-decoration: none; whit |  font-size: 14px; font-family: Conso |
| e-space: pre; width: 8px;">          | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
| 3                                    | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
| </div>                               |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
| <div                                 | oration: none; white-space: pre; wid |
| style="background: none 0% 0% / auto | th: 643px;">                         |
|  repeat scroll padding-box border-bo |                                      |
| x rgb(255, 255, 255); color: rgb(175 | `  `{style="border: 0px none rgb(37, |
| , 175, 175); display: block; font-st |  37, 37); color: rgb(37, 37, 37); di |
| yle: normal; font-variant: normal; f | splay: inline; font-style: normal; f |
| ont-weight: normal; font-stretch: no | ont-variant: normal; font-weight: no |
| rmal; font-size: 14px; font-family:  | rmal; font-stretch: normal; font-siz |
| Consolas, &quot;Bitstream Vera Sans  | e: 14px; font-family: Consolas, "Bit |
| Mono&quot;, &quot;Courier New&quot;, | stream Vera Sans Mono", "Courier New |
|  Courier, monospace; height: 15px; l | ", Courier, monospace; line-height:  |
| ine-height: 15.4px; margin: 0px; out | 15.4px; margin: 0px; outline: rgb(37 |
| line: rgb(175, 175, 175) none 0px; p | , 37, 37) none 0px; padding: 0px; te |
| adding: 0px 7px 0px 14px; text-align | xt-align: left; text-decoration: non |
| : right; text-decoration: none; whit | e; white-space: pre;"}`NSPredicate * |
| e-space: pre; width: 8px;">          | predicate = [NSPredicate predicateWi |
|                                      | thFormat:@`{style="display: inline;  |
| 4                                    | font-style: normal; font-variant: no |
|                                      | rmal; font-weight: normal; font-stre |
| </div>                               | tch: normal; font-size: 14px; font-f |
|                                      | amily: Consolas, "Bitstream Vera San |
| <div                                 | s Mono", "Courier New", Courier, mon |
| style="background: none 0% 0% / auto | ospace; line-height: 15.4px; margin: |
|  repeat scroll padding-box border-bo |  0px; padding: 0px; text-align: left |
| x rgb(255, 255, 255); color: rgb(175 | ; text-decoration: none; white-space |
| , 175, 175); display: block; font-st | : pre;"}`"SELF = 123"`{style="border |
| yle: normal; font-variant: normal; f | : 0px none rgb(0, 0, 255); color: rg |
| ont-weight: normal; font-stretch: no | b(0, 0, 255); display: inline; font- |
| rmal; font-size: 14px; font-family:  | style: normal; font-variant: normal; |
| Consolas, &quot;Bitstream Vera Sans  |  font-weight: normal; font-stretch:  |
| Mono&quot;, &quot;Courier New&quot;, | normal; font-size: 14px; font-family |
|  Courier, monospace; height: 15px; l | : Consolas, "Bitstream Vera Sans Mon |
| ine-height: 15.4px; margin: 0px; out | o", "Courier New", Courier, monospac |
| line: rgb(175, 175, 175) none 0px; p | e; line-height: 15.4px; margin: 0px; |
| adding: 0px 7px 0px 14px; text-align |  outline: rgb(0, 0, 255) none 0px; p |
| : right; text-decoration: none; whit | adding: 0px; text-align: left; text- |
| e-space: pre; width: 8px;">          | decoration: none; white-space: pre;" |
|                                      | }`];`{style="display: inline; font-s |
| 5                                    | tyle: normal; font-variant: normal;  |
|                                      | font-weight: normal; font-stretch: n |
| </div>                               | ormal; font-size: 14px; font-family: |
|                                      |  Consolas, "Bitstream Vera Sans Mono |
|                                      | ", "Courier New", Courier, monospace |
|                                      | ; line-height: 15.4px; margin: 0px;  |
|                                      | padding: 0px; text-align: left; text |
|                                      | -decoration: none; white-space: pre; |
|                                      | "}                                   |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 643px;">                         |
|                                      |                                      |
|                                      | `  `{style="border: 0px none rgb(37, |
|                                      |  37, 37); color: rgb(37, 37, 37); di |
|                                      | splay: inline; font-style: normal; f |
|                                      | ont-variant: normal; font-weight: no |
|                                      | rmal; font-stretch: normal; font-siz |
|                                      | e: 14px; font-family: Consolas, "Bit |
|                                      | stream Vera Sans Mono", "Courier New |
|                                      | ", Courier, monospace; line-height:  |
|                                      | 15.4px; margin: 0px; outline: rgb(37 |
|                                      | , 37, 37) none 0px; padding: 0px; te |
|                                      | xt-align: left; text-decoration: non |
|                                      | e; white-space: pre;"}`if`{style="bo |
|                                      | rder: 0px none rgb(0, 102, 153); col |
|                                      | or: rgb(0, 102, 153); display: inlin |
|                                      | e; font-style: normal; font-variant: |
|                                      |  normal; font-weight: bold; font-str |
|                                      | etch: normal; font-size: 14px; font- |
|                                      | family: Consolas, "Bitstream Vera Sa |
|                                      | ns Mono", "Courier New", Courier, mo |
|                                      | nospace; line-height: 15.4px; margin |
|                                      | : 0px; outline: rgb(0, 102, 153) non |
|                                      | e 0px; padding: 0px; text-align: lef |
|                                      | t; text-decoration: none; white-spac |
|                                      | e: pre;"} `([predicate evaluateWithO |
|                                      | bject:testNumber]) {`{style="display |
|                                      | : inline; font-style: normal; font-v |
|                                      | ariant: normal; font-weight: normal; |
|                                      |  font-stretch: normal; font-size: 14 |
|                                      | px; font-family: Consolas, "Bitstrea |
|                                      | m Vera Sans Mono", "Courier New", Co |
|                                      | urier, monospace; line-height: 15.4p |
|                                      | x; margin: 0px; padding: 0px; text-a |
|                                      | lign: left; text-decoration: none; w |
|                                      | hite-space: pre;"}                   |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 643px;">                         |
|                                      |                                      |
|                                      | `      `{style="border: 0px none rgb |
|                                      | (37, 37, 37); color: rgb(37, 37, 37) |
|                                      | ; display: inline; font-style: norma |
|                                      | l; font-variant: normal; font-weight |
|                                      | : normal; font-stretch: normal; font |
|                                      | -size: 14px; font-family: Consolas,  |
|                                      | "Bitstream Vera Sans Mono", "Courier |
|                                      |  New", Courier, monospace; line-heig |
|                                      | ht: 15.4px; margin: 0px; outline: rg |
|                                      | b(37, 37, 37) none 0px; padding: 0px |
|                                      | ; text-align: left; text-decoration: |
|                                      |  none; white-space: pre;"}`NSLog(@`{ |
|                                      | style="display: inline; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, "Bitstream Vera Sans Mono", "Co |
|                                      | urier New", Courier, monospace; line |
|                                      | -height: 15.4px; margin: 0px; paddin |
|                                      | g: 0px; text-align: left; text-decor |
|                                      | ation: none; white-space: pre;"}`"te |
|                                      | stString:%@"`{style="border: 0px non |
|                                      | e rgb(0, 0, 255); color: rgb(0, 0, 2 |
|                                      | 55); display: inline; font-style: no |
|                                      | rmal; font-variant: normal; font-wei |
|                                      | ght: normal; font-stretch: normal; f |
|                                      | ont-size: 14px; font-family: Consola |
|                                      | s, "Bitstream Vera Sans Mono", "Cour |
|                                      | ier New", Courier, monospace; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(0, 0, 255) none 0px; padding: 0 |
|                                      | px; text-align: left; text-decoratio |
|                                      | n: none; white-space: pre;"}`, testN |
|                                      | umber);`{style="display: inline; fon |
|                                      | t-style: normal; font-variant: norma |
|                                      | l; font-weight: normal; font-stretch |
|                                      | : normal; font-size: 14px; font-fami |
|                                      | ly: Consolas, "Bitstream Vera Sans M |
|                                      | ono", "Courier New", Courier, monosp |
|                                      | ace; line-height: 15.4px; margin: 0p |
|                                      | x; padding: 0px; text-align: left; t |
|                                      | ext-decoration: none; white-space: p |
|                                      | re;"}                                |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 643px;">                         |
|                                      |                                      |
|                                      | `  `{style="border: 0px none rgb(37, |
|                                      |  37, 37); color: rgb(37, 37, 37); di |
|                                      | splay: inline; font-style: normal; f |
|                                      | ont-variant: normal; font-weight: no |
|                                      | rmal; font-stretch: normal; font-siz |
|                                      | e: 14px; font-family: Consolas, "Bit |
|                                      | stream Vera Sans Mono", "Courier New |
|                                      | ", Courier, monospace; line-height:  |
|                                      | 15.4px; margin: 0px; outline: rgb(37 |
|                                      | , 37, 37) none 0px; padding: 0px; te |
|                                      | xt-align: left; text-decoration: non |
|                                      | e; white-space: pre;"}`}`{style="dis |
|                                      | play: inline; font-style: normal; fo |
|                                      | nt-variant: normal; font-weight: nor |
|                                      | mal; font-stretch: normal; font-size |
|                                      | : 14px; font-family: Consolas, "Bits |
|                                      | tream Vera Sans Mono", "Courier New" |
|                                      | , Courier, monospace; line-height: 1 |
|                                      | 5.4px; margin: 0px; padding: 0px; te |
|                                      | xt-align: left; text-decoration: non |
|                                      | e; white-space: pre;"}               |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+

</div>

</div>

我们可以看到输出的内容为:

<div
style="border: 0px none rgb(37, 37, 37); color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 15px; line-height: 28px; margin: 0px; outline: rgb(37, 37, 37) none 0px; padding: 0px; text-decoration: none; width: 720px;">

<div
style="background: none 0% 0% / auto repeat scroll padding-box border-box rgb(255, 255, 255); border: 0px none rgb(37, 37, 37); bottom: 0px; color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 15px; left: 0px; line-height: 28px; margin: 14px 0px; outline: rgb(37, 37, 37) none 0px; overflow: auto; padding: 0px; position: relative; right: 0px; text-decoration: none; top: 0px; width: 703px;">

+--------------------------------------+--------------------------------------+
| <div                                 | <div                                 |
| style="background: none 0% 0% / auto | style="border: 0px none rgb(37, 37,  |
|  repeat scroll padding-box border-bo | 37); bottom: 0px; color: rgb(37, 37, |
| x rgb(255, 255, 255); color: rgb(175 |  37); display: block; font-style: no |
| , 175, 175); display: block; font-st | rmal; font-variant: normal; font-wei |
| yle: normal; font-variant: normal; f | ght: normal; font-stretch: normal; f |
| ont-weight: normal; font-stretch: no | ont-size: 14px; font-family: Consola |
| rmal; font-size: 14px; font-family:  | s, &quot;Bitstream Vera Sans Mono&qu |
| Consolas, &quot;Bitstream Vera Sans  | ot;, &quot;Courier New&quot;, Courie |
| Mono&quot;, &quot;Courier New&quot;, | r, monospace; height: 15px; left: 0p |
|  Courier, monospace; height: 15px; l | x; line-height: 15.4px; margin: 0px; |
| ine-height: 15.4px; margin: 0px; out |  outline: rgb(37, 37, 37) none 0px;  |
| line: rgb(175, 175, 175) none 0px; p | padding: 0px; position: relative; ri |
| adding: 0px 7px 0px 14px; text-align | ght: 0px; text-align: left; text-dec |
| : right; text-decoration: none; whit | oration: none; top: 0px; width: 671p |
| e-space: pre; width: 8px;">          | x;">                                 |
|                                      |                                      |
| 1                                    | <div                                 |
|                                      | style="background: none 0% 0% / auto |
| </div>                               |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 643px;">                         |
|                                      |                                      |
|                                      | `2016-01-07 11:12:27.281 PredicteDem |
|                                      | o[4130:80412] testString:123`{style= |
|                                      | "display: inline; font-style: normal |
|                                      | ; font-variant: normal; font-weight: |
|                                      |  normal; font-stretch: normal; font- |
|                                      | size: 14px; font-family: Consolas, " |
|                                      | Bitstream Vera Sans Mono", "Courier  |
|                                      | New", Courier, monospace; line-heigh |
|                                      | t: 15.4px; margin: 0px; padding: 0px |
|                                      | ; text-align: left; text-decoration: |
|                                      |  none; white-space: pre;"}           |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+

</div>

</div>

-   &gt;=，=&gt;：判断左边表达式的值是否大于或等于右边表达式的值

-   &lt;=，=&lt;：判断右边表达式的值是否小于或等于右边表达式的值

-   &gt;：判断左边表达式的值是否大于右边表达式的值

-   &lt;：判断左边表达式的值是否小于右边表达式的值

-   !=、&lt;&gt;：判断两个表达式是否不相等

-   BETWEEN：BETWEEN表达式必须满足表达式 BETWEEN
    {下限，上限}的格式，要求该表达式必须大于或等于下限，并小于或等于上限

<div
style="border: 0px none rgb(37, 37, 37); color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 122px; line-height: 28px; margin: 0px; outline: rgb(37, 37, 37) none 0px; padding: 0px; text-decoration: none; width: 720px;">

<div
style="background: none 0% 0% / auto repeat scroll padding-box border-box rgb(255, 255, 255); border: 0px none rgb(37, 37, 37); bottom: 0px; color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 105px; left: 0px; line-height: 28px; margin: 14px 0px; outline: rgb(37, 37, 37) none 0px; overflow: auto; padding: 0px; position: relative; right: 0px; text-decoration: none; top: 0px; width: 703px;">

+--------------------------------------+--------------------------------------+
| <div                                 | <div                                 |
| style="background: none 0% 0% / auto | style="border: 0px none rgb(37, 37,  |
|  repeat scroll padding-box border-bo | 37); bottom: 0px; color: rgb(37, 37, |
| x rgb(255, 255, 255); color: rgb(175 |  37); display: block; font-style: no |
| , 175, 175); display: block; font-st | rmal; font-variant: normal; font-wei |
| yle: normal; font-variant: normal; f | ght: normal; font-stretch: normal; f |
| ont-weight: normal; font-stretch: no | ont-size: 14px; font-family: Consola |
| rmal; font-size: 14px; font-family:  | s, &quot;Bitstream Vera Sans Mono&qu |
| Consolas, &quot;Bitstream Vera Sans  | ot;, &quot;Courier New&quot;, Courie |
| Mono&quot;, &quot;Courier New&quot;, | r, monospace; height: 105px; left: 0 |
|  Courier, monospace; height: 15px; l | px; line-height: 15.4px; margin: 0px |
| ine-height: 15.4px; margin: 0px; out | ; outline: rgb(37, 37, 37) none 0px; |
| line: rgb(175, 175, 175) none 0px; p |  padding: 0px; position: relative; r |
| adding: 0px 7px 0px 14px; text-align | ight: 0px; text-align: left; text-de |
| : right; text-decoration: none; whit | coration: none; top: 0px; width: 690 |
| e-space: pre; width: 8px;">          | px;">                                |
|                                      |                                      |
| 1                                    | <div                                 |
|                                      | style="background: none 0% 0% / auto |
| </div>                               |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
| <div                                 | ne rgb(37, 37, 37); color: rgb(37, 3 |
| style="background: none 0% 0% / auto | 7, 37); display: block; font-style:  |
|  repeat scroll padding-box border-bo | normal; font-variant: normal; font-w |
| x rgb(255, 255, 255); color: rgb(175 | eight: normal; font-stretch: normal; |
| , 175, 175); display: block; font-st |  font-size: 14px; font-family: Conso |
| yle: normal; font-variant: normal; f | las, &quot;Bitstream Vera Sans Mono& |
| ont-weight: normal; font-stretch: no | quot;, &quot;Courier New&quot;, Cour |
| rmal; font-size: 14px; font-family:  | ier, monospace; height: 15px; line-h |
| Consolas, &quot;Bitstream Vera Sans  | eight: 15.4px; margin: 0px; outline: |
| Mono&quot;, &quot;Courier New&quot;, |  rgb(37, 37, 37) none 0px; padding:  |
|  Courier, monospace; height: 15px; l | 0px 14px; text-align: left; text-dec |
| ine-height: 15.4px; margin: 0px; out | oration: none; white-space: pre; wid |
| line: rgb(175, 175, 175) none 0px; p | th: 662px;">                         |
| adding: 0px 7px 0px 14px; text-align |                                      |
| : right; text-decoration: none; whit | `NSNumber *testNumber = @123;`{style |
| e-space: pre; width: 8px;">          | ="display: inline; font-style: norma |
|                                      | l; font-variant: normal; font-weight |
| 2                                    | : normal; font-stretch: normal; font |
|                                      | -size: 14px; font-family: Consolas,  |
| </div>                               | "Bitstream Vera Sans Mono", "Courier |
|                                      |  New", Courier, monospace; line-heig |
| <div                                 | ht: 15.4px; margin: 0px; padding: 0p |
| style="background: none 0% 0% / auto | x; text-align: left; text-decoration |
|  repeat scroll padding-box border-bo | : none; white-space: pre;"}          |
| x rgb(255, 255, 255); color: rgb(175 |                                      |
| , 175, 175); display: block; font-st | </div>                               |
| yle: normal; font-variant: normal; f |                                      |
| ont-weight: normal; font-stretch: no | <div                                 |
| rmal; font-size: 14px; font-family:  | style="background: none 0% 0% / auto |
| Consolas, &quot;Bitstream Vera Sans  |  repeat scroll padding-box border-bo |
| Mono&quot;, &quot;Courier New&quot;, | x rgb(255, 255, 255); border: 0px no |
|  Courier, monospace; height: 15px; l | ne rgb(37, 37, 37); color: rgb(37, 3 |
| ine-height: 15.4px; margin: 0px; out | 7, 37); display: block; font-style:  |
| line: rgb(175, 175, 175) none 0px; p | normal; font-variant: normal; font-w |
| adding: 0px 7px 0px 14px; text-align | eight: normal; font-stretch: normal; |
| : right; text-decoration: none; whit |  font-size: 14px; font-family: Conso |
| e-space: pre; width: 8px;">          | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
| 3                                    | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
| </div>                               |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
| <div                                 | oration: none; white-space: pre; wid |
| style="background: none 0% 0% / auto | th: 662px;">                         |
|  repeat scroll padding-box border-bo |                                      |
| x rgb(255, 255, 255); color: rgb(175 | `NSPredicate *predicate = [NSPredica |
| , 175, 175); display: block; font-st | te predicateWithFormat:@`{style="dis |
| yle: normal; font-variant: normal; f | play: inline; font-style: normal; fo |
| ont-weight: normal; font-stretch: no | nt-variant: normal; font-weight: nor |
| rmal; font-size: 14px; font-family:  | mal; font-stretch: normal; font-size |
| Consolas, &quot;Bitstream Vera Sans  | : 14px; font-family: Consolas, "Bits |
| Mono&quot;, &quot;Courier New&quot;, | tream Vera Sans Mono", "Courier New" |
|  Courier, monospace; height: 15px; l | , Courier, monospace; line-height: 1 |
| ine-height: 15.4px; margin: 0px; out | 5.4px; margin: 0px; padding: 0px; te |
| line: rgb(175, 175, 175) none 0px; p | xt-align: left; text-decoration: non |
| adding: 0px 7px 0px 14px; text-align | e; white-space: pre;"}`"SELF BETWEEN |
| : right; text-decoration: none; whit |  {100, 200}"`{style="border: 0px non |
| e-space: pre; width: 8px;">          | e rgb(0, 0, 255); color: rgb(0, 0, 2 |
|                                      | 55); display: inline; font-style: no |
| 4                                    | rmal; font-variant: normal; font-wei |
|                                      | ght: normal; font-stretch: normal; f |
| </div>                               | ont-size: 14px; font-family: Consola |
|                                      | s, "Bitstream Vera Sans Mono", "Cour |
| <div                                 | ier New", Courier, monospace; line-h |
| style="background: none 0% 0% / auto | eight: 15.4px; margin: 0px; outline: |
|  repeat scroll padding-box border-bo |  rgb(0, 0, 255) none 0px; padding: 0 |
| x rgb(255, 255, 255); color: rgb(175 | px; text-align: left; text-decoratio |
| , 175, 175); display: block; font-st | n: none; white-space: pre;"}`];`{sty |
| yle: normal; font-variant: normal; f | le="display: inline; font-style: nor |
| ont-weight: normal; font-stretch: no | mal; font-variant: normal; font-weig |
| rmal; font-size: 14px; font-family:  | ht: normal; font-stretch: normal; fo |
| Consolas, &quot;Bitstream Vera Sans  | nt-size: 14px; font-family: Consolas |
| Mono&quot;, &quot;Courier New&quot;, | , "Bitstream Vera Sans Mono", "Couri |
|  Courier, monospace; height: 15px; l | er New", Courier, monospace; line-he |
| ine-height: 15.4px; margin: 0px; out | ight: 15.4px; margin: 0px; padding:  |
| line: rgb(175, 175, 175) none 0px; p | 0px; text-align: left; text-decorati |
| adding: 0px 7px 0px 14px; text-align | on: none; white-space: pre;"}        |
| : right; text-decoration: none; whit |                                      |
| e-space: pre; width: 8px;">          | </div>                               |
|                                      |                                      |
| 5                                    | <div                                 |
|                                      | style="background: none 0% 0% / auto |
| </div>                               |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
| <div                                 | ne rgb(37, 37, 37); color: rgb(37, 3 |
| style="background: none 0% 0% / auto | 7, 37); display: block; font-style:  |
|  repeat scroll padding-box border-bo | normal; font-variant: normal; font-w |
| x rgb(255, 255, 255); color: rgb(175 | eight: normal; font-stretch: normal; |
| , 175, 175); display: block; font-st |  font-size: 14px; font-family: Conso |
| yle: normal; font-variant: normal; f | las, &quot;Bitstream Vera Sans Mono& |
| ont-weight: normal; font-stretch: no | quot;, &quot;Courier New&quot;, Cour |
| rmal; font-size: 14px; font-family:  | ier, monospace; height: 15px; line-h |
| Consolas, &quot;Bitstream Vera Sans  | eight: 15.4px; margin: 0px; outline: |
| Mono&quot;, &quot;Courier New&quot;, |  rgb(37, 37, 37) none 0px; padding:  |
|  Courier, monospace; height: 15px; l | 0px 14px; text-align: left; text-dec |
| ine-height: 15.4px; margin: 0px; out | oration: none; white-space: pre; wid |
| line: rgb(175, 175, 175) none 0px; p | th: 662px;">                         |
| adding: 0px 7px 0px 14px; text-align |                                      |
| : right; text-decoration: none; whit | `  `{style="border: 0px none rgb(37, |
| e-space: pre; width: 8px;">          |  37, 37); color: rgb(37, 37, 37); di |
|                                      | splay: inline; font-style: normal; f |
| 6                                    | ont-variant: normal; font-weight: no |
|                                      | rmal; font-stretch: normal; font-siz |
| </div>                               | e: 14px; font-family: Consolas, "Bit |
|                                      | stream Vera Sans Mono", "Courier New |
| <div                                 | ", Courier, monospace; line-height:  |
| style="background: none 0% 0% / auto | 15.4px; margin: 0px; outline: rgb(37 |
|  repeat scroll padding-box border-bo | , 37, 37) none 0px; padding: 0px; te |
| x rgb(255, 255, 255); color: rgb(175 | xt-align: left; text-decoration: non |
| , 175, 175); display: block; font-st | e; white-space: pre;"}`if`{style="bo |
| yle: normal; font-variant: normal; f | rder: 0px none rgb(0, 102, 153); col |
| ont-weight: normal; font-stretch: no | or: rgb(0, 102, 153); display: inlin |
| rmal; font-size: 14px; font-family:  | e; font-style: normal; font-variant: |
| Consolas, &quot;Bitstream Vera Sans  |  normal; font-weight: bold; font-str |
| Mono&quot;, &quot;Courier New&quot;, | etch: normal; font-size: 14px; font- |
|  Courier, monospace; height: 15px; l | family: Consolas, "Bitstream Vera Sa |
| ine-height: 15.4px; margin: 0px; out | ns Mono", "Courier New", Courier, mo |
| line: rgb(175, 175, 175) none 0px; p | nospace; line-height: 15.4px; margin |
| adding: 0px 7px 0px 14px; text-align | : 0px; outline: rgb(0, 102, 153) non |
| : right; text-decoration: none; whit | e 0px; padding: 0px; text-align: lef |
| e-space: pre; width: 8px;">          | t; text-decoration: none; white-spac |
|                                      | e: pre;"} `([predicate evaluateWithO |
| 7                                    | bject:testNumber]) {`{style="display |
|                                      | : inline; font-style: normal; font-v |
| </div>                               | ariant: normal; font-weight: normal; |
|                                      |  font-stretch: normal; font-size: 14 |
|                                      | px; font-family: Consolas, "Bitstrea |
|                                      | m Vera Sans Mono", "Courier New", Co |
|                                      | urier, monospace; line-height: 15.4p |
|                                      | x; margin: 0px; padding: 0px; text-a |
|                                      | lign: left; text-decoration: none; w |
|                                      | hite-space: pre;"}                   |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 662px;">                         |
|                                      |                                      |
|                                      | `      `{style="border: 0px none rgb |
|                                      | (37, 37, 37); color: rgb(37, 37, 37) |
|                                      | ; display: inline; font-style: norma |
|                                      | l; font-variant: normal; font-weight |
|                                      | : normal; font-stretch: normal; font |
|                                      | -size: 14px; font-family: Consolas,  |
|                                      | "Bitstream Vera Sans Mono", "Courier |
|                                      |  New", Courier, monospace; line-heig |
|                                      | ht: 15.4px; margin: 0px; outline: rg |
|                                      | b(37, 37, 37) none 0px; padding: 0px |
|                                      | ; text-align: left; text-decoration: |
|                                      |  none; white-space: pre;"}`NSLog(@`{ |
|                                      | style="display: inline; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, "Bitstream Vera Sans Mono", "Co |
|                                      | urier New", Courier, monospace; line |
|                                      | -height: 15.4px; margin: 0px; paddin |
|                                      | g: 0px; text-align: left; text-decor |
|                                      | ation: none; white-space: pre;"}`"te |
|                                      | stString:%@"`{style="border: 0px non |
|                                      | e rgb(0, 0, 255); color: rgb(0, 0, 2 |
|                                      | 55); display: inline; font-style: no |
|                                      | rmal; font-variant: normal; font-wei |
|                                      | ght: normal; font-stretch: normal; f |
|                                      | ont-size: 14px; font-family: Consola |
|                                      | s, "Bitstream Vera Sans Mono", "Cour |
|                                      | ier New", Courier, monospace; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(0, 0, 255) none 0px; padding: 0 |
|                                      | px; text-align: left; text-decoratio |
|                                      | n: none; white-space: pre;"}`, testN |
|                                      | umber);`{style="display: inline; fon |
|                                      | t-style: normal; font-variant: norma |
|                                      | l; font-weight: normal; font-stretch |
|                                      | : normal; font-size: 14px; font-fami |
|                                      | ly: Consolas, "Bitstream Vera Sans M |
|                                      | ono", "Courier New", Courier, monosp |
|                                      | ace; line-height: 15.4px; margin: 0p |
|                                      | x; padding: 0px; text-align: left; t |
|                                      | ext-decoration: none; white-space: p |
|                                      | re;"}                                |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 662px;">                         |
|                                      |                                      |
|                                      | `  `{style="border: 0px none rgb(37, |
|                                      |  37, 37); color: rgb(37, 37, 37); di |
|                                      | splay: inline; font-style: normal; f |
|                                      | ont-variant: normal; font-weight: no |
|                                      | rmal; font-stretch: normal; font-siz |
|                                      | e: 14px; font-family: Consolas, "Bit |
|                                      | stream Vera Sans Mono", "Courier New |
|                                      | ", Courier, monospace; line-height:  |
|                                      | 15.4px; margin: 0px; outline: rgb(37 |
|                                      | , 37, 37) none 0px; padding: 0px; te |
|                                      | xt-align: left; text-decoration: non |
|                                      | e; white-space: pre;"}`} `{style="di |
|                                      | splay: inline; font-style: normal; f |
|                                      | ont-variant: normal; font-weight: no |
|                                      | rmal; font-stretch: normal; font-siz |
|                                      | e: 14px; font-family: Consolas, "Bit |
|                                      | stream Vera Sans Mono", "Courier New |
|                                      | ", Courier, monospace; line-height:  |
|                                      | 15.4px; margin: 0px; padding: 0px; t |
|                                      | ext-align: left; text-decoration: no |
|                                      | ne; white-space: pre;"}`else`{style= |
|                                      | "border: 0px none rgb(0, 102, 153);  |
|                                      | color: rgb(0, 102, 153); display: in |
|                                      | line; font-style: normal; font-varia |
|                                      | nt: normal; font-weight: bold; font- |
|                                      | stretch: normal; font-size: 14px; fo |
|                                      | nt-family: Consolas, "Bitstream Vera |
|                                      |  Sans Mono", "Courier New", Courier, |
|                                      |  monospace; line-height: 15.4px; mar |
|                                      | gin: 0px; outline: rgb(0, 102, 153)  |
|                                      | none 0px; padding: 0px; text-align:  |
|                                      | left; text-decoration: none; white-s |
|                                      | pace: pre;"} `{`{style="display: inl |
|                                      | ine; font-style: normal; font-varian |
|                                      | t: normal; font-weight: normal; font |
|                                      | -stretch: normal; font-size: 14px; f |
|                                      | ont-family: Consolas, "Bitstream Ver |
|                                      | a Sans Mono", "Courier New", Courier |
|                                      | , monospace; line-height: 15.4px; ma |
|                                      | rgin: 0px; padding: 0px; text-align: |
|                                      |  left; text-decoration: none; white- |
|                                      | space: pre;"}                        |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 662px;">                         |
|                                      |                                      |
|                                      | `      `{style="border: 0px none rgb |
|                                      | (37, 37, 37); color: rgb(37, 37, 37) |
|                                      | ; display: inline; font-style: norma |
|                                      | l; font-variant: normal; font-weight |
|                                      | : normal; font-stretch: normal; font |
|                                      | -size: 14px; font-family: Consolas,  |
|                                      | "Bitstream Vera Sans Mono", "Courier |
|                                      |  New", Courier, monospace; line-heig |
|                                      | ht: 15.4px; margin: 0px; outline: rg |
|                                      | b(37, 37, 37) none 0px; padding: 0px |
|                                      | ; text-align: left; text-decoration: |
|                                      |  none; white-space: pre;"}`NSLog(@`{ |
|                                      | style="display: inline; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, "Bitstream Vera Sans Mono", "Co |
|                                      | urier New", Courier, monospace; line |
|                                      | -height: 15.4px; margin: 0px; paddin |
|                                      | g: 0px; text-align: left; text-decor |
|                                      | ation: none; white-space: pre;"}`"不符 |
|                                      | 合条件"`{style="border: 0px none rgb(0, |
|                                      |  0, 255); color: rgb(0, 0, 255); dis |
|                                      | play: inline; font-style: normal; fo |
|                                      | nt-variant: normal; font-weight: nor |
|                                      | mal; font-stretch: normal; font-size |
|                                      | : 14px; font-family: Consolas, "Bits |
|                                      | tream Vera Sans Mono", "Courier New" |
|                                      | , Courier, monospace; line-height: 1 |
|                                      | 5.4px; margin: 0px; outline: rgb(0,  |
|                                      | 0, 255) none 0px; padding: 0px; text |
|                                      | -align: left; text-decoration: none; |
|                                      |  white-space: pre;"}`);`{style="disp |
|                                      | lay: inline; font-style: normal; fon |
|                                      | t-variant: normal; font-weight: norm |
|                                      | al; font-stretch: normal; font-size: |
|                                      |  14px; font-family: Consolas, "Bitst |
|                                      | ream Vera Sans Mono", "Courier New", |
|                                      |  Courier, monospace; line-height: 15 |
|                                      | .4px; margin: 0px; padding: 0px; tex |
|                                      | t-align: left; text-decoration: none |
|                                      | ; white-space: pre;"}                |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 662px;">                         |
|                                      |                                      |
|                                      | `  `{style="border: 0px none rgb(37, |
|                                      |  37, 37); color: rgb(37, 37, 37); di |
|                                      | splay: inline; font-style: normal; f |
|                                      | ont-variant: normal; font-weight: no |
|                                      | rmal; font-stretch: normal; font-siz |
|                                      | e: 14px; font-family: Consolas, "Bit |
|                                      | stream Vera Sans Mono", "Courier New |
|                                      | ", Courier, monospace; line-height:  |
|                                      | 15.4px; margin: 0px; outline: rgb(37 |
|                                      | , 37, 37) none 0px; padding: 0px; te |
|                                      | xt-align: left; text-decoration: non |
|                                      | e; white-space: pre;"}`}`{style="dis |
|                                      | play: inline; font-style: normal; fo |
|                                      | nt-variant: normal; font-weight: nor |
|                                      | mal; font-stretch: normal; font-size |
|                                      | : 14px; font-family: Consolas, "Bits |
|                                      | tream Vera Sans Mono", "Courier New" |
|                                      | , Courier, monospace; line-height: 1 |
|                                      | 5.4px; margin: 0px; padding: 0px; te |
|                                      | xt-align: left; text-decoration: non |
|                                      | e; white-space: pre;"}               |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+

</div>

</div>

输出结果为：

<div
style="border: 0px none rgb(37, 37, 37); color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 15px; line-height: 28px; margin: 0px; outline: rgb(37, 37, 37) none 0px; padding: 0px; text-decoration: none; width: 720px;">

<div
style="background: none 0% 0% / auto repeat scroll padding-box border-box rgb(255, 255, 255); border: 0px none rgb(37, 37, 37); bottom: 0px; color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 15px; left: 0px; line-height: 28px; margin: 14px 0px; outline: rgb(37, 37, 37) none 0px; overflow: auto; padding: 0px; position: relative; right: 0px; text-decoration: none; top: 0px; width: 703px;">

+--------------------------------------+--------------------------------------+
| <div                                 | <div                                 |
| style="background: none 0% 0% / auto | style="border: 0px none rgb(37, 37,  |
|  repeat scroll padding-box border-bo | 37); bottom: 0px; color: rgb(37, 37, |
| x rgb(255, 255, 255); color: rgb(175 |  37); display: block; font-style: no |
| , 175, 175); display: block; font-st | rmal; font-variant: normal; font-wei |
| yle: normal; font-variant: normal; f | ght: normal; font-stretch: normal; f |
| ont-weight: normal; font-stretch: no | ont-size: 14px; font-family: Consola |
| rmal; font-size: 14px; font-family:  | s, &quot;Bitstream Vera Sans Mono&qu |
| Consolas, &quot;Bitstream Vera Sans  | ot;, &quot;Courier New&quot;, Courie |
| Mono&quot;, &quot;Courier New&quot;, | r, monospace; height: 15px; left: 0p |
|  Courier, monospace; height: 15px; l | x; line-height: 15.4px; margin: 0px; |
| ine-height: 15.4px; margin: 0px; out |  outline: rgb(37, 37, 37) none 0px;  |
| line: rgb(175, 175, 175) none 0px; p | padding: 0px; position: relative; ri |
| adding: 0px 7px 0px 14px; text-align | ght: 0px; text-align: left; text-dec |
| : right; text-decoration: none; whit | oration: none; top: 0px; width: 671p |
| e-space: pre; width: 8px;">          | x;">                                 |
|                                      |                                      |
| 1                                    | <div                                 |
|                                      | style="background: none 0% 0% / auto |
| </div>                               |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 643px;">                         |
|                                      |                                      |
|                                      | `2016-01-07 11:20:39.921 PredicteDem |
|                                      | o[4366:85408] testString:123`{style= |
|                                      | "display: inline; font-style: normal |
|                                      | ; font-variant: normal; font-weight: |
|                                      |  normal; font-stretch: normal; font- |
|                                      | size: 14px; font-family: Consolas, " |
|                                      | Bitstream Vera Sans Mono", "Courier  |
|                                      | New", Courier, monospace; line-heigh |
|                                      | t: 15.4px; margin: 0px; padding: 0px |
|                                      | ; text-align: left; text-decoration: |
|                                      |  none; white-space: pre;"}           |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+

</div>

</div>

<span
style="border: 0px none rgb(149, 55, 52); color: rgb(149, 55, 52); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; line-height: 28px; margin: 0px; outline: rgb(149, 55, 52) none 0px; padding: 0px; text-decoration: none;">2.逻辑运算符</span>

-   AND、&&：逻辑与，要求两个表达式的值都为YES时，结果才为YES。

<div
style="border: 0px none rgb(37, 37, 37); color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 60px; line-height: 28px; margin: 0px; outline: rgb(37, 37, 37) none 0px; padding: 0px; text-decoration: none; width: 720px;">

<div
style="background: none 0% 0% / auto repeat scroll padding-box border-box rgb(255, 255, 255); border: 0px none rgb(37, 37, 37); bottom: 0px; color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 60px; left: 0px; line-height: 28px; margin: 14px 0px; outline: rgb(37, 37, 37) none 0px; overflow: auto; padding: 0px; position: relative; right: 0px; text-decoration: none; top: 0px; width: 703px;">

+--------------------------------------+--------------------------------------+
| <div                                 | <div                                 |
| style="background: none 0% 0% / auto | style="border: 0px none rgb(37, 37,  |
|  repeat scroll padding-box border-bo | 37); bottom: 0px; color: rgb(37, 37, |
| x rgb(255, 255, 255); color: rgb(175 |  37); display: block; font-style: no |
| , 175, 175); display: block; font-st | rmal; font-variant: normal; font-wei |
| yle: normal; font-variant: normal; f | ght: normal; font-stretch: normal; f |
| ont-weight: normal; font-stretch: no | ont-size: 14px; font-family: Consola |
| rmal; font-size: 14px; font-family:  | s, &quot;Bitstream Vera Sans Mono&qu |
| Consolas, &quot;Bitstream Vera Sans  | ot;, &quot;Courier New&quot;, Courie |
| Mono&quot;, &quot;Courier New&quot;, | r, monospace; height: 60px; left: 0p |
|  Courier, monospace; height: 15px; l | x; line-height: 15.4px; margin: 0px; |
| ine-height: 15.4px; margin: 0px; out |  outline: rgb(37, 37, 37) none 0px;  |
| line: rgb(175, 175, 175) none 0px; p | padding: 0px; position: relative; ri |
| adding: 0px 7px 0px 14px; text-align | ght: 0px; text-align: left; text-dec |
| : right; text-decoration: none; whit | oration: none; top: 0px; width: 683p |
| e-space: pre; width: 8px;">          | x;">                                 |
|                                      |                                      |
| 1                                    | <div                                 |
|                                      | style="background: none 0% 0% / auto |
| </div>                               |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
| <div                                 | ne rgb(37, 37, 37); color: rgb(37, 3 |
| style="background: none 0% 0% / auto | 7, 37); display: block; font-style:  |
|  repeat scroll padding-box border-bo | normal; font-variant: normal; font-w |
| x rgb(255, 255, 255); color: rgb(175 | eight: normal; font-stretch: normal; |
| , 175, 175); display: block; font-st |  font-size: 14px; font-family: Conso |
| yle: normal; font-variant: normal; f | las, &quot;Bitstream Vera Sans Mono& |
| ont-weight: normal; font-stretch: no | quot;, &quot;Courier New&quot;, Cour |
| rmal; font-size: 14px; font-family:  | ier, monospace; height: 15px; line-h |
| Consolas, &quot;Bitstream Vera Sans  | eight: 15.4px; margin: 0px; outline: |
| Mono&quot;, &quot;Courier New&quot;, |  rgb(37, 37, 37) none 0px; padding:  |
|  Courier, monospace; height: 15px; l | 0px 14px; text-align: left; text-dec |
| ine-height: 15.4px; margin: 0px; out | oration: none; white-space: pre; wid |
| line: rgb(175, 175, 175) none 0px; p | th: 655px;">                         |
| adding: 0px 7px 0px 14px; text-align |                                      |
| : right; text-decoration: none; whit | `NSArray *testArray = @[@1, @2, @3,  |
| e-space: pre; width: 8px;">          | @4, @5, @6];`{style="display: inline |
|                                      | ; font-style: normal; font-variant:  |
| 2                                    | normal; font-weight: normal; font-st |
|                                      | retch: normal; font-size: 14px; font |
| </div>                               | -family: Consolas, "Bitstream Vera S |
|                                      | ans Mono", "Courier New", Courier, m |
| <div                                 | onospace; line-height: 15.4px; margi |
| style="background: none 0% 0% / auto | n: 0px; padding: 0px; text-align: le |
|  repeat scroll padding-box border-bo | ft; text-decoration: none; white-spa |
| x rgb(255, 255, 255); color: rgb(175 | ce: pre;"}                           |
| , 175, 175); display: block; font-st |                                      |
| yle: normal; font-variant: normal; f | </div>                               |
| ont-weight: normal; font-stretch: no |                                      |
| rmal; font-size: 14px; font-family:  | <div                                 |
| Consolas, &quot;Bitstream Vera Sans  | style="background: none 0% 0% / auto |
| Mono&quot;, &quot;Courier New&quot;, |  repeat scroll padding-box border-bo |
|  Courier, monospace; height: 15px; l | x rgb(255, 255, 255); border: 0px no |
| ine-height: 15.4px; margin: 0px; out | ne rgb(37, 37, 37); color: rgb(37, 3 |
| line: rgb(175, 175, 175) none 0px; p | 7, 37); display: block; font-style:  |
| adding: 0px 7px 0px 14px; text-align | normal; font-variant: normal; font-w |
| : right; text-decoration: none; whit | eight: normal; font-stretch: normal; |
| e-space: pre; width: 8px;">          |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
| 3                                    | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
| </div>                               | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
| <div                                 | 0px 14px; text-align: left; text-dec |
| style="background: none 0% 0% / auto | oration: none; white-space: pre; wid |
|  repeat scroll padding-box border-bo | th: 655px;">                         |
| x rgb(255, 255, 255); color: rgb(175 |                                      |
| , 175, 175); display: block; font-st | `  `{style="border: 0px none rgb(37, |
| yle: normal; font-variant: normal; f |  37, 37); color: rgb(37, 37, 37); di |
| ont-weight: normal; font-stretch: no | splay: inline; font-style: normal; f |
| rmal; font-size: 14px; font-family:  | ont-variant: normal; font-weight: no |
| Consolas, &quot;Bitstream Vera Sans  | rmal; font-stretch: normal; font-siz |
| Mono&quot;, &quot;Courier New&quot;, | e: 14px; font-family: Consolas, "Bit |
|  Courier, monospace; height: 15px; l | stream Vera Sans Mono", "Courier New |
| ine-height: 15.4px; margin: 0px; out | ", Courier, monospace; line-height:  |
| line: rgb(175, 175, 175) none 0px; p | 15.4px; margin: 0px; outline: rgb(37 |
| adding: 0px 7px 0px 14px; text-align | , 37, 37) none 0px; padding: 0px; te |
| : right; text-decoration: none; whit | xt-align: left; text-decoration: non |
| e-space: pre; width: 8px;">          | e; white-space: pre;"}`NSPredicate * |
|                                      | predicate = [NSPredicate predicateWi |
| 4                                    | thFormat:@`{style="display: inline;  |
|                                      | font-style: normal; font-variant: no |
| </div>                               | rmal; font-weight: normal; font-stre |
|                                      | tch: normal; font-size: 14px; font-f |
|                                      | amily: Consolas, "Bitstream Vera San |
|                                      | s Mono", "Courier New", Courier, mon |
|                                      | ospace; line-height: 15.4px; margin: |
|                                      |  0px; padding: 0px; text-align: left |
|                                      | ; text-decoration: none; white-space |
|                                      | : pre;"}`"SELF > 2 && SELF < 5"`{sty |
|                                      | le="border: 0px none rgb(0, 0, 255); |
|                                      |  color: rgb(0, 0, 255); display: inl |
|                                      | ine; font-style: normal; font-varian |
|                                      | t: normal; font-weight: normal; font |
|                                      | -stretch: normal; font-size: 14px; f |
|                                      | ont-family: Consolas, "Bitstream Ver |
|                                      | a Sans Mono", "Courier New", Courier |
|                                      | , monospace; line-height: 15.4px; ma |
|                                      | rgin: 0px; outline: rgb(0, 0, 255) n |
|                                      | one 0px; padding: 0px; text-align: l |
|                                      | eft; text-decoration: none; white-sp |
|                                      | ace: pre;"}`];`{style="display: inli |
|                                      | ne; font-style: normal; font-variant |
|                                      | : normal; font-weight: normal; font- |
|                                      | stretch: normal; font-size: 14px; fo |
|                                      | nt-family: Consolas, "Bitstream Vera |
|                                      |  Sans Mono", "Courier New", Courier, |
|                                      |  monospace; line-height: 15.4px; mar |
|                                      | gin: 0px; padding: 0px; text-align:  |
|                                      | left; text-decoration: none; white-s |
|                                      | pace: pre;"}                         |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 655px;">                         |
|                                      |                                      |
|                                      | `  `{style="border: 0px none rgb(37, |
|                                      |  37, 37); color: rgb(37, 37, 37); di |
|                                      | splay: inline; font-style: normal; f |
|                                      | ont-variant: normal; font-weight: no |
|                                      | rmal; font-stretch: normal; font-siz |
|                                      | e: 14px; font-family: Consolas, "Bit |
|                                      | stream Vera Sans Mono", "Courier New |
|                                      | ", Courier, monospace; line-height:  |
|                                      | 15.4px; margin: 0px; outline: rgb(37 |
|                                      | , 37, 37) none 0px; padding: 0px; te |
|                                      | xt-align: left; text-decoration: non |
|                                      | e; white-space: pre;"}`NSArray *filt |
|                                      | erArray = [testArray filteredArrayUs |
|                                      | ingPredicate:predicate];`{style="dis |
|                                      | play: inline; font-style: normal; fo |
|                                      | nt-variant: normal; font-weight: nor |
|                                      | mal; font-stretch: normal; font-size |
|                                      | : 14px; font-family: Consolas, "Bits |
|                                      | tream Vera Sans Mono", "Courier New" |
|                                      | , Courier, monospace; line-height: 1 |
|                                      | 5.4px; margin: 0px; padding: 0px; te |
|                                      | xt-align: left; text-decoration: non |
|                                      | e; white-space: pre;"}               |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 655px;">                         |
|                                      |                                      |
|                                      | `  `{style="border: 0px none rgb(37, |
|                                      |  37, 37); color: rgb(37, 37, 37); di |
|                                      | splay: inline; font-style: normal; f |
|                                      | ont-variant: normal; font-weight: no |
|                                      | rmal; font-stretch: normal; font-siz |
|                                      | e: 14px; font-family: Consolas, "Bit |
|                                      | stream Vera Sans Mono", "Courier New |
|                                      | ", Courier, monospace; line-height:  |
|                                      | 15.4px; margin: 0px; outline: rgb(37 |
|                                      | , 37, 37) none 0px; padding: 0px; te |
|                                      | xt-align: left; text-decoration: non |
|                                      | e; white-space: pre;"}`NSLog(@`{styl |
|                                      | e="display: inline; font-style: norm |
|                                      | al; font-variant: normal; font-weigh |
|                                      | t: normal; font-stretch: normal; fon |
|                                      | t-size: 14px; font-family: Consolas, |
|                                      |  "Bitstream Vera Sans Mono", "Courie |
|                                      | r New", Courier, monospace; line-hei |
|                                      | ght: 15.4px; margin: 0px; padding: 0 |
|                                      | px; text-align: left; text-decoratio |
|                                      | n: none; white-space: pre;"}`"filter |
|                                      | Array:%@"`{style="border: 0px none r |
|                                      | gb(0, 0, 255); color: rgb(0, 0, 255) |
|                                      | ; display: inline; font-style: norma |
|                                      | l; font-variant: normal; font-weight |
|                                      | : normal; font-stretch: normal; font |
|                                      | -size: 14px; font-family: Consolas,  |
|                                      | "Bitstream Vera Sans Mono", "Courier |
|                                      |  New", Courier, monospace; line-heig |
|                                      | ht: 15.4px; margin: 0px; outline: rg |
|                                      | b(0, 0, 255) none 0px; padding: 0px; |
|                                      |  text-align: left; text-decoration:  |
|                                      | none; white-space: pre;"}`, filterAr |
|                                      | ray);`{style="display: inline; font- |
|                                      | style: normal; font-variant: normal; |
|                                      |  font-weight: normal; font-stretch:  |
|                                      | normal; font-size: 14px; font-family |
|                                      | : Consolas, "Bitstream Vera Sans Mon |
|                                      | o", "Courier New", Courier, monospac |
|                                      | e; line-height: 15.4px; margin: 0px; |
|                                      |  padding: 0px; text-align: left; tex |
|                                      | t-decoration: none; white-space: pre |
|                                      | ;"}                                  |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+

</div>

</div>

输出结果为:

<div
style="border: 0px none rgb(37, 37, 37); color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 60px; line-height: 28px; margin: 0px; outline: rgb(37, 37, 37) none 0px; padding: 0px; text-decoration: none; width: 720px;">

<div
style="background: none 0% 0% / auto repeat scroll padding-box border-box rgb(255, 255, 255); border: 0px none rgb(37, 37, 37); bottom: 0px; color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 60px; left: 0px; line-height: 28px; margin: 14px 0px; outline: rgb(37, 37, 37) none 0px; overflow: auto; padding: 0px; position: relative; right: 0px; text-decoration: none; top: 0px; width: 703px;">

+--------------------------------------+--------------------------------------+
| <div                                 | <div                                 |
| style="background: none 0% 0% / auto | style="border: 0px none rgb(37, 37,  |
|  repeat scroll padding-box border-bo | 37); bottom: 0px; color: rgb(37, 37, |
| x rgb(255, 255, 255); color: rgb(175 |  37); display: block; font-style: no |
| , 175, 175); display: block; font-st | rmal; font-variant: normal; font-wei |
| yle: normal; font-variant: normal; f | ght: normal; font-stretch: normal; f |
| ont-weight: normal; font-stretch: no | ont-size: 14px; font-family: Consola |
| rmal; font-size: 14px; font-family:  | s, &quot;Bitstream Vera Sans Mono&qu |
| Consolas, &quot;Bitstream Vera Sans  | ot;, &quot;Courier New&quot;, Courie |
| Mono&quot;, &quot;Courier New&quot;, | r, monospace; height: 60px; left: 0p |
|  Courier, monospace; height: 15px; l | x; line-height: 15.4px; margin: 0px; |
| ine-height: 15.4px; margin: 0px; out |  outline: rgb(37, 37, 37) none 0px;  |
| line: rgb(175, 175, 175) none 0px; p | padding: 0px; position: relative; ri |
| adding: 0px 7px 0px 14px; text-align | ght: 0px; text-align: left; text-dec |
| : right; text-decoration: none; whit | oration: none; top: 0px; width: 671p |
| e-space: pre; width: 8px;">          | x;">                                 |
|                                      |                                      |
| 1                                    | <div                                 |
|                                      | style="background: none 0% 0% / auto |
| </div>                               |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
| <div                                 | ne rgb(37, 37, 37); color: rgb(37, 3 |
| style="background: none 0% 0% / auto | 7, 37); display: block; font-style:  |
|  repeat scroll padding-box border-bo | normal; font-variant: normal; font-w |
| x rgb(255, 255, 255); color: rgb(175 | eight: normal; font-stretch: normal; |
| , 175, 175); display: block; font-st |  font-size: 14px; font-family: Conso |
| yle: normal; font-variant: normal; f | las, &quot;Bitstream Vera Sans Mono& |
| ont-weight: normal; font-stretch: no | quot;, &quot;Courier New&quot;, Cour |
| rmal; font-size: 14px; font-family:  | ier, monospace; height: 15px; line-h |
| Consolas, &quot;Bitstream Vera Sans  | eight: 15.4px; margin: 0px; outline: |
| Mono&quot;, &quot;Courier New&quot;, |  rgb(37, 37, 37) none 0px; padding:  |
|  Courier, monospace; height: 15px; l | 0px 14px; text-align: left; text-dec |
| ine-height: 15.4px; margin: 0px; out | oration: none; white-space: pre; wid |
| line: rgb(175, 175, 175) none 0px; p | th: 643px;">                         |
| adding: 0px 7px 0px 14px; text-align |                                      |
| : right; text-decoration: none; whit | `2016-01-07 11:27:01.885 PredicteDem |
| e-space: pre; width: 8px;">          | o[4531:89537] filterArray:(`{style=" |
|                                      | display: inline; font-style: normal; |
| 2                                    |  font-variant: normal; font-weight:  |
|                                      | normal; font-stretch: normal; font-s |
| </div>                               | ize: 14px; font-family: Consolas, "B |
|                                      | itstream Vera Sans Mono", "Courier N |
| <div                                 | ew", Courier, monospace; line-height |
| style="background: none 0% 0% / auto | : 15.4px; margin: 0px; padding: 0px; |
|  repeat scroll padding-box border-bo |  text-align: left; text-decoration:  |
| x rgb(255, 255, 255); color: rgb(175 | none; white-space: pre;"}            |
| , 175, 175); display: block; font-st |                                      |
| yle: normal; font-variant: normal; f | </div>                               |
| ont-weight: normal; font-stretch: no |                                      |
| rmal; font-size: 14px; font-family:  | <div                                 |
| Consolas, &quot;Bitstream Vera Sans  | style="background: none 0% 0% / auto |
| Mono&quot;, &quot;Courier New&quot;, |  repeat scroll padding-box border-bo |
|  Courier, monospace; height: 15px; l | x rgb(255, 255, 255); border: 0px no |
| ine-height: 15.4px; margin: 0px; out | ne rgb(37, 37, 37); color: rgb(37, 3 |
| line: rgb(175, 175, 175) none 0px; p | 7, 37); display: block; font-style:  |
| adding: 0px 7px 0px 14px; text-align | normal; font-variant: normal; font-w |
| : right; text-decoration: none; whit | eight: normal; font-stretch: normal; |
| e-space: pre; width: 8px;">          |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
| 3                                    | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
| </div>                               | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
| <div                                 | 0px 14px; text-align: left; text-dec |
| style="background: none 0% 0% / auto | oration: none; white-space: pre; wid |
|  repeat scroll padding-box border-bo | th: 643px;">                         |
| x rgb(255, 255, 255); color: rgb(175 |                                      |
| , 175, 175); display: block; font-st | `  `{style="border: 0px none rgb(37, |
| yle: normal; font-variant: normal; f |  37, 37); color: rgb(37, 37, 37); di |
| ont-weight: normal; font-stretch: no | splay: inline; font-style: normal; f |
| rmal; font-size: 14px; font-family:  | ont-variant: normal; font-weight: no |
| Consolas, &quot;Bitstream Vera Sans  | rmal; font-stretch: normal; font-siz |
| Mono&quot;, &quot;Courier New&quot;, | e: 14px; font-family: Consolas, "Bit |
|  Courier, monospace; height: 15px; l | stream Vera Sans Mono", "Courier New |
| ine-height: 15.4px; margin: 0px; out | ", Courier, monospace; line-height:  |
| line: rgb(175, 175, 175) none 0px; p | 15.4px; margin: 0px; outline: rgb(37 |
| adding: 0px 7px 0px 14px; text-align | , 37, 37) none 0px; padding: 0px; te |
| : right; text-decoration: none; whit | xt-align: left; text-decoration: non |
| e-space: pre; width: 8px;">          | e; white-space: pre;"}`3,`{style="di |
|                                      | splay: inline; font-style: normal; f |
| 4                                    | ont-variant: normal; font-weight: no |
|                                      | rmal; font-stretch: normal; font-siz |
| </div>                               | e: 14px; font-family: Consolas, "Bit |
|                                      | stream Vera Sans Mono", "Courier New |
|                                      | ", Courier, monospace; line-height:  |
|                                      | 15.4px; margin: 0px; padding: 0px; t |
|                                      | ext-align: left; text-decoration: no |
|                                      | ne; white-space: pre;"}              |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 643px;">                         |
|                                      |                                      |
|                                      | `  `{style="border: 0px none rgb(37, |
|                                      |  37, 37); color: rgb(37, 37, 37); di |
|                                      | splay: inline; font-style: normal; f |
|                                      | ont-variant: normal; font-weight: no |
|                                      | rmal; font-stretch: normal; font-siz |
|                                      | e: 14px; font-family: Consolas, "Bit |
|                                      | stream Vera Sans Mono", "Courier New |
|                                      | ", Courier, monospace; line-height:  |
|                                      | 15.4px; margin: 0px; outline: rgb(37 |
|                                      | , 37, 37) none 0px; padding: 0px; te |
|                                      | xt-align: left; text-decoration: non |
|                                      | e; white-space: pre;"}`4`{style="dis |
|                                      | play: inline; font-style: normal; fo |
|                                      | nt-variant: normal; font-weight: nor |
|                                      | mal; font-stretch: normal; font-size |
|                                      | : 14px; font-family: Consolas, "Bits |
|                                      | tream Vera Sans Mono", "Courier New" |
|                                      | , Courier, monospace; line-height: 1 |
|                                      | 5.4px; margin: 0px; padding: 0px; te |
|                                      | xt-align: left; text-decoration: non |
|                                      | e; white-space: pre;"}               |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 643px;">                         |
|                                      |                                      |
|                                      | `)`{style="display: inline; font-sty |
|                                      | le: normal; font-variant: normal; fo |
|                                      | nt-weight: normal; font-stretch: nor |
|                                      | mal; font-size: 14px; font-family: C |
|                                      | onsolas, "Bitstream Vera Sans Mono", |
|                                      |  "Courier New", Courier, monospace;  |
|                                      | line-height: 15.4px; margin: 0px; pa |
|                                      | dding: 0px; text-align: left; text-d |
|                                      | ecoration: none; white-space: pre;"} |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+

</div>

</div>

-   OR、||：逻辑或，要求其中一个表达式为YES时，结果就是YES

-   NOT、 !：逻辑非，对原有的表达式取反

<span
style="border: 0px none rgb(149, 55, 52); color: rgb(149, 55, 52); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; line-height: 28px; margin: 0px; outline: rgb(149, 55, 52) none 0px; padding: 0px; text-decoration: none;">3.字符串比较运算符</span>

-   BEGINSWITH：检查某个字符串是否以指定的字符串开头（如判断字符串是否以a开头：BEGINSWITH
    'a'）

-   ENDSWITH：检查某个字符串是否以指定的字符串结尾

-   CONTAINS：检查某个字符串是否包含指定的字符串

-   LIKE：检查某个字符串是否匹配指定的字符串模板。其之后可以跟?代表一个字符和\*代表任意多个字符两个通配符。比如"name
    LIKE '\*ac\*'"，这表示name的值中包含ac则返回YES；"name LIKE
    '?ac\*'"，表示name的第2、3个字符为ac时返回YES。

-   MATCHES：检查某个字符串是否匹配指定的正则表达式。虽然正则表达式的执行效率是最低的，但其功能是最强大的，也是我们最常用的。

注：<span
style="border: 0px none rgb(127, 127, 127); color: rgb(127, 127, 127); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; line-height: 28px; margin: 0px; outline: rgb(127, 127, 127) none 0px; padding: 0px; text-decoration: none;">字符串比较都是区分大小写和重音符号的。如：café和cafe是不一样的，Cafe和cafe也是不一样的。如果希望字符串比较运算不区分大小写和重音符号，请在这些运算符后使用\[c\]，\[d\]选项。其中\[c\]是不区分大小写，\[d\]是不区分重音符号，其写在字符串比较运算符之后，比如：name
LIKE\[cd\]
'cafe'，那么不论name是cafe、Cafe还是café上面的表达式都会返回YES。</span>

<span
style="border: 0px none rgb(149, 55, 52); color: rgb(149, 55, 52); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; line-height: 28px; margin: 0px; outline: rgb(149, 55, 52) none 0px; padding: 0px; text-decoration: none;">4.集合运算符</span>

-   ANY、SOME：集合中任意一个元素满足条件，就返回YES。

-   ALL：集合中所有元素都满足条件，才返回YES。

-   NONE：集合中没有任何元素满足条件就返回YES。如:NONE person.age &lt;
    18，表示person集合中所有元素的age&gt;=18时，才返回YES。

-   IN：等价于SQL语句中的IN运算符，只有当左边表达式或值出现在右边的集合中才会返回YES。我们通过一个例子来看一下

<div
style="border: 0px none rgb(37, 37, 37); color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 77px; line-height: 28px; margin: 0px; outline: rgb(37, 37, 37) none 0px; padding: 0px; text-decoration: none; width: 720px;">

<div
style="background: none 0% 0% / auto repeat scroll padding-box border-box rgb(255, 255, 255); border: 0px none rgb(37, 37, 37); bottom: 0px; color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 60px; left: 0px; line-height: 28px; margin: 14px 0px; outline: rgb(37, 37, 37) none 0px; overflow: auto; padding: 0px; position: relative; right: 0px; text-decoration: none; top: 0px; width: 703px;">

+--------------------------------------+--------------------------------------+
| <div                                 | <div                                 |
| style="background: none 0% 0% / auto | style="border: 0px none rgb(37, 37,  |
|  repeat scroll padding-box border-bo | 37); bottom: 0px; color: rgb(37, 37, |
| x rgb(255, 255, 255); color: rgb(175 |  37); display: block; font-style: no |
| , 175, 175); display: block; font-st | rmal; font-variant: normal; font-wei |
| yle: normal; font-variant: normal; f | ght: normal; font-stretch: normal; f |
| ont-weight: normal; font-stretch: no | ont-size: 14px; font-family: Consola |
| rmal; font-size: 14px; font-family:  | s, &quot;Bitstream Vera Sans Mono&qu |
| Consolas, &quot;Bitstream Vera Sans  | ot;, &quot;Courier New&quot;, Courie |
| Mono&quot;, &quot;Courier New&quot;, | r, monospace; height: 60px; left: 0p |
|  Courier, monospace; height: 15px; l | x; line-height: 15.4px; margin: 0px; |
| ine-height: 15.4px; margin: 0px; out |  outline: rgb(37, 37, 37) none 0px;  |
| line: rgb(175, 175, 175) none 0px; p | padding: 0px; position: relative; ri |
| adding: 0px 7px 0px 14px; text-align | ght: 0px; text-align: left; text-dec |
| : right; text-decoration: none; whit | oration: none; top: 0px; width: 752p |
| e-space: pre; width: 8px;">          | x;">                                 |
|                                      |                                      |
| 1                                    | <div                                 |
|                                      | style="background: none 0% 0% / auto |
| </div>                               |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
| <div                                 | ne rgb(37, 37, 37); color: rgb(37, 3 |
| style="background: none 0% 0% / auto | 7, 37); display: block; font-style:  |
|  repeat scroll padding-box border-bo | normal; font-variant: normal; font-w |
| x rgb(255, 255, 255); color: rgb(175 | eight: normal; font-stretch: normal; |
| , 175, 175); display: block; font-st |  font-size: 14px; font-family: Conso |
| yle: normal; font-variant: normal; f | las, &quot;Bitstream Vera Sans Mono& |
| ont-weight: normal; font-stretch: no | quot;, &quot;Courier New&quot;, Cour |
| rmal; font-size: 14px; font-family:  | ier, monospace; height: 15px; line-h |
| Consolas, &quot;Bitstream Vera Sans  | eight: 15.4px; margin: 0px; outline: |
| Mono&quot;, &quot;Courier New&quot;, |  rgb(37, 37, 37) none 0px; padding:  |
|  Courier, monospace; height: 15px; l | 0px 14px; text-align: left; text-dec |
| ine-height: 15.4px; margin: 0px; out | oration: none; white-space: pre; wid |
| line: rgb(175, 175, 175) none 0px; p | th: 724px;">                         |
| adding: 0px 7px 0px 14px; text-align |                                      |
| : right; text-decoration: none; whit | `NSArray *filterArray = @[@`{style=" |
| e-space: pre; width: 8px;">          | display: inline; font-style: normal; |
|                                      |  font-variant: normal; font-weight:  |
| 2                                    | normal; font-stretch: normal; font-s |
|                                      | ize: 14px; font-family: Consolas, "B |
| </div>                               | itstream Vera Sans Mono", "Courier N |
|                                      | ew", Courier, monospace; line-height |
| <div                                 | : 15.4px; margin: 0px; padding: 0px; |
| style="background: none 0% 0% / auto |  text-align: left; text-decoration:  |
|  repeat scroll padding-box border-bo | none; white-space: pre;"}`"ab"`{styl |
| x rgb(255, 255, 255); color: rgb(175 | e="border: 0px none rgb(0, 0, 255);  |
| , 175, 175); display: block; font-st | color: rgb(0, 0, 255); display: inli |
| yle: normal; font-variant: normal; f | ne; font-style: normal; font-variant |
| ont-weight: normal; font-stretch: no | : normal; font-weight: normal; font- |
| rmal; font-size: 14px; font-family:  | stretch: normal; font-size: 14px; fo |
| Consolas, &quot;Bitstream Vera Sans  | nt-family: Consolas, "Bitstream Vera |
| Mono&quot;, &quot;Courier New&quot;, |  Sans Mono", "Courier New", Courier, |
|  Courier, monospace; height: 15px; l |  monospace; line-height: 15.4px; mar |
| ine-height: 15.4px; margin: 0px; out | gin: 0px; outline: rgb(0, 0, 255) no |
| line: rgb(175, 175, 175) none 0px; p | ne 0px; padding: 0px; text-align: le |
| adding: 0px 7px 0px 14px; text-align | ft; text-decoration: none; white-spa |
| : right; text-decoration: none; whit | ce: pre;"}`, @`{style="display: inli |
| e-space: pre; width: 8px;">          | ne; font-style: normal; font-variant |
|                                      | : normal; font-weight: normal; font- |
| 3                                    | stretch: normal; font-size: 14px; fo |
|                                      | nt-family: Consolas, "Bitstream Vera |
| </div>                               |  Sans Mono", "Courier New", Courier, |
|                                      |  monospace; line-height: 15.4px; mar |
| <div                                 | gin: 0px; padding: 0px; text-align:  |
| style="background: none 0% 0% / auto | left; text-decoration: none; white-s |
|  repeat scroll padding-box border-bo | pace: pre;"}`"abc"`{style="border: 0 |
| x rgb(255, 255, 255); color: rgb(175 | px none rgb(0, 0, 255); color: rgb(0 |
| , 175, 175); display: block; font-st | , 0, 255); display: inline; font-sty |
| yle: normal; font-variant: normal; f | le: normal; font-variant: normal; fo |
| ont-weight: normal; font-stretch: no | nt-weight: normal; font-stretch: nor |
| rmal; font-size: 14px; font-family:  | mal; font-size: 14px; font-family: C |
| Consolas, &quot;Bitstream Vera Sans  | onsolas, "Bitstream Vera Sans Mono", |
| Mono&quot;, &quot;Courier New&quot;, |  "Courier New", Courier, monospace;  |
|  Courier, monospace; height: 15px; l | line-height: 15.4px; margin: 0px; ou |
| ine-height: 15.4px; margin: 0px; out | tline: rgb(0, 0, 255) none 0px; padd |
| line: rgb(175, 175, 175) none 0px; p | ing: 0px; text-align: left; text-dec |
| adding: 0px 7px 0px 14px; text-align | oration: none; white-space: pre;"}`] |
| : right; text-decoration: none; whit | ;`{style="display: inline; font-styl |
| e-space: pre; width: 8px;">          | e: normal; font-variant: normal; fon |
|                                      | t-weight: normal; font-stretch: norm |
| 4                                    | al; font-size: 14px; font-family: Co |
|                                      | nsolas, "Bitstream Vera Sans Mono",  |
| </div>                               | "Courier New", Courier, monospace; l |
|                                      | ine-height: 15.4px; margin: 0px; pad |
|                                      | ding: 0px; text-align: left; text-de |
|                                      | coration: none; white-space: pre;"}  |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 724px;">                         |
|                                      |                                      |
|                                      | `  `{style="border: 0px none rgb(37, |
|                                      |  37, 37); color: rgb(37, 37, 37); di |
|                                      | splay: inline; font-style: normal; f |
|                                      | ont-variant: normal; font-weight: no |
|                                      | rmal; font-stretch: normal; font-siz |
|                                      | e: 14px; font-family: Consolas, "Bit |
|                                      | stream Vera Sans Mono", "Courier New |
|                                      | ", Courier, monospace; line-height:  |
|                                      | 15.4px; margin: 0px; outline: rgb(37 |
|                                      | , 37, 37) none 0px; padding: 0px; te |
|                                      | xt-align: left; text-decoration: non |
|                                      | e; white-space: pre;"}`NSArray *arra |
|                                      | y = @[@`{style="display: inline; fon |
|                                      | t-style: normal; font-variant: norma |
|                                      | l; font-weight: normal; font-stretch |
|                                      | : normal; font-size: 14px; font-fami |
|                                      | ly: Consolas, "Bitstream Vera Sans M |
|                                      | ono", "Courier New", Courier, monosp |
|                                      | ace; line-height: 15.4px; margin: 0p |
|                                      | x; padding: 0px; text-align: left; t |
|                                      | ext-decoration: none; white-space: p |
|                                      | re;"}`"a"`{style="border: 0px none r |
|                                      | gb(0, 0, 255); color: rgb(0, 0, 255) |
|                                      | ; display: inline; font-style: norma |
|                                      | l; font-variant: normal; font-weight |
|                                      | : normal; font-stretch: normal; font |
|                                      | -size: 14px; font-family: Consolas,  |
|                                      | "Bitstream Vera Sans Mono", "Courier |
|                                      |  New", Courier, monospace; line-heig |
|                                      | ht: 15.4px; margin: 0px; outline: rg |
|                                      | b(0, 0, 255) none 0px; padding: 0px; |
|                                      |  text-align: left; text-decoration:  |
|                                      | none; white-space: pre;"}`, @`{style |
|                                      | ="display: inline; font-style: norma |
|                                      | l; font-variant: normal; font-weight |
|                                      | : normal; font-stretch: normal; font |
|                                      | -size: 14px; font-family: Consolas,  |
|                                      | "Bitstream Vera Sans Mono", "Courier |
|                                      |  New", Courier, monospace; line-heig |
|                                      | ht: 15.4px; margin: 0px; padding: 0p |
|                                      | x; text-align: left; text-decoration |
|                                      | : none; white-space: pre;"}`"ab"`{st |
|                                      | yle="border: 0px none rgb(0, 0, 255) |
|                                      | ; color: rgb(0, 0, 255); display: in |
|                                      | line; font-style: normal; font-varia |
|                                      | nt: normal; font-weight: normal; fon |
|                                      | t-stretch: normal; font-size: 14px;  |
|                                      | font-family: Consolas, "Bitstream Ve |
|                                      | ra Sans Mono", "Courier New", Courie |
|                                      | r, monospace; line-height: 15.4px; m |
|                                      | argin: 0px; outline: rgb(0, 0, 255)  |
|                                      | none 0px; padding: 0px; text-align:  |
|                                      | left; text-decoration: none; white-s |
|                                      | pace: pre;"}`, @`{style="display: in |
|                                      | line; font-style: normal; font-varia |
|                                      | nt: normal; font-weight: normal; fon |
|                                      | t-stretch: normal; font-size: 14px;  |
|                                      | font-family: Consolas, "Bitstream Ve |
|                                      | ra Sans Mono", "Courier New", Courie |
|                                      | r, monospace; line-height: 15.4px; m |
|                                      | argin: 0px; padding: 0px; text-align |
|                                      | : left; text-decoration: none; white |
|                                      | -space: pre;"}`"abc"`{style="border: |
|                                      |  0px none rgb(0, 0, 255); color: rgb |
|                                      | (0, 0, 255); display: inline; font-s |
|                                      | tyle: normal; font-variant: normal;  |
|                                      | font-weight: normal; font-stretch: n |
|                                      | ormal; font-size: 14px; font-family: |
|                                      |  Consolas, "Bitstream Vera Sans Mono |
|                                      | ", "Courier New", Courier, monospace |
|                                      | ; line-height: 15.4px; margin: 0px;  |
|                                      | outline: rgb(0, 0, 255) none 0px; pa |
|                                      | dding: 0px; text-align: left; text-d |
|                                      | ecoration: none; white-space: pre;"} |
|                                      | `, @`{style="display: inline; font-s |
|                                      | tyle: normal; font-variant: normal;  |
|                                      | font-weight: normal; font-stretch: n |
|                                      | ormal; font-size: 14px; font-family: |
|                                      |  Consolas, "Bitstream Vera Sans Mono |
|                                      | ", "Courier New", Courier, monospace |
|                                      | ; line-height: 15.4px; margin: 0px;  |
|                                      | padding: 0px; text-align: left; text |
|                                      | -decoration: none; white-space: pre; |
|                                      | "}`"abcd"`{style="border: 0px none r |
|                                      | gb(0, 0, 255); color: rgb(0, 0, 255) |
|                                      | ; display: inline; font-style: norma |
|                                      | l; font-variant: normal; font-weight |
|                                      | : normal; font-stretch: normal; font |
|                                      | -size: 14px; font-family: Consolas,  |
|                                      | "Bitstream Vera Sans Mono", "Courier |
|                                      |  New", Courier, monospace; line-heig |
|                                      | ht: 15.4px; margin: 0px; outline: rg |
|                                      | b(0, 0, 255) none 0px; padding: 0px; |
|                                      |  text-align: left; text-decoration:  |
|                                      | none; white-space: pre;"}`];`{style= |
|                                      | "display: inline; font-style: normal |
|                                      | ; font-variant: normal; font-weight: |
|                                      |  normal; font-stretch: normal; font- |
|                                      | size: 14px; font-family: Consolas, " |
|                                      | Bitstream Vera Sans Mono", "Courier  |
|                                      | New", Courier, monospace; line-heigh |
|                                      | t: 15.4px; margin: 0px; padding: 0px |
|                                      | ; text-align: left; text-decoration: |
|                                      |  none; white-space: pre;"}           |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 724px;">                         |
|                                      |                                      |
|                                      | `  `{style="border: 0px none rgb(37, |
|                                      |  37, 37); color: rgb(37, 37, 37); di |
|                                      | splay: inline; font-style: normal; f |
|                                      | ont-variant: normal; font-weight: no |
|                                      | rmal; font-stretch: normal; font-siz |
|                                      | e: 14px; font-family: Consolas, "Bit |
|                                      | stream Vera Sans Mono", "Courier New |
|                                      | ", Courier, monospace; line-height:  |
|                                      | 15.4px; margin: 0px; outline: rgb(37 |
|                                      | , 37, 37) none 0px; padding: 0px; te |
|                                      | xt-align: left; text-decoration: non |
|                                      | e; white-space: pre;"}`NSPredicate * |
|                                      | predicate = [NSPredicate predicateWi |
|                                      | thFormat:@`{style="display: inline;  |
|                                      | font-style: normal; font-variant: no |
|                                      | rmal; font-weight: normal; font-stre |
|                                      | tch: normal; font-size: 14px; font-f |
|                                      | amily: Consolas, "Bitstream Vera San |
|                                      | s Mono", "Courier New", Courier, mon |
|                                      | ospace; line-height: 15.4px; margin: |
|                                      |  0px; padding: 0px; text-align: left |
|                                      | ; text-decoration: none; white-space |
|                                      | : pre;"}`"NOT (SELF IN %@)"`{style=" |
|                                      | border: 0px none rgb(0, 0, 255); col |
|                                      | or: rgb(0, 0, 255); display: inline; |
|                                      |  font-style: normal; font-variant: n |
|                                      | ormal; font-weight: normal; font-str |
|                                      | etch: normal; font-size: 14px; font- |
|                                      | family: Consolas, "Bitstream Vera Sa |
|                                      | ns Mono", "Courier New", Courier, mo |
|                                      | nospace; line-height: 15.4px; margin |
|                                      | : 0px; outline: rgb(0, 0, 255) none  |
|                                      | 0px; padding: 0px; text-align: left; |
|                                      |  text-decoration: none; white-space: |
|                                      |  pre;"}`, filterArray];`{style="disp |
|                                      | lay: inline; font-style: normal; fon |
|                                      | t-variant: normal; font-weight: norm |
|                                      | al; font-stretch: normal; font-size: |
|                                      |  14px; font-family: Consolas, "Bitst |
|                                      | ream Vera Sans Mono", "Courier New", |
|                                      |  Courier, monospace; line-height: 15 |
|                                      | .4px; margin: 0px; padding: 0px; tex |
|                                      | t-align: left; text-decoration: none |
|                                      | ; white-space: pre;"}                |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 724px;">                         |
|                                      |                                      |
|                                      | `  `{style="border: 0px none rgb(37, |
|                                      |  37, 37); color: rgb(37, 37, 37); di |
|                                      | splay: inline; font-style: normal; f |
|                                      | ont-variant: normal; font-weight: no |
|                                      | rmal; font-stretch: normal; font-siz |
|                                      | e: 14px; font-family: Consolas, "Bit |
|                                      | stream Vera Sans Mono", "Courier New |
|                                      | ", Courier, monospace; line-height:  |
|                                      | 15.4px; margin: 0px; outline: rgb(37 |
|                                      | , 37, 37) none 0px; padding: 0px; te |
|                                      | xt-align: left; text-decoration: non |
|                                      | e; white-space: pre;"}`NSLog(@`{styl |
|                                      | e="display: inline; font-style: norm |
|                                      | al; font-variant: normal; font-weigh |
|                                      | t: normal; font-stretch: normal; fon |
|                                      | t-size: 14px; font-family: Consolas, |
|                                      |  "Bitstream Vera Sans Mono", "Courie |
|                                      | r New", Courier, monospace; line-hei |
|                                      | ght: 15.4px; margin: 0px; padding: 0 |
|                                      | px; text-align: left; text-decoratio |
|                                      | n: none; white-space: pre;"}`"%@"`{s |
|                                      | tyle="border: 0px none rgb(0, 0, 255 |
|                                      | ); color: rgb(0, 0, 255); display: i |
|                                      | nline; font-style: normal; font-vari |
|                                      | ant: normal; font-weight: normal; fo |
|                                      | nt-stretch: normal; font-size: 14px; |
|                                      |  font-family: Consolas, "Bitstream V |
|                                      | era Sans Mono", "Courier New", Couri |
|                                      | er, monospace; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(0, 0, 255) |
|                                      |  none 0px; padding: 0px; text-align: |
|                                      |  left; text-decoration: none; white- |
|                                      | space: pre;"}`, [array filteredArray |
|                                      | UsingPredicate:predicate]);`{style=" |
|                                      | display: inline; font-style: normal; |
|                                      |  font-variant: normal; font-weight:  |
|                                      | normal; font-stretch: normal; font-s |
|                                      | ize: 14px; font-family: Consolas, "B |
|                                      | itstream Vera Sans Mono", "Courier N |
|                                      | ew", Courier, monospace; line-height |
|                                      | : 15.4px; margin: 0px; padding: 0px; |
|                                      |  text-align: left; text-decoration:  |
|                                      | none; white-space: pre;"}            |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+

</div>

</div>

代码的作用是将array中和filterArray中相同的元素去除，输出为：

<div
style="border: 0px none rgb(37, 37, 37); color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 60px; line-height: 28px; margin: 0px; outline: rgb(37, 37, 37) none 0px; padding: 0px; text-decoration: none; width: 720px;">

<div
style="background: none 0% 0% / auto repeat scroll padding-box border-box rgb(255, 255, 255); border: 0px none rgb(37, 37, 37); bottom: 0px; color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 60px; left: 0px; line-height: 28px; margin: 14px 0px; outline: rgb(37, 37, 37) none 0px; overflow: auto; padding: 0px; position: relative; right: 0px; text-decoration: none; top: 0px; width: 703px;">

+--------------------------------------+--------------------------------------+
| <div                                 | <div                                 |
| style="background: none 0% 0% / auto | style="border: 0px none rgb(37, 37,  |
|  repeat scroll padding-box border-bo | 37); bottom: 0px; color: rgb(37, 37, |
| x rgb(255, 255, 255); color: rgb(175 |  37); display: block; font-style: no |
| , 175, 175); display: block; font-st | rmal; font-variant: normal; font-wei |
| yle: normal; font-variant: normal; f | ght: normal; font-stretch: normal; f |
| ont-weight: normal; font-stretch: no | ont-size: 14px; font-family: Consola |
| rmal; font-size: 14px; font-family:  | s, &quot;Bitstream Vera Sans Mono&qu |
| Consolas, &quot;Bitstream Vera Sans  | ot;, &quot;Courier New&quot;, Courie |
| Mono&quot;, &quot;Courier New&quot;, | r, monospace; height: 60px; left: 0p |
|  Courier, monospace; height: 15px; l | x; line-height: 15.4px; margin: 0px; |
| ine-height: 15.4px; margin: 0px; out |  outline: rgb(37, 37, 37) none 0px;  |
| line: rgb(175, 175, 175) none 0px; p | padding: 0px; position: relative; ri |
| adding: 0px 7px 0px 14px; text-align | ght: 0px; text-align: left; text-dec |
| : right; text-decoration: none; whit | oration: none; top: 0px; width: 671p |
| e-space: pre; width: 8px;">          | x;">                                 |
|                                      |                                      |
| 1                                    | <div                                 |
|                                      | style="background: none 0% 0% / auto |
| </div>                               |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
| <div                                 | ne rgb(37, 37, 37); color: rgb(37, 3 |
| style="background: none 0% 0% / auto | 7, 37); display: block; font-style:  |
|  repeat scroll padding-box border-bo | normal; font-variant: normal; font-w |
| x rgb(255, 255, 255); color: rgb(175 | eight: normal; font-stretch: normal; |
| , 175, 175); display: block; font-st |  font-size: 14px; font-family: Conso |
| yle: normal; font-variant: normal; f | las, &quot;Bitstream Vera Sans Mono& |
| ont-weight: normal; font-stretch: no | quot;, &quot;Courier New&quot;, Cour |
| rmal; font-size: 14px; font-family:  | ier, monospace; height: 15px; line-h |
| Consolas, &quot;Bitstream Vera Sans  | eight: 15.4px; margin: 0px; outline: |
| Mono&quot;, &quot;Courier New&quot;, |  rgb(37, 37, 37) none 0px; padding:  |
|  Courier, monospace; height: 15px; l | 0px 14px; text-align: left; text-dec |
| ine-height: 15.4px; margin: 0px; out | oration: none; white-space: pre; wid |
| line: rgb(175, 175, 175) none 0px; p | th: 643px;">                         |
| adding: 0px 7px 0px 14px; text-align |                                      |
| : right; text-decoration: none; whit | `2016-01-07 13:17:43.669 PredicteDem |
| e-space: pre; width: 8px;">          | o[6701:136206] (`{style="display: in |
|                                      | line; font-style: normal; font-varia |
| 2                                    | nt: normal; font-weight: normal; fon |
|                                      | t-stretch: normal; font-size: 14px;  |
| </div>                               | font-family: Consolas, "Bitstream Ve |
|                                      | ra Sans Mono", "Courier New", Courie |
| <div                                 | r, monospace; line-height: 15.4px; m |
| style="background: none 0% 0% / auto | argin: 0px; padding: 0px; text-align |
|  repeat scroll padding-box border-bo | : left; text-decoration: none; white |
| x rgb(255, 255, 255); color: rgb(175 | -space: pre;"}                       |
| , 175, 175); display: block; font-st |                                      |
| yle: normal; font-variant: normal; f | </div>                               |
| ont-weight: normal; font-stretch: no |                                      |
| rmal; font-size: 14px; font-family:  | <div                                 |
| Consolas, &quot;Bitstream Vera Sans  | style="background: none 0% 0% / auto |
| Mono&quot;, &quot;Courier New&quot;, |  repeat scroll padding-box border-bo |
|  Courier, monospace; height: 15px; l | x rgb(255, 255, 255); border: 0px no |
| ine-height: 15.4px; margin: 0px; out | ne rgb(37, 37, 37); color: rgb(37, 3 |
| line: rgb(175, 175, 175) none 0px; p | 7, 37); display: block; font-style:  |
| adding: 0px 7px 0px 14px; text-align | normal; font-variant: normal; font-w |
| : right; text-decoration: none; whit | eight: normal; font-stretch: normal; |
| e-space: pre; width: 8px;">          |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
| 3                                    | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
| </div>                               | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
| <div                                 | 0px 14px; text-align: left; text-dec |
| style="background: none 0% 0% / auto | oration: none; white-space: pre; wid |
|  repeat scroll padding-box border-bo | th: 643px;">                         |
| x rgb(255, 255, 255); color: rgb(175 |                                      |
| , 175, 175); display: block; font-st | `  `{style="border: 0px none rgb(37, |
| yle: normal; font-variant: normal; f |  37, 37); color: rgb(37, 37, 37); di |
| ont-weight: normal; font-stretch: no | splay: inline; font-style: normal; f |
| rmal; font-size: 14px; font-family:  | ont-variant: normal; font-weight: no |
| Consolas, &quot;Bitstream Vera Sans  | rmal; font-stretch: normal; font-siz |
| Mono&quot;, &quot;Courier New&quot;, | e: 14px; font-family: Consolas, "Bit |
|  Courier, monospace; height: 15px; l | stream Vera Sans Mono", "Courier New |
| ine-height: 15.4px; margin: 0px; out | ", Courier, monospace; line-height:  |
| line: rgb(175, 175, 175) none 0px; p | 15.4px; margin: 0px; outline: rgb(37 |
| adding: 0px 7px 0px 14px; text-align | , 37, 37) none 0px; padding: 0px; te |
| : right; text-decoration: none; whit | xt-align: left; text-decoration: non |
| e-space: pre; width: 8px;">          | e; white-space: pre;"}`a,`{style="di |
|                                      | splay: inline; font-style: normal; f |
| 4                                    | ont-variant: normal; font-weight: no |
|                                      | rmal; font-stretch: normal; font-siz |
| </div>                               | e: 14px; font-family: Consolas, "Bit |
|                                      | stream Vera Sans Mono", "Courier New |
|                                      | ", Courier, monospace; line-height:  |
|                                      | 15.4px; margin: 0px; padding: 0px; t |
|                                      | ext-align: left; text-decoration: no |
|                                      | ne; white-space: pre;"}              |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 643px;">                         |
|                                      |                                      |
|                                      | `  `{style="border: 0px none rgb(37, |
|                                      |  37, 37); color: rgb(37, 37, 37); di |
|                                      | splay: inline; font-style: normal; f |
|                                      | ont-variant: normal; font-weight: no |
|                                      | rmal; font-stretch: normal; font-siz |
|                                      | e: 14px; font-family: Consolas, "Bit |
|                                      | stream Vera Sans Mono", "Courier New |
|                                      | ", Courier, monospace; line-height:  |
|                                      | 15.4px; margin: 0px; outline: rgb(37 |
|                                      | , 37, 37) none 0px; padding: 0px; te |
|                                      | xt-align: left; text-decoration: non |
|                                      | e; white-space: pre;"}`abcd`{style=" |
|                                      | display: inline; font-style: normal; |
|                                      |  font-variant: normal; font-weight:  |
|                                      | normal; font-stretch: normal; font-s |
|                                      | ize: 14px; font-family: Consolas, "B |
|                                      | itstream Vera Sans Mono", "Courier N |
|                                      | ew", Courier, monospace; line-height |
|                                      | : 15.4px; margin: 0px; padding: 0px; |
|                                      |  text-align: left; text-decoration:  |
|                                      | none; white-space: pre;"}            |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 643px;">                         |
|                                      |                                      |
|                                      | `)`{style="display: inline; font-sty |
|                                      | le: normal; font-variant: normal; fo |
|                                      | nt-weight: normal; font-stretch: nor |
|                                      | mal; font-size: 14px; font-family: C |
|                                      | onsolas, "Bitstream Vera Sans Mono", |
|                                      |  "Courier New", Courier, monospace;  |
|                                      | line-height: 15.4px; margin: 0px; pa |
|                                      | dding: 0px; text-align: left; text-d |
|                                      | ecoration: none; white-space: pre;"} |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+

</div>

</div>

-   array\[index\]：返回array数组中index索引处的元素

-   array\[FIRST\]：返回array数组中第一个元素

-   array\[LAST\]：返回array数组中最后一个元素

-   array\[SIZE\]：返回array数组中元素的个数

<span
style="border: 0px none rgb(149, 55, 52); color: rgb(149, 55, 52); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; line-height: 28px; margin: 0px; outline: rgb(149, 55, 52) none 0px; padding: 0px; text-decoration: none;">5.直接量</span>

在谓词表达式中可以使用如下直接量

-   FALSE、NO：代表逻辑假

-   TRUE、YES：代表逻辑真

-   NULL、NIL：代表空值

-   SELF：代表正在被判断的对象自身

-   "string"或'string'：代表字符串

-   数组：和c中的写法相同，如：{'one', 'two', 'three'}。

-   数值：包括证书、小数和科学计数法表示的形式

-   十六进制数：0x开头的数字

-   八进制：0o开头的数字

-   二进制：0b开头的数字

<span
style="border: 0px none rgb(149, 55, 52); color: rgb(149, 55, 52); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; line-height: 28px; margin: 0px; outline: rgb(149, 55, 52) none 0px; padding: 0px; text-decoration: none;">6.保留字</span>

下列单词都是保留字（不论大小写）

AND、OR、IN、NOT、ALL、ANY、SOME、NONE、LIKE、CASEINSENSITIVE、CI、MATCHES、CONTAINS、BEGINSWITH、ENDSWITH、BETWEEN、NULL、NIL、SELF、TRUE、YES、FALSE、NO、FIRST、LAST、SIZE、ANYKEY、SUBQUERY、CAST、TRUEPREDICATE、FALSEPREDICATE

<span
style="border: 0px none rgb(149, 55, 52); color: rgb(149, 55, 52); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; line-height: 28px; margin: 0px; outline: rgb(149, 55, 52) none 0px; padding: 0px; text-decoration: none;">注：虽然大小写都可以，但是更推荐使用大写来表示这些保留字</span>

**二、谓词的用法**

<span
style="border: 0px none rgb(149, 55, 52); color: rgb(149, 55, 52); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; line-height: 28px; margin: 0px; outline: rgb(149, 55, 52) none 0px; padding: 0px; text-decoration: none;">1.定义谓词</span>

一般我们使用下列方法来定义一个谓词

<div
style="border: 0px none rgb(37, 37, 37); color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 15px; line-height: 28px; margin: 0px; outline: rgb(37, 37, 37) none 0px; padding: 0px; text-decoration: none; width: 720px;">

<div
style="background: none 0% 0% / auto repeat scroll padding-box border-box rgb(255, 255, 255); border: 0px none rgb(37, 37, 37); bottom: 0px; color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 15px; left: 0px; line-height: 28px; margin: 14px 0px; outline: rgb(37, 37, 37) none 0px; overflow: auto; padding: 0px; position: relative; right: 0px; text-decoration: none; top: 0px; width: 703px;">

+--------------------------------------+--------------------------------------+
| <div                                 | <div                                 |
| style="background: none 0% 0% / auto | style="border: 0px none rgb(37, 37,  |
|  repeat scroll padding-box border-bo | 37); bottom: 0px; color: rgb(37, 37, |
| x rgb(255, 255, 255); color: rgb(175 |  37); display: block; font-style: no |
| , 175, 175); display: block; font-st | rmal; font-variant: normal; font-wei |
| yle: normal; font-variant: normal; f | ght: normal; font-stretch: normal; f |
| ont-weight: normal; font-stretch: no | ont-size: 14px; font-family: Consola |
| rmal; font-size: 14px; font-family:  | s, &quot;Bitstream Vera Sans Mono&qu |
| Consolas, &quot;Bitstream Vera Sans  | ot;, &quot;Courier New&quot;, Courie |
| Mono&quot;, &quot;Courier New&quot;, | r, monospace; height: 15px; left: 0p |
|  Courier, monospace; height: 15px; l | x; line-height: 15.4px; margin: 0px; |
| ine-height: 15.4px; margin: 0px; out |  outline: rgb(37, 37, 37) none 0px;  |
| line: rgb(175, 175, 175) none 0px; p | padding: 0px; position: relative; ri |
| adding: 0px 7px 0px 14px; text-align | ght: 0px; text-align: left; text-dec |
| : right; text-decoration: none; whit | oration: none; top: 0px; width: 671p |
| e-space: pre; width: 8px;">          | x;">                                 |
|                                      |                                      |
| 1                                    | <div                                 |
|                                      | style="background: none 0% 0% / auto |
| </div>                               |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 643px;">                         |
|                                      |                                      |
|                                      | `NSPredicate *predicate = [NSPredica |
|                                      | te predicateWithFormat:];`{style="di |
|                                      | splay: inline; font-style: normal; f |
|                                      | ont-variant: normal; font-weight: no |
|                                      | rmal; font-stretch: normal; font-siz |
|                                      | e: 14px; font-family: Consolas, "Bit |
|                                      | stream Vera Sans Mono", "Courier New |
|                                      | ", Courier, monospace; line-height:  |
|                                      | 15.4px; margin: 0px; padding: 0px; t |
|                                      | ext-align: left; text-decoration: no |
|                                      | ne; white-space: pre;"}              |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+

</div>

</div>

下面我们通过几个简单的例子来看看它该如何使用：

首先我们需要定义一个模型，因为示例中需要用到它

ZLPersonModel.h

<div
style="border: 0px none rgb(37, 37, 37); color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 257px; line-height: 28px; margin: 0px; outline: rgb(37, 37, 37) none 0px; padding: 0px; text-decoration: none; width: 720px;">

<div
style="background: none 0% 0% / auto repeat scroll padding-box border-box rgb(255, 255, 255); border: 0px none rgb(37, 37, 37); bottom: 0px; color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 240px; left: 0px; line-height: 28px; margin: 14px 0px; outline: rgb(37, 37, 37) none 0px; overflow: auto; padding: 0px; position: relative; right: 0px; text-decoration: none; top: 0px; width: 703px;">

+--------------------------------------+--------------------------------------+
| <div                                 | <div                                 |
| style="background: none 0% 0% / auto | style="border: 0px none rgb(37, 37,  |
|  repeat scroll padding-box border-bo | 37); bottom: 0px; color: rgb(37, 37, |
| x rgb(255, 255, 255); color: rgb(175 |  37); display: block; font-style: no |
| , 175, 175); display: block; font-st | rmal; font-variant: normal; font-wei |
| yle: normal; font-variant: normal; f | ght: normal; font-stretch: normal; f |
| ont-weight: normal; font-stretch: no | ont-size: 14px; font-family: Consola |
| rmal; font-size: 14px; font-family:  | s, &quot;Bitstream Vera Sans Mono&qu |
| Consolas, &quot;Bitstream Vera Sans  | ot;, &quot;Courier New&quot;, Courie |
| Mono&quot;, &quot;Courier New&quot;, | r, monospace; height: 240px; left: 0 |
|  Courier, monospace; height: 15px; l | px; line-height: 15.4px; margin: 0px |
| ine-height: 15.4px; margin: 0px; out | ; outline: rgb(37, 37, 37) none 0px; |
| line: rgb(175, 175, 175) none 0px; p |  padding: 0px; position: relative; r |
| adding: 0px 7px 0px 14px; text-align | ight: 0px; text-align: left; text-de |
| : right; text-decoration: none; whit | coration: none; top: 0px; width: 714 |
| e-space: pre; width: 16px;">         | px;">                                |
|                                      |                                      |
| 1                                    | <div                                 |
|                                      | style="background: none 0% 0% / auto |
| </div>                               |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
| <div                                 | ne rgb(37, 37, 37); color: rgb(37, 3 |
| style="background: none 0% 0% / auto | 7, 37); display: block; font-style:  |
|  repeat scroll padding-box border-bo | normal; font-variant: normal; font-w |
| x rgb(255, 255, 255); color: rgb(175 | eight: normal; font-stretch: normal; |
| , 175, 175); display: block; font-st |  font-size: 14px; font-family: Conso |
| yle: normal; font-variant: normal; f | las, &quot;Bitstream Vera Sans Mono& |
| ont-weight: normal; font-stretch: no | quot;, &quot;Courier New&quot;, Cour |
| rmal; font-size: 14px; font-family:  | ier, monospace; height: 15px; line-h |
| Consolas, &quot;Bitstream Vera Sans  | eight: 15.4px; margin: 0px; outline: |
| Mono&quot;, &quot;Courier New&quot;, |  rgb(37, 37, 37) none 0px; padding:  |
|  Courier, monospace; height: 15px; l | 0px 14px; text-align: left; text-dec |
| ine-height: 15.4px; margin: 0px; out | oration: none; white-space: pre; wid |
| line: rgb(175, 175, 175) none 0px; p | th: 686px;">                         |
| adding: 0px 7px 0px 14px; text-align |                                      |
| : right; text-decoration: none; whit | `#import typedef NS_ENUM(NSInteger,  |
| e-space: pre; width: 16px;">         | ZLPersonSex) {`{style="border: 0px n |
|                                      | one rgb(128, 128, 128); color: rgb(1 |
| 2                                    | 28, 128, 128); display: inline; font |
|                                      | -style: normal; font-variant: normal |
| </div>                               | ; font-weight: normal; font-stretch: |
|                                      |  normal; font-size: 14px; font-famil |
| <div                                 | y: Consolas, "Bitstream Vera Sans Mo |
| style="background: none 0% 0% / auto | no", "Courier New", Courier, monospa |
|  repeat scroll padding-box border-bo | ce; line-height: 15.4px; margin: 0px |
| x rgb(255, 255, 255); color: rgb(175 | ; outline: rgb(128, 128, 128) none 0 |
| , 175, 175); display: block; font-st | px; padding: 0px; text-align: left;  |
| yle: normal; font-variant: normal; f | text-decoration: none; white-space:  |
| ont-weight: normal; font-stretch: no | pre;"}                               |
| rmal; font-size: 14px; font-family:  |                                      |
| Consolas, &quot;Bitstream Vera Sans  | </div>                               |
| Mono&quot;, &quot;Courier New&quot;, |                                      |
|  Courier, monospace; height: 15px; l | <div                                 |
| ine-height: 15.4px; margin: 0px; out | style="background: none 0% 0% / auto |
| line: rgb(175, 175, 175) none 0px; p |  repeat scroll padding-box border-bo |
| adding: 0px 7px 0px 14px; text-align | x rgb(255, 255, 255); border: 0px no |
| : right; text-decoration: none; whit | ne rgb(37, 37, 37); color: rgb(37, 3 |
| e-space: pre; width: 16px;">         | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
| 3                                    | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
| </div>                               | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
| <div                                 | ier, monospace; height: 15px; line-h |
| style="background: none 0% 0% / auto | eight: 15.4px; margin: 0px; outline: |
|  repeat scroll padding-box border-bo |  rgb(37, 37, 37) none 0px; padding:  |
| x rgb(255, 255, 255); color: rgb(175 | 0px 14px; text-align: left; text-dec |
| , 175, 175); display: block; font-st | oration: none; white-space: pre; wid |
| yle: normal; font-variant: normal; f | th: 686px;">                         |
| ont-weight: normal; font-stretch: no |                                      |
| rmal; font-size: 14px; font-family:  | `    `{style="border: 0px none rgb(3 |
| Consolas, &quot;Bitstream Vera Sans  | 7, 37, 37); color: rgb(37, 37, 37);  |
| Mono&quot;, &quot;Courier New&quot;, | display: inline; font-style: normal; |
|  Courier, monospace; height: 15px; l |  font-variant: normal; font-weight:  |
| ine-height: 15.4px; margin: 0px; out | normal; font-stretch: normal; font-s |
| line: rgb(175, 175, 175) none 0px; p | ize: 14px; font-family: Consolas, "B |
| adding: 0px 7px 0px 14px; text-align | itstream Vera Sans Mono", "Courier N |
| : right; text-decoration: none; whit | ew", Courier, monospace; line-height |
| e-space: pre; width: 16px;">         | : 15.4px; margin: 0px; outline: rgb( |
|                                      | 37, 37, 37) none 0px; padding: 0px;  |
| 4                                    | text-align: left; text-decoration: n |
|                                      | one; white-space: pre;"}`ZLPersonSex |
| </div>                               | Male = 0,`{style="display: inline; f |
|                                      | ont-style: normal; font-variant: nor |
| <div                                 | mal; font-weight: normal; font-stret |
| style="background: none 0% 0% / auto | ch: normal; font-size: 14px; font-fa |
|  repeat scroll padding-box border-bo | mily: Consolas, "Bitstream Vera Sans |
| x rgb(255, 255, 255); color: rgb(175 |  Mono", "Courier New", Courier, mono |
| , 175, 175); display: block; font-st | space; line-height: 15.4px; margin:  |
| yle: normal; font-variant: normal; f | 0px; padding: 0px; text-align: left; |
| ont-weight: normal; font-stretch: no |  text-decoration: none; white-space: |
| rmal; font-size: 14px; font-family:  |  pre;"}                              |
| Consolas, &quot;Bitstream Vera Sans  |                                      |
| Mono&quot;, &quot;Courier New&quot;, | </div>                               |
|  Courier, monospace; height: 15px; l |                                      |
| ine-height: 15.4px; margin: 0px; out | <div                                 |
| line: rgb(175, 175, 175) none 0px; p | style="background: none 0% 0% / auto |
| adding: 0px 7px 0px 14px; text-align |  repeat scroll padding-box border-bo |
| : right; text-decoration: none; whit | x rgb(255, 255, 255); border: 0px no |
| e-space: pre; width: 16px;">         | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
| 5                                    | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
| </div>                               |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
| <div                                 | quot;, &quot;Courier New&quot;, Cour |
| style="background: none 0% 0% / auto | ier, monospace; height: 15px; line-h |
|  repeat scroll padding-box border-bo | eight: 15.4px; margin: 0px; outline: |
| x rgb(255, 255, 255); color: rgb(175 |  rgb(37, 37, 37) none 0px; padding:  |
| , 175, 175); display: block; font-st | 0px 14px; text-align: left; text-dec |
| yle: normal; font-variant: normal; f | oration: none; white-space: pre; wid |
| ont-weight: normal; font-stretch: no | th: 686px;">                         |
| rmal; font-size: 14px; font-family:  |                                      |
| Consolas, &quot;Bitstream Vera Sans  | `    `{style="border: 0px none rgb(3 |
| Mono&quot;, &quot;Courier New&quot;, | 7, 37, 37); color: rgb(37, 37, 37);  |
|  Courier, monospace; height: 15px; l | display: inline; font-style: normal; |
| ine-height: 15.4px; margin: 0px; out |  font-variant: normal; font-weight:  |
| line: rgb(175, 175, 175) none 0px; p | normal; font-stretch: normal; font-s |
| adding: 0px 7px 0px 14px; text-align | ize: 14px; font-family: Consolas, "B |
| : right; text-decoration: none; whit | itstream Vera Sans Mono", "Courier N |
| e-space: pre; width: 16px;">         | ew", Courier, monospace; line-height |
|                                      | : 15.4px; margin: 0px; outline: rgb( |
| 6                                    | 37, 37, 37) none 0px; padding: 0px;  |
|                                      | text-align: left; text-decoration: n |
| </div>                               | one; white-space: pre;"}`ZLPersonSex |
|                                      | Famale`{style="display: inline; font |
| <div                                 | -style: normal; font-variant: normal |
| style="background: none 0% 0% / auto | ; font-weight: normal; font-stretch: |
|  repeat scroll padding-box border-bo |  normal; font-size: 14px; font-famil |
| x rgb(255, 255, 255); color: rgb(175 | y: Consolas, "Bitstream Vera Sans Mo |
| , 175, 175); display: block; font-st | no", "Courier New", Courier, monospa |
| yle: normal; font-variant: normal; f | ce; line-height: 15.4px; margin: 0px |
| ont-weight: normal; font-stretch: no | ; padding: 0px; text-align: left; te |
| rmal; font-size: 14px; font-family:  | xt-decoration: none; white-space: pr |
| Consolas, &quot;Bitstream Vera Sans  | e;"}                                 |
| Mono&quot;, &quot;Courier New&quot;, |                                      |
|  Courier, monospace; height: 15px; l | </div>                               |
| ine-height: 15.4px; margin: 0px; out |                                      |
| line: rgb(175, 175, 175) none 0px; p | <div                                 |
| adding: 0px 7px 0px 14px; text-align | style="background: none 0% 0% / auto |
| : right; text-decoration: none; whit |  repeat scroll padding-box border-bo |
| e-space: pre; width: 16px;">         | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
| 7                                    | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
| </div>                               | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
| <div                                 | las, &quot;Bitstream Vera Sans Mono& |
| style="background: none 0% 0% / auto | quot;, &quot;Courier New&quot;, Cour |
|  repeat scroll padding-box border-bo | ier, monospace; height: 15px; line-h |
| x rgb(255, 255, 255); color: rgb(175 | eight: 15.4px; margin: 0px; outline: |
| , 175, 175); display: block; font-st |  rgb(37, 37, 37) none 0px; padding:  |
| yle: normal; font-variant: normal; f | 0px 14px; text-align: left; text-dec |
| ont-weight: normal; font-stretch: no | oration: none; white-space: pre; wid |
| rmal; font-size: 14px; font-family:  | th: 686px;">                         |
| Consolas, &quot;Bitstream Vera Sans  |                                      |
| Mono&quot;, &quot;Courier New&quot;, | `};`{style="display: inline; font-st |
|  Courier, monospace; height: 15px; l | yle: normal; font-variant: normal; f |
| ine-height: 15.4px; margin: 0px; out | ont-weight: normal; font-stretch: no |
| line: rgb(175, 175, 175) none 0px; p | rmal; font-size: 14px; font-family:  |
| adding: 0px 7px 0px 14px; text-align | Consolas, "Bitstream Vera Sans Mono" |
| : right; text-decoration: none; whit | , "Courier New", Courier, monospace; |
| e-space: pre; width: 16px;">         |  line-height: 15.4px; margin: 0px; p |
|                                      | adding: 0px; text-align: left; text- |
| 8                                    | decoration: none; white-space: pre;" |
|                                      | }                                    |
| </div>                               |                                      |
|                                      | </div>                               |
| <div                                 |                                      |
| style="background: none 0% 0% / auto | <div                                 |
|  repeat scroll padding-box border-bo | style="background: none 0% 0% / auto |
| x rgb(255, 255, 255); color: rgb(175 |  repeat scroll padding-box border-bo |
| , 175, 175); display: block; font-st | x rgb(255, 255, 255); border: 0px no |
| yle: normal; font-variant: normal; f | ne rgb(37, 37, 37); color: rgb(37, 3 |
| ont-weight: normal; font-stretch: no | 7, 37); display: block; font-style:  |
| rmal; font-size: 14px; font-family:  | normal; font-variant: normal; font-w |
| Consolas, &quot;Bitstream Vera Sans  | eight: normal; font-stretch: normal; |
| Mono&quot;, &quot;Courier New&quot;, |  font-size: 14px; font-family: Conso |
|  Courier, monospace; height: 15px; l | las, &quot;Bitstream Vera Sans Mono& |
| ine-height: 15.4px; margin: 0px; out | quot;, &quot;Courier New&quot;, Cour |
| line: rgb(175, 175, 175) none 0px; p | ier, monospace; height: 15px; line-h |
| adding: 0px 7px 0px 14px; text-align | eight: 15.4px; margin: 0px; outline: |
| : right; text-decoration: none; whit |  rgb(37, 37, 37) none 0px; padding:  |
| e-space: pre; width: 16px;">         | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
| 9                                    | th: 686px;">                         |
|                                      |                                      |
| </div>                               |                                      |
|                                      |                                      |
| <div                                 | </div>                               |
| style="background: none 0% 0% / auto |                                      |
|  repeat scroll padding-box border-bo | <div                                 |
| x rgb(255, 255, 255); color: rgb(175 | style="background: none 0% 0% / auto |
| , 175, 175); display: block; font-st |  repeat scroll padding-box border-bo |
| yle: normal; font-variant: normal; f | x rgb(255, 255, 255); border: 0px no |
| ont-weight: normal; font-stretch: no | ne rgb(37, 37, 37); color: rgb(37, 3 |
| rmal; font-size: 14px; font-family:  | 7, 37); display: block; font-style:  |
| Consolas, &quot;Bitstream Vera Sans  | normal; font-variant: normal; font-w |
| Mono&quot;, &quot;Courier New&quot;, | eight: normal; font-stretch: normal; |
|  Courier, monospace; height: 15px; l |  font-size: 14px; font-family: Conso |
| ine-height: 15.4px; margin: 0px; out | las, &quot;Bitstream Vera Sans Mono& |
| line: rgb(175, 175, 175) none 0px; p | quot;, &quot;Courier New&quot;, Cour |
| adding: 0px 7px 0px 14px; text-align | ier, monospace; height: 15px; line-h |
| : right; text-decoration: none; whit | eight: 15.4px; margin: 0px; outline: |
| e-space: pre; width: 16px;">         |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
| 10                                   | oration: none; white-space: pre; wid |
|                                      | th: 686px;">                         |
| </div>                               |                                      |
|                                      | `@interface ZLPersonModel : NSObject |
| <div                                 | `{style="display: inline; font-style |
| style="background: none 0% 0% / auto | : normal; font-variant: normal; font |
|  repeat scroll padding-box border-bo | -weight: normal; font-stretch: norma |
| x rgb(255, 255, 255); color: rgb(175 | l; font-size: 14px; font-family: Con |
| , 175, 175); display: block; font-st | solas, "Bitstream Vera Sans Mono", " |
| yle: normal; font-variant: normal; f | Courier New", Courier, monospace; li |
| ont-weight: normal; font-stretch: no | ne-height: 15.4px; margin: 0px; padd |
| rmal; font-size: 14px; font-family:  | ing: 0px; text-align: left; text-dec |
| Consolas, &quot;Bitstream Vera Sans  | oration: none; white-space: pre;"}   |
| Mono&quot;, &quot;Courier New&quot;, |                                      |
|  Courier, monospace; height: 15px; l | </div>                               |
| ine-height: 15.4px; margin: 0px; out |                                      |
| line: rgb(175, 175, 175) none 0px; p | <div                                 |
| adding: 0px 7px 0px 14px; text-align | style="background: none 0% 0% / auto |
| : right; text-decoration: none; whit |  repeat scroll padding-box border-bo |
| e-space: pre; width: 16px;">         | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
| 11                                   | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
| </div>                               | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
| <div                                 | las, &quot;Bitstream Vera Sans Mono& |
| style="background: none 0% 0% / auto | quot;, &quot;Courier New&quot;, Cour |
|  repeat scroll padding-box border-bo | ier, monospace; height: 15px; line-h |
| x rgb(255, 255, 255); color: rgb(175 | eight: 15.4px; margin: 0px; outline: |
| , 175, 175); display: block; font-st |  rgb(37, 37, 37) none 0px; padding:  |
| yle: normal; font-variant: normal; f | 0px 14px; text-align: left; text-dec |
| ont-weight: normal; font-stretch: no | oration: none; white-space: pre; wid |
| rmal; font-size: 14px; font-family:  | th: 686px;">                         |
| Consolas, &quot;Bitstream Vera Sans  |                                      |
| Mono&quot;, &quot;Courier New&quot;, | `/** NSString 姓名 */`{style="border:  |
|  Courier, monospace; height: 15px; l | 0px none rgb(0, 130, 0); color: rgb( |
| ine-height: 15.4px; margin: 0px; out | 0, 130, 0); display: inline; font-st |
| line: rgb(175, 175, 175) none 0px; p | yle: normal; font-variant: normal; f |
| adding: 0px 7px 0px 14px; text-align | ont-weight: normal; font-stretch: no |
| : right; text-decoration: none; whit | rmal; font-size: 14px; font-family:  |
| e-space: pre; width: 16px;">         | Consolas, "Bitstream Vera Sans Mono" |
|                                      | , "Courier New", Courier, monospace; |
| 12                                   |  line-height: 15.4px; margin: 0px; o |
|                                      | utline: rgb(0, 130, 0) none 0px; pad |
| </div>                               | ding: 0px; text-align: left; text-de |
|                                      | coration: none; white-space: pre;"}  |
| <div                                 |                                      |
| style="background: none 0% 0% / auto | </div>                               |
|  repeat scroll padding-box border-bo |                                      |
| x rgb(255, 255, 255); color: rgb(175 | <div                                 |
| , 175, 175); display: block; font-st | style="background: none 0% 0% / auto |
| yle: normal; font-variant: normal; f |  repeat scroll padding-box border-bo |
| ont-weight: normal; font-stretch: no | x rgb(255, 255, 255); border: 0px no |
| rmal; font-size: 14px; font-family:  | ne rgb(37, 37, 37); color: rgb(37, 3 |
| Consolas, &quot;Bitstream Vera Sans  | 7, 37); display: block; font-style:  |
| Mono&quot;, &quot;Courier New&quot;, | normal; font-variant: normal; font-w |
|  Courier, monospace; height: 15px; l | eight: normal; font-stretch: normal; |
| ine-height: 15.4px; margin: 0px; out |  font-size: 14px; font-family: Conso |
| line: rgb(175, 175, 175) none 0px; p | las, &quot;Bitstream Vera Sans Mono& |
| adding: 0px 7px 0px 14px; text-align | quot;, &quot;Courier New&quot;, Cour |
| : right; text-decoration: none; whit | ier, monospace; height: 15px; line-h |
| e-space: pre; width: 16px;">         | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
| 13                                   | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
| </div>                               | th: 686px;">                         |
|                                      |                                      |
| <div                                 | `@property (nonatomic, copy) NSStrin |
| style="background: none 0% 0% / auto | g *name;`{style="display: inline; fo |
|  repeat scroll padding-box border-bo | nt-style: normal; font-variant: norm |
| x rgb(255, 255, 255); color: rgb(175 | al; font-weight: normal; font-stretc |
| , 175, 175); display: block; font-st | h: normal; font-size: 14px; font-fam |
| yle: normal; font-variant: normal; f | ily: Consolas, "Bitstream Vera Sans  |
| ont-weight: normal; font-stretch: no | Mono", "Courier New", Courier, monos |
| rmal; font-size: 14px; font-family:  | pace; line-height: 15.4px; margin: 0 |
| Consolas, &quot;Bitstream Vera Sans  | px; padding: 0px; text-align: left;  |
| Mono&quot;, &quot;Courier New&quot;, | text-decoration: none; white-space:  |
|  Courier, monospace; height: 15px; l | pre;"}                               |
| ine-height: 15.4px; margin: 0px; out |                                      |
| line: rgb(175, 175, 175) none 0px; p | </div>                               |
| adding: 0px 7px 0px 14px; text-align |                                      |
| : right; text-decoration: none; whit | <div                                 |
| e-space: pre; width: 16px;">         | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
| 14                                   | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
| </div>                               | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
| <div                                 | eight: normal; font-stretch: normal; |
| style="background: none 0% 0% / auto |  font-size: 14px; font-family: Conso |
|  repeat scroll padding-box border-bo | las, &quot;Bitstream Vera Sans Mono& |
| x rgb(255, 255, 255); color: rgb(175 | quot;, &quot;Courier New&quot;, Cour |
| , 175, 175); display: block; font-st | ier, monospace; height: 15px; line-h |
| yle: normal; font-variant: normal; f | eight: 15.4px; margin: 0px; outline: |
| ont-weight: normal; font-stretch: no |  rgb(37, 37, 37) none 0px; padding:  |
| rmal; font-size: 14px; font-family:  | 0px 14px; text-align: left; text-dec |
| Consolas, &quot;Bitstream Vera Sans  | oration: none; white-space: pre; wid |
| Mono&quot;, &quot;Courier New&quot;, | th: 686px;">                         |
|  Courier, monospace; height: 15px; l |                                      |
| ine-height: 15.4px; margin: 0px; out | `/** NSUInteger 年龄 */`{style="border |
| line: rgb(175, 175, 175) none 0px; p | : 0px none rgb(0, 130, 0); color: rg |
| adding: 0px 7px 0px 14px; text-align | b(0, 130, 0); display: inline; font- |
| : right; text-decoration: none; whit | style: normal; font-variant: normal; |
| e-space: pre; width: 16px;">         |  font-weight: normal; font-stretch:  |
|                                      | normal; font-size: 14px; font-family |
| 15                                   | : Consolas, "Bitstream Vera Sans Mon |
|                                      | o", "Courier New", Courier, monospac |
| </div>                               | e; line-height: 15.4px; margin: 0px; |
|                                      |  outline: rgb(0, 130, 0) none 0px; p |
| <div                                 | adding: 0px; text-align: left; text- |
| style="background: none 0% 0% / auto | decoration: none; white-space: pre;" |
|  repeat scroll padding-box border-bo | }                                    |
| x rgb(255, 255, 255); color: rgb(175 |                                      |
| , 175, 175); display: block; font-st | </div>                               |
| yle: normal; font-variant: normal; f |                                      |
| ont-weight: normal; font-stretch: no | <div                                 |
| rmal; font-size: 14px; font-family:  | style="background: none 0% 0% / auto |
| Consolas, &quot;Bitstream Vera Sans  |  repeat scroll padding-box border-bo |
| Mono&quot;, &quot;Courier New&quot;, | x rgb(255, 255, 255); border: 0px no |
|  Courier, monospace; height: 15px; l | ne rgb(37, 37, 37); color: rgb(37, 3 |
| ine-height: 15.4px; margin: 0px; out | 7, 37); display: block; font-style:  |
| line: rgb(175, 175, 175) none 0px; p | normal; font-variant: normal; font-w |
| adding: 0px 7px 0px 14px; text-align | eight: normal; font-stretch: normal; |
| : right; text-decoration: none; whit |  font-size: 14px; font-family: Conso |
| e-space: pre; width: 16px;">         | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
| 16                                   | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
| </div>                               |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 686px;">                         |
|                                      |                                      |
|                                      | `@property (nonatomic, assign) NSUIn |
|                                      | teger age;`{style="display: inline;  |
|                                      | font-style: normal; font-variant: no |
|                                      | rmal; font-weight: normal; font-stre |
|                                      | tch: normal; font-size: 14px; font-f |
|                                      | amily: Consolas, "Bitstream Vera San |
|                                      | s Mono", "Courier New", Courier, mon |
|                                      | ospace; line-height: 15.4px; margin: |
|                                      |  0px; padding: 0px; text-align: left |
|                                      | ; text-decoration: none; white-space |
|                                      | : pre;"}                             |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 686px;">                         |
|                                      |                                      |
|                                      | `/** ZLPersonSex 性别 */`{style="borde |
|                                      | r: 0px none rgb(0, 130, 0); color: r |
|                                      | gb(0, 130, 0); display: inline; font |
|                                      | -style: normal; font-variant: normal |
|                                      | ; font-weight: normal; font-stretch: |
|                                      |  normal; font-size: 14px; font-famil |
|                                      | y: Consolas, "Bitstream Vera Sans Mo |
|                                      | no", "Courier New", Courier, monospa |
|                                      | ce; line-height: 15.4px; margin: 0px |
|                                      | ; outline: rgb(0, 130, 0) none 0px;  |
|                                      | padding: 0px; text-align: left; text |
|                                      | -decoration: none; white-space: pre; |
|                                      | "}                                   |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 686px;">                         |
|                                      |                                      |
|                                      | `@property (nonatomic, assign) ZLPer |
|                                      | sonSex sex;`{style="display: inline; |
|                                      |  font-style: normal; font-variant: n |
|                                      | ormal; font-weight: normal; font-str |
|                                      | etch: normal; font-size: 14px; font- |
|                                      | family: Consolas, "Bitstream Vera Sa |
|                                      | ns Mono", "Courier New", Courier, mo |
|                                      | nospace; line-height: 15.4px; margin |
|                                      | : 0px; padding: 0px; text-align: lef |
|                                      | t; text-decoration: none; white-spac |
|                                      | e: pre;"}                            |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 686px;">                         |
|                                      |                                      |
|                                      |                                      |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 686px;">                         |
|                                      |                                      |
|                                      | `+ (instancetype)personWithName:(NSS |
|                                      | tring *)name age:(NSUInteger)age sex |
|                                      | :(ZLPersonSex)sex;`{style="display:  |
|                                      | inline; font-style: normal; font-var |
|                                      | iant: normal; font-weight: normal; f |
|                                      | ont-stretch: normal; font-size: 14px |
|                                      | ; font-family: Consolas, "Bitstream  |
|                                      | Vera Sans Mono", "Courier New", Cour |
|                                      | ier, monospace; line-height: 15.4px; |
|                                      |  margin: 0px; padding: 0px; text-ali |
|                                      | gn: left; text-decoration: none; whi |
|                                      | te-space: pre;"}                     |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 686px;">                         |
|                                      |                                      |
|                                      |                                      |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 686px;">                         |
|                                      |                                      |
|                                      | `@end`{style="display: inline; font- |
|                                      | style: normal; font-variant: normal; |
|                                      |  font-weight: normal; font-stretch:  |
|                                      | normal; font-size: 14px; font-family |
|                                      | : Consolas, "Bitstream Vera Sans Mon |
|                                      | o", "Courier New", Courier, monospac |
|                                      | e; line-height: 15.4px; margin: 0px; |
|                                      |  padding: 0px; text-align: left; tex |
|                                      | t-decoration: none; white-space: pre |
|                                      | ;"}                                  |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+

</div>

</div>

下面让我们进入正题

例一:(最简单的使用)

<div
style="border: 0px none rgb(37, 37, 37); color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 182px; line-height: 28px; margin: 0px; outline: rgb(37, 37, 37) none 0px; padding: 0px; text-decoration: none; width: 720px;">

<div
style="background: none 0% 0% / auto repeat scroll padding-box border-box rgb(255, 255, 255); border: 0px none rgb(37, 37, 37); bottom: 0px; color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 165px; left: 0px; line-height: 28px; margin: 14px 0px; outline: rgb(37, 37, 37) none 0px; overflow: auto; padding: 0px; position: relative; right: 0px; text-decoration: none; top: 0px; width: 703px;">

+--------------------------------------+--------------------------------------+
| <div                                 | <div                                 |
| style="background: none 0% 0% / auto | style="border: 0px none rgb(37, 37,  |
|  repeat scroll padding-box border-bo | 37); bottom: 0px; color: rgb(37, 37, |
| x rgb(255, 255, 255); color: rgb(175 |  37); display: block; font-style: no |
| , 175, 175); display: block; font-st | rmal; font-variant: normal; font-wei |
| yle: normal; font-variant: normal; f | ght: normal; font-stretch: normal; f |
| ont-weight: normal; font-stretch: no | ont-size: 14px; font-family: Consola |
| rmal; font-size: 14px; font-family:  | s, &quot;Bitstream Vera Sans Mono&qu |
| Consolas, &quot;Bitstream Vera Sans  | ot;, &quot;Courier New&quot;, Courie |
| Mono&quot;, &quot;Courier New&quot;, | r, monospace; height: 165px; left: 0 |
|  Courier, monospace; height: 15px; l | px; line-height: 15.4px; margin: 0px |
| ine-height: 15.4px; margin: 0px; out | ; outline: rgb(37, 37, 37) none 0px; |
| line: rgb(175, 175, 175) none 0px; p |  padding: 0px; position: relative; r |
| adding: 0px 7px 0px 14px; text-align | ight: 0px; text-align: left; text-de |
| : right; text-decoration: none; whit | coration: none; top: 0px; width: 106 |
| e-space: pre; width: 16px;">         | 1px;">                               |
|                                      |                                      |
| 1                                    | <div                                 |
|                                      | style="background: none 0% 0% / auto |
| </div>                               |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
| <div                                 | ne rgb(37, 37, 37); color: rgb(37, 3 |
| style="background: none 0% 0% / auto | 7, 37); display: block; font-style:  |
|  repeat scroll padding-box border-bo | normal; font-variant: normal; font-w |
| x rgb(255, 255, 255); color: rgb(175 | eight: normal; font-stretch: normal; |
| , 175, 175); display: block; font-st |  font-size: 14px; font-family: Conso |
| yle: normal; font-variant: normal; f | las, &quot;Bitstream Vera Sans Mono& |
| ont-weight: normal; font-stretch: no | quot;, &quot;Courier New&quot;, Cour |
| rmal; font-size: 14px; font-family:  | ier, monospace; height: 15px; line-h |
| Consolas, &quot;Bitstream Vera Sans  | eight: 15.4px; margin: 0px; outline: |
| Mono&quot;, &quot;Courier New&quot;, |  rgb(37, 37, 37) none 0px; padding:  |
|  Courier, monospace; height: 15px; l | 0px 14px; text-align: left; text-dec |
| ine-height: 15.4px; margin: 0px; out | oration: none; white-space: pre; wid |
| line: rgb(175, 175, 175) none 0px; p | th: 1033px;">                        |
| adding: 0px 7px 0px 14px; text-align |                                      |
| : right; text-decoration: none; whit | `ZLPersonModel *sunnyzl = [ZLPersonM |
| e-space: pre; width: 16px;">         | odel personWithName:@`{style="displa |
|                                      | y: inline; font-style: normal; font- |
| 2                                    | variant: normal; font-weight: normal |
|                                      | ; font-stretch: normal; font-size: 1 |
| </div>                               | 4px; font-family: Consolas, "Bitstre |
|                                      | am Vera Sans Mono", "Courier New", C |
| <div                                 | ourier, monospace; line-height: 15.4 |
| style="background: none 0% 0% / auto | px; margin: 0px; padding: 0px; text- |
|  repeat scroll padding-box border-bo | align: left; text-decoration: none;  |
| x rgb(255, 255, 255); color: rgb(175 | white-space: pre;"}`"sunnyzl"`{style |
| , 175, 175); display: block; font-st | ="border: 0px none rgb(0, 0, 255); c |
| yle: normal; font-variant: normal; f | olor: rgb(0, 0, 255); display: inlin |
| ont-weight: normal; font-stretch: no | e; font-style: normal; font-variant: |
| rmal; font-size: 14px; font-family:  |  normal; font-weight: normal; font-s |
| Consolas, &quot;Bitstream Vera Sans  | tretch: normal; font-size: 14px; fon |
| Mono&quot;, &quot;Courier New&quot;, | t-family: Consolas, "Bitstream Vera  |
|  Courier, monospace; height: 15px; l | Sans Mono", "Courier New", Courier,  |
| ine-height: 15.4px; margin: 0px; out | monospace; line-height: 15.4px; marg |
| line: rgb(175, 175, 175) none 0px; p | in: 0px; outline: rgb(0, 0, 255) non |
| adding: 0px 7px 0px 14px; text-align | e 0px; padding: 0px; text-align: lef |
| : right; text-decoration: none; whit | t; text-decoration: none; white-spac |
| e-space: pre; width: 16px;">         | e: pre;"} `age:29 sex:ZLPersonSexMal |
|                                      | e];`{style="display: inline; font-st |
| 3                                    | yle: normal; font-variant: normal; f |
|                                      | ont-weight: normal; font-stretch: no |
| </div>                               | rmal; font-size: 14px; font-family:  |
|                                      | Consolas, "Bitstream Vera Sans Mono" |
| <div                                 | , "Courier New", Courier, monospace; |
| style="background: none 0% 0% / auto |  line-height: 15.4px; margin: 0px; p |
|  repeat scroll padding-box border-bo | adding: 0px; text-align: left; text- |
| x rgb(255, 255, 255); color: rgb(175 | decoration: none; white-space: pre;" |
| , 175, 175); display: block; font-st | }                                    |
| yle: normal; font-variant: normal; f |                                      |
| ont-weight: normal; font-stretch: no | </div>                               |
| rmal; font-size: 14px; font-family:  |                                      |
| Consolas, &quot;Bitstream Vera Sans  | <div                                 |
| Mono&quot;, &quot;Courier New&quot;, | style="background: none 0% 0% / auto |
|  Courier, monospace; height: 15px; l |  repeat scroll padding-box border-bo |
| ine-height: 15.4px; margin: 0px; out | x rgb(255, 255, 255); border: 0px no |
| line: rgb(175, 175, 175) none 0px; p | ne rgb(37, 37, 37); color: rgb(37, 3 |
| adding: 0px 7px 0px 14px; text-align | 7, 37); display: block; font-style:  |
| : right; text-decoration: none; whit | normal; font-variant: normal; font-w |
| e-space: pre; width: 16px;">         | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
| 4                                    | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
| </div>                               | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
| <div                                 |  rgb(37, 37, 37) none 0px; padding:  |
| style="background: none 0% 0% / auto | 0px 14px; text-align: left; text-dec |
|  repeat scroll padding-box border-bo | oration: none; white-space: pre; wid |
| x rgb(255, 255, 255); color: rgb(175 | th: 1033px;">                        |
| , 175, 175); display: block; font-st |                                      |
| yle: normal; font-variant: normal; f | `    `{style="border: 0px none rgb(3 |
| ont-weight: normal; font-stretch: no | 7, 37, 37); color: rgb(37, 37, 37);  |
| rmal; font-size: 14px; font-family:  | display: inline; font-style: normal; |
| Consolas, &quot;Bitstream Vera Sans  |  font-variant: normal; font-weight:  |
| Mono&quot;, &quot;Courier New&quot;, | normal; font-stretch: normal; font-s |
|  Courier, monospace; height: 15px; l | ize: 14px; font-family: Consolas, "B |
| ine-height: 15.4px; margin: 0px; out | itstream Vera Sans Mono", "Courier N |
| line: rgb(175, 175, 175) none 0px; p | ew", Courier, monospace; line-height |
| adding: 0px 7px 0px 14px; text-align | : 15.4px; margin: 0px; outline: rgb( |
| : right; text-decoration: none; whit | 37, 37, 37) none 0px; padding: 0px;  |
| e-space: pre; width: 16px;">         | text-align: left; text-decoration: n |
|                                      | one; white-space: pre;"}`ZLPersonMod |
| 5                                    | el *jack = [ZLPersonModel personWith |
|                                      | Name:@`{style="display: inline; font |
| </div>                               | -style: normal; font-variant: normal |
|                                      | ; font-weight: normal; font-stretch: |
| <div                                 |  normal; font-size: 14px; font-famil |
| style="background: none 0% 0% / auto | y: Consolas, "Bitstream Vera Sans Mo |
|  repeat scroll padding-box border-bo | no", "Courier New", Courier, monospa |
| x rgb(255, 255, 255); color: rgb(175 | ce; line-height: 15.4px; margin: 0px |
| , 175, 175); display: block; font-st | ; padding: 0px; text-align: left; te |
| yle: normal; font-variant: normal; f | xt-decoration: none; white-space: pr |
| ont-weight: normal; font-stretch: no | e;"}`"jack"`{style="border: 0px none |
| rmal; font-size: 14px; font-family:  |  rgb(0, 0, 255); color: rgb(0, 0, 25 |
| Consolas, &quot;Bitstream Vera Sans  | 5); display: inline; font-style: nor |
| Mono&quot;, &quot;Courier New&quot;, | mal; font-variant: normal; font-weig |
|  Courier, monospace; height: 15px; l | ht: normal; font-stretch: normal; fo |
| ine-height: 15.4px; margin: 0px; out | nt-size: 14px; font-family: Consolas |
| line: rgb(175, 175, 175) none 0px; p | , "Bitstream Vera Sans Mono", "Couri |
| adding: 0px 7px 0px 14px; text-align | er New", Courier, monospace; line-he |
| : right; text-decoration: none; whit | ight: 15.4px; margin: 0px; outline:  |
| e-space: pre; width: 16px;">         | rgb(0, 0, 255) none 0px; padding: 0p |
|                                      | x; text-align: left; text-decoration |
| 6                                    | : none; white-space: pre;"} `age:22  |
|                                      | sex:ZLPersonSexMale];`{style="displa |
| </div>                               | y: inline; font-style: normal; font- |
|                                      | variant: normal; font-weight: normal |
| <div                                 | ; font-stretch: normal; font-size: 1 |
| style="background: none 0% 0% / auto | 4px; font-family: Consolas, "Bitstre |
|  repeat scroll padding-box border-bo | am Vera Sans Mono", "Courier New", C |
| x rgb(255, 255, 255); color: rgb(175 | ourier, monospace; line-height: 15.4 |
| , 175, 175); display: block; font-st | px; margin: 0px; padding: 0px; text- |
| yle: normal; font-variant: normal; f | align: left; text-decoration: none;  |
| ont-weight: normal; font-stretch: no | white-space: pre;"}                  |
| rmal; font-size: 14px; font-family:  |                                      |
| Consolas, &quot;Bitstream Vera Sans  | </div>                               |
| Mono&quot;, &quot;Courier New&quot;, |                                      |
|  Courier, monospace; height: 15px; l | <div                                 |
| ine-height: 15.4px; margin: 0px; out | style="background: none 0% 0% / auto |
| line: rgb(175, 175, 175) none 0px; p |  repeat scroll padding-box border-bo |
| adding: 0px 7px 0px 14px; text-align | x rgb(255, 255, 255); border: 0px no |
| : right; text-decoration: none; whit | ne rgb(37, 37, 37); color: rgb(37, 3 |
| e-space: pre; width: 16px;">         | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
| 7                                    | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
| </div>                               | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
| <div                                 | ier, monospace; height: 15px; line-h |
| style="background: none 0% 0% / auto | eight: 15.4px; margin: 0px; outline: |
|  repeat scroll padding-box border-bo |  rgb(37, 37, 37) none 0px; padding:  |
| x rgb(255, 255, 255); color: rgb(175 | 0px 14px; text-align: left; text-dec |
| , 175, 175); display: block; font-st | oration: none; white-space: pre; wid |
| yle: normal; font-variant: normal; f | th: 1033px;">                        |
| ont-weight: normal; font-stretch: no |                                      |
| rmal; font-size: 14px; font-family:  | `    `{style="border: 0px none rgb(3 |
| Consolas, &quot;Bitstream Vera Sans  | 7, 37, 37); color: rgb(37, 37, 37);  |
| Mono&quot;, &quot;Courier New&quot;, | display: inline; font-style: normal; |
|  Courier, monospace; height: 15px; l |  font-variant: normal; font-weight:  |
| ine-height: 15.4px; margin: 0px; out | normal; font-stretch: normal; font-s |
| line: rgb(175, 175, 175) none 0px; p | ize: 14px; font-family: Consolas, "B |
| adding: 0px 7px 0px 14px; text-align | itstream Vera Sans Mono", "Courier N |
| : right; text-decoration: none; whit | ew", Courier, monospace; line-height |
| e-space: pre; width: 16px;">         | : 15.4px; margin: 0px; outline: rgb( |
|                                      | 37, 37, 37) none 0px; padding: 0px;  |
| 8                                    | text-align: left; text-decoration: n |
|                                      | one; white-space: pre;"}`//  首先我们来看一 |
| </div>                               | 些简单的使用`{style="border: 0px none rgb( |
|                                      | 0, 130, 0); color: rgb(0, 130, 0); d |
| <div                                 | isplay: inline; font-style: normal;  |
| style="background: none 0% 0% / auto | font-variant: normal; font-weight: n |
|  repeat scroll padding-box border-bo | ormal; font-stretch: normal; font-si |
| x rgb(255, 255, 255); color: rgb(175 | ze: 14px; font-family: Consolas, "Bi |
| , 175, 175); display: block; font-st | tstream Vera Sans Mono", "Courier Ne |
| yle: normal; font-variant: normal; f | w", Courier, monospace; line-height: |
| ont-weight: normal; font-stretch: no |  15.4px; margin: 0px; outline: rgb(0 |
| rmal; font-size: 14px; font-family:  | , 130, 0) none 0px; padding: 0px; te |
| Consolas, &quot;Bitstream Vera Sans  | xt-align: left; text-decoration: non |
| Mono&quot;, &quot;Courier New&quot;, | e; white-space: pre;"}               |
|  Courier, monospace; height: 15px; l |                                      |
| ine-height: 15.4px; margin: 0px; out | </div>                               |
| line: rgb(175, 175, 175) none 0px; p |                                      |
| adding: 0px 7px 0px 14px; text-align | <div                                 |
| : right; text-decoration: none; whit | style="background: none 0% 0% / auto |
| e-space: pre; width: 16px;">         |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
| 9                                    | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
| </div>                               | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
| <div                                 |  font-size: 14px; font-family: Conso |
| style="background: none 0% 0% / auto | las, &quot;Bitstream Vera Sans Mono& |
|  repeat scroll padding-box border-bo | quot;, &quot;Courier New&quot;, Cour |
| x rgb(255, 255, 255); color: rgb(175 | ier, monospace; height: 15px; line-h |
| , 175, 175); display: block; font-st | eight: 15.4px; margin: 0px; outline: |
| yle: normal; font-variant: normal; f |  rgb(37, 37, 37) none 0px; padding:  |
| ont-weight: normal; font-stretch: no | 0px 14px; text-align: left; text-dec |
| rmal; font-size: 14px; font-family:  | oration: none; white-space: pre; wid |
| Consolas, &quot;Bitstream Vera Sans  | th: 1033px;">                        |
| Mono&quot;, &quot;Courier New&quot;, |                                      |
|  Courier, monospace; height: 15px; l | `    `{style="border: 0px none rgb(3 |
| ine-height: 15.4px; margin: 0px; out | 7, 37, 37); color: rgb(37, 37, 37);  |
| line: rgb(175, 175, 175) none 0px; p | display: inline; font-style: normal; |
| adding: 0px 7px 0px 14px; text-align |  font-variant: normal; font-weight:  |
| : right; text-decoration: none; whit | normal; font-stretch: normal; font-s |
| e-space: pre; width: 16px;">         | ize: 14px; font-family: Consolas, "B |
|                                      | itstream Vera Sans Mono", "Courier N |
| 10                                   | ew", Courier, monospace; line-height |
|                                      | : 15.4px; margin: 0px; outline: rgb( |
| </div>                               | 37, 37, 37) none 0px; padding: 0px;  |
|                                      | text-align: left; text-decoration: n |
| <div                                 | one; white-space: pre;"}`//  1.判断姓名是 |
| style="background: none 0% 0% / auto | 否是以s开头的`{style="border: 0px none rgb |
|  repeat scroll padding-box border-bo | (0, 130, 0); color: rgb(0, 130, 0);  |
| x rgb(255, 255, 255); color: rgb(175 | display: inline; font-style: normal; |
| , 175, 175); display: block; font-st |  font-variant: normal; font-weight:  |
| yle: normal; font-variant: normal; f | normal; font-stretch: normal; font-s |
| ont-weight: normal; font-stretch: no | ize: 14px; font-family: Consolas, "B |
| rmal; font-size: 14px; font-family:  | itstream Vera Sans Mono", "Courier N |
| Consolas, &quot;Bitstream Vera Sans  | ew", Courier, monospace; line-height |
| Mono&quot;, &quot;Courier New&quot;, | : 15.4px; margin: 0px; outline: rgb( |
|  Courier, monospace; height: 15px; l | 0, 130, 0) none 0px; padding: 0px; t |
| ine-height: 15.4px; margin: 0px; out | ext-align: left; text-decoration: no |
| line: rgb(175, 175, 175) none 0px; p | ne; white-space: pre;"}              |
| adding: 0px 7px 0px 14px; text-align |                                      |
| : right; text-decoration: none; whit | </div>                               |
| e-space: pre; width: 16px;">         |                                      |
|                                      | <div                                 |
| 11                                   | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
| </div>                               | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 1033px;">                        |
|                                      |                                      |
|                                      | `    `{style="border: 0px none rgb(3 |
|                                      | 7, 37, 37); color: rgb(37, 37, 37);  |
|                                      | display: inline; font-style: normal; |
|                                      |  font-variant: normal; font-weight:  |
|                                      | normal; font-stretch: normal; font-s |
|                                      | ize: 14px; font-family: Consolas, "B |
|                                      | itstream Vera Sans Mono", "Courier N |
|                                      | ew", Courier, monospace; line-height |
|                                      | : 15.4px; margin: 0px; outline: rgb( |
|                                      | 37, 37, 37) none 0px; padding: 0px;  |
|                                      | text-align: left; text-decoration: n |
|                                      | one; white-space: pre;"}`NSPredicate |
|                                      |  *pred1 = [NSPredicate predicateWith |
|                                      | Format:@`{style="display: inline; fo |
|                                      | nt-style: normal; font-variant: norm |
|                                      | al; font-weight: normal; font-stretc |
|                                      | h: normal; font-size: 14px; font-fam |
|                                      | ily: Consolas, "Bitstream Vera Sans  |
|                                      | Mono", "Courier New", Courier, monos |
|                                      | pace; line-height: 15.4px; margin: 0 |
|                                      | px; padding: 0px; text-align: left;  |
|                                      | text-decoration: none; white-space:  |
|                                      | pre;"}`"name LIKE 's*'"`{style="bord |
|                                      | er: 0px none rgb(0, 0, 255); color:  |
|                                      | rgb(0, 0, 255); display: inline; fon |
|                                      | t-style: normal; font-variant: norma |
|                                      | l; font-weight: normal; font-stretch |
|                                      | : normal; font-size: 14px; font-fami |
|                                      | ly: Consolas, "Bitstream Vera Sans M |
|                                      | ono", "Courier New", Courier, monosp |
|                                      | ace; line-height: 15.4px; margin: 0p |
|                                      | x; outline: rgb(0, 0, 255) none 0px; |
|                                      |  padding: 0px; text-align: left; tex |
|                                      | t-decoration: none; white-space: pre |
|                                      | ;"}`];`{style="display: inline; font |
|                                      | -style: normal; font-variant: normal |
|                                      | ; font-weight: normal; font-stretch: |
|                                      |  normal; font-size: 14px; font-famil |
|                                      | y: Consolas, "Bitstream Vera Sans Mo |
|                                      | no", "Courier New", Courier, monospa |
|                                      | ce; line-height: 15.4px; margin: 0px |
|                                      | ; padding: 0px; text-align: left; te |
|                                      | xt-decoration: none; white-space: pr |
|                                      | e;"}                                 |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 1033px;">                        |
|                                      |                                      |
|                                      | `    `{style="border: 0px none rgb(3 |
|                                      | 7, 37, 37); color: rgb(37, 37, 37);  |
|                                      | display: inline; font-style: normal; |
|                                      |  font-variant: normal; font-weight:  |
|                                      | normal; font-stretch: normal; font-s |
|                                      | ize: 14px; font-family: Consolas, "B |
|                                      | itstream Vera Sans Mono", "Courier N |
|                                      | ew", Courier, monospace; line-height |
|                                      | : 15.4px; margin: 0px; outline: rgb( |
|                                      | 37, 37, 37) none 0px; padding: 0px;  |
|                                      | text-align: left; text-decoration: n |
|                                      | one; white-space: pre;"}`//  输出为：sun |
|                                      | nyzl:1, jack:0`{style="border: 0px n |
|                                      | one rgb(0, 130, 0); color: rgb(0, 13 |
|                                      | 0, 0); display: inline; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, "Bitstream Vera Sans Mono", "Co |
|                                      | urier New", Courier, monospace; line |
|                                      | -height: 15.4px; margin: 0px; outlin |
|                                      | e: rgb(0, 130, 0) none 0px; padding: |
|                                      |  0px; text-align: left; text-decorat |
|                                      | ion: none; white-space: pre;"}       |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 1033px;">                        |
|                                      |                                      |
|                                      | `    `{style="border: 0px none rgb(3 |
|                                      | 7, 37, 37); color: rgb(37, 37, 37);  |
|                                      | display: inline; font-style: normal; |
|                                      |  font-variant: normal; font-weight:  |
|                                      | normal; font-stretch: normal; font-s |
|                                      | ize: 14px; font-family: Consolas, "B |
|                                      | itstream Vera Sans Mono", "Courier N |
|                                      | ew", Courier, monospace; line-height |
|                                      | : 15.4px; margin: 0px; outline: rgb( |
|                                      | 37, 37, 37) none 0px; padding: 0px;  |
|                                      | text-align: left; text-decoration: n |
|                                      | one; white-space: pre;"}`NSLog(@`{st |
|                                      | yle="display: inline; font-style: no |
|                                      | rmal; font-variant: normal; font-wei |
|                                      | ght: normal; font-stretch: normal; f |
|                                      | ont-size: 14px; font-family: Consola |
|                                      | s, "Bitstream Vera Sans Mono", "Cour |
|                                      | ier New", Courier, monospace; line-h |
|                                      | eight: 15.4px; margin: 0px; padding: |
|                                      |  0px; text-align: left; text-decorat |
|                                      | ion: none; white-space: pre;"}`"sunn |
|                                      | yzl:%d, jack:%d"`{style="border: 0px |
|                                      |  none rgb(0, 0, 255); color: rgb(0,  |
|                                      | 0, 255); display: inline; font-style |
|                                      | : normal; font-variant: normal; font |
|                                      | -weight: normal; font-stretch: norma |
|                                      | l; font-size: 14px; font-family: Con |
|                                      | solas, "Bitstream Vera Sans Mono", " |
|                                      | Courier New", Courier, monospace; li |
|                                      | ne-height: 15.4px; margin: 0px; outl |
|                                      | ine: rgb(0, 0, 255) none 0px; paddin |
|                                      | g: 0px; text-align: left; text-decor |
|                                      | ation: none; white-space: pre;"}`, [ |
|                                      | pred1 evaluateWithObject:sunnyzl], [ |
|                                      | pred1 evaluateWithObject:jack]);`{st |
|                                      | yle="display: inline; font-style: no |
|                                      | rmal; font-variant: normal; font-wei |
|                                      | ght: normal; font-stretch: normal; f |
|                                      | ont-size: 14px; font-family: Consola |
|                                      | s, "Bitstream Vera Sans Mono", "Cour |
|                                      | ier New", Courier, monospace; line-h |
|                                      | eight: 15.4px; margin: 0px; padding: |
|                                      |  0px; text-align: left; text-decorat |
|                                      | ion: none; white-space: pre;"}       |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 1033px;">                        |
|                                      |                                      |
|                                      | `    `{style="border: 0px none rgb(3 |
|                                      | 7, 37, 37); color: rgb(37, 37, 37);  |
|                                      | display: inline; font-style: normal; |
|                                      |  font-variant: normal; font-weight:  |
|                                      | normal; font-stretch: normal; font-s |
|                                      | ize: 14px; font-family: Consolas, "B |
|                                      | itstream Vera Sans Mono", "Courier N |
|                                      | ew", Courier, monospace; line-height |
|                                      | : 15.4px; margin: 0px; outline: rgb( |
|                                      | 37, 37, 37) none 0px; padding: 0px;  |
|                                      | text-align: left; text-decoration: n |
|                                      | one; white-space: pre;"}`//  2.判断年龄是 |
|                                      | 否大于25`{style="border: 0px none rgb(0 |
|                                      | , 130, 0); color: rgb(0, 130, 0); di |
|                                      | splay: inline; font-style: normal; f |
|                                      | ont-variant: normal; font-weight: no |
|                                      | rmal; font-stretch: normal; font-siz |
|                                      | e: 14px; font-family: Consolas, "Bit |
|                                      | stream Vera Sans Mono", "Courier New |
|                                      | ", Courier, monospace; line-height:  |
|                                      | 15.4px; margin: 0px; outline: rgb(0, |
|                                      |  130, 0) none 0px; padding: 0px; tex |
|                                      | t-align: left; text-decoration: none |
|                                      | ; white-space: pre;"}                |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 1033px;">                        |
|                                      |                                      |
|                                      | `    `{style="border: 0px none rgb(3 |
|                                      | 7, 37, 37); color: rgb(37, 37, 37);  |
|                                      | display: inline; font-style: normal; |
|                                      |  font-variant: normal; font-weight:  |
|                                      | normal; font-stretch: normal; font-s |
|                                      | ize: 14px; font-family: Consolas, "B |
|                                      | itstream Vera Sans Mono", "Courier N |
|                                      | ew", Courier, monospace; line-height |
|                                      | : 15.4px; margin: 0px; outline: rgb( |
|                                      | 37, 37, 37) none 0px; padding: 0px;  |
|                                      | text-align: left; text-decoration: n |
|                                      | one; white-space: pre;"}`NSPredicate |
|                                      |  *pred2 = [NSPredicate predicateWith |
|                                      | Format:@`{style="display: inline; fo |
|                                      | nt-style: normal; font-variant: norm |
|                                      | al; font-weight: normal; font-stretc |
|                                      | h: normal; font-size: 14px; font-fam |
|                                      | ily: Consolas, "Bitstream Vera Sans  |
|                                      | Mono", "Courier New", Courier, monos |
|                                      | pace; line-height: 15.4px; margin: 0 |
|                                      | px; padding: 0px; text-align: left;  |
|                                      | text-decoration: none; white-space:  |
|                                      | pre;"}`"age > 25"`{style="border: 0p |
|                                      | x none rgb(0, 0, 255); color: rgb(0, |
|                                      |  0, 255); display: inline; font-styl |
|                                      | e: normal; font-variant: normal; fon |
|                                      | t-weight: normal; font-stretch: norm |
|                                      | al; font-size: 14px; font-family: Co |
|                                      | nsolas, "Bitstream Vera Sans Mono",  |
|                                      | "Courier New", Courier, monospace; l |
|                                      | ine-height: 15.4px; margin: 0px; out |
|                                      | line: rgb(0, 0, 255) none 0px; paddi |
|                                      | ng: 0px; text-align: left; text-deco |
|                                      | ration: none; white-space: pre;"}`]; |
|                                      | `{style="display: inline; font-style |
|                                      | : normal; font-variant: normal; font |
|                                      | -weight: normal; font-stretch: norma |
|                                      | l; font-size: 14px; font-family: Con |
|                                      | solas, "Bitstream Vera Sans Mono", " |
|                                      | Courier New", Courier, monospace; li |
|                                      | ne-height: 15.4px; margin: 0px; padd |
|                                      | ing: 0px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre;"}   |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 1033px;">                        |
|                                      |                                      |
|                                      | `    `{style="border: 0px none rgb(3 |
|                                      | 7, 37, 37); color: rgb(37, 37, 37);  |
|                                      | display: inline; font-style: normal; |
|                                      |  font-variant: normal; font-weight:  |
|                                      | normal; font-stretch: normal; font-s |
|                                      | ize: 14px; font-family: Consolas, "B |
|                                      | itstream Vera Sans Mono", "Courier N |
|                                      | ew", Courier, monospace; line-height |
|                                      | : 15.4px; margin: 0px; outline: rgb( |
|                                      | 37, 37, 37) none 0px; padding: 0px;  |
|                                      | text-align: left; text-decoration: n |
|                                      | one; white-space: pre;"}`//  输出为：sun |
|                                      | nyzl的年龄是否大于25：1, jack的年龄是否大于25：0`{st |
|                                      | yle="border: 0px none rgb(0, 130, 0) |
|                                      | ; color: rgb(0, 130, 0); display: in |
|                                      | line; font-style: normal; font-varia |
|                                      | nt: normal; font-weight: normal; fon |
|                                      | t-stretch: normal; font-size: 14px;  |
|                                      | font-family: Consolas, "Bitstream Ve |
|                                      | ra Sans Mono", "Courier New", Courie |
|                                      | r, monospace; line-height: 15.4px; m |
|                                      | argin: 0px; outline: rgb(0, 130, 0)  |
|                                      | none 0px; padding: 0px; text-align:  |
|                                      | left; text-decoration: none; white-s |
|                                      | pace: pre;"}                         |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 1033px;">                        |
|                                      |                                      |
|                                      | `    `{style="border: 0px none rgb(3 |
|                                      | 7, 37, 37); color: rgb(37, 37, 37);  |
|                                      | display: inline; font-style: normal; |
|                                      |  font-variant: normal; font-weight:  |
|                                      | normal; font-stretch: normal; font-s |
|                                      | ize: 14px; font-family: Consolas, "B |
|                                      | itstream Vera Sans Mono", "Courier N |
|                                      | ew", Courier, monospace; line-height |
|                                      | : 15.4px; margin: 0px; outline: rgb( |
|                                      | 37, 37, 37) none 0px; padding: 0px;  |
|                                      | text-align: left; text-decoration: n |
|                                      | one; white-space: pre;"}`NSLog(@`{st |
|                                      | yle="display: inline; font-style: no |
|                                      | rmal; font-variant: normal; font-wei |
|                                      | ght: normal; font-stretch: normal; f |
|                                      | ont-size: 14px; font-family: Consola |
|                                      | s, "Bitstream Vera Sans Mono", "Cour |
|                                      | ier New", Courier, monospace; line-h |
|                                      | eight: 15.4px; margin: 0px; padding: |
|                                      |  0px; text-align: left; text-decorat |
|                                      | ion: none; white-space: pre;"}`"sunn |
|                                      | yzl的年龄是否大于25：%d, jack的年龄是否大于25：%d"`{ |
|                                      | style="border: 0px none rgb(0, 0, 25 |
|                                      | 5); color: rgb(0, 0, 255); display:  |
|                                      | inline; font-style: normal; font-var |
|                                      | iant: normal; font-weight: normal; f |
|                                      | ont-stretch: normal; font-size: 14px |
|                                      | ; font-family: Consolas, "Bitstream  |
|                                      | Vera Sans Mono", "Courier New", Cour |
|                                      | ier, monospace; line-height: 15.4px; |
|                                      |  margin: 0px; outline: rgb(0, 0, 255 |
|                                      | ) none 0px; padding: 0px; text-align |
|                                      | : left; text-decoration: none; white |
|                                      | -space: pre;"}`, [pred2 evaluateWith |
|                                      | Object:sunnyzl], [pred2 evaluateWith |
|                                      | Object:jack]);`{style="display: inli |
|                                      | ne; font-style: normal; font-variant |
|                                      | : normal; font-weight: normal; font- |
|                                      | stretch: normal; font-size: 14px; fo |
|                                      | nt-family: Consolas, "Bitstream Vera |
|                                      |  Sans Mono", "Courier New", Courier, |
|                                      |  monospace; line-height: 15.4px; mar |
|                                      | gin: 0px; padding: 0px; text-align:  |
|                                      | left; text-decoration: none; white-s |
|                                      | pace: pre;"}                         |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+

</div>

</div>

看到这里我们会发现evaluateWithObject:方法返回的是一个BOOL值，如果符合条件就返回YES，不符合就返回NO。而即使是最简单的使用也有一些大用处，比如以前我们写判断手机号码、邮编等等，像我就喜欢用John
Engelhart大神的RegexKitLite，然而由于年代久远需要导入libicucore.dylib库（xcode7为libicucore.tbd）且由于是mrc又需要添加-fno-objc-arc，至此我们才能使用。然而使用谓词让我们可以用同样简洁的代码实现相同的功能

例二：<span
style="border: 0px none rgb(37, 37, 37); color: rgb(37, 37, 37); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; line-height: 25.2px; margin: 0px; outline: rgb(37, 37, 37) none 0px; padding: 0px; text-decoration: none;">判断手机号是否正确</span>

<div
style="border: 0px none rgb(37, 37, 37); color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 90px; line-height: 28px; margin: 0px; outline: rgb(37, 37, 37) none 0px; padding: 0px; text-decoration: none; width: 720px;">

<div
style="background: none 0% 0% / auto repeat scroll padding-box border-box rgb(255, 255, 255); border: 0px none rgb(37, 37, 37); bottom: 0px; color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 90px; left: 0px; line-height: 28px; margin: 14px 0px; outline: rgb(37, 37, 37) none 0px; overflow: auto; padding: 0px; position: relative; right: 0px; text-decoration: none; top: 0px; width: 703px;">

+--------------------------------------+--------------------------------------+
| <div                                 | <div                                 |
| style="background: none 0% 0% / auto | style="border: 0px none rgb(37, 37,  |
|  repeat scroll padding-box border-bo | 37); bottom: 0px; color: rgb(37, 37, |
| x rgb(255, 255, 255); color: rgb(175 |  37); display: block; font-style: no |
| , 175, 175); display: block; font-st | rmal; font-variant: normal; font-wei |
| yle: normal; font-variant: normal; f | ght: normal; font-stretch: normal; f |
| ont-weight: normal; font-stretch: no | ont-size: 14px; font-family: Consola |
| rmal; font-size: 14px; font-family:  | s, &quot;Bitstream Vera Sans Mono&qu |
| Consolas, &quot;Bitstream Vera Sans  | ot;, &quot;Courier New&quot;, Courie |
| Mono&quot;, &quot;Courier New&quot;, | r, monospace; height: 90px; left: 0p |
|  Courier, monospace; height: 15px; l | x; line-height: 15.4px; margin: 0px; |
| ine-height: 15.4px; margin: 0px; out |  outline: rgb(37, 37, 37) none 0px;  |
| line: rgb(175, 175, 175) none 0px; p | padding: 0px; position: relative; ri |
| adding: 0px 7px 0px 14px; text-align | ght: 0px; text-align: left; text-dec |
| : right; text-decoration: none; whit | oration: none; top: 0px; width: 675p |
| e-space: pre; width: 8px;">          | x;">                                 |
|                                      |                                      |
| 1                                    | <div                                 |
|                                      | style="background: none 0% 0% / auto |
| </div>                               |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
| <div                                 | ne rgb(37, 37, 37); color: rgb(37, 3 |
| style="background: none 0% 0% / auto | 7, 37); display: block; font-style:  |
|  repeat scroll padding-box border-bo | normal; font-variant: normal; font-w |
| x rgb(255, 255, 255); color: rgb(175 | eight: normal; font-stretch: normal; |
| , 175, 175); display: block; font-st |  font-size: 14px; font-family: Conso |
| yle: normal; font-variant: normal; f | las, &quot;Bitstream Vera Sans Mono& |
| ont-weight: normal; font-stretch: no | quot;, &quot;Courier New&quot;, Cour |
| rmal; font-size: 14px; font-family:  | ier, monospace; height: 15px; line-h |
| Consolas, &quot;Bitstream Vera Sans  | eight: 15.4px; margin: 0px; outline: |
| Mono&quot;, &quot;Courier New&quot;, |  rgb(37, 37, 37) none 0px; padding:  |
|  Courier, monospace; height: 15px; l | 0px 14px; text-align: left; text-dec |
| ine-height: 15.4px; margin: 0px; out | oration: none; white-space: pre; wid |
| line: rgb(175, 175, 175) none 0px; p | th: 647px;">                         |
| adding: 0px 7px 0px 14px; text-align |                                      |
| : right; text-decoration: none; whit | ` `{style="border: 0px none rgb(37,  |
| e-space: pre; width: 8px;">          | 37, 37); color: rgb(37, 37, 37); dis |
|                                      | play: inline; font-style: normal; fo |
| 2                                    | nt-variant: normal; font-weight: nor |
|                                      | mal; font-stretch: normal; font-size |
| </div>                               | : 14px; font-family: Consolas, "Bits |
|                                      | tream Vera Sans Mono", "Courier New" |
| <div                                 | , Courier, monospace; line-height: 1 |
| style="background: none 0% 0% / auto | 5.4px; margin: 0px; outline: rgb(37, |
|  repeat scroll padding-box border-bo |  37, 37) none 0px; padding: 0px; tex |
| x rgb(255, 255, 255); color: rgb(175 | t-align: left; text-decoration: none |
| , 175, 175); display: block; font-st | ; white-space: pre;"}`- (BOOL)checkP |
| yle: normal; font-variant: normal; f | honeNumber:(NSString *)phoneNumber`{ |
| ont-weight: normal; font-stretch: no | style="display: inline; font-style:  |
| rmal; font-size: 14px; font-family:  | normal; font-variant: normal; font-w |
| Consolas, &quot;Bitstream Vera Sans  | eight: normal; font-stretch: normal; |
| Mono&quot;, &quot;Courier New&quot;, |  font-size: 14px; font-family: Conso |
|  Courier, monospace; height: 15px; l | las, "Bitstream Vera Sans Mono", "Co |
| ine-height: 15.4px; margin: 0px; out | urier New", Courier, monospace; line |
| line: rgb(175, 175, 175) none 0px; p | -height: 15.4px; margin: 0px; paddin |
| adding: 0px 7px 0px 14px; text-align | g: 0px; text-align: left; text-decor |
| : right; text-decoration: none; whit | ation: none; white-space: pre;"}     |
| e-space: pre; width: 8px;">          |                                      |
|                                      | </div>                               |
| 3                                    |                                      |
|                                      | <div                                 |
| </div>                               | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
| <div                                 | x rgb(255, 255, 255); border: 0px no |
| style="background: none 0% 0% / auto | ne rgb(37, 37, 37); color: rgb(37, 3 |
|  repeat scroll padding-box border-bo | 7, 37); display: block; font-style:  |
| x rgb(255, 255, 255); color: rgb(175 | normal; font-variant: normal; font-w |
| , 175, 175); display: block; font-st | eight: normal; font-stretch: normal; |
| yle: normal; font-variant: normal; f |  font-size: 14px; font-family: Conso |
| ont-weight: normal; font-stretch: no | las, &quot;Bitstream Vera Sans Mono& |
| rmal; font-size: 14px; font-family:  | quot;, &quot;Courier New&quot;, Cour |
| Consolas, &quot;Bitstream Vera Sans  | ier, monospace; height: 15px; line-h |
| Mono&quot;, &quot;Courier New&quot;, | eight: 15.4px; margin: 0px; outline: |
|  Courier, monospace; height: 15px; l |  rgb(37, 37, 37) none 0px; padding:  |
| ine-height: 15.4px; margin: 0px; out | 0px 14px; text-align: left; text-dec |
| line: rgb(175, 175, 175) none 0px; p | oration: none; white-space: pre; wid |
| adding: 0px 7px 0px 14px; text-align | th: 647px;">                         |
| : right; text-decoration: none; whit |                                      |
| e-space: pre; width: 8px;">          | `{`{style="display: inline; font-sty |
|                                      | le: normal; font-variant: normal; fo |
| 4                                    | nt-weight: normal; font-stretch: nor |
|                                      | mal; font-size: 14px; font-family: C |
| </div>                               | onsolas, "Bitstream Vera Sans Mono", |
|                                      |  "Courier New", Courier, monospace;  |
| <div                                 | line-height: 15.4px; margin: 0px; pa |
| style="background: none 0% 0% / auto | dding: 0px; text-align: left; text-d |
|  repeat scroll padding-box border-bo | ecoration: none; white-space: pre;"} |
| x rgb(255, 255, 255); color: rgb(175 |                                      |
| , 175, 175); display: block; font-st | </div>                               |
| yle: normal; font-variant: normal; f |                                      |
| ont-weight: normal; font-stretch: no | <div                                 |
| rmal; font-size: 14px; font-family:  | style="background: none 0% 0% / auto |
| Consolas, &quot;Bitstream Vera Sans  |  repeat scroll padding-box border-bo |
| Mono&quot;, &quot;Courier New&quot;, | x rgb(255, 255, 255); border: 0px no |
|  Courier, monospace; height: 15px; l | ne rgb(37, 37, 37); color: rgb(37, 3 |
| ine-height: 15.4px; margin: 0px; out | 7, 37); display: block; font-style:  |
| line: rgb(175, 175, 175) none 0px; p | normal; font-variant: normal; font-w |
| adding: 0px 7px 0px 14px; text-align | eight: normal; font-stretch: normal; |
| : right; text-decoration: none; whit |  font-size: 14px; font-family: Conso |
| e-space: pre; width: 8px;">          | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
| 5                                    | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
| </div>                               |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
| <div                                 | oration: none; white-space: pre; wid |
| style="background: none 0% 0% / auto | th: 647px;">                         |
|  repeat scroll padding-box border-bo |                                      |
| x rgb(255, 255, 255); color: rgb(175 | `    `{style="border: 0px none rgb(3 |
| , 175, 175); display: block; font-st | 7, 37, 37); color: rgb(37, 37, 37);  |
| yle: normal; font-variant: normal; f | display: inline; font-style: normal; |
| ont-weight: normal; font-stretch: no |  font-variant: normal; font-weight:  |
| rmal; font-size: 14px; font-family:  | normal; font-stretch: normal; font-s |
| Consolas, &quot;Bitstream Vera Sans  | ize: 14px; font-family: Consolas, "B |
| Mono&quot;, &quot;Courier New&quot;, | itstream Vera Sans Mono", "Courier N |
|  Courier, monospace; height: 15px; l | ew", Courier, monospace; line-height |
| ine-height: 15.4px; margin: 0px; out | : 15.4px; margin: 0px; outline: rgb( |
| line: rgb(175, 175, 175) none 0px; p | 37, 37, 37) none 0px; padding: 0px;  |
| adding: 0px 7px 0px 14px; text-align | text-align: left; text-decoration: n |
| : right; text-decoration: none; whit | one; white-space: pre;"}`NSString *r |
| e-space: pre; width: 8px;">          | egex = @`{style="display: inline; fo |
|                                      | nt-style: normal; font-variant: norm |
| 6                                    | al; font-weight: normal; font-stretc |
|                                      | h: normal; font-size: 14px; font-fam |
| </div>                               | ily: Consolas, "Bitstream Vera Sans  |
|                                      | Mono", "Courier New", Courier, monos |
|                                      | pace; line-height: 15.4px; margin: 0 |
|                                      | px; padding: 0px; text-align: left;  |
|                                      | text-decoration: none; white-space:  |
|                                      | pre;"}`"^[1][3-8]\\d{9}$"`{style="bo |
|                                      | rder: 0px none rgb(0, 0, 255); color |
|                                      | : rgb(0, 0, 255); display: inline; f |
|                                      | ont-style: normal; font-variant: nor |
|                                      | mal; font-weight: normal; font-stret |
|                                      | ch: normal; font-size: 14px; font-fa |
|                                      | mily: Consolas, "Bitstream Vera Sans |
|                                      |  Mono", "Courier New", Courier, mono |
|                                      | space; line-height: 15.4px; margin:  |
|                                      | 0px; outline: rgb(0, 0, 255) none 0p |
|                                      | x; padding: 0px; text-align: left; t |
|                                      | ext-decoration: none; white-space: p |
|                                      | re;"}`;`{style="display: inline; fon |
|                                      | t-style: normal; font-variant: norma |
|                                      | l; font-weight: normal; font-stretch |
|                                      | : normal; font-size: 14px; font-fami |
|                                      | ly: Consolas, "Bitstream Vera Sans M |
|                                      | ono", "Courier New", Courier, monosp |
|                                      | ace; line-height: 15.4px; margin: 0p |
|                                      | x; padding: 0px; text-align: left; t |
|                                      | ext-decoration: none; white-space: p |
|                                      | re;"}                                |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 647px;">                         |
|                                      |                                      |
|                                      | `    `{style="border: 0px none rgb(3 |
|                                      | 7, 37, 37); color: rgb(37, 37, 37);  |
|                                      | display: inline; font-style: normal; |
|                                      |  font-variant: normal; font-weight:  |
|                                      | normal; font-stretch: normal; font-s |
|                                      | ize: 14px; font-family: Consolas, "B |
|                                      | itstream Vera Sans Mono", "Courier N |
|                                      | ew", Courier, monospace; line-height |
|                                      | : 15.4px; margin: 0px; outline: rgb( |
|                                      | 37, 37, 37) none 0px; padding: 0px;  |
|                                      | text-align: left; text-decoration: n |
|                                      | one; white-space: pre;"}`NSPredicate |
|                                      |  *pred = [NSPredicate predicateWithF |
|                                      | ormat:@`{style="display: inline; fon |
|                                      | t-style: normal; font-variant: norma |
|                                      | l; font-weight: normal; font-stretch |
|                                      | : normal; font-size: 14px; font-fami |
|                                      | ly: Consolas, "Bitstream Vera Sans M |
|                                      | ono", "Courier New", Courier, monosp |
|                                      | ace; line-height: 15.4px; margin: 0p |
|                                      | x; padding: 0px; text-align: left; t |
|                                      | ext-decoration: none; white-space: p |
|                                      | re;"}`"SELF MATCHES %@"`{style="bord |
|                                      | er: 0px none rgb(0, 0, 255); color:  |
|                                      | rgb(0, 0, 255); display: inline; fon |
|                                      | t-style: normal; font-variant: norma |
|                                      | l; font-weight: normal; font-stretch |
|                                      | : normal; font-size: 14px; font-fami |
|                                      | ly: Consolas, "Bitstream Vera Sans M |
|                                      | ono", "Courier New", Courier, monosp |
|                                      | ace; line-height: 15.4px; margin: 0p |
|                                      | x; outline: rgb(0, 0, 255) none 0px; |
|                                      |  padding: 0px; text-align: left; tex |
|                                      | t-decoration: none; white-space: pre |
|                                      | ;"}`, regex];`{style="display: inlin |
|                                      | e; font-style: normal; font-variant: |
|                                      |  normal; font-weight: normal; font-s |
|                                      | tretch: normal; font-size: 14px; fon |
|                                      | t-family: Consolas, "Bitstream Vera  |
|                                      | Sans Mono", "Courier New", Courier,  |
|                                      | monospace; line-height: 15.4px; marg |
|                                      | in: 0px; padding: 0px; text-align: l |
|                                      | eft; text-decoration: none; white-sp |
|                                      | ace: pre;"}                          |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 647px;">                         |
|                                      |                                      |
|                                      | `    `{style="border: 0px none rgb(3 |
|                                      | 7, 37, 37); color: rgb(37, 37, 37);  |
|                                      | display: inline; font-style: normal; |
|                                      |  font-variant: normal; font-weight:  |
|                                      | normal; font-stretch: normal; font-s |
|                                      | ize: 14px; font-family: Consolas, "B |
|                                      | itstream Vera Sans Mono", "Courier N |
|                                      | ew", Courier, monospace; line-height |
|                                      | : 15.4px; margin: 0px; outline: rgb( |
|                                      | 37, 37, 37) none 0px; padding: 0px;  |
|                                      | text-align: left; text-decoration: n |
|                                      | one; white-space: pre;"}`return`{sty |
|                                      | le="border: 0px none rgb(0, 102, 153 |
|                                      | ); color: rgb(0, 102, 153); display: |
|                                      |  inline; font-style: normal; font-va |
|                                      | riant: normal; font-weight: bold; fo |
|                                      | nt-stretch: normal; font-size: 14px; |
|                                      |  font-family: Consolas, "Bitstream V |
|                                      | era Sans Mono", "Courier New", Couri |
|                                      | er, monospace; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(0, 102, 15 |
|                                      | 3) none 0px; padding: 0px; text-alig |
|                                      | n: left; text-decoration: none; whit |
|                                      | e-space: pre;"} `[pred evaluateWithO |
|                                      | bject:phoneNumber];`{style="display: |
|                                      |  inline; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, "Bitstream |
|                                      |  Vera Sans Mono", "Courier New", Cou |
|                                      | rier, monospace; line-height: 15.4px |
|                                      | ; margin: 0px; padding: 0px; text-al |
|                                      | ign: left; text-decoration: none; wh |
|                                      | ite-space: pre;"}                    |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 647px;">                         |
|                                      |                                      |
|                                      | `}`{style="display: inline; font-sty |
|                                      | le: normal; font-variant: normal; fo |
|                                      | nt-weight: normal; font-stretch: nor |
|                                      | mal; font-size: 14px; font-family: C |
|                                      | onsolas, "Bitstream Vera Sans Mono", |
|                                      |  "Courier New", Courier, monospace;  |
|                                      | line-height: 15.4px; margin: 0px; pa |
|                                      | dding: 0px; text-align: left; text-d |
|                                      | ecoration: none; white-space: pre;"} |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+

</div>

</div>

看到这里是不是感觉好爽，感觉以前所有的正则都可以这么匹配，但是谓词匹配正则时也是有缺点的，下面通过一个例子来看一下这个致命的缺点

例三：谓词匹配正则的缺点

（本意：检测字符串中是否有特殊字符）

<div
style="border: 0px none rgb(37, 37, 37); color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 107px; line-height: 28px; margin: 0px; outline: rgb(37, 37, 37) none 0px; padding: 0px; text-decoration: none; width: 720px;">

<div
style="background: none 0% 0% / auto repeat scroll padding-box border-box rgb(255, 255, 255); border: 0px none rgb(37, 37, 37); bottom: 0px; color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 90px; left: 0px; line-height: 28px; margin: 14px 0px; outline: rgb(37, 37, 37) none 0px; overflow: auto; padding: 0px; position: relative; right: 0px; text-decoration: none; top: 0px; width: 703px;">

+--------------------------------------+--------------------------------------+
| <div                                 | <div                                 |
| style="background: none 0% 0% / auto | style="border: 0px none rgb(37, 37,  |
|  repeat scroll padding-box border-bo | 37); bottom: 0px; color: rgb(37, 37, |
| x rgb(255, 255, 255); color: rgb(175 |  37); display: block; font-style: no |
| , 175, 175); display: block; font-st | rmal; font-variant: normal; font-wei |
| yle: normal; font-variant: normal; f | ght: normal; font-stretch: normal; f |
| ont-weight: normal; font-stretch: no | ont-size: 14px; font-family: Consola |
| rmal; font-size: 14px; font-family:  | s, &quot;Bitstream Vera Sans Mono&qu |
| Consolas, &quot;Bitstream Vera Sans  | ot;, &quot;Courier New&quot;, Courie |
| Mono&quot;, &quot;Courier New&quot;, | r, monospace; height: 90px; left: 0p |
|  Courier, monospace; height: 15px; l | x; line-height: 15.4px; margin: 0px; |
| ine-height: 15.4px; margin: 0px; out |  outline: rgb(37, 37, 37) none 0px;  |
| line: rgb(175, 175, 175) none 0px; p | padding: 0px; position: relative; ri |
| adding: 0px 7px 0px 14px; text-align | ght: 0px; text-align: left; text-dec |
| : right; text-decoration: none; whit | oration: none; top: 0px; width: 774p |
| e-space: pre; width: 8px;">          | x;">                                 |
|                                      |                                      |
| 1                                    | <div                                 |
|                                      | style="background: none 0% 0% / auto |
| </div>                               |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
| <div                                 | ne rgb(37, 37, 37); color: rgb(37, 3 |
| style="background: none 0% 0% / auto | 7, 37); display: block; font-style:  |
|  repeat scroll padding-box border-bo | normal; font-variant: normal; font-w |
| x rgb(255, 255, 255); color: rgb(175 | eight: normal; font-stretch: normal; |
| , 175, 175); display: block; font-st |  font-size: 14px; font-family: Conso |
| yle: normal; font-variant: normal; f | las, &quot;Bitstream Vera Sans Mono& |
| ont-weight: normal; font-stretch: no | quot;, &quot;Courier New&quot;, Cour |
| rmal; font-size: 14px; font-family:  | ier, monospace; height: 15px; line-h |
| Consolas, &quot;Bitstream Vera Sans  | eight: 15.4px; margin: 0px; outline: |
| Mono&quot;, &quot;Courier New&quot;, |  rgb(37, 37, 37) none 0px; padding:  |
|  Courier, monospace; height: 15px; l | 0px 14px; text-align: left; text-dec |
| ine-height: 15.4px; margin: 0px; out | oration: none; white-space: pre; wid |
| line: rgb(175, 175, 175) none 0px; p | th: 746px;">                         |
| adding: 0px 7px 0px 14px; text-align |                                      |
| : right; text-decoration: none; whit | `- (BOOL)checkSpecialCharacter:(NSSt |
| e-space: pre; width: 8px;">          | ring *)string`{style="display: inlin |
|                                      | e; font-style: normal; font-variant: |
| 2                                    |  normal; font-weight: normal; font-s |
|                                      | tretch: normal; font-size: 14px; fon |
| </div>                               | t-family: Consolas, "Bitstream Vera  |
|                                      | Sans Mono", "Courier New", Courier,  |
| <div                                 | monospace; line-height: 15.4px; marg |
| style="background: none 0% 0% / auto | in: 0px; padding: 0px; text-align: l |
|  repeat scroll padding-box border-bo | eft; text-decoration: none; white-sp |
| x rgb(255, 255, 255); color: rgb(175 | ace: pre;"}                          |
| , 175, 175); display: block; font-st |                                      |
| yle: normal; font-variant: normal; f | </div>                               |
| ont-weight: normal; font-stretch: no |                                      |
| rmal; font-size: 14px; font-family:  | <div                                 |
| Consolas, &quot;Bitstream Vera Sans  | style="background: none 0% 0% / auto |
| Mono&quot;, &quot;Courier New&quot;, |  repeat scroll padding-box border-bo |
|  Courier, monospace; height: 15px; l | x rgb(255, 255, 255); border: 0px no |
| ine-height: 15.4px; margin: 0px; out | ne rgb(37, 37, 37); color: rgb(37, 3 |
| line: rgb(175, 175, 175) none 0px; p | 7, 37); display: block; font-style:  |
| adding: 0px 7px 0px 14px; text-align | normal; font-variant: normal; font-w |
| : right; text-decoration: none; whit | eight: normal; font-stretch: normal; |
| e-space: pre; width: 8px;">          |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
| 3                                    | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
| </div>                               | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
| <div                                 | 0px 14px; text-align: left; text-dec |
| style="background: none 0% 0% / auto | oration: none; white-space: pre; wid |
|  repeat scroll padding-box border-bo | th: 746px;">                         |
| x rgb(255, 255, 255); color: rgb(175 |                                      |
| , 175, 175); display: block; font-st | `{`{style="display: inline; font-sty |
| yle: normal; font-variant: normal; f | le: normal; font-variant: normal; fo |
| ont-weight: normal; font-stretch: no | nt-weight: normal; font-stretch: nor |
| rmal; font-size: 14px; font-family:  | mal; font-size: 14px; font-family: C |
| Consolas, &quot;Bitstream Vera Sans  | onsolas, "Bitstream Vera Sans Mono", |
| Mono&quot;, &quot;Courier New&quot;, |  "Courier New", Courier, monospace;  |
|  Courier, monospace; height: 15px; l | line-height: 15.4px; margin: 0px; pa |
| ine-height: 15.4px; margin: 0px; out | dding: 0px; text-align: left; text-d |
| line: rgb(175, 175, 175) none 0px; p | ecoration: none; white-space: pre;"} |
| adding: 0px 7px 0px 14px; text-align |                                      |
| : right; text-decoration: none; whit | </div>                               |
| e-space: pre; width: 8px;">          |                                      |
|                                      | <div                                 |
| 4                                    | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
| </div>                               | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
| <div                                 | 7, 37); display: block; font-style:  |
| style="background: none 0% 0% / auto | normal; font-variant: normal; font-w |
|  repeat scroll padding-box border-bo | eight: normal; font-stretch: normal; |
| x rgb(255, 255, 255); color: rgb(175 |  font-size: 14px; font-family: Conso |
| , 175, 175); display: block; font-st | las, &quot;Bitstream Vera Sans Mono& |
| yle: normal; font-variant: normal; f | quot;, &quot;Courier New&quot;, Cour |
| ont-weight: normal; font-stretch: no | ier, monospace; height: 15px; line-h |
| rmal; font-size: 14px; font-family:  | eight: 15.4px; margin: 0px; outline: |
| Consolas, &quot;Bitstream Vera Sans  |  rgb(37, 37, 37) none 0px; padding:  |
| Mono&quot;, &quot;Courier New&quot;, | 0px 14px; text-align: left; text-dec |
|  Courier, monospace; height: 15px; l | oration: none; white-space: pre; wid |
| ine-height: 15.4px; margin: 0px; out | th: 746px;">                         |
| line: rgb(175, 175, 175) none 0px; p |                                      |
| adding: 0px 7px 0px 14px; text-align | `    `{style="border: 0px none rgb(3 |
| : right; text-decoration: none; whit | 7, 37, 37); color: rgb(37, 37, 37);  |
| e-space: pre; width: 8px;">          | display: inline; font-style: normal; |
|                                      |  font-variant: normal; font-weight:  |
| 5                                    | normal; font-stretch: normal; font-s |
|                                      | ize: 14px; font-family: Consolas, "B |
| </div>                               | itstream Vera Sans Mono", "Courier N |
|                                      | ew", Courier, monospace; line-height |
| <div                                 | : 15.4px; margin: 0px; outline: rgb( |
| style="background: none 0% 0% / auto | 37, 37, 37) none 0px; padding: 0px;  |
|  repeat scroll padding-box border-bo | text-align: left; text-decoration: n |
| x rgb(255, 255, 255); color: rgb(175 | one; white-space: pre;"}`NSString *r |
| , 175, 175); display: block; font-st | egex = @`{style="display: inline; fo |
| yle: normal; font-variant: normal; f | nt-style: normal; font-variant: norm |
| ont-weight: normal; font-stretch: no | al; font-weight: normal; font-stretc |
| rmal; font-size: 14px; font-family:  | h: normal; font-size: 14px; font-fam |
| Consolas, &quot;Bitstream Vera Sans  | ily: Consolas, "Bitstream Vera Sans  |
| Mono&quot;, &quot;Courier New&quot;, | Mono", "Courier New", Courier, monos |
|  Courier, monospace; height: 15px; l | pace; line-height: 15.4px; margin: 0 |
| ine-height: 15.4px; margin: 0px; out | px; padding: 0px; text-align: left;  |
| line: rgb(175, 175, 175) none 0px; p | text-decoration: none; white-space:  |
| adding: 0px 7px 0px 14px; text-align | pre;"}`` "[`~!@#$^&*()=|{}':;',\\[\\ |
| : right; text-decoration: none; whit | ].<>/?~！@#￥……&*（）——|{}【】‘；：”“'。，、？]" |
| e-space: pre; width: 8px;">          |  ``{style="border: 0px none rgb(0, 0 |
|                                      | , 255); color: rgb(0, 0, 255); displ |
| 6                                    | ay: inline; font-style: normal; font |
|                                      | -variant: normal; font-weight: norma |
| </div>                               | l; font-stretch: normal; font-size:  |
|                                      | 14px; font-family: Consolas, "Bitstr |
|                                      | eam Vera Sans Mono", "Courier New",  |
|                                      | Courier, monospace; line-height: 15. |
|                                      | 4px; margin: 0px; outline: rgb(0, 0, |
|                                      |  255) none 0px; padding: 0px; text-a |
|                                      | lign: left; text-decoration: none; w |
|                                      | hite-space: pre;"}`;`{style="display |
|                                      | : inline; font-style: normal; font-v |
|                                      | ariant: normal; font-weight: normal; |
|                                      |  font-stretch: normal; font-size: 14 |
|                                      | px; font-family: Consolas, "Bitstrea |
|                                      | m Vera Sans Mono", "Courier New", Co |
|                                      | urier, monospace; line-height: 15.4p |
|                                      | x; margin: 0px; padding: 0px; text-a |
|                                      | lign: left; text-decoration: none; w |
|                                      | hite-space: pre;"}                   |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 746px;">                         |
|                                      |                                      |
|                                      | `    `{style="border: 0px none rgb(3 |
|                                      | 7, 37, 37); color: rgb(37, 37, 37);  |
|                                      | display: inline; font-style: normal; |
|                                      |  font-variant: normal; font-weight:  |
|                                      | normal; font-stretch: normal; font-s |
|                                      | ize: 14px; font-family: Consolas, "B |
|                                      | itstream Vera Sans Mono", "Courier N |
|                                      | ew", Courier, monospace; line-height |
|                                      | : 15.4px; margin: 0px; outline: rgb( |
|                                      | 37, 37, 37) none 0px; padding: 0px;  |
|                                      | text-align: left; text-decoration: n |
|                                      | one; white-space: pre;"}`NSPredicate |
|                                      |  *pred = [NSPredicate predicateWithF |
|                                      | ormat:@`{style="display: inline; fon |
|                                      | t-style: normal; font-variant: norma |
|                                      | l; font-weight: normal; font-stretch |
|                                      | : normal; font-size: 14px; font-fami |
|                                      | ly: Consolas, "Bitstream Vera Sans M |
|                                      | ono", "Courier New", Courier, monosp |
|                                      | ace; line-height: 15.4px; margin: 0p |
|                                      | x; padding: 0px; text-align: left; t |
|                                      | ext-decoration: none; white-space: p |
|                                      | re;"}`"SELF MATCHES %@"`{style="bord |
|                                      | er: 0px none rgb(0, 0, 255); color:  |
|                                      | rgb(0, 0, 255); display: inline; fon |
|                                      | t-style: normal; font-variant: norma |
|                                      | l; font-weight: normal; font-stretch |
|                                      | : normal; font-size: 14px; font-fami |
|                                      | ly: Consolas, "Bitstream Vera Sans M |
|                                      | ono", "Courier New", Courier, monosp |
|                                      | ace; line-height: 15.4px; margin: 0p |
|                                      | x; outline: rgb(0, 0, 255) none 0px; |
|                                      |  padding: 0px; text-align: left; tex |
|                                      | t-decoration: none; white-space: pre |
|                                      | ;"}`, regex];`{style="display: inlin |
|                                      | e; font-style: normal; font-variant: |
|                                      |  normal; font-weight: normal; font-s |
|                                      | tretch: normal; font-size: 14px; fon |
|                                      | t-family: Consolas, "Bitstream Vera  |
|                                      | Sans Mono", "Courier New", Courier,  |
|                                      | monospace; line-height: 15.4px; marg |
|                                      | in: 0px; padding: 0px; text-align: l |
|                                      | eft; text-decoration: none; white-sp |
|                                      | ace: pre;"}                          |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 746px;">                         |
|                                      |                                      |
|                                      | `    `{style="border: 0px none rgb(3 |
|                                      | 7, 37, 37); color: rgb(37, 37, 37);  |
|                                      | display: inline; font-style: normal; |
|                                      |  font-variant: normal; font-weight:  |
|                                      | normal; font-stretch: normal; font-s |
|                                      | ize: 14px; font-family: Consolas, "B |
|                                      | itstream Vera Sans Mono", "Courier N |
|                                      | ew", Courier, monospace; line-height |
|                                      | : 15.4px; margin: 0px; outline: rgb( |
|                                      | 37, 37, 37) none 0px; padding: 0px;  |
|                                      | text-align: left; text-decoration: n |
|                                      | one; white-space: pre;"}`return`{sty |
|                                      | le="border: 0px none rgb(0, 102, 153 |
|                                      | ); color: rgb(0, 102, 153); display: |
|                                      |  inline; font-style: normal; font-va |
|                                      | riant: normal; font-weight: bold; fo |
|                                      | nt-stretch: normal; font-size: 14px; |
|                                      |  font-family: Consolas, "Bitstream V |
|                                      | era Sans Mono", "Courier New", Couri |
|                                      | er, monospace; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(0, 102, 15 |
|                                      | 3) none 0px; padding: 0px; text-alig |
|                                      | n: left; text-decoration: none; whit |
|                                      | e-space: pre;"} `[pred evaluateWithO |
|                                      | bject:string];`{style="display: inli |
|                                      | ne; font-style: normal; font-variant |
|                                      | : normal; font-weight: normal; font- |
|                                      | stretch: normal; font-size: 14px; fo |
|                                      | nt-family: Consolas, "Bitstream Vera |
|                                      |  Sans Mono", "Courier New", Courier, |
|                                      |  monospace; line-height: 15.4px; mar |
|                                      | gin: 0px; padding: 0px; text-align:  |
|                                      | left; text-decoration: none; white-s |
|                                      | pace: pre;"}                         |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 746px;">                         |
|                                      |                                      |
|                                      | `}`{style="display: inline; font-sty |
|                                      | le: normal; font-variant: normal; fo |
|                                      | nt-weight: normal; font-stretch: nor |
|                                      | mal; font-size: 14px; font-family: C |
|                                      | onsolas, "Bitstream Vera Sans Mono", |
|                                      |  "Courier New", Courier, monospace;  |
|                                      | line-height: 15.4px; margin: 0px; pa |
|                                      | dding: 0px; text-align: left; text-d |
|                                      | ecoration: none; white-space: pre;"} |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+

</div>

</div>

我们想要的效果是字符串中有特殊字符时就返回YES，然而梦想是美好的，现实是残酷的

让我们看看这悲催的结局

<div
style="border: 0px none rgb(37, 37, 37); color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 60px; line-height: 28px; margin: 0px; outline: rgb(37, 37, 37) none 0px; padding: 0px; text-decoration: none; width: 720px;">

<div
style="background: none 0% 0% / auto repeat scroll padding-box border-box rgb(255, 255, 255); border: 0px none rgb(37, 37, 37); bottom: 0px; color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 60px; left: 0px; line-height: 28px; margin: 14px 0px; outline: rgb(37, 37, 37) none 0px; overflow: auto; padding: 0px; position: relative; right: 0px; text-decoration: none; top: 0px; width: 703px;">

+--------------------------------------+--------------------------------------+
| <div                                 | <div                                 |
| style="background: none 0% 0% / auto | style="border: 0px none rgb(37, 37,  |
|  repeat scroll padding-box border-bo | 37); bottom: 0px; color: rgb(37, 37, |
| x rgb(255, 255, 255); color: rgb(175 |  37); display: block; font-style: no |
| , 175, 175); display: block; font-st | rmal; font-variant: normal; font-wei |
| yle: normal; font-variant: normal; f | ght: normal; font-stretch: normal; f |
| ont-weight: normal; font-stretch: no | ont-size: 14px; font-family: Consola |
| rmal; font-size: 14px; font-family:  | s, &quot;Bitstream Vera Sans Mono&qu |
| Consolas, &quot;Bitstream Vera Sans  | ot;, &quot;Courier New&quot;, Courie |
| Mono&quot;, &quot;Courier New&quot;, | r, monospace; height: 60px; left: 0p |
|  Courier, monospace; height: 15px; l | x; line-height: 15.4px; margin: 0px; |
| ine-height: 15.4px; margin: 0px; out |  outline: rgb(37, 37, 37) none 0px;  |
| line: rgb(175, 175, 175) none 0px; p | padding: 0px; position: relative; ri |
| adding: 0px 7px 0px 14px; text-align | ght: 0px; text-align: left; text-dec |
| : right; text-decoration: none; whit | oration: none; top: 0px; width: 671p |
| e-space: pre; width: 8px;">          | x;">                                 |
|                                      |                                      |
| 1                                    | <div                                 |
|                                      | style="background: none 0% 0% / auto |
| </div>                               |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
| <div                                 | ne rgb(37, 37, 37); color: rgb(37, 3 |
| style="background: none 0% 0% / auto | 7, 37); display: block; font-style:  |
|  repeat scroll padding-box border-bo | normal; font-variant: normal; font-w |
| x rgb(255, 255, 255); color: rgb(175 | eight: normal; font-stretch: normal; |
| , 175, 175); display: block; font-st |  font-size: 14px; font-family: Conso |
| yle: normal; font-variant: normal; f | las, &quot;Bitstream Vera Sans Mono& |
| ont-weight: normal; font-stretch: no | quot;, &quot;Courier New&quot;, Cour |
| rmal; font-size: 14px; font-family:  | ier, monospace; height: 15px; line-h |
| Consolas, &quot;Bitstream Vera Sans  | eight: 15.4px; margin: 0px; outline: |
| Mono&quot;, &quot;Courier New&quot;, |  rgb(37, 37, 37) none 0px; padding:  |
|  Courier, monospace; height: 15px; l | 0px 14px; text-align: left; text-dec |
| ine-height: 15.4px; margin: 0px; out | oration: none; white-space: pre; wid |
| line: rgb(175, 175, 175) none 0px; p | th: 643px;">                         |
| adding: 0px 7px 0px 14px; text-align |                                      |
| : right; text-decoration: none; whit | `NSString *testString = @`{style="di |
| e-space: pre; width: 8px;">          | splay: inline; font-style: normal; f |
|                                      | ont-variant: normal; font-weight: no |
| 2                                    | rmal; font-stretch: normal; font-siz |
|                                      | e: 14px; font-family: Consolas, "Bit |
| </div>                               | stream Vera Sans Mono", "Courier New |
|                                      | ", Courier, monospace; line-height:  |
| <div                                 | 15.4px; margin: 0px; padding: 0px; t |
| style="background: none 0% 0% / auto | ext-align: left; text-decoration: no |
|  repeat scroll padding-box border-bo | ne; white-space: pre;"}`"!"`{style=" |
| x rgb(255, 255, 255); color: rgb(175 | border: 0px none rgb(0, 0, 255); col |
| , 175, 175); display: block; font-st | or: rgb(0, 0, 255); display: inline; |
| yle: normal; font-variant: normal; f |  font-style: normal; font-variant: n |
| ont-weight: normal; font-stretch: no | ormal; font-weight: normal; font-str |
| rmal; font-size: 14px; font-family:  | etch: normal; font-size: 14px; font- |
| Consolas, &quot;Bitstream Vera Sans  | family: Consolas, "Bitstream Vera Sa |
| Mono&quot;, &quot;Courier New&quot;, | ns Mono", "Courier New", Courier, mo |
|  Courier, monospace; height: 15px; l | nospace; line-height: 15.4px; margin |
| ine-height: 15.4px; margin: 0px; out | : 0px; outline: rgb(0, 0, 255) none  |
| line: rgb(175, 175, 175) none 0px; p | 0px; padding: 0px; text-align: left; |
| adding: 0px 7px 0px 14px; text-align |  text-decoration: none; white-space: |
| : right; text-decoration: none; whit |  pre;"}`;`{style="display: inline; f |
| e-space: pre; width: 8px;">          | ont-style: normal; font-variant: nor |
|                                      | mal; font-weight: normal; font-stret |
| 3                                    | ch: normal; font-size: 14px; font-fa |
|                                      | mily: Consolas, "Bitstream Vera Sans |
| </div>                               |  Mono", "Courier New", Courier, mono |
|                                      | space; line-height: 15.4px; margin:  |
| <div                                 | 0px; padding: 0px; text-align: left; |
| style="background: none 0% 0% / auto |  text-decoration: none; white-space: |
|  repeat scroll padding-box border-bo |  pre;"}                              |
| x rgb(255, 255, 255); color: rgb(175 |                                      |
| , 175, 175); display: block; font-st | </div>                               |
| yle: normal; font-variant: normal; f |                                      |
| ont-weight: normal; font-stretch: no | <div                                 |
| rmal; font-size: 14px; font-family:  | style="background: none 0% 0% / auto |
| Consolas, &quot;Bitstream Vera Sans  |  repeat scroll padding-box border-bo |
| Mono&quot;, &quot;Courier New&quot;, | x rgb(255, 255, 255); border: 0px no |
|  Courier, monospace; height: 15px; l | ne rgb(37, 37, 37); color: rgb(37, 3 |
| ine-height: 15.4px; margin: 0px; out | 7, 37); display: block; font-style:  |
| line: rgb(175, 175, 175) none 0px; p | normal; font-variant: normal; font-w |
| adding: 0px 7px 0px 14px; text-align | eight: normal; font-stretch: normal; |
| : right; text-decoration: none; whit |  font-size: 14px; font-family: Conso |
| e-space: pre; width: 8px;">          | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
| 4                                    | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
| </div>                               |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 643px;">                         |
|                                      |                                      |
|                                      | `NSLog(@`{style="display: inline; fo |
|                                      | nt-style: normal; font-variant: norm |
|                                      | al; font-weight: normal; font-stretc |
|                                      | h: normal; font-size: 14px; font-fam |
|                                      | ily: Consolas, "Bitstream Vera Sans  |
|                                      | Mono", "Courier New", Courier, monos |
|                                      | pace; line-height: 15.4px; margin: 0 |
|                                      | px; padding: 0px; text-align: left;  |
|                                      | text-decoration: none; white-space:  |
|                                      | pre;"}`"是否含有特殊字符：%d"`{style="border: |
|                                      |  0px none rgb(0, 0, 255); color: rgb |
|                                      | (0, 0, 255); display: inline; font-s |
|                                      | tyle: normal; font-variant: normal;  |
|                                      | font-weight: normal; font-stretch: n |
|                                      | ormal; font-size: 14px; font-family: |
|                                      |  Consolas, "Bitstream Vera Sans Mono |
|                                      | ", "Courier New", Courier, monospace |
|                                      | ; line-height: 15.4px; margin: 0px;  |
|                                      | outline: rgb(0, 0, 255) none 0px; pa |
|                                      | dding: 0px; text-align: left; text-d |
|                                      | ecoration: none; white-space: pre;"} |
|                                      | `, [self checkSpecialCharacter:testS |
|                                      | tring]);`{style="display: inline; fo |
|                                      | nt-style: normal; font-variant: norm |
|                                      | al; font-weight: normal; font-stretc |
|                                      | h: normal; font-size: 14px; font-fam |
|                                      | ily: Consolas, "Bitstream Vera Sans  |
|                                      | Mono", "Courier New", Courier, monos |
|                                      | pace; line-height: 15.4px; margin: 0 |
|                                      | px; padding: 0px; text-align: left;  |
|                                      | text-decoration: none; white-space:  |
|                                      | pre;"}                               |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 643px;">                         |
|                                      |                                      |
|                                      | `//  当testString为一个特殊字符时，我们惊喜的发现输出为` |
|                                      | {style="border: 0px none rgb(0, 130, |
|                                      |  0); color: rgb(0, 130, 0); display: |
|                                      |  inline; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, "Bitstream |
|                                      |  Vera Sans Mono", "Courier New", Cou |
|                                      | rier, monospace; line-height: 15.4px |
|                                      | ; margin: 0px; outline: rgb(0, 130,  |
|                                      | 0) none 0px; padding: 0px; text-alig |
|                                      | n: left; text-decoration: none; whit |
|                                      | e-space: pre;"}                      |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 643px;">                         |
|                                      |                                      |
|                                      | `//  是否含有特殊字符：1`{style="border: 0px  |
|                                      | none rgb(0, 130, 0); color: rgb(0, 1 |
|                                      | 30, 0); display: inline; font-style: |
|                                      |  normal; font-variant: normal; font- |
|                                      | weight: normal; font-stretch: normal |
|                                      | ; font-size: 14px; font-family: Cons |
|                                      | olas, "Bitstream Vera Sans Mono", "C |
|                                      | ourier New", Courier, monospace; lin |
|                                      | e-height: 15.4px; margin: 0px; outli |
|                                      | ne: rgb(0, 130, 0) none 0px; padding |
|                                      | : 0px; text-align: left; text-decora |
|                                      | tion: none; white-space: pre;"}      |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+

</div>

</div>

看到这里我们心里猛然一喜，这tmd根本没问题嘛

让我们修改下testString的值

<div
style="border: 0px none rgb(37, 37, 37); color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 60px; line-height: 28px; margin: 0px; outline: rgb(37, 37, 37) none 0px; padding: 0px; text-decoration: none; width: 720px;">

<div
style="background: none 0% 0% / auto repeat scroll padding-box border-box rgb(255, 255, 255); border: 0px none rgb(37, 37, 37); bottom: 0px; color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 60px; left: 0px; line-height: 28px; margin: 14px 0px; outline: rgb(37, 37, 37) none 0px; overflow: auto; padding: 0px; position: relative; right: 0px; text-decoration: none; top: 0px; width: 703px;">

+--------------------------------------+--------------------------------------+
| <div                                 | <div                                 |
| style="background: none 0% 0% / auto | style="border: 0px none rgb(37, 37,  |
|  repeat scroll padding-box border-bo | 37); bottom: 0px; color: rgb(37, 37, |
| x rgb(255, 255, 255); color: rgb(175 |  37); display: block; font-style: no |
| , 175, 175); display: block; font-st | rmal; font-variant: normal; font-wei |
| yle: normal; font-variant: normal; f | ght: normal; font-stretch: normal; f |
| ont-weight: normal; font-stretch: no | ont-size: 14px; font-family: Consola |
| rmal; font-size: 14px; font-family:  | s, &quot;Bitstream Vera Sans Mono&qu |
| Consolas, &quot;Bitstream Vera Sans  | ot;, &quot;Courier New&quot;, Courie |
| Mono&quot;, &quot;Courier New&quot;, | r, monospace; height: 60px; left: 0p |
|  Courier, monospace; height: 15px; l | x; line-height: 15.4px; margin: 0px; |
| ine-height: 15.4px; margin: 0px; out |  outline: rgb(37, 37, 37) none 0px;  |
| line: rgb(175, 175, 175) none 0px; p | padding: 0px; position: relative; ri |
| adding: 0px 7px 0px 14px; text-align | ght: 0px; text-align: left; text-dec |
| : right; text-decoration: none; whit | oration: none; top: 0px; width: 671p |
| e-space: pre; width: 8px;">          | x;">                                 |
|                                      |                                      |
| 1                                    | <div                                 |
|                                      | style="background: none 0% 0% / auto |
| </div>                               |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
| <div                                 | ne rgb(37, 37, 37); color: rgb(37, 3 |
| style="background: none 0% 0% / auto | 7, 37); display: block; font-style:  |
|  repeat scroll padding-box border-bo | normal; font-variant: normal; font-w |
| x rgb(255, 255, 255); color: rgb(175 | eight: normal; font-stretch: normal; |
| , 175, 175); display: block; font-st |  font-size: 14px; font-family: Conso |
| yle: normal; font-variant: normal; f | las, &quot;Bitstream Vera Sans Mono& |
| ont-weight: normal; font-stretch: no | quot;, &quot;Courier New&quot;, Cour |
| rmal; font-size: 14px; font-family:  | ier, monospace; height: 15px; line-h |
| Consolas, &quot;Bitstream Vera Sans  | eight: 15.4px; margin: 0px; outline: |
| Mono&quot;, &quot;Courier New&quot;, |  rgb(37, 37, 37) none 0px; padding:  |
|  Courier, monospace; height: 15px; l | 0px 14px; text-align: left; text-dec |
| ine-height: 15.4px; margin: 0px; out | oration: none; white-space: pre; wid |
| line: rgb(175, 175, 175) none 0px; p | th: 643px;">                         |
| adding: 0px 7px 0px 14px; text-align |                                      |
| : right; text-decoration: none; whit | `NSString *testString = @`{style="di |
| e-space: pre; width: 8px;">          | splay: inline; font-style: normal; f |
|                                      | ont-variant: normal; font-weight: no |
| 2                                    | rmal; font-stretch: normal; font-siz |
|                                      | e: 14px; font-family: Consolas, "Bit |
| </div>                               | stream Vera Sans Mono", "Courier New |
|                                      | ", Courier, monospace; line-height:  |
| <div                                 | 15.4px; margin: 0px; padding: 0px; t |
| style="background: none 0% 0% / auto | ext-align: left; text-decoration: no |
|  repeat scroll padding-box border-bo | ne; white-space: pre;"}`"!~"`{style= |
| x rgb(255, 255, 255); color: rgb(175 | "border: 0px none rgb(0, 0, 255); co |
| , 175, 175); display: block; font-st | lor: rgb(0, 0, 255); display: inline |
| yle: normal; font-variant: normal; f | ; font-style: normal; font-variant:  |
| ont-weight: normal; font-stretch: no | normal; font-weight: normal; font-st |
| rmal; font-size: 14px; font-family:  | retch: normal; font-size: 14px; font |
| Consolas, &quot;Bitstream Vera Sans  | -family: Consolas, "Bitstream Vera S |
| Mono&quot;, &quot;Courier New&quot;, | ans Mono", "Courier New", Courier, m |
|  Courier, monospace; height: 15px; l | onospace; line-height: 15.4px; margi |
| ine-height: 15.4px; margin: 0px; out | n: 0px; outline: rgb(0, 0, 255) none |
| line: rgb(175, 175, 175) none 0px; p |  0px; padding: 0px; text-align: left |
| adding: 0px 7px 0px 14px; text-align | ; text-decoration: none; white-space |
| : right; text-decoration: none; whit | : pre;"}`;`{style="display: inline;  |
| e-space: pre; width: 8px;">          | font-style: normal; font-variant: no |
|                                      | rmal; font-weight: normal; font-stre |
| 3                                    | tch: normal; font-size: 14px; font-f |
|                                      | amily: Consolas, "Bitstream Vera San |
| </div>                               | s Mono", "Courier New", Courier, mon |
|                                      | ospace; line-height: 15.4px; margin: |
| <div                                 |  0px; padding: 0px; text-align: left |
| style="background: none 0% 0% / auto | ; text-decoration: none; white-space |
|  repeat scroll padding-box border-bo | : pre;"}                             |
| x rgb(255, 255, 255); color: rgb(175 |                                      |
| , 175, 175); display: block; font-st | </div>                               |
| yle: normal; font-variant: normal; f |                                      |
| ont-weight: normal; font-stretch: no | <div                                 |
| rmal; font-size: 14px; font-family:  | style="background: none 0% 0% / auto |
| Consolas, &quot;Bitstream Vera Sans  |  repeat scroll padding-box border-bo |
| Mono&quot;, &quot;Courier New&quot;, | x rgb(255, 255, 255); border: 0px no |
|  Courier, monospace; height: 15px; l | ne rgb(37, 37, 37); color: rgb(37, 3 |
| ine-height: 15.4px; margin: 0px; out | 7, 37); display: block; font-style:  |
| line: rgb(175, 175, 175) none 0px; p | normal; font-variant: normal; font-w |
| adding: 0px 7px 0px 14px; text-align | eight: normal; font-stretch: normal; |
| : right; text-decoration: none; whit |  font-size: 14px; font-family: Conso |
| e-space: pre; width: 8px;">          | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
| 4                                    | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
| </div>                               |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 643px;">                         |
|                                      |                                      |
|                                      | `NSLog(@`{style="display: inline; fo |
|                                      | nt-style: normal; font-variant: norm |
|                                      | al; font-weight: normal; font-stretc |
|                                      | h: normal; font-size: 14px; font-fam |
|                                      | ily: Consolas, "Bitstream Vera Sans  |
|                                      | Mono", "Courier New", Courier, monos |
|                                      | pace; line-height: 15.4px; margin: 0 |
|                                      | px; padding: 0px; text-align: left;  |
|                                      | text-decoration: none; white-space:  |
|                                      | pre;"}`"%d"`{style="border: 0px none |
|                                      |  rgb(0, 0, 255); color: rgb(0, 0, 25 |
|                                      | 5); display: inline; font-style: nor |
|                                      | mal; font-variant: normal; font-weig |
|                                      | ht: normal; font-stretch: normal; fo |
|                                      | nt-size: 14px; font-family: Consolas |
|                                      | , "Bitstream Vera Sans Mono", "Couri |
|                                      | er New", Courier, monospace; line-he |
|                                      | ight: 15.4px; margin: 0px; outline:  |
|                                      | rgb(0, 0, 255) none 0px; padding: 0p |
|                                      | x; text-align: left; text-decoration |
|                                      | : none; white-space: pre;"}`, [self  |
|                                      | checkSpecialCharacter:testString]);` |
|                                      | {style="display: inline; font-style: |
|                                      |  normal; font-variant: normal; font- |
|                                      | weight: normal; font-stretch: normal |
|                                      | ; font-size: 14px; font-family: Cons |
|                                      | olas, "Bitstream Vera Sans Mono", "C |
|                                      | ourier New", Courier, monospace; lin |
|                                      | e-height: 15.4px; margin: 0px; paddi |
|                                      | ng: 0px; text-align: left; text-deco |
|                                      | ration: none; white-space: pre;"}    |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 643px;">                         |
|                                      |                                      |
|                                      | `//  我们会发现悲催的结局来了输出为`{style="border: |
|                                      |  0px none rgb(0, 130, 0); color: rgb |
|                                      | (0, 130, 0); display: inline; font-s |
|                                      | tyle: normal; font-variant: normal;  |
|                                      | font-weight: normal; font-stretch: n |
|                                      | ormal; font-size: 14px; font-family: |
|                                      |  Consolas, "Bitstream Vera Sans Mono |
|                                      | ", "Courier New", Courier, monospace |
|                                      | ; line-height: 15.4px; margin: 0px;  |
|                                      | outline: rgb(0, 130, 0) none 0px; pa |
|                                      | dding: 0px; text-align: left; text-d |
|                                      | ecoration: none; white-space: pre;"} |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 643px;">                         |
|                                      |                                      |
|                                      | `//  是否含有特殊字符：0`{style="border: 0px  |
|                                      | none rgb(0, 130, 0); color: rgb(0, 1 |
|                                      | 30, 0); display: inline; font-style: |
|                                      |  normal; font-variant: normal; font- |
|                                      | weight: normal; font-stretch: normal |
|                                      | ; font-size: 14px; font-family: Cons |
|                                      | olas, "Bitstream Vera Sans Mono", "C |
|                                      | ourier New", Courier, monospace; lin |
|                                      | e-height: 15.4px; margin: 0px; outli |
|                                      | ne: rgb(0, 130, 0) none 0px; padding |
|                                      | : 0px; text-align: left; text-decora |
|                                      | tion: none; white-space: pre;"}      |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+

</div>

</div>

再次修改testString的值

<div
style="border: 0px none rgb(37, 37, 37); color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 60px; line-height: 28px; margin: 0px; outline: rgb(37, 37, 37) none 0px; padding: 0px; text-decoration: none; width: 720px;">

<div
style="background: none 0% 0% / auto repeat scroll padding-box border-box rgb(255, 255, 255); border: 0px none rgb(37, 37, 37); bottom: 0px; color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 60px; left: 0px; line-height: 28px; margin: 14px 0px; outline: rgb(37, 37, 37) none 0px; overflow: auto; padding: 0px; position: relative; right: 0px; text-decoration: none; top: 0px; width: 703px;">

+--------------------------------------+--------------------------------------+
| <div                                 | <div                                 |
| style="background: none 0% 0% / auto | style="border: 0px none rgb(37, 37,  |
|  repeat scroll padding-box border-bo | 37); bottom: 0px; color: rgb(37, 37, |
| x rgb(255, 255, 255); color: rgb(175 |  37); display: block; font-style: no |
| , 175, 175); display: block; font-st | rmal; font-variant: normal; font-wei |
| yle: normal; font-variant: normal; f | ght: normal; font-stretch: normal; f |
| ont-weight: normal; font-stretch: no | ont-size: 14px; font-family: Consola |
| rmal; font-size: 14px; font-family:  | s, &quot;Bitstream Vera Sans Mono&qu |
| Consolas, &quot;Bitstream Vera Sans  | ot;, &quot;Courier New&quot;, Courie |
| Mono&quot;, &quot;Courier New&quot;, | r, monospace; height: 60px; left: 0p |
|  Courier, monospace; height: 15px; l | x; line-height: 15.4px; margin: 0px; |
| ine-height: 15.4px; margin: 0px; out |  outline: rgb(37, 37, 37) none 0px;  |
| line: rgb(175, 175, 175) none 0px; p | padding: 0px; position: relative; ri |
| adding: 0px 7px 0px 14px; text-align | ght: 0px; text-align: left; text-dec |
| : right; text-decoration: none; whit | oration: none; top: 0px; width: 671p |
| e-space: pre; width: 8px;">          | x;">                                 |
|                                      |                                      |
| 1                                    | <div                                 |
|                                      | style="background: none 0% 0% / auto |
| </div>                               |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
| <div                                 | ne rgb(37, 37, 37); color: rgb(37, 3 |
| style="background: none 0% 0% / auto | 7, 37); display: block; font-style:  |
|  repeat scroll padding-box border-bo | normal; font-variant: normal; font-w |
| x rgb(255, 255, 255); color: rgb(175 | eight: normal; font-stretch: normal; |
| , 175, 175); display: block; font-st |  font-size: 14px; font-family: Conso |
| yle: normal; font-variant: normal; f | las, &quot;Bitstream Vera Sans Mono& |
| ont-weight: normal; font-stretch: no | quot;, &quot;Courier New&quot;, Cour |
| rmal; font-size: 14px; font-family:  | ier, monospace; height: 15px; line-h |
| Consolas, &quot;Bitstream Vera Sans  | eight: 15.4px; margin: 0px; outline: |
| Mono&quot;, &quot;Courier New&quot;, |  rgb(37, 37, 37) none 0px; padding:  |
|  Courier, monospace; height: 15px; l | 0px 14px; text-align: left; text-dec |
| ine-height: 15.4px; margin: 0px; out | oration: none; white-space: pre; wid |
| line: rgb(175, 175, 175) none 0px; p | th: 643px;">                         |
| adding: 0px 7px 0px 14px; text-align |                                      |
| : right; text-decoration: none; whit | `NSString *testString = @`{style="di |
| e-space: pre; width: 8px;">          | splay: inline; font-style: normal; f |
|                                      | ont-variant: normal; font-weight: no |
| 2                                    | rmal; font-stretch: normal; font-siz |
|                                      | e: 14px; font-family: Consolas, "Bit |
| </div>                               | stream Vera Sans Mono", "Courier New |
|                                      | ", Courier, monospace; line-height:  |
| <div                                 | 15.4px; margin: 0px; padding: 0px; t |
| style="background: none 0% 0% / auto | ext-align: left; text-decoration: no |
|  repeat scroll padding-box border-bo | ne; white-space: pre;"}`"abc!~d"`{st |
| x rgb(255, 255, 255); color: rgb(175 | yle="border: 0px none rgb(0, 0, 255) |
| , 175, 175); display: block; font-st | ; color: rgb(0, 0, 255); display: in |
| yle: normal; font-variant: normal; f | line; font-style: normal; font-varia |
| ont-weight: normal; font-stretch: no | nt: normal; font-weight: normal; fon |
| rmal; font-size: 14px; font-family:  | t-stretch: normal; font-size: 14px;  |
| Consolas, &quot;Bitstream Vera Sans  | font-family: Consolas, "Bitstream Ve |
| Mono&quot;, &quot;Courier New&quot;, | ra Sans Mono", "Courier New", Courie |
|  Courier, monospace; height: 15px; l | r, monospace; line-height: 15.4px; m |
| ine-height: 15.4px; margin: 0px; out | argin: 0px; outline: rgb(0, 0, 255)  |
| line: rgb(175, 175, 175) none 0px; p | none 0px; padding: 0px; text-align:  |
| adding: 0px 7px 0px 14px; text-align | left; text-decoration: none; white-s |
| : right; text-decoration: none; whit | pace: pre;"}`;`{style="display: inli |
| e-space: pre; width: 8px;">          | ne; font-style: normal; font-variant |
|                                      | : normal; font-weight: normal; font- |
| 3                                    | stretch: normal; font-size: 14px; fo |
|                                      | nt-family: Consolas, "Bitstream Vera |
| </div>                               |  Sans Mono", "Courier New", Courier, |
|                                      |  monospace; line-height: 15.4px; mar |
| <div                                 | gin: 0px; padding: 0px; text-align:  |
| style="background: none 0% 0% / auto | left; text-decoration: none; white-s |
|  repeat scroll padding-box border-bo | pace: pre;"}                         |
| x rgb(255, 255, 255); color: rgb(175 |                                      |
| , 175, 175); display: block; font-st | </div>                               |
| yle: normal; font-variant: normal; f |                                      |
| ont-weight: normal; font-stretch: no | <div                                 |
| rmal; font-size: 14px; font-family:  | style="background: none 0% 0% / auto |
| Consolas, &quot;Bitstream Vera Sans  |  repeat scroll padding-box border-bo |
| Mono&quot;, &quot;Courier New&quot;, | x rgb(255, 255, 255); border: 0px no |
|  Courier, monospace; height: 15px; l | ne rgb(37, 37, 37); color: rgb(37, 3 |
| ine-height: 15.4px; margin: 0px; out | 7, 37); display: block; font-style:  |
| line: rgb(175, 175, 175) none 0px; p | normal; font-variant: normal; font-w |
| adding: 0px 7px 0px 14px; text-align | eight: normal; font-stretch: normal; |
| : right; text-decoration: none; whit |  font-size: 14px; font-family: Conso |
| e-space: pre; width: 8px;">          | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
| 4                                    | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
| </div>                               |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 643px;">                         |
|                                      |                                      |
|                                      | `NSLog(@`{style="display: inline; fo |
|                                      | nt-style: normal; font-variant: norm |
|                                      | al; font-weight: normal; font-stretc |
|                                      | h: normal; font-size: 14px; font-fam |
|                                      | ily: Consolas, "Bitstream Vera Sans  |
|                                      | Mono", "Courier New", Courier, monos |
|                                      | pace; line-height: 15.4px; margin: 0 |
|                                      | px; padding: 0px; text-align: left;  |
|                                      | text-decoration: none; white-space:  |
|                                      | pre;"}`"%d"`{style="border: 0px none |
|                                      |  rgb(0, 0, 255); color: rgb(0, 0, 25 |
|                                      | 5); display: inline; font-style: nor |
|                                      | mal; font-variant: normal; font-weig |
|                                      | ht: normal; font-stretch: normal; fo |
|                                      | nt-size: 14px; font-family: Consolas |
|                                      | , "Bitstream Vera Sans Mono", "Couri |
|                                      | er New", Courier, monospace; line-he |
|                                      | ight: 15.4px; margin: 0px; outline:  |
|                                      | rgb(0, 0, 255) none 0px; padding: 0p |
|                                      | x; text-align: left; text-decoration |
|                                      | : none; white-space: pre;"}`, [self  |
|                                      | checkSpecialCharacter:testString]);` |
|                                      | {style="display: inline; font-style: |
|                                      |  normal; font-variant: normal; font- |
|                                      | weight: normal; font-stretch: normal |
|                                      | ; font-size: 14px; font-family: Cons |
|                                      | olas, "Bitstream Vera Sans Mono", "C |
|                                      | ourier New", Courier, monospace; lin |
|                                      | e-height: 15.4px; margin: 0px; paddi |
|                                      | ng: 0px; text-align: left; text-deco |
|                                      | ration: none; white-space: pre;"}    |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 643px;">                         |
|                                      |                                      |
|                                      | `//  我们会发现输出为`{style="border: 0px no |
|                                      | ne rgb(0, 130, 0); color: rgb(0, 130 |
|                                      | , 0); display: inline; font-style: n |
|                                      | ormal; font-variant: normal; font-we |
|                                      | ight: normal; font-stretch: normal;  |
|                                      | font-size: 14px; font-family: Consol |
|                                      | as, "Bitstream Vera Sans Mono", "Cou |
|                                      | rier New", Courier, monospace; line- |
|                                      | height: 15.4px; margin: 0px; outline |
|                                      | : rgb(0, 130, 0) none 0px; padding:  |
|                                      | 0px; text-align: left; text-decorati |
|                                      | on: none; white-space: pre;"}        |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 643px;">                         |
|                                      |                                      |
|                                      | `//  是否含有特殊字符：0`{style="border: 0px  |
|                                      | none rgb(0, 130, 0); color: rgb(0, 1 |
|                                      | 30, 0); display: inline; font-style: |
|                                      |  normal; font-variant: normal; font- |
|                                      | weight: normal; font-stretch: normal |
|                                      | ; font-size: 14px; font-family: Cons |
|                                      | olas, "Bitstream Vera Sans Mono", "C |
|                                      | ourier New", Courier, monospace; lin |
|                                      | e-height: 15.4px; margin: 0px; outli |
|                                      | ne: rgb(0, 130, 0) none 0px; padding |
|                                      | : 0px; text-align: left; text-decora |
|                                      | tion: none; white-space: pre;"}      |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+

</div>

</div>

这总与我们的想法事与愿违，看到这里我们会发现谓词对正则并不像我们使用NSRegularExpression时匹配的那么好，究其原因是为什么呢？我们用NSRegularExpression时会发现匹配到一个结果时就会存入数组，再从匹配到的位置继续向下匹配。

然而NSPredicate并不会做这样的自动操作，我们最终发现在NSPredicate输入\[\`\~!@\#\$\^&\*()=|{}':;',\\\[\\\].&lt;&gt;/?\~！@\#￥……&\*（）——|{}【】‘；：”“'。，、？\]正则表达式时和写成\^\[\`\~!@\#\$\^&\*()=|{}':;',\\\[\\\].&lt;&gt;/?\~！@\#￥……&\*（）——|{}【】‘；：”“'。，、？\]\$的效果是一样的。

所以通过这个例子我们总结出来，只有在正则表达式为\^表达式\$时才使用谓词，而不是所有情况都使用。

那么我们是不是因为这一点就摒弃它了呢，答案是否定的。因为虽然NSPredicate有这么一点瑕疵，但是它总体带给我们的便利其实除了正则表达式匹配时的这个问题外是更多的。

<span
style="border: 0px none rgb(149, 55, 52); color: rgb(149, 55, 52); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; line-height: 28px; margin: 0px; outline: rgb(149, 55, 52) none 0px; padding: 0px; text-decoration: none;">2.使用谓词过滤集合</span>

此部分是我们需要掌握的重点，因为从这里我们就可以看到谓词的真正的强大之处

其实谓词本身就代表了一个逻辑条件，计算谓词之后返回的结果永远为BOOL类型的值。而谓词最常用的功能就是对集合进行过滤。当程序使用谓词对集合元素进行过滤时，程序会自动遍历其元素，并根据集合元素来计算谓词的值，当这个集合中的元素计算谓词并返回YES时，这个元素才会被保留下来。请注意程序会自动遍历其元素，它会将自动遍历过之后返回为YES的值重新组合成一个集合返回。

其实类似于我们使用tableView设置索引时使用的下段代码

<div
style="border: 0px none rgb(37, 37, 37); color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 60px; line-height: 28px; margin: 0px; outline: rgb(37, 37, 37) none 0px; padding: 0px; text-decoration: none; width: 720px;">

<div
style="background: none 0% 0% / auto repeat scroll padding-box border-box rgb(255, 255, 255); border: 0px none rgb(37, 37, 37); bottom: 0px; color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 60px; left: 0px; line-height: 28px; margin: 14px 0px; outline: rgb(37, 37, 37) none 0px; overflow: auto; padding: 0px; position: relative; right: 0px; text-decoration: none; top: 0px; width: 703px;">

+--------------------------------------+--------------------------------------+
| <div                                 | <div                                 |
| style="background: none 0% 0% / auto | style="border: 0px none rgb(37, 37,  |
|  repeat scroll padding-box border-bo | 37); bottom: 0px; color: rgb(37, 37, |
| x rgb(255, 255, 255); color: rgb(175 |  37); display: block; font-style: no |
| , 175, 175); display: block; font-st | rmal; font-variant: normal; font-wei |
| yle: normal; font-variant: normal; f | ght: normal; font-stretch: normal; f |
| ont-weight: normal; font-stretch: no | ont-size: 14px; font-family: Consola |
| rmal; font-size: 14px; font-family:  | s, &quot;Bitstream Vera Sans Mono&qu |
| Consolas, &quot;Bitstream Vera Sans  | ot;, &quot;Courier New&quot;, Courie |
| Mono&quot;, &quot;Courier New&quot;, | r, monospace; height: 60px; left: 0p |
|  Courier, monospace; height: 15px; l | x; line-height: 15.4px; margin: 0px; |
| ine-height: 15.4px; margin: 0px; out |  outline: rgb(37, 37, 37) none 0px;  |
| line: rgb(175, 175, 175) none 0px; p | padding: 0px; position: relative; ri |
| adding: 0px 7px 0px 14px; text-align | ght: 0px; text-align: left; text-dec |
| : right; text-decoration: none; whit | oration: none; top: 0px; width: 671p |
| e-space: pre; width: 8px;">          | x;">                                 |
|                                      |                                      |
| 1                                    | <div                                 |
|                                      | style="background: none 0% 0% / auto |
| </div>                               |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
| <div                                 | ne rgb(37, 37, 37); color: rgb(37, 3 |
| style="background: none 0% 0% / auto | 7, 37); display: block; font-style:  |
|  repeat scroll padding-box border-bo | normal; font-variant: normal; font-w |
| x rgb(255, 255, 255); color: rgb(175 | eight: normal; font-stretch: normal; |
| , 175, 175); display: block; font-st |  font-size: 14px; font-family: Conso |
| yle: normal; font-variant: normal; f | las, &quot;Bitstream Vera Sans Mono& |
| ont-weight: normal; font-stretch: no | quot;, &quot;Courier New&quot;, Cour |
| rmal; font-size: 14px; font-family:  | ier, monospace; height: 15px; line-h |
| Consolas, &quot;Bitstream Vera Sans  | eight: 15.4px; margin: 0px; outline: |
| Mono&quot;, &quot;Courier New&quot;, |  rgb(37, 37, 37) none 0px; padding:  |
|  Courier, monospace; height: 15px; l | 0px 14px; text-align: left; text-dec |
| ine-height: 15.4px; margin: 0px; out | oration: none; white-space: pre; wid |
| line: rgb(175, 175, 175) none 0px; p | th: 643px;">                         |
| adding: 0px 7px 0px 14px; text-align |                                      |
| : right; text-decoration: none; whit | `- (NSArray *)sectionIndexTitlesForT |
| e-space: pre; width: 8px;">          | ableView:(UITableView *)tableView`{s |
|                                      | tyle="display: inline; font-style: n |
| 2                                    | ormal; font-variant: normal; font-we |
|                                      | ight: normal; font-stretch: normal;  |
| </div>                               | font-size: 14px; font-family: Consol |
|                                      | as, "Bitstream Vera Sans Mono", "Cou |
| <div                                 | rier New", Courier, monospace; line- |
| style="background: none 0% 0% / auto | height: 15.4px; margin: 0px; padding |
|  repeat scroll padding-box border-bo | : 0px; text-align: left; text-decora |
| x rgb(255, 255, 255); color: rgb(175 | tion: none; white-space: pre;"}      |
| , 175, 175); display: block; font-st |                                      |
| yle: normal; font-variant: normal; f | </div>                               |
| ont-weight: normal; font-stretch: no |                                      |
| rmal; font-size: 14px; font-family:  | <div                                 |
| Consolas, &quot;Bitstream Vera Sans  | style="background: none 0% 0% / auto |
| Mono&quot;, &quot;Courier New&quot;, |  repeat scroll padding-box border-bo |
|  Courier, monospace; height: 15px; l | x rgb(255, 255, 255); border: 0px no |
| ine-height: 15.4px; margin: 0px; out | ne rgb(37, 37, 37); color: rgb(37, 3 |
| line: rgb(175, 175, 175) none 0px; p | 7, 37); display: block; font-style:  |
| adding: 0px 7px 0px 14px; text-align | normal; font-variant: normal; font-w |
| : right; text-decoration: none; whit | eight: normal; font-stretch: normal; |
| e-space: pre; width: 8px;">          |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
| 3                                    | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
| </div>                               | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
| <div                                 | 0px 14px; text-align: left; text-dec |
| style="background: none 0% 0% / auto | oration: none; white-space: pre; wid |
|  repeat scroll padding-box border-bo | th: 643px;">                         |
| x rgb(255, 255, 255); color: rgb(175 |                                      |
| , 175, 175); display: block; font-st | `{`{style="display: inline; font-sty |
| yle: normal; font-variant: normal; f | le: normal; font-variant: normal; fo |
| ont-weight: normal; font-stretch: no | nt-weight: normal; font-stretch: nor |
| rmal; font-size: 14px; font-family:  | mal; font-size: 14px; font-family: C |
| Consolas, &quot;Bitstream Vera Sans  | onsolas, "Bitstream Vera Sans Mono", |
| Mono&quot;, &quot;Courier New&quot;, |  "Courier New", Courier, monospace;  |
|  Courier, monospace; height: 15px; l | line-height: 15.4px; margin: 0px; pa |
| ine-height: 15.4px; margin: 0px; out | dding: 0px; text-align: left; text-d |
| line: rgb(175, 175, 175) none 0px; p | ecoration: none; white-space: pre;"} |
| adding: 0px 7px 0px 14px; text-align |                                      |
| : right; text-decoration: none; whit | </div>                               |
| e-space: pre; width: 8px;">          |                                      |
|                                      | <div                                 |
| 4                                    | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
| </div>                               | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 643px;">                         |
|                                      |                                      |
|                                      | `    `{style="border: 0px none rgb(3 |
|                                      | 7, 37, 37); color: rgb(37, 37, 37);  |
|                                      | display: inline; font-style: normal; |
|                                      |  font-variant: normal; font-weight:  |
|                                      | normal; font-stretch: normal; font-s |
|                                      | ize: 14px; font-family: Consolas, "B |
|                                      | itstream Vera Sans Mono", "Courier N |
|                                      | ew", Courier, monospace; line-height |
|                                      | : 15.4px; margin: 0px; outline: rgb( |
|                                      | 37, 37, 37) none 0px; padding: 0px;  |
|                                      | text-align: left; text-decoration: n |
|                                      | one; white-space: pre;"}`return`{sty |
|                                      | le="border: 0px none rgb(0, 102, 153 |
|                                      | ); color: rgb(0, 102, 153); display: |
|                                      |  inline; font-style: normal; font-va |
|                                      | riant: normal; font-weight: bold; fo |
|                                      | nt-stretch: normal; font-size: 14px; |
|                                      |  font-family: Consolas, "Bitstream V |
|                                      | era Sans Mono", "Courier New", Couri |
|                                      | er, monospace; line-height: 15.4px;  |
|                                      | margin: 0px; outline: rgb(0, 102, 15 |
|                                      | 3) none 0px; padding: 0px; text-alig |
|                                      | n: left; text-decoration: none; whit |
|                                      | e-space: pre;"} `[self.cityGroup val |
|                                      | ueForKey:@`{style="display: inline;  |
|                                      | font-style: normal; font-variant: no |
|                                      | rmal; font-weight: normal; font-stre |
|                                      | tch: normal; font-size: 14px; font-f |
|                                      | amily: Consolas, "Bitstream Vera San |
|                                      | s Mono", "Courier New", Courier, mon |
|                                      | ospace; line-height: 15.4px; margin: |
|                                      |  0px; padding: 0px; text-align: left |
|                                      | ; text-decoration: none; white-space |
|                                      | : pre;"}`"title"`{style="border: 0px |
|                                      |  none rgb(0, 0, 255); color: rgb(0,  |
|                                      | 0, 255); display: inline; font-style |
|                                      | : normal; font-variant: normal; font |
|                                      | -weight: normal; font-stretch: norma |
|                                      | l; font-size: 14px; font-family: Con |
|                                      | solas, "Bitstream Vera Sans Mono", " |
|                                      | Courier New", Courier, monospace; li |
|                                      | ne-height: 15.4px; margin: 0px; outl |
|                                      | ine: rgb(0, 0, 255) none 0px; paddin |
|                                      | g: 0px; text-align: left; text-decor |
|                                      | ation: none; white-space: pre;"}`];` |
|                                      | {style="display: inline; font-style: |
|                                      |  normal; font-variant: normal; font- |
|                                      | weight: normal; font-stretch: normal |
|                                      | ; font-size: 14px; font-family: Cons |
|                                      | olas, "Bitstream Vera Sans Mono", "C |
|                                      | ourier New", Courier, monospace; lin |
|                                      | e-height: 15.4px; margin: 0px; paddi |
|                                      | ng: 0px; text-align: left; text-deco |
|                                      | ration: none; white-space: pre;"}    |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 643px;">                         |
|                                      |                                      |
|                                      | `}`{style="display: inline; font-sty |
|                                      | le: normal; font-variant: normal; fo |
|                                      | nt-weight: normal; font-stretch: nor |
|                                      | mal; font-size: 14px; font-family: C |
|                                      | onsolas, "Bitstream Vera Sans Mono", |
|                                      |  "Courier New", Courier, monospace;  |
|                                      | line-height: 15.4px; margin: 0px; pa |
|                                      | dding: 0px; text-align: left; text-d |
|                                      | ecoration: none; white-space: pre;"} |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+

</div>

</div>

中的\[self.cityGroup
valueForKey:@"title"\]。它的作用是遍历所有title并将得到的值组成新的数组。

-   NSArray提供了如下方法使用谓词来过滤集合

- (NSArray\*)filteredArrayUsingPredicate:(NSPredicate
\*)predicate:使用指定的谓词过滤NSArray集合，返回符合条件的元素组成的新集合

-   NSMutableArray提供了如下方法使用谓词来过滤集合

- (void)filterUsingPredicate:(NSPredicate
\*)predicate：使用指定的谓词过滤NSMutableArray，剔除集合中不符合条件的元素

-   NSSet提供了如下方法使用谓词来过滤集合

- (NSSet\*)filteredSetUsingPredicate:(NSPredicate \*)predicate
NS\_AVAILABLE(10\_5, 3\_0)：作用同NSArray中的方法

-   NSMutableSet提供了如下方法使用谓词来过滤集合

- (void)filterUsingPredicate:(NSPredicate \*)predicate
NS\_AVAILABLE(10\_5, 3\_0)：作用同NSMutableArray中的方法。

通过上面的描述可以看出，使用谓词过滤不可变集合和可变集合的区别是：过滤不可变集合时，会返回符合条件的集合元素组成的新集合；过滤可变集合时，没有返回值，会直接剔除不符合条件的集合元素

下面让我们来看几个例子：

例一：

<div
style="border: 0px none rgb(37, 37, 37); color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 212px; line-height: 28px; margin: 0px; outline: rgb(37, 37, 37) none 0px; padding: 0px; text-decoration: none; width: 720px;">

<div
style="background: none 0% 0% / auto repeat scroll padding-box border-box rgb(255, 255, 255); border: 0px none rgb(37, 37, 37); bottom: 0px; color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 195px; left: 0px; line-height: 28px; margin: 14px 0px; outline: rgb(37, 37, 37) none 0px; overflow: auto; padding: 0px; position: relative; right: 0px; text-decoration: none; top: 0px; width: 703px;">

+--------------------------------------+--------------------------------------+
| <div                                 | <div                                 |
| style="background: none 0% 0% / auto | style="border: 0px none rgb(37, 37,  |
|  repeat scroll padding-box border-bo | 37); bottom: 0px; color: rgb(37, 37, |
| x rgb(255, 255, 255); color: rgb(175 |  37); display: block; font-style: no |
| , 175, 175); display: block; font-st | rmal; font-variant: normal; font-wei |
| yle: normal; font-variant: normal; f | ght: normal; font-stretch: normal; f |
| ont-weight: normal; font-stretch: no | ont-size: 14px; font-family: Consola |
| rmal; font-size: 14px; font-family:  | s, &quot;Bitstream Vera Sans Mono&qu |
| Consolas, &quot;Bitstream Vera Sans  | ot;, &quot;Courier New&quot;, Courie |
| Mono&quot;, &quot;Courier New&quot;, | r, monospace; height: 195px; left: 0 |
|  Courier, monospace; height: 15px; l | px; line-height: 15.4px; margin: 0px |
| ine-height: 15.4px; margin: 0px; out | ; outline: rgb(37, 37, 37) none 0px; |
| line: rgb(175, 175, 175) none 0px; p |  padding: 0px; position: relative; r |
| adding: 0px 7px 0px 14px; text-align | ight: 0px; text-align: left; text-de |
| : right; text-decoration: none; whit | coration: none; top: 0px; width: 744 |
| e-space: pre; width: 16px;">         | px;">                                |
|                                      |                                      |
| 1                                    | <div                                 |
|                                      | style="background: none 0% 0% / auto |
| </div>                               |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
| <div                                 | ne rgb(37, 37, 37); color: rgb(37, 3 |
| style="background: none 0% 0% / auto | 7, 37); display: block; font-style:  |
|  repeat scroll padding-box border-bo | normal; font-variant: normal; font-w |
| x rgb(255, 255, 255); color: rgb(175 | eight: normal; font-stretch: normal; |
| , 175, 175); display: block; font-st |  font-size: 14px; font-family: Conso |
| yle: normal; font-variant: normal; f | las, &quot;Bitstream Vera Sans Mono& |
| ont-weight: normal; font-stretch: no | quot;, &quot;Courier New&quot;, Cour |
| rmal; font-size: 14px; font-family:  | ier, monospace; height: 15px; line-h |
| Consolas, &quot;Bitstream Vera Sans  | eight: 15.4px; margin: 0px; outline: |
| Mono&quot;, &quot;Courier New&quot;, |  rgb(37, 37, 37) none 0px; padding:  |
|  Courier, monospace; height: 15px; l | 0px 14px; text-align: left; text-dec |
| ine-height: 15.4px; margin: 0px; out | oration: none; white-space: pre; wid |
| line: rgb(175, 175, 175) none 0px; p | th: 716px;">                         |
| adding: 0px 7px 0px 14px; text-align |                                      |
| : right; text-decoration: none; whit | `NSMutableArray *arrayM = [@[@20, @4 |
| e-space: pre; width: 16px;">         | 0, @50, @30, @60, @70] mutableCopy]; |
|                                      | `{style="display: inline; font-style |
| 2                                    | : normal; font-variant: normal; font |
|                                      | -weight: normal; font-stretch: norma |
| </div>                               | l; font-size: 14px; font-family: Con |
|                                      | solas, "Bitstream Vera Sans Mono", " |
| <div                                 | Courier New", Courier, monospace; li |
| style="background: none 0% 0% / auto | ne-height: 15.4px; margin: 0px; padd |
|  repeat scroll padding-box border-bo | ing: 0px; text-align: left; text-dec |
| x rgb(255, 255, 255); color: rgb(175 | oration: none; white-space: pre;"}   |
| , 175, 175); display: block; font-st |                                      |
| yle: normal; font-variant: normal; f | </div>                               |
| ont-weight: normal; font-stretch: no |                                      |
| rmal; font-size: 14px; font-family:  | <div                                 |
| Consolas, &quot;Bitstream Vera Sans  | style="background: none 0% 0% / auto |
| Mono&quot;, &quot;Courier New&quot;, |  repeat scroll padding-box border-bo |
|  Courier, monospace; height: 15px; l | x rgb(255, 255, 255); border: 0px no |
| ine-height: 15.4px; margin: 0px; out | ne rgb(37, 37, 37); color: rgb(37, 3 |
| line: rgb(175, 175, 175) none 0px; p | 7, 37); display: block; font-style:  |
| adding: 0px 7px 0px 14px; text-align | normal; font-variant: normal; font-w |
| : right; text-decoration: none; whit | eight: normal; font-stretch: normal; |
| e-space: pre; width: 16px;">         |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
| 3                                    | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
| </div>                               | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
| <div                                 | 0px 14px; text-align: left; text-dec |
| style="background: none 0% 0% / auto | oration: none; white-space: pre; wid |
|  repeat scroll padding-box border-bo | th: 716px;">                         |
| x rgb(255, 255, 255); color: rgb(175 |                                      |
| , 175, 175); display: block; font-st | `    `{style="border: 0px none rgb(3 |
| yle: normal; font-variant: normal; f | 7, 37, 37); color: rgb(37, 37, 37);  |
| ont-weight: normal; font-stretch: no | display: inline; font-style: normal; |
| rmal; font-size: 14px; font-family:  |  font-variant: normal; font-weight:  |
| Consolas, &quot;Bitstream Vera Sans  | normal; font-stretch: normal; font-s |
| Mono&quot;, &quot;Courier New&quot;, | ize: 14px; font-family: Consolas, "B |
|  Courier, monospace; height: 15px; l | itstream Vera Sans Mono", "Courier N |
| ine-height: 15.4px; margin: 0px; out | ew", Courier, monospace; line-height |
| line: rgb(175, 175, 175) none 0px; p | : 15.4px; margin: 0px; outline: rgb( |
| adding: 0px 7px 0px 14px; text-align | 37, 37, 37) none 0px; padding: 0px;  |
| : right; text-decoration: none; whit | text-align: left; text-decoration: n |
| e-space: pre; width: 16px;">         | one; white-space: pre;"}`//  过滤大于50的 |
|                                      | 值`{style="border: 0px none rgb(0, 13 |
| 4                                    | 0, 0); color: rgb(0, 130, 0); displa |
|                                      | y: inline; font-style: normal; font- |
| </div>                               | variant: normal; font-weight: normal |
|                                      | ; font-stretch: normal; font-size: 1 |
| <div                                 | 4px; font-family: Consolas, "Bitstre |
| style="background: none 0% 0% / auto | am Vera Sans Mono", "Courier New", C |
|  repeat scroll padding-box border-bo | ourier, monospace; line-height: 15.4 |
| x rgb(255, 255, 255); color: rgb(175 | px; margin: 0px; outline: rgb(0, 130 |
| , 175, 175); display: block; font-st | , 0) none 0px; padding: 0px; text-al |
| yle: normal; font-variant: normal; f | ign: left; text-decoration: none; wh |
| ont-weight: normal; font-stretch: no | ite-space: pre;"}                    |
| rmal; font-size: 14px; font-family:  |                                      |
| Consolas, &quot;Bitstream Vera Sans  | </div>                               |
| Mono&quot;, &quot;Courier New&quot;, |                                      |
|  Courier, monospace; height: 15px; l | <div                                 |
| ine-height: 15.4px; margin: 0px; out | style="background: none 0% 0% / auto |
| line: rgb(175, 175, 175) none 0px; p |  repeat scroll padding-box border-bo |
| adding: 0px 7px 0px 14px; text-align | x rgb(255, 255, 255); border: 0px no |
| : right; text-decoration: none; whit | ne rgb(37, 37, 37); color: rgb(37, 3 |
| e-space: pre; width: 16px;">         | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
| 5                                    | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
| </div>                               | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
| <div                                 | ier, monospace; height: 15px; line-h |
| style="background: none 0% 0% / auto | eight: 15.4px; margin: 0px; outline: |
|  repeat scroll padding-box border-bo |  rgb(37, 37, 37) none 0px; padding:  |
| x rgb(255, 255, 255); color: rgb(175 | 0px 14px; text-align: left; text-dec |
| , 175, 175); display: block; font-st | oration: none; white-space: pre; wid |
| yle: normal; font-variant: normal; f | th: 716px;">                         |
| ont-weight: normal; font-stretch: no |                                      |
| rmal; font-size: 14px; font-family:  | `    `{style="border: 0px none rgb(3 |
| Consolas, &quot;Bitstream Vera Sans  | 7, 37, 37); color: rgb(37, 37, 37);  |
| Mono&quot;, &quot;Courier New&quot;, | display: inline; font-style: normal; |
|  Courier, monospace; height: 15px; l |  font-variant: normal; font-weight:  |
| ine-height: 15.4px; margin: 0px; out | normal; font-stretch: normal; font-s |
| line: rgb(175, 175, 175) none 0px; p | ize: 14px; font-family: Consolas, "B |
| adding: 0px 7px 0px 14px; text-align | itstream Vera Sans Mono", "Courier N |
| : right; text-decoration: none; whit | ew", Courier, monospace; line-height |
| e-space: pre; width: 16px;">         | : 15.4px; margin: 0px; outline: rgb( |
|                                      | 37, 37, 37) none 0px; padding: 0px;  |
| 6                                    | text-align: left; text-decoration: n |
|                                      | one; white-space: pre;"}`NSPredicate |
| </div>                               |  *pred1 = [NSPredicate predicateWith |
|                                      | Format:@`{style="display: inline; fo |
| <div                                 | nt-style: normal; font-variant: norm |
| style="background: none 0% 0% / auto | al; font-weight: normal; font-stretc |
|  repeat scroll padding-box border-bo | h: normal; font-size: 14px; font-fam |
| x rgb(255, 255, 255); color: rgb(175 | ily: Consolas, "Bitstream Vera Sans  |
| , 175, 175); display: block; font-st | Mono", "Courier New", Courier, monos |
| yle: normal; font-variant: normal; f | pace; line-height: 15.4px; margin: 0 |
| ont-weight: normal; font-stretch: no | px; padding: 0px; text-align: left;  |
| rmal; font-size: 14px; font-family:  | text-decoration: none; white-space:  |
| Consolas, &quot;Bitstream Vera Sans  | pre;"}`"SELF > 50"`{style="border: 0 |
| Mono&quot;, &quot;Courier New&quot;, | px none rgb(0, 0, 255); color: rgb(0 |
|  Courier, monospace; height: 15px; l | , 0, 255); display: inline; font-sty |
| ine-height: 15.4px; margin: 0px; out | le: normal; font-variant: normal; fo |
| line: rgb(175, 175, 175) none 0px; p | nt-weight: normal; font-stretch: nor |
| adding: 0px 7px 0px 14px; text-align | mal; font-size: 14px; font-family: C |
| : right; text-decoration: none; whit | onsolas, "Bitstream Vera Sans Mono", |
| e-space: pre; width: 16px;">         |  "Courier New", Courier, monospace;  |
|                                      | line-height: 15.4px; margin: 0px; ou |
| 7                                    | tline: rgb(0, 0, 255) none 0px; padd |
|                                      | ing: 0px; text-align: left; text-dec |
| </div>                               | oration: none; white-space: pre;"}`] |
|                                      | ;`{style="display: inline; font-styl |
| <div                                 | e: normal; font-variant: normal; fon |
| style="background: none 0% 0% / auto | t-weight: normal; font-stretch: norm |
|  repeat scroll padding-box border-bo | al; font-size: 14px; font-family: Co |
| x rgb(255, 255, 255); color: rgb(175 | nsolas, "Bitstream Vera Sans Mono",  |
| , 175, 175); display: block; font-st | "Courier New", Courier, monospace; l |
| yle: normal; font-variant: normal; f | ine-height: 15.4px; margin: 0px; pad |
| ont-weight: normal; font-stretch: no | ding: 0px; text-align: left; text-de |
| rmal; font-size: 14px; font-family:  | coration: none; white-space: pre;"}  |
| Consolas, &quot;Bitstream Vera Sans  |                                      |
| Mono&quot;, &quot;Courier New&quot;, | </div>                               |
|  Courier, monospace; height: 15px; l |                                      |
| ine-height: 15.4px; margin: 0px; out | <div                                 |
| line: rgb(175, 175, 175) none 0px; p | style="background: none 0% 0% / auto |
| adding: 0px 7px 0px 14px; text-align |  repeat scroll padding-box border-bo |
| : right; text-decoration: none; whit | x rgb(255, 255, 255); border: 0px no |
| e-space: pre; width: 16px;">         | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
| 8                                    | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
| </div>                               |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
| <div                                 | quot;, &quot;Courier New&quot;, Cour |
| style="background: none 0% 0% / auto | ier, monospace; height: 15px; line-h |
|  repeat scroll padding-box border-bo | eight: 15.4px; margin: 0px; outline: |
| x rgb(255, 255, 255); color: rgb(175 |  rgb(37, 37, 37) none 0px; padding:  |
| , 175, 175); display: block; font-st | 0px 14px; text-align: left; text-dec |
| yle: normal; font-variant: normal; f | oration: none; white-space: pre; wid |
| ont-weight: normal; font-stretch: no | th: 716px;">                         |
| rmal; font-size: 14px; font-family:  |                                      |
| Consolas, &quot;Bitstream Vera Sans  | `    `{style="border: 0px none rgb(3 |
| Mono&quot;, &quot;Courier New&quot;, | 7, 37, 37); color: rgb(37, 37, 37);  |
|  Courier, monospace; height: 15px; l | display: inline; font-style: normal; |
| ine-height: 15.4px; margin: 0px; out |  font-variant: normal; font-weight:  |
| line: rgb(175, 175, 175) none 0px; p | normal; font-stretch: normal; font-s |
| adding: 0px 7px 0px 14px; text-align | ize: 14px; font-family: Consolas, "B |
| : right; text-decoration: none; whit | itstream Vera Sans Mono", "Courier N |
| e-space: pre; width: 16px;">         | ew", Courier, monospace; line-height |
|                                      | : 15.4px; margin: 0px; outline: rgb( |
| 9                                    | 37, 37, 37) none 0px; padding: 0px;  |
|                                      | text-align: left; text-decoration: n |
| </div>                               | one; white-space: pre;"}`[arrayM fil |
|                                      | terUsingPredicate:pred1];`{style="di |
| <div                                 | splay: inline; font-style: normal; f |
| style="background: none 0% 0% / auto | ont-variant: normal; font-weight: no |
|  repeat scroll padding-box border-bo | rmal; font-stretch: normal; font-siz |
| x rgb(255, 255, 255); color: rgb(175 | e: 14px; font-family: Consolas, "Bit |
| , 175, 175); display: block; font-st | stream Vera Sans Mono", "Courier New |
| yle: normal; font-variant: normal; f | ", Courier, monospace; line-height:  |
| ont-weight: normal; font-stretch: no | 15.4px; margin: 0px; padding: 0px; t |
| rmal; font-size: 14px; font-family:  | ext-align: left; text-decoration: no |
| Consolas, &quot;Bitstream Vera Sans  | ne; white-space: pre;"}              |
| Mono&quot;, &quot;Courier New&quot;, |                                      |
|  Courier, monospace; height: 15px; l | </div>                               |
| ine-height: 15.4px; margin: 0px; out |                                      |
| line: rgb(175, 175, 175) none 0px; p | <div                                 |
| adding: 0px 7px 0px 14px; text-align | style="background: none 0% 0% / auto |
| : right; text-decoration: none; whit |  repeat scroll padding-box border-bo |
| e-space: pre; width: 16px;">         | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
| 10                                   | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
| </div>                               | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
| <div                                 | las, &quot;Bitstream Vera Sans Mono& |
| style="background: none 0% 0% / auto | quot;, &quot;Courier New&quot;, Cour |
|  repeat scroll padding-box border-bo | ier, monospace; height: 15px; line-h |
| x rgb(255, 255, 255); color: rgb(175 | eight: 15.4px; margin: 0px; outline: |
| , 175, 175); display: block; font-st |  rgb(37, 37, 37) none 0px; padding:  |
| yle: normal; font-variant: normal; f | 0px 14px; text-align: left; text-dec |
| ont-weight: normal; font-stretch: no | oration: none; white-space: pre; wid |
| rmal; font-size: 14px; font-family:  | th: 716px;">                         |
| Consolas, &quot;Bitstream Vera Sans  |                                      |
| Mono&quot;, &quot;Courier New&quot;, | `    `{style="border: 0px none rgb(3 |
|  Courier, monospace; height: 15px; l | 7, 37, 37); color: rgb(37, 37, 37);  |
| ine-height: 15.4px; margin: 0px; out | display: inline; font-style: normal; |
| line: rgb(175, 175, 175) none 0px; p |  font-variant: normal; font-weight:  |
| adding: 0px 7px 0px 14px; text-align | normal; font-stretch: normal; font-s |
| : right; text-decoration: none; whit | ize: 14px; font-family: Consolas, "B |
| e-space: pre; width: 16px;">         | itstream Vera Sans Mono", "Courier N |
|                                      | ew", Courier, monospace; line-height |
| 11                                   | : 15.4px; margin: 0px; outline: rgb( |
|                                      | 37, 37, 37) none 0px; padding: 0px;  |
| </div>                               | text-align: left; text-decoration: n |
|                                      | one; white-space: pre;"}`NSLog(@`{st |
| <div                                 | yle="display: inline; font-style: no |
| style="background: none 0% 0% / auto | rmal; font-variant: normal; font-wei |
|  repeat scroll padding-box border-bo | ght: normal; font-stretch: normal; f |
| x rgb(255, 255, 255); color: rgb(175 | ont-size: 14px; font-family: Consola |
| , 175, 175); display: block; font-st | s, "Bitstream Vera Sans Mono", "Cour |
| yle: normal; font-variant: normal; f | ier New", Courier, monospace; line-h |
| ont-weight: normal; font-stretch: no | eight: 15.4px; margin: 0px; padding: |
| rmal; font-size: 14px; font-family:  |  0px; text-align: left; text-decorat |
| Consolas, &quot;Bitstream Vera Sans  | ion: none; white-space: pre;"}`"arra |
| Mono&quot;, &quot;Courier New&quot;, | yM:%@"`{style="border: 0px none rgb( |
|  Courier, monospace; height: 15px; l | 0, 0, 255); color: rgb(0, 0, 255); d |
| ine-height: 15.4px; margin: 0px; out | isplay: inline; font-style: normal;  |
| line: rgb(175, 175, 175) none 0px; p | font-variant: normal; font-weight: n |
| adding: 0px 7px 0px 14px; text-align | ormal; font-stretch: normal; font-si |
| : right; text-decoration: none; whit | ze: 14px; font-family: Consolas, "Bi |
| e-space: pre; width: 16px;">         | tstream Vera Sans Mono", "Courier Ne |
|                                      | w", Courier, monospace; line-height: |
| 12                                   |  15.4px; margin: 0px; outline: rgb(0 |
|                                      | , 0, 255) none 0px; padding: 0px; te |
| </div>                               | xt-align: left; text-decoration: non |
|                                      | e; white-space: pre;"}`, arrayM);`{s |
| <div                                 | tyle="display: inline; font-style: n |
| style="background: none 0% 0% / auto | ormal; font-variant: normal; font-we |
|  repeat scroll padding-box border-bo | ight: normal; font-stretch: normal;  |
| x rgb(255, 255, 255); color: rgb(175 | font-size: 14px; font-family: Consol |
| , 175, 175); display: block; font-st | as, "Bitstream Vera Sans Mono", "Cou |
| yle: normal; font-variant: normal; f | rier New", Courier, monospace; line- |
| ont-weight: normal; font-stretch: no | height: 15.4px; margin: 0px; padding |
| rmal; font-size: 14px; font-family:  | : 0px; text-align: left; text-decora |
| Consolas, &quot;Bitstream Vera Sans  | tion: none; white-space: pre;"}      |
| Mono&quot;, &quot;Courier New&quot;, |                                      |
|  Courier, monospace; height: 15px; l | </div>                               |
| ine-height: 15.4px; margin: 0px; out |                                      |
| line: rgb(175, 175, 175) none 0px; p | <div                                 |
| adding: 0px 7px 0px 14px; text-align | style="background: none 0% 0% / auto |
| : right; text-decoration: none; whit |  repeat scroll padding-box border-bo |
| e-space: pre; width: 16px;">         | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
| 13                                   | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
| </div>                               | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 716px;">                         |
|                                      |                                      |
|                                      | `    `{style="border: 0px none rgb(3 |
|                                      | 7, 37, 37); color: rgb(37, 37, 37);  |
|                                      | display: inline; font-style: normal; |
|                                      |  font-variant: normal; font-weight:  |
|                                      | normal; font-stretch: normal; font-s |
|                                      | ize: 14px; font-family: Consolas, "B |
|                                      | itstream Vera Sans Mono", "Courier N |
|                                      | ew", Courier, monospace; line-height |
|                                      | : 15.4px; margin: 0px; outline: rgb( |
|                                      | 37, 37, 37) none 0px; padding: 0px;  |
|                                      | text-align: left; text-decoration: n |
|                                      | one; white-space: pre;"}`NSArray *ar |
|                                      | ray = @[[ZLPersonModel personWithNam |
|                                      | e:@`{style="display: inline; font-st |
|                                      | yle: normal; font-variant: normal; f |
|                                      | ont-weight: normal; font-stretch: no |
|                                      | rmal; font-size: 14px; font-family:  |
|                                      | Consolas, "Bitstream Vera Sans Mono" |
|                                      | , "Courier New", Courier, monospace; |
|                                      |  line-height: 15.4px; margin: 0px; p |
|                                      | adding: 0px; text-align: left; text- |
|                                      | decoration: none; white-space: pre;" |
|                                      | }`"Jack"`{style="border: 0px none rg |
|                                      | b(0, 0, 255); color: rgb(0, 0, 255); |
|                                      |  display: inline; font-style: normal |
|                                      | ; font-variant: normal; font-weight: |
|                                      |  normal; font-stretch: normal; font- |
|                                      | size: 14px; font-family: Consolas, " |
|                                      | Bitstream Vera Sans Mono", "Courier  |
|                                      | New", Courier, monospace; line-heigh |
|                                      | t: 15.4px; margin: 0px; outline: rgb |
|                                      | (0, 0, 255) none 0px; padding: 0px;  |
|                                      | text-align: left; text-decoration: n |
|                                      | one; white-space: pre;"} `age:20 sex |
|                                      | :ZLPersonSexMale],`{style="display:  |
|                                      | inline; font-style: normal; font-var |
|                                      | iant: normal; font-weight: normal; f |
|                                      | ont-stretch: normal; font-size: 14px |
|                                      | ; font-family: Consolas, "Bitstream  |
|                                      | Vera Sans Mono", "Courier New", Cour |
|                                      | ier, monospace; line-height: 15.4px; |
|                                      |  margin: 0px; padding: 0px; text-ali |
|                                      | gn: left; text-decoration: none; whi |
|                                      | te-space: pre;"}                     |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 716px;">                         |
|                                      |                                      |
|                                      | `                       `{style="bor |
|                                      | der: 0px none rgb(37, 37, 37); color |
|                                      | : rgb(37, 37, 37); display: inline;  |
|                                      | font-style: normal; font-variant: no |
|                                      | rmal; font-weight: normal; font-stre |
|                                      | tch: normal; font-size: 14px; font-f |
|                                      | amily: Consolas, "Bitstream Vera San |
|                                      | s Mono", "Courier New", Courier, mon |
|                                      | ospace; line-height: 15.4px; margin: |
|                                      |  0px; outline: rgb(37, 37, 37) none  |
|                                      | 0px; padding: 0px; text-align: left; |
|                                      |  text-decoration: none; white-space: |
|                                      |  pre;"}`[ZLPersonModel personWithNam |
|                                      | e:@`{style="display: inline; font-st |
|                                      | yle: normal; font-variant: normal; f |
|                                      | ont-weight: normal; font-stretch: no |
|                                      | rmal; font-size: 14px; font-family:  |
|                                      | Consolas, "Bitstream Vera Sans Mono" |
|                                      | , "Courier New", Courier, monospace; |
|                                      |  line-height: 15.4px; margin: 0px; p |
|                                      | adding: 0px; text-align: left; text- |
|                                      | decoration: none; white-space: pre;" |
|                                      | }`"Rose"`{style="border: 0px none rg |
|                                      | b(0, 0, 255); color: rgb(0, 0, 255); |
|                                      |  display: inline; font-style: normal |
|                                      | ; font-variant: normal; font-weight: |
|                                      |  normal; font-stretch: normal; font- |
|                                      | size: 14px; font-family: Consolas, " |
|                                      | Bitstream Vera Sans Mono", "Courier  |
|                                      | New", Courier, monospace; line-heigh |
|                                      | t: 15.4px; margin: 0px; outline: rgb |
|                                      | (0, 0, 255) none 0px; padding: 0px;  |
|                                      | text-align: left; text-decoration: n |
|                                      | one; white-space: pre;"} `age:22 sex |
|                                      | :ZLPersonSexFamale],`{style="display |
|                                      | : inline; font-style: normal; font-v |
|                                      | ariant: normal; font-weight: normal; |
|                                      |  font-stretch: normal; font-size: 14 |
|                                      | px; font-family: Consolas, "Bitstrea |
|                                      | m Vera Sans Mono", "Courier New", Co |
|                                      | urier, monospace; line-height: 15.4p |
|                                      | x; margin: 0px; padding: 0px; text-a |
|                                      | lign: left; text-decoration: none; w |
|                                      | hite-space: pre;"}                   |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 716px;">                         |
|                                      |                                      |
|                                      | `                       `{style="bor |
|                                      | der: 0px none rgb(37, 37, 37); color |
|                                      | : rgb(37, 37, 37); display: inline;  |
|                                      | font-style: normal; font-variant: no |
|                                      | rmal; font-weight: normal; font-stre |
|                                      | tch: normal; font-size: 14px; font-f |
|                                      | amily: Consolas, "Bitstream Vera San |
|                                      | s Mono", "Courier New", Courier, mon |
|                                      | ospace; line-height: 15.4px; margin: |
|                                      |  0px; outline: rgb(37, 37, 37) none  |
|                                      | 0px; padding: 0px; text-align: left; |
|                                      |  text-decoration: none; white-space: |
|                                      |  pre;"}`[ZLPersonModel personWithNam |
|                                      | e:@`{style="display: inline; font-st |
|                                      | yle: normal; font-variant: normal; f |
|                                      | ont-weight: normal; font-stretch: no |
|                                      | rmal; font-size: 14px; font-family:  |
|                                      | Consolas, "Bitstream Vera Sans Mono" |
|                                      | , "Courier New", Courier, monospace; |
|                                      |  line-height: 15.4px; margin: 0px; p |
|                                      | adding: 0px; text-align: left; text- |
|                                      | decoration: none; white-space: pre;" |
|                                      | }`"Jackson"`{style="border: 0px none |
|                                      |  rgb(0, 0, 255); color: rgb(0, 0, 25 |
|                                      | 5); display: inline; font-style: nor |
|                                      | mal; font-variant: normal; font-weig |
|                                      | ht: normal; font-stretch: normal; fo |
|                                      | nt-size: 14px; font-family: Consolas |
|                                      | , "Bitstream Vera Sans Mono", "Couri |
|                                      | er New", Courier, monospace; line-he |
|                                      | ight: 15.4px; margin: 0px; outline:  |
|                                      | rgb(0, 0, 255) none 0px; padding: 0p |
|                                      | x; text-align: left; text-decoration |
|                                      | : none; white-space: pre;"} `age:30  |
|                                      | sex:ZLPersonSexMale],`{style="displa |
|                                      | y: inline; font-style: normal; font- |
|                                      | variant: normal; font-weight: normal |
|                                      | ; font-stretch: normal; font-size: 1 |
|                                      | 4px; font-family: Consolas, "Bitstre |
|                                      | am Vera Sans Mono", "Courier New", C |
|                                      | ourier, monospace; line-height: 15.4 |
|                                      | px; margin: 0px; padding: 0px; text- |
|                                      | align: left; text-decoration: none;  |
|                                      | white-space: pre;"}                  |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 716px;">                         |
|                                      |                                      |
|                                      | `                       `{style="bor |
|                                      | der: 0px none rgb(37, 37, 37); color |
|                                      | : rgb(37, 37, 37); display: inline;  |
|                                      | font-style: normal; font-variant: no |
|                                      | rmal; font-weight: normal; font-stre |
|                                      | tch: normal; font-size: 14px; font-f |
|                                      | amily: Consolas, "Bitstream Vera San |
|                                      | s Mono", "Courier New", Courier, mon |
|                                      | ospace; line-height: 15.4px; margin: |
|                                      |  0px; outline: rgb(37, 37, 37) none  |
|                                      | 0px; padding: 0px; text-align: left; |
|                                      |  text-decoration: none; white-space: |
|                                      |  pre;"}`[ZLPersonModel personWithNam |
|                                      | e:@`{style="display: inline; font-st |
|                                      | yle: normal; font-variant: normal; f |
|                                      | ont-weight: normal; font-stretch: no |
|                                      | rmal; font-size: 14px; font-family:  |
|                                      | Consolas, "Bitstream Vera Sans Mono" |
|                                      | , "Courier New", Courier, monospace; |
|                                      |  line-height: 15.4px; margin: 0px; p |
|                                      | adding: 0px; text-align: left; text- |
|                                      | decoration: none; white-space: pre;" |
|                                      | }`"Johnson"`{style="border: 0px none |
|                                      |  rgb(0, 0, 255); color: rgb(0, 0, 25 |
|                                      | 5); display: inline; font-style: nor |
|                                      | mal; font-variant: normal; font-weig |
|                                      | ht: normal; font-stretch: normal; fo |
|                                      | nt-size: 14px; font-family: Consolas |
|                                      | , "Bitstream Vera Sans Mono", "Couri |
|                                      | er New", Courier, monospace; line-he |
|                                      | ight: 15.4px; margin: 0px; outline:  |
|                                      | rgb(0, 0, 255) none 0px; padding: 0p |
|                                      | x; text-align: left; text-decoration |
|                                      | : none; white-space: pre;"} `age:35  |
|                                      | sex:ZLPersonSexMale]];`{style="displ |
|                                      | ay: inline; font-style: normal; font |
|                                      | -variant: normal; font-weight: norma |
|                                      | l; font-stretch: normal; font-size:  |
|                                      | 14px; font-family: Consolas, "Bitstr |
|                                      | eam Vera Sans Mono", "Courier New",  |
|                                      | Courier, monospace; line-height: 15. |
|                                      | 4px; margin: 0px; padding: 0px; text |
|                                      | -align: left; text-decoration: none; |
|                                      |  white-space: pre;"}                 |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 716px;">                         |
|                                      |                                      |
|                                      | `    `{style="border: 0px none rgb(3 |
|                                      | 7, 37, 37); color: rgb(37, 37, 37);  |
|                                      | display: inline; font-style: normal; |
|                                      |  font-variant: normal; font-weight:  |
|                                      | normal; font-stretch: normal; font-s |
|                                      | ize: 14px; font-family: Consolas, "B |
|                                      | itstream Vera Sans Mono", "Courier N |
|                                      | ew", Courier, monospace; line-height |
|                                      | : 15.4px; margin: 0px; outline: rgb( |
|                                      | 37, 37, 37) none 0px; padding: 0px;  |
|                                      | text-align: left; text-decoration: n |
|                                      | one; white-space: pre;"}`//  要求取出包含‘ |
|                                      | son’的元素`{style="border: 0px none rgb |
|                                      | (0, 130, 0); color: rgb(0, 130, 0);  |
|                                      | display: inline; font-style: normal; |
|                                      |  font-variant: normal; font-weight:  |
|                                      | normal; font-stretch: normal; font-s |
|                                      | ize: 14px; font-family: Consolas, "B |
|                                      | itstream Vera Sans Mono", "Courier N |
|                                      | ew", Courier, monospace; line-height |
|                                      | : 15.4px; margin: 0px; outline: rgb( |
|                                      | 0, 130, 0) none 0px; padding: 0px; t |
|                                      | ext-align: left; text-decoration: no |
|                                      | ne; white-space: pre;"}              |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 716px;">                         |
|                                      |                                      |
|                                      | `    `{style="border: 0px none rgb(3 |
|                                      | 7, 37, 37); color: rgb(37, 37, 37);  |
|                                      | display: inline; font-style: normal; |
|                                      |  font-variant: normal; font-weight:  |
|                                      | normal; font-stretch: normal; font-s |
|                                      | ize: 14px; font-family: Consolas, "B |
|                                      | itstream Vera Sans Mono", "Courier N |
|                                      | ew", Courier, monospace; line-height |
|                                      | : 15.4px; margin: 0px; outline: rgb( |
|                                      | 37, 37, 37) none 0px; padding: 0px;  |
|                                      | text-align: left; text-decoration: n |
|                                      | one; white-space: pre;"}`NSPredicate |
|                                      |  *pred2 = [NSPredicate predicateWith |
|                                      | Format:@`{style="display: inline; fo |
|                                      | nt-style: normal; font-variant: norm |
|                                      | al; font-weight: normal; font-stretc |
|                                      | h: normal; font-size: 14px; font-fam |
|                                      | ily: Consolas, "Bitstream Vera Sans  |
|                                      | Mono", "Courier New", Courier, monos |
|                                      | pace; line-height: 15.4px; margin: 0 |
|                                      | px; padding: 0px; text-align: left;  |
|                                      | text-decoration: none; white-space:  |
|                                      | pre;"}`"name CONTAINS 'son'"`{style= |
|                                      | "border: 0px none rgb(0, 0, 255); co |
|                                      | lor: rgb(0, 0, 255); display: inline |
|                                      | ; font-style: normal; font-variant:  |
|                                      | normal; font-weight: normal; font-st |
|                                      | retch: normal; font-size: 14px; font |
|                                      | -family: Consolas, "Bitstream Vera S |
|                                      | ans Mono", "Courier New", Courier, m |
|                                      | onospace; line-height: 15.4px; margi |
|                                      | n: 0px; outline: rgb(0, 0, 255) none |
|                                      |  0px; padding: 0px; text-align: left |
|                                      | ; text-decoration: none; white-space |
|                                      | : pre;"}`];`{style="display: inline; |
|                                      |  font-style: normal; font-variant: n |
|                                      | ormal; font-weight: normal; font-str |
|                                      | etch: normal; font-size: 14px; font- |
|                                      | family: Consolas, "Bitstream Vera Sa |
|                                      | ns Mono", "Courier New", Courier, mo |
|                                      | nospace; line-height: 15.4px; margin |
|                                      | : 0px; padding: 0px; text-align: lef |
|                                      | t; text-decoration: none; white-spac |
|                                      | e: pre;"}                            |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 716px;">                         |
|                                      |                                      |
|                                      | `    `{style="border: 0px none rgb(3 |
|                                      | 7, 37, 37); color: rgb(37, 37, 37);  |
|                                      | display: inline; font-style: normal; |
|                                      |  font-variant: normal; font-weight:  |
|                                      | normal; font-stretch: normal; font-s |
|                                      | ize: 14px; font-family: Consolas, "B |
|                                      | itstream Vera Sans Mono", "Courier N |
|                                      | ew", Courier, monospace; line-height |
|                                      | : 15.4px; margin: 0px; outline: rgb( |
|                                      | 37, 37, 37) none 0px; padding: 0px;  |
|                                      | text-align: left; text-decoration: n |
|                                      | one; white-space: pre;"}`NSArray *ne |
|                                      | wArray = [array filteredArrayUsingPr |
|                                      | edicate:pred2];`{style="display: inl |
|                                      | ine; font-style: normal; font-varian |
|                                      | t: normal; font-weight: normal; font |
|                                      | -stretch: normal; font-size: 14px; f |
|                                      | ont-family: Consolas, "Bitstream Ver |
|                                      | a Sans Mono", "Courier New", Courier |
|                                      | , monospace; line-height: 15.4px; ma |
|                                      | rgin: 0px; padding: 0px; text-align: |
|                                      |  left; text-decoration: none; white- |
|                                      | space: pre;"}                        |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 716px;">                         |
|                                      |                                      |
|                                      | `    `{style="border: 0px none rgb(3 |
|                                      | 7, 37, 37); color: rgb(37, 37, 37);  |
|                                      | display: inline; font-style: normal; |
|                                      |  font-variant: normal; font-weight:  |
|                                      | normal; font-stretch: normal; font-s |
|                                      | ize: 14px; font-family: Consolas, "B |
|                                      | itstream Vera Sans Mono", "Courier N |
|                                      | ew", Courier, monospace; line-height |
|                                      | : 15.4px; margin: 0px; outline: rgb( |
|                                      | 37, 37, 37) none 0px; padding: 0px;  |
|                                      | text-align: left; text-decoration: n |
|                                      | one; white-space: pre;"}`NSLog(@`{st |
|                                      | yle="display: inline; font-style: no |
|                                      | rmal; font-variant: normal; font-wei |
|                                      | ght: normal; font-stretch: normal; f |
|                                      | ont-size: 14px; font-family: Consola |
|                                      | s, "Bitstream Vera Sans Mono", "Cour |
|                                      | ier New", Courier, monospace; line-h |
|                                      | eight: 15.4px; margin: 0px; padding: |
|                                      |  0px; text-align: left; text-decorat |
|                                      | ion: none; white-space: pre;"}`"%@"` |
|                                      | {style="border: 0px none rgb(0, 0, 2 |
|                                      | 55); color: rgb(0, 0, 255); display: |
|                                      |  inline; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, "Bitstream |
|                                      |  Vera Sans Mono", "Courier New", Cou |
|                                      | rier, monospace; line-height: 15.4px |
|                                      | ; margin: 0px; outline: rgb(0, 0, 25 |
|                                      | 5) none 0px; padding: 0px; text-alig |
|                                      | n: left; text-decoration: none; whit |
|                                      | e-space: pre;"}`, newArray);`{style= |
|                                      | "display: inline; font-style: normal |
|                                      | ; font-variant: normal; font-weight: |
|                                      |  normal; font-stretch: normal; font- |
|                                      | size: 14px; font-family: Consolas, " |
|                                      | Bitstream Vera Sans Mono", "Courier  |
|                                      | New", Courier, monospace; line-heigh |
|                                      | t: 15.4px; margin: 0px; padding: 0px |
|                                      | ; text-align: left; text-decoration: |
|                                      |  none; white-space: pre;"}           |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+

</div>

</div>

输出为

<div
style="border: 0px none rgb(37, 37, 37); color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 120px; line-height: 28px; margin: 0px; outline: rgb(37, 37, 37) none 0px; padding: 0px; text-decoration: none; width: 720px;">

<div
style="background: none 0% 0% / auto repeat scroll padding-box border-box rgb(255, 255, 255); border: 0px none rgb(37, 37, 37); bottom: 0px; color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 120px; left: 0px; line-height: 28px; margin: 14px 0px; outline: rgb(37, 37, 37) none 0px; overflow: auto; padding: 0px; position: relative; right: 0px; text-decoration: none; top: 0px; width: 703px;">

+--------------------------------------+--------------------------------------+
| <div                                 | <div                                 |
| style="background: none 0% 0% / auto | style="border: 0px none rgb(37, 37,  |
|  repeat scroll padding-box border-bo | 37); bottom: 0px; color: rgb(37, 37, |
| x rgb(255, 255, 255); color: rgb(175 |  37); display: block; font-style: no |
| , 175, 175); display: block; font-st | rmal; font-variant: normal; font-wei |
| yle: normal; font-variant: normal; f | ght: normal; font-stretch: normal; f |
| ont-weight: normal; font-stretch: no | ont-size: 14px; font-family: Consola |
| rmal; font-size: 14px; font-family:  | s, &quot;Bitstream Vera Sans Mono&qu |
| Consolas, &quot;Bitstream Vera Sans  | ot;, &quot;Courier New&quot;, Courie |
| Mono&quot;, &quot;Courier New&quot;, | r, monospace; height: 120px; left: 0 |
|  Courier, monospace; height: 15px; l | px; line-height: 15.4px; margin: 0px |
| ine-height: 15.4px; margin: 0px; out | ; outline: rgb(37, 37, 37) none 0px; |
| line: rgb(175, 175, 175) none 0px; p |  padding: 0px; position: relative; r |
| adding: 0px 7px 0px 14px; text-align | ight: 0px; text-align: left; text-de |
| : right; text-decoration: none; whit | coration: none; top: 0px; width: 671 |
| e-space: pre; width: 8px;">          | px;">                                |
|                                      |                                      |
| 1                                    | <div                                 |
|                                      | style="background: none 0% 0% / auto |
| </div>                               |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
| <div                                 | ne rgb(37, 37, 37); color: rgb(37, 3 |
| style="background: none 0% 0% / auto | 7, 37); display: block; font-style:  |
|  repeat scroll padding-box border-bo | normal; font-variant: normal; font-w |
| x rgb(255, 255, 255); color: rgb(175 | eight: normal; font-stretch: normal; |
| , 175, 175); display: block; font-st |  font-size: 14px; font-family: Conso |
| yle: normal; font-variant: normal; f | las, &quot;Bitstream Vera Sans Mono& |
| ont-weight: normal; font-stretch: no | quot;, &quot;Courier New&quot;, Cour |
| rmal; font-size: 14px; font-family:  | ier, monospace; height: 15px; line-h |
| Consolas, &quot;Bitstream Vera Sans  | eight: 15.4px; margin: 0px; outline: |
| Mono&quot;, &quot;Courier New&quot;, |  rgb(37, 37, 37) none 0px; padding:  |
|  Courier, monospace; height: 15px; l | 0px 14px; text-align: left; text-dec |
| ine-height: 15.4px; margin: 0px; out | oration: none; white-space: pre; wid |
| line: rgb(175, 175, 175) none 0px; p | th: 643px;">                         |
| adding: 0px 7px 0px 14px; text-align |                                      |
| : right; text-decoration: none; whit | `2016-01-07 16:50:09.510 PredicteDem |
| e-space: pre; width: 8px;">          | o[13660:293822] arrayM:(`{style="dis |
|                                      | play: inline; font-style: normal; fo |
| 2                                    | nt-variant: normal; font-weight: nor |
|                                      | mal; font-stretch: normal; font-size |
| </div>                               | : 14px; font-family: Consolas, "Bits |
|                                      | tream Vera Sans Mono", "Courier New" |
| <div                                 | , Courier, monospace; line-height: 1 |
| style="background: none 0% 0% / auto | 5.4px; margin: 0px; padding: 0px; te |
|  repeat scroll padding-box border-bo | xt-align: left; text-decoration: non |
| x rgb(255, 255, 255); color: rgb(175 | e; white-space: pre;"}               |
| , 175, 175); display: block; font-st |                                      |
| yle: normal; font-variant: normal; f | </div>                               |
| ont-weight: normal; font-stretch: no |                                      |
| rmal; font-size: 14px; font-family:  | <div                                 |
| Consolas, &quot;Bitstream Vera Sans  | style="background: none 0% 0% / auto |
| Mono&quot;, &quot;Courier New&quot;, |  repeat scroll padding-box border-bo |
|  Courier, monospace; height: 15px; l | x rgb(255, 255, 255); border: 0px no |
| ine-height: 15.4px; margin: 0px; out | ne rgb(37, 37, 37); color: rgb(37, 3 |
| line: rgb(175, 175, 175) none 0px; p | 7, 37); display: block; font-style:  |
| adding: 0px 7px 0px 14px; text-align | normal; font-variant: normal; font-w |
| : right; text-decoration: none; whit | eight: normal; font-stretch: normal; |
| e-space: pre; width: 8px;">          |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
| 3                                    | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
| </div>                               | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
| <div                                 | 0px 14px; text-align: left; text-dec |
| style="background: none 0% 0% / auto | oration: none; white-space: pre; wid |
|  repeat scroll padding-box border-bo | th: 643px;">                         |
| x rgb(255, 255, 255); color: rgb(175 |                                      |
| , 175, 175); display: block; font-st | `    `{style="border: 0px none rgb(3 |
| yle: normal; font-variant: normal; f | 7, 37, 37); color: rgb(37, 37, 37);  |
| ont-weight: normal; font-stretch: no | display: inline; font-style: normal; |
| rmal; font-size: 14px; font-family:  |  font-variant: normal; font-weight:  |
| Consolas, &quot;Bitstream Vera Sans  | normal; font-stretch: normal; font-s |
| Mono&quot;, &quot;Courier New&quot;, | ize: 14px; font-family: Consolas, "B |
|  Courier, monospace; height: 15px; l | itstream Vera Sans Mono", "Courier N |
| ine-height: 15.4px; margin: 0px; out | ew", Courier, monospace; line-height |
| line: rgb(175, 175, 175) none 0px; p | : 15.4px; margin: 0px; outline: rgb( |
| adding: 0px 7px 0px 14px; text-align | 37, 37, 37) none 0px; padding: 0px;  |
| : right; text-decoration: none; whit | text-align: left; text-decoration: n |
| e-space: pre; width: 8px;">          | one; white-space: pre;"}`60,`{style= |
|                                      | "display: inline; font-style: normal |
| 4                                    | ; font-variant: normal; font-weight: |
|                                      |  normal; font-stretch: normal; font- |
| </div>                               | size: 14px; font-family: Consolas, " |
|                                      | Bitstream Vera Sans Mono", "Courier  |
| <div                                 | New", Courier, monospace; line-heigh |
| style="background: none 0% 0% / auto | t: 15.4px; margin: 0px; padding: 0px |
|  repeat scroll padding-box border-bo | ; text-align: left; text-decoration: |
| x rgb(255, 255, 255); color: rgb(175 |  none; white-space: pre;"}           |
| , 175, 175); display: block; font-st |                                      |
| yle: normal; font-variant: normal; f | </div>                               |
| ont-weight: normal; font-stretch: no |                                      |
| rmal; font-size: 14px; font-family:  | <div                                 |
| Consolas, &quot;Bitstream Vera Sans  | style="background: none 0% 0% / auto |
| Mono&quot;, &quot;Courier New&quot;, |  repeat scroll padding-box border-bo |
|  Courier, monospace; height: 15px; l | x rgb(255, 255, 255); border: 0px no |
| ine-height: 15.4px; margin: 0px; out | ne rgb(37, 37, 37); color: rgb(37, 3 |
| line: rgb(175, 175, 175) none 0px; p | 7, 37); display: block; font-style:  |
| adding: 0px 7px 0px 14px; text-align | normal; font-variant: normal; font-w |
| : right; text-decoration: none; whit | eight: normal; font-stretch: normal; |
| e-space: pre; width: 8px;">          |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
| 5                                    | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
| </div>                               | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
| <div                                 | 0px 14px; text-align: left; text-dec |
| style="background: none 0% 0% / auto | oration: none; white-space: pre; wid |
|  repeat scroll padding-box border-bo | th: 643px;">                         |
| x rgb(255, 255, 255); color: rgb(175 |                                      |
| , 175, 175); display: block; font-st | `    `{style="border: 0px none rgb(3 |
| yle: normal; font-variant: normal; f | 7, 37, 37); color: rgb(37, 37, 37);  |
| ont-weight: normal; font-stretch: no | display: inline; font-style: normal; |
| rmal; font-size: 14px; font-family:  |  font-variant: normal; font-weight:  |
| Consolas, &quot;Bitstream Vera Sans  | normal; font-stretch: normal; font-s |
| Mono&quot;, &quot;Courier New&quot;, | ize: 14px; font-family: Consolas, "B |
|  Courier, monospace; height: 15px; l | itstream Vera Sans Mono", "Courier N |
| ine-height: 15.4px; margin: 0px; out | ew", Courier, monospace; line-height |
| line: rgb(175, 175, 175) none 0px; p | : 15.4px; margin: 0px; outline: rgb( |
| adding: 0px 7px 0px 14px; text-align | 37, 37, 37) none 0px; padding: 0px;  |
| : right; text-decoration: none; whit | text-align: left; text-decoration: n |
| e-space: pre; width: 8px;">          | one; white-space: pre;"}`70`{style=" |
|                                      | display: inline; font-style: normal; |
| 6                                    |  font-variant: normal; font-weight:  |
|                                      | normal; font-stretch: normal; font-s |
| </div>                               | ize: 14px; font-family: Consolas, "B |
|                                      | itstream Vera Sans Mono", "Courier N |
| <div                                 | ew", Courier, monospace; line-height |
| style="background: none 0% 0% / auto | : 15.4px; margin: 0px; padding: 0px; |
|  repeat scroll padding-box border-bo |  text-align: left; text-decoration:  |
| x rgb(255, 255, 255); color: rgb(175 | none; white-space: pre;"}            |
| , 175, 175); display: block; font-st |                                      |
| yle: normal; font-variant: normal; f | </div>                               |
| ont-weight: normal; font-stretch: no |                                      |
| rmal; font-size: 14px; font-family:  | <div                                 |
| Consolas, &quot;Bitstream Vera Sans  | style="background: none 0% 0% / auto |
| Mono&quot;, &quot;Courier New&quot;, |  repeat scroll padding-box border-bo |
|  Courier, monospace; height: 15px; l | x rgb(255, 255, 255); border: 0px no |
| ine-height: 15.4px; margin: 0px; out | ne rgb(37, 37, 37); color: rgb(37, 3 |
| line: rgb(175, 175, 175) none 0px; p | 7, 37); display: block; font-style:  |
| adding: 0px 7px 0px 14px; text-align | normal; font-variant: normal; font-w |
| : right; text-decoration: none; whit | eight: normal; font-stretch: normal; |
| e-space: pre; width: 8px;">          |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
| 7                                    | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
| </div>                               | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
| <div                                 | 0px 14px; text-align: left; text-dec |
| style="background: none 0% 0% / auto | oration: none; white-space: pre; wid |
|  repeat scroll padding-box border-bo | th: 643px;">                         |
| x rgb(255, 255, 255); color: rgb(175 |                                      |
| , 175, 175); display: block; font-st | `)`{style="display: inline; font-sty |
| yle: normal; font-variant: normal; f | le: normal; font-variant: normal; fo |
| ont-weight: normal; font-stretch: no | nt-weight: normal; font-stretch: nor |
| rmal; font-size: 14px; font-family:  | mal; font-size: 14px; font-family: C |
| Consolas, &quot;Bitstream Vera Sans  | onsolas, "Bitstream Vera Sans Mono", |
| Mono&quot;, &quot;Courier New&quot;, |  "Courier New", Courier, monospace;  |
|  Courier, monospace; height: 15px; l | line-height: 15.4px; margin: 0px; pa |
| ine-height: 15.4px; margin: 0px; out | dding: 0px; text-align: left; text-d |
| line: rgb(175, 175, 175) none 0px; p | ecoration: none; white-space: pre;"} |
| adding: 0px 7px 0px 14px; text-align |                                      |
| : right; text-decoration: none; whit | </div>                               |
| e-space: pre; width: 8px;">          |                                      |
|                                      | <div                                 |
| 8                                    | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
| </div>                               | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 643px;">                         |
|                                      |                                      |
|                                      | `2016-01-07 16:50:09.511 PredicteDem |
|                                      | o[13660:293822] (`{style="display: i |
|                                      | nline; font-style: normal; font-vari |
|                                      | ant: normal; font-weight: normal; fo |
|                                      | nt-stretch: normal; font-size: 14px; |
|                                      |  font-family: Consolas, "Bitstream V |
|                                      | era Sans Mono", "Courier New", Couri |
|                                      | er, monospace; line-height: 15.4px;  |
|                                      | margin: 0px; padding: 0px; text-alig |
|                                      | n: left; text-decoration: none; whit |
|                                      | e-space: pre;"}                      |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 643px;">                         |
|                                      |                                      |
|                                      | `    `{style="border: 0px none rgb(3 |
|                                      | 7, 37, 37); color: rgb(37, 37, 37);  |
|                                      | display: inline; font-style: normal; |
|                                      |  font-variant: normal; font-weight:  |
|                                      | normal; font-stretch: normal; font-s |
|                                      | ize: 14px; font-family: Consolas, "B |
|                                      | itstream Vera Sans Mono", "Courier N |
|                                      | ew", Courier, monospace; line-height |
|                                      | : 15.4px; margin: 0px; outline: rgb( |
|                                      | 37, 37, 37) none 0px; padding: 0px;  |
|                                      | text-align: left; text-decoration: n |
|                                      | one; white-space: pre;"}`"[name = Ja |
|                                      | ckson, age = 30, sex = 0]"`{style="b |
|                                      | order: 0px none rgb(0, 0, 255); colo |
|                                      | r: rgb(0, 0, 255); display: inline;  |
|                                      | font-style: normal; font-variant: no |
|                                      | rmal; font-weight: normal; font-stre |
|                                      | tch: normal; font-size: 14px; font-f |
|                                      | amily: Consolas, "Bitstream Vera San |
|                                      | s Mono", "Courier New", Courier, mon |
|                                      | ospace; line-height: 15.4px; margin: |
|                                      |  0px; outline: rgb(0, 0, 255) none 0 |
|                                      | px; padding: 0px; text-align: left;  |
|                                      | text-decoration: none; white-space:  |
|                                      | pre;"}`,`{style="display: inline; fo |
|                                      | nt-style: normal; font-variant: norm |
|                                      | al; font-weight: normal; font-stretc |
|                                      | h: normal; font-size: 14px; font-fam |
|                                      | ily: Consolas, "Bitstream Vera Sans  |
|                                      | Mono", "Courier New", Courier, monos |
|                                      | pace; line-height: 15.4px; margin: 0 |
|                                      | px; padding: 0px; text-align: left;  |
|                                      | text-decoration: none; white-space:  |
|                                      | pre;"}                               |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 643px;">                         |
|                                      |                                      |
|                                      | `    `{style="border: 0px none rgb(3 |
|                                      | 7, 37, 37); color: rgb(37, 37, 37);  |
|                                      | display: inline; font-style: normal; |
|                                      |  font-variant: normal; font-weight:  |
|                                      | normal; font-stretch: normal; font-s |
|                                      | ize: 14px; font-family: Consolas, "B |
|                                      | itstream Vera Sans Mono", "Courier N |
|                                      | ew", Courier, monospace; line-height |
|                                      | : 15.4px; margin: 0px; outline: rgb( |
|                                      | 37, 37, 37) none 0px; padding: 0px;  |
|                                      | text-align: left; text-decoration: n |
|                                      | one; white-space: pre;"}`"[name = Jo |
|                                      | hnson, age = 35, sex = 0]"`{style="b |
|                                      | order: 0px none rgb(0, 0, 255); colo |
|                                      | r: rgb(0, 0, 255); display: inline;  |
|                                      | font-style: normal; font-variant: no |
|                                      | rmal; font-weight: normal; font-stre |
|                                      | tch: normal; font-size: 14px; font-f |
|                                      | amily: Consolas, "Bitstream Vera San |
|                                      | s Mono", "Courier New", Courier, mon |
|                                      | ospace; line-height: 15.4px; margin: |
|                                      |  0px; outline: rgb(0, 0, 255) none 0 |
|                                      | px; padding: 0px; text-align: left;  |
|                                      | text-decoration: none; white-space:  |
|                                      | pre;"}                               |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 643px;">                         |
|                                      |                                      |
|                                      | `)`{style="display: inline; font-sty |
|                                      | le: normal; font-variant: normal; fo |
|                                      | nt-weight: normal; font-stretch: nor |
|                                      | mal; font-size: 14px; font-family: C |
|                                      | onsolas, "Bitstream Vera Sans Mono", |
|                                      |  "Courier New", Courier, monospace;  |
|                                      | line-height: 15.4px; margin: 0px; pa |
|                                      | dding: 0px; text-align: left; text-d |
|                                      | ecoration: none; white-space: pre;"} |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+

</div>

</div>

从这个例子我们就可以看到NSPredicate有多么强大，如果让我们用其他的方法来实现又是一大堆if...else。

让我们来回顾一下上面的从第二个数组中去除第一个数组中相同的元素

例二：

<div
style="border: 0px none rgb(37, 37, 37); color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 77px; line-height: 28px; margin: 0px; outline: rgb(37, 37, 37) none 0px; padding: 0px; text-decoration: none; width: 720px;">

<div
style="background: none 0% 0% / auto repeat scroll padding-box border-box rgb(255, 255, 255); border: 0px none rgb(37, 37, 37); bottom: 0px; color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 60px; left: 0px; line-height: 28px; margin: 14px 0px; outline: rgb(37, 37, 37) none 0px; overflow: auto; padding: 0px; position: relative; right: 0px; text-decoration: none; top: 0px; width: 703px;">

+--------------------------------------+--------------------------------------+
| <div                                 | <div                                 |
| style="background: none 0% 0% / auto | style="border: 0px none rgb(37, 37,  |
|  repeat scroll padding-box border-bo | 37); bottom: 0px; color: rgb(37, 37, |
| x rgb(255, 255, 255); color: rgb(175 |  37); display: block; font-style: no |
| , 175, 175); display: block; font-st | rmal; font-variant: normal; font-wei |
| yle: normal; font-variant: normal; f | ght: normal; font-stretch: normal; f |
| ont-weight: normal; font-stretch: no | ont-size: 14px; font-family: Consola |
| rmal; font-size: 14px; font-family:  | s, &quot;Bitstream Vera Sans Mono&qu |
| Consolas, &quot;Bitstream Vera Sans  | ot;, &quot;Courier New&quot;, Courie |
| Mono&quot;, &quot;Courier New&quot;, | r, monospace; height: 60px; left: 0p |
|  Courier, monospace; height: 15px; l | x; line-height: 15.4px; margin: 0px; |
| ine-height: 15.4px; margin: 0px; out |  outline: rgb(37, 37, 37) none 0px;  |
| line: rgb(175, 175, 175) none 0px; p | padding: 0px; position: relative; ri |
| adding: 0px 7px 0px 14px; text-align | ght: 0px; text-align: left; text-dec |
| : right; text-decoration: none; whit | oration: none; top: 0px; width: 767p |
| e-space: pre; width: 8px;">          | x;">                                 |
|                                      |                                      |
| 1                                    | <div                                 |
|                                      | style="background: none 0% 0% / auto |
| </div>                               |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
| <div                                 | ne rgb(37, 37, 37); color: rgb(37, 3 |
| style="background: none 0% 0% / auto | 7, 37); display: block; font-style:  |
|  repeat scroll padding-box border-bo | normal; font-variant: normal; font-w |
| x rgb(255, 255, 255); color: rgb(175 | eight: normal; font-stretch: normal; |
| , 175, 175); display: block; font-st |  font-size: 14px; font-family: Conso |
| yle: normal; font-variant: normal; f | las, &quot;Bitstream Vera Sans Mono& |
| ont-weight: normal; font-stretch: no | quot;, &quot;Courier New&quot;, Cour |
| rmal; font-size: 14px; font-family:  | ier, monospace; height: 15px; line-h |
| Consolas, &quot;Bitstream Vera Sans  | eight: 15.4px; margin: 0px; outline: |
| Mono&quot;, &quot;Courier New&quot;, |  rgb(37, 37, 37) none 0px; padding:  |
|  Courier, monospace; height: 15px; l | 0px 14px; text-align: left; text-dec |
| ine-height: 15.4px; margin: 0px; out | oration: none; white-space: pre; wid |
| line: rgb(175, 175, 175) none 0px; p | th: 739px;">                         |
| adding: 0px 7px 0px 14px; text-align |                                      |
| : right; text-decoration: none; whit | `NSArray *filterArray = @[@`{style=" |
| e-space: pre; width: 8px;">          | display: inline; font-style: normal; |
|                                      |  font-variant: normal; font-weight:  |
| 2                                    | normal; font-stretch: normal; font-s |
|                                      | ize: 14px; font-family: Consolas, "B |
| </div>                               | itstream Vera Sans Mono", "Courier N |
|                                      | ew", Courier, monospace; line-height |
| <div                                 | : 15.4px; margin: 0px; padding: 0px; |
| style="background: none 0% 0% / auto |  text-align: left; text-decoration:  |
|  repeat scroll padding-box border-bo | none; white-space: pre;"}`"ab"`{styl |
| x rgb(255, 255, 255); color: rgb(175 | e="border: 0px none rgb(0, 0, 255);  |
| , 175, 175); display: block; font-st | color: rgb(0, 0, 255); display: inli |
| yle: normal; font-variant: normal; f | ne; font-style: normal; font-variant |
| ont-weight: normal; font-stretch: no | : normal; font-weight: normal; font- |
| rmal; font-size: 14px; font-family:  | stretch: normal; font-size: 14px; fo |
| Consolas, &quot;Bitstream Vera Sans  | nt-family: Consolas, "Bitstream Vera |
| Mono&quot;, &quot;Courier New&quot;, |  Sans Mono", "Courier New", Courier, |
|  Courier, monospace; height: 15px; l |  monospace; line-height: 15.4px; mar |
| ine-height: 15.4px; margin: 0px; out | gin: 0px; outline: rgb(0, 0, 255) no |
| line: rgb(175, 175, 175) none 0px; p | ne 0px; padding: 0px; text-align: le |
| adding: 0px 7px 0px 14px; text-align | ft; text-decoration: none; white-spa |
| : right; text-decoration: none; whit | ce: pre;"}`, @`{style="display: inli |
| e-space: pre; width: 8px;">          | ne; font-style: normal; font-variant |
|                                      | : normal; font-weight: normal; font- |
| 3                                    | stretch: normal; font-size: 14px; fo |
|                                      | nt-family: Consolas, "Bitstream Vera |
| </div>                               |  Sans Mono", "Courier New", Courier, |
|                                      |  monospace; line-height: 15.4px; mar |
| <div                                 | gin: 0px; padding: 0px; text-align:  |
| style="background: none 0% 0% / auto | left; text-decoration: none; white-s |
|  repeat scroll padding-box border-bo | pace: pre;"}`"abc"`{style="border: 0 |
| x rgb(255, 255, 255); color: rgb(175 | px none rgb(0, 0, 255); color: rgb(0 |
| , 175, 175); display: block; font-st | , 0, 255); display: inline; font-sty |
| yle: normal; font-variant: normal; f | le: normal; font-variant: normal; fo |
| ont-weight: normal; font-stretch: no | nt-weight: normal; font-stretch: nor |
| rmal; font-size: 14px; font-family:  | mal; font-size: 14px; font-family: C |
| Consolas, &quot;Bitstream Vera Sans  | onsolas, "Bitstream Vera Sans Mono", |
| Mono&quot;, &quot;Courier New&quot;, |  "Courier New", Courier, monospace;  |
|  Courier, monospace; height: 15px; l | line-height: 15.4px; margin: 0px; ou |
| ine-height: 15.4px; margin: 0px; out | tline: rgb(0, 0, 255) none 0px; padd |
| line: rgb(175, 175, 175) none 0px; p | ing: 0px; text-align: left; text-dec |
| adding: 0px 7px 0px 14px; text-align | oration: none; white-space: pre;"}`] |
| : right; text-decoration: none; whit | ;`{style="display: inline; font-styl |
| e-space: pre; width: 8px;">          | e: normal; font-variant: normal; fon |
|                                      | t-weight: normal; font-stretch: norm |
| 4                                    | al; font-size: 14px; font-family: Co |
|                                      | nsolas, "Bitstream Vera Sans Mono",  |
| </div>                               | "Courier New", Courier, monospace; l |
|                                      | ine-height: 15.4px; margin: 0px; pad |
|                                      | ding: 0px; text-align: left; text-de |
|                                      | coration: none; white-space: pre;"}  |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 739px;">                         |
|                                      |                                      |
|                                      | `    `{style="border: 0px none rgb(3 |
|                                      | 7, 37, 37); color: rgb(37, 37, 37);  |
|                                      | display: inline; font-style: normal; |
|                                      |  font-variant: normal; font-weight:  |
|                                      | normal; font-stretch: normal; font-s |
|                                      | ize: 14px; font-family: Consolas, "B |
|                                      | itstream Vera Sans Mono", "Courier N |
|                                      | ew", Courier, monospace; line-height |
|                                      | : 15.4px; margin: 0px; outline: rgb( |
|                                      | 37, 37, 37) none 0px; padding: 0px;  |
|                                      | text-align: left; text-decoration: n |
|                                      | one; white-space: pre;"}`NSArray *ar |
|                                      | ray = @[@`{style="display: inline; f |
|                                      | ont-style: normal; font-variant: nor |
|                                      | mal; font-weight: normal; font-stret |
|                                      | ch: normal; font-size: 14px; font-fa |
|                                      | mily: Consolas, "Bitstream Vera Sans |
|                                      |  Mono", "Courier New", Courier, mono |
|                                      | space; line-height: 15.4px; margin:  |
|                                      | 0px; padding: 0px; text-align: left; |
|                                      |  text-decoration: none; white-space: |
|                                      |  pre;"}`"a"`{style="border: 0px none |
|                                      |  rgb(0, 0, 255); color: rgb(0, 0, 25 |
|                                      | 5); display: inline; font-style: nor |
|                                      | mal; font-variant: normal; font-weig |
|                                      | ht: normal; font-stretch: normal; fo |
|                                      | nt-size: 14px; font-family: Consolas |
|                                      | , "Bitstream Vera Sans Mono", "Couri |
|                                      | er New", Courier, monospace; line-he |
|                                      | ight: 15.4px; margin: 0px; outline:  |
|                                      | rgb(0, 0, 255) none 0px; padding: 0p |
|                                      | x; text-align: left; text-decoration |
|                                      | : none; white-space: pre;"}`, @`{sty |
|                                      | le="display: inline; font-style: nor |
|                                      | mal; font-variant: normal; font-weig |
|                                      | ht: normal; font-stretch: normal; fo |
|                                      | nt-size: 14px; font-family: Consolas |
|                                      | , "Bitstream Vera Sans Mono", "Couri |
|                                      | er New", Courier, monospace; line-he |
|                                      | ight: 15.4px; margin: 0px; padding:  |
|                                      | 0px; text-align: left; text-decorati |
|                                      | on: none; white-space: pre;"}`"ab"`{ |
|                                      | style="border: 0px none rgb(0, 0, 25 |
|                                      | 5); color: rgb(0, 0, 255); display:  |
|                                      | inline; font-style: normal; font-var |
|                                      | iant: normal; font-weight: normal; f |
|                                      | ont-stretch: normal; font-size: 14px |
|                                      | ; font-family: Consolas, "Bitstream  |
|                                      | Vera Sans Mono", "Courier New", Cour |
|                                      | ier, monospace; line-height: 15.4px; |
|                                      |  margin: 0px; outline: rgb(0, 0, 255 |
|                                      | ) none 0px; padding: 0px; text-align |
|                                      | : left; text-decoration: none; white |
|                                      | -space: pre;"}`, @`{style="display:  |
|                                      | inline; font-style: normal; font-var |
|                                      | iant: normal; font-weight: normal; f |
|                                      | ont-stretch: normal; font-size: 14px |
|                                      | ; font-family: Consolas, "Bitstream  |
|                                      | Vera Sans Mono", "Courier New", Cour |
|                                      | ier, monospace; line-height: 15.4px; |
|                                      |  margin: 0px; padding: 0px; text-ali |
|                                      | gn: left; text-decoration: none; whi |
|                                      | te-space: pre;"}`"abc"`{style="borde |
|                                      | r: 0px none rgb(0, 0, 255); color: r |
|                                      | gb(0, 0, 255); display: inline; font |
|                                      | -style: normal; font-variant: normal |
|                                      | ; font-weight: normal; font-stretch: |
|                                      |  normal; font-size: 14px; font-famil |
|                                      | y: Consolas, "Bitstream Vera Sans Mo |
|                                      | no", "Courier New", Courier, monospa |
|                                      | ce; line-height: 15.4px; margin: 0px |
|                                      | ; outline: rgb(0, 0, 255) none 0px;  |
|                                      | padding: 0px; text-align: left; text |
|                                      | -decoration: none; white-space: pre; |
|                                      | "}`, @`{style="display: inline; font |
|                                      | -style: normal; font-variant: normal |
|                                      | ; font-weight: normal; font-stretch: |
|                                      |  normal; font-size: 14px; font-famil |
|                                      | y: Consolas, "Bitstream Vera Sans Mo |
|                                      | no", "Courier New", Courier, monospa |
|                                      | ce; line-height: 15.4px; margin: 0px |
|                                      | ; padding: 0px; text-align: left; te |
|                                      | xt-decoration: none; white-space: pr |
|                                      | e;"}`"abcd"`{style="border: 0px none |
|                                      |  rgb(0, 0, 255); color: rgb(0, 0, 25 |
|                                      | 5); display: inline; font-style: nor |
|                                      | mal; font-variant: normal; font-weig |
|                                      | ht: normal; font-stretch: normal; fo |
|                                      | nt-size: 14px; font-family: Consolas |
|                                      | , "Bitstream Vera Sans Mono", "Couri |
|                                      | er New", Courier, monospace; line-he |
|                                      | ight: 15.4px; margin: 0px; outline:  |
|                                      | rgb(0, 0, 255) none 0px; padding: 0p |
|                                      | x; text-align: left; text-decoration |
|                                      | : none; white-space: pre;"}`];`{styl |
|                                      | e="display: inline; font-style: norm |
|                                      | al; font-variant: normal; font-weigh |
|                                      | t: normal; font-stretch: normal; fon |
|                                      | t-size: 14px; font-family: Consolas, |
|                                      |  "Bitstream Vera Sans Mono", "Courie |
|                                      | r New", Courier, monospace; line-hei |
|                                      | ght: 15.4px; margin: 0px; padding: 0 |
|                                      | px; text-align: left; text-decoratio |
|                                      | n: none; white-space: pre;"}         |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 739px;">                         |
|                                      |                                      |
|                                      | `    `{style="border: 0px none rgb(3 |
|                                      | 7, 37, 37); color: rgb(37, 37, 37);  |
|                                      | display: inline; font-style: normal; |
|                                      |  font-variant: normal; font-weight:  |
|                                      | normal; font-stretch: normal; font-s |
|                                      | ize: 14px; font-family: Consolas, "B |
|                                      | itstream Vera Sans Mono", "Courier N |
|                                      | ew", Courier, monospace; line-height |
|                                      | : 15.4px; margin: 0px; outline: rgb( |
|                                      | 37, 37, 37) none 0px; padding: 0px;  |
|                                      | text-align: left; text-decoration: n |
|                                      | one; white-space: pre;"}`NSPredicate |
|                                      |  *predicate = [NSPredicate predicate |
|                                      | WithFormat:@`{style="display: inline |
|                                      | ; font-style: normal; font-variant:  |
|                                      | normal; font-weight: normal; font-st |
|                                      | retch: normal; font-size: 14px; font |
|                                      | -family: Consolas, "Bitstream Vera S |
|                                      | ans Mono", "Courier New", Courier, m |
|                                      | onospace; line-height: 15.4px; margi |
|                                      | n: 0px; padding: 0px; text-align: le |
|                                      | ft; text-decoration: none; white-spa |
|                                      | ce: pre;"}`"NOT (SELF IN %@)"`{style |
|                                      | ="border: 0px none rgb(0, 0, 255); c |
|                                      | olor: rgb(0, 0, 255); display: inlin |
|                                      | e; font-style: normal; font-variant: |
|                                      |  normal; font-weight: normal; font-s |
|                                      | tretch: normal; font-size: 14px; fon |
|                                      | t-family: Consolas, "Bitstream Vera  |
|                                      | Sans Mono", "Courier New", Courier,  |
|                                      | monospace; line-height: 15.4px; marg |
|                                      | in: 0px; outline: rgb(0, 0, 255) non |
|                                      | e 0px; padding: 0px; text-align: lef |
|                                      | t; text-decoration: none; white-spac |
|                                      | e: pre;"}`, filterArray];`{style="di |
|                                      | splay: inline; font-style: normal; f |
|                                      | ont-variant: normal; font-weight: no |
|                                      | rmal; font-stretch: normal; font-siz |
|                                      | e: 14px; font-family: Consolas, "Bit |
|                                      | stream Vera Sans Mono", "Courier New |
|                                      | ", Courier, monospace; line-height:  |
|                                      | 15.4px; margin: 0px; padding: 0px; t |
|                                      | ext-align: left; text-decoration: no |
|                                      | ne; white-space: pre;"}              |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 739px;">                         |
|                                      |                                      |
|                                      | `    `{style="border: 0px none rgb(3 |
|                                      | 7, 37, 37); color: rgb(37, 37, 37);  |
|                                      | display: inline; font-style: normal; |
|                                      |  font-variant: normal; font-weight:  |
|                                      | normal; font-stretch: normal; font-s |
|                                      | ize: 14px; font-family: Consolas, "B |
|                                      | itstream Vera Sans Mono", "Courier N |
|                                      | ew", Courier, monospace; line-height |
|                                      | : 15.4px; margin: 0px; outline: rgb( |
|                                      | 37, 37, 37) none 0px; padding: 0px;  |
|                                      | text-align: left; text-decoration: n |
|                                      | one; white-space: pre;"}`NSLog(@`{st |
|                                      | yle="display: inline; font-style: no |
|                                      | rmal; font-variant: normal; font-wei |
|                                      | ght: normal; font-stretch: normal; f |
|                                      | ont-size: 14px; font-family: Consola |
|                                      | s, "Bitstream Vera Sans Mono", "Cour |
|                                      | ier New", Courier, monospace; line-h |
|                                      | eight: 15.4px; margin: 0px; padding: |
|                                      |  0px; text-align: left; text-decorat |
|                                      | ion: none; white-space: pre;"}`"%@"` |
|                                      | {style="border: 0px none rgb(0, 0, 2 |
|                                      | 55); color: rgb(0, 0, 255); display: |
|                                      |  inline; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, "Bitstream |
|                                      |  Vera Sans Mono", "Courier New", Cou |
|                                      | rier, monospace; line-height: 15.4px |
|                                      | ; margin: 0px; outline: rgb(0, 0, 25 |
|                                      | 5) none 0px; padding: 0px; text-alig |
|                                      | n: left; text-decoration: none; whit |
|                                      | e-space: pre;"}`, [array filteredArr |
|                                      | ayUsingPredicate:predicate]);`{style |
|                                      | ="display: inline; font-style: norma |
|                                      | l; font-variant: normal; font-weight |
|                                      | : normal; font-stretch: normal; font |
|                                      | -size: 14px; font-family: Consolas,  |
|                                      | "Bitstream Vera Sans Mono", "Courier |
|                                      |  New", Courier, monospace; line-heig |
|                                      | ht: 15.4px; margin: 0px; padding: 0p |
|                                      | x; text-align: left; text-decoration |
|                                      | : none; white-space: pre;"}          |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+

</div>

</div>

输出为：

<div
style="border: 0px none rgb(37, 37, 37); color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 60px; line-height: 28px; margin: 0px; outline: rgb(37, 37, 37) none 0px; padding: 0px; text-decoration: none; width: 720px;">

<div
style="background: none 0% 0% / auto repeat scroll padding-box border-box rgb(255, 255, 255); border: 0px none rgb(37, 37, 37); bottom: 0px; color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 60px; left: 0px; line-height: 28px; margin: 14px 0px; outline: rgb(37, 37, 37) none 0px; overflow: auto; padding: 0px; position: relative; right: 0px; text-decoration: none; top: 0px; width: 703px;">

+--------------------------------------+--------------------------------------+
| <div                                 | <div                                 |
| style="background: none 0% 0% / auto | style="border: 0px none rgb(37, 37,  |
|  repeat scroll padding-box border-bo | 37); bottom: 0px; color: rgb(37, 37, |
| x rgb(255, 255, 255); color: rgb(175 |  37); display: block; font-style: no |
| , 175, 175); display: block; font-st | rmal; font-variant: normal; font-wei |
| yle: normal; font-variant: normal; f | ght: normal; font-stretch: normal; f |
| ont-weight: normal; font-stretch: no | ont-size: 14px; font-family: Consola |
| rmal; font-size: 14px; font-family:  | s, &quot;Bitstream Vera Sans Mono&qu |
| Consolas, &quot;Bitstream Vera Sans  | ot;, &quot;Courier New&quot;, Courie |
| Mono&quot;, &quot;Courier New&quot;, | r, monospace; height: 60px; left: 0p |
|  Courier, monospace; height: 15px; l | x; line-height: 15.4px; margin: 0px; |
| ine-height: 15.4px; margin: 0px; out |  outline: rgb(37, 37, 37) none 0px;  |
| line: rgb(175, 175, 175) none 0px; p | padding: 0px; position: relative; ri |
| adding: 0px 7px 0px 14px; text-align | ght: 0px; text-align: left; text-dec |
| : right; text-decoration: none; whit | oration: none; top: 0px; width: 671p |
| e-space: pre; width: 8px;">          | x;">                                 |
|                                      |                                      |
| 1                                    | <div                                 |
|                                      | style="background: none 0% 0% / auto |
| </div>                               |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
| <div                                 | ne rgb(37, 37, 37); color: rgb(37, 3 |
| style="background: none 0% 0% / auto | 7, 37); display: block; font-style:  |
|  repeat scroll padding-box border-bo | normal; font-variant: normal; font-w |
| x rgb(255, 255, 255); color: rgb(175 | eight: normal; font-stretch: normal; |
| , 175, 175); display: block; font-st |  font-size: 14px; font-family: Conso |
| yle: normal; font-variant: normal; f | las, &quot;Bitstream Vera Sans Mono& |
| ont-weight: normal; font-stretch: no | quot;, &quot;Courier New&quot;, Cour |
| rmal; font-size: 14px; font-family:  | ier, monospace; height: 15px; line-h |
| Consolas, &quot;Bitstream Vera Sans  | eight: 15.4px; margin: 0px; outline: |
| Mono&quot;, &quot;Courier New&quot;, |  rgb(37, 37, 37) none 0px; padding:  |
|  Courier, monospace; height: 15px; l | 0px 14px; text-align: left; text-dec |
| ine-height: 15.4px; margin: 0px; out | oration: none; white-space: pre; wid |
| line: rgb(175, 175, 175) none 0px; p | th: 643px;">                         |
| adding: 0px 7px 0px 14px; text-align |                                      |
| : right; text-decoration: none; whit | `2016-01-07 13:17:43.669 PredicteDem |
| e-space: pre; width: 8px;">          | o[6701:136206] (`{style="display: in |
|                                      | line; font-style: normal; font-varia |
| 2                                    | nt: normal; font-weight: normal; fon |
|                                      | t-stretch: normal; font-size: 14px;  |
| </div>                               | font-family: Consolas, "Bitstream Ve |
|                                      | ra Sans Mono", "Courier New", Courie |
| <div                                 | r, monospace; line-height: 15.4px; m |
| style="background: none 0% 0% / auto | argin: 0px; padding: 0px; text-align |
|  repeat scroll padding-box border-bo | : left; text-decoration: none; white |
| x rgb(255, 255, 255); color: rgb(175 | -space: pre;"}                       |
| , 175, 175); display: block; font-st |                                      |
| yle: normal; font-variant: normal; f | </div>                               |
| ont-weight: normal; font-stretch: no |                                      |
| rmal; font-size: 14px; font-family:  | <div                                 |
| Consolas, &quot;Bitstream Vera Sans  | style="background: none 0% 0% / auto |
| Mono&quot;, &quot;Courier New&quot;, |  repeat scroll padding-box border-bo |
|  Courier, monospace; height: 15px; l | x rgb(255, 255, 255); border: 0px no |
| ine-height: 15.4px; margin: 0px; out | ne rgb(37, 37, 37); color: rgb(37, 3 |
| line: rgb(175, 175, 175) none 0px; p | 7, 37); display: block; font-style:  |
| adding: 0px 7px 0px 14px; text-align | normal; font-variant: normal; font-w |
| : right; text-decoration: none; whit | eight: normal; font-stretch: normal; |
| e-space: pre; width: 8px;">          |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
| 3                                    | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
| </div>                               | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
| <div                                 | 0px 14px; text-align: left; text-dec |
| style="background: none 0% 0% / auto | oration: none; white-space: pre; wid |
|  repeat scroll padding-box border-bo | th: 643px;">                         |
| x rgb(255, 255, 255); color: rgb(175 |                                      |
| , 175, 175); display: block; font-st | `    `{style="border: 0px none rgb(3 |
| yle: normal; font-variant: normal; f | 7, 37, 37); color: rgb(37, 37, 37);  |
| ont-weight: normal; font-stretch: no | display: inline; font-style: normal; |
| rmal; font-size: 14px; font-family:  |  font-variant: normal; font-weight:  |
| Consolas, &quot;Bitstream Vera Sans  | normal; font-stretch: normal; font-s |
| Mono&quot;, &quot;Courier New&quot;, | ize: 14px; font-family: Consolas, "B |
|  Courier, monospace; height: 15px; l | itstream Vera Sans Mono", "Courier N |
| ine-height: 15.4px; margin: 0px; out | ew", Courier, monospace; line-height |
| line: rgb(175, 175, 175) none 0px; p | : 15.4px; margin: 0px; outline: rgb( |
| adding: 0px 7px 0px 14px; text-align | 37, 37, 37) none 0px; padding: 0px;  |
| : right; text-decoration: none; whit | text-align: left; text-decoration: n |
| e-space: pre; width: 8px;">          | one; white-space: pre;"}`a,`{style=" |
|                                      | display: inline; font-style: normal; |
| 4                                    |  font-variant: normal; font-weight:  |
|                                      | normal; font-stretch: normal; font-s |
| </div>                               | ize: 14px; font-family: Consolas, "B |
|                                      | itstream Vera Sans Mono", "Courier N |
|                                      | ew", Courier, monospace; line-height |
|                                      | : 15.4px; margin: 0px; padding: 0px; |
|                                      |  text-align: left; text-decoration:  |
|                                      | none; white-space: pre;"}            |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 643px;">                         |
|                                      |                                      |
|                                      | `    `{style="border: 0px none rgb(3 |
|                                      | 7, 37, 37); color: rgb(37, 37, 37);  |
|                                      | display: inline; font-style: normal; |
|                                      |  font-variant: normal; font-weight:  |
|                                      | normal; font-stretch: normal; font-s |
|                                      | ize: 14px; font-family: Consolas, "B |
|                                      | itstream Vera Sans Mono", "Courier N |
|                                      | ew", Courier, monospace; line-height |
|                                      | : 15.4px; margin: 0px; outline: rgb( |
|                                      | 37, 37, 37) none 0px; padding: 0px;  |
|                                      | text-align: left; text-decoration: n |
|                                      | one; white-space: pre;"}`abcd`{style |
|                                      | ="display: inline; font-style: norma |
|                                      | l; font-variant: normal; font-weight |
|                                      | : normal; font-stretch: normal; font |
|                                      | -size: 14px; font-family: Consolas,  |
|                                      | "Bitstream Vera Sans Mono", "Courier |
|                                      |  New", Courier, monospace; line-heig |
|                                      | ht: 15.4px; margin: 0px; padding: 0p |
|                                      | x; text-align: left; text-decoration |
|                                      | : none; white-space: pre;"}          |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 643px;">                         |
|                                      |                                      |
|                                      | `)`{style="display: inline; font-sty |
|                                      | le: normal; font-variant: normal; fo |
|                                      | nt-weight: normal; font-stretch: nor |
|                                      | mal; font-size: 14px; font-family: C |
|                                      | onsolas, "Bitstream Vera Sans Mono", |
|                                      |  "Courier New", Courier, monospace;  |
|                                      | line-height: 15.4px; margin: 0px; pa |
|                                      | dding: 0px; text-align: left; text-d |
|                                      | ecoration: none; white-space: pre;"} |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+

</div>

</div>

如果我们不用NSPredicate的话，肯定又是各种if...else，for循环等等。可以看出NSPredicate的出现为我们节省了大量的时间和精力。

<span
style="border: 0px none rgb(149, 55, 52); color: rgb(149, 55, 52); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; line-height: 28px; margin: 0px; outline: rgb(149, 55, 52) none 0px; padding: 0px; text-decoration: none;">3.在谓词中使用占位符参数</span>

我们上面所有的例子中谓词总是固定的，然而我们在现实中处理变量时决定了谓词应该是可变的。下面我们来看看如果让谓词变化起来。

首先如果我们想在谓词表达式中使用变量，那么我们需要了解下列两种占位符：

-   %K：用于动态传入属性名

-   %@：用于动态设置属性值

其实相当于变量名与变量值

除此之外，还可以在谓词表达式中使用动态改变的属性值，就像环境变量一样

<div
style="border: 0px none rgb(37, 37, 37); color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 15px; line-height: 28px; margin: 0px; outline: rgb(37, 37, 37) none 0px; padding: 0px; text-decoration: none; width: 720px;">

<div
style="background: none 0% 0% / auto repeat scroll padding-box border-box rgb(255, 255, 255); border: 0px none rgb(37, 37, 37); bottom: 0px; color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 15px; left: 0px; line-height: 28px; margin: 14px 0px; outline: rgb(37, 37, 37) none 0px; overflow: auto; padding: 0px; position: relative; right: 0px; text-decoration: none; top: 0px; width: 703px;">

+--------------------------------------+--------------------------------------+
| <div                                 | <div                                 |
| style="background: none 0% 0% / auto | style="border: 0px none rgb(37, 37,  |
|  repeat scroll padding-box border-bo | 37); bottom: 0px; color: rgb(37, 37, |
| x rgb(255, 255, 255); color: rgb(175 |  37); display: block; font-style: no |
| , 175, 175); display: block; font-st | rmal; font-variant: normal; font-wei |
| yle: normal; font-variant: normal; f | ght: normal; font-stretch: normal; f |
| ont-weight: normal; font-stretch: no | ont-size: 14px; font-family: Consola |
| rmal; font-size: 14px; font-family:  | s, &quot;Bitstream Vera Sans Mono&qu |
| Consolas, &quot;Bitstream Vera Sans  | ot;, &quot;Courier New&quot;, Courie |
| Mono&quot;, &quot;Courier New&quot;, | r, monospace; height: 15px; left: 0p |
|  Courier, monospace; height: 15px; l | x; line-height: 15.4px; margin: 0px; |
| ine-height: 15.4px; margin: 0px; out |  outline: rgb(37, 37, 37) none 0px;  |
| line: rgb(175, 175, 175) none 0px; p | padding: 0px; position: relative; ri |
| adding: 0px 7px 0px 14px; text-align | ght: 0px; text-align: left; text-dec |
| : right; text-decoration: none; whit | oration: none; top: 0px; width: 671p |
| e-space: pre; width: 8px;">          | x;">                                 |
|                                      |                                      |
| 1                                    | <div                                 |
|                                      | style="background: none 0% 0% / auto |
| </div>                               |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 643px;">                         |
|                                      |                                      |
|                                      | `NSPredicate *pred = [NSPredicate pr |
|                                      | edicateWithFormat:@`{style="display: |
|                                      |  inline; font-style: normal; font-va |
|                                      | riant: normal; font-weight: normal;  |
|                                      | font-stretch: normal; font-size: 14p |
|                                      | x; font-family: Consolas, "Bitstream |
|                                      |  Vera Sans Mono", "Courier New", Cou |
|                                      | rier, monospace; line-height: 15.4px |
|                                      | ; margin: 0px; padding: 0px; text-al |
|                                      | ign: left; text-decoration: none; wh |
|                                      | ite-space: pre;"}`"SELF CONTAINS $VA |
|                                      | LUE"`{style="border: 0px none rgb(0, |
|                                      |  0, 255); color: rgb(0, 0, 255); dis |
|                                      | play: inline; font-style: normal; fo |
|                                      | nt-variant: normal; font-weight: nor |
|                                      | mal; font-stretch: normal; font-size |
|                                      | : 14px; font-family: Consolas, "Bits |
|                                      | tream Vera Sans Mono", "Courier New" |
|                                      | , Courier, monospace; line-height: 1 |
|                                      | 5.4px; margin: 0px; outline: rgb(0,  |
|                                      | 0, 255) none 0px; padding: 0px; text |
|                                      | -align: left; text-decoration: none; |
|                                      |  white-space: pre;"}`];`{style="disp |
|                                      | lay: inline; font-style: normal; fon |
|                                      | t-variant: normal; font-weight: norm |
|                                      | al; font-stretch: normal; font-size: |
|                                      |  14px; font-family: Consolas, "Bitst |
|                                      | ream Vera Sans Mono", "Courier New", |
|                                      |  Courier, monospace; line-height: 15 |
|                                      | .4px; margin: 0px; padding: 0px; tex |
|                                      | t-align: left; text-decoration: none |
|                                      | ; white-space: pre;"}                |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+

</div>

</div>

上述表达式中，\$VALUE是一个可以动态变化的值，它其实最后是在字典中的一个key，所以可以根据你的需要写不同的值，但是必须有\$开头，随着程序改变\$VALUE这个谓词表达式的比较条件就可以动态改变。

下面我们通过一个例子来看看这三个重要的占位符应该如何使用

例一：

<span
style="border: 0px none rgb(37, 37, 37); color: rgb(37, 37, 37); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; line-height: 28px; margin: 0px; outline: rgb(37, 37, 37) none 0px; padding: 0px; text-decoration: none; white-space: nowrap;"></span>

<div
style="border: 0px none rgb(37, 37, 37); color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 362px; line-height: 28px; margin: 0px; outline: rgb(37, 37, 37) none 0px; padding: 0px; text-decoration: none; width: 720px;">

<div
style="background: none 0% 0% / auto repeat scroll padding-box border-box rgb(255, 255, 255); border: 0px none rgb(37, 37, 37); bottom: 0px; color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 345px; left: 0px; line-height: 28px; margin: 14px 0px; outline: rgb(37, 37, 37) none 0px; overflow: auto; padding: 0px; position: relative; right: 0px; text-decoration: none; top: 0px; width: 703px;">

+--------------------------------------+--------------------------------------+
| <div                                 | <div                                 |
| style="background: none 0% 0% / auto | style="border: 0px none rgb(37, 37,  |
|  repeat scroll padding-box border-bo | 37); bottom: 0px; color: rgb(37, 37, |
| x rgb(255, 255, 255); color: rgb(175 |  37); display: block; font-style: no |
| , 175, 175); display: block; font-st | rmal; font-variant: normal; font-wei |
| yle: normal; font-variant: normal; f | ght: normal; font-stretch: normal; f |
| ont-weight: normal; font-stretch: no | ont-size: 14px; font-family: Consola |
| rmal; font-size: 14px; font-family:  | s, &quot;Bitstream Vera Sans Mono&qu |
| Consolas, &quot;Bitstream Vera Sans  | ot;, &quot;Courier New&quot;, Courie |
| Mono&quot;, &quot;Courier New&quot;, | r, monospace; height: 345px; left: 0 |
|  Courier, monospace; height: 15px; l | px; line-height: 15.4px; margin: 0px |
| ine-height: 15.4px; margin: 0px; out | ; outline: rgb(37, 37, 37) none 0px; |
| line: rgb(175, 175, 175) none 0px; p |  padding: 0px; position: relative; r |
| adding: 0px 7px 0px 14px; text-align | ight: 0px; text-align: left; text-de |
| : right; text-decoration: none; whit | coration: none; top: 0px; width: 729 |
| e-space: pre; width: 16px;">         | px;">                                |
|                                      |                                      |
| 1                                    | <div                                 |
|                                      | style="background: none 0% 0% / auto |
| </div>                               |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
| <div                                 | ne rgb(37, 37, 37); color: rgb(37, 3 |
| style="background: none 0% 0% / auto | 7, 37); display: block; font-style:  |
|  repeat scroll padding-box border-bo | normal; font-variant: normal; font-w |
| x rgb(255, 255, 255); color: rgb(175 | eight: normal; font-stretch: normal; |
| , 175, 175); display: block; font-st |  font-size: 14px; font-family: Conso |
| yle: normal; font-variant: normal; f | las, &quot;Bitstream Vera Sans Mono& |
| ont-weight: normal; font-stretch: no | quot;, &quot;Courier New&quot;, Cour |
| rmal; font-size: 14px; font-family:  | ier, monospace; height: 15px; line-h |
| Consolas, &quot;Bitstream Vera Sans  | eight: 15.4px; margin: 0px; outline: |
| Mono&quot;, &quot;Courier New&quot;, |  rgb(37, 37, 37) none 0px; padding:  |
|  Courier, monospace; height: 15px; l | 0px 14px; text-align: left; text-dec |
| ine-height: 15.4px; margin: 0px; out | oration: none; white-space: pre; wid |
| line: rgb(175, 175, 175) none 0px; p | th: 701px;">                         |
| adding: 0px 7px 0px 14px; text-align |                                      |
| : right; text-decoration: none; whit | `NSArray *array = @[[ZLPersonModel p |
| e-space: pre; width: 16px;">         | ersonWithName:@`{style="display: inl |
|                                      | ine; font-style: normal; font-varian |
| 2                                    | t: normal; font-weight: normal; font |
|                                      | -stretch: normal; font-size: 14px; f |
| </div>                               | ont-family: Consolas, "Bitstream Ver |
|                                      | a Sans Mono", "Courier New", Courier |
| <div                                 | , monospace; line-height: 15.4px; ma |
| style="background: none 0% 0% / auto | rgin: 0px; padding: 0px; text-align: |
|  repeat scroll padding-box border-bo |  left; text-decoration: none; white- |
| x rgb(255, 255, 255); color: rgb(175 | space: pre;"}`"Jack"`{style="border: |
| , 175, 175); display: block; font-st |  0px none rgb(0, 0, 255); color: rgb |
| yle: normal; font-variant: normal; f | (0, 0, 255); display: inline; font-s |
| ont-weight: normal; font-stretch: no | tyle: normal; font-variant: normal;  |
| rmal; font-size: 14px; font-family:  | font-weight: normal; font-stretch: n |
| Consolas, &quot;Bitstream Vera Sans  | ormal; font-size: 14px; font-family: |
| Mono&quot;, &quot;Courier New&quot;, |  Consolas, "Bitstream Vera Sans Mono |
|  Courier, monospace; height: 15px; l | ", "Courier New", Courier, monospace |
| ine-height: 15.4px; margin: 0px; out | ; line-height: 15.4px; margin: 0px;  |
| line: rgb(175, 175, 175) none 0px; p | outline: rgb(0, 0, 255) none 0px; pa |
| adding: 0px 7px 0px 14px; text-align | dding: 0px; text-align: left; text-d |
| : right; text-decoration: none; whit | ecoration: none; white-space: pre;"} |
| e-space: pre; width: 16px;">         |  `age:20 sex:ZLPersonSexMale],`{styl |
|                                      | e="display: inline; font-style: norm |
| 3                                    | al; font-variant: normal; font-weigh |
|                                      | t: normal; font-stretch: normal; fon |
| </div>                               | t-size: 14px; font-family: Consolas, |
|                                      |  "Bitstream Vera Sans Mono", "Courie |
| <div                                 | r New", Courier, monospace; line-hei |
| style="background: none 0% 0% / auto | ght: 15.4px; margin: 0px; padding: 0 |
|  repeat scroll padding-box border-bo | px; text-align: left; text-decoratio |
| x rgb(255, 255, 255); color: rgb(175 | n: none; white-space: pre;"}         |
| , 175, 175); display: block; font-st |                                      |
| yle: normal; font-variant: normal; f | </div>                               |
| ont-weight: normal; font-stretch: no |                                      |
| rmal; font-size: 14px; font-family:  | <div                                 |
| Consolas, &quot;Bitstream Vera Sans  | style="background: none 0% 0% / auto |
| Mono&quot;, &quot;Courier New&quot;, |  repeat scroll padding-box border-bo |
|  Courier, monospace; height: 15px; l | x rgb(255, 255, 255); border: 0px no |
| ine-height: 15.4px; margin: 0px; out | ne rgb(37, 37, 37); color: rgb(37, 3 |
| line: rgb(175, 175, 175) none 0px; p | 7, 37); display: block; font-style:  |
| adding: 0px 7px 0px 14px; text-align | normal; font-variant: normal; font-w |
| : right; text-decoration: none; whit | eight: normal; font-stretch: normal; |
| e-space: pre; width: 16px;">         |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
| 4                                    | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
| </div>                               | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
| <div                                 | 0px 14px; text-align: left; text-dec |
| style="background: none 0% 0% / auto | oration: none; white-space: pre; wid |
|  repeat scroll padding-box border-bo | th: 701px;">                         |
| x rgb(255, 255, 255); color: rgb(175 |                                      |
| , 175, 175); display: block; font-st | `                     `{style="borde |
| yle: normal; font-variant: normal; f | r: 0px none rgb(37, 37, 37); color:  |
| ont-weight: normal; font-stretch: no | rgb(37, 37, 37); display: inline; fo |
| rmal; font-size: 14px; font-family:  | nt-style: normal; font-variant: norm |
| Consolas, &quot;Bitstream Vera Sans  | al; font-weight: normal; font-stretc |
| Mono&quot;, &quot;Courier New&quot;, | h: normal; font-size: 14px; font-fam |
|  Courier, monospace; height: 15px; l | ily: Consolas, "Bitstream Vera Sans  |
| ine-height: 15.4px; margin: 0px; out | Mono", "Courier New", Courier, monos |
| line: rgb(175, 175, 175) none 0px; p | pace; line-height: 15.4px; margin: 0 |
| adding: 0px 7px 0px 14px; text-align | px; outline: rgb(37, 37, 37) none 0p |
| : right; text-decoration: none; whit | x; padding: 0px; text-align: left; t |
| e-space: pre; width: 16px;">         | ext-decoration: none; white-space: p |
|                                      | re;"}`[ZLPersonModel personWithName: |
| 5                                    | @`{style="display: inline; font-styl |
|                                      | e: normal; font-variant: normal; fon |
| </div>                               | t-weight: normal; font-stretch: norm |
|                                      | al; font-size: 14px; font-family: Co |
| <div                                 | nsolas, "Bitstream Vera Sans Mono",  |
| style="background: none 0% 0% / auto | "Courier New", Courier, monospace; l |
|  repeat scroll padding-box border-bo | ine-height: 15.4px; margin: 0px; pad |
| x rgb(255, 255, 255); color: rgb(175 | ding: 0px; text-align: left; text-de |
| , 175, 175); display: block; font-st | coration: none; white-space: pre;"}` |
| yle: normal; font-variant: normal; f | "Rose"`{style="border: 0px none rgb( |
| ont-weight: normal; font-stretch: no | 0, 0, 255); color: rgb(0, 0, 255); d |
| rmal; font-size: 14px; font-family:  | isplay: inline; font-style: normal;  |
| Consolas, &quot;Bitstream Vera Sans  | font-variant: normal; font-weight: n |
| Mono&quot;, &quot;Courier New&quot;, | ormal; font-stretch: normal; font-si |
|  Courier, monospace; height: 15px; l | ze: 14px; font-family: Consolas, "Bi |
| ine-height: 15.4px; margin: 0px; out | tstream Vera Sans Mono", "Courier Ne |
| line: rgb(175, 175, 175) none 0px; p | w", Courier, monospace; line-height: |
| adding: 0px 7px 0px 14px; text-align |  15.4px; margin: 0px; outline: rgb(0 |
| : right; text-decoration: none; whit | , 0, 255) none 0px; padding: 0px; te |
| e-space: pre; width: 16px;">         | xt-align: left; text-decoration: non |
|                                      | e; white-space: pre;"} `age:22 sex:Z |
| 6                                    | LPersonSexFamale],`{style="display:  |
|                                      | inline; font-style: normal; font-var |
| </div>                               | iant: normal; font-weight: normal; f |
|                                      | ont-stretch: normal; font-size: 14px |
| <div                                 | ; font-family: Consolas, "Bitstream  |
| style="background: none 0% 0% / auto | Vera Sans Mono", "Courier New", Cour |
|  repeat scroll padding-box border-bo | ier, monospace; line-height: 15.4px; |
| x rgb(255, 255, 255); color: rgb(175 |  margin: 0px; padding: 0px; text-ali |
| , 175, 175); display: block; font-st | gn: left; text-decoration: none; whi |
| yle: normal; font-variant: normal; f | te-space: pre;"}                     |
| ont-weight: normal; font-stretch: no |                                      |
| rmal; font-size: 14px; font-family:  | </div>                               |
| Consolas, &quot;Bitstream Vera Sans  |                                      |
| Mono&quot;, &quot;Courier New&quot;, | <div                                 |
|  Courier, monospace; height: 15px; l | style="background: none 0% 0% / auto |
| ine-height: 15.4px; margin: 0px; out |  repeat scroll padding-box border-bo |
| line: rgb(175, 175, 175) none 0px; p | x rgb(255, 255, 255); border: 0px no |
| adding: 0px 7px 0px 14px; text-align | ne rgb(37, 37, 37); color: rgb(37, 3 |
| : right; text-decoration: none; whit | 7, 37); display: block; font-style:  |
| e-space: pre; width: 16px;">         | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
| 7                                    |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
| </div>                               | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
| <div                                 | eight: 15.4px; margin: 0px; outline: |
| style="background: none 0% 0% / auto |  rgb(37, 37, 37) none 0px; padding:  |
|  repeat scroll padding-box border-bo | 0px 14px; text-align: left; text-dec |
| x rgb(255, 255, 255); color: rgb(175 | oration: none; white-space: pre; wid |
| , 175, 175); display: block; font-st | th: 701px;">                         |
| yle: normal; font-variant: normal; f |                                      |
| ont-weight: normal; font-stretch: no | `                     `{style="borde |
| rmal; font-size: 14px; font-family:  | r: 0px none rgb(37, 37, 37); color:  |
| Consolas, &quot;Bitstream Vera Sans  | rgb(37, 37, 37); display: inline; fo |
| Mono&quot;, &quot;Courier New&quot;, | nt-style: normal; font-variant: norm |
|  Courier, monospace; height: 15px; l | al; font-weight: normal; font-stretc |
| ine-height: 15.4px; margin: 0px; out | h: normal; font-size: 14px; font-fam |
| line: rgb(175, 175, 175) none 0px; p | ily: Consolas, "Bitstream Vera Sans  |
| adding: 0px 7px 0px 14px; text-align | Mono", "Courier New", Courier, monos |
| : right; text-decoration: none; whit | pace; line-height: 15.4px; margin: 0 |
| e-space: pre; width: 16px;">         | px; outline: rgb(37, 37, 37) none 0p |
|                                      | x; padding: 0px; text-align: left; t |
| 8                                    | ext-decoration: none; white-space: p |
|                                      | re;"}`[ZLPersonModel personWithName: |
| </div>                               | @`{style="display: inline; font-styl |
|                                      | e: normal; font-variant: normal; fon |
| <div                                 | t-weight: normal; font-stretch: norm |
| style="background: none 0% 0% / auto | al; font-size: 14px; font-family: Co |
|  repeat scroll padding-box border-bo | nsolas, "Bitstream Vera Sans Mono",  |
| x rgb(255, 255, 255); color: rgb(175 | "Courier New", Courier, monospace; l |
| , 175, 175); display: block; font-st | ine-height: 15.4px; margin: 0px; pad |
| yle: normal; font-variant: normal; f | ding: 0px; text-align: left; text-de |
| ont-weight: normal; font-stretch: no | coration: none; white-space: pre;"}` |
| rmal; font-size: 14px; font-family:  | "Jackson"`{style="border: 0px none r |
| Consolas, &quot;Bitstream Vera Sans  | gb(0, 0, 255); color: rgb(0, 0, 255) |
| Mono&quot;, &quot;Courier New&quot;, | ; display: inline; font-style: norma |
|  Courier, monospace; height: 15px; l | l; font-variant: normal; font-weight |
| ine-height: 15.4px; margin: 0px; out | : normal; font-stretch: normal; font |
| line: rgb(175, 175, 175) none 0px; p | -size: 14px; font-family: Consolas,  |
| adding: 0px 7px 0px 14px; text-align | "Bitstream Vera Sans Mono", "Courier |
| : right; text-decoration: none; whit |  New", Courier, monospace; line-heig |
| e-space: pre; width: 16px;">         | ht: 15.4px; margin: 0px; outline: rg |
|                                      | b(0, 0, 255) none 0px; padding: 0px; |
| 9                                    |  text-align: left; text-decoration:  |
|                                      | none; white-space: pre;"} `age:30 se |
| </div>                               | x:ZLPersonSexMale],`{style="display: |
|                                      |  inline; font-style: normal; font-va |
| <div                                 | riant: normal; font-weight: normal;  |
| style="background: none 0% 0% / auto | font-stretch: normal; font-size: 14p |
|  repeat scroll padding-box border-bo | x; font-family: Consolas, "Bitstream |
| x rgb(255, 255, 255); color: rgb(175 |  Vera Sans Mono", "Courier New", Cou |
| , 175, 175); display: block; font-st | rier, monospace; line-height: 15.4px |
| yle: normal; font-variant: normal; f | ; margin: 0px; padding: 0px; text-al |
| ont-weight: normal; font-stretch: no | ign: left; text-decoration: none; wh |
| rmal; font-size: 14px; font-family:  | ite-space: pre;"}                    |
| Consolas, &quot;Bitstream Vera Sans  |                                      |
| Mono&quot;, &quot;Courier New&quot;, | </div>                               |
|  Courier, monospace; height: 15px; l |                                      |
| ine-height: 15.4px; margin: 0px; out | <div                                 |
| line: rgb(175, 175, 175) none 0px; p | style="background: none 0% 0% / auto |
| adding: 0px 7px 0px 14px; text-align |  repeat scroll padding-box border-bo |
| : right; text-decoration: none; whit | x rgb(255, 255, 255); border: 0px no |
| e-space: pre; width: 16px;">         | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
| 10                                   | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
| </div>                               |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
| <div                                 | quot;, &quot;Courier New&quot;, Cour |
| style="background: none 0% 0% / auto | ier, monospace; height: 15px; line-h |
|  repeat scroll padding-box border-bo | eight: 15.4px; margin: 0px; outline: |
| x rgb(255, 255, 255); color: rgb(175 |  rgb(37, 37, 37) none 0px; padding:  |
| , 175, 175); display: block; font-st | 0px 14px; text-align: left; text-dec |
| yle: normal; font-variant: normal; f | oration: none; white-space: pre; wid |
| ont-weight: normal; font-stretch: no | th: 701px;">                         |
| rmal; font-size: 14px; font-family:  |                                      |
| Consolas, &quot;Bitstream Vera Sans  | `                     `{style="borde |
| Mono&quot;, &quot;Courier New&quot;, | r: 0px none rgb(37, 37, 37); color:  |
|  Courier, monospace; height: 15px; l | rgb(37, 37, 37); display: inline; fo |
| ine-height: 15.4px; margin: 0px; out | nt-style: normal; font-variant: norm |
| line: rgb(175, 175, 175) none 0px; p | al; font-weight: normal; font-stretc |
| adding: 0px 7px 0px 14px; text-align | h: normal; font-size: 14px; font-fam |
| : right; text-decoration: none; whit | ily: Consolas, "Bitstream Vera Sans  |
| e-space: pre; width: 16px;">         | Mono", "Courier New", Courier, monos |
|                                      | pace; line-height: 15.4px; margin: 0 |
| 11                                   | px; outline: rgb(37, 37, 37) none 0p |
|                                      | x; padding: 0px; text-align: left; t |
| </div>                               | ext-decoration: none; white-space: p |
|                                      | re;"}`[ZLPersonModel personWithName: |
| <div                                 | @`{style="display: inline; font-styl |
| style="background: none 0% 0% / auto | e: normal; font-variant: normal; fon |
|  repeat scroll padding-box border-bo | t-weight: normal; font-stretch: norm |
| x rgb(255, 255, 255); color: rgb(175 | al; font-size: 14px; font-family: Co |
| , 175, 175); display: block; font-st | nsolas, "Bitstream Vera Sans Mono",  |
| yle: normal; font-variant: normal; f | "Courier New", Courier, monospace; l |
| ont-weight: normal; font-stretch: no | ine-height: 15.4px; margin: 0px; pad |
| rmal; font-size: 14px; font-family:  | ding: 0px; text-align: left; text-de |
| Consolas, &quot;Bitstream Vera Sans  | coration: none; white-space: pre;"}` |
| Mono&quot;, &quot;Courier New&quot;, | "Johnson"`{style="border: 0px none r |
|  Courier, monospace; height: 15px; l | gb(0, 0, 255); color: rgb(0, 0, 255) |
| ine-height: 15.4px; margin: 0px; out | ; display: inline; font-style: norma |
| line: rgb(175, 175, 175) none 0px; p | l; font-variant: normal; font-weight |
| adding: 0px 7px 0px 14px; text-align | : normal; font-stretch: normal; font |
| : right; text-decoration: none; whit | -size: 14px; font-family: Consolas,  |
| e-space: pre; width: 16px;">         | "Bitstream Vera Sans Mono", "Courier |
|                                      |  New", Courier, monospace; line-heig |
| 12                                   | ht: 15.4px; margin: 0px; outline: rg |
|                                      | b(0, 0, 255) none 0px; padding: 0px; |
| </div>                               |  text-align: left; text-decoration:  |
|                                      | none; white-space: pre;"} `age:35 se |
| <div                                 | x:ZLPersonSexMale]];`{style="display |
| style="background: none 0% 0% / auto | : inline; font-style: normal; font-v |
|  repeat scroll padding-box border-bo | ariant: normal; font-weight: normal; |
| x rgb(255, 255, 255); color: rgb(175 |  font-stretch: normal; font-size: 14 |
| , 175, 175); display: block; font-st | px; font-family: Consolas, "Bitstrea |
| yle: normal; font-variant: normal; f | m Vera Sans Mono", "Courier New", Co |
| ont-weight: normal; font-stretch: no | urier, monospace; line-height: 15.4p |
| rmal; font-size: 14px; font-family:  | x; margin: 0px; padding: 0px; text-a |
| Consolas, &quot;Bitstream Vera Sans  | lign: left; text-decoration: none; w |
| Mono&quot;, &quot;Courier New&quot;, | hite-space: pre;"}                   |
|  Courier, monospace; height: 15px; l |                                      |
| ine-height: 15.4px; margin: 0px; out | </div>                               |
| line: rgb(175, 175, 175) none 0px; p |                                      |
| adding: 0px 7px 0px 14px; text-align | <div                                 |
| : right; text-decoration: none; whit | style="background: none 0% 0% / auto |
| e-space: pre; width: 16px;">         |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
| 13                                   | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
| </div>                               | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
| <div                                 |  font-size: 14px; font-family: Conso |
| style="background: none 0% 0% / auto | las, &quot;Bitstream Vera Sans Mono& |
|  repeat scroll padding-box border-bo | quot;, &quot;Courier New&quot;, Cour |
| x rgb(255, 255, 255); color: rgb(175 | ier, monospace; height: 15px; line-h |
| , 175, 175); display: block; font-st | eight: 15.4px; margin: 0px; outline: |
| yle: normal; font-variant: normal; f |  rgb(37, 37, 37) none 0px; padding:  |
| ont-weight: normal; font-stretch: no | 0px 14px; text-align: left; text-dec |
| rmal; font-size: 14px; font-family:  | oration: none; white-space: pre; wid |
| Consolas, &quot;Bitstream Vera Sans  | th: 701px;">                         |
| Mono&quot;, &quot;Courier New&quot;, |                                      |
|  Courier, monospace; height: 15px; l | `  `{style="border: 0px none rgb(37, |
| ine-height: 15.4px; margin: 0px; out |  37, 37); color: rgb(37, 37, 37); di |
| line: rgb(175, 175, 175) none 0px; p | splay: inline; font-style: normal; f |
| adding: 0px 7px 0px 14px; text-align | ont-variant: normal; font-weight: no |
| : right; text-decoration: none; whit | rmal; font-stretch: normal; font-siz |
| e-space: pre; width: 16px;">         | e: 14px; font-family: Consolas, "Bit |
|                                      | stream Vera Sans Mono", "Courier New |
| 14                                   | ", Courier, monospace; line-height:  |
|                                      | 15.4px; margin: 0px; outline: rgb(37 |
| </div>                               | , 37, 37) none 0px; padding: 0px; te |
|                                      | xt-align: left; text-decoration: non |
| <div                                 | e; white-space: pre;"}`//  定义一个prope |
| style="background: none 0% 0% / auto | rty来存放属性名，定义一个value来存放值`{style="bord |
|  repeat scroll padding-box border-bo | er: 0px none rgb(0, 130, 0); color:  |
| x rgb(255, 255, 255); color: rgb(175 | rgb(0, 130, 0); display: inline; fon |
| , 175, 175); display: block; font-st | t-style: normal; font-variant: norma |
| yle: normal; font-variant: normal; f | l; font-weight: normal; font-stretch |
| ont-weight: normal; font-stretch: no | : normal; font-size: 14px; font-fami |
| rmal; font-size: 14px; font-family:  | ly: Consolas, "Bitstream Vera Sans M |
| Consolas, &quot;Bitstream Vera Sans  | ono", "Courier New", Courier, monosp |
| Mono&quot;, &quot;Courier New&quot;, | ace; line-height: 15.4px; margin: 0p |
|  Courier, monospace; height: 15px; l | x; outline: rgb(0, 130, 0) none 0px; |
| ine-height: 15.4px; margin: 0px; out |  padding: 0px; text-align: left; tex |
| line: rgb(175, 175, 175) none 0px; p | t-decoration: none; white-space: pre |
| adding: 0px 7px 0px 14px; text-align | ;"}                                  |
| : right; text-decoration: none; whit |                                      |
| e-space: pre; width: 16px;">         | </div>                               |
|                                      |                                      |
| 15                                   | <div                                 |
|                                      | style="background: none 0% 0% / auto |
| </div>                               |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
| <div                                 | ne rgb(37, 37, 37); color: rgb(37, 3 |
| style="background: none 0% 0% / auto | 7, 37); display: block; font-style:  |
|  repeat scroll padding-box border-bo | normal; font-variant: normal; font-w |
| x rgb(255, 255, 255); color: rgb(175 | eight: normal; font-stretch: normal; |
| , 175, 175); display: block; font-st |  font-size: 14px; font-family: Conso |
| yle: normal; font-variant: normal; f | las, &quot;Bitstream Vera Sans Mono& |
| ont-weight: normal; font-stretch: no | quot;, &quot;Courier New&quot;, Cour |
| rmal; font-size: 14px; font-family:  | ier, monospace; height: 15px; line-h |
| Consolas, &quot;Bitstream Vera Sans  | eight: 15.4px; margin: 0px; outline: |
| Mono&quot;, &quot;Courier New&quot;, |  rgb(37, 37, 37) none 0px; padding:  |
|  Courier, monospace; height: 15px; l | 0px 14px; text-align: left; text-dec |
| ine-height: 15.4px; margin: 0px; out | oration: none; white-space: pre; wid |
| line: rgb(175, 175, 175) none 0px; p | th: 701px;">                         |
| adding: 0px 7px 0px 14px; text-align |                                      |
| : right; text-decoration: none; whit | `  `{style="border: 0px none rgb(37, |
| e-space: pre; width: 16px;">         |  37, 37); color: rgb(37, 37, 37); di |
|                                      | splay: inline; font-style: normal; f |
| 16                                   | ont-variant: normal; font-weight: no |
|                                      | rmal; font-stretch: normal; font-siz |
| </div>                               | e: 14px; font-family: Consolas, "Bit |
|                                      | stream Vera Sans Mono", "Courier New |
| <div                                 | ", Courier, monospace; line-height:  |
| style="background: none 0% 0% / auto | 15.4px; margin: 0px; outline: rgb(37 |
|  repeat scroll padding-box border-bo | , 37, 37) none 0px; padding: 0px; te |
| x rgb(255, 255, 255); color: rgb(175 | xt-align: left; text-decoration: non |
| , 175, 175); display: block; font-st | e; white-space: pre;"}`NSString *pro |
| yle: normal; font-variant: normal; f | perty = @`{style="display: inline; f |
| ont-weight: normal; font-stretch: no | ont-style: normal; font-variant: nor |
| rmal; font-size: 14px; font-family:  | mal; font-weight: normal; font-stret |
| Consolas, &quot;Bitstream Vera Sans  | ch: normal; font-size: 14px; font-fa |
| Mono&quot;, &quot;Courier New&quot;, | mily: Consolas, "Bitstream Vera Sans |
|  Courier, monospace; height: 15px; l |  Mono", "Courier New", Courier, mono |
| ine-height: 15.4px; margin: 0px; out | space; line-height: 15.4px; margin:  |
| line: rgb(175, 175, 175) none 0px; p | 0px; padding: 0px; text-align: left; |
| adding: 0px 7px 0px 14px; text-align |  text-decoration: none; white-space: |
| : right; text-decoration: none; whit |  pre;"}`"name"`{style="border: 0px n |
| e-space: pre; width: 16px;">         | one rgb(0, 0, 255); color: rgb(0, 0, |
|                                      |  255); display: inline; font-style:  |
| 17                                   | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
| </div>                               |  font-size: 14px; font-family: Conso |
|                                      | las, "Bitstream Vera Sans Mono", "Co |
| <div                                 | urier New", Courier, monospace; line |
| style="background: none 0% 0% / auto | -height: 15.4px; margin: 0px; outlin |
|  repeat scroll padding-box border-bo | e: rgb(0, 0, 255) none 0px; padding: |
| x rgb(255, 255, 255); color: rgb(175 |  0px; text-align: left; text-decorat |
| , 175, 175); display: block; font-st | ion: none; white-space: pre;"}`;`{st |
| yle: normal; font-variant: normal; f | yle="display: inline; font-style: no |
| ont-weight: normal; font-stretch: no | rmal; font-variant: normal; font-wei |
| rmal; font-size: 14px; font-family:  | ght: normal; font-stretch: normal; f |
| Consolas, &quot;Bitstream Vera Sans  | ont-size: 14px; font-family: Consola |
| Mono&quot;, &quot;Courier New&quot;, | s, "Bitstream Vera Sans Mono", "Cour |
|  Courier, monospace; height: 15px; l | ier New", Courier, monospace; line-h |
| ine-height: 15.4px; margin: 0px; out | eight: 15.4px; margin: 0px; padding: |
| line: rgb(175, 175, 175) none 0px; p |  0px; text-align: left; text-decorat |
| adding: 0px 7px 0px 14px; text-align | ion: none; white-space: pre;"}       |
| : right; text-decoration: none; whit |                                      |
| e-space: pre; width: 16px;">         | </div>                               |
|                                      |                                      |
| 18                                   | <div                                 |
|                                      | style="background: none 0% 0% / auto |
| </div>                               |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
| <div                                 | ne rgb(37, 37, 37); color: rgb(37, 3 |
| style="background: none 0% 0% / auto | 7, 37); display: block; font-style:  |
|  repeat scroll padding-box border-bo | normal; font-variant: normal; font-w |
| x rgb(255, 255, 255); color: rgb(175 | eight: normal; font-stretch: normal; |
| , 175, 175); display: block; font-st |  font-size: 14px; font-family: Conso |
| yle: normal; font-variant: normal; f | las, &quot;Bitstream Vera Sans Mono& |
| ont-weight: normal; font-stretch: no | quot;, &quot;Courier New&quot;, Cour |
| rmal; font-size: 14px; font-family:  | ier, monospace; height: 15px; line-h |
| Consolas, &quot;Bitstream Vera Sans  | eight: 15.4px; margin: 0px; outline: |
| Mono&quot;, &quot;Courier New&quot;, |  rgb(37, 37, 37) none 0px; padding:  |
|  Courier, monospace; height: 15px; l | 0px 14px; text-align: left; text-dec |
| ine-height: 15.4px; margin: 0px; out | oration: none; white-space: pre; wid |
| line: rgb(175, 175, 175) none 0px; p | th: 701px;">                         |
| adding: 0px 7px 0px 14px; text-align |                                      |
| : right; text-decoration: none; whit | `  `{style="border: 0px none rgb(37, |
| e-space: pre; width: 16px;">         |  37, 37); color: rgb(37, 37, 37); di |
|                                      | splay: inline; font-style: normal; f |
| 19                                   | ont-variant: normal; font-weight: no |
|                                      | rmal; font-stretch: normal; font-siz |
| </div>                               | e: 14px; font-family: Consolas, "Bit |
|                                      | stream Vera Sans Mono", "Courier New |
| <div                                 | ", Courier, monospace; line-height:  |
| style="background: none 0% 0% / auto | 15.4px; margin: 0px; outline: rgb(37 |
|  repeat scroll padding-box border-bo | , 37, 37) none 0px; padding: 0px; te |
| x rgb(255, 255, 255); color: rgb(175 | xt-align: left; text-decoration: non |
| , 175, 175); display: block; font-st | e; white-space: pre;"}`NSString *val |
| yle: normal; font-variant: normal; f | ue = @`{style="display: inline; font |
| ont-weight: normal; font-stretch: no | -style: normal; font-variant: normal |
| rmal; font-size: 14px; font-family:  | ; font-weight: normal; font-stretch: |
| Consolas, &quot;Bitstream Vera Sans  |  normal; font-size: 14px; font-famil |
| Mono&quot;, &quot;Courier New&quot;, | y: Consolas, "Bitstream Vera Sans Mo |
|  Courier, monospace; height: 15px; l | no", "Courier New", Courier, monospa |
| ine-height: 15.4px; margin: 0px; out | ce; line-height: 15.4px; margin: 0px |
| line: rgb(175, 175, 175) none 0px; p | ; padding: 0px; text-align: left; te |
| adding: 0px 7px 0px 14px; text-align | xt-decoration: none; white-space: pr |
| : right; text-decoration: none; whit | e;"}`"Jack"`{style="border: 0px none |
| e-space: pre; width: 16px;">         |  rgb(0, 0, 255); color: rgb(0, 0, 25 |
|                                      | 5); display: inline; font-style: nor |
| 20                                   | mal; font-variant: normal; font-weig |
|                                      | ht: normal; font-stretch: normal; fo |
| </div>                               | nt-size: 14px; font-family: Consolas |
|                                      | , "Bitstream Vera Sans Mono", "Couri |
| <div                                 | er New", Courier, monospace; line-he |
| style="background: none 0% 0% / auto | ight: 15.4px; margin: 0px; outline:  |
|  repeat scroll padding-box border-bo | rgb(0, 0, 255) none 0px; padding: 0p |
| x rgb(255, 255, 255); color: rgb(175 | x; text-align: left; text-decoration |
| , 175, 175); display: block; font-st | : none; white-space: pre;"}`;`{style |
| yle: normal; font-variant: normal; f | ="display: inline; font-style: norma |
| ont-weight: normal; font-stretch: no | l; font-variant: normal; font-weight |
| rmal; font-size: 14px; font-family:  | : normal; font-stretch: normal; font |
| Consolas, &quot;Bitstream Vera Sans  | -size: 14px; font-family: Consolas,  |
| Mono&quot;, &quot;Courier New&quot;, | "Bitstream Vera Sans Mono", "Courier |
|  Courier, monospace; height: 15px; l |  New", Courier, monospace; line-heig |
| ine-height: 15.4px; margin: 0px; out | ht: 15.4px; margin: 0px; padding: 0p |
| line: rgb(175, 175, 175) none 0px; p | x; text-align: left; text-decoration |
| adding: 0px 7px 0px 14px; text-align | : none; white-space: pre;"}          |
| : right; text-decoration: none; whit |                                      |
| e-space: pre; width: 16px;">         | </div>                               |
|                                      |                                      |
| 21                                   | <div                                 |
|                                      | style="background: none 0% 0% / auto |
| </div>                               |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
| <div                                 | ne rgb(37, 37, 37); color: rgb(37, 3 |
| style="background: none 0% 0% / auto | 7, 37); display: block; font-style:  |
|  repeat scroll padding-box border-bo | normal; font-variant: normal; font-w |
| x rgb(255, 255, 255); color: rgb(175 | eight: normal; font-stretch: normal; |
| , 175, 175); display: block; font-st |  font-size: 14px; font-family: Conso |
| yle: normal; font-variant: normal; f | las, &quot;Bitstream Vera Sans Mono& |
| ont-weight: normal; font-stretch: no | quot;, &quot;Courier New&quot;, Cour |
| rmal; font-size: 14px; font-family:  | ier, monospace; height: 15px; line-h |
| Consolas, &quot;Bitstream Vera Sans  | eight: 15.4px; margin: 0px; outline: |
| Mono&quot;, &quot;Courier New&quot;, |  rgb(37, 37, 37) none 0px; padding:  |
|  Courier, monospace; height: 15px; l | 0px 14px; text-align: left; text-dec |
| ine-height: 15.4px; margin: 0px; out | oration: none; white-space: pre; wid |
| line: rgb(175, 175, 175) none 0px; p | th: 701px;">                         |
| adding: 0px 7px 0px 14px; text-align |                                      |
| : right; text-decoration: none; whit | `  `{style="border: 0px none rgb(37, |
| e-space: pre; width: 16px;">         |  37, 37); color: rgb(37, 37, 37); di |
|                                      | splay: inline; font-style: normal; f |
| 22                                   | ont-variant: normal; font-weight: no |
|                                      | rmal; font-stretch: normal; font-siz |
| </div>                               | e: 14px; font-family: Consolas, "Bit |
|                                      | stream Vera Sans Mono", "Courier New |
| <div                                 | ", Courier, monospace; line-height:  |
| style="background: none 0% 0% / auto | 15.4px; margin: 0px; outline: rgb(37 |
|  repeat scroll padding-box border-bo | , 37, 37) none 0px; padding: 0px; te |
| x rgb(255, 255, 255); color: rgb(175 | xt-align: left; text-decoration: non |
| , 175, 175); display: block; font-st | e; white-space: pre;"}`//  该谓词的作用是如果 |
| yle: normal; font-variant: normal; f | 元素中property属性含有值value时就取出放入新的数组内，这里是 |
| ont-weight: normal; font-stretch: no | name包含Jack`{style="border: 0px none  |
| rmal; font-size: 14px; font-family:  | rgb(0, 130, 0); color: rgb(0, 130, 0 |
| Consolas, &quot;Bitstream Vera Sans  | ); display: inline; font-style: norm |
| Mono&quot;, &quot;Courier New&quot;, | al; font-variant: normal; font-weigh |
|  Courier, monospace; height: 15px; l | t: normal; font-stretch: normal; fon |
| ine-height: 15.4px; margin: 0px; out | t-size: 14px; font-family: Consolas, |
| line: rgb(175, 175, 175) none 0px; p |  "Bitstream Vera Sans Mono", "Courie |
| adding: 0px 7px 0px 14px; text-align | r New", Courier, monospace; line-hei |
| : right; text-decoration: none; whit | ght: 15.4px; margin: 0px; outline: r |
| e-space: pre; width: 16px;">         | gb(0, 130, 0) none 0px; padding: 0px |
|                                      | ; text-align: left; text-decoration: |
| 23                                   |  none; white-space: pre;"}           |
|                                      |                                      |
| </div>                               | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 701px;">                         |
|                                      |                                      |
|                                      | `  `{style="border: 0px none rgb(37, |
|                                      |  37, 37); color: rgb(37, 37, 37); di |
|                                      | splay: inline; font-style: normal; f |
|                                      | ont-variant: normal; font-weight: no |
|                                      | rmal; font-stretch: normal; font-siz |
|                                      | e: 14px; font-family: Consolas, "Bit |
|                                      | stream Vera Sans Mono", "Courier New |
|                                      | ", Courier, monospace; line-height:  |
|                                      | 15.4px; margin: 0px; outline: rgb(37 |
|                                      | , 37, 37) none 0px; padding: 0px; te |
|                                      | xt-align: left; text-decoration: non |
|                                      | e; white-space: pre;"}`NSPredicate * |
|                                      | pred = [NSPredicate predicateWithFor |
|                                      | mat:@`{style="display: inline; font- |
|                                      | style: normal; font-variant: normal; |
|                                      |  font-weight: normal; font-stretch:  |
|                                      | normal; font-size: 14px; font-family |
|                                      | : Consolas, "Bitstream Vera Sans Mon |
|                                      | o", "Courier New", Courier, monospac |
|                                      | e; line-height: 15.4px; margin: 0px; |
|                                      |  padding: 0px; text-align: left; tex |
|                                      | t-decoration: none; white-space: pre |
|                                      | ;"}`"%K CONTAINS %@"`{style="border: |
|                                      |  0px none rgb(0, 0, 255); color: rgb |
|                                      | (0, 0, 255); display: inline; font-s |
|                                      | tyle: normal; font-variant: normal;  |
|                                      | font-weight: normal; font-stretch: n |
|                                      | ormal; font-size: 14px; font-family: |
|                                      |  Consolas, "Bitstream Vera Sans Mono |
|                                      | ", "Courier New", Courier, monospace |
|                                      | ; line-height: 15.4px; margin: 0px;  |
|                                      | outline: rgb(0, 0, 255) none 0px; pa |
|                                      | dding: 0px; text-align: left; text-d |
|                                      | ecoration: none; white-space: pre;"} |
|                                      | `, property, value];`{style="display |
|                                      | : inline; font-style: normal; font-v |
|                                      | ariant: normal; font-weight: normal; |
|                                      |  font-stretch: normal; font-size: 14 |
|                                      | px; font-family: Consolas, "Bitstrea |
|                                      | m Vera Sans Mono", "Courier New", Co |
|                                      | urier, monospace; line-height: 15.4p |
|                                      | x; margin: 0px; padding: 0px; text-a |
|                                      | lign: left; text-decoration: none; w |
|                                      | hite-space: pre;"}                   |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 701px;">                         |
|                                      |                                      |
|                                      | `  `{style="border: 0px none rgb(37, |
|                                      |  37, 37); color: rgb(37, 37, 37); di |
|                                      | splay: inline; font-style: normal; f |
|                                      | ont-variant: normal; font-weight: no |
|                                      | rmal; font-stretch: normal; font-siz |
|                                      | e: 14px; font-family: Consolas, "Bit |
|                                      | stream Vera Sans Mono", "Courier New |
|                                      | ", Courier, monospace; line-height:  |
|                                      | 15.4px; margin: 0px; outline: rgb(37 |
|                                      | , 37, 37) none 0px; padding: 0px; te |
|                                      | xt-align: left; text-decoration: non |
|                                      | e; white-space: pre;"}`NSArray *newA |
|                                      | rray = [array filteredArrayUsingPred |
|                                      | icate:pred];`{style="display: inline |
|                                      | ; font-style: normal; font-variant:  |
|                                      | normal; font-weight: normal; font-st |
|                                      | retch: normal; font-size: 14px; font |
|                                      | -family: Consolas, "Bitstream Vera S |
|                                      | ans Mono", "Courier New", Courier, m |
|                                      | onospace; line-height: 15.4px; margi |
|                                      | n: 0px; padding: 0px; text-align: le |
|                                      | ft; text-decoration: none; white-spa |
|                                      | ce: pre;"}                           |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 701px;">                         |
|                                      |                                      |
|                                      | `  `{style="border: 0px none rgb(37, |
|                                      |  37, 37); color: rgb(37, 37, 37); di |
|                                      | splay: inline; font-style: normal; f |
|                                      | ont-variant: normal; font-weight: no |
|                                      | rmal; font-stretch: normal; font-siz |
|                                      | e: 14px; font-family: Consolas, "Bit |
|                                      | stream Vera Sans Mono", "Courier New |
|                                      | ", Courier, monospace; line-height:  |
|                                      | 15.4px; margin: 0px; outline: rgb(37 |
|                                      | , 37, 37) none 0px; padding: 0px; te |
|                                      | xt-align: left; text-decoration: non |
|                                      | e; white-space: pre;"}`NSLog(@`{styl |
|                                      | e="display: inline; font-style: norm |
|                                      | al; font-variant: normal; font-weigh |
|                                      | t: normal; font-stretch: normal; fon |
|                                      | t-size: 14px; font-family: Consolas, |
|                                      |  "Bitstream Vera Sans Mono", "Courie |
|                                      | r New", Courier, monospace; line-hei |
|                                      | ght: 15.4px; margin: 0px; padding: 0 |
|                                      | px; text-align: left; text-decoratio |
|                                      | n: none; white-space: pre;"}`"newArr |
|                                      | ay:%@"`{style="border: 0px none rgb( |
|                                      | 0, 0, 255); color: rgb(0, 0, 255); d |
|                                      | isplay: inline; font-style: normal;  |
|                                      | font-variant: normal; font-weight: n |
|                                      | ormal; font-stretch: normal; font-si |
|                                      | ze: 14px; font-family: Consolas, "Bi |
|                                      | tstream Vera Sans Mono", "Courier Ne |
|                                      | w", Courier, monospace; line-height: |
|                                      |  15.4px; margin: 0px; outline: rgb(0 |
|                                      | , 0, 255) none 0px; padding: 0px; te |
|                                      | xt-align: left; text-decoration: non |
|                                      | e; white-space: pre;"}`, newArray);` |
|                                      | {style="display: inline; font-style: |
|                                      |  normal; font-variant: normal; font- |
|                                      | weight: normal; font-stretch: normal |
|                                      | ; font-size: 14px; font-family: Cons |
|                                      | olas, "Bitstream Vera Sans Mono", "C |
|                                      | ourier New", Courier, monospace; lin |
|                                      | e-height: 15.4px; margin: 0px; paddi |
|                                      | ng: 0px; text-align: left; text-deco |
|                                      | ration: none; white-space: pre;"}    |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 701px;">                         |
|                                      |                                      |
|                                      | `  `{style="border: 0px none rgb(37, |
|                                      |  37, 37); color: rgb(37, 37, 37); di |
|                                      | splay: inline; font-style: normal; f |
|                                      | ont-variant: normal; font-weight: no |
|                                      | rmal; font-stretch: normal; font-siz |
|                                      | e: 14px; font-family: Consolas, "Bit |
|                                      | stream Vera Sans Mono", "Courier New |
|                                      | ", Courier, monospace; line-height:  |
|                                      | 15.4px; margin: 0px; outline: rgb(37 |
|                                      | , 37, 37) none 0px; padding: 0px; te |
|                                      | xt-align: left; text-decoration: non |
|                                      | e; white-space: pre;"}               |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 701px;">                         |
|                                      |                                      |
|                                      | `  `{style="border: 0px none rgb(37, |
|                                      |  37, 37); color: rgb(37, 37, 37); di |
|                                      | splay: inline; font-style: normal; f |
|                                      | ont-variant: normal; font-weight: no |
|                                      | rmal; font-stretch: normal; font-siz |
|                                      | e: 14px; font-family: Consolas, "Bit |
|                                      | stream Vera Sans Mono", "Courier New |
|                                      | ", Courier, monospace; line-height:  |
|                                      | 15.4px; margin: 0px; outline: rgb(37 |
|                                      | , 37, 37) none 0px; padding: 0px; te |
|                                      | xt-align: left; text-decoration: non |
|                                      | e; white-space: pre;"}`//  创建谓词，属性名改 |
|                                      | 为age，要求这个age包含$VALUE字符串`{style="bord |
|                                      | er: 0px none rgb(0, 130, 0); color:  |
|                                      | rgb(0, 130, 0); display: inline; fon |
|                                      | t-style: normal; font-variant: norma |
|                                      | l; font-weight: normal; font-stretch |
|                                      | : normal; font-size: 14px; font-fami |
|                                      | ly: Consolas, "Bitstream Vera Sans M |
|                                      | ono", "Courier New", Courier, monosp |
|                                      | ace; line-height: 15.4px; margin: 0p |
|                                      | x; outline: rgb(0, 130, 0) none 0px; |
|                                      |  padding: 0px; text-align: left; tex |
|                                      | t-decoration: none; white-space: pre |
|                                      | ;"}                                  |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 701px;">                         |
|                                      |                                      |
|                                      | `  `{style="border: 0px none rgb(37, |
|                                      |  37, 37); color: rgb(37, 37, 37); di |
|                                      | splay: inline; font-style: normal; f |
|                                      | ont-variant: normal; font-weight: no |
|                                      | rmal; font-stretch: normal; font-siz |
|                                      | e: 14px; font-family: Consolas, "Bit |
|                                      | stream Vera Sans Mono", "Courier New |
|                                      | ", Courier, monospace; line-height:  |
|                                      | 15.4px; margin: 0px; outline: rgb(37 |
|                                      | , 37, 37) none 0px; padding: 0px; te |
|                                      | xt-align: left; text-decoration: non |
|                                      | e; white-space: pre;"}`NSPredicate * |
|                                      | predTemp = [NSPredicate predicateWit |
|                                      | hFormat:@`{style="display: inline; f |
|                                      | ont-style: normal; font-variant: nor |
|                                      | mal; font-weight: normal; font-stret |
|                                      | ch: normal; font-size: 14px; font-fa |
|                                      | mily: Consolas, "Bitstream Vera Sans |
|                                      |  Mono", "Courier New", Courier, mono |
|                                      | space; line-height: 15.4px; margin:  |
|                                      | 0px; padding: 0px; text-align: left; |
|                                      |  text-decoration: none; white-space: |
|                                      |  pre;"}`"%K > $VALUE"`{style="border |
|                                      | : 0px none rgb(0, 0, 255); color: rg |
|                                      | b(0, 0, 255); display: inline; font- |
|                                      | style: normal; font-variant: normal; |
|                                      |  font-weight: normal; font-stretch:  |
|                                      | normal; font-size: 14px; font-family |
|                                      | : Consolas, "Bitstream Vera Sans Mon |
|                                      | o", "Courier New", Courier, monospac |
|                                      | e; line-height: 15.4px; margin: 0px; |
|                                      |  outline: rgb(0, 0, 255) none 0px; p |
|                                      | adding: 0px; text-align: left; text- |
|                                      | decoration: none; white-space: pre;" |
|                                      | }`, @`{style="display: inline; font- |
|                                      | style: normal; font-variant: normal; |
|                                      |  font-weight: normal; font-stretch:  |
|                                      | normal; font-size: 14px; font-family |
|                                      | : Consolas, "Bitstream Vera Sans Mon |
|                                      | o", "Courier New", Courier, monospac |
|                                      | e; line-height: 15.4px; margin: 0px; |
|                                      |  padding: 0px; text-align: left; tex |
|                                      | t-decoration: none; white-space: pre |
|                                      | ;"}`"age"`{style="border: 0px none r |
|                                      | gb(0, 0, 255); color: rgb(0, 0, 255) |
|                                      | ; display: inline; font-style: norma |
|                                      | l; font-variant: normal; font-weight |
|                                      | : normal; font-stretch: normal; font |
|                                      | -size: 14px; font-family: Consolas,  |
|                                      | "Bitstream Vera Sans Mono", "Courier |
|                                      |  New", Courier, monospace; line-heig |
|                                      | ht: 15.4px; margin: 0px; outline: rg |
|                                      | b(0, 0, 255) none 0px; padding: 0px; |
|                                      |  text-align: left; text-decoration:  |
|                                      | none; white-space: pre;"}`];`{style= |
|                                      | "display: inline; font-style: normal |
|                                      | ; font-variant: normal; font-weight: |
|                                      |  normal; font-stretch: normal; font- |
|                                      | size: 14px; font-family: Consolas, " |
|                                      | Bitstream Vera Sans Mono", "Courier  |
|                                      | New", Courier, monospace; line-heigh |
|                                      | t: 15.4px; margin: 0px; padding: 0px |
|                                      | ; text-align: left; text-decoration: |
|                                      |  none; white-space: pre;"}           |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 701px;">                         |
|                                      |                                      |
|                                      | `  `{style="border: 0px none rgb(37, |
|                                      |  37, 37); color: rgb(37, 37, 37); di |
|                                      | splay: inline; font-style: normal; f |
|                                      | ont-variant: normal; font-weight: no |
|                                      | rmal; font-stretch: normal; font-siz |
|                                      | e: 14px; font-family: Consolas, "Bit |
|                                      | stream Vera Sans Mono", "Courier New |
|                                      | ", Courier, monospace; line-height:  |
|                                      | 15.4px; margin: 0px; outline: rgb(37 |
|                                      | , 37, 37) none 0px; padding: 0px; te |
|                                      | xt-align: left; text-decoration: non |
|                                      | e; white-space: pre;"}`// 指定$SUBSTR的 |
|                                      | 值为 25    这里注释中的$SUBSTR改为$VALUE`{styl |
|                                      | e="border: 0px none rgb(0, 130, 0);  |
|                                      | color: rgb(0, 130, 0); display: inli |
|                                      | ne; font-style: normal; font-variant |
|                                      | : normal; font-weight: normal; font- |
|                                      | stretch: normal; font-size: 14px; fo |
|                                      | nt-family: Consolas, "Bitstream Vera |
|                                      |  Sans Mono", "Courier New", Courier, |
|                                      |  monospace; line-height: 15.4px; mar |
|                                      | gin: 0px; outline: rgb(0, 130, 0) no |
|                                      | ne 0px; padding: 0px; text-align: le |
|                                      | ft; text-decoration: none; white-spa |
|                                      | ce: pre;"}                           |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 701px;">                         |
|                                      |                                      |
|                                      | `  `{style="border: 0px none rgb(37, |
|                                      |  37, 37); color: rgb(37, 37, 37); di |
|                                      | splay: inline; font-style: normal; f |
|                                      | ont-variant: normal; font-weight: no |
|                                      | rmal; font-stretch: normal; font-siz |
|                                      | e: 14px; font-family: Consolas, "Bit |
|                                      | stream Vera Sans Mono", "Courier New |
|                                      | ", Courier, monospace; line-height:  |
|                                      | 15.4px; margin: 0px; outline: rgb(37 |
|                                      | , 37, 37) none 0px; padding: 0px; te |
|                                      | xt-align: left; text-decoration: non |
|                                      | e; white-space: pre;"}`NSPredicate * |
|                                      | pred1 = [predTemp predicateWithSubst |
|                                      | itutionVariables:@{@`{style="display |
|                                      | : inline; font-style: normal; font-v |
|                                      | ariant: normal; font-weight: normal; |
|                                      |  font-stretch: normal; font-size: 14 |
|                                      | px; font-family: Consolas, "Bitstrea |
|                                      | m Vera Sans Mono", "Courier New", Co |
|                                      | urier, monospace; line-height: 15.4p |
|                                      | x; margin: 0px; padding: 0px; text-a |
|                                      | lign: left; text-decoration: none; w |
|                                      | hite-space: pre;"}`"VALUE"`{style="b |
|                                      | order: 0px none rgb(0, 0, 255); colo |
|                                      | r: rgb(0, 0, 255); display: inline;  |
|                                      | font-style: normal; font-variant: no |
|                                      | rmal; font-weight: normal; font-stre |
|                                      | tch: normal; font-size: 14px; font-f |
|                                      | amily: Consolas, "Bitstream Vera San |
|                                      | s Mono", "Courier New", Courier, mon |
|                                      | ospace; line-height: 15.4px; margin: |
|                                      |  0px; outline: rgb(0, 0, 255) none 0 |
|                                      | px; padding: 0px; text-align: left;  |
|                                      | text-decoration: none; white-space:  |
|                                      | pre;"} `: @25}];`{style="display: in |
|                                      | line; font-style: normal; font-varia |
|                                      | nt: normal; font-weight: normal; fon |
|                                      | t-stretch: normal; font-size: 14px;  |
|                                      | font-family: Consolas, "Bitstream Ve |
|                                      | ra Sans Mono", "Courier New", Courie |
|                                      | r, monospace; line-height: 15.4px; m |
|                                      | argin: 0px; padding: 0px; text-align |
|                                      | : left; text-decoration: none; white |
|                                      | -space: pre;"}                       |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 701px;">                         |
|                                      |                                      |
|                                      | `  `{style="border: 0px none rgb(37, |
|                                      |  37, 37); color: rgb(37, 37, 37); di |
|                                      | splay: inline; font-style: normal; f |
|                                      | ont-variant: normal; font-weight: no |
|                                      | rmal; font-stretch: normal; font-siz |
|                                      | e: 14px; font-family: Consolas, "Bit |
|                                      | stream Vera Sans Mono", "Courier New |
|                                      | ", Courier, monospace; line-height:  |
|                                      | 15.4px; margin: 0px; outline: rgb(37 |
|                                      | , 37, 37) none 0px; padding: 0px; te |
|                                      | xt-align: left; text-decoration: non |
|                                      | e; white-space: pre;"}`NSArray *newA |
|                                      | rray1 = [array filteredArrayUsingPre |
|                                      | dicate:pred1];`{style="display: inli |
|                                      | ne; font-style: normal; font-variant |
|                                      | : normal; font-weight: normal; font- |
|                                      | stretch: normal; font-size: 14px; fo |
|                                      | nt-family: Consolas, "Bitstream Vera |
|                                      |  Sans Mono", "Courier New", Courier, |
|                                      |  monospace; line-height: 15.4px; mar |
|                                      | gin: 0px; padding: 0px; text-align:  |
|                                      | left; text-decoration: none; white-s |
|                                      | pace: pre;"}                         |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 701px;">                         |
|                                      |                                      |
|                                      | `  `{style="border: 0px none rgb(37, |
|                                      |  37, 37); color: rgb(37, 37, 37); di |
|                                      | splay: inline; font-style: normal; f |
|                                      | ont-variant: normal; font-weight: no |
|                                      | rmal; font-stretch: normal; font-siz |
|                                      | e: 14px; font-family: Consolas, "Bit |
|                                      | stream Vera Sans Mono", "Courier New |
|                                      | ", Courier, monospace; line-height:  |
|                                      | 15.4px; margin: 0px; outline: rgb(37 |
|                                      | , 37, 37) none 0px; padding: 0px; te |
|                                      | xt-align: left; text-decoration: non |
|                                      | e; white-space: pre;"}`NSLog(@`{styl |
|                                      | e="display: inline; font-style: norm |
|                                      | al; font-variant: normal; font-weigh |
|                                      | t: normal; font-stretch: normal; fon |
|                                      | t-size: 14px; font-family: Consolas, |
|                                      |  "Bitstream Vera Sans Mono", "Courie |
|                                      | r New", Courier, monospace; line-hei |
|                                      | ght: 15.4px; margin: 0px; padding: 0 |
|                                      | px; text-align: left; text-decoratio |
|                                      | n: none; white-space: pre;"}`"newArr |
|                                      | ay1:%@"`{style="border: 0px none rgb |
|                                      | (0, 0, 255); color: rgb(0, 0, 255);  |
|                                      | display: inline; font-style: normal; |
|                                      |  font-variant: normal; font-weight:  |
|                                      | normal; font-stretch: normal; font-s |
|                                      | ize: 14px; font-family: Consolas, "B |
|                                      | itstream Vera Sans Mono", "Courier N |
|                                      | ew", Courier, monospace; line-height |
|                                      | : 15.4px; margin: 0px; outline: rgb( |
|                                      | 0, 0, 255) none 0px; padding: 0px; t |
|                                      | ext-align: left; text-decoration: no |
|                                      | ne; white-space: pre;"}`, newArray1) |
|                                      | ;`{style="display: inline; font-styl |
|                                      | e: normal; font-variant: normal; fon |
|                                      | t-weight: normal; font-stretch: norm |
|                                      | al; font-size: 14px; font-family: Co |
|                                      | nsolas, "Bitstream Vera Sans Mono",  |
|                                      | "Courier New", Courier, monospace; l |
|                                      | ine-height: 15.4px; margin: 0px; pad |
|                                      | ding: 0px; text-align: left; text-de |
|                                      | coration: none; white-space: pre;"}  |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 701px;">                         |
|                                      |                                      |
|                                      | `  `{style="border: 0px none rgb(37, |
|                                      |  37, 37); color: rgb(37, 37, 37); di |
|                                      | splay: inline; font-style: normal; f |
|                                      | ont-variant: normal; font-weight: no |
|                                      | rmal; font-stretch: normal; font-siz |
|                                      | e: 14px; font-family: Consolas, "Bit |
|                                      | stream Vera Sans Mono", "Courier New |
|                                      | ", Courier, monospace; line-height:  |
|                                      | 15.4px; margin: 0px; outline: rgb(37 |
|                                      | , 37, 37) none 0px; padding: 0px; te |
|                                      | xt-align: left; text-decoration: non |
|                                      | e; white-space: pre;"}               |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 701px;">                         |
|                                      |                                      |
|                                      | `  `{style="border: 0px none rgb(37, |
|                                      |  37, 37); color: rgb(37, 37, 37); di |
|                                      | splay: inline; font-style: normal; f |
|                                      | ont-variant: normal; font-weight: no |
|                                      | rmal; font-stretch: normal; font-siz |
|                                      | e: 14px; font-family: Consolas, "Bit |
|                                      | stream Vera Sans Mono", "Courier New |
|                                      | ", Courier, monospace; line-height:  |
|                                      | 15.4px; margin: 0px; outline: rgb(37 |
|                                      | , 37, 37) none 0px; padding: 0px; te |
|                                      | xt-align: left; text-decoration: non |
|                                      | e; white-space: pre;"}`//  修改 $SUBST |
|                                      | R的值为32，  这里注释中的SUBSTR改为$VALUE`{style |
|                                      | ="border: 0px none rgb(0, 130, 0); c |
|                                      | olor: rgb(0, 130, 0); display: inlin |
|                                      | e; font-style: normal; font-variant: |
|                                      |  normal; font-weight: normal; font-s |
|                                      | tretch: normal; font-size: 14px; fon |
|                                      | t-family: Consolas, "Bitstream Vera  |
|                                      | Sans Mono", "Courier New", Courier,  |
|                                      | monospace; line-height: 15.4px; marg |
|                                      | in: 0px; outline: rgb(0, 130, 0) non |
|                                      | e 0px; padding: 0px; text-align: lef |
|                                      | t; text-decoration: none; white-spac |
|                                      | e: pre;"}                            |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 701px;">                         |
|                                      |                                      |
|                                      | `  `{style="border: 0px none rgb(37, |
|                                      |  37, 37); color: rgb(37, 37, 37); di |
|                                      | splay: inline; font-style: normal; f |
|                                      | ont-variant: normal; font-weight: no |
|                                      | rmal; font-stretch: normal; font-siz |
|                                      | e: 14px; font-family: Consolas, "Bit |
|                                      | stream Vera Sans Mono", "Courier New |
|                                      | ", Courier, monospace; line-height:  |
|                                      | 15.4px; margin: 0px; outline: rgb(37 |
|                                      | , 37, 37) none 0px; padding: 0px; te |
|                                      | xt-align: left; text-decoration: non |
|                                      | e; white-space: pre;"}`NSPredicate * |
|                                      | pred2 = [predTemp predicateWithSubst |
|                                      | itutionVariables:@{@`{style="display |
|                                      | : inline; font-style: normal; font-v |
|                                      | ariant: normal; font-weight: normal; |
|                                      |  font-stretch: normal; font-size: 14 |
|                                      | px; font-family: Consolas, "Bitstrea |
|                                      | m Vera Sans Mono", "Courier New", Co |
|                                      | urier, monospace; line-height: 15.4p |
|                                      | x; margin: 0px; padding: 0px; text-a |
|                                      | lign: left; text-decoration: none; w |
|                                      | hite-space: pre;"}`"VALUE"`{style="b |
|                                      | order: 0px none rgb(0, 0, 255); colo |
|                                      | r: rgb(0, 0, 255); display: inline;  |
|                                      | font-style: normal; font-variant: no |
|                                      | rmal; font-weight: normal; font-stre |
|                                      | tch: normal; font-size: 14px; font-f |
|                                      | amily: Consolas, "Bitstream Vera San |
|                                      | s Mono", "Courier New", Courier, mon |
|                                      | ospace; line-height: 15.4px; margin: |
|                                      |  0px; outline: rgb(0, 0, 255) none 0 |
|                                      | px; padding: 0px; text-align: left;  |
|                                      | text-decoration: none; white-space:  |
|                                      | pre;"} `: @32}];`{style="display: in |
|                                      | line; font-style: normal; font-varia |
|                                      | nt: normal; font-weight: normal; fon |
|                                      | t-stretch: normal; font-size: 14px;  |
|                                      | font-family: Consolas, "Bitstream Ve |
|                                      | ra Sans Mono", "Courier New", Courie |
|                                      | r, monospace; line-height: 15.4px; m |
|                                      | argin: 0px; padding: 0px; text-align |
|                                      | : left; text-decoration: none; white |
|                                      | -space: pre;"}                       |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 701px;">                         |
|                                      |                                      |
|                                      | `  `{style="border: 0px none rgb(37, |
|                                      |  37, 37); color: rgb(37, 37, 37); di |
|                                      | splay: inline; font-style: normal; f |
|                                      | ont-variant: normal; font-weight: no |
|                                      | rmal; font-stretch: normal; font-siz |
|                                      | e: 14px; font-family: Consolas, "Bit |
|                                      | stream Vera Sans Mono", "Courier New |
|                                      | ", Courier, monospace; line-height:  |
|                                      | 15.4px; margin: 0px; outline: rgb(37 |
|                                      | , 37, 37) none 0px; padding: 0px; te |
|                                      | xt-align: left; text-decoration: non |
|                                      | e; white-space: pre;"}`NSArray *newA |
|                                      | rray2 = [array filteredArrayUsingPre |
|                                      | dicate:pred2];`{style="display: inli |
|                                      | ne; font-style: normal; font-variant |
|                                      | : normal; font-weight: normal; font- |
|                                      | stretch: normal; font-size: 14px; fo |
|                                      | nt-family: Consolas, "Bitstream Vera |
|                                      |  Sans Mono", "Courier New", Courier, |
|                                      |  monospace; line-height: 15.4px; mar |
|                                      | gin: 0px; padding: 0px; text-align:  |
|                                      | left; text-decoration: none; white-s |
|                                      | pace: pre;"}                         |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 701px;">                         |
|                                      |                                      |
|                                      | `  `{style="border: 0px none rgb(37, |
|                                      |  37, 37); color: rgb(37, 37, 37); di |
|                                      | splay: inline; font-style: normal; f |
|                                      | ont-variant: normal; font-weight: no |
|                                      | rmal; font-stretch: normal; font-siz |
|                                      | e: 14px; font-family: Consolas, "Bit |
|                                      | stream Vera Sans Mono", "Courier New |
|                                      | ", Courier, monospace; line-height:  |
|                                      | 15.4px; margin: 0px; outline: rgb(37 |
|                                      | , 37, 37) none 0px; padding: 0px; te |
|                                      | xt-align: left; text-decoration: non |
|                                      | e; white-space: pre;"}`NSLog(@`{styl |
|                                      | e="display: inline; font-style: norm |
|                                      | al; font-variant: normal; font-weigh |
|                                      | t: normal; font-stretch: normal; fon |
|                                      | t-size: 14px; font-family: Consolas, |
|                                      |  "Bitstream Vera Sans Mono", "Courie |
|                                      | r New", Courier, monospace; line-hei |
|                                      | ght: 15.4px; margin: 0px; padding: 0 |
|                                      | px; text-align: left; text-decoratio |
|                                      | n: none; white-space: pre;"}`"newArr |
|                                      | ay2:%@"`{style="border: 0px none rgb |
|                                      | (0, 0, 255); color: rgb(0, 0, 255);  |
|                                      | display: inline; font-style: normal; |
|                                      |  font-variant: normal; font-weight:  |
|                                      | normal; font-stretch: normal; font-s |
|                                      | ize: 14px; font-family: Consolas, "B |
|                                      | itstream Vera Sans Mono", "Courier N |
|                                      | ew", Courier, monospace; line-height |
|                                      | : 15.4px; margin: 0px; outline: rgb( |
|                                      | 0, 0, 255) none 0px; padding: 0px; t |
|                                      | ext-align: left; text-decoration: no |
|                                      | ne; white-space: pre;"}`, newArray2) |
|                                      | ;`{style="display: inline; font-styl |
|                                      | e: normal; font-variant: normal; fon |
|                                      | t-weight: normal; font-stretch: norm |
|                                      | al; font-size: 14px; font-family: Co |
|                                      | nsolas, "Bitstream Vera Sans Mono",  |
|                                      | "Courier New", Courier, monospace; l |
|                                      | ine-height: 15.4px; margin: 0px; pad |
|                                      | ding: 0px; text-align: left; text-de |
|                                      | coration: none; white-space: pre;"}  |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+

</div>

</div>

<span
style="border: 0px none rgb(37, 37, 37); color: rgb(37, 37, 37); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; line-height: 25.2px; margin: 0px; outline: rgb(37, 37, 37) none 0px; padding: 0px; text-decoration: none;">输出为</span>

<div
style="border: 0px none rgb(37, 37, 37); color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 165px; line-height: 28px; margin: 0px; outline: rgb(37, 37, 37) none 0px; padding: 0px; text-decoration: none; width: 720px;">

<div
style="background: none 0% 0% / auto repeat scroll padding-box border-box rgb(255, 255, 255); border: 0px none rgb(37, 37, 37); bottom: 0px; color: rgb(37, 37, 37); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: &quot;Helvetica Neue&quot;, Helvetica, STheiti, 微软雅黑, 黑体, Arial, Tahoma, sans-serif, serif; height: 165px; left: 0px; line-height: 28px; margin: 14px 0px; outline: rgb(37, 37, 37) none 0px; overflow: auto; padding: 0px; position: relative; right: 0px; text-decoration: none; top: 0px; width: 703px;">

+--------------------------------------+--------------------------------------+
| <div                                 | <div                                 |
| style="background: none 0% 0% / auto | style="border: 0px none rgb(37, 37,  |
|  repeat scroll padding-box border-bo | 37); bottom: 0px; color: rgb(37, 37, |
| x rgb(255, 255, 255); color: rgb(175 |  37); display: block; font-style: no |
| , 175, 175); display: block; font-st | rmal; font-variant: normal; font-wei |
| yle: normal; font-variant: normal; f | ght: normal; font-stretch: normal; f |
| ont-weight: normal; font-stretch: no | ont-size: 14px; font-family: Consola |
| rmal; font-size: 14px; font-family:  | s, &quot;Bitstream Vera Sans Mono&qu |
| Consolas, &quot;Bitstream Vera Sans  | ot;, &quot;Courier New&quot;, Courie |
| Mono&quot;, &quot;Courier New&quot;, | r, monospace; height: 165px; left: 0 |
|  Courier, monospace; height: 15px; l | px; line-height: 15.4px; margin: 0px |
| ine-height: 15.4px; margin: 0px; out | ; outline: rgb(37, 37, 37) none 0px; |
| line: rgb(175, 175, 175) none 0px; p |  padding: 0px; position: relative; r |
| adding: 0px 7px 0px 14px; text-align | ight: 0px; text-align: left; text-de |
| : right; text-decoration: none; whit | coration: none; top: 0px; width: 663 |
| e-space: pre; width: 16px;">         | px;">                                |
|                                      |                                      |
| 1                                    | <div                                 |
|                                      | style="background: none 0% 0% / auto |
| </div>                               |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
| <div                                 | ne rgb(37, 37, 37); color: rgb(37, 3 |
| style="background: none 0% 0% / auto | 7, 37); display: block; font-style:  |
|  repeat scroll padding-box border-bo | normal; font-variant: normal; font-w |
| x rgb(255, 255, 255); color: rgb(175 | eight: normal; font-stretch: normal; |
| , 175, 175); display: block; font-st |  font-size: 14px; font-family: Conso |
| yle: normal; font-variant: normal; f | las, &quot;Bitstream Vera Sans Mono& |
| ont-weight: normal; font-stretch: no | quot;, &quot;Courier New&quot;, Cour |
| rmal; font-size: 14px; font-family:  | ier, monospace; height: 15px; line-h |
| Consolas, &quot;Bitstream Vera Sans  | eight: 15.4px; margin: 0px; outline: |
| Mono&quot;, &quot;Courier New&quot;, |  rgb(37, 37, 37) none 0px; padding:  |
|  Courier, monospace; height: 15px; l | 0px 14px; text-align: left; text-dec |
| ine-height: 15.4px; margin: 0px; out | oration: none; white-space: pre; wid |
| line: rgb(175, 175, 175) none 0px; p | th: 635px;">                         |
| adding: 0px 7px 0px 14px; text-align |                                      |
| : right; text-decoration: none; whit | `2016-01-07 17:28:02.062 PredicteDem |
| e-space: pre; width: 16px;">         | o[14542:309494] newArray:(`{style="d |
|                                      | isplay: inline; font-style: normal;  |
| 2                                    | font-variant: normal; font-weight: n |
|                                      | ormal; font-stretch: normal; font-si |
| </div>                               | ze: 14px; font-family: Consolas, "Bi |
|                                      | tstream Vera Sans Mono", "Courier Ne |
| <div                                 | w", Courier, monospace; line-height: |
| style="background: none 0% 0% / auto |  15.4px; margin: 0px; padding: 0px;  |
|  repeat scroll padding-box border-bo | text-align: left; text-decoration: n |
| x rgb(255, 255, 255); color: rgb(175 | one; white-space: pre;"}             |
| , 175, 175); display: block; font-st |                                      |
| yle: normal; font-variant: normal; f | </div>                               |
| ont-weight: normal; font-stretch: no |                                      |
| rmal; font-size: 14px; font-family:  | <div                                 |
| Consolas, &quot;Bitstream Vera Sans  | style="background: none 0% 0% / auto |
| Mono&quot;, &quot;Courier New&quot;, |  repeat scroll padding-box border-bo |
|  Courier, monospace; height: 15px; l | x rgb(255, 255, 255); border: 0px no |
| ine-height: 15.4px; margin: 0px; out | ne rgb(37, 37, 37); color: rgb(37, 3 |
| line: rgb(175, 175, 175) none 0px; p | 7, 37); display: block; font-style:  |
| adding: 0px 7px 0px 14px; text-align | normal; font-variant: normal; font-w |
| : right; text-decoration: none; whit | eight: normal; font-stretch: normal; |
| e-space: pre; width: 16px;">         |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
| 3                                    | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
| </div>                               | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
| <div                                 | 0px 14px; text-align: left; text-dec |
| style="background: none 0% 0% / auto | oration: none; white-space: pre; wid |
|  repeat scroll padding-box border-bo | th: 635px;">                         |
| x rgb(255, 255, 255); color: rgb(175 |                                      |
| , 175, 175); display: block; font-st | `  `{style="border: 0px none rgb(37, |
| yle: normal; font-variant: normal; f |  37, 37); color: rgb(37, 37, 37); di |
| ont-weight: normal; font-stretch: no | splay: inline; font-style: normal; f |
| rmal; font-size: 14px; font-family:  | ont-variant: normal; font-weight: no |
| Consolas, &quot;Bitstream Vera Sans  | rmal; font-stretch: normal; font-siz |
| Mono&quot;, &quot;Courier New&quot;, | e: 14px; font-family: Consolas, "Bit |
|  Courier, monospace; height: 15px; l | stream Vera Sans Mono", "Courier New |
| ine-height: 15.4px; margin: 0px; out | ", Courier, monospace; line-height:  |
| line: rgb(175, 175, 175) none 0px; p | 15.4px; margin: 0px; outline: rgb(37 |
| adding: 0px 7px 0px 14px; text-align | , 37, 37) none 0px; padding: 0px; te |
| : right; text-decoration: none; whit | xt-align: left; text-decoration: non |
| e-space: pre; width: 16px;">         | e; white-space: pre;"}`"[name = Jack |
|                                      | , age = 20, sex = 0]"`{style="border |
| 4                                    | : 0px none rgb(0, 0, 255); color: rg |
|                                      | b(0, 0, 255); display: inline; font- |
| </div>                               | style: normal; font-variant: normal; |
|                                      |  font-weight: normal; font-stretch:  |
| <div                                 | normal; font-size: 14px; font-family |
| style="background: none 0% 0% / auto | : Consolas, "Bitstream Vera Sans Mon |
|  repeat scroll padding-box border-bo | o", "Courier New", Courier, monospac |
| x rgb(255, 255, 255); color: rgb(175 | e; line-height: 15.4px; margin: 0px; |
| , 175, 175); display: block; font-st |  outline: rgb(0, 0, 255) none 0px; p |
| yle: normal; font-variant: normal; f | adding: 0px; text-align: left; text- |
| ont-weight: normal; font-stretch: no | decoration: none; white-space: pre;" |
| rmal; font-size: 14px; font-family:  | }`,`{style="display: inline; font-st |
| Consolas, &quot;Bitstream Vera Sans  | yle: normal; font-variant: normal; f |
| Mono&quot;, &quot;Courier New&quot;, | ont-weight: normal; font-stretch: no |
|  Courier, monospace; height: 15px; l | rmal; font-size: 14px; font-family:  |
| ine-height: 15.4px; margin: 0px; out | Consolas, "Bitstream Vera Sans Mono" |
| line: rgb(175, 175, 175) none 0px; p | , "Courier New", Courier, monospace; |
| adding: 0px 7px 0px 14px; text-align |  line-height: 15.4px; margin: 0px; p |
| : right; text-decoration: none; whit | adding: 0px; text-align: left; text- |
| e-space: pre; width: 16px;">         | decoration: none; white-space: pre;" |
|                                      | }                                    |
| 5                                    |                                      |
|                                      | </div>                               |
| </div>                               |                                      |
|                                      | <div                                 |
| <div                                 | style="background: none 0% 0% / auto |
| style="background: none 0% 0% / auto |  repeat scroll padding-box border-bo |
|  repeat scroll padding-box border-bo | x rgb(255, 255, 255); border: 0px no |
| x rgb(255, 255, 255); color: rgb(175 | ne rgb(37, 37, 37); color: rgb(37, 3 |
| , 175, 175); display: block; font-st | 7, 37); display: block; font-style:  |
| yle: normal; font-variant: normal; f | normal; font-variant: normal; font-w |
| ont-weight: normal; font-stretch: no | eight: normal; font-stretch: normal; |
| rmal; font-size: 14px; font-family:  |  font-size: 14px; font-family: Conso |
| Consolas, &quot;Bitstream Vera Sans  | las, &quot;Bitstream Vera Sans Mono& |
| Mono&quot;, &quot;Courier New&quot;, | quot;, &quot;Courier New&quot;, Cour |
|  Courier, monospace; height: 15px; l | ier, monospace; height: 15px; line-h |
| ine-height: 15.4px; margin: 0px; out | eight: 15.4px; margin: 0px; outline: |
| line: rgb(175, 175, 175) none 0px; p |  rgb(37, 37, 37) none 0px; padding:  |
| adding: 0px 7px 0px 14px; text-align | 0px 14px; text-align: left; text-dec |
| : right; text-decoration: none; whit | oration: none; white-space: pre; wid |
| e-space: pre; width: 16px;">         | th: 635px;">                         |
|                                      |                                      |
| 6                                    | `  `{style="border: 0px none rgb(37, |
|                                      |  37, 37); color: rgb(37, 37, 37); di |
| </div>                               | splay: inline; font-style: normal; f |
|                                      | ont-variant: normal; font-weight: no |
| <div                                 | rmal; font-stretch: normal; font-siz |
| style="background: none 0% 0% / auto | e: 14px; font-family: Consolas, "Bit |
|  repeat scroll padding-box border-bo | stream Vera Sans Mono", "Courier New |
| x rgb(255, 255, 255); color: rgb(175 | ", Courier, monospace; line-height:  |
| , 175, 175); display: block; font-st | 15.4px; margin: 0px; outline: rgb(37 |
| yle: normal; font-variant: normal; f | , 37, 37) none 0px; padding: 0px; te |
| ont-weight: normal; font-stretch: no | xt-align: left; text-decoration: non |
| rmal; font-size: 14px; font-family:  | e; white-space: pre;"}`"[name = Jack |
| Consolas, &quot;Bitstream Vera Sans  | son, age = 30, sex = 0]"`{style="bor |
| Mono&quot;, &quot;Courier New&quot;, | der: 0px none rgb(0, 0, 255); color: |
|  Courier, monospace; height: 15px; l |  rgb(0, 0, 255); display: inline; fo |
| ine-height: 15.4px; margin: 0px; out | nt-style: normal; font-variant: norm |
| line: rgb(175, 175, 175) none 0px; p | al; font-weight: normal; font-stretc |
| adding: 0px 7px 0px 14px; text-align | h: normal; font-size: 14px; font-fam |
| : right; text-decoration: none; whit | ily: Consolas, "Bitstream Vera Sans  |
| e-space: pre; width: 16px;">         | Mono", "Courier New", Courier, monos |
|                                      | pace; line-height: 15.4px; margin: 0 |
| 7                                    | px; outline: rgb(0, 0, 255) none 0px |
|                                      | ; padding: 0px; text-align: left; te |
| </div>                               | xt-decoration: none; white-space: pr |
|                                      | e;"}                                 |
| <div                                 |                                      |
| style="background: none 0% 0% / auto | </div>                               |
|  repeat scroll padding-box border-bo |                                      |
| x rgb(255, 255, 255); color: rgb(175 | <div                                 |
| , 175, 175); display: block; font-st | style="background: none 0% 0% / auto |
| yle: normal; font-variant: normal; f |  repeat scroll padding-box border-bo |
| ont-weight: normal; font-stretch: no | x rgb(255, 255, 255); border: 0px no |
| rmal; font-size: 14px; font-family:  | ne rgb(37, 37, 37); color: rgb(37, 3 |
| Consolas, &quot;Bitstream Vera Sans  | 7, 37); display: block; font-style:  |
| Mono&quot;, &quot;Courier New&quot;, | normal; font-variant: normal; font-w |
|  Courier, monospace; height: 15px; l | eight: normal; font-stretch: normal; |
| ine-height: 15.4px; margin: 0px; out |  font-size: 14px; font-family: Conso |
| line: rgb(175, 175, 175) none 0px; p | las, &quot;Bitstream Vera Sans Mono& |
| adding: 0px 7px 0px 14px; text-align | quot;, &quot;Courier New&quot;, Cour |
| : right; text-decoration: none; whit | ier, monospace; height: 15px; line-h |
| e-space: pre; width: 16px;">         | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
| 8                                    | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
| </div>                               | th: 635px;">                         |
|                                      |                                      |
| <div                                 | `)`{style="display: inline; font-sty |
| style="background: none 0% 0% / auto | le: normal; font-variant: normal; fo |
|  repeat scroll padding-box border-bo | nt-weight: normal; font-stretch: nor |
| x rgb(255, 255, 255); color: rgb(175 | mal; font-size: 14px; font-family: C |
| , 175, 175); display: block; font-st | onsolas, "Bitstream Vera Sans Mono", |
| yle: normal; font-variant: normal; f |  "Courier New", Courier, monospace;  |
| ont-weight: normal; font-stretch: no | line-height: 15.4px; margin: 0px; pa |
| rmal; font-size: 14px; font-family:  | dding: 0px; text-align: left; text-d |
| Consolas, &quot;Bitstream Vera Sans  | ecoration: none; white-space: pre;"} |
| Mono&quot;, &quot;Courier New&quot;, |                                      |
|  Courier, monospace; height: 15px; l | </div>                               |
| ine-height: 15.4px; margin: 0px; out |                                      |
| line: rgb(175, 175, 175) none 0px; p | <div                                 |
| adding: 0px 7px 0px 14px; text-align | style="background: none 0% 0% / auto |
| : right; text-decoration: none; whit |  repeat scroll padding-box border-bo |
| e-space: pre; width: 16px;">         | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
| 9                                    | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
| </div>                               | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
| <div                                 | las, &quot;Bitstream Vera Sans Mono& |
| style="background: none 0% 0% / auto | quot;, &quot;Courier New&quot;, Cour |
|  repeat scroll padding-box border-bo | ier, monospace; height: 15px; line-h |
| x rgb(255, 255, 255); color: rgb(175 | eight: 15.4px; margin: 0px; outline: |
| , 175, 175); display: block; font-st |  rgb(37, 37, 37) none 0px; padding:  |
| yle: normal; font-variant: normal; f | 0px 14px; text-align: left; text-dec |
| ont-weight: normal; font-stretch: no | oration: none; white-space: pre; wid |
| rmal; font-size: 14px; font-family:  | th: 635px;">                         |
| Consolas, &quot;Bitstream Vera Sans  |                                      |
| Mono&quot;, &quot;Courier New&quot;, | `2016-01-07 17:28:02.063 PredicteDem |
|  Courier, monospace; height: 15px; l | o[14542:309494] newArray1:(`{style=" |
| ine-height: 15.4px; margin: 0px; out | display: inline; font-style: normal; |
| line: rgb(175, 175, 175) none 0px; p |  font-variant: normal; font-weight:  |
| adding: 0px 7px 0px 14px; text-align | normal; font-stretch: normal; font-s |
| : right; text-decoration: none; whit | ize: 14px; font-family: Consolas, "B |
| e-space: pre; width: 16px;">         | itstream Vera Sans Mono", "Courier N |
|                                      | ew", Courier, monospace; line-height |
| 10                                   | : 15.4px; margin: 0px; padding: 0px; |
|                                      |  text-align: left; text-decoration:  |
| </div>                               | none; white-space: pre;"}            |
|                                      |                                      |
| <div                                 | </div>                               |
| style="background: none 0% 0% / auto |                                      |
|  repeat scroll padding-box border-bo | <div                                 |
| x rgb(255, 255, 255); color: rgb(175 | style="background: none 0% 0% / auto |
| , 175, 175); display: block; font-st |  repeat scroll padding-box border-bo |
| yle: normal; font-variant: normal; f | x rgb(255, 255, 255); border: 0px no |
| ont-weight: normal; font-stretch: no | ne rgb(37, 37, 37); color: rgb(37, 3 |
| rmal; font-size: 14px; font-family:  | 7, 37); display: block; font-style:  |
| Consolas, &quot;Bitstream Vera Sans  | normal; font-variant: normal; font-w |
| Mono&quot;, &quot;Courier New&quot;, | eight: normal; font-stretch: normal; |
|  Courier, monospace; height: 15px; l |  font-size: 14px; font-family: Conso |
| ine-height: 15.4px; margin: 0px; out | las, &quot;Bitstream Vera Sans Mono& |
| line: rgb(175, 175, 175) none 0px; p | quot;, &quot;Courier New&quot;, Cour |
| adding: 0px 7px 0px 14px; text-align | ier, monospace; height: 15px; line-h |
| : right; text-decoration: none; whit | eight: 15.4px; margin: 0px; outline: |
| e-space: pre; width: 16px;">         |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
| 11                                   | oration: none; white-space: pre; wid |
|                                      | th: 635px;">                         |
| </div>                               |                                      |
|                                      | `  `{style="border: 0px none rgb(37, |
|                                      |  37, 37); color: rgb(37, 37, 37); di |
|                                      | splay: inline; font-style: normal; f |
|                                      | ont-variant: normal; font-weight: no |
|                                      | rmal; font-stretch: normal; font-siz |
|                                      | e: 14px; font-family: Consolas, "Bit |
|                                      | stream Vera Sans Mono", "Courier New |
|                                      | ", Courier, monospace; line-height:  |
|                                      | 15.4px; margin: 0px; outline: rgb(37 |
|                                      | , 37, 37) none 0px; padding: 0px; te |
|                                      | xt-align: left; text-decoration: non |
|                                      | e; white-space: pre;"}`"[name = Jack |
|                                      | son, age = 30, sex = 0]"`{style="bor |
|                                      | der: 0px none rgb(0, 0, 255); color: |
|                                      |  rgb(0, 0, 255); display: inline; fo |
|                                      | nt-style: normal; font-variant: norm |
|                                      | al; font-weight: normal; font-stretc |
|                                      | h: normal; font-size: 14px; font-fam |
|                                      | ily: Consolas, "Bitstream Vera Sans  |
|                                      | Mono", "Courier New", Courier, monos |
|                                      | pace; line-height: 15.4px; margin: 0 |
|                                      | px; outline: rgb(0, 0, 255) none 0px |
|                                      | ; padding: 0px; text-align: left; te |
|                                      | xt-decoration: none; white-space: pr |
|                                      | e;"}`,`{style="display: inline; font |
|                                      | -style: normal; font-variant: normal |
|                                      | ; font-weight: normal; font-stretch: |
|                                      |  normal; font-size: 14px; font-famil |
|                                      | y: Consolas, "Bitstream Vera Sans Mo |
|                                      | no", "Courier New", Courier, monospa |
|                                      | ce; line-height: 15.4px; margin: 0px |
|                                      | ; padding: 0px; text-align: left; te |
|                                      | xt-decoration: none; white-space: pr |
|                                      | e;"}                                 |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 635px;">                         |
|                                      |                                      |
|                                      | `  `{style="border: 0px none rgb(37, |
|                                      |  37, 37); color: rgb(37, 37, 37); di |
|                                      | splay: inline; font-style: normal; f |
|                                      | ont-variant: normal; font-weight: no |
|                                      | rmal; font-stretch: normal; font-siz |
|                                      | e: 14px; font-family: Consolas, "Bit |
|                                      | stream Vera Sans Mono", "Courier New |
|                                      | ", Courier, monospace; line-height:  |
|                                      | 15.4px; margin: 0px; outline: rgb(37 |
|                                      | , 37, 37) none 0px; padding: 0px; te |
|                                      | xt-align: left; text-decoration: non |
|                                      | e; white-space: pre;"}`"[name = John |
|                                      | son, age = 35, sex = 0]"`{style="bor |
|                                      | der: 0px none rgb(0, 0, 255); color: |
|                                      |  rgb(0, 0, 255); display: inline; fo |
|                                      | nt-style: normal; font-variant: norm |
|                                      | al; font-weight: normal; font-stretc |
|                                      | h: normal; font-size: 14px; font-fam |
|                                      | ily: Consolas, "Bitstream Vera Sans  |
|                                      | Mono", "Courier New", Courier, monos |
|                                      | pace; line-height: 15.4px; margin: 0 |
|                                      | px; outline: rgb(0, 0, 255) none 0px |
|                                      | ; padding: 0px; text-align: left; te |
|                                      | xt-decoration: none; white-space: pr |
|                                      | e;"}                                 |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 635px;">                         |
|                                      |                                      |
|                                      | `)`{style="display: inline; font-sty |
|                                      | le: normal; font-variant: normal; fo |
|                                      | nt-weight: normal; font-stretch: nor |
|                                      | mal; font-size: 14px; font-family: C |
|                                      | onsolas, "Bitstream Vera Sans Mono", |
|                                      |  "Courier New", Courier, monospace;  |
|                                      | line-height: 15.4px; margin: 0px; pa |
|                                      | dding: 0px; text-align: left; text-d |
|                                      | ecoration: none; white-space: pre;"} |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 635px;">                         |
|                                      |                                      |
|                                      | `2016-01-07 17:28:02.063 PredicteDem |
|                                      | o[14542:309494] newArray2:(`{style=" |
|                                      | display: inline; font-style: normal; |
|                                      |  font-variant: normal; font-weight:  |
|                                      | normal; font-stretch: normal; font-s |
|                                      | ize: 14px; font-family: Consolas, "B |
|                                      | itstream Vera Sans Mono", "Courier N |
|                                      | ew", Courier, monospace; line-height |
|                                      | : 15.4px; margin: 0px; padding: 0px; |
|                                      |  text-align: left; text-decoration:  |
|                                      | none; white-space: pre;"}            |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 635px;">                         |
|                                      |                                      |
|                                      | `  `{style="border: 0px none rgb(37, |
|                                      |  37, 37); color: rgb(37, 37, 37); di |
|                                      | splay: inline; font-style: normal; f |
|                                      | ont-variant: normal; font-weight: no |
|                                      | rmal; font-stretch: normal; font-siz |
|                                      | e: 14px; font-family: Consolas, "Bit |
|                                      | stream Vera Sans Mono", "Courier New |
|                                      | ", Courier, monospace; line-height:  |
|                                      | 15.4px; margin: 0px; outline: rgb(37 |
|                                      | , 37, 37) none 0px; padding: 0px; te |
|                                      | xt-align: left; text-decoration: non |
|                                      | e; white-space: pre;"}`"[name = John |
|                                      | son, age = 35, sex = 0]"`{style="bor |
|                                      | der: 0px none rgb(0, 0, 255); color: |
|                                      |  rgb(0, 0, 255); display: inline; fo |
|                                      | nt-style: normal; font-variant: norm |
|                                      | al; font-weight: normal; font-stretc |
|                                      | h: normal; font-size: 14px; font-fam |
|                                      | ily: Consolas, "Bitstream Vera Sans  |
|                                      | Mono", "Courier New", Courier, monos |
|                                      | pace; line-height: 15.4px; margin: 0 |
|                                      | px; outline: rgb(0, 0, 255) none 0px |
|                                      | ; padding: 0px; text-align: left; te |
|                                      | xt-decoration: none; white-space: pr |
|                                      | e;"}                                 |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="background: none 0% 0% / auto |
|                                      |  repeat scroll padding-box border-bo |
|                                      | x rgb(255, 255, 255); border: 0px no |
|                                      | ne rgb(37, 37, 37); color: rgb(37, 3 |
|                                      | 7, 37); display: block; font-style:  |
|                                      | normal; font-variant: normal; font-w |
|                                      | eight: normal; font-stretch: normal; |
|                                      |  font-size: 14px; font-family: Conso |
|                                      | las, &quot;Bitstream Vera Sans Mono& |
|                                      | quot;, &quot;Courier New&quot;, Cour |
|                                      | ier, monospace; height: 15px; line-h |
|                                      | eight: 15.4px; margin: 0px; outline: |
|                                      |  rgb(37, 37, 37) none 0px; padding:  |
|                                      | 0px 14px; text-align: left; text-dec |
|                                      | oration: none; white-space: pre; wid |
|                                      | th: 635px;">                         |
|                                      |                                      |
|                                      | `)`{style="display: inline; font-sty |
|                                      | le: normal; font-variant: normal; fo |
|                                      | nt-weight: normal; font-stretch: nor |
|                                      | mal; font-size: 14px; font-family: C |
|                                      | onsolas, "Bitstream Vera Sans Mono", |
|                                      |  "Courier New", Courier, monospace;  |
|                                      | line-height: 15.4px; margin: 0px; pa |
|                                      | dding: 0px; text-align: left; text-d |
|                                      | ecoration: none; white-space: pre;"} |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+

</div>

</div>

从上例中我们主要可以看出来%K和\$VALUE的含义。

那么至此NSPredicate就到到此介绍完毕。

因为本人水平有限，如果有什么好的建议请联系我。

</div>

</div>

</div>

</div>

</div>
