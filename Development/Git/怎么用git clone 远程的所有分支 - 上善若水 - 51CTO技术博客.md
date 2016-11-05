怎么用git clone 远程的所有分支 - 上善若水 - 51CTO技术博客
<div>

\
<div style="font-size: 16px">

<div>

<div
style="font-family:宋体, 'Arial Narrow', arial, serif;font-size:12px;color:rgb(44, 44, 44);background:rgb(228, 228, 228);">

<div>

<div style="overflow:hidden;">

<div style="background:rgb(255, 255, 255);margin-top:5px;">

<div>

<div style="margin:0 0 10px;">

<div
style="line-height:2;font-size:14px;word-wrap:break-word;word-break:normal;">

首先, clone 一个远端仓库，到其目录下：

\$ git clone git://example.com/myproject\$ cd myproject

然后，看看你本地有什么分支：

\$ git branch\* master

但是有些其他分支你在的仓库里面是隐藏的，你可以加上－a选项来查看它们：

<div style="padding:0px;margin:0px;">

<div
style="text-align:left;padding:0px;border-radius:0px;border:0px;bottom:auto;float:none;left:auto;line-height:1.1em;outline:0px;overflow:visible;position:relative;right:auto;margin:0.3em 0px;top:auto;vertical-align:baseline;width:100%;box-sizing:content-box;font-family:Consolas, 'Bitstream Vera Sans Mono', 'Courier New', Courier, monospace;font-weight:normal;font-style:normal;font-size:1em;min-height:auto;background:none;overflow-x:auto;background-color:white;">

+--------------------------------------+--------------------------------------+
| <div                                 | <div                                 |
| style="vertical-align:baseline;borde | style="right:auto;padding:0px;border |
| r-right-color:rgb(108, 226, 108);bor | -radius:0px;border:0px;bottom:auto;f |
| der-radius:0px;border:0px;bottom:aut | loat:none;left:auto;line-height:1.1e |
| o;float:none;left:auto;line-height:1 | m;outline:0px;overflow:visible;min-h |
| .1em;outline:0px;overflow:visible;po | eight:auto;margin:0px;text-align:lef |
| sition:static;right:auto;border-righ | t;top:auto;vertical-align:baseline;w |
| t-style:solid;top:auto;margin:0px;wi | idth:auto;box-sizing:content-box;fon |
| dth:auto;box-sizing:content-box;font | t-family:Consolas, 'Bitstream Vera S |
| -family:Consolas, 'Bitstream Vera Sa | ans Mono', 'Courier New', Courier, m |
| ns Mono', 'Courier New', Courier, mo | onospace;font-weight:normal;font-sty |
| nospace;font-weight:normal;font-styl | le:normal;font-size:1em;background:n |
| e:normal;font-size:1em;min-height:au | one;position:relative;">             |
| to;background:none;background-color: |                                      |
| white;word-wrap:normal;white-space:p | <div                                 |
| re;border-right-width:3px;text-align | style="text-align:left;white-space:n |
| :right;padding:0px 0.5em 0px 1em;">  | owrap;top:auto;border-radius:0px;bot |
|                                      | tom:auto;float:none;left:auto;line-h |
| 1                                    | eight:1.1em;outline:0px;overflow:vis |
|                                      | ible;position:static;right:auto;marg |
| </div>                               | in:0px;border:0px;vertical-align:bas |
|                                      | eline;width:auto;box-sizing:content- |
| <div                                 | box;font-family:Consolas, 'Bitstream |
| style="vertical-align:baseline;borde |  Vera Sans Mono', 'Courier New', Cou |
| r-right-color:rgb(108, 226, 108);bor | rier, monospace;font-weight:normal;f |
| der-radius:0px;border:0px;bottom:aut | ont-style:normal;font-size:1em;min-h |
| o;float:none;left:auto;line-height:1 | eight:auto;background:none;backgroun |
| .1em;outline:0px;overflow:visible;po | d-color:white;padding:0px 1em;">     |
| sition:static;right:auto;border-righ |                                      |
| t-style:solid;top:auto;margin:0px;wi | `$ git branch -a`{style="text-align: |
| dth:auto;box-sizing:content-box;font | left;padding:0px;border-radius:0px;b |
| -family:Consolas, 'Bitstream Vera Sa | order:0px;bottom:auto;float:none;lef |
| ns Mono', 'Courier New', Courier, mo | t:auto;line-height:1.1em;outline:0px |
| nospace;font-weight:normal;font-styl | ;overflow:visible;position:static;ri |
| e:normal;font-size:1em;min-height:au | ght:auto;margin:0px;top:auto;vertica |
| to;background:none;background-color: | l-align:baseline;width:auto;box-sizi |
| white;word-wrap:normal;white-space:p | ng:content-box;font-family:Consolas, |
| re;border-right-width:3px;text-align |  'Bitstream Vera Sans Mono', 'Courie |
| :right;padding:0px 0.5em 0px 1em;">  | r New', Courier, monospace;font-weig |
|                                      | ht:normal;font-style:normal;font-siz |
| 2                                    | e:1em;min-height:auto;background:non |
|                                      | e;color:black;"}                     |
| </div>                               |                                      |
|                                      | </div>                               |
| <div                                 |                                      |
| style="vertical-align:baseline;borde | <div                                 |
| r-right-color:rgb(108, 226, 108);bor | style="text-align:left;white-space:n |
| der-radius:0px;border:0px;bottom:aut | owrap;top:auto;border-radius:0px;bot |
| o;float:none;left:auto;line-height:1 | tom:auto;float:none;left:auto;line-h |
| .1em;outline:0px;overflow:visible;po | eight:1.1em;outline:0px;overflow:vis |
| sition:static;right:auto;border-righ | ible;position:static;right:auto;marg |
| t-style:solid;top:auto;margin:0px;wi | in:0px;border:0px;vertical-align:bas |
| dth:auto;box-sizing:content-box;font | eline;width:auto;box-sizing:content- |
| -family:Consolas, 'Bitstream Vera Sa | box;font-family:Consolas, 'Bitstream |
| ns Mono', 'Courier New', Courier, mo |  Vera Sans Mono', 'Courier New', Cou |
| nospace;font-weight:normal;font-styl | rier, monospace;font-weight:normal;f |
| e:normal;font-size:1em;min-height:au | ont-style:normal;font-size:1em;min-h |
| to;background:none;background-color: | eight:auto;background:none;backgroun |
| white;word-wrap:normal;white-space:p | d-color:white;padding:0px 1em;">     |
| re;border-right-width:3px;text-align |                                      |
| :right;padding:0px 0.5em 0px 1em;">  | `* master`{style="text-align:left;pa |
|                                      | dding:0px;border-radius:0px;border:0 |
| 3                                    | px;bottom:auto;float:none;left:auto; |
|                                      | line-height:1.1em;outline:0px;overfl |
| </div>                               | ow:visible;position:static;right:aut |
|                                      | o;margin:0px;top:auto;vertical-align |
| <div                                 | :baseline;width:auto;box-sizing:cont |
| style="vertical-align:baseline;borde | ent-box;font-family:Consolas, 'Bitst |
| r-right-color:rgb(108, 226, 108);bor | ream Vera Sans Mono', 'Courier New', |
| der-radius:0px;border:0px;bottom:aut |  Courier, monospace;font-weight:norm |
| o;float:none;left:auto;line-height:1 | al;font-style:normal;font-size:1em;m |
| .1em;outline:0px;overflow:visible;po | in-height:auto;background:none;color |
| sition:static;right:auto;border-righ | :black;"}                            |
| t-style:solid;top:auto;margin:0px;wi |                                      |
| dth:auto;box-sizing:content-box;font | </div>                               |
| -family:Consolas, 'Bitstream Vera Sa |                                      |
| ns Mono', 'Courier New', Courier, mo | <div                                 |
| nospace;font-weight:normal;font-styl | style="text-align:left;white-space:n |
| e:normal;font-size:1em;min-height:au | owrap;top:auto;border-radius:0px;bot |
| to;background:none;background-color: | tom:auto;float:none;left:auto;line-h |
| white;word-wrap:normal;white-space:p | eight:1.1em;outline:0px;overflow:vis |
| re;border-right-width:3px;text-align | ible;position:static;right:auto;marg |
| :right;padding:0px 0.5em 0px 1em;">  | in:0px;border:0px;vertical-align:bas |
|                                      | eline;width:auto;box-sizing:content- |
| 4                                    | box;font-family:Consolas, 'Bitstream |
|                                      |  Vera Sans Mono', 'Courier New', Cou |
| </div>                               | rier, monospace;font-weight:normal;f |
|                                      | ont-style:normal;font-size:1em;min-h |
| <div                                 | eight:auto;background:none;backgroun |
| style="vertical-align:baseline;borde | d-color:white;padding:0px 1em;">     |
| r-right-color:rgb(108, 226, 108);bor |                                      |
| der-radius:0px;border:0px;bottom:aut | `  `{style="right:auto;padding:0px;b |
| o;float:none;left:auto;line-height:1 | order-radius:0px;border:0px;bottom:a |
| .1em;outline:0px;overflow:visible;po | uto;float:none;left:auto;line-height |
| sition:static;right:auto;border-righ | :1.1em;outline:0px;overflow:visible; |
| t-style:solid;top:auto;margin:0px;wi | position:static;margin:0px;text-alig |
| dth:auto;box-sizing:content-box;font | n:left;top:auto;vertical-align:basel |
| -family:Consolas, 'Bitstream Vera Sa | ine;width:auto;box-sizing:content-bo |
| ns Mono', 'Courier New', Courier, mo | x;font-family:Consolas, 'Bitstream V |
| nospace;font-weight:normal;font-styl | era Sans Mono', 'Courier New', Couri |
| e:normal;font-size:1em;min-height:au | er, monospace;font-weight:normal;fon |
| to;background:none;background-color: | t-style:normal;font-size:1em;min-hei |
| white;word-wrap:normal;white-space:p | ght:auto;background:none;"}`origin/H |
| re;border-right-width:3px;text-align | EAD`{style="text-align:left;padding: |
| :right;padding:0px 0.5em 0px 1em;">  | 0px;border-radius:0px;border:0px;bot |
|                                      | tom:auto;float:none;left:auto;line-h |
| 5                                    | eight:1.1em;outline:0px;overflow:vis |
|                                      | ible;position:static;right:auto;marg |
| </div>                               | in:0px;top:auto;vertical-align:basel |
|                                      | ine;width:auto;box-sizing:content-bo |
| <div                                 | x;font-family:Consolas, 'Bitstream V |
| style="vertical-align:baseline;borde | era Sans Mono', 'Courier New', Couri |
| r-right-color:rgb(108, 226, 108);bor | er, monospace;font-weight:normal;fon |
| der-radius:0px;border:0px;bottom:aut | t-style:normal;font-size:1em;min-hei |
| o;float:none;left:auto;line-height:1 | ght:auto;background:none;color:black |
| .1em;outline:0px;overflow:visible;po | ;"}                                  |
| sition:static;right:auto;border-righ |                                      |
| t-style:solid;top:auto;margin:0px;wi | </div>                               |
| dth:auto;box-sizing:content-box;font |                                      |
| -family:Consolas, 'Bitstream Vera Sa | <div                                 |
| ns Mono', 'Courier New', Courier, mo | style="text-align:left;white-space:n |
| nospace;font-weight:normal;font-styl | owrap;top:auto;border-radius:0px;bot |
| e:normal;font-size:1em;min-height:au | tom:auto;float:none;left:auto;line-h |
| to;background:none;background-color: | eight:1.1em;outline:0px;overflow:vis |
| white;word-wrap:normal;white-space:p | ible;position:static;right:auto;marg |
| re;border-right-width:3px;text-align | in:0px;border:0px;vertical-align:bas |
| :right;padding:0px 0.5em 0px 1em;">  | eline;width:auto;box-sizing:content- |
|                                      | box;font-family:Consolas, 'Bitstream |
| 6                                    |  Vera Sans Mono', 'Courier New', Cou |
|                                      | rier, monospace;font-weight:normal;f |
| </div>                               | ont-style:normal;font-size:1em;min-h |
|                                      | eight:auto;background:none;backgroun |
| <div                                 | d-color:white;padding:0px 1em;">     |
| style="vertical-align:baseline;borde |                                      |
| r-right-color:rgb(108, 226, 108);bor | `  `{style="right:auto;padding:0px;b |
| der-radius:0px;border:0px;bottom:aut | order-radius:0px;border:0px;bottom:a |
| o;float:none;left:auto;line-height:1 | uto;float:none;left:auto;line-height |
| .1em;outline:0px;overflow:visible;po | :1.1em;outline:0px;overflow:visible; |
| sition:static;right:auto;border-righ | position:static;margin:0px;text-alig |
| t-style:solid;top:auto;margin:0px;wi | n:left;top:auto;vertical-align:basel |
| dth:auto;box-sizing:content-box;font | ine;width:auto;box-sizing:content-bo |
| -family:Consolas, 'Bitstream Vera Sa | x;font-family:Consolas, 'Bitstream V |
| ns Mono', 'Courier New', Courier, mo | era Sans Mono', 'Courier New', Couri |
| nospace;font-weight:normal;font-styl | er, monospace;font-weight:normal;fon |
| e:normal;font-size:1em;min-height:au | t-style:normal;font-size:1em;min-hei |
| to;background:none;background-color: | ght:auto;background:none;"}`origin/m |
| white;word-wrap:normal;white-space:p | aster`{style="text-align:left;paddin |
| re;border-right-width:3px;text-align | g:0px;border-radius:0px;border:0px;b |
| :right;padding:0px 0.5em 0px 1em;">  | ottom:auto;float:none;left:auto;line |
|                                      | -height:1.1em;outline:0px;overflow:v |
| 7                                    | isible;position:static;right:auto;ma |
|                                      | rgin:0px;top:auto;vertical-align:bas |
| </div>                               | eline;width:auto;box-sizing:content- |
|                                      | box;font-family:Consolas, 'Bitstream |
| <div                                 |  Vera Sans Mono', 'Courier New', Cou |
| style="vertical-align:baseline;borde | rier, monospace;font-weight:normal;f |
| r-right-color:rgb(108, 226, 108);bor | ont-style:normal;font-size:1em;min-h |
| der-radius:0px;border:0px;bottom:aut | eight:auto;background:none;color:bla |
| o;float:none;left:auto;line-height:1 | ck;"}                                |
| .1em;outline:0px;overflow:visible;po |                                      |
| sition:static;right:auto;border-righ | </div>                               |
| t-style:solid;top:auto;margin:0px;wi |                                      |
| dth:auto;box-sizing:content-box;font | <div                                 |
| -family:Consolas, 'Bitstream Vera Sa | style="text-align:left;white-space:n |
| ns Mono', 'Courier New', Courier, mo | owrap;top:auto;border-radius:0px;bot |
| nospace;font-weight:normal;font-styl | tom:auto;float:none;left:auto;line-h |
| e:normal;font-size:1em;min-height:au | eight:1.1em;outline:0px;overflow:vis |
| to;background:none;background-color: | ible;position:static;right:auto;marg |
| white;word-wrap:normal;white-space:p | in:0px;border:0px;vertical-align:bas |
| re;border-right-width:3px;text-align | eline;width:auto;box-sizing:content- |
| :right;padding:0px 0.5em 0px 1em;">  | box;font-family:Consolas, 'Bitstream |
|                                      |  Vera Sans Mono', 'Courier New', Cou |
| 8                                    | rier, monospace;font-weight:normal;f |
|                                      | ont-style:normal;font-size:1em;min-h |
| </div>                               | eight:auto;background:none;backgroun |
|                                      | d-color:white;padding:0px 1em;">     |
| <div                                 |                                      |
| style="vertical-align:baseline;borde | `  `{style="right:auto;padding:0px;b |
| r-right-color:rgb(108, 226, 108);bor | order-radius:0px;border:0px;bottom:a |
| der-radius:0px;border:0px;bottom:aut | uto;float:none;left:auto;line-height |
| o;float:none;left:auto;line-height:1 | :1.1em;outline:0px;overflow:visible; |
| .1em;outline:0px;overflow:visible;po | position:static;margin:0px;text-alig |
| sition:static;right:auto;border-righ | n:left;top:auto;vertical-align:basel |
| t-style:solid;top:auto;margin:0px;wi | ine;width:auto;box-sizing:content-bo |
| dth:auto;box-sizing:content-box;font | x;font-family:Consolas, 'Bitstream V |
| -family:Consolas, 'Bitstream Vera Sa | era Sans Mono', 'Courier New', Couri |
| ns Mono', 'Courier New', Courier, mo | er, monospace;font-weight:normal;fon |
| nospace;font-weight:normal;font-styl | t-style:normal;font-size:1em;min-hei |
| e:normal;font-size:1em;min-height:au | ght:auto;background:none;"}`origin/v |
| to;background:none;background-color: | 1.`{style="text-align:left;padding:0 |
| white;word-wrap:normal;white-space:p | px;border-radius:0px;border:0px;bott |
| re;border-right-width:3px;text-align | om:auto;float:none;left:auto;line-he |
| :right;padding:0px 0.5em 0px 1em;">  | ight:1.1em;outline:0px;overflow:visi |
|                                      | ble;position:static;right:auto;margi |
| 9                                    | n:0px;top:auto;vertical-align:baseli |
|                                      | ne;width:auto;box-sizing:content-box |
| </div>                               | ;font-family:Consolas, 'Bitstream Ve |
|                                      | ra Sans Mono', 'Courier New', Courie |
| <div                                 | r, monospace;font-weight:normal;font |
| style="vertical-align:baseline;borde | -style:normal;font-size:1em;min-heig |
| r-right-color:rgb(108, 226, 108);bor | ht:auto;background:none;color:black; |
| der-radius:0px;border:0px;bottom:aut | "}`0`{style="text-align:left;padding |
| o;float:none;left:auto;line-height:1 | :0px;border-radius:0px;border:0px;bo |
| .1em;outline:0px;overflow:visible;po | ttom:auto;float:none;left:auto;line- |
| sition:static;right:auto;border-righ | height:1.1em;outline:0px;overflow:vi |
| t-style:solid;top:auto;margin:0px;wi | sible;position:static;right:auto;mar |
| dth:auto;box-sizing:content-box;font | gin:0px;top:auto;vertical-align:base |
| -family:Consolas, 'Bitstream Vera Sa | line;width:auto;box-sizing:content-b |
| ns Mono', 'Courier New', Courier, mo | ox;font-family:Consolas, 'Bitstream  |
| nospace;font-weight:normal;font-styl | Vera Sans Mono', 'Courier New', Cour |
| e:normal;font-size:1em;min-height:au | ier, monospace;font-weight:normal;fo |
| to;background:none;background-color: | nt-style:normal;font-size:1em;min-he |
| white;word-wrap:normal;white-space:p | ight:auto;background:none;color:rgb( |
| re;border-right-width:3px;text-align | 0, 153, 0);"}`-stable`{style="text-a |
| :right;padding:0px 0.5em 0px 1em;">  | lign:left;padding:0px;border-radius: |
|                                      | 0px;border:0px;bottom:auto;float:non |
| 10                                   | e;left:auto;line-height:1.1em;outlin |
|                                      | e:0px;overflow:visible;position:stat |
| </div>                               | ic;right:auto;margin:0px;top:auto;ve |
|                                      | rtical-align:baseline;width:auto;box |
| <div                                 | -sizing:content-box;font-family:Cons |
| style="vertical-align:baseline;borde | olas, 'Bitstream Vera Sans Mono', 'C |
| r-right-color:rgb(108, 226, 108);bor | ourier New', Courier, monospace;font |
| der-radius:0px;border:0px;bottom:aut | -weight:normal;font-style:normal;fon |
| o;float:none;left:auto;line-height:1 | t-size:1em;min-height:auto;backgroun |
| .1em;outline:0px;overflow:visible;po | d:none;color:black;"}                |
| sition:static;right:auto;border-righ |                                      |
| t-style:solid;top:auto;margin:0px;wi | </div>                               |
| dth:auto;box-sizing:content-box;font |                                      |
| -family:Consolas, 'Bitstream Vera Sa | <div                                 |
| ns Mono', 'Courier New', Courier, mo | style="text-align:left;white-space:n |
| nospace;font-weight:normal;font-styl | owrap;top:auto;border-radius:0px;bot |
| e:normal;font-size:1em;min-height:au | tom:auto;float:none;left:auto;line-h |
| to;background:none;background-color: | eight:1.1em;outline:0px;overflow:vis |
| white;word-wrap:normal;white-space:p | ible;position:static;right:auto;marg |
| re;border-right-width:3px;text-align | in:0px;border:0px;vertical-align:bas |
| :right;padding:0px 0.5em 0px 1em;">  | eline;width:auto;box-sizing:content- |
|                                      | box;font-family:Consolas, 'Bitstream |
| 11                                   |  Vera Sans Mono', 'Courier New', Cou |
|                                      | rier, monospace;font-weight:normal;f |
| </div>                               | ont-style:normal;font-size:1em;min-h |
|                                      | eight:auto;background:none;backgroun |
| <div                                 | d-color:white;padding:0px 1em;">     |
| style="vertical-align:baseline;borde |                                      |
| r-right-color:rgb(108, 226, 108);bor | `  `{style="right:auto;padding:0px;b |
| der-radius:0px;border:0px;bottom:aut | order-radius:0px;border:0px;bottom:a |
| o;float:none;left:auto;line-height:1 | uto;float:none;left:auto;line-height |
| .1em;outline:0px;overflow:visible;po | :1.1em;outline:0px;overflow:visible; |
| sition:static;right:auto;border-righ | position:static;margin:0px;text-alig |
| t-style:solid;top:auto;margin:0px;wi | n:left;top:auto;vertical-align:basel |
| dth:auto;box-sizing:content-box;font | ine;width:auto;box-sizing:content-bo |
| -family:Consolas, 'Bitstream Vera Sa | x;font-family:Consolas, 'Bitstream V |
| ns Mono', 'Courier New', Courier, mo | era Sans Mono', 'Courier New', Couri |
| nospace;font-weight:normal;font-styl | er, monospace;font-weight:normal;fon |
| e:normal;font-size:1em;min-height:au | t-style:normal;font-size:1em;min-hei |
| to;background:none;background-color: | ght:auto;background:none;"}`origin/e |
| white;word-wrap:normal;white-space:p | xperimental`{style="text-align:left; |
| re;border-right-width:3px;text-align | padding:0px;border-radius:0px;border |
| :right;padding:0px 0.5em 0px 1em;">  | :0px;bottom:auto;float:none;left:aut |
|                                      | o;line-height:1.1em;outline:0px;over |
| 12                                   | flow:visible;position:static;right:a |
|                                      | uto;margin:0px;top:auto;vertical-ali |
| </div>                               | gn:baseline;width:auto;box-sizing:co |
|                                      | ntent-box;font-family:Consolas, 'Bit |
| <div                                 | stream Vera Sans Mono', 'Courier New |
| style="vertical-align:baseline;borde | ', Courier, monospace;font-weight:no |
| r-right-color:rgb(108, 226, 108);bor | rmal;font-style:normal;font-size:1em |
| der-radius:0px;border:0px;bottom:aut | ;min-height:auto;background:none;col |
| o;float:none;left:auto;line-height:1 | or:black;"}                          |
| .1em;outline:0px;overflow:visible;po |                                      |
| sition:static;right:auto;border-righ | </div>                               |
| t-style:solid;top:auto;margin:0px;wi |                                      |
| dth:auto;box-sizing:content-box;font | <div                                 |
| -family:Consolas, 'Bitstream Vera Sa | style="text-align:left;white-space:n |
| ns Mono', 'Courier New', Courier, mo | owrap;top:auto;border-radius:0px;bot |
| nospace;font-weight:normal;font-styl | tom:auto;float:none;left:auto;line-h |
| e:normal;font-size:1em;min-height:au | eight:1.1em;outline:0px;overflow:vis |
| to;background:none;background-color: | ible;position:static;right:auto;marg |
| white;word-wrap:normal;white-space:p | in:0px;border:0px;vertical-align:bas |
| re;border-right-width:3px;text-align | eline;width:auto;box-sizing:content- |
| :right;padding:0px 0.5em 0px 1em;">  | box;font-family:Consolas, 'Bitstream |
|                                      |  Vera Sans Mono', 'Courier New', Cou |
| 13                                   | rier, monospace;font-weight:normal;f |
|                                      | ont-style:normal;font-size:1em;min-h |
| </div>                               | eight:auto;background:none;backgroun |
|                                      | d-color:white;padding:0px 1em;">     |
| <div                                 |                                      |
| style="vertical-align:baseline;borde | `如果你现快速的代上面的分支，你可以直接切换到那个分支：`{style= |
| r-right-color:rgb(108, 226, 108);bor | "text-align:left;padding:0px;border- |
| der-radius:0px;border:0px;bottom:aut | radius:0px;border:0px;bottom:auto;fl |
| o;float:none;left:auto;line-height:1 | oat:none;left:auto;line-height:1.1em |
| .1em;outline:0px;overflow:visible;po | ;outline:0px;overflow:visible;positi |
| sition:static;right:auto;border-righ | on:static;right:auto;margin:0px;top: |
| t-style:solid;top:auto;margin:0px;wi | auto;vertical-align:baseline;width:a |
| dth:auto;box-sizing:content-box;font | uto;box-sizing:content-box;font-fami |
| -family:Consolas, 'Bitstream Vera Sa | ly:Consolas, 'Bitstream Vera Sans Mo |
| ns Mono', 'Courier New', Courier, mo | no', 'Courier New', Courier, monospa |
| nospace;font-weight:normal;font-styl | ce;font-weight:normal;font-style:nor |
| e:normal;font-size:1em;min-height:au | mal;font-size:1em;min-height:auto;ba |
| to;background:none;background-color: | ckground:none;color:black;"}         |
| white;word-wrap:normal;white-space:p |                                      |
| re;border-right-width:3px;text-align | </div>                               |
| :right;padding:0px 0.5em 0px 1em;">  |                                      |
|                                      | <div                                 |
| 14                                   | style="text-align:left;white-space:n |
|                                      | owrap;top:auto;border-radius:0px;bot |
| </div>                               | tom:auto;float:none;left:auto;line-h |
|                                      | eight:1.1em;outline:0px;overflow:vis |
| <div                                 | ible;position:static;right:auto;marg |
| style="vertical-align:baseline;borde | in:0px;border:0px;vertical-align:bas |
| r-right-color:rgb(108, 226, 108);bor | eline;width:auto;box-sizing:content- |
| der-radius:0px;border:0px;bottom:aut | box;font-family:Consolas, 'Bitstream |
| o;float:none;left:auto;line-height:1 |  Vera Sans Mono', 'Courier New', Cou |
| .1em;outline:0px;overflow:visible;po | rier, monospace;font-weight:normal;f |
| sition:static;right:auto;border-righ | ont-style:normal;font-size:1em;min-h |
| t-style:solid;top:auto;margin:0px;wi | eight:auto;background:none;backgroun |
| dth:auto;box-sizing:content-box;font | d-color:white;padding:0px 1em;">     |
| -family:Consolas, 'Bitstream Vera Sa |                                      |
| ns Mono', 'Courier New', Courier, mo | `$ git checkout origin/experimental` |
| nospace;font-weight:normal;font-styl | {style="text-align:left;padding:0px; |
| e:normal;font-size:1em;min-height:au | border-radius:0px;border:0px;bottom: |
| to;background:none;background-color: | auto;float:none;left:auto;line-heigh |
| white;word-wrap:normal;white-space:p | t:1.1em;outline:0px;overflow:visible |
| re;border-right-width:3px;text-align | ;position:static;right:auto;margin:0 |
| :right;padding:0px 0.5em 0px 1em;">  | px;top:auto;vertical-align:baseline; |
|                                      | width:auto;box-sizing:content-box;fo |
| 15                                   | nt-family:Consolas, 'Bitstream Vera  |
|                                      | Sans Mono', 'Courier New', Courier,  |
| </div>                               | monospace;font-weight:normal;font-st |
|                                      | yle:normal;font-size:1em;min-height: |
| <div                                 | auto;background:none;color:black;"}  |
| style="vertical-align:baseline;borde |                                      |
| r-right-color:rgb(108, 226, 108);bor | </div>                               |
| der-radius:0px;border:0px;bottom:aut |                                      |
| o;float:none;left:auto;line-height:1 | <div                                 |
| .1em;outline:0px;overflow:visible;po | style="text-align:left;white-space:n |
| sition:static;right:auto;border-righ | owrap;top:auto;border-radius:0px;bot |
| t-style:solid;top:auto;margin:0px;wi | tom:auto;float:none;left:auto;line-h |
| dth:auto;box-sizing:content-box;font | eight:1.1em;outline:0px;overflow:vis |
| -family:Consolas, 'Bitstream Vera Sa | ible;position:static;right:auto;marg |
| ns Mono', 'Courier New', Courier, mo | in:0px;border:0px;vertical-align:bas |
| nospace;font-weight:normal;font-styl | eline;width:auto;box-sizing:content- |
| e:normal;font-size:1em;min-height:au | box;font-family:Consolas, 'Bitstream |
| to;background:none;background-color: |  Vera Sans Mono', 'Courier New', Cou |
| white;word-wrap:normal;white-space:p | rier, monospace;font-weight:normal;f |
| re;border-right-width:3px;text-align | ont-style:normal;font-size:1em;min-h |
| :right;padding:0px 0.5em 0px 1em;">  | eight:auto;background:none;backgroun |
|                                      | d-color:white;padding:0px 1em;">     |
| 16                                   |                                      |
|                                      | `但是，如果你想在那个分支工作的话，你就需要创建一个本地分支：`{sty |
| </div>                               | le="text-align:left;padding:0px;bord |
|                                      | er-radius:0px;border:0px;bottom:auto |
| <div                                 | ;float:none;left:auto;line-height:1. |
| style="vertical-align:baseline;borde | 1em;outline:0px;overflow:visible;pos |
| r-right-color:rgb(108, 226, 108);bor | ition:static;right:auto;margin:0px;t |
| der-radius:0px;border:0px;bottom:aut | op:auto;vertical-align:baseline;widt |
| o;float:none;left:auto;line-height:1 | h:auto;box-sizing:content-box;font-f |
| .1em;outline:0px;overflow:visible;po | amily:Consolas, 'Bitstream Vera Sans |
| sition:static;right:auto;border-righ |  Mono', 'Courier New', Courier, mono |
| t-style:solid;top:auto;margin:0px;wi | space;font-weight:normal;font-style: |
| dth:auto;box-sizing:content-box;font | normal;font-size:1em;min-height:auto |
| -family:Consolas, 'Bitstream Vera Sa | ;background:none;color:black;"}      |
| ns Mono', 'Courier New', Courier, mo |                                      |
| nospace;font-weight:normal;font-styl | </div>                               |
| e:normal;font-size:1em;min-height:au |                                      |
| to;background:none;background-color: | <div                                 |
| white;word-wrap:normal;white-space:p | style="text-align:left;white-space:n |
| re;border-right-width:3px;text-align | owrap;top:auto;border-radius:0px;bot |
| :right;padding:0px 0.5em 0px 1em;">  | tom:auto;float:none;left:auto;line-h |
|                                      | eight:1.1em;outline:0px;overflow:vis |
| 17                                   | ible;position:static;right:auto;marg |
|                                      | in:0px;border:0px;vertical-align:bas |
| </div>                               | eline;width:auto;box-sizing:content- |
|                                      | box;font-family:Consolas, 'Bitstream |
| <div                                 |  Vera Sans Mono', 'Courier New', Cou |
| style="vertical-align:baseline;borde | rier, monospace;font-weight:normal;f |
| r-right-color:rgb(108, 226, 108);bor | ont-style:normal;font-size:1em;min-h |
| der-radius:0px;border:0px;bottom:aut | eight:auto;background:none;backgroun |
| o;float:none;left:auto;line-height:1 | d-color:white;padding:0px 1em;">     |
| .1em;outline:0px;overflow:visible;po |                                      |
| sition:static;right:auto;border-righ | `$ git checkout -b experimental orig |
| t-style:solid;top:auto;margin:0px;wi | in/experimental`{style="text-align:l |
| dth:auto;box-sizing:content-box;font | eft;padding:0px;border-radius:0px;bo |
| -family:Consolas, 'Bitstream Vera Sa | rder:0px;bottom:auto;float:none;left |
| ns Mono', 'Courier New', Courier, mo | :auto;line-height:1.1em;outline:0px; |
| nospace;font-weight:normal;font-styl | overflow:visible;position:static;rig |
| e:normal;font-size:1em;min-height:au | ht:auto;margin:0px;top:auto;vertical |
| to;background:none;background-color: | -align:baseline;width:auto;box-sizin |
| white;word-wrap:normal;white-space:p | g:content-box;font-family:Consolas,  |
| re;border-right-width:3px;text-align | 'Bitstream Vera Sans Mono', 'Courier |
| :right;padding:0px 0.5em 0px 1em;">  |  New', Courier, monospace;font-weigh |
|                                      | t:normal;font-style:normal;font-size |
| 18                                   | :1em;min-height:auto;background:none |
|                                      | ;color:black;"}                      |
| </div>                               |                                      |
|                                      | </div>                               |
| <div                                 |                                      |
| style="vertical-align:baseline;borde | <div                                 |
| r-right-color:rgb(108, 226, 108);bor | style="text-align:left;white-space:n |
| der-radius:0px;border:0px;bottom:aut | owrap;top:auto;border-radius:0px;bot |
| o;float:none;left:auto;line-height:1 | tom:auto;float:none;left:auto;line-h |
| .1em;outline:0px;overflow:visible;po | eight:1.1em;outline:0px;overflow:vis |
| sition:static;right:auto;border-righ | ible;position:static;right:auto;marg |
| t-style:solid;top:auto;margin:0px;wi | in:0px;border:0px;vertical-align:bas |
| dth:auto;box-sizing:content-box;font | eline;width:auto;box-sizing:content- |
| -family:Consolas, 'Bitstream Vera Sa | box;font-family:Consolas, 'Bitstream |
| ns Mono', 'Courier New', Courier, mo |  Vera Sans Mono', 'Courier New', Cou |
| nospace;font-weight:normal;font-styl | rier, monospace;font-weight:normal;f |
| e:normal;font-size:1em;min-height:au | ont-style:normal;font-size:1em;min-h |
| to;background:none;background-color: | eight:auto;background:none;backgroun |
| white;word-wrap:normal;white-space:p | d-color:white;padding:0px 1em;">     |
| re;border-right-width:3px;text-align |                                      |
| :right;padding:0px 0.5em 0px 1em;">  | `现在，如果你看看你的本地分支，你会看到：`{style="text-a |
|                                      | lign:left;padding:0px;border-radius: |
| 19                                   | 0px;border:0px;bottom:auto;float:non |
|                                      | e;left:auto;line-height:1.1em;outlin |
| </div>                               | e:0px;overflow:visible;position:stat |
|                                      | ic;right:auto;margin:0px;top:auto;ve |
| <div                                 | rtical-align:baseline;width:auto;box |
| style="vertical-align:baseline;borde | -sizing:content-box;font-family:Cons |
| r-right-color:rgb(108, 226, 108);bor | olas, 'Bitstream Vera Sans Mono', 'C |
| der-radius:0px;border:0px;bottom:aut | ourier New', Courier, monospace;font |
| o;float:none;left:auto;line-height:1 | -weight:normal;font-style:normal;fon |
| .1em;outline:0px;overflow:visible;po | t-size:1em;min-height:auto;backgroun |
| sition:static;right:auto;border-righ | d:none;color:black;"}                |
| t-style:solid;top:auto;margin:0px;wi |                                      |
| dth:auto;box-sizing:content-box;font | </div>                               |
| -family:Consolas, 'Bitstream Vera Sa |                                      |
| ns Mono', 'Courier New', Courier, mo | <div                                 |
| nospace;font-weight:normal;font-styl | style="text-align:left;white-space:n |
| e:normal;font-size:1em;min-height:au | owrap;top:auto;border-radius:0px;bot |
| to;background:none;background-color: | tom:auto;float:none;left:auto;line-h |
| white;word-wrap:normal;white-space:p | eight:1.1em;outline:0px;overflow:vis |
| re;border-right-width:3px;text-align | ible;position:static;right:auto;marg |
| :right;padding:0px 0.5em 0px 1em;">  | in:0px;border:0px;vertical-align:bas |
|                                      | eline;width:auto;box-sizing:content- |
| 20                                   | box;font-family:Consolas, 'Bitstream |
|                                      |  Vera Sans Mono', 'Courier New', Cou |
| </div>                               | rier, monospace;font-weight:normal;f |
|                                      | ont-style:normal;font-size:1em;min-h |
| <div                                 | eight:auto;background:none;backgroun |
| style="vertical-align:baseline;borde | d-color:white;padding:0px 1em;">     |
| r-right-color:rgb(108, 226, 108);bor |                                      |
| der-radius:0px;border:0px;bottom:aut | `$ git branch`{style="text-align:lef |
| o;float:none;left:auto;line-height:1 | t;padding:0px;border-radius:0px;bord |
| .1em;outline:0px;overflow:visible;po | er:0px;bottom:auto;float:none;left:a |
| sition:static;right:auto;border-righ | uto;line-height:1.1em;outline:0px;ov |
| t-style:solid;top:auto;margin:0px;wi | erflow:visible;position:static;right |
| dth:auto;box-sizing:content-box;font | :auto;margin:0px;top:auto;vertical-a |
| -family:Consolas, 'Bitstream Vera Sa | lign:baseline;width:auto;box-sizing: |
| ns Mono', 'Courier New', Courier, mo | content-box;font-family:Consolas, 'B |
| nospace;font-weight:normal;font-styl | itstream Vera Sans Mono', 'Courier N |
| e:normal;font-size:1em;min-height:au | ew', Courier, monospace;font-weight: |
| to;background:none;background-color: | normal;font-style:normal;font-size:1 |
| white;word-wrap:normal;white-space:p | em;min-height:auto;background:none;c |
| re;border-right-width:3px;text-align | olor:black;"}                        |
| :right;padding:0px 0.5em 0px 1em;">  |                                      |
|                                      | </div>                               |
| 21                                   |                                      |
|                                      | <div                                 |
| </div>                               | style="text-align:left;white-space:n |
|                                      | owrap;top:auto;border-radius:0px;bot |
| <div                                 | tom:auto;float:none;left:auto;line-h |
| style="vertical-align:baseline;borde | eight:1.1em;outline:0px;overflow:vis |
| r-right-color:rgb(108, 226, 108);bor | ible;position:static;right:auto;marg |
| der-radius:0px;border:0px;bottom:aut | in:0px;border:0px;vertical-align:bas |
| o;float:none;left:auto;line-height:1 | eline;width:auto;box-sizing:content- |
| .1em;outline:0px;overflow:visible;po | box;font-family:Consolas, 'Bitstream |
| sition:static;right:auto;border-righ |  Vera Sans Mono', 'Courier New', Cou |
| t-style:solid;top:auto;margin:0px;wi | rier, monospace;font-weight:normal;f |
| dth:auto;box-sizing:content-box;font | ont-style:normal;font-size:1em;min-h |
| -family:Consolas, 'Bitstream Vera Sa | eight:auto;background:none;backgroun |
| ns Mono', 'Courier New', Courier, mo | d-color:white;padding:0px 1em;">     |
| nospace;font-weight:normal;font-styl |                                      |
| e:normal;font-size:1em;min-height:au | `  `{style="right:auto;padding:0px;b |
| to;background:none;background-color: | order-radius:0px;border:0px;bottom:a |
| white;word-wrap:normal;white-space:p | uto;float:none;left:auto;line-height |
| re;border-right-width:3px;text-align | :1.1em;outline:0px;overflow:visible; |
| :right;padding:0px 0.5em 0px 1em;">  | position:static;margin:0px;text-alig |
|                                      | n:left;top:auto;vertical-align:basel |
| 22                                   | ine;width:auto;box-sizing:content-bo |
|                                      | x;font-family:Consolas, 'Bitstream V |
| </div>                               | era Sans Mono', 'Courier New', Couri |
|                                      | er, monospace;font-weight:normal;fon |
| <div                                 | t-style:normal;font-size:1em;min-hei |
| style="vertical-align:baseline;borde | ght:auto;background:none;"}`master`{ |
| r-right-color:rgb(108, 226, 108);bor | style="text-align:left;padding:0px;b |
| der-radius:0px;border:0px;bottom:aut | order-radius:0px;border:0px;bottom:a |
| o;float:none;left:auto;line-height:1 | uto;float:none;left:auto;line-height |
| .1em;outline:0px;overflow:visible;po | :1.1em;outline:0px;overflow:visible; |
| sition:static;right:auto;border-righ | position:static;right:auto;margin:0p |
| t-style:solid;top:auto;margin:0px;wi | x;top:auto;vertical-align:baseline;w |
| dth:auto;box-sizing:content-box;font | idth:auto;box-sizing:content-box;fon |
| -family:Consolas, 'Bitstream Vera Sa | t-family:Consolas, 'Bitstream Vera S |
| ns Mono', 'Courier New', Courier, mo | ans Mono', 'Courier New', Courier, m |
| nospace;font-weight:normal;font-styl | onospace;font-weight:normal;font-sty |
| e:normal;font-size:1em;min-height:au | le:normal;font-size:1em;min-height:a |
| to;background:none;background-color: | uto;background:none;color:black;"}   |
| white;word-wrap:normal;white-space:p |                                      |
| re;border-right-width:3px;text-align | </div>                               |
| :right;padding:0px 0.5em 0px 1em;">  |                                      |
|                                      | <div                                 |
| 23                                   | style="text-align:left;white-space:n |
|                                      | owrap;top:auto;border-radius:0px;bot |
| </div>                               | tom:auto;float:none;left:auto;line-h |
|                                      | eight:1.1em;outline:0px;overflow:vis |
| <div                                 | ible;position:static;right:auto;marg |
| style="vertical-align:baseline;borde | in:0px;border:0px;vertical-align:bas |
| r-right-color:rgb(108, 226, 108);bor | eline;width:auto;box-sizing:content- |
| der-radius:0px;border:0px;bottom:aut | box;font-family:Consolas, 'Bitstream |
| o;float:none;left:auto;line-height:1 |  Vera Sans Mono', 'Courier New', Cou |
| .1em;outline:0px;overflow:visible;po | rier, monospace;font-weight:normal;f |
| sition:static;right:auto;border-righ | ont-style:normal;font-size:1em;min-h |
| t-style:solid;top:auto;margin:0px;wi | eight:auto;background:none;backgroun |
| dth:auto;box-sizing:content-box;font | d-color:white;padding:0px 1em;">     |
| -family:Consolas, 'Bitstream Vera Sa |                                      |
| ns Mono', 'Courier New', Courier, mo | `* experimental`{style="text-align:l |
| nospace;font-weight:normal;font-styl | eft;padding:0px;border-radius:0px;bo |
| e:normal;font-size:1em;min-height:au | rder:0px;bottom:auto;float:none;left |
| to;background:none;background-color: | :auto;line-height:1.1em;outline:0px; |
| white;word-wrap:normal;white-space:p | overflow:visible;position:static;rig |
| re;border-right-width:3px;text-align | ht:auto;margin:0px;top:auto;vertical |
| :right;padding:0px 0.5em 0px 1em;">  | -align:baseline;width:auto;box-sizin |
|                                      | g:content-box;font-family:Consolas,  |
| 24                                   | 'Bitstream Vera Sans Mono', 'Courier |
|                                      |  New', Courier, monospace;font-weigh |
| </div>                               | t:normal;font-style:normal;font-size |
|                                      | :1em;min-height:auto;background:none |
|                                      | ;color:black;"}                      |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="text-align:left;white-space:n |
|                                      | owrap;top:auto;border-radius:0px;bot |
|                                      | tom:auto;float:none;left:auto;line-h |
|                                      | eight:1.1em;outline:0px;overflow:vis |
|                                      | ible;position:static;right:auto;marg |
|                                      | in:0px;border:0px;vertical-align:bas |
|                                      | eline;width:auto;box-sizing:content- |
|                                      | box;font-family:Consolas, 'Bitstream |
|                                      |  Vera Sans Mono', 'Courier New', Cou |
|                                      | rier, monospace;font-weight:normal;f |
|                                      | ont-style:normal;font-size:1em;min-h |
|                                      | eight:auto;background:none;backgroun |
|                                      | d-color:white;padding:0px 1em;">     |
|                                      |                                      |
|                                      | `你还可以用git remote命令跟踪多个远程分支`{style="t |
|                                      | ext-align:left;padding:0px;border-ra |
|                                      | dius:0px;border:0px;bottom:auto;floa |
|                                      | t:none;left:auto;line-height:1.1em;o |
|                                      | utline:0px;overflow:visible;position |
|                                      | :static;right:auto;margin:0px;top:au |
|                                      | to;vertical-align:baseline;width:aut |
|                                      | o;box-sizing:content-box;font-family |
|                                      | :Consolas, 'Bitstream Vera Sans Mono |
|                                      | ', 'Courier New', Courier, monospace |
|                                      | ;font-weight:normal;font-style:norma |
|                                      | l;font-size:1em;min-height:auto;back |
|                                      | ground:none;color:black;"}           |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="text-align:left;white-space:n |
|                                      | owrap;top:auto;border-radius:0px;bot |
|                                      | tom:auto;float:none;left:auto;line-h |
|                                      | eight:1.1em;outline:0px;overflow:vis |
|                                      | ible;position:static;right:auto;marg |
|                                      | in:0px;border:0px;vertical-align:bas |
|                                      | eline;width:auto;box-sizing:content- |
|                                      | box;font-family:Consolas, 'Bitstream |
|                                      |  Vera Sans Mono', 'Courier New', Cou |
|                                      | rier, monospace;font-weight:normal;f |
|                                      | ont-style:normal;font-size:1em;min-h |
|                                      | eight:auto;background:none;backgroun |
|                                      | d-color:white;padding:0px 1em;">     |
|                                      |                                      |
|                                      | `$ git remote add win32 git:`{style= |
|                                      | "text-align:left;padding:0px;border- |
|                                      | radius:0px;border:0px;bottom:auto;fl |
|                                      | oat:none;left:auto;line-height:1.1em |
|                                      | ;outline:0px;overflow:visible;positi |
|                                      | on:static;right:auto;margin:0px;top: |
|                                      | auto;vertical-align:baseline;width:a |
|                                      | uto;box-sizing:content-box;font-fami |
|                                      | ly:Consolas, 'Bitstream Vera Sans Mo |
|                                      | no', 'Courier New', Courier, monospa |
|                                      | ce;font-weight:normal;font-style:nor |
|                                      | mal;font-size:1em;min-height:auto;ba |
|                                      | ckground:none;color:black;"}`//gutup |
|                                      | .com/users/joe/myproject-linux-port` |
|                                      | {style="text-align:left;padding:0px; |
|                                      | border-radius:0px;border:0px;bottom: |
|                                      | auto;float:none;left:auto;line-heigh |
|                                      | t:1.1em;outline:0px;overflow:visible |
|                                      | ;position:static;right:auto;margin:0 |
|                                      | px;top:auto;vertical-align:baseline; |
|                                      | width:auto;box-sizing:content-box;fo |
|                                      | nt-family:Consolas, 'Bitstream Vera  |
|                                      | Sans Mono', 'Courier New', Courier,  |
|                                      | monospace;font-weight:normal;font-st |
|                                      | yle:normal;font-size:1em;min-height: |
|                                      | auto;background:none;color:rgb(0, 13 |
|                                      | 0, 0);"}                             |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="text-align:left;white-space:n |
|                                      | owrap;top:auto;border-radius:0px;bot |
|                                      | tom:auto;float:none;left:auto;line-h |
|                                      | eight:1.1em;outline:0px;overflow:vis |
|                                      | ible;position:static;right:auto;marg |
|                                      | in:0px;border:0px;vertical-align:bas |
|                                      | eline;width:auto;box-sizing:content- |
|                                      | box;font-family:Consolas, 'Bitstream |
|                                      |  Vera Sans Mono', 'Courier New', Cou |
|                                      | rier, monospace;font-weight:normal;f |
|                                      | ont-style:normal;font-size:1em;min-h |
|                                      | eight:auto;background:none;backgroun |
|                                      | d-color:white;padding:0px 1em;">     |
|                                      |                                      |
|                                      | `$ git branch -a`{style="text-align: |
|                                      | left;padding:0px;border-radius:0px;b |
|                                      | order:0px;bottom:auto;float:none;lef |
|                                      | t:auto;line-height:1.1em;outline:0px |
|                                      | ;overflow:visible;position:static;ri |
|                                      | ght:auto;margin:0px;top:auto;vertica |
|                                      | l-align:baseline;width:auto;box-sizi |
|                                      | ng:content-box;font-family:Consolas, |
|                                      |  'Bitstream Vera Sans Mono', 'Courie |
|                                      | r New', Courier, monospace;font-weig |
|                                      | ht:normal;font-style:normal;font-siz |
|                                      | e:1em;min-height:auto;background:non |
|                                      | e;color:black;"}                     |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="text-align:left;white-space:n |
|                                      | owrap;top:auto;border-radius:0px;bot |
|                                      | tom:auto;float:none;left:auto;line-h |
|                                      | eight:1.1em;outline:0px;overflow:vis |
|                                      | ible;position:static;right:auto;marg |
|                                      | in:0px;border:0px;vertical-align:bas |
|                                      | eline;width:auto;box-sizing:content- |
|                                      | box;font-family:Consolas, 'Bitstream |
|                                      |  Vera Sans Mono', 'Courier New', Cou |
|                                      | rier, monospace;font-weight:normal;f |
|                                      | ont-style:normal;font-size:1em;min-h |
|                                      | eight:auto;background:none;backgroun |
|                                      | d-color:white;padding:0px 1em;">     |
|                                      |                                      |
|                                      | `* master`{style="text-align:left;pa |
|                                      | dding:0px;border-radius:0px;border:0 |
|                                      | px;bottom:auto;float:none;left:auto; |
|                                      | line-height:1.1em;outline:0px;overfl |
|                                      | ow:visible;position:static;right:aut |
|                                      | o;margin:0px;top:auto;vertical-align |
|                                      | :baseline;width:auto;box-sizing:cont |
|                                      | ent-box;font-family:Consolas, 'Bitst |
|                                      | ream Vera Sans Mono', 'Courier New', |
|                                      |  Courier, monospace;font-weight:norm |
|                                      | al;font-style:normal;font-size:1em;m |
|                                      | in-height:auto;background:none;color |
|                                      | :black;"}                            |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="text-align:left;white-space:n |
|                                      | owrap;top:auto;border-radius:0px;bot |
|                                      | tom:auto;float:none;left:auto;line-h |
|                                      | eight:1.1em;outline:0px;overflow:vis |
|                                      | ible;position:static;right:auto;marg |
|                                      | in:0px;border:0px;vertical-align:bas |
|                                      | eline;width:auto;box-sizing:content- |
|                                      | box;font-family:Consolas, 'Bitstream |
|                                      |  Vera Sans Mono', 'Courier New', Cou |
|                                      | rier, monospace;font-weight:normal;f |
|                                      | ont-style:normal;font-size:1em;min-h |
|                                      | eight:auto;background:none;backgroun |
|                                      | d-color:white;padding:0px 1em;">     |
|                                      |                                      |
|                                      | `  `{style="right:auto;padding:0px;b |
|                                      | order-radius:0px;border:0px;bottom:a |
|                                      | uto;float:none;left:auto;line-height |
|                                      | :1.1em;outline:0px;overflow:visible; |
|                                      | position:static;margin:0px;text-alig |
|                                      | n:left;top:auto;vertical-align:basel |
|                                      | ine;width:auto;box-sizing:content-bo |
|                                      | x;font-family:Consolas, 'Bitstream V |
|                                      | era Sans Mono', 'Courier New', Couri |
|                                      | er, monospace;font-weight:normal;fon |
|                                      | t-style:normal;font-size:1em;min-hei |
|                                      | ght:auto;background:none;"}`origin/H |
|                                      | EAD`{style="text-align:left;padding: |
|                                      | 0px;border-radius:0px;border:0px;bot |
|                                      | tom:auto;float:none;left:auto;line-h |
|                                      | eight:1.1em;outline:0px;overflow:vis |
|                                      | ible;position:static;right:auto;marg |
|                                      | in:0px;top:auto;vertical-align:basel |
|                                      | ine;width:auto;box-sizing:content-bo |
|                                      | x;font-family:Consolas, 'Bitstream V |
|                                      | era Sans Mono', 'Courier New', Couri |
|                                      | er, monospace;font-weight:normal;fon |
|                                      | t-style:normal;font-size:1em;min-hei |
|                                      | ght:auto;background:none;color:black |
|                                      | ;"}                                  |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="text-align:left;white-space:n |
|                                      | owrap;top:auto;border-radius:0px;bot |
|                                      | tom:auto;float:none;left:auto;line-h |
|                                      | eight:1.1em;outline:0px;overflow:vis |
|                                      | ible;position:static;right:auto;marg |
|                                      | in:0px;border:0px;vertical-align:bas |
|                                      | eline;width:auto;box-sizing:content- |
|                                      | box;font-family:Consolas, 'Bitstream |
|                                      |  Vera Sans Mono', 'Courier New', Cou |
|                                      | rier, monospace;font-weight:normal;f |
|                                      | ont-style:normal;font-size:1em;min-h |
|                                      | eight:auto;background:none;backgroun |
|                                      | d-color:white;padding:0px 1em;">     |
|                                      |                                      |
|                                      | `  `{style="right:auto;padding:0px;b |
|                                      | order-radius:0px;border:0px;bottom:a |
|                                      | uto;float:none;left:auto;line-height |
|                                      | :1.1em;outline:0px;overflow:visible; |
|                                      | position:static;margin:0px;text-alig |
|                                      | n:left;top:auto;vertical-align:basel |
|                                      | ine;width:auto;box-sizing:content-bo |
|                                      | x;font-family:Consolas, 'Bitstream V |
|                                      | era Sans Mono', 'Courier New', Couri |
|                                      | er, monospace;font-weight:normal;fon |
|                                      | t-style:normal;font-size:1em;min-hei |
|                                      | ght:auto;background:none;"}`origin/m |
|                                      | aster`{style="text-align:left;paddin |
|                                      | g:0px;border-radius:0px;border:0px;b |
|                                      | ottom:auto;float:none;left:auto;line |
|                                      | -height:1.1em;outline:0px;overflow:v |
|                                      | isible;position:static;right:auto;ma |
|                                      | rgin:0px;top:auto;vertical-align:bas |
|                                      | eline;width:auto;box-sizing:content- |
|                                      | box;font-family:Consolas, 'Bitstream |
|                                      |  Vera Sans Mono', 'Courier New', Cou |
|                                      | rier, monospace;font-weight:normal;f |
|                                      | ont-style:normal;font-size:1em;min-h |
|                                      | eight:auto;background:none;color:bla |
|                                      | ck;"}                                |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="text-align:left;white-space:n |
|                                      | owrap;top:auto;border-radius:0px;bot |
|                                      | tom:auto;float:none;left:auto;line-h |
|                                      | eight:1.1em;outline:0px;overflow:vis |
|                                      | ible;position:static;right:auto;marg |
|                                      | in:0px;border:0px;vertical-align:bas |
|                                      | eline;width:auto;box-sizing:content- |
|                                      | box;font-family:Consolas, 'Bitstream |
|                                      |  Vera Sans Mono', 'Courier New', Cou |
|                                      | rier, monospace;font-weight:normal;f |
|                                      | ont-style:normal;font-size:1em;min-h |
|                                      | eight:auto;background:none;backgroun |
|                                      | d-color:white;padding:0px 1em;">     |
|                                      |                                      |
|                                      | `  `{style="right:auto;padding:0px;b |
|                                      | order-radius:0px;border:0px;bottom:a |
|                                      | uto;float:none;left:auto;line-height |
|                                      | :1.1em;outline:0px;overflow:visible; |
|                                      | position:static;margin:0px;text-alig |
|                                      | n:left;top:auto;vertical-align:basel |
|                                      | ine;width:auto;box-sizing:content-bo |
|                                      | x;font-family:Consolas, 'Bitstream V |
|                                      | era Sans Mono', 'Courier New', Couri |
|                                      | er, monospace;font-weight:normal;fon |
|                                      | t-style:normal;font-size:1em;min-hei |
|                                      | ght:auto;background:none;"}`origin/v |
|                                      | 1.`{style="text-align:left;padding:0 |
|                                      | px;border-radius:0px;border:0px;bott |
|                                      | om:auto;float:none;left:auto;line-he |
|                                      | ight:1.1em;outline:0px;overflow:visi |
|                                      | ble;position:static;right:auto;margi |
|                                      | n:0px;top:auto;vertical-align:baseli |
|                                      | ne;width:auto;box-sizing:content-box |
|                                      | ;font-family:Consolas, 'Bitstream Ve |
|                                      | ra Sans Mono', 'Courier New', Courie |
|                                      | r, monospace;font-weight:normal;font |
|                                      | -style:normal;font-size:1em;min-heig |
|                                      | ht:auto;background:none;color:black; |
|                                      | "}`0`{style="text-align:left;padding |
|                                      | :0px;border-radius:0px;border:0px;bo |
|                                      | ttom:auto;float:none;left:auto;line- |
|                                      | height:1.1em;outline:0px;overflow:vi |
|                                      | sible;position:static;right:auto;mar |
|                                      | gin:0px;top:auto;vertical-align:base |
|                                      | line;width:auto;box-sizing:content-b |
|                                      | ox;font-family:Consolas, 'Bitstream  |
|                                      | Vera Sans Mono', 'Courier New', Cour |
|                                      | ier, monospace;font-weight:normal;fo |
|                                      | nt-style:normal;font-size:1em;min-he |
|                                      | ight:auto;background:none;color:rgb( |
|                                      | 0, 153, 0);"}`-stable`{style="text-a |
|                                      | lign:left;padding:0px;border-radius: |
|                                      | 0px;border:0px;bottom:auto;float:non |
|                                      | e;left:auto;line-height:1.1em;outlin |
|                                      | e:0px;overflow:visible;position:stat |
|                                      | ic;right:auto;margin:0px;top:auto;ve |
|                                      | rtical-align:baseline;width:auto;box |
|                                      | -sizing:content-box;font-family:Cons |
|                                      | olas, 'Bitstream Vera Sans Mono', 'C |
|                                      | ourier New', Courier, monospace;font |
|                                      | -weight:normal;font-style:normal;fon |
|                                      | t-size:1em;min-height:auto;backgroun |
|                                      | d:none;color:black;"}                |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="text-align:left;white-space:n |
|                                      | owrap;top:auto;border-radius:0px;bot |
|                                      | tom:auto;float:none;left:auto;line-h |
|                                      | eight:1.1em;outline:0px;overflow:vis |
|                                      | ible;position:static;right:auto;marg |
|                                      | in:0px;border:0px;vertical-align:bas |
|                                      | eline;width:auto;box-sizing:content- |
|                                      | box;font-family:Consolas, 'Bitstream |
|                                      |  Vera Sans Mono', 'Courier New', Cou |
|                                      | rier, monospace;font-weight:normal;f |
|                                      | ont-style:normal;font-size:1em;min-h |
|                                      | eight:auto;background:none;backgroun |
|                                      | d-color:white;padding:0px 1em;">     |
|                                      |                                      |
|                                      | `  `{style="right:auto;padding:0px;b |
|                                      | order-radius:0px;border:0px;bottom:a |
|                                      | uto;float:none;left:auto;line-height |
|                                      | :1.1em;outline:0px;overflow:visible; |
|                                      | position:static;margin:0px;text-alig |
|                                      | n:left;top:auto;vertical-align:basel |
|                                      | ine;width:auto;box-sizing:content-bo |
|                                      | x;font-family:Consolas, 'Bitstream V |
|                                      | era Sans Mono', 'Courier New', Couri |
|                                      | er, monospace;font-weight:normal;fon |
|                                      | t-style:normal;font-size:1em;min-hei |
|                                      | ght:auto;background:none;"}`origin/e |
|                                      | xperimental`{style="text-align:left; |
|                                      | padding:0px;border-radius:0px;border |
|                                      | :0px;bottom:auto;float:none;left:aut |
|                                      | o;line-height:1.1em;outline:0px;over |
|                                      | flow:visible;position:static;right:a |
|                                      | uto;margin:0px;top:auto;vertical-ali |
|                                      | gn:baseline;width:auto;box-sizing:co |
|                                      | ntent-box;font-family:Consolas, 'Bit |
|                                      | stream Vera Sans Mono', 'Courier New |
|                                      | ', Courier, monospace;font-weight:no |
|                                      | rmal;font-style:normal;font-size:1em |
|                                      | ;min-height:auto;background:none;col |
|                                      | or:black;"}                          |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="text-align:left;white-space:n |
|                                      | owrap;top:auto;border-radius:0px;bot |
|                                      | tom:auto;float:none;left:auto;line-h |
|                                      | eight:1.1em;outline:0px;overflow:vis |
|                                      | ible;position:static;right:auto;marg |
|                                      | in:0px;border:0px;vertical-align:bas |
|                                      | eline;width:auto;box-sizing:content- |
|                                      | box;font-family:Consolas, 'Bitstream |
|                                      |  Vera Sans Mono', 'Courier New', Cou |
|                                      | rier, monospace;font-weight:normal;f |
|                                      | ont-style:normal;font-size:1em;min-h |
|                                      | eight:auto;background:none;backgroun |
|                                      | d-color:white;padding:0px 1em;">     |
|                                      |                                      |
|                                      | `  `{style="right:auto;padding:0px;b |
|                                      | order-radius:0px;border:0px;bottom:a |
|                                      | uto;float:none;left:auto;line-height |
|                                      | :1.1em;outline:0px;overflow:visible; |
|                                      | position:static;margin:0px;text-alig |
|                                      | n:left;top:auto;vertical-align:basel |
|                                      | ine;width:auto;box-sizing:content-bo |
|                                      | x;font-family:Consolas, 'Bitstream V |
|                                      | era Sans Mono', 'Courier New', Couri |
|                                      | er, monospace;font-weight:normal;fon |
|                                      | t-style:normal;font-size:1em;min-hei |
|                                      | ght:auto;background:none;"}`linux/ma |
|                                      | ster`{style="text-align:left;padding |
|                                      | :0px;border-radius:0px;border:0px;bo |
|                                      | ttom:auto;float:none;left:auto;line- |
|                                      | height:1.1em;outline:0px;overflow:vi |
|                                      | sible;position:static;right:auto;mar |
|                                      | gin:0px;top:auto;vertical-align:base |
|                                      | line;width:auto;box-sizing:content-b |
|                                      | ox;font-family:Consolas, 'Bitstream  |
|                                      | Vera Sans Mono', 'Courier New', Cour |
|                                      | ier, monospace;font-weight:normal;fo |
|                                      | nt-style:normal;font-size:1em;min-he |
|                                      | ight:auto;background:none;color:blac |
|                                      | k;"}                                 |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | style="text-align:left;white-space:n |
|                                      | owrap;top:auto;border-radius:0px;bot |
|                                      | tom:auto;float:none;left:auto;line-h |
|                                      | eight:1.1em;outline:0px;overflow:vis |
|                                      | ible;position:static;right:auto;marg |
|                                      | in:0px;border:0px;vertical-align:bas |
|                                      | eline;width:auto;box-sizing:content- |
|                                      | box;font-family:Consolas, 'Bitstream |
|                                      |  Vera Sans Mono', 'Courier New', Cou |
|                                      | rier, monospace;font-weight:normal;f |
|                                      | ont-style:normal;font-size:1em;min-h |
|                                      | eight:auto;background:none;backgroun |
|                                      | d-color:white;padding:0px 1em;">     |
|                                      |                                      |
|                                      | `  `{style="right:auto;padding:0px;b |
|                                      | order-radius:0px;border:0px;bottom:a |
|                                      | uto;float:none;left:auto;line-height |
|                                      | :1.1em;outline:0px;overflow:visible; |
|                                      | position:static;margin:0px;text-alig |
|                                      | n:left;top:auto;vertical-align:basel |
|                                      | ine;width:auto;box-sizing:content-bo |
|                                      | x;font-family:Consolas, 'Bitstream V |
|                                      | era Sans Mono', 'Courier New', Couri |
|                                      | er, monospace;font-weight:normal;fon |
|                                      | t-style:normal;font-size:1em;min-hei |
|                                      | ght:auto;background:none;"}`linux/`{ |
|                                      | style="text-align:left;padding:0px;b |
|                                      | order-radius:0px;border:0px;bottom:a |
|                                      | uto;float:none;left:auto;line-height |
|                                      | :1.1em;outline:0px;overflow:visible; |
|                                      | position:static;right:auto;margin:0p |
|                                      | x;top:auto;vertical-align:baseline;w |
|                                      | idth:auto;box-sizing:content-box;fon |
|                                      | t-family:Consolas, 'Bitstream Vera S |
|                                      | ans Mono', 'Courier New', Courier, m |
|                                      | onospace;font-weight:normal;font-sty |
|                                      | le:normal;font-size:1em;min-height:a |
|                                      | uto;background:none;color:black;"}`n |
|                                      | ew`{style="text-align:left;padding:0 |
|                                      | px;border-radius:0px;border:0px;bott |
|                                      | om:auto;float:none;left:auto;line-he |
|                                      | ight:1.1em;outline:0px;overflow:visi |
|                                      | ble;position:static;right:auto;margi |
|                                      | n:0px;top:auto;vertical-align:baseli |
|                                      | ne;width:auto;box-sizing:content-box |
|                                      | ;font-family:Consolas, 'Bitstream Ve |
|                                      | ra Sans Mono', 'Courier New', Courie |
|                                      | r, monospace;background:none;font-st |
|                                      | yle:normal;font-size:1em;min-height: |
|                                      | auto;font-weight:bold;color:rgb(0, 1 |
|                                      | 02, 153);"}`-widgets`{style="text-al |
|                                      | ign:left;padding:0px;border-radius:0 |
|                                      | px;border:0px;bottom:auto;float:none |
|                                      | ;left:auto;line-height:1.1em;outline |
|                                      | :0px;overflow:visible;position:stati |
|                                      | c;right:auto;margin:0px;top:auto;ver |
|                                      | tical-align:baseline;width:auto;box- |
|                                      | sizing:content-box;font-family:Conso |
|                                      | las, 'Bitstream Vera Sans Mono', 'Co |
|                                      | urier New', Courier, monospace;font- |
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

你可以用gitk查看你做了些什么：``{style="padding:0px;margin:0px;"}

`$ gitk --all &`{style="padding:0px;margin:0px;"}

</div>

</div>

</div>

</div>

</div>

</div>

</div>

</div>

</div>

\

</div>
