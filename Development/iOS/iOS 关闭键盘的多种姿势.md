<div class="post-body __reader_view_article_wrap_8712960554143683__"
itemprop="articleBody"
style="font-family: Lato, 'PingFang SC', 'Microsoft YaHei', sans-serif; text-align: justify; color: rgb(85, 85, 85); font-size: 16px; font-variant-ligatures: normal; orphans: 2; widows: 2; background-color: rgb(255, 255, 255);">

很多时候，我们需要关闭弹出的虚拟键盘，这里我们就讨论一下关闭键盘的多种方法。

[](){#more}
[](http://www.futantan.com/2015/08/28/how-to-dismiss-keyboard-in-iOS/#原理解析 "原理解析"){.headerlink}原理解析 {#原理解析 style="margin-top: 20px; margin-bottom: 15px; padding-top: 10px; line-height: 1.5; font-size: 20px;"}
---------------------------------------------------------------------------------------------------------------

[苹果官方文档](https://developer.apple.com/library/ios/documentation/UIKit/Reference/UITextField_Class/index.html)中是这么描述的：

> 在用户进行了特定的操作的时候，可能需要将键盘隐藏。如果需要在点击键盘上的`return`{style="font-family: consolas, Menlo, "PingFang SC", "Microsoft YaHei", monospace; font-size: 13px; padding: 2px 4px; word-break: break-all; color: rgb(85, 85, 85); background: rgb(238, 238, 238); border-radius: 4px;"} 按钮时隐藏，需要设置文本输入框的 `delegate`{style="font-family: consolas, Menlo, "PingFang SC", "Microsoft YaHei", monospace; font-size: 13px; padding: 2px 4px; word-break: break-all; color: rgb(85, 85, 85); background: rgb(238, 238, 238); border-radius: 4px;"}。为了隐藏按钮，需要向当前的第一响应者(first
> responder)发送 `resignFirstResponder`{style="font-family: consolas, Menlo, "PingFang SC", "Microsoft YaHei", monospace; font-size: 13px; padding: 2px 4px; word-break: break-all; color: rgb(85, 85, 85); background: rgb(238, 238, 238); border-radius: 4px;"} 消息。这样可以让该文本输入框结束当前的输入会话，并隐藏键盘。

那么问题的关键就是向第一响应者发送 `resignFirstResponder`{style="font-family: consolas, Menlo, 'PingFang SC', 'Microsoft YaHei', monospace; font-size: 13px; padding: 2px 4px; word-break: break-all; border-radius: 4px; background: rgb(238, 238, 238);"} 消息。

+--------------------------------------+--------------------------------------+
| ``` {style="overflow: auto; font-fam | ``` {style="overflow: auto; font-fam |
| ily: consolas, Menlo, 'PingFang SC', | ily: consolas, Menlo, 'PingFang SC', |
|  'Microsoft YaHei', monospace; font- |  'Microsoft YaHei', monospace; font- |
| size: 13px; margin-top: 0px; margin- | size: 13px; margin-top: 0px; margin- |
| bottom: 0px; padding: 1px 20px 1px 1 | bottom: 0px; padding: 1px; line-heig |
| px; color: rgb(102, 102, 102); line- | ht: 1.6; border: none; background: r |
| height: 1.6; border: none; text-alig | gb(247, 247, 247);"}                 |
| n: right; background: rgb(247, 247,  | [yourTextFieldName resignFirstRespon |
| 247);"}                              | der];                                |
| 1                                    | ```                                  |
| ```                                  |                                      |
+--------------------------------------+--------------------------------------+

[](http://www.futantan.com/2015/08/28/how-to-dismiss-keyboard-in-iOS/#问题 "问题"){.headerlink}问题 {#问题 style="margin-top: 20px; margin-bottom: 15px; padding-top: 10px; line-height: 1.5; font-size: 20px;"}
---------------------------------------------------------------------------------------------------

但是问题来了，如果界面上有多个文本输入框怎么办，并不知道哪个输入框才是第一响应者。

### [](http://www.futantan.com/2015/08/28/how-to-dismiss-keyboard-in-iOS/#方法一 "方法一"){.headerlink}方法一 {#方法一 style="margin-top: 20px; margin-bottom: 15px; padding-top: 10px; line-height: 1.5; font-size: 18px;"}

最直观的方法就是给每一个文本输入框都发送 `resignFirstResponder`{style="font-family: consolas, Menlo, 'PingFang SC', 'Microsoft YaHei', monospace; font-size: 13px; padding: 2px 4px; word-break: break-all; border-radius: 4px; background: rgb(238, 238, 238);"} 消息。

+--------------------------------------+--------------------------------------+
| ``` {style="overflow: auto; font-fam | ``` {style="overflow: auto; font-fam |
| ily: consolas, Menlo, 'PingFang SC', | ily: consolas, Menlo, 'PingFang SC', |
|  'Microsoft YaHei', monospace; font- |  'Microsoft YaHei', monospace; font- |
| size: 13px; margin-top: 0px; margin- | size: 13px; margin-top: 0px; margin- |
| bottom: 0px; padding: 1px 20px 1px 1 | bottom: 0px; padding: 1px; line-heig |
| px; color: rgb(102, 102, 102); line- | ht: 1.6; border: none; background: r |
| height: 1.6; border: none; text-alig | gb(247, 247, 247);"}                 |
| n: right; background: rgb(247, 247,  | [self.yourTextField1 resignFirstResp |
| 247);"}                              | onder];                              |
| 1                                    | [self.yourTextField2 resignFirstResp |
| 2                                    | onder];                              |
| 3                                    | ...                                  |
| 4                                    | [self.yourTextFieldn resignFirstResp |
| ```                                  | onder];                              |
|                                      | ```                                  |
+--------------------------------------+--------------------------------------+

### [](http://www.futantan.com/2015/08/28/how-to-dismiss-keyboard-in-iOS/#方法二 "方法二"){.headerlink}方法二 {#方法二 style="margin-top: 20px; margin-bottom: 15px; padding-top: 10px; line-height: 1.5; font-size: 18px;"}

当然，还有一种稍微聪明一些的方式，传入整个 `view`{style="font-family: consolas, Menlo, 'PingFang SC', 'Microsoft YaHei', monospace; font-size: 13px; padding: 2px 4px; word-break: break-all; border-radius: 4px; background: rgb(238, 238, 238);"}：

+--------------------------------------+--------------------------------------+
| ``` {style="overflow: auto; font-fam | ``` {style="overflow: auto; font-fam |
| ily: consolas, Menlo, 'PingFang SC', | ily: consolas, Menlo, 'PingFang SC', |
|  'Microsoft YaHei', monospace; font- |  'Microsoft YaHei', monospace; font- |
| size: 13px; margin-top: 0px; margin- | size: 13px; margin-top: 0px; margin- |
| bottom: 0px; padding: 1px 20px 1px 1 | bottom: 0px; padding: 1px; line-heig |
| px; color: rgb(102, 102, 102); line- | ht: 1.6; border: none; background: r |
| height: 1.6; border: none; text-alig | gb(247, 247, 247);"}                 |
| n: right; background: rgb(247, 247,  | UIView *resignFirstResponder(UIView  |
| 247);"}                              | *theView)                            |
| 1                                    | {                                    |
| 2                                    |     if([theView isFirstResponder])   |
| 3                                    |     {                                |
| 4                                    |         [theView resignFirstResponde |
| 5                                    | r];                                  |
| 6                                    |         return theView;              |
| 7                                    |     }                                |
| 8                                    |     for(UIView *subview in theView.s |
| 9                                    | ubviews)                             |
| 10                                   |     {                                |
| 11                                   |         UIView *result = resignFirst |
| 12                                   | Responder(subview);                  |
| 13                                   |         if(result) return result;    |
| 14                                   |     }                                |
| ```                                  |     return nil;                      |
|                                      | }                                    |
|                                      | ```                                  |
+--------------------------------------+--------------------------------------+

遍历传入的 `view`{style="font-family: consolas, Menlo, 'PingFang SC', 'Microsoft YaHei', monospace; font-size: 13px; padding: 2px 4px; word-break: break-all; border-radius: 4px; background: rgb(238, 238, 238);"} 的所有子视图，并发送 `resignFirstResponder`{style="font-family: consolas, Menlo, 'PingFang SC', 'Microsoft YaHei', monospace; font-size: 13px; padding: 2px 4px; word-break: break-all; border-radius: 4px; background: rgb(238, 238, 238);"} 消息。

### [](http://www.futantan.com/2015/08/28/how-to-dismiss-keyboard-in-iOS/#方法三 "方法三"){.headerlink}方法三 {#方法三 style="margin-top: 20px; margin-bottom: 15px; padding-top: 10px; line-height: 1.5; font-size: 18px;"}

有没有相对优雅一点的方法呢。当然，下面的方法和方法二中提供的方法原理一致，不过有造好的轮子干嘛不用呢。

+--------------------------------------+--------------------------------------+
| ``` {style="overflow: auto; font-fam | ``` {style="overflow: auto; font-fam |
| ily: consolas, Menlo, 'PingFang SC', | ily: consolas, Menlo, 'PingFang SC', |
|  'Microsoft YaHei', monospace; font- |  'Microsoft YaHei', monospace; font- |
| size: 13px; margin-top: 0px; margin- | size: 13px; margin-top: 0px; margin- |
| bottom: 0px; padding: 1px 20px 1px 1 | bottom: 0px; padding: 1px; line-heig |
| px; color: rgb(102, 102, 102); line- | ht: 1.6; border: none; background: r |
| height: 1.6; border: none; text-alig | gb(247, 247, 247);"}                 |
| n: right; background: rgb(247, 247,  | [self.view endEditing:YES];          |
| 247);"}                              | ```                                  |
| 1                                    |                                      |
| ```                                  |                                      |
+--------------------------------------+--------------------------------------+

是不是简洁明了多了！

[](http://www.futantan.com/2015/08/28/how-to-dismiss-keyboard-in-iOS/#键盘-return-键隐藏键盘 "键盘 return 键隐藏键盘"){.headerlink}键盘 `return`{style="font-family: consolas, Menlo, 'PingFang SC', 'Microsoft YaHei', monospace; font-size: 13px; padding: 2px 4px; word-break: break-all; border-radius: 4px; background: rgb(238, 238, 238);"} 键隐藏键盘 {#键盘-return-键隐藏键盘 style="margin-top: 20px; margin-bottom: 15px; padding-top: 10px; line-height: 1.5; font-size: 20px;"}
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

原理与上述方法一致，只是要求响应点击 `return`{style="font-family: consolas, Menlo, 'PingFang SC', 'Microsoft YaHei', monospace; font-size: 13px; padding: 2px 4px; word-break: break-all; border-radius: 4px; background: rgb(238, 238, 238);"} 键的事件。

1.  将 TextField 的 delegate
    设置为实现 `textFieldShouldReturn:(UITextField *)textField`{style="font-family: consolas, Menlo, 'PingFang SC', 'Microsoft YaHei', monospace; font-size: 13px; padding: 2px 4px; word-break: break-all; border-radius: 4px; background: rgb(238, 238, 238);"} 方法的类（一般为相应的
    ViewController）
2.  遵循 `UITextFieldDelegate`{style="font-family: consolas, Menlo, 'PingFang SC', 'Microsoft YaHei', monospace; font-size: 13px; padding: 2px 4px; word-break: break-all; border-radius: 4px; background: rgb(238, 238, 238);"} 协议，并实现 `textFieldShouldReturn`{style="font-family: consolas, Menlo, 'PingFang SC', 'Microsoft YaHei', monospace; font-size: 13px; padding: 2px 4px; word-break: break-all; border-radius: 4px; background: rgb(238, 238, 238);"}方法：

    +--------------------------------------+--------------------------------------+
    | ``` {style="overflow: auto; font-fam | ``` {style="overflow: auto; font-fam |
    | ily: consolas, Menlo, 'PingFang SC', | ily: consolas, Menlo, 'PingFang SC', |
    |  'Microsoft YaHei', monospace; font- |  'Microsoft YaHei', monospace; font- |
    | size: 13px; margin-top: 0px; margin- | size: 13px; margin-top: 0px; margin- |
    | bottom: 0px; padding: 1px 20px 1px 1 | bottom: 0px; padding: 1px; line-heig |
    | px; color: rgb(102, 102, 102); line- | ht: 1.6; border: none; background: r |
    | height: 1.6; border: none; text-alig | gb(247, 247, 247);"}                 |
    | n: right; background: rgb(247, 247,  | - (BOOL)textFieldShouldReturn:(UITex |
    | 247);"}                              | tField *)textField {                 |
    | 1                                    |     [textField resignFirstResponder] |
    | 2                                    | ;                                    |
    | 3                                    |     return YES;                      |
    | 4                                    | }                                    |
    | ```                                  | ```                                  |
    +--------------------------------------+--------------------------------------+

[](http://www.futantan.com/2015/08/28/how-to-dismiss-keyboard-in-iOS/#点击空白处，隐藏键盘 "点击空白处，隐藏键盘"){.headerlink}点击空白处，隐藏键盘 {#点击空白处，隐藏键盘 style="margin-top: 20px; margin-bottom: 15px; padding-top: 10px; line-height: 1.5; font-size: 20px;"}
---------------------------------------------------------------------------------------------------------------------------------------------------

有时我们需要在点击界面的空白处隐藏键盘，这是一个非常便利的操作。\
这里我们的思路是，响应点击空白处的事件，并调用相应的 `endEditing`{style="font-family: consolas, Menlo, 'PingFang SC', 'Microsoft YaHei', monospace; font-size: 13px; padding: 2px 4px; word-break: break-all; border-radius: 4px; background: rgb(238, 238, 238);"} 方法。为了响应空白处的点击事件，需要将 `xib`{style="font-family: consolas, Menlo, 'PingFang SC', 'Microsoft YaHei', monospace; font-size: 13px; padding: 2px 4px; word-break: break-all; border-radius: 4px; background: rgb(238, 238, 238);"} 文件（或 `stroyboard`{style="font-family: consolas, Menlo, 'PingFang SC', 'Microsoft YaHei', monospace; font-size: 13px; padding: 2px 4px; word-break: break-all; border-radius: 4px; background: rgb(238, 238, 238);"}）文件中响应的
View Class
改为 `UIControl`{style="font-family: consolas, Menlo, 'PingFang SC', 'Microsoft YaHei', monospace; font-size: 13px; padding: 2px 4px; word-break: break-all; border-radius: 4px; background: rgb(238, 238, 238);"}，之后设定相关的
Target-Action\
[![](iOS%20关闭键盘的多种姿势_files/0.9974319776520133.png)](http://www.futantan.com/media/14407356188460.jpg){.fancybox}\
并实现相关的方法：

+--------------------------------------+--------------------------------------+
| ``` {style="overflow: auto; font-fam | ``` {style="overflow: auto; font-fam |
| ily: consolas, Menlo, 'PingFang SC', | ily: consolas, Menlo, 'PingFang SC', |
|  'Microsoft YaHei', monospace; font- |  'Microsoft YaHei', monospace; font- |
| size: 13px; margin-top: 0px; margin- | size: 13px; margin-top: 0px; margin- |
| bottom: 0px; padding: 1px 20px 1px 1 | bottom: 0px; padding: 1px; line-heig |
| px; color: rgb(102, 102, 102); line- | ht: 1.6; border: none; background: r |
| height: 1.6; border: none; text-alig | gb(247, 247, 247);"}                 |
| n: right; background: rgb(247, 247,  | - (IBAction)backgroundTapped:(id)sen |
| 247);"}                              | der {                                |
| 1                                    |     [self.view endEditing:YES];      |
| 2                                    | }                                    |
| 3                                    | ```                                  |
| ```                                  |                                      |
+--------------------------------------+--------------------------------------+

\
<div style="color:gray">

来源： <http://www.futantan.com/2015/08/28/how-to-dismiss-keyboard-in-iOS/>

</div>

</div>

<div
style="color: rgb(85, 85, 85); font-family: Lato, 'PingFang SC', 'Microsoft YaHei', sans-serif; font-size: 16px; font-variant-ligatures: normal; orphans: 2; widows: 2; background-color: rgb(255, 255, 255);">

</div>

<div
style="color: rgb(85, 85, 85); font-family: Lato, 'PingFang SC', 'Microsoft YaHei', sans-serif; font-size: 16px; font-variant-ligatures: normal; orphans: 2; widows: 2; background-color: rgb(255, 255, 255);">

</div>
