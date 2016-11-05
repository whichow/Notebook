<span
style="margin: 0px; padding: 0px; border: 0px; font-style: inherit; font-variant: inherit; font-weight: inherit; font-stretch: inherit; font-size: inherit; line-height: inherit; font-family: inherit; vertical-align: baseline;">（1</span><span
style="margin: 0px; padding: 0px; border: 0px; font-style: inherit; font-variant: inherit; font-weight: inherit; font-stretch: inherit; font-size: inherit; line-height: inherit; font-family: inherit; vertical-align: baseline;">）以r</span><span
style="margin: 0px; padding: 0px; border: 0px; font-style: inherit; font-variant: inherit; font-weight: inherit; font-stretch: inherit; font-size: inherit; line-height: inherit; font-family: inherit; vertical-align: baseline;">或R</span><span
style="margin: 0px; padding: 0px; border: 0px; font-style: inherit; font-variant: inherit; font-weight: inherit; font-stretch: inherit; font-size: inherit; line-height: inherit; font-family: inherit; vertical-align: baseline;">开头的python</span><span
style="margin: 0px; padding: 0px; border: 0px; font-style: inherit; font-variant: inherit; font-weight: inherit; font-stretch: inherit; font-size: inherit; line-height: inherit; font-family: inherit; vertical-align: baseline;">中的字符串表示（非转义的）原始字符串</span>

python里面的字符，如果开头处有个r，比如：

(r’\^time/plus/\\d{1,2}/\$’, hours\_ahead)

说明字符串r"XXX"中的XXX是普通字符。

有普通字符相比，其他相对特殊的字符，其中可能包含转义字符，即那些，反斜杠加上对应字母，表示对应的特殊含义的，比如最常见的”\\n"表示换行，"\\t"表示Tab等。

而如果是以r开头，那么说明后面的字符，都是普通的字符了，即如果是“\\n”那么表示一个反斜杠字符，一个字母n，而不是表示换行了。

以r开头的字符，常用于正则表达式，对应着re模块。

关于re模块，详情自己google搜索“python re”。

举例：

原始字符串操作符(r/R),能方便处理反斜杠:

<div
style="padding: 0px; border: 0px; font-variant-ligatures: normal; font-stretch: inherit; font-size: 14px; line-height: inherit; font-family: 'Lucida Grande', 'Helvetica Neue', Helvetica, Arial, sans-serif; vertical-align: baseline; color: rgb(102, 102, 102); orphans: 2; widows: 2; background-color: rgb(255, 255, 255);">

<div id="highlighter_972970" class="syntaxhighlighter notranslate py"
style="padding: 0px; border: 0px; font-style: inherit; font-variant: inherit; font-weight: inherit; font-stretch: inherit; line-height: inherit; font-family: inherit; vertical-align: baseline; width: 598px; margin-top: 1em !important; margin-bottom: 1em !important; font-size: 1em !important; position: relative !important; overflow: auto !important; background-color: rgb(15, 25, 42) !important;">

<div class="toolbar"
style="font-variant: inherit; font-stretch: inherit; padding: 0px !important; border: none !important; font-size: 10px !important; line-height: 1.1em !important; font-family: Consolas, 'Bitstream Vera Sans Mono', 'Courier New', Courier, monospace !important; vertical-align: baseline !important; border-radius: 0px !important; bottom: auto !important; float: none !important; height: 11px !important; left: auto !important; outline: 0px !important; overflow: visible !important; position: absolute !important; right: 1px !important; top: 1px !important; width: 11px !important; box-sizing: content-box !important; min-height: auto !important; z-index: 10 !important; color: rgb(209, 237, 255) !important; background: rgb(67, 90, 95) !important;">

<span
style="margin: 0px; padding: 0px; border: 0px; font-style: inherit; font-variant: inherit; font-weight: inherit; font-stretch: inherit; font-size: inherit; line-height: inherit; font-family: inherit; vertical-align: baseline;">[?](http://www.crifan.com/python_string_with_leading_char_r_u/#){.toolbar_item
.command_help .help}</span>

</div>

+--------------------------------------+--------------------------------------+
| <div                                 | <div class="container"               |
| class="line number1 index0 alt2"     | style="font-variant: inherit; font-s |
| style="font-variant: inherit; font-s | tretch: inherit; padding: 0px !impor |
| tretch: inherit; padding: 0px 0.5em  | tant; border: 0px !important; font-s |
| 0px 1em !important; border-width: 0p | ize: 1em !important; line-height: 1. |
| x 3px 0px 0px !important; border-top | 1em !important; vertical-align: base |
| -style: initial !important; border-r | line !important; border-radius: 0px  |
| ight-style: solid !important; border | !important; bottom: auto !important; |
| -bottom-style: initial !important; b |  float: none !important; height: aut |
| order-left-style: initial !important | o !important; left: auto !important; |
| ; border-top-color: initial !importa |  outline: 0px !important; overflow:  |
| nt; border-right-color: rgb(67, 90,  | visible !important; position: relati |
| 95) !important; border-bottom-color: | ve !important; right: auto !importan |
|  initial !important; border-left-col | t; top: auto !important; width: auto |
| or: initial !important; border-image |  !important; box-sizing: content-box |
| -source: initial !important; border- |  !important; min-height: auto !impor |
| image-slice: initial !important; bor | tant; background: none !important;"> |
| der-image-width: initial !important; |                                      |
|  border-image-outset: initial !impor | <div                                 |
| tant; border-image-repeat: initial ! | class="line number1 index0 alt2"     |
| important; font-size: 1em !important | style="font-variant: inherit; font-s |
| ; line-height: 1.1em !important; ver | tretch: inherit; padding: 0px 1em !i |
| tical-align: baseline !important; bo | mportant; border: 0px !important; fo |
| rder-radius: 0px !important; bottom: | nt-size: 1em !important; line-height |
|  auto !important; float: none !impor | : 1.1em !important; vertical-align:  |
| tant; height: auto !important; left: | baseline !important; border-radius:  |
|  auto !important; outline: 0px !impo | 0px !important; bottom: auto !import |
| rtant; overflow: visible !important; | ant; float: none !important; height: |
|  position: static !important; right: |  auto !important; left: auto !import |
|  auto !important; text-align: right  | ant; outline: 0px !important; overfl |
| !important; top: auto !important; wi | ow: visible !important; position: st |
| dth: auto !important; box-sizing: co | atic !important; right: auto !import |
| ntent-box !important; min-height: au | ant; top: auto !important; width: au |
| to !important; white-space: pre !imp | to !important; box-sizing: content-b |
| ortant; background-image: none !impo | ox !important; min-height: auto !imp |
| rtant; background-attachment: initia | ortant; white-space: pre !important; |
| l !important; background-size: initi |  background-image: none !important;  |
| al !important; background-origin: in | background-attachment: initial !impo |
| itial !important; background-clip: i | rtant; background-size: initial !imp |
| nitial !important; background-positi | ortant; background-origin: initial ! |
| on: initial !important; background-r | important; background-clip: initial  |
| epeat: initial !important;">         | !important; background-position: ini |
|                                      | tial !important; background-repeat:  |
| 1                                    | initial !important;">                |
|                                      |                                      |
| </div>                               | `f `{.py .plain                      |
|                                      | style="font-variant: inherit; font-s |
| <div                                 | tretch: inherit; margin-top: 0px !im |
| class="line number2 index1 alt1"     | portant; margin-bottom: 0px !importa |
| style="font-variant: inherit; font-s | nt; padding: 0px !important; border: |
| tretch: inherit; padding: 0px 0.5em  |  0px !important; font-size: 1em !imp |
| 0px 1em !important; border-width: 0p | ortant; line-height: 1.1em !importan |
| x 3px 0px 0px !important; border-top | t; font-family: Consolas, 'Bitstream |
| -style: initial !important; border-r |  Vera Sans Mono', 'Courier New', Cou |
| ight-style: solid !important; border | rier, monospace !important; vertical |
| -bottom-style: initial !important; b | -align: baseline !important; color:  |
| order-left-style: initial !important | rgb(209, 237, 255) !important; borde |
| ; border-top-color: initial !importa | r-radius: 0px !important; bottom: au |
| nt; border-right-color: rgb(67, 90,  | to !important; float: none !importan |
| 95) !important; border-bottom-color: | t; height: auto !important; left: au |
|  initial !important; border-left-col | to !important; outline: 0px !importa |
| or: initial !important; border-image | nt; overflow: visible !important; po |
| -source: initial !important; border- | sition: static !important; right: au |
| image-slice: initial !important; bor | to !important; top: auto !important; |
| der-image-width: initial !important; |  width: auto !important; box-sizing: |
|  border-image-outset: initial !impor |  content-box !important; min-height: |
| tant; border-image-repeat: initial ! |  auto !important; background: none ! |
| important; font-size: 1em !important | important;"}`=`{.py                  |
| ; line-height: 1.1em !important; ver | .keyword                             |
| tical-align: baseline !important; bo | style="font-variant: inherit; font-s |
| rder-radius: 0px !important; bottom: | tretch: inherit; margin-top: 0px !im |
|  auto !important; float: none !impor | portant; margin-bottom: 0px !importa |
| tant; height: auto !important; left: | nt; padding: 0px !important; border: |
|  auto !important; outline: 0px !impo |  0px !important; font-size: 1em !imp |
| rtant; overflow: visible !important; | ortant; line-height: 1.1em !importan |
|  position: static !important; right: | t; font-family: Consolas, 'Bitstream |
|  auto !important; text-align: right  |  Vera Sans Mono', 'Courier New', Cou |
| !important; top: auto !important; wi | rier, monospace !important; vertical |
| dth: auto !important; box-sizing: co | -align: baseline !important; color:  |
| ntent-box !important; min-height: au | rgb(180, 61, 61) !important; border- |
| to !important; white-space: pre !imp | radius: 0px !important; bottom: auto |
| ortant; background-image: none !impo |  !important; float: none !important; |
| rtant; background-attachment: initia |  height: auto !important; left: auto |
| l !important; background-size: initi |  !important; outline: 0px !important |
| al !important; background-origin: in | ; overflow: visible !important; posi |
| itial !important; background-clip: i | tion: static !important; right: auto |
| nitial !important; background-positi |  !important; top: auto !important; w |
| on: initial !important; background-r | idth: auto !important; box-sizing: c |
| epeat: initial !important;">         | ontent-box !important; min-height: a |
|                                      | uto !important; background: none !im |
| 2                                    | portant;"}                           |
|                                      | `open`{.py .functions                |
| </div>                               | style="font-variant: inherit; font-s |
|                                      | tretch: inherit; margin-top: 0px !im |
| <div                                 | portant; margin-bottom: 0px !importa |
| class="line number3 index2 alt2"     | nt; padding: 0px !important; border: |
| style="font-variant: inherit; font-s |  0px !important; font-size: 1em !imp |
| tretch: inherit; padding: 0px 0.5em  | ortant; line-height: 1.1em !importan |
| 0px 1em !important; border-width: 0p | t; font-family: Consolas, 'Bitstream |
| x 3px 0px 0px !important; border-top |  Vera Sans Mono', 'Courier New', Cou |
| -style: initial !important; border-r | rier, monospace !important; vertical |
| ight-style: solid !important; border | -align: baseline !important; color:  |
| -bottom-style: initial !important; b | rgb(255, 170, 62) !important; border |
| order-left-style: initial !important | -radius: 0px !important; bottom: aut |
| ; border-top-color: initial !importa | o !important; float: none !important |
| nt; border-right-color: rgb(67, 90,  | ; height: auto !important; left: aut |
| 95) !important; border-bottom-color: | o !important; outline: 0px !importan |
|  initial !important; border-left-col | t; overflow: visible !important; pos |
| or: initial !important; border-image | ition: static !important; right: aut |
| -source: initial !important; border- | o !important; top: auto !important;  |
| image-slice: initial !important; bor | width: auto !important; box-sizing:  |
| der-image-width: initial !important; | content-box !important; min-height:  |
|  border-image-outset: initial !impor | auto !important; background: none !i |
| tant; border-image-repeat: initial ! | mportant;"}`(r`{.py                  |
| important; font-size: 1em !important | .plain                               |
| ; line-height: 1.1em !important; ver | style="font-variant: inherit; font-s |
| tical-align: baseline !important; bo | tretch: inherit; margin-top: 0px !im |
| rder-radius: 0px !important; bottom: | portant; margin-bottom: 0px !importa |
|  auto !important; float: none !impor | nt; padding: 0px !important; border: |
| tant; height: auto !important; left: |  0px !important; font-size: 1em !imp |
|  auto !important; outline: 0px !impo | ortant; line-height: 1.1em !importan |
| rtant; overflow: visible !important; | t; font-family: Consolas, 'Bitstream |
|  position: static !important; right: |  Vera Sans Mono', 'Courier New', Cou |
|  auto !important; text-align: right  | rier, monospace !important; vertical |
| !important; top: auto !important; wi | -align: baseline !important; color:  |
| dth: auto !important; box-sizing: co | rgb(209, 237, 255) !important; borde |
| ntent-box !important; min-height: au | r-radius: 0px !important; bottom: au |
| to !important; white-space: pre !imp | to !important; float: none !importan |
| ortant; background-image: none !impo | t; height: auto !important; left: au |
| rtant; background-attachment: initia | to !important; outline: 0px !importa |
| l !important; background-size: initi | nt; overflow: visible !important; po |
| al !important; background-origin: in | sition: static !important; right: au |
| itial !important; background-clip: i | to !important; top: auto !important; |
| nitial !important; background-positi |  width: auto !important; box-sizing: |
| on: initial !important; background-r |  content-box !important; min-height: |
| epeat: initial !important;">         |  auto !important; background: none ! |
|                                      | important;"}`'C:\Program Files\Adobe |
| 3                                    | \Reader 9.0\Setup Files\setup.ini'`{ |
|                                      | .py                                  |
| </div>                               | .string                              |
|                                      | style="font-variant: inherit; font-s |
| <div                                 | tretch: inherit; margin-top: 0px !im |
| class="line number4 index3 alt1"     | portant; margin-bottom: 0px !importa |
| style="font-variant: inherit; font-s | nt; padding: 0px !important; border: |
| tretch: inherit; padding: 0px 0.5em  |  0px !important; font-size: 1em !imp |
| 0px 1em !important; border-width: 0p | ortant; line-height: 1.1em !importan |
| x 3px 0px 0px !important; border-top | t; font-family: Consolas, 'Bitstream |
| -style: initial !important; border-r |  Vera Sans Mono', 'Courier New', Cou |
| ight-style: solid !important; border | rier, monospace !important; vertical |
| -bottom-style: initial !important; b | -align: baseline !important; color:  |
| order-left-style: initial !important | rgb(29, 193, 22) !important; border- |
| ; border-top-color: initial !importa | radius: 0px !important; bottom: auto |
| nt; border-right-color: rgb(67, 90,  |  !important; float: none !important; |
| 95) !important; border-bottom-color: |  height: auto !important; left: auto |
|  initial !important; border-left-col |  !important; outline: 0px !important |
| or: initial !important; border-image | ; overflow: visible !important; posi |
| -source: initial !important; border- | tion: static !important; right: auto |
| image-slice: initial !important; bor |  !important; top: auto !important; w |
| der-image-width: initial !important; | idth: auto !important; box-sizing: c |
|  border-image-outset: initial !impor | ontent-box !important; min-height: a |
| tant; border-image-repeat: initial ! | uto !important; background: none !im |
| important; font-size: 1em !important | portant;"}`,`{.py                    |
| ; line-height: 1.1em !important; ver | .plain                               |
| tical-align: baseline !important; bo | style="font-variant: inherit; font-s |
| rder-radius: 0px !important; bottom: | tretch: inherit; margin-top: 0px !im |
|  auto !important; float: none !impor | portant; margin-bottom: 0px !importa |
| tant; height: auto !important; left: | nt; padding: 0px !important; border: |
|  auto !important; outline: 0px !impo |  0px !important; font-size: 1em !imp |
| rtant; overflow: visible !important; | ortant; line-height: 1.1em !importan |
|  position: static !important; right: | t; font-family: Consolas, 'Bitstream |
|  auto !important; text-align: right  |  Vera Sans Mono', 'Courier New', Cou |
| !important; top: auto !important; wi | rier, monospace !important; vertical |
| dth: auto !important; box-sizing: co | -align: baseline !important; color:  |
| ntent-box !important; min-height: au | rgb(209, 237, 255) !important; borde |
| to !important; white-space: pre !imp | r-radius: 0px !important; bottom: au |
| ortant; background-image: none !impo | to !important; float: none !importan |
| rtant; background-attachment: initia | t; height: auto !important; left: au |
| l !important; background-size: initi | to !important; outline: 0px !importa |
| al !important; background-origin: in | nt; overflow: visible !important; po |
| itial !important; background-clip: i | sition: static !important; right: au |
| nitial !important; background-positi | to !important; top: auto !important; |
| on: initial !important; background-r |  width: auto !important; box-sizing: |
| epeat: initial !important;">         |  content-box !important; min-height: |
|                                      |  auto !important; background: none ! |
| 4                                    | important;"}`'r'`{.py                |
|                                      | .string                              |
| </div>                               | style="font-variant: inherit; font-s |
|                                      | tretch: inherit; margin-top: 0px !im |
|                                      | portant; margin-bottom: 0px !importa |
|                                      | nt; padding: 0px !important; border: |
|                                      |  0px !important; font-size: 1em !imp |
|                                      | ortant; line-height: 1.1em !importan |
|                                      | t; font-family: Consolas, 'Bitstream |
|                                      |  Vera Sans Mono', 'Courier New', Cou |
|                                      | rier, monospace !important; vertical |
|                                      | -align: baseline !important; color:  |
|                                      | rgb(29, 193, 22) !important; border- |
|                                      | radius: 0px !important; bottom: auto |
|                                      |  !important; float: none !important; |
|                                      |  height: auto !important; left: auto |
|                                      |  !important; outline: 0px !important |
|                                      | ; overflow: visible !important; posi |
|                                      | tion: static !important; right: auto |
|                                      |  !important; top: auto !important; w |
|                                      | idth: auto !important; box-sizing: c |
|                                      | ontent-box !important; min-height: a |
|                                      | uto !important; background: none !im |
|                                      | portant;"}`) `{.py                   |
|                                      | .plain                               |
|                                      | style="font-variant: inherit; font-s |
|                                      | tretch: inherit; margin-top: 0px !im |
|                                      | portant; margin-bottom: 0px !importa |
|                                      | nt; padding: 0px !important; border: |
|                                      |  0px !important; font-size: 1em !imp |
|                                      | ortant; line-height: 1.1em !importan |
|                                      | t; font-family: Consolas, 'Bitstream |
|                                      |  Vera Sans Mono', 'Courier New', Cou |
|                                      | rier, monospace !important; vertical |
|                                      | -align: baseline !important; color:  |
|                                      | rgb(209, 237, 255) !important; borde |
|                                      | r-radius: 0px !important; bottom: au |
|                                      | to !important; float: none !importan |
|                                      | t; height: auto !important; left: au |
|                                      | to !important; outline: 0px !importa |
|                                      | nt; overflow: visible !important; po |
|                                      | sition: static !important; right: au |
|                                      | to !important; top: auto !important; |
|                                      |  width: auto !important; box-sizing: |
|                                      |  content-box !important; min-height: |
|                                      |  auto !important; background: none ! |
|                                      | important;"}                         |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | class="line number2 index1 alt1"     |
|                                      | style="font-variant: inherit; font-s |
|                                      | tretch: inherit; padding: 0px 1em !i |
|                                      | mportant; border: 0px !important; fo |
|                                      | nt-size: 1em !important; line-height |
|                                      | : 1.1em !important; vertical-align:  |
|                                      | baseline !important; border-radius:  |
|                                      | 0px !important; bottom: auto !import |
|                                      | ant; float: none !important; height: |
|                                      |  auto !important; left: auto !import |
|                                      | ant; outline: 0px !important; overfl |
|                                      | ow: visible !important; position: st |
|                                      | atic !important; right: auto !import |
|                                      | ant; top: auto !important; width: au |
|                                      | to !important; box-sizing: content-b |
|                                      | ox !important; min-height: auto !imp |
|                                      | ortant; white-space: pre !important; |
|                                      |  background-image: none !important;  |
|                                      | background-attachment: initial !impo |
|                                      | rtant; background-size: initial !imp |
|                                      | ortant; background-origin: initial ! |
|                                      | important; background-clip: initial  |
|                                      | !important; background-position: ini |
|                                      | tial !important; background-repeat:  |
|                                      | initial !important;">                |
|                                      |                                      |
|                                      | `for`{.py .keyword                   |
|                                      | style="font-variant: inherit; font-s |
|                                      | tretch: inherit; margin-top: 0px !im |
|                                      | portant; margin-bottom: 0px !importa |
|                                      | nt; padding: 0px !important; border: |
|                                      |  0px !important; font-size: 1em !imp |
|                                      | ortant; line-height: 1.1em !importan |
|                                      | t; font-family: Consolas, 'Bitstream |
|                                      |  Vera Sans Mono', 'Courier New', Cou |
|                                      | rier, monospace !important; vertical |
|                                      | -align: baseline !important; color:  |
|                                      | rgb(180, 61, 61) !important; border- |
|                                      | radius: 0px !important; bottom: auto |
|                                      |  !important; float: none !important; |
|                                      |  height: auto !important; left: auto |
|                                      |  !important; outline: 0px !important |
|                                      | ; overflow: visible !important; posi |
|                                      | tion: static !important; right: auto |
|                                      |  !important; top: auto !important; w |
|                                      | idth: auto !important; box-sizing: c |
|                                      | ontent-box !important; min-height: a |
|                                      | uto !important; background: none !im |
|                                      | portant;"}                           |
|                                      | `i `{.py .plain                      |
|                                      | style="font-variant: inherit; font-s |
|                                      | tretch: inherit; margin-top: 0px !im |
|                                      | portant; margin-bottom: 0px !importa |
|                                      | nt; padding: 0px !important; border: |
|                                      |  0px !important; font-size: 1em !imp |
|                                      | ortant; line-height: 1.1em !importan |
|                                      | t; font-family: Consolas, 'Bitstream |
|                                      |  Vera Sans Mono', 'Courier New', Cou |
|                                      | rier, monospace !important; vertical |
|                                      | -align: baseline !important; color:  |
|                                      | rgb(209, 237, 255) !important; borde |
|                                      | r-radius: 0px !important; bottom: au |
|                                      | to !important; float: none !importan |
|                                      | t; height: auto !important; left: au |
|                                      | to !important; outline: 0px !importa |
|                                      | nt; overflow: visible !important; po |
|                                      | sition: static !important; right: au |
|                                      | to !important; top: auto !important; |
|                                      |  width: auto !important; box-sizing: |
|                                      |  content-box !important; min-height: |
|                                      |  auto !important; background: none ! |
|                                      | important;"}`in`{.py                 |
|                                      | .keyword                             |
|                                      | style="font-variant: inherit; font-s |
|                                      | tretch: inherit; margin-top: 0px !im |
|                                      | portant; margin-bottom: 0px !importa |
|                                      | nt; padding: 0px !important; border: |
|                                      |  0px !important; font-size: 1em !imp |
|                                      | ortant; line-height: 1.1em !importan |
|                                      | t; font-family: Consolas, 'Bitstream |
|                                      |  Vera Sans Mono', 'Courier New', Cou |
|                                      | rier, monospace !important; vertical |
|                                      | -align: baseline !important; color:  |
|                                      | rgb(180, 61, 61) !important; border- |
|                                      | radius: 0px !important; bottom: auto |
|                                      |  !important; float: none !important; |
|                                      |  height: auto !important; left: auto |
|                                      |  !important; outline: 0px !important |
|                                      | ; overflow: visible !important; posi |
|                                      | tion: static !important; right: auto |
|                                      |  !important; top: auto !important; w |
|                                      | idth: auto !important; box-sizing: c |
|                                      | ontent-box !important; min-height: a |
|                                      | uto !important; background: none !im |
|                                      | portant;"}                           |
|                                      | `f: `{.py .plain                     |
|                                      | style="font-variant: inherit; font-s |
|                                      | tretch: inherit; margin-top: 0px !im |
|                                      | portant; margin-bottom: 0px !importa |
|                                      | nt; padding: 0px !important; border: |
|                                      |  0px !important; font-size: 1em !imp |
|                                      | ortant; line-height: 1.1em !importan |
|                                      | t; font-family: Consolas, 'Bitstream |
|                                      |  Vera Sans Mono', 'Courier New', Cou |
|                                      | rier, monospace !important; vertical |
|                                      | -align: baseline !important; color:  |
|                                      | rgb(209, 237, 255) !important; borde |
|                                      | r-radius: 0px !important; bottom: au |
|                                      | to !important; float: none !importan |
|                                      | t; height: auto !important; left: au |
|                                      | to !important; outline: 0px !importa |
|                                      | nt; overflow: visible !important; po |
|                                      | sition: static !important; right: au |
|                                      | to !important; top: auto !important; |
|                                      |  width: auto !important; box-sizing: |
|                                      |  content-box !important; min-height: |
|                                      |  auto !important; background: none ! |
|                                      | important;"}                         |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | class="line number3 index2 alt2"     |
|                                      | style="font-variant: inherit; font-s |
|                                      | tretch: inherit; padding: 0px 1em !i |
|                                      | mportant; border: 0px !important; fo |
|                                      | nt-size: 1em !important; line-height |
|                                      | : 1.1em !important; vertical-align:  |
|                                      | baseline !important; border-radius:  |
|                                      | 0px !important; bottom: auto !import |
|                                      | ant; float: none !important; height: |
|                                      |  auto !important; left: auto !import |
|                                      | ant; outline: 0px !important; overfl |
|                                      | ow: visible !important; position: st |
|                                      | atic !important; right: auto !import |
|                                      | ant; top: auto !important; width: au |
|                                      | to !important; box-sizing: content-b |
|                                      | ox !important; min-height: auto !imp |
|                                      | ortant; white-space: pre !important; |
|                                      |  background-image: none !important;  |
|                                      | background-attachment: initial !impo |
|                                      | rtant; background-size: initial !imp |
|                                      | ortant; background-origin: initial ! |
|                                      | important; background-clip: initial  |
|                                      | !important; background-position: ini |
|                                      | tial !important; background-repeat:  |
|                                      | initial !important;">                |
|                                      |                                      |
|                                      | `    `{.py .spaces                   |
|                                      | style="font-variant: inherit; font-s |
|                                      | tretch: inherit; color: rgb(0, 0, 0) |
|                                      | ; margin-top: 0px !important; margin |
|                                      | -bottom: 0px !important; padding: 0p |
|                                      | x !important; border: 0px !important |
|                                      | ; font-size: 1em !important; line-he |
|                                      | ight: 1.1em !important; font-family: |
|                                      |  Consolas, 'Bitstream Vera Sans Mono |
|                                      | ', 'Courier New', Courier, monospace |
|                                      |  !important; vertical-align: baselin |
|                                      | e !important; border-radius: 0px !im |
|                                      | portant; bottom: auto !important; fl |
|                                      | oat: none !important; height: auto ! |
|                                      | important; left: auto !important; ou |
|                                      | tline: 0px !important; overflow: vis |
|                                      | ible !important; position: static !i |
|                                      | mportant; right: auto !important; to |
|                                      | p: auto !important; width: auto !imp |
|                                      | ortant; box-sizing: content-box !imp |
|                                      | ortant; min-height: auto !important; |
|                                      |  background: none !important;"}`prin |
|                                      | t`{.py                               |
|                                      | .functions                           |
|                                      | style="font-variant: inherit; font-s |
|                                      | tretch: inherit; margin-top: 0px !im |
|                                      | portant; margin-bottom: 0px !importa |
|                                      | nt; padding: 0px !important; border: |
|                                      |  0px !important; font-size: 1em !imp |
|                                      | ortant; line-height: 1.1em !importan |
|                                      | t; font-family: Consolas, 'Bitstream |
|                                      |  Vera Sans Mono', 'Courier New', Cou |
|                                      | rier, monospace !important; vertical |
|                                      | -align: baseline !important; color:  |
|                                      | rgb(255, 170, 62) !important; border |
|                                      | -radius: 0px !important; bottom: aut |
|                                      | o !important; float: none !important |
|                                      | ; height: auto !important; left: aut |
|                                      | o !important; outline: 0px !importan |
|                                      | t; overflow: visible !important; pos |
|                                      | ition: static !important; right: aut |
|                                      | o !important; top: auto !important;  |
|                                      | width: auto !important; box-sizing:  |
|                                      | content-box !important; min-height:  |
|                                      | auto !important; background: none !i |
|                                      | mportant;"}                          |
|                                      | `i `{.py .plain                      |
|                                      | style="font-variant: inherit; font-s |
|                                      | tretch: inherit; margin-top: 0px !im |
|                                      | portant; margin-bottom: 0px !importa |
|                                      | nt; padding: 0px !important; border: |
|                                      |  0px !important; font-size: 1em !imp |
|                                      | ortant; line-height: 1.1em !importan |
|                                      | t; font-family: Consolas, 'Bitstream |
|                                      |  Vera Sans Mono', 'Courier New', Cou |
|                                      | rier, monospace !important; vertical |
|                                      | -align: baseline !important; color:  |
|                                      | rgb(209, 237, 255) !important; borde |
|                                      | r-radius: 0px !important; bottom: au |
|                                      | to !important; float: none !importan |
|                                      | t; height: auto !important; left: au |
|                                      | to !important; outline: 0px !importa |
|                                      | nt; overflow: visible !important; po |
|                                      | sition: static !important; right: au |
|                                      | to !important; top: auto !important; |
|                                      |  width: auto !important; box-sizing: |
|                                      |  content-box !important; min-height: |
|                                      |  auto !important; background: none ! |
|                                      | important;"}                         |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | <div                                 |
|                                      | class="line number4 index3 alt1"     |
|                                      | style="font-variant: inherit; font-s |
|                                      | tretch: inherit; padding: 0px 1em !i |
|                                      | mportant; border: 0px !important; fo |
|                                      | nt-size: 1em !important; line-height |
|                                      | : 1.1em !important; vertical-align:  |
|                                      | baseline !important; border-radius:  |
|                                      | 0px !important; bottom: auto !import |
|                                      | ant; float: none !important; height: |
|                                      |  auto !important; left: auto !import |
|                                      | ant; outline: 0px !important; overfl |
|                                      | ow: visible !important; position: st |
|                                      | atic !important; right: auto !import |
|                                      | ant; top: auto !important; width: au |
|                                      | to !important; box-sizing: content-b |
|                                      | ox !important; min-height: auto !imp |
|                                      | ortant; white-space: pre !important; |
|                                      |  background-image: none !important;  |
|                                      | background-attachment: initial !impo |
|                                      | rtant; background-size: initial !imp |
|                                      | ortant; background-origin: initial ! |
|                                      | important; background-clip: initial  |
|                                      | !important; background-position: ini |
|                                      | tial !important; background-repeat:  |
|                                      | initial !important;">                |
|                                      |                                      |
|                                      | `f.close()`{.py .plain               |
|                                      | style="font-variant: inherit; font-s |
|                                      | tretch: inherit; margin-top: 0px !im |
|                                      | portant; margin-bottom: 0px !importa |
|                                      | nt; padding: 0px !important; border: |
|                                      |  0px !important; font-size: 1em !imp |
|                                      | ortant; line-height: 1.1em !importan |
|                                      | t; font-family: Consolas, 'Bitstream |
|                                      |  Vera Sans Mono', 'Courier New', Cou |
|                                      | rier, monospace !important; vertical |
|                                      | -align: baseline !important; color:  |
|                                      | rgb(209, 237, 255) !important; borde |
|                                      | r-radius: 0px !important; bottom: au |
|                                      | to !important; float: none !importan |
|                                      | t; height: auto !important; left: au |
|                                      | to !important; outline: 0px !importa |
|                                      | nt; overflow: visible !important; po |
|                                      | sition: static !important; right: au |
|                                      | to !important; top: auto !important; |
|                                      |  width: auto !important; box-sizing: |
|                                      |  content-box !important; min-height: |
|                                      |  auto !important; background: none ! |
|                                      | important;"}                         |
|                                      |                                      |
|                                      | </div>                               |
|                                      |                                      |
|                                      | </div>                               |
+--------------------------------------+--------------------------------------+

</div>

</div>

<span
style="margin: 0px; padding: 0px; border: 0px; font-style: inherit; font-variant: inherit; font-weight: inherit; font-stretch: inherit; font-size: inherit; line-height: inherit; font-family: inherit; vertical-align: baseline;">（2</span><span
style="margin: 0px; padding: 0px; border: 0px; font-style: inherit; font-variant: inherit; font-weight: inherit; font-stretch: inherit; font-size: inherit; line-height: inherit; font-family: inherit; vertical-align: baseline;">）以u</span><span
style="margin: 0px; padding: 0px; border: 0px; font-style: inherit; font-variant: inherit; font-weight: inherit; font-stretch: inherit; font-size: inherit; line-height: inherit; font-family: inherit; vertical-align: baseline;">或U</span><span
style="margin: 0px; padding: 0px; border: 0px; font-style: inherit; font-variant: inherit; font-weight: inherit; font-stretch: inherit; font-size: inherit; line-height: inherit; font-family: inherit; vertical-align: baseline;">开头的字符串表示unicode</span><span
style="margin: 0px; padding: 0px; border: 0px; font-style: inherit; font-variant: inherit; font-weight: inherit; font-stretch: inherit; font-size: inherit; line-height: inherit; font-family: inherit; vertical-align: baseline;">字符串</span>

Unicode是书写国际文本的标准方法。如果你想要用非英语写文本,那么你需要有一个支持Unicode的编辑器。

类似地,Python允许你处理Unicode文本——你只需要在字符串前加上前缀u或U。

举例：

+--------------------------------------------------------------------------+
| u"This is a Unicode string."                                             |
+--------------------------------------------------------------------------+

<div class="wumii-hook"
style="padding: 0px; border: 0px; font-variant-ligatures: normal; font-stretch: inherit; font-size: 14px; line-height: inherit; font-family: 'Lucida Grande', 'Helvetica Neue', Helvetica, Arial, sans-serif; vertical-align: baseline; color: rgb(102, 102, 102); orphans: 2; widows: 2; background-color: rgb(255, 255, 255);">

\
<div style="color:gray">

来源： <http://www.crifan.com/python_string_with_leading_char_r_u/>

</div>

</div>
