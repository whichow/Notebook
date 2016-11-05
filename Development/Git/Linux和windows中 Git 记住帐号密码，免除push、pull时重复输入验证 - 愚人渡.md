Linux和windows中 Git 记住帐号密码，免除push、pull时重复输入验证 - 愚人渡
<div>

\
<div style="font-size: 16px">

<div>

<div
style="font-style:normal;font-variant:normal;font-weight:normal;font-stretch:normal;font-size:14px;line-height:1.14;font-family:'Microsoft YaHei', 微软雅黑, 雅黑宋体, SimSun, Helvetica, Tahoma, Arial, sans-serif;color:rgb(51, 51, 51);outline:0px;background:rgb(255, 255, 255);">

<div style="line-height:22px;letter-spacing:1px;">

<div>

[Linux和windows中 Git 记住帐号密码，免除push、pull时重复输入验证](#) {#linux和windows中-git-记住帐号密码免除pushpull时重复输入验证 style="margin:0px;padding:0px;font-size:100%;font-weight:bold;margin-bottom:10px;border-left-width:4px;border-left-style:solid;border-left-color:rgb(25, 85, 141);display:inline-block;background:rgb(239, 239, 239);"}
====================================================================

<span
style="float:right;color:rgb(136, 136, 136);font-size:13px;">Hot:18130℃
-- Poster:Echo -- Date:2014-09-24</span>
<div style="margin:0px;padding:0px;margin-top:12px;">

**<span style="color:rgb(192, 0, 0);">Linux下：</span>**

<div style="margin:0px;padding:0px;">

<div
style="padding:0px;margin:1em 0px;width:100%;position:relative;overflow:auto;font-size:1em;background-color:white;">

+--------------------------------------+--------------------------------------+
| <div                                 | <div                                 |
| style="top:auto;margin:0px;border-ra | style="right:auto;margin:0px;border- |
| dius:0px;border:0px;bottom:auto;floa | radius:0px;border:0px;bottom:auto;fl |
| t:none;height:auto;left:auto;line-he | oat:none;height:auto;left:auto;line- |
| ight:1.3em;outline:0px;overflow:visi | height:1.3em;outline:0px;overflow:vi |
| ble;position:static;right:auto;backg | sible;min-height:auto;padding:0px;te |
| round:none;min-height:auto;vertical- | xt-align:left;top:auto;vertical-alig |
| align:baseline;width:auto;box-sizing | n:baseline;width:auto;box-sizing:con |
| :content-box;font-family:Consolas, ' | tent-box;font-family:Consolas, 'Bits |
| Bitstream Vera Sans Mono', 'Courier  | tream Vera Sans Mono', 'Courier New' |
| New', Courier, monospace;font-weight | , Courier, monospace;font-weight:nor |
| :normal;font-style:normal;font-size: | mal;font-style:normal;font-size:1em; |
| 1em;white-space:pre;background-color | background:none;position:relative;"> |
| :white;border-right-width:2px;border |                                      |
| -right-style:solid;border-right-colo | <div                                 |
| r:rgb(238, 136, 34);padding:0px 0.5e | style="text-align:left;margin:0px;bo |
| m 0px 0px;text-align:right;">        | rder-radius:0px;border:0px;bottom:au |
|                                      | to;float:none;height:auto;left:auto; |
| 1                                    | line-height:1.3em;outline:0px;overfl |
|                                      | ow:visible;position:static;right:aut |
| </div>                               | o;background:none;top:auto;vertical- |
|                                      | align:baseline;width:auto;box-sizing |
| <div                                 | :content-box;font-family:Consolas, ' |
| style="top:auto;margin:0px;border-ra | Bitstream Vera Sans Mono', 'Courier  |
| dius:0px;border:0px;bottom:auto;floa | New', Courier, monospace;font-weight |
| t:none;height:auto;left:auto;line-he | :normal;font-style:normal;font-size: |
| ight:1.3em;outline:0px;overflow:visi | 1em;min-height:auto;white-space:pre; |
| ble;position:static;right:auto;backg | background-color:white;padding:0px 1 |
| round:none;min-height:auto;vertical- | em;">                                |
| align:baseline;width:auto;box-sizing |                                      |
| :content-box;font-family:Consolas, ' | `cd`{style="position:static;font-fam |
| Bitstream Vera Sans Mono', 'Courier  | ily:Consolas, 'Bitstream Vera Sans M |
| New', Courier, monospace;font-weight | ono', 'Courier New', Courier, monosp |
| :normal;font-style:normal;font-size: | ace;border:0px;bottom:auto;float:non |
| 1em;white-space:pre;background-color | e;height:auto;left:auto;line-height: |
| :rgb(252, 252, 252);border-right-wid | 1.3em;margin:0px;outline:0px;overflo |
| th:2px;border-right-style:solid;bord | w:visible;padding:0px;border-radius: |
| er-right-color:rgb(238, 136, 34);pad | 0px;right:auto;text-align:left;top:a |
| ding:0px 0.5em 0px 0px;text-align:ri | uto;vertical-align:baseline;width:au |
| ght;">                               | to;box-sizing:content-box;font-weigh |
|                                      | t:normal;font-style:normal;font-size |
| 2                                    | :1em;min-height:auto;background:none |
|                                      | ;color:rgb(255, 20, 147);"} `~`{styl |
| </div>                               | e="position:static;font-family:Conso |
|                                      | las, 'Bitstream Vera Sans Mono', 'Co |
| <div                                 | urier New', Courier, monospace;borde |
| style="top:auto;margin:0px;border-ra | r:0px;bottom:auto;float:none;height: |
| dius:0px;border:0px;bottom:auto;floa | auto;left:auto;line-height:1.3em;mar |
| t:none;height:auto;left:auto;line-he | gin:0px;outline:0px;overflow:visible |
| ight:1.3em;outline:0px;overflow:visi | ;padding:0px;border-radius:0px;right |
| ble;position:static;right:auto;backg | :auto;text-align:left;top:auto;verti |
| round:none;min-height:auto;vertical- | cal-align:baseline;width:auto;box-si |
| align:baseline;width:auto;box-sizing | zing:content-box;font-weight:normal; |
| :content-box;font-family:Consolas, ' | font-style:normal;font-size:1em;min- |
| Bitstream Vera Sans Mono', 'Courier  | height:auto;background:none;color:bl |
| New', Courier, monospace;font-weight | ack;"}                               |
| :normal;font-style:normal;font-size: |                                      |
| 1em;white-space:pre;background-color | </div>                               |
| :white;border-right-width:2px;border |                                      |
| -right-style:solid;border-right-colo | <div                                 |
| r:rgb(238, 136, 34);padding:0px 0.5e | style="text-align:left;margin:0px;bo |
| m 0px 0px;text-align:right;">        | rder-radius:0px;border:0px;bottom:au |
|                                      | to;float:none;height:auto;left:auto; |
| 3                                    | line-height:1.3em;outline:0px;overfl |
|                                      | ow:visible;position:static;right:aut |
| </div>                               | o;background:none;top:auto;vertical- |
|                                      | align:baseline;width:auto;box-sizing |
| <div                                 | :content-box;font-family:Consolas, ' |
| style="top:auto;margin:0px;border-ra | Bitstream Vera Sans Mono', 'Courier  |
| dius:0px;border:0px;bottom:auto;floa | New', Courier, monospace;font-weight |
| t:none;height:auto;left:auto;line-he | :normal;font-style:normal;font-size: |
| ight:1.3em;outline:0px;overflow:visi | 1em;min-height:auto;white-space:pre; |
| ble;position:static;right:auto;backg | background-color:rgb(252, 252, 252); |
| round:none;min-height:auto;vertical- | padding:0px 1em;">                   |
| align:baseline;width:auto;box-sizing |                                      |
| :content-box;font-family:Consolas, ' | `touch`{style="position:static;font- |
| Bitstream Vera Sans Mono', 'Courier  | family:Consolas, 'Bitstream Vera San |
| New', Courier, monospace;font-weight | s Mono', 'Courier New', Courier, mon |
| :normal;font-style:normal;font-size: | ospace;border:0px;bottom:auto;float: |
| 1em;white-space:pre;background-color | none;height:auto;left:auto;line-heig |
| :rgb(252, 252, 252);border-right-wid | ht:1.3em;margin:0px;outline:0px;over |
| th:2px;border-right-style:solid;bord | flow:visible;padding:0px;border-radi |
| er-right-color:rgb(238, 136, 34);pad | us:0px;right:auto;text-align:left;to |
| ding:0px 0.5em 0px 0px;text-align:ri | p:auto;vertical-align:baseline;width |
| ght;">                               | :auto;box-sizing:content-box;font-we |
|                                      | ight:normal;font-style:normal;font-s |
| 4                                    | ize:1em;min-height:auto;background:n |
|                                      | one;color:rgb(255, 20, 147);"} `.git |
| </div>                               | -credentials`{style="position:static |
|                                      | ;font-family:Consolas, 'Bitstream Ve |
| <div                                 | ra Sans Mono', 'Courier New', Courie |
| style="top:auto;margin:0px;border-ra | r, monospace;border:0px;bottom:auto; |
| dius:0px;border:0px;bottom:auto;floa | float:none;height:auto;left:auto;lin |
| t:none;height:auto;left:auto;line-he | e-height:1.3em;margin:0px;outline:0p |
| ight:1.3em;outline:0px;overflow:visi | x;overflow:visible;padding:0px;borde |
| ble;position:static;right:auto;backg | r-radius:0px;right:auto;text-align:l |
| round:none;min-height:auto;vertical- | eft;top:auto;vertical-align:baseline |
| align:baseline;width:auto;box-sizing | ;width:auto;box-sizing:content-box;f |
| :content-box;font-family:Consolas, ' | ont-weight:normal;font-style:normal; |
| Bitstream Vera Sans Mono', 'Courier  | font-size:1em;min-height:auto;backgr |
| New', Courier, monospace;font-weight | ound:none;color:black;"}             |
| :normal;font-style:normal;font-size: |                                      |
| 1em;white-space:pre;background-color | </div>                               |
| :white;border-right-width:2px;border |                                      |
| -right-style:solid;border-right-colo | <div                                 |
| r:rgb(238, 136, 34);padding:0px 0.5e | style="text-align:left;margin:0px;bo |
| m 0px 0px;text-align:right;">        | rder-radius:0px;border:0px;bottom:au |
|                                      | to;float:none;height:auto;left:auto; |
| 5                                    | line-height:1.3em;outline:0px;overfl |
|                                      | ow:visible;position:static;right:aut |
| </div>                               | o;background:none;top:auto;vertical- |
|                                      | align:baseline;width:auto;box-sizing |
| <div                                 | :content-box;font-family:Consolas, ' |
| style="top:auto;margin:0px;border-ra | Bitstream Vera Sans Mono', 'Courier  |
| dius:0px;border:0px;bottom:auto;floa | New', Courier, monospace;font-weight |
| t:none;height:auto;left:auto;line-he | :normal;font-style:normal;font-size: |
| ight:1.3em;outline:0px;overflow:visi | 1em;min-height:auto;white-space:pre; |
| ble;position:static;right:auto;backg | background-color:white;padding:0px 1 |
| round:none;min-height:auto;vertical- | em;">                                |
| align:baseline;width:auto;box-sizing |                                      |
| :content-box;font-family:Consolas, ' | `vim .git-credentials`{style="positi |
| Bitstream Vera Sans Mono', 'Courier  | on:static;font-family:Consolas, 'Bit |
| New', Courier, monospace;font-weight | stream Vera Sans Mono', 'Courier New |
| :normal;font-style:normal;font-size: | ', Courier, monospace;border:0px;bot |
| 1em;white-space:pre;background-color | tom:auto;float:none;height:auto;left |
| :rgb(252, 252, 252);border-right-wid | :auto;line-height:1.3em;margin:0px;o |
| th:2px;border-right-style:solid;bord | utline:0px;overflow:visible;padding: |
| er-right-color:rgb(238, 136, 34);pad | 0px;border-radius:0px;right:auto;tex |
| ding:0px 0.5em 0px 0px;text-align:ri | t-align:left;top:auto;vertical-align |
| ght;">                               | :baseline;width:auto;box-sizing:cont |
|                                      | ent-box;font-weight:normal;font-styl |
| 6                                    | e:normal;font-size:1em;min-height:au |
|                                      | to;background:none;color:black;"}    |
| </div>                               |                                      |
|                                      | </div>                               |
| <div                                 |                                      |
| style="top:auto;margin:0px;border-ra | <div                                 |
| dius:0px;border:0px;bottom:auto;floa | style="text-align:left;margin:0px;bo |
| t:none;height:auto;left:auto;line-he | rder-radius:0px;border:0px;bottom:au |
| ight:1.3em;outline:0px;overflow:visi | to;float:none;height:auto;left:auto; |
| ble;position:static;right:auto;backg | line-height:1.3em;outline:0px;overfl |
| round:none;min-height:auto;vertical- | ow:visible;position:static;right:aut |
| align:baseline;width:auto;box-sizing | o;background:none;top:auto;vertical- |
| :content-box;font-family:Consolas, ' | align:baseline;width:auto;box-sizing |
| Bitstream Vera Sans Mono', 'Courier  | :content-box;font-family:Consolas, ' |
| New', Courier, monospace;font-weight | Bitstream Vera Sans Mono', 'Courier  |
| :normal;font-style:normal;font-size: | New', Courier, monospace;font-weight |
| 1em;white-space:pre;background-color | :normal;font-style:normal;font-size: |
| :white;border-right-width:2px;border | 1em;min-height:auto;white-space:pre; |
| -right-style:solid;border-right-colo | background-color:rgb(252, 252, 252); |
| r:rgb(238, 136, 34);padding:0px 0.5e | padding:0px 1em;">                   |
| m 0px 0px;text-align:right;">        |                                      |
|                                      | `# 将以下内容写入该文件中`{style="position:stat |
| 7                                    | ic;font-family:Consolas, 'Bitstream  |
|                                      | Vera Sans Mono', 'Courier New', Cour |
| </div>                               | ier, monospace;border:0px;bottom:aut |
|                                      | o;float:none;height:auto;left:auto;l |
| <div                                 | ine-height:1.3em;margin:0px;outline: |
| style="top:auto;margin:0px;border-ra | 0px;overflow:visible;padding:0px;bor |
| dius:0px;border:0px;bottom:auto;floa | der-radius:0px;right:auto;text-align |
| t:none;height:auto;left:auto;line-he | :left;top:auto;vertical-align:baseli |
| ight:1.3em;outline:0px;overflow:visi | ne;width:auto;box-sizing:content-box |
| ble;position:static;right:auto;backg | ;font-weight:normal;font-style:norma |
| round:none;min-height:auto;vertical- | l;font-size:1em;min-height:auto;back |
| align:baseline;width:auto;box-sizing | ground:none;color:rgb(0, 130, 0);"}  |
| :content-box;font-family:Consolas, ' |                                      |
| Bitstream Vera Sans Mono', 'Courier  | </div>                               |
| New', Courier, monospace;font-weight |                                      |
| :normal;font-style:normal;font-size: | <div                                 |
| 1em;white-space:pre;background-color | style="text-align:left;margin:0px;bo |
| :rgb(252, 252, 252);border-right-wid | rder-radius:0px;border:0px;bottom:au |
| th:2px;border-right-style:solid;bord | to;float:none;height:auto;left:auto; |
| er-right-color:rgb(238, 136, 34);pad | line-height:1.3em;outline:0px;overfl |
| ding:0px 0.5em 0px 0px;text-align:ri | ow:visible;position:static;right:aut |
| ght;">                               | o;background:none;top:auto;vertical- |
|                                      | align:baseline;width:auto;box-sizing |
| 8                                    | :content-box;font-family:Consolas, ' |
|                                      | Bitstream Vera Sans Mono', 'Courier  |
| </div>                               | New', Courier, monospace;font-weight |
|                                      | :normal;font-style:normal;font-size: |
| <div                                 | 1em;min-height:auto;white-space:pre; |
| style="top:auto;margin:0px;border-ra | background-color:white;padding:0px 1 |
| dius:0px;border:0px;bottom:auto;floa | em;">                                |
| t:none;height:auto;left:auto;line-he |                                      |
| ight:1.3em;outline:0px;overflow:visi | `https:`{style="position:static;font |
| ble;position:static;right:auto;backg | -family:Consolas, 'Bitstream Vera Sa |
| round:none;min-height:auto;vertical- | ns Mono', 'Courier New', Courier, mo |
| align:baseline;width:auto;box-sizing | nospace;border:0px;bottom:auto;float |
| :content-box;font-family:Consolas, ' | :none;height:auto;left:auto;line-hei |
| Bitstream Vera Sans Mono', 'Courier  | ght:1.3em;margin:0px;outline:0px;ove |
| New', Courier, monospace;font-weight | rflow:visible;padding:0px;border-rad |
| :normal;font-style:normal;font-size: | ius:0px;right:auto;text-align:left;t |
| 1em;white-space:pre;background-color | op:auto;vertical-align:baseline;widt |
| :white;border-right-width:2px;border | h:auto;box-sizing:content-box;font-w |
| -right-style:solid;border-right-colo | eight:normal;font-style:normal;font- |
| r:rgb(238, 136, 34);padding:0px 0.5e | size:1em;min-height:auto;background: |
| m 0px 0px;text-align:right;">        | none;color:black;"}`//`{style="posit |
|                                      | ion:static;font-family:Consolas, 'Bi |
| 9                                    | tstream Vera Sans Mono', 'Courier Ne |
|                                      | w', Courier, monospace;border:0px;bo |
| </div>                               | ttom:auto;float:none;height:auto;lef |
|                                      | t:auto;line-height:1.3em;margin:0px; |
| <div                                 | outline:0px;overflow:visible;padding |
| style="top:auto;margin:0px;border-ra | :0px;border-radius:0px;right:auto;te |
| dius:0px;border:0px;bottom:auto;floa | xt-align:left;top:auto;vertical-alig |
| t:none;height:auto;left:auto;line-he | n:baseline;width:auto;box-sizing:con |
| ight:1.3em;outline:0px;overflow:visi | tent-box;font-weight:normal;font-sty |
| ble;position:static;right:auto;backg | le:normal;font-size:1em;min-height:a |
| round:none;min-height:auto;vertical- | uto;background:none;color:black;"}`{ |
| align:baseline;width:auto;box-sizing | username}:{password}@github.com`{sty |
| :content-box;font-family:Consolas, ' | le="position:static;font-family:Cons |
| Bitstream Vera Sans Mono', 'Courier  | olas, 'Bitstream Vera Sans Mono', 'C |
| New', Courier, monospace;font-weight | ourier New', Courier, monospace;bord |
| :normal;font-style:normal;font-size: | er:0px;bottom:auto;float:none;height |
| 1em;white-space:pre;background-color | :auto;left:auto;line-height:1.3em;ma |
| :rgb(252, 252, 252);border-right-wid | rgin:0px;outline:0px;overflow:visibl |
| th:2px;border-right-style:solid;bord | e;padding:0px;border-radius:0px;righ |
| er-right-color:rgb(238, 136, 34);pad | t:auto;text-align:left;top:auto;vert |
| ding:0px 0.5em 0px 0px;text-align:ri | ical-align:baseline;width:auto;box-s |
| ght;">                               | izing:content-box;font-weight:normal |
|                                      | ;font-style:normal;font-size:1em;min |
| 10                                   | -height:auto;background:none;color:b |
|                                      | lack;"}                              |
| </div>                               |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="text-align:left;margin:0px;bo |
|                                      | rder-radius:0px;border:0px;bottom:au |
|                                      | to;float:none;height:auto;left:auto; |
|                                      | line-height:1.3em;outline:0px;overfl |
|                                      | ow:visible;position:static;right:aut |
|                                      | o;background:none;top:auto;vertical- |
|                                      | align:baseline;width:auto;box-sizing |
|                                      | :content-box;font-family:Consolas, ' |
|                                      | Bitstream Vera Sans Mono', 'Courier  |
|                                      | New', Courier, monospace;font-weight |
|                                      | :normal;font-style:normal;font-size: |
|                                      | 1em;min-height:auto;white-space:pre; |
|                                      | background-color:rgb(252, 252, 252); |
|                                      | padding:0px 1em;">                   |
|                                      |                                      |
|                                      | `# 或者`{style="position:static;font-f |
|                                      | amily:Consolas, 'Bitstream Vera Sans |
|                                      |  Mono', 'Courier New', Courier, mono |
|                                      | space;border:0px;bottom:auto;float:n |
|                                      | one;height:auto;left:auto;line-heigh |
|                                      | t:1.3em;margin:0px;outline:0px;overf |
|                                      | low:visible;padding:0px;border-radiu |
|                                      | s:0px;right:auto;text-align:left;top |
|                                      | :auto;vertical-align:baseline;width: |
|                                      | auto;box-sizing:content-box;font-wei |
|                                      | ght:normal;font-style:normal;font-si |
|                                      | ze:1em;min-height:auto;background:no |
|                                      | ne;color:rgb(0, 130, 0);"}           |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="text-align:left;margin:0px;bo |
|                                      | rder-radius:0px;border:0px;bottom:au |
|                                      | to;float:none;height:auto;left:auto; |
|                                      | line-height:1.3em;outline:0px;overfl |
|                                      | ow:visible;position:static;right:aut |
|                                      | o;background:none;top:auto;vertical- |
|                                      | align:baseline;width:auto;box-sizing |
|                                      | :content-box;font-family:Consolas, ' |
|                                      | Bitstream Vera Sans Mono', 'Courier  |
|                                      | New', Courier, monospace;font-weight |
|                                      | :normal;font-style:normal;font-size: |
|                                      | 1em;min-height:auto;white-space:pre; |
|                                      | background-color:white;padding:0px 1 |
|                                      | em;">                                |
|                                      |                                      |
|                                      | `https:`{style="position:static;font |
|                                      | -family:Consolas, 'Bitstream Vera Sa |
|                                      | ns Mono', 'Courier New', Courier, mo |
|                                      | nospace;border:0px;bottom:auto;float |
|                                      | :none;height:auto;left:auto;line-hei |
|                                      | ght:1.3em;margin:0px;outline:0px;ove |
|                                      | rflow:visible;padding:0px;border-rad |
|                                      | ius:0px;right:auto;text-align:left;t |
|                                      | op:auto;vertical-align:baseline;widt |
|                                      | h:auto;box-sizing:content-box;font-w |
|                                      | eight:normal;font-style:normal;font- |
|                                      | size:1em;min-height:auto;background: |
|                                      | none;color:black;"}`//`{style="posit |
|                                      | ion:static;font-family:Consolas, 'Bi |
|                                      | tstream Vera Sans Mono', 'Courier Ne |
|                                      | w', Courier, monospace;border:0px;bo |
|                                      | ttom:auto;float:none;height:auto;lef |
|                                      | t:auto;line-height:1.3em;margin:0px; |
|                                      | outline:0px;overflow:visible;padding |
|                                      | :0px;border-radius:0px;right:auto;te |
|                                      | xt-align:left;top:auto;vertical-alig |
|                                      | n:baseline;width:auto;box-sizing:con |
|                                      | tent-box;font-weight:normal;font-sty |
|                                      | le:normal;font-size:1em;min-height:a |
|                                      | uto;background:none;color:black;"}`{ |
|                                      | username}:{password}@192.168.0.108`{ |
|                                      | style="position:static;font-family:C |
|                                      | onsolas, 'Bitstream Vera Sans Mono', |
|                                      |  'Courier New', Courier, monospace;b |
|                                      | order:0px;bottom:auto;float:none;hei |
|                                      | ght:auto;left:auto;line-height:1.3em |
|                                      | ;margin:0px;outline:0px;overflow:vis |
|                                      | ible;padding:0px;border-radius:0px;r |
|                                      | ight:auto;text-align:left;top:auto;v |
|                                      | ertical-align:baseline;width:auto;bo |
|                                      | x-sizing:content-box;font-weight:nor |
|                                      | mal;font-style:normal;font-size:1em; |
|                                      | min-height:auto;background:none;colo |
|                                      | r:black;"}                           |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="text-align:left;margin:0px;bo |
|                                      | rder-radius:0px;border:0px;bottom:au |
|                                      | to;float:none;height:auto;left:auto; |
|                                      | line-height:1.3em;outline:0px;overfl |
|                                      | ow:visible;position:static;right:aut |
|                                      | o;background:none;top:auto;vertical- |
|                                      | align:baseline;width:auto;box-sizing |
|                                      | :content-box;font-family:Consolas, ' |
|                                      | Bitstream Vera Sans Mono', 'Courier  |
|                                      | New', Courier, monospace;font-weight |
|                                      | :normal;font-style:normal;font-size: |
|                                      | 1em;min-height:auto;white-space:pre; |
|                                      | background-color:rgb(252, 252, 252); |
|                                      | padding:0px 1em;">                   |
|                                      |                                      |
|                                      |                                      |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="text-align:left;margin:0px;bo |
|                                      | rder-radius:0px;border:0px;bottom:au |
|                                      | to;float:none;height:auto;left:auto; |
|                                      | line-height:1.3em;outline:0px;overfl |
|                                      | ow:visible;position:static;right:aut |
|                                      | o;background:none;top:auto;vertical- |
|                                      | align:baseline;width:auto;box-sizing |
|                                      | :content-box;font-family:Consolas, ' |
|                                      | Bitstream Vera Sans Mono', 'Courier  |
|                                      | New', Courier, monospace;font-weight |
|                                      | :normal;font-style:normal;font-size: |
|                                      | 1em;min-height:auto;white-space:pre; |
|                                      | background-color:white;padding:0px 1 |
|                                      | em;">                                |
|                                      |                                      |
|                                      | `#运行以下git配置命令`{style="position:stati |
|                                      | c;font-family:Consolas, 'Bitstream V |
|                                      | era Sans Mono', 'Courier New', Couri |
|                                      | er, monospace;border:0px;bottom:auto |
|                                      | ;float:none;height:auto;left:auto;li |
|                                      | ne-height:1.3em;margin:0px;outline:0 |
|                                      | px;overflow:visible;padding:0px;bord |
|                                      | er-radius:0px;right:auto;text-align: |
|                                      | left;top:auto;vertical-align:baselin |
|                                      | e;width:auto;box-sizing:content-box; |
|                                      | font-weight:normal;font-style:normal |
|                                      | ;font-size:1em;min-height:auto;backg |
|                                      | round:none;color:rgb(0, 130, 0);"}   |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="text-align:left;margin:0px;bo |
|                                      | rder-radius:0px;border:0px;bottom:au |
|                                      | to;float:none;height:auto;left:auto; |
|                                      | line-height:1.3em;outline:0px;overfl |
|                                      | ow:visible;position:static;right:aut |
|                                      | o;background:none;top:auto;vertical- |
|                                      | align:baseline;width:auto;box-sizing |
|                                      | :content-box;font-family:Consolas, ' |
|                                      | Bitstream Vera Sans Mono', 'Courier  |
|                                      | New', Courier, monospace;font-weight |
|                                      | :normal;font-style:normal;font-size: |
|                                      | 1em;min-height:auto;white-space:pre; |
|                                      | background-color:rgb(252, 252, 252); |
|                                      | padding:0px 1em;">                   |
|                                      |                                      |
|                                      | `git config --global credential.help |
|                                      | er store`{style="position:static;fon |
|                                      | t-family:Consolas, 'Bitstream Vera S |
|                                      | ans Mono', 'Courier New', Courier, m |
|                                      | onospace;border:0px;bottom:auto;floa |
|                                      | t:none;height:auto;left:auto;line-he |
|                                      | ight:1.3em;margin:0px;outline:0px;ov |
|                                      | erflow:visible;padding:0px;border-ra |
|                                      | dius:0px;right:auto;text-align:left; |
|                                      | top:auto;vertical-align:baseline;wid |
|                                      | th:auto;box-sizing:content-box;font- |
|                                      | weight:normal;font-style:normal;font |
|                                      | -size:1em;min-height:auto;background |
|                                      | :none;color:black;"}                 |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+

</div>

</div>

到这一步，执行完后查看Git目录下的.gitconfig文件，会多了一项：

<div style="margin:0px;padding:0px;">

<div
style="padding:0px;margin:1em 0px;width:100%;position:relative;overflow:auto;font-size:1em;background-color:white;">

+--------------------------------------+--------------------------------------+
| <div                                 | <div                                 |
| style="top:auto;margin:0px;border-ra | style="right:auto;margin:0px;border- |
| dius:0px;border:0px;bottom:auto;floa | radius:0px;border:0px;bottom:auto;fl |
| t:none;height:auto;left:auto;line-he | oat:none;height:auto;left:auto;line- |
| ight:1.3em;outline:0px;overflow:visi | height:1.3em;outline:0px;overflow:vi |
| ble;position:static;right:auto;backg | sible;min-height:auto;padding:0px;te |
| round:none;min-height:auto;vertical- | xt-align:left;top:auto;vertical-alig |
| align:baseline;width:auto;box-sizing | n:baseline;width:auto;box-sizing:con |
| :content-box;font-family:Consolas, ' | tent-box;font-family:Consolas, 'Bits |
| Bitstream Vera Sans Mono', 'Courier  | tream Vera Sans Mono', 'Courier New' |
| New', Courier, monospace;font-weight | , Courier, monospace;font-weight:nor |
| :normal;font-style:normal;font-size: | mal;font-style:normal;font-size:1em; |
| 1em;white-space:pre;background-color | background:none;position:relative;"> |
| :white;border-right-width:2px;border |                                      |
| -right-style:solid;border-right-colo | <div                                 |
| r:rgb(238, 136, 34);padding:0px 0.5e | style="text-align:left;margin:0px;bo |
| m 0px 0px;text-align:right;">        | rder-radius:0px;border:0px;bottom:au |
|                                      | to;float:none;height:auto;left:auto; |
| 1                                    | line-height:1.3em;outline:0px;overfl |
|                                      | ow:visible;position:static;right:aut |
| </div>                               | o;background:none;top:auto;vertical- |
|                                      | align:baseline;width:auto;box-sizing |
| <div                                 | :content-box;font-family:Consolas, ' |
| style="top:auto;margin:0px;border-ra | Bitstream Vera Sans Mono', 'Courier  |
| dius:0px;border:0px;bottom:auto;floa | New', Courier, monospace;font-weight |
| t:none;height:auto;left:auto;line-he | :normal;font-style:normal;font-size: |
| ight:1.3em;outline:0px;overflow:visi | 1em;min-height:auto;white-space:pre; |
| ble;position:static;right:auto;backg | background-color:white;padding:0px 1 |
| round:none;min-height:auto;vertical- | em;">                                |
| align:baseline;width:auto;box-sizing |                                      |
| :content-box;font-family:Consolas, ' | `[credential]`{style="position:stati |
| Bitstream Vera Sans Mono', 'Courier  | c;font-family:Consolas, 'Bitstream V |
| New', Courier, monospace;font-weight | era Sans Mono', 'Courier New', Couri |
| :normal;font-style:normal;font-size: | er, monospace;border:0px;bottom:auto |
| 1em;white-space:pre;background-color | ;float:none;height:auto;left:auto;li |
| :rgb(252, 252, 252);border-right-wid | ne-height:1.3em;margin:0px;outline:0 |
| th:2px;border-right-style:solid;bord | px;overflow:visible;padding:0px;bord |
| er-right-color:rgb(238, 136, 34);pad | er-radius:0px;right:auto;text-align: |
| ding:0px 0.5em 0px 0px;text-align:ri | left;top:auto;vertical-align:baselin |
| ght;">                               | e;width:auto;box-sizing:content-box; |
|                                      | font-weight:normal;font-style:normal |
| 2                                    | ;font-size:1em;min-height:auto;backg |
|                                      | round:none;color:black;"}            |
| </div>                               |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="text-align:left;margin:0px;bo |
|                                      | rder-radius:0px;border:0px;bottom:au |
|                                      | to;float:none;height:auto;left:auto; |
|                                      | line-height:1.3em;outline:0px;overfl |
|                                      | ow:visible;position:static;right:aut |
|                                      | o;background:none;top:auto;vertical- |
|                                      | align:baseline;width:auto;box-sizing |
|                                      | :content-box;font-family:Consolas, ' |
|                                      | Bitstream Vera Sans Mono', 'Courier  |
|                                      | New', Courier, monospace;font-weight |
|                                      | :normal;font-style:normal;font-size: |
|                                      | 1em;min-height:auto;white-space:pre; |
|                                      | background-color:rgb(252, 252, 252); |
|                                      | padding:0px 1em;">                   |
|                                      |                                      |
|                                      | `    `{style="position:static;font-f |
|                                      | amily:Consolas, 'Bitstream Vera Sans |
|                                      |  Mono', 'Courier New', Courier, mono |
|                                      | space;border:0px;bottom:auto;float:n |
|                                      | one;height:auto;left:auto;line-heigh |
|                                      | t:1.3em;margin:0px;outline:0px;overf |
|                                      | low:visible;padding:0px;border-radiu |
|                                      | s:0px;right:auto;text-align:left;top |
|                                      | :auto;vertical-align:baseline;width: |
|                                      | auto;box-sizing:content-box;font-wei |
|                                      | ght:normal;font-style:normal;font-si |
|                                      | ze:1em;min-height:auto;background:no |
|                                      | ne;color:black;"}`helper = store`{st |
|                                      | yle="position:static;font-family:Con |
|                                      | solas, 'Bitstream Vera Sans Mono', ' |
|                                      | Courier New', Courier, monospace;bor |
|                                      | der:0px;bottom:auto;float:none;heigh |
|                                      | t:auto;left:auto;line-height:1.3em;m |
|                                      | argin:0px;outline:0px;overflow:visib |
|                                      | le;padding:0px;border-radius:0px;rig |
|                                      | ht:auto;text-align:left;top:auto;ver |
|                                      | tical-align:baseline;width:auto;box- |
|                                      | sizing:content-box;font-weight:norma |
|                                      | l;font-style:normal;font-size:1em;mi |
|                                      | n-height:auto;background:none;color: |
|                                      | black;"}                             |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+

</div>

</div>

\

<span style="color:rgb(192, 0, 0);">**Windows下：**</span>

方法一（本人未使用过）：

在windows中添加一个HOME环境变量，变量名:HOME,变量值：%USERPROFILE%\

进入%HOME%目录，新建一个名为"\_netrc"的文件，文件中内容格式如下：

<div style="margin:0px;padding:0px;">

<div
style="padding:0px;margin:1em 0px;width:100%;position:relative;overflow:auto;font-size:1em;background-color:white;">

+--------------------------------------+--------------------------------------+
| <div                                 | <div                                 |
| style="top:auto;margin:0px;border-ra | style="right:auto;margin:0px;border- |
| dius:0px;border:0px;bottom:auto;floa | radius:0px;border:0px;bottom:auto;fl |
| t:none;height:auto;left:auto;line-he | oat:none;height:auto;left:auto;line- |
| ight:1.3em;outline:0px;overflow:visi | height:1.3em;outline:0px;overflow:vi |
| ble;position:static;right:auto;backg | sible;min-height:auto;padding:0px;te |
| round:none;min-height:auto;vertical- | xt-align:left;top:auto;vertical-alig |
| align:baseline;width:auto;box-sizing | n:baseline;width:auto;box-sizing:con |
| :content-box;font-family:Consolas, ' | tent-box;font-family:Consolas, 'Bits |
| Bitstream Vera Sans Mono', 'Courier  | tream Vera Sans Mono', 'Courier New' |
| New', Courier, monospace;font-weight | , Courier, monospace;font-weight:nor |
| :normal;font-style:normal;font-size: | mal;font-style:normal;font-size:1em; |
| 1em;white-space:pre;background-color | background:none;position:relative;"> |
| :white;border-right-width:2px;border |                                      |
| -right-style:solid;border-right-colo | <div                                 |
| r:rgb(238, 136, 34);padding:0px 0.5e | style="text-align:left;margin:0px;bo |
| m 0px 0px;text-align:right;">        | rder-radius:0px;border:0px;bottom:au |
|                                      | to;float:none;height:auto;left:auto; |
| 1                                    | line-height:1.3em;outline:0px;overfl |
|                                      | ow:visible;position:static;right:aut |
| </div>                               | o;background:none;top:auto;vertical- |
|                                      | align:baseline;width:auto;box-sizing |
| <div                                 | :content-box;font-family:Consolas, ' |
| style="top:auto;margin:0px;border-ra | Bitstream Vera Sans Mono', 'Courier  |
| dius:0px;border:0px;bottom:auto;floa | New', Courier, monospace;font-weight |
| t:none;height:auto;left:auto;line-he | :normal;font-style:normal;font-size: |
| ight:1.3em;outline:0px;overflow:visi | 1em;min-height:auto;white-space:pre; |
| ble;position:static;right:auto;backg | background-color:white;padding:0px 1 |
| round:none;min-height:auto;vertical- | em;">                                |
| align:baseline;width:auto;box-sizing |                                      |
| :content-box;font-family:Consolas, ' | `machine {git account name}.github.c |
| Bitstream Vera Sans Mono', 'Courier  | om`{style="position:static;font-fami |
| New', Courier, monospace;font-weight | ly:Consolas, 'Bitstream Vera Sans Mo |
| :normal;font-style:normal;font-size: | no', 'Courier New', Courier, monospa |
| 1em;white-space:pre;background-color | ce;border:0px;bottom:auto;float:none |
| :rgb(252, 252, 252);border-right-wid | ;height:auto;left:auto;line-height:1 |
| th:2px;border-right-style:solid;bord | .3em;margin:0px;outline:0px;overflow |
| er-right-color:rgb(238, 136, 34);pad | :visible;padding:0px;border-radius:0 |
| ding:0px 0.5em 0px 0px;text-align:ri | px;right:auto;text-align:left;top:au |
| ght;">                               | to;vertical-align:baseline;width:aut |
|                                      | o;box-sizing:content-box;font-weight |
| 2                                    | :normal;font-style:normal;font-size: |
|                                      | 1em;min-height:auto;background:none; |
| </div>                               | color:black;"}                       |
|                                      |                                      |
| <div                                 | </div>                               |
| style="top:auto;margin:0px;border-ra |                                      |
| dius:0px;border:0px;bottom:auto;floa | <div                                 |
| t:none;height:auto;left:auto;line-he | style="text-align:left;margin:0px;bo |
| ight:1.3em;outline:0px;overflow:visi | rder-radius:0px;border:0px;bottom:au |
| ble;position:static;right:auto;backg | to;float:none;height:auto;left:auto; |
| round:none;min-height:auto;vertical- | line-height:1.3em;outline:0px;overfl |
| align:baseline;width:auto;box-sizing | ow:visible;position:static;right:aut |
| :content-box;font-family:Consolas, ' | o;background:none;top:auto;vertical- |
| Bitstream Vera Sans Mono', 'Courier  | align:baseline;width:auto;box-sizing |
| New', Courier, monospace;font-weight | :content-box;font-family:Consolas, ' |
| :normal;font-style:normal;font-size: | Bitstream Vera Sans Mono', 'Courier  |
| 1em;white-space:pre;background-color | New', Courier, monospace;font-weight |
| :white;border-right-width:2px;border | :normal;font-style:normal;font-size: |
| -right-style:solid;border-right-colo | 1em;min-height:auto;white-space:pre; |
| r:rgb(238, 136, 34);padding:0px 0.5e | background-color:rgb(252, 252, 252); |
| m 0px 0px;text-align:right;">        | padding:0px 1em;">                   |
|                                      |                                      |
| 3                                    | `login your-username`{style="positio |
|                                      | n:static;font-family:Consolas, 'Bits |
| </div>                               | tream Vera Sans Mono', 'Courier New' |
|                                      | , Courier, monospace;border:0px;bott |
|                                      | om:auto;float:none;height:auto;left: |
|                                      | auto;line-height:1.3em;margin:0px;ou |
|                                      | tline:0px;overflow:visible;padding:0 |
|                                      | px;border-radius:0px;right:auto;text |
|                                      | -align:left;top:auto;vertical-align: |
|                                      | baseline;width:auto;box-sizing:conte |
|                                      | nt-box;font-weight:normal;font-style |
|                                      | :normal;font-size:1em;min-height:aut |
|                                      | o;background:none;color:black;"}     |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="text-align:left;margin:0px;bo |
|                                      | rder-radius:0px;border:0px;bottom:au |
|                                      | to;float:none;height:auto;left:auto; |
|                                      | line-height:1.3em;outline:0px;overfl |
|                                      | ow:visible;position:static;right:aut |
|                                      | o;background:none;top:auto;vertical- |
|                                      | align:baseline;width:auto;box-sizing |
|                                      | :content-box;font-family:Consolas, ' |
|                                      | Bitstream Vera Sans Mono', 'Courier  |
|                                      | New', Courier, monospace;font-weight |
|                                      | :normal;font-style:normal;font-size: |
|                                      | 1em;min-height:auto;white-space:pre; |
|                                      | background-color:white;padding:0px 1 |
|                                      | em;">                                |
|                                      |                                      |
|                                      | `password your-password`{style="posi |
|                                      | tion:static;font-family:Consolas, 'B |
|                                      | itstream Vera Sans Mono', 'Courier N |
|                                      | ew', Courier, monospace;border:0px;b |
|                                      | ottom:auto;float:none;height:auto;le |
|                                      | ft:auto;line-height:1.3em;margin:0px |
|                                      | ;outline:0px;overflow:visible;paddin |
|                                      | g:0px;border-radius:0px;right:auto;t |
|                                      | ext-align:left;top:auto;vertical-ali |
|                                      | gn:baseline;width:auto;box-sizing:co |
|                                      | ntent-box;font-weight:normal;font-st |
|                                      | yle:normal;font-size:1em;min-height: |
|                                      | auto;background:none;color:black;"}  |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+

</div>

</div>

\

方法二（测试可行）：

在home文件夹，一般是 C:\\Documents and Settings\\Administrator
下建立文件 .git-credentials

输入以下内容：\

<div style="margin:0px;padding:0px;">

<div
style="padding:0px;margin:1em 0px;width:100%;position:relative;overflow:auto;font-size:1em;background-color:white;">

+--------------------------------------+--------------------------------------+
| <div                                 | <div                                 |
| style="top:auto;margin:0px;border-ra | style="right:auto;margin:0px;border- |
| dius:0px;border:0px;bottom:auto;floa | radius:0px;border:0px;bottom:auto;fl |
| t:none;height:auto;left:auto;line-he | oat:none;height:auto;left:auto;line- |
| ight:1.3em;outline:0px;overflow:visi | height:1.3em;outline:0px;overflow:vi |
| ble;position:static;right:auto;backg | sible;min-height:auto;padding:0px;te |
| round:none;min-height:auto;vertical- | xt-align:left;top:auto;vertical-alig |
| align:baseline;width:auto;box-sizing | n:baseline;width:auto;box-sizing:con |
| :content-box;font-family:Consolas, ' | tent-box;font-family:Consolas, 'Bits |
| Bitstream Vera Sans Mono', 'Courier  | tream Vera Sans Mono', 'Courier New' |
| New', Courier, monospace;font-weight | , Courier, monospace;font-weight:nor |
| :normal;font-style:normal;font-size: | mal;font-style:normal;font-size:1em; |
| 1em;white-space:pre;background-color | background:none;position:relative;"> |
| :white;border-right-width:2px;border |                                      |
| -right-style:solid;border-right-colo | <div                                 |
| r:rgb(238, 136, 34);padding:0px 0.5e | style="text-align:left;margin:0px;bo |
| m 0px 0px;text-align:right;">        | rder-radius:0px;border:0px;bottom:au |
|                                      | to;float:none;height:auto;left:auto; |
| 1                                    | line-height:1.3em;outline:0px;overfl |
|                                      | ow:visible;position:static;right:aut |
| </div>                               | o;background:none;top:auto;vertical- |
|                                      | align:baseline;width:auto;box-sizing |
|                                      | :content-box;font-family:Consolas, ' |
|                                      | Bitstream Vera Sans Mono', 'Courier  |
|                                      | New', Courier, monospace;font-weight |
|                                      | :normal;font-style:normal;font-size: |
|                                      | 1em;min-height:auto;white-space:pre; |
|                                      | background-color:white;padding:0px 1 |
|                                      | em;">                                |
|                                      |                                      |
|                                      | `https://{username}:{password}@githu |
|                                      | b.com`{style="position:static;font-f |
|                                      | amily:Consolas, 'Bitstream Vera Sans |
|                                      |  Mono', 'Courier New', Courier, mono |
|                                      | space;border:0px;bottom:auto;float:n |
|                                      | one;height:auto;left:auto;line-heigh |
|                                      | t:1.3em;margin:0px;outline:0px;overf |
|                                      | low:visible;padding:0px;border-radiu |
|                                      | s:0px;right:auto;text-align:left;top |
|                                      | :auto;vertical-align:baseline;width: |
|                                      | auto;box-sizing:content-box;font-wei |
|                                      | ght:normal;font-style:normal;font-si |
|                                      | ze:1em;min-height:auto;background:no |
|                                      | ne;color:black;"}                    |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+

</div>

</div>

运行以下git配置命令：\

<div style="margin:0px;padding:0px;">

<div
style="padding:0px;margin:1em 0px;width:100%;position:relative;overflow:auto;font-size:1em;background-color:white;">

+--------------------------------------+--------------------------------------+
| <div                                 | <div                                 |
| style="top:auto;margin:0px;border-ra | style="right:auto;margin:0px;border- |
| dius:0px;border:0px;bottom:auto;floa | radius:0px;border:0px;bottom:auto;fl |
| t:none;height:auto;left:auto;line-he | oat:none;height:auto;left:auto;line- |
| ight:1.3em;outline:0px;overflow:visi | height:1.3em;outline:0px;overflow:vi |
| ble;position:static;right:auto;backg | sible;min-height:auto;padding:0px;te |
| round:none;min-height:auto;vertical- | xt-align:left;top:auto;vertical-alig |
| align:baseline;width:auto;box-sizing | n:baseline;width:auto;box-sizing:con |
| :content-box;font-family:Consolas, ' | tent-box;font-family:Consolas, 'Bits |
| Bitstream Vera Sans Mono', 'Courier  | tream Vera Sans Mono', 'Courier New' |
| New', Courier, monospace;font-weight | , Courier, monospace;font-weight:nor |
| :normal;font-style:normal;font-size: | mal;font-style:normal;font-size:1em; |
| 1em;white-space:pre;background-color | background:none;position:relative;"> |
| :white;border-right-width:2px;border |                                      |
| -right-style:solid;border-right-colo | <div                                 |
| r:rgb(238, 136, 34);padding:0px 0.5e | style="text-align:left;margin:0px;bo |
| m 0px 0px;text-align:right;">        | rder-radius:0px;border:0px;bottom:au |
|                                      | to;float:none;height:auto;left:auto; |
| 1                                    | line-height:1.3em;outline:0px;overfl |
|                                      | ow:visible;position:static;right:aut |
| </div>                               | o;background:none;top:auto;vertical- |
|                                      | align:baseline;width:auto;box-sizing |
|                                      | :content-box;font-family:Consolas, ' |
|                                      | Bitstream Vera Sans Mono', 'Courier  |
|                                      | New', Courier, monospace;font-weight |
|                                      | :normal;font-style:normal;font-size: |
|                                      | 1em;min-height:auto;white-space:pre; |
|                                      | background-color:white;padding:0px 1 |
|                                      | em;">                                |
|                                      |                                      |
|                                      | `git config --global credential.help |
|                                      | er store`{style="position:static;fon |
|                                      | t-family:Consolas, 'Bitstream Vera S |
|                                      | ans Mono', 'Courier New', Courier, m |
|                                      | onospace;border:0px;bottom:auto;floa |
|                                      | t:none;height:auto;left:auto;line-he |
|                                      | ight:1.3em;margin:0px;outline:0px;ov |
|                                      | erflow:visible;padding:0px;border-ra |
|                                      | dius:0px;right:auto;text-align:left; |
|                                      | top:auto;vertical-align:baseline;wid |
|                                      | th:auto;box-sizing:content-box;font- |
|                                      | weight:normal;font-style:normal;font |
|                                      | -size:1em;min-height:auto;background |
|                                      | :none;color:black;"}                 |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+

</div>

</div>

\

重新打开git bash即可，无需再输入用户名和密码了。

</div>

<div
style="margin:0px;padding:10px;margin-top:50px;border-top-width:1px;border-top-style:dashed;border-top-color:rgb(204, 102, 0);background:url(&quot;&quot;) 100% 80px no-repeat;">

#### 推荐阅读： {#推荐阅读 style="margin:0px;padding:0px;font-size:100%;font-weight:bold;"}

[PHP和jQuery实现QR
Code二维码生成](http://old.yurendu.com/516/php%E5%92%8Cjquery%E5%AE%9E%E7%8E%B0qr%20code%E4%BA%8C%E7%BB%B4%E7%A0%81%E7%94%9F%E6%88%90.html)\
[MySQL十大优化技巧](http://old.yurendu.com/253/mysql%E5%8D%81%E5%A4%A7%E4%BC%98%E5%8C%96%E6%8A%80%E5%B7%A7.html)\
[jQuery插件galleria的配置和使用](http://old.yurendu.com/35/jquery%E6%8F%92%E4%BB%B6galleria%E7%9A%84%E9%85%8D%E7%BD%AE%E5%92%8C%E4%BD%BF%E7%94%A8.html)\
[PHP判断是否是手机访问](http://old.yurendu.com/102/php%E5%88%A4%E6%96%AD%E6%98%AF%E5%90%A6%E6%98%AF%E6%89%8B%E6%9C%BA%E8%AE%BF%E9%97%AE.html)\
[mysql replace
批量替换字段中的值](http://old.yurendu.com/519/mysql%20replace%20%E6%89%B9%E9%87%8F%E6%9B%BF%E6%8D%A2%E5%AD%97%E6%AE%B5%E4%B8%AD%E7%9A%84%E5%80%BC.html)\
[php实现
rss订阅](http://old.yurendu.com/284/php%E5%AE%9E%E7%8E%B0%20rss%E8%AE%A2%E9%98%85.html)\
[CentOS系统性能指标查看](http://old.yurendu.com/70/centos%E7%B3%BB%E7%BB%9F%E6%80%A7%E8%83%BD%E6%8C%87%E6%A0%87%E6%9F%A5%E7%9C%8B.html)\
[PHP
date函数日期格式明细](http://old.yurendu.com/334/php%20date%E5%87%BD%E6%95%B0%E6%97%A5%E6%9C%9F%E6%A0%BC%E5%BC%8F%E6%98%8E%E7%BB%86.html)\
[SEO中HTML标签权重分配](http://old.yurendu.com/347/seo%E4%B8%ADhtml%E6%A0%87%E7%AD%BE%E6%9D%83%E9%87%8D%E5%88%86%E9%85%8D.html)\
[CSS字体中英文名称对照表](http://old.yurendu.com/185/css%E5%AD%97%E4%BD%93%E4%B8%AD%E8%8B%B1%E6%96%87%E5%90%8D%E7%A7%B0%E5%AF%B9%E7%85%A7%E8%A1%A8.html)\

</div>

<div
style="margin:0px;padding:0px;clear:both;position:relative;overflow:visible;">

<div
style="margin:0px;padding:0px;font-weight:normal;font-size:13px;color:rgb(51, 51, 51);line-height:1;text-align:left;">

<div
style="font-family:inherit;margin:0px;box-sizing:content-box;border:0px;vertical-align:baseline;font-style:inherit;font-variant:inherit;font-weight:inherit;font-stretch:inherit;background:none;transition:none;overflow:visible;float:none;height:auto;width:100%;line-height:25px;padding:8px 0px;font-size:13px;margin-top:10px;position:relative;">

<div
style="font-family:inherit;margin:0px;box-sizing:content-box;border:0px;vertical-align:baseline;font-style:inherit;font-variant:inherit;font-weight:inherit;font-stretch:inherit;font-size:inherit;padding:0px;line-height:inherit;width:auto;height:auto;float:none;overflow:visible;transition:none;background:none;position:absolute;right:0px;top:8px;">

[最新]()[最早]()[最热]()

</div>

-   [0条评论](#)

</div>

-   还没有评论，沙发等你来抢

[]()
<div
style="font-size:inherit;margin:0px;box-sizing:content-box;border:0px;vertical-align:baseline;font-style:inherit;font-variant:inherit;font-weight:inherit;font-stretch:inherit;background:none;font-family:inherit;line-height:inherit;transition:none;height:auto;float:none;overflow:visible;width:100%;padding:10px 0px 6px;position:relative;">

社交帐号登录:

<div
style="font-size:inherit;margin:0px;box-sizing:content-box;border:0px;vertical-align:baseline;font-style:inherit;font-variant:inherit;font-weight:inherit;font-stretch:inherit;padding:0px;font-family:inherit;line-height:inherit;transition:none;height:auto;overflow:visible;background:none;float:left;width:306px;">

-   [微信](http://yurendu.duoshuo.com/login/weixin/)
-   [微博](http://yurendu.duoshuo.com/login/weibo/)
-   [QQ](http://yurendu.duoshuo.com/login/qq/)
-   [人人](http://yurendu.duoshuo.com/login/renren/)
-   [更多»](#)

</div>

<span
style="font-style:inherit;font-variant:inherit;font-weight:inherit;font-size:inherit;font-family:inherit;line-height:inherit;display:block;height:0px;clear:both;visibility:hidden;">.</span>

</div>

<div
style="font-family:inherit;margin:8px 0px;box-sizing:content-box;border:0px;vertical-align:baseline;font-style:inherit;font-variant:inherit;font-weight:inherit;font-stretch:inherit;font-size:12px;z-index:3;line-height:inherit;width:auto;height:auto;float:none;overflow:visible;transition:none;background:none;position:relative;padding:0px 0px 0px 80px;">

[![](Linux和windows中%20Git%20记住帐号密码，免除push、pull时重复输入验证%20-%20愚人渡_files/86865.jpg){width="50"
height="50"}](#)
<div
style="font-size:inherit;margin:0px;box-sizing:content-box;border:0px;vertical-align:baseline;font-style:inherit;font-variant:inherit;font-weight:inherit;font-stretch:inherit;padding:0px;font-family:inherit;line-height:inherit;width:auto;height:auto;float:none;overflow:visible;transition:none;background:none;">

<div
style="float:none;margin:0px;box-sizing:content-box;border:0px;vertical-align:baseline;font-style:inherit;font-variant:inherit;font-weight:inherit;font-stretch:inherit;font-size:inherit;font-family:inherit;line-height:inherit;width:auto;height:auto;padding:0px;transition:none;border-right-width:1px;overflow:hidden;border-top-right-radius:3px;border-top-left-radius:3px;position:relative;border-top-width:1px;background:url(&quot;&quot;) 0px -90px repeat-x rgb(255, 255, 255);border-left-width:1px;border-style:solid solid none;border-top-color:rgb(204, 204, 204);border-right-color:rgb(204, 204, 204);border-left-color:rgb(204, 204, 204);padding-right:20px;">

``` {style="width:auto;margin:0px;background:none;box-sizing:content-box;transition:none;vertical-align:baseline;font-style:inherit;font-variant:inherit;font-weight:inherit;font-stretch:inherit;overflow:visible;float:none;padding:0px;height:auto;visibility:hidden;line-height:20px;border:none;font-family:'Helvetica Neue', Helvetica, Arial, sans-serif;word-wrap:break-word;font-size:13px;position:absolute;top:0px;left:10px;right:10px;display:block;"}
```

</div>

<div
style="font-family:inherit;margin:0px;box-sizing:content-box;border:0px;vertical-align:baseline;font-style:inherit;font-variant:inherit;font-weight:inherit;font-stretch:inherit;font-size:inherit;padding:0px;line-height:inherit;background:none;height:auto;float:none;overflow:visible;transition:none;width:100%;position:relative;box-shadow:rgba(255, 255, 255, 0.6) 0px 1px 0px;">

<div
style="float:none;margin:0px;box-sizing:content-box;border:0px;vertical-align:baseline;font-style:inherit;font-variant:inherit;font-weight:inherit;font-stretch:inherit;font-size:inherit;font-family:inherit;line-height:inherit;width:auto;transition:none;padding:0px;overflow:visible;border-left-width:1px;height:30px;position:relative;margin-right:100px;border-top-width:1px;border-bottom-width:1px;background:url(&quot;&quot;) 0px -60px repeat-x;border-style:solid none solid solid;border-top-color:rgb(204, 204, 204);border-left-color:rgb(204, 204, 204);border-bottom-color:rgb(170, 170, 170);border-bottom-left-radius:3px;">

<span
style="line-height:30px;box-sizing:content-box;width:auto;padding:0px;display:inline;font-style:inherit;font-variant:inherit;font-weight:inherit;font-stretch:inherit;background:none;font-family:inherit;border:0px;margin:0px;height:auto;float:none;overflow:visible;transition:none;font-size:12px;color:rgb(153, 153, 153);position:absolute;right:5px;vertical-align:middle;"></span>

</div>

<div
style="font-family:inherit;margin:0px;box-sizing:content-box;border:0px;vertical-align:baseline;font-style:inherit;font-variant:inherit;font-weight:inherit;font-stretch:inherit;font-size:inherit;padding:0px;line-height:inherit;width:auto;height:auto;float:none;overflow:visible;transition:none;background:none;position:absolute;top:5px;left:6px;">

[]( "插入表情")[]( "插入图片")

</div>

</div>

</div>

<span
style="font-style:inherit;font-variant:inherit;font-weight:inherit;font-size:12px;font-family:inherit;line-height:inherit;display:block;height:0px;clear:both;visibility:hidden;">.</span>

</div>

[愚人渡正在使用多说](http://duoshuo.com/)

</div>

</div>

</div>

</div>

</div>

</div>

</div>

\

</div>
