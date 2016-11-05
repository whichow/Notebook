Invoke Tutorial: Passing parameters (Part 3) | manski's blog
<div>

\
<div style="font-size: 16px">

<div
style="font-size:100%;font-family:sans-serif;color:rgb(34, 34, 34);background:url(&quot;&quot;) 50% 0% no-repeat fixed rgb(17, 17, 17);">

<div style="font-size:1em;line-height:1.4;">

<div
style="font-style:normal;font-variant:normal;font-weight:200;font-stretch:normal;font-size:1.1em;line-height:1.7;font-family:ProximaNovaRegular, 'Helvetica Neue', Helvetica, Arial, sans-serif;color:rgb(150, 168, 185);box-shadow:rgb(0, 0, 0) 0px 0px 20px;background-color:rgb(42, 42, 42);">

<div style="background:url(&quot;&quot;) 50% 100% no-repeat;">

<div>

<div style="display:block;margin:1em 2em 2em;clear:both;">

<div style="display:block;position:relative;">

[P/Invoke Tutorial: Passing parameters (Part 3)](http://manski.net/2012/06/pinvoke-tutorial-passing-parameters-part-3/ "Permalink to this page") {#pinvoke-tutorial-passing-parameters-part-3 style="color:rgb(255, 255, 255);font-family:'Crete Round', serif;font-style:normal;font-weight:normal;text-align:center;word-wrap:break-word;text-shadow:rgb(0, 0, 0) 0px 3px 5px;font-size:200%;"}
================================================================================================================================================

<div
style="font-size:90%;text-align:center;margin-top:-2em;margin-bottom:2em;">

<span style="padding:0px 0.4em;"><span
style="font-family:icons;font-weight:normal;font-style:normal;display:inline-block;margin-right:0.3em;">🕔</span>
<span title="Created on June 11, 2012. Modified on August 10, 2013."
style="cursor:help;">August 10, 2013</span> </span> • <span
style="padding:0px 0.4em;"><span
style="font-family:icons;font-weight:normal;font-style:normal;display:inline-block;margin-right:0.3em;"></span>
[6
comments](http://manski.net/2012/06/pinvoke-tutorial-passing-parameters-part-3/#comments)
</span>

</div>

</div>

<div>

P/In­voke tries to make your life eas­ier by au­to­mat­i­cally
con­vert­ing (“mar­shalling”) data types from man­aged code to na­tive
code and the other way around.

<span></span>

<div
style="display:table;border:none;padding:5px 25px;font-size:90%;border-top-right-radius:15px;border-bottom-left-radius:15px;background-color:rgb(17, 17, 17);">

<div
style="color:rgb(255, 255, 255);font-size:1.2em;border-bottom-width:1px;border-bottom-style:solid;border-bottom-color:rgb(51, 51, 51);margin-bottom:0.5em;">

Table of Con­tents <span
style="font-size:75%;display:block;float:right;margin-left:5px;margin-top:4px;">\[[hide](#)\]</span>

</div>

<div>

-   [<span>1</span> <span>Mar­shalling Prim­i­tive Data
    Types</span>](http://manski.net/2012/06/pinvoke-tutorial-passing-parameters-part-3/#marshalling-primitive-data-types)
-   [<span>2</span> <span>Mar­shalling
    Strings</span>](http://manski.net/2012/06/pinvoke-tutorial-passing-parameters-part-3/#marshalling-strings)
-   [<span>3</span> <span>Mar­shalling
    Ar­rays</span>](http://manski.net/2012/06/pinvoke-tutorial-passing-parameters-part-3/#marshalling-arrays)
-   [<span>4</span> <span>Mar­shalling
    Ob­jects</span>](http://manski.net/2012/06/pinvoke-tutorial-passing-parameters-part-3/#marshalling-objects)
-   [<span>5</span> <span>Mar­shalling
    Structs</span>](http://manski.net/2012/06/pinvoke-tutorial-passing-parameters-part-3/#marshalling-structs)
-   [<span>6</span> <span>Mar­shalling
    Del­e­gates</span>](http://manski.net/2012/06/pinvoke-tutorial-passing-parameters-part-3/#marshalling-delegates)
-   [<span>7</span> <span>Mar­shalling Ar­bi­trary
    Point­ers</span>](http://manski.net/2012/06/pinvoke-tutorial-passing-parameters-part-3/#marshalling-arbitrary-pointers)

</div>

</div>

Mar­shalling Prim­i­tive Data Types [∞](http://manski.net/2012/06/pinvoke-tutorial-passing-parameters-part-3/#marshalling-primitive-data-types "Link to this section") {#marshalling-primitive-data-types style="color:rgb(255, 255, 255);font-family:'Crete Round', serif;font-style:normal;font-weight:normal;text-align:center;word-wrap:break-word;text-shadow:rgb(0, 0, 0) 0px 3px 5px;font-size:160%;margin-top:2em;"}
----------------------------------------------------------------------------------------------------------------------------------------------------------------------

Prim­i­tive data types
(`bool`{style="font-family:Inconsolata, Profont, 'Bitstream Vera Sans Mono', Monaco, 'Courier New', courier, monospace, serif;font-size:85%;line-height:1.2em;color:rgb(255, 238, 170);background-color:rgb(17, 17, 17);"},
`int`{style="font-family:Inconsolata, Profont, 'Bitstream Vera Sans Mono', Monaco, 'Courier New', courier, monospace, serif;font-size:85%;line-height:1.2em;color:rgb(255, 238, 170);background-color:rgb(17, 17, 17);"},
`double`{style="font-family:Inconsolata, Profont, 'Bitstream Vera Sans Mono', Monaco, 'Courier New', courier, monospace, serif;font-size:85%;line-height:1.2em;color:rgb(255, 238, 170);background-color:rgb(17, 17, 17);"},
…) are the eas­i­est to use. They map di­rectly to their na­tive
coun­ter­parts.

  C\# type                                                                                                                                                                                                                      C/C++ type                                                                                                                                                                                                                                                                                                                                                                                                                                                                   Bytes        Range
  ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ------------ ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
  `bool`{style="font-family:Inconsolata, Profont, 'Bitstream Vera Sans Mono', Monaco, 'Courier New', courier, monospace, serif;font-size:85%;line-height:1.2em;color:rgb(255, 238, 170);background-color:rgb(17, 17, 17);"}     `bool`{style="font-family:Inconsolata, Profont, 'Bitstream Vera Sans Mono', Monaco, 'Courier New', courier, monospace, serif;font-size:85%;line-height:1.2em;color:rgb(255, 238, 170);background-color:rgb(17, 17, 17);"} (with `int`{style="font-family:Inconsolata, Profont, 'Bitstream Vera Sans Mono', Monaco, 'Courier New', courier, monospace, serif;font-size:85%;line-height:1.2em;color:rgb(255, 238, 170);background-color:rgb(17, 17, 17);"} fall­back)          usu­ally 1   `true`{style="font-family:Inconsolata, Profont, 'Bitstream Vera Sans Mono', Monaco, 'Courier New', courier, monospace, serif;font-size:85%;line-height:1.2em;color:rgb(255, 238, 170);background-color:rgb(17, 17, 17);"} or `false`{style="font-family:Inconsolata, Profont, 'Bitstream Vera Sans Mono', Monaco, 'Courier New', courier, monospace, serif;font-size:85%;line-height:1.2em;color:rgb(255, 238, 170);background-color:rgb(17, 17, 17);"}
  `char`{style="font-family:Inconsolata, Profont, 'Bitstream Vera Sans Mono', Monaco, 'Courier New', courier, monospace, serif;font-size:85%;line-height:1.2em;color:rgb(255, 238, 170);background-color:rgb(17, 17, 17);"}     `wchar_t`{style="font-family:Inconsolata, Profont, 'Bitstream Vera Sans Mono', Monaco, 'Courier New', courier, monospace, serif;font-size:85%;line-height:1.2em;color:rgb(255, 238, 170);background-color:rgb(17, 17, 17);"} (or `char`{style="font-family:Inconsolata, Profont, 'Bitstream Vera Sans Mono', Monaco, 'Courier New', courier, monospace, serif;font-size:85%;line-height:1.2em;color:rgb(255, 238, 170);background-color:rgb(17, 17, 17);"} if nec­es­sary)   2 (1)        Uni­code BMP
  `byte`{style="font-family:Inconsolata, Profont, 'Bitstream Vera Sans Mono', Monaco, 'Courier New', courier, monospace, serif;font-size:85%;line-height:1.2em;color:rgb(255, 238, 170);background-color:rgb(17, 17, 17);"}     `unsigned char`{style="font-family:Inconsolata, Profont, 'Bitstream Vera Sans Mono', Monaco, 'Courier New', courier, monospace, serif;font-size:85%;line-height:1.2em;color:rgb(255, 238, 170);background-color:rgb(17, 17, 17);"}                                                                                                                                                                                                                                           1            0 to 255
  `sbyte`{style="font-family:Inconsolata, Profont, 'Bitstream Vera Sans Mono', Monaco, 'Courier New', courier, monospace, serif;font-size:85%;line-height:1.2em;color:rgb(255, 238, 170);background-color:rgb(17, 17, 17);"}    `char`{style="font-family:Inconsolata, Profont, 'Bitstream Vera Sans Mono', Monaco, 'Courier New', courier, monospace, serif;font-size:85%;line-height:1.2em;color:rgb(255, 238, 170);background-color:rgb(17, 17, 17);"}                                                                                                                                                                                                                                                    1            -128 to 127
  `short`{style="font-family:Inconsolata, Profont, 'Bitstream Vera Sans Mono', Monaco, 'Courier New', courier, monospace, serif;font-size:85%;line-height:1.2em;color:rgb(255, 238, 170);background-color:rgb(17, 17, 17);"}    `short`{style="font-family:Inconsolata, Profont, 'Bitstream Vera Sans Mono', Monaco, 'Courier New', courier, monospace, serif;font-size:85%;line-height:1.2em;color:rgb(255, 238, 170);background-color:rgb(17, 17, 17);"}                                                                                                                                                                                                                                                   2            -32,768 to 32,767
  `ushort`{style="font-family:Inconsolata, Profont, 'Bitstream Vera Sans Mono', Monaco, 'Courier New', courier, monospace, serif;font-size:85%;line-height:1.2em;color:rgb(255, 238, 170);background-color:rgb(17, 17, 17);"}   `unsigned short`{style="font-family:Inconsolata, Profont, 'Bitstream Vera Sans Mono', Monaco, 'Courier New', courier, monospace, serif;font-size:85%;line-height:1.2em;color:rgb(255, 238, 170);background-color:rgb(17, 17, 17);"}                                                                                                                                                                                                                                          2            0 to 65,535
  `int`{style="font-family:Inconsolata, Profont, 'Bitstream Vera Sans Mono', Monaco, 'Courier New', courier, monospace, serif;font-size:85%;line-height:1.2em;color:rgb(255, 238, 170);background-color:rgb(17, 17, 17);"}      `int`{style="font-family:Inconsolata, Profont, 'Bitstream Vera Sans Mono', Monaco, 'Courier New', courier, monospace, serif;font-size:85%;line-height:1.2em;color:rgb(255, 238, 170);background-color:rgb(17, 17, 17);"}                                                                                                                                                                                                                                                     4            -2 bil­lion to 2 bil­lion
  `uint`{style="font-family:Inconsolata, Profont, 'Bitstream Vera Sans Mono', Monaco, 'Courier New', courier, monospace, serif;font-size:85%;line-height:1.2em;color:rgb(255, 238, 170);background-color:rgb(17, 17, 17);"}     `unsigned int`{style="font-family:Inconsolata, Profont, 'Bitstream Vera Sans Mono', Monaco, 'Courier New', courier, monospace, serif;font-size:85%;line-height:1.2em;color:rgb(255, 238, 170);background-color:rgb(17, 17, 17);"}                                                                                                                                                                                                                                            4            0 to 4 bil­lion
  `long`{style="font-family:Inconsolata, Profont, 'Bitstream Vera Sans Mono', Monaco, 'Courier New', courier, monospace, serif;font-size:85%;line-height:1.2em;color:rgb(255, 238, 170);background-color:rgb(17, 17, 17);"}     `__int64`{style="font-family:Inconsolata, Profont, 'Bitstream Vera Sans Mono', Monaco, 'Courier New', courier, monospace, serif;font-size:85%;line-height:1.2em;color:rgb(255, 238, 170);background-color:rgb(17, 17, 17);"}                                                                                                                                                                                                                                                 8            -9 quin­til­lion to 9 quin­til­lion
  `ulong`{style="font-family:Inconsolata, Profont, 'Bitstream Vera Sans Mono', Monaco, 'Courier New', courier, monospace, serif;font-size:85%;line-height:1.2em;color:rgb(255, 238, 170);background-color:rgb(17, 17, 17);"}    `unsigned __int64`{style="font-family:Inconsolata, Profont, 'Bitstream Vera Sans Mono', Monaco, 'Courier New', courier, monospace, serif;font-size:85%;line-height:1.2em;color:rgb(255, 238, 170);background-color:rgb(17, 17, 17);"}                                                                                                                                                                                                                                        8            0 to 18 quin­til­lion
  `float`{style="font-family:Inconsolata, Profont, 'Bitstream Vera Sans Mono', Monaco, 'Courier New', courier, monospace, serif;font-size:85%;line-height:1.2em;color:rgb(255, 238, 170);background-color:rgb(17, 17, 17);"}    `float`{style="font-family:Inconsolata, Profont, 'Bitstream Vera Sans Mono', Monaco, 'Courier New', courier, monospace, serif;font-size:85%;line-height:1.2em;color:rgb(255, 238, 170);background-color:rgb(17, 17, 17);"}                                                                                                                                                                                                                                                   4            7 sig­nif­i­cant dec­i­mal dig­its
  `double`{style="font-family:Inconsolata, Profont, 'Bitstream Vera Sans Mono', Monaco, 'Courier New', courier, monospace, serif;font-size:85%;line-height:1.2em;color:rgb(255, 238, 170);background-color:rgb(17, 17, 17);"}   `double`{style="font-family:Inconsolata, Profont, 'Bitstream Vera Sans Mono', Monaco, 'Courier New', courier, monospace, serif;font-size:85%;line-height:1.2em;color:rgb(255, 238, 170);background-color:rgb(17, 17, 17);"}                                                                                                                                                                                                                                                  8            15 sig­nif­i­cant dec­i­mal dig­its

Mar­shalling Strings [∞](http://manski.net/2012/06/pinvoke-tutorial-passing-parameters-part-3/#marshalling-strings "Link to this section") {#marshalling-strings style="color:rgb(255, 255, 255);font-family:'Crete Round', serif;font-style:normal;font-weight:normal;text-align:center;word-wrap:break-word;text-shadow:rgb(0, 0, 0) 0px 3px 5px;font-size:160%;margin-top:2em;"}
------------------------------------------------------------------------------------------------------------------------------------------

For pass­ing strings, it’s rec­om­mended that you pass them as Uni­code
strings (if pos­si­ble). For this, you need to spec­ify
`Char.Unicode`{style="font-family:Inconsolata, Profont, 'Bitstream Vera Sans Mono', Monaco, 'Courier New', courier, monospace, serif;font-size:85%;line-height:1.2em;color:rgb(255, 238, 170);background-color:rgb(17, 17, 17);"}
like this:

``` {style="background-color:rgb(17, 17, 17);font-family:Inconsolata, Profont, 'Bitstream Vera Sans Mono', Monaco, 'Courier New', courier, monospace, serif;white-space:pre;word-wrap:normal;line-height:1.2em;font-size:10pt;padding:15px;margin-bottom:2em;overflow-x:auto;border-top-right-radius:15px;border-bottom-left-radius:15px;"}
[DllImport("NativeLib.dll", CharSet = CharSet.Unicode)]
private static extern void do_something(string str);
```

This re­quires the C/C++ pa­ra­me­ter type be a
`wchar_t*`{style="font-family:Inconsolata, Profont, 'Bitstream Vera Sans Mono', Monaco, 'Courier New', courier, monospace, serif;font-size:85%;line-height:1.2em;color:rgb(255, 238, 170);background-color:rgb(17, 17, 17);"}:

``` {style="background-color:rgb(17, 17, 17);font-family:Inconsolata, Profont, 'Bitstream Vera Sans Mono', Monaco, 'Courier New', courier, monospace, serif;white-space:pre;word-wrap:normal;line-height:1.2em;font-size:10pt;padding:15px;margin-bottom:2em;overflow-x:auto;border-top-right-radius:15px;border-bottom-left-radius:15px;"}
void do_something(const wchar_t* str);
```

For more de­tails, see [P/In­voke Tu­to­r­ial: Pass­ing strings (Part
2)](http://manski.net/2012/06/pinvoke-tutorial-passing-strings-part-2/).

Mar­shalling Ar­rays [∞](http://manski.net/2012/06/pinvoke-tutorial-passing-parameters-part-3/#marshalling-arrays "Link to this section") {#marshalling-arrays style="color:rgb(255, 255, 255);font-family:'Crete Round', serif;font-style:normal;font-weight:normal;text-align:center;word-wrap:break-word;text-shadow:rgb(0, 0, 0) 0px 3px 5px;font-size:160%;margin-top:2em;"}
-----------------------------------------------------------------------------------------------------------------------------------------

Ar­rays of prim­i­tive types can be passed di­rectly.

``` {style="background-color:rgb(17, 17, 17);font-family:Inconsolata, Profont, 'Bitstream Vera Sans Mono', Monaco, 'Courier New', courier, monospace, serif;white-space:pre;word-wrap:normal;line-height:1.2em;font-size:10pt;padding:15px;margin-bottom:2em;overflow-x:auto;border-top-right-radius:15px;border-bottom-left-radius:15px;"}
[DllImport("NativeLib.dll")]
private static extern void do_something(byte[] data);
```

Mar­shalling Ob­jects [∞](http://manski.net/2012/06/pinvoke-tutorial-passing-parameters-part-3/#marshalling-objects "Link to this section") {#marshalling-objects style="color:rgb(255, 255, 255);font-family:'Crete Round', serif;font-style:normal;font-weight:normal;text-align:center;word-wrap:break-word;text-shadow:rgb(0, 0, 0) 0px 3px 5px;font-size:160%;margin-top:2em;"}
-------------------------------------------------------------------------------------------------------------------------------------------

To be able to pass ob­jects you need to make their mem­ory lay­out
se­quen­tial:

``` {style="background-color:rgb(17, 17, 17);font-family:Inconsolata, Profont, 'Bitstream Vera Sans Mono', Monaco, 'Courier New', courier, monospace, serif;white-space:pre;word-wrap:normal;line-height:1.2em;font-size:10pt;padding:15px;margin-bottom:2em;overflow-x:auto;border-top-right-radius:15px;border-bottom-left-radius:15px;"}
[StructLayout(LayoutKind.Sequential)]
class MyClass {
  ...
}
```

This en­sures that the fields are stored in the same order they’re
writ­ten in code. (With­out this at­tribute the C\# com­piler re­order
fields around to op­ti­mize the data struc­ture.)

Then sim­ply use the ob­ject’s class di­rectly:

``` {style="background-color:rgb(17, 17, 17);font-family:Inconsolata, Profont, 'Bitstream Vera Sans Mono', Monaco, 'Courier New', courier, monospace, serif;white-space:pre;word-wrap:normal;line-height:1.2em;font-size:10pt;padding:15px;margin-bottom:2em;overflow-x:auto;border-top-right-radius:15px;border-bottom-left-radius:15px;"}
[DllImport("NativeLib.dll")]
private static extern void do_something(MyClass data);
```

The ob­ject will be passed by ref­er­ence (ei­ther as
`struct*`{style="font-family:Inconsolata, Profont, 'Bitstream Vera Sans Mono', Monaco, 'Courier New', courier, monospace, serif;font-size:85%;line-height:1.2em;color:rgb(255, 238, 170);background-color:rgb(17, 17, 17);"}
or
`stuct&`{style="font-family:Inconsolata, Profont, 'Bitstream Vera Sans Mono', Monaco, 'Courier New', courier, monospace, serif;font-size:85%;line-height:1.2em;color:rgb(255, 238, 170);background-color:rgb(17, 17, 17);"})
to the C func­tion:

``` {style="background-color:rgb(17, 17, 17);font-family:Inconsolata, Profont, 'Bitstream Vera Sans Mono', Monaco, 'Courier New', courier, monospace, serif;white-space:pre;word-wrap:normal;line-height:1.2em;font-size:10pt;padding:15px;margin-bottom:2em;overflow-x:auto;border-top-right-radius:15px;border-bottom-left-radius:15px;"}
typedef struct {
  ...
} MyClass;

void do_something(MyClass* data);
```

*Note:* Ob­vi­ously the order of the fields in the na­tive struct and
the man­aged class *must be ex­actly the same*.

Mar­shalling Structs [∞](http://manski.net/2012/06/pinvoke-tutorial-passing-parameters-part-3/#marshalling-structs "Link to this section") {#marshalling-structs style="color:rgb(255, 255, 255);font-family:'Crete Round', serif;font-style:normal;font-weight:normal;text-align:center;word-wrap:break-word;text-shadow:rgb(0, 0, 0) 0px 3px 5px;font-size:160%;margin-top:2em;"}
------------------------------------------------------------------------------------------------------------------------------------------

Mar­shalling man­aged
`struct`{style="font-family:Inconsolata, Profont, 'Bitstream Vera Sans Mono', Monaco, 'Courier New', courier, monospace, serif;font-size:85%;line-height:1.2em;color:rgb(255, 238, 170);background-color:rgb(17, 17, 17);"}s
is al­most iden­ti­cal to mar­shalling ob­jects with only one
dif­fer­ence:
`struct`{style="font-family:Inconsolata, Profont, 'Bitstream Vera Sans Mono', Monaco, 'Courier New', courier, monospace, serif;font-size:85%;line-height:1.2em;color:rgb(255, 238, 170);background-color:rgb(17, 17, 17);"}s
are passed by copy by de­fault.

So for
`struct`{style="font-family:Inconsolata, Profont, 'Bitstream Vera Sans Mono', Monaco, 'Courier New', courier, monospace, serif;font-size:85%;line-height:1.2em;color:rgb(255, 238, 170);background-color:rgb(17, 17, 17);"}s
the C/C++ func­tion sig­na­ture reads:

``` {style="background-color:rgb(17, 17, 17);font-family:Inconsolata, Profont, 'Bitstream Vera Sans Mono', Monaco, 'Courier New', courier, monospace, serif;white-space:pre;word-wrap:normal;line-height:1.2em;font-size:10pt;padding:15px;margin-bottom:2em;overflow-x:auto;border-top-right-radius:15px;border-bottom-left-radius:15px;"}
void do_something(MyClass data);
```

Of course, you can pass the
`struct`{style="font-family:Inconsolata, Profont, 'Bitstream Vera Sans Mono', Monaco, 'Courier New', courier, monospace, serif;font-size:85%;line-height:1.2em;color:rgb(255, 238, 170);background-color:rgb(17, 17, 17);"}
also by ref­er­ence. In this case, use
`(MyClass* data)`{style="font-family:Inconsolata, Profont, 'Bitstream Vera Sans Mono', Monaco, 'Courier New', courier, monospace, serif;font-size:85%;line-height:1.2em;color:rgb(255, 238, 170);background-color:rgb(17, 17, 17);"}
or
`(MyClass& data)`{style="font-family:Inconsolata, Profont, 'Bitstream Vera Sans Mono', Monaco, 'Courier New', courier, monospace, serif;font-size:85%;line-height:1.2em;color:rgb(255, 238, 170);background-color:rgb(17, 17, 17);"}
in C/C++ and
`(ref MyClass data)`{style="font-family:Inconsolata, Profont, 'Bitstream Vera Sans Mono', Monaco, 'Courier New', courier, monospace, serif;font-size:85%;line-height:1.2em;color:rgb(255, 238, 170);background-color:rgb(17, 17, 17);"}
in C\#.

Mar­shalling Del­e­gates [∞](http://manski.net/2012/06/pinvoke-tutorial-passing-parameters-part-3/#marshalling-delegates "Link to this section") {#marshalling-delegates style="color:rgb(255, 255, 255);font-family:'Crete Round', serif;font-style:normal;font-weight:normal;text-align:center;word-wrap:break-word;text-shadow:rgb(0, 0, 0) 0px 3px 5px;font-size:160%;margin-top:2em;"}
------------------------------------------------------------------------------------------------------------------------------------------------

Del­e­gates are mar­shalled di­rectly. The only thing you need to take
care of is the “call­ing con­ven­tion”. The de­fault call­ing
con­ven­tion is
`Winapi`{style="font-family:Inconsolata, Profont, 'Bitstream Vera Sans Mono', Monaco, 'Courier New', courier, monospace, serif;font-size:85%;line-height:1.2em;color:rgb(255, 238, 170);background-color:rgb(17, 17, 17);"}
(which equals to
`StdCall`{style="font-family:Inconsolata, Profont, 'Bitstream Vera Sans Mono', Monaco, 'Courier New', courier, monospace, serif;font-size:85%;line-height:1.2em;color:rgb(255, 238, 170);background-color:rgb(17, 17, 17);"}
on Win­dows). If your na­tive li­brary uses a dif­fer­ent call­ing
con­ven­tion, you need to spec­ify it like this:

``` {style="background-color:rgb(17, 17, 17);font-family:Inconsolata, Profont, 'Bitstream Vera Sans Mono', Monaco, 'Courier New', courier, monospace, serif;white-space:pre;word-wrap:normal;line-height:1.2em;font-size:10pt;padding:15px;margin-bottom:2em;overflow-x:auto;border-top-right-radius:15px;border-bottom-left-radius:15px;"}
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void MyDelegate(IntPtr value);
```

Mar­shalling Ar­bi­trary Point­ers [∞](http://manski.net/2012/06/pinvoke-tutorial-passing-parameters-part-3/#marshalling-arbitrary-pointers "Link to this section") {#marshalling-arbitrary-pointers style="color:rgb(255, 255, 255);font-family:'Crete Round', serif;font-style:normal;font-weight:normal;text-align:center;word-wrap:break-word;text-shadow:rgb(0, 0, 0) 0px 3px 5px;font-size:160%;margin-top:2em;"}
-------------------------------------------------------------------------------------------------------------------------------------------------------------------

Ar­bi­trary point­ers (like
`void*`{style="font-family:Inconsolata, Profont, 'Bitstream Vera Sans Mono', Monaco, 'Courier New', courier, monospace, serif;font-size:85%;line-height:1.2em;color:rgb(255, 238, 170);background-color:rgb(17, 17, 17);"})
are mar­shalled as
`IntPtr`{style="font-family:Inconsolata, Profont, 'Bitstream Vera Sans Mono', Monaco, 'Courier New', courier, monospace, serif;font-size:85%;line-height:1.2em;color:rgb(255, 238, 170);background-color:rgb(17, 17, 17);"}
ob­jects.

So this C func­tion:

``` {style="background-color:rgb(17, 17, 17);font-family:Inconsolata, Profont, 'Bitstream Vera Sans Mono', Monaco, 'Courier New', courier, monospace, serif;white-space:pre;word-wrap:normal;line-height:1.2em;font-size:10pt;padding:15px;margin-bottom:2em;overflow-x:auto;border-top-right-radius:15px;border-bottom-left-radius:15px;"}
void do_something(void* ptr);
```

be­comes:

``` {style="background-color:rgb(17, 17, 17);font-family:Inconsolata, Profont, 'Bitstream Vera Sans Mono', Monaco, 'Courier New', courier, monospace, serif;white-space:pre;word-wrap:normal;line-height:1.2em;font-size:10pt;padding:15px;margin-bottom:2em;overflow-x:auto;border-top-right-radius:15px;border-bottom-left-radius:15px;"}
[DllImport("NativeLib.dll")]
private static extern void do_something(IntPtr ptr);
```

</div>

<div
style="display:table;font-size:90%;text-align:center;margin:3em auto 0px;padding:0.3em 1em;border-top-right-radius:15px;border-bottom-left-radius:15px;clear:both;background-color:rgb(17, 17, 17);">

<span style="padding:0px 0.4em;"><span
style="font-family:icons;font-weight:normal;font-style:normal;display:inline-block;margin-right:0.3em;">👤</span>Sebastian Krysmanski</span>
• <span style="padding:0px 0.4em;"><span
style="font-family:icons;font-weight:normal;font-style:normal;display:inline-block;margin-right:0.3em;"></span>[Articles](http://manski.net/topics/articles/),
[Code
Project](http://manski.net/topics/articles/code-project-articles/),
[Software
Development](http://manski.net/topics/tech/software-develop/)</span> •
<span style="padding:0px 0.4em;"><span
style="font-family:icons;font-weight:normal;font-style:normal;display:inline-block;margin-right:0.3em;"></span>[C\#](http://manski.net/tags/csharp/),
[marshalling](http://manski.net/tags/marshalling/),
[P/Invoke](http://manski.net/tags/pinvoke/)</span>

</div>

</div>

<div
style="padding:3em 2em 2em;background:url(&quot;&quot;) 50% 0% repeat-x;">

6 comments {#comments style="color:rgb(255, 255, 255);font-family:'Crete Round', serif;font-style:normal;font-weight:normal;text-align:center;word-wrap:break-word;text-shadow:rgb(0, 0, 0) 0px 3px 5px;font-size:160%;"}
----------

1.  <div style="display:block;">

    <div style="display:block;font-size:10pt;">

    ![](Invoke%20Tutorial-%20Passing%20parameters%20(Part%203)%20-%20man_files/79498d665324b252dccd5279de71fd3a.png){width="120"
    height="120"}<span style="font-style:italic;">Levy said:
    </span><span style="display:block;float:right;"><span>November 2,
    2012 at 20:15</span>
    [∞](http://manski.net/2012/06/pinvoke-tutorial-passing-parameters-part-3/#comment-39327 "Permalink to this comment")</span>

    </div>

    <div>

    How do I marshall an object from a third party DLL for which I do
    not have access to the source code?

    </div>

    <div style="font-size:85%;">

    <span> [<span
    style="color:rgb(255, 255, 255);text-align:center;line-height:1em;cursor:pointer;font-family:icons;font-weight:normal;font-style:normal;display:inline-block;margin-right:0.3em;"></span>Reply](http://manski.net/2012/06/pinvoke-tutorial-passing-parameters-part-3/?replytocom=39327#respond)
    </span>

    </div>

    </div>

2.  <div style="display:block;">

    <div style="display:block;font-size:10pt;">

    ![](Invoke%20Tutorial-%20Passing%20parameters%20(Part%203)%20-%20man_files/77a37a4223989b6cddde24ae2cb6caa3.jpg){width="120"
    height="120"}<span
    style="font-style:italic;">[Manski](http://www.mayastudios.com/)
    (post author) said: </span><span
    style="display:block;float:right;"><span>November 5, 2012 at
    09:22</span>
    [∞](http://manski.net/2012/06/pinvoke-tutorial-passing-parameters-part-3/#comment-40058 "Permalink to this comment")</span>

    </div>

    <div>

    If it’s a C++ object/class, I think you’re out of luck – at least,
    if you want to call any methods of the class (no matter whether you
    have the source code or not). If you just want to pass it around,
    use “IntPtr”.

    </div>

    <div style="font-size:85%;">

    <span> [<span
    style="color:rgb(255, 255, 255);text-align:center;line-height:1em;cursor:pointer;font-family:icons;font-weight:normal;font-style:normal;display:inline-block;margin-right:0.3em;"></span>Reply](http://manski.net/2012/06/pinvoke-tutorial-passing-parameters-part-3/?replytocom=40058#respond)
    </span>

    </div>

    </div>

    -   <div style="display:block;">

        <div style="display:block;font-size:10pt;">

        ![](Invoke%20Tutorial-%20Passing%20parameters%20(Part%203)%20-%20man_files/6083e7f3db5f4023e4255b9483364f39.png){width="60"
        height="60"}<span
        style="font-style:italic;">[Shawn](http://www.xinterop.com/)
        replied: </span><span
        style="display:block;float:right;"><span>April 28, 2013 at
        19:17</span>
        [∞](http://manski.net/2012/06/pinvoke-tutorial-passing-parameters-part-3/#comment-141800 "Permalink to this comment")</span>

        </div>

        <div>

        Hi, it is really very nice tutorial about pinvoke, and
        very organized.

        Even if its C++ class/object, it can still be called
        using PInvoke. Please read [PInvoke Interop SDK for C++
        DLL](http://www.xinterop.com/index.php/2013/04/13/introduction-to-c-pinvoke-interop-sdk),
        basically, you would be able to marshal anything from C++ to C\#
        as long as they are exported from the C++ DLL.

        </div>

        <div style="font-size:85%;">

        <span> </span>

        </div>

        </div>

3.  <div style="display:block;">

    <div style="display:block;font-size:10pt;">

    ![](Invoke%20Tutorial-%20Passing%20parameters%20(Part%203)%20-%20man_files/ce117e745472b132a6bf387a816fbc7a.png){width="120"
    height="120"}<span style="font-style:italic;">Levy said:
    </span><span style="display:block;float:right;"><span>December 3,
    2013 at 13:15</span>
    [∞](http://manski.net/2012/06/pinvoke-tutorial-passing-parameters-part-3/#comment-213911 "Permalink to this comment")</span>

    </div>

    <div>

    How do I marshall an array of pointers in a C\# callback? For
    example:

    ``` {style="background-color:rgb(17, 17, 17);font-family:Inconsolata, Profont, 'Bitstream Vera Sans Mono', Monaco, 'Courier New', courier, monospace, serif;white-space:pre;word-wrap:normal;line-height:1.2em;font-size:10pt;padding:15px;margin-bottom:2em;overflow-x:auto;border-top-right-radius:15px;border-bottom-left-radius:15px;"}
    public delegate void CallbackPrototype(int sizeOfArray, IntPtr[] arrayOfPointers);

    void MyCallback(int sizeOfArray, IntPtr[] arrayOfPointers)
    {
      for (int i = 0; i < sizeOfArray; i++)
      {
        IntPtr intPtr = arrayOfPointers[i]; // fails for i != 0 because arrayOfPointers.Length is one
      }
    }
    ```

    </div>

    <div style="font-size:85%;">

    <span> [<span
    style="color:rgb(255, 255, 255);text-align:center;line-height:1em;cursor:pointer;font-family:icons;font-weight:normal;font-style:normal;display:inline-block;margin-right:0.3em;"></span>Reply](http://manski.net/2012/06/pinvoke-tutorial-passing-parameters-part-3/?replytocom=213911#respond)
    </span>

    </div>

    </div>

4.  <div style="display:block;">

    <div style="display:block;font-size:10pt;">

    ![](Invoke%20Tutorial-%20Passing%20parameters%20(Part%203)%20-%20man_files/dd12c41bc4f34b6d3f47bb6474a935cc.jpg){width="120"
    height="120"}<span style="font-style:italic;">[Tore
    Aurstad](http://aurstad.info/) said: </span><span
    style="display:block;float:right;"><span>April 25, 2015 at
    13:50</span>
    [∞](http://manski.net/2012/06/pinvoke-tutorial-passing-parameters-part-3/#comment-270848 "Permalink to this comment")</span>

    </div>

    <div>

    Great overview of P/Invoke! Is it possible to retrieve internal
    errors in the code you call, simple as wrapping a try catch I
    suppose? But will that give a generic error message, or is it
    possible to get internal details from the unmanaged dll?

    </div>

    <div style="font-size:85%;">

    <span> [<span
    style="color:rgb(255, 255, 255);text-align:center;line-height:1em;cursor:pointer;font-family:icons;font-weight:normal;font-style:normal;display:inline-block;margin-right:0.3em;"></span>Reply](http://manski.net/2012/06/pinvoke-tutorial-passing-parameters-part-3/?replytocom=270848#respond)
    </span>

    </div>

    </div>

5.  <div style="display:block;">

    <div style="display:block;font-size:10pt;">

    ![](Invoke%20Tutorial-%20Passing%20parameters%20(Part%203)%20-%20man_files/92be9748b68b0c50257d6e870818ae4d.png){width="120"
    height="120"}<span style="font-style:italic;">steve said:
    </span><span style="display:block;float:right;"><span>November 5,
    2015 at 14:28</span>
    [∞](http://manski.net/2012/06/pinvoke-tutorial-passing-parameters-part-3/#comment-278262 "Permalink to this comment")</span>

    </div>

    <div>

    Dear Sebastian\
    Maybe, you got an idea or advice what’s the issue with passing a 2D
    string array from C\# to C++. Many thanks ..

    Here the C\# code, which works fine:

    public struct TestStruct\
    {\
    public string\[,\] stringArray;\
    }

    \[DllImport(“C:\\\\Users\\\\Win32Project2.dll”,\
    EntryPoint = “DDentry”,\
    CallingConvention = CallingConvention.StdCall)\]

    public static extern void DDentry\
    (\
    \[In\]\[MarshalAs(UnmanagedType.LPArray,\
    ArraySubType = UnmanagedType.BStr)\]\
    string\[,\] arrayReadDat, int iDim1, int iDim2\
    );

    private void button6\_Click\_1(object sender, EventArgs e)\
    {\
    TestStruct arrayReadDat = new TestStruct();\
    arrayReadDat.stringArray = new string\[lastRow+1, lastCol+1\];\
    string strK = “testify”;\
    for (int i = 2; i &lt;= lastRow; i++)\
    {\
    for (int j = 1; j &lt;= lastCol; j++)\
    {\
    arrayReadDat.stringArray\[i, j\] = strK;\
    }\
    }

    int size = Marshal.SizeOf(typeof(TestStruct));\
    IntPtr strPointer = Marshal.AllocHGlobal(size);\
    Marshal.StructureToPtr(arrayReadDat, strPointer, false);

    DDentry(arrayReadDat.stringArray, lastRow+1, lastCol+1);

    Marshal.FreeHGlobal(strPointer);\
    }

    Here the C++ code, where "no" data were passed to the pointer/array:

    extern "C"\
    {\
    \_declspec(dllexport) void DDentry(string \*p2DIntArray, int iDim1,
    int iDim2)

    {\
    int iIndex = 0;\
    for (int i = 2; i &lt;= iDim1; i++)\
    {\
    for (int j = 1; j &lt;= iDim2; j++)\
    {\
    arrayREAD\[i\]\[j\] = p2DIntArray\[iIndex++\];\
    }\
    }\
    }\
    }

    </div>

    <div style="font-size:85%;">

    <span> [<span
    style="color:rgb(255, 255, 255);text-align:center;line-height:1em;cursor:pointer;font-family:icons;font-weight:normal;font-style:normal;display:inline-block;margin-right:0.3em;"></span>Reply](http://manski.net/2012/06/pinvoke-tutorial-passing-parameters-part-3/?replytocom=278262#respond)
    </span>

    </div>

    </div>

<div
style="padding-top:1em;margin-top:3em;margin-right:1em;background:url(&quot;&quot;) 50% 0% repeat-x;">

### Leave a Reply {#leave-a-reply style="color:rgb(255, 255, 255);font-family:'Crete Round', serif;font-style:normal;font-weight:normal;text-align:center;word-wrap:break-word;text-shadow:rgb(0, 0, 0) 0px 3px 5px;font-size:140%;"}

<div style="margin:0px;">

<span>Your email address will not be published.</span> Required fields
are marked <span
style="color:rgb(189, 53, 0);font-weight:bold;">\*</span>

<span style="cursor:pointer;">Comment</span>

<span style="cursor:pointer;">Name <span>\*</span></span>

<span style="cursor:pointer;">Email <span>\*</span></span>

<span style="cursor:pointer;">Website</span>

<div>

<div>

<div style="width:304px;height:78px;">

<div style="width:304px;height:78px;position:relative;">

<div style="font-size: 16px">

<div dir="ltr">

<div style="margin:0px;">

<div style="color:red;position:absolute;font-size:13px;">

</div>

<div
style="border-radius:3px;box-shadow:rgba(0, 0, 0, 0.0784314) 0px 0px 4px 1px;height:74px;width:300px;border:1px solid rgb(82, 82, 82);color:rgb(255, 255, 255);background:rgb(34, 34, 34);">

<div
style="left:-10000px;height:1px;position:absolute;top:-10000px;width:1px;">

<div>

recaptcha status
================

<span>Recaptcha requires verification</span>

</div>

</div>

<div style="display:inline-block;height:74px;width:206px;">

<div style="display:inline-block;height:100%;">

<div style="display:table;height:100%;">

<div style="display:table-cell;vertical-align:middle;">

<span dir="ltr"
style="position:relative;display:inline-block;border:none;font-size:1px;height:28px;margin:0px 12px 2px;width:28px;overflow:visible;outline:0px;vertical-align:text-bottom;"></span>
<div
style="border-radius:2px;border:2px solid rgb(193, 193, 193);font-size:1px;height:24px;position:absolute;width:24px;background-color:rgb(255, 255, 255);">

</div>

<div
style="border:none;height:28px;outline:0px;position:absolute;width:28px;background-image:url(data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAFQAAANICAYAAABZl8i8AAAABmJLR0QA/wD/AP+gvaeTAAAACXBIWXMAAABIAAAASABGyWs+AAAACXZwQWcAAABUAAADSAC4K4y8AAA4oElEQVR42u2dCZRV1ZX3q5iE4IQIiKQQCKBt0JLEIUZwCCk7pBNFiRMajZrIl9aOLZ8sY4CWdkDbT2McooaAEmNixFhpaYE2dCiLScWiQHCgoGQoGQuhGArKKl7V+c5/n33fO/V4w733nVuheXuv9V/rrnvP2Xud3zvTPee+ewsKxMTExMTExMTExMTExMTExMTExMTExMTExMTExMTExMTExMTExMTExMTExMTExMTExMTExP4OdtlT6ztAbRWvvLy8A3QkwxzH6tBGMMexIo+nCgraaf2E1U6A5g60o9a9rI7S5N1APQaSzl1MTExMTExMTExMTExMTExMTExMTExMTExMTExMTOwIsMueWl8EtVW88vLyIqit4qmCguOgtoT5AKuojWA+wCpqA5i9tP6d1UuA5g70K1oPsL4iTd4N1DMh6dzFxMTExMTExMTExMTExMTExMTExMTExMTExMTExMT+l9tlT63/stbtrC9HHa+8vPzLWrezIo+nCgq6a41hdW8LoAD5COv2NgAKkI+wbm8DoHhf0yOsnwjQ3IHeaQG9U5p87kAHa01kDZZOXkxMTExMTExMTExMTExMTExMTExMTExMTExMTEysLe2yp9afoTWWdUbU8crLy8/QGsuKPJ4qKOirdRWrb1vAfDJJZ0QM88kknREhTLwR5wmtJ1lPRPpmHK6VT/5q3g4SAx0bIVDUyidXr15NYqBjIwT6YwI5cqSRgfpjARoe6E8J4vjxRgboT6XJhwf6Dau5e/qGDEq5Qb3I+mriRTINERMTExMTExMTExMTExMTExMTExMTExMTEzss7LKn1neB2ipeeXl5F+hIBHma1mStF1g4Pi1CkKdpTdZ6gYXjyOKpgoLeWndoPcPCce8oYU63YHqaHgVUhjndgulpehRQNbgiree0XkgSzhVFAZRq5pQ3t7+w+0CMhGOvpkYAlGrmhx9++EJTUxMJx15NjQDozwngN7/5gnr/fSMcG6g/j6LPJHgAqZQi4diqqV0c95kEDyC9eDi2amoXhzCP0ppO8DZsiMejYwMU144SoP6BHk3gCgtf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&quot;);background-repeat:no-repeat;">

</div>

<div
style="border:none;height:36px;left:-4px;outline:0px;position:absolute;top:-4px;width:36px;background-image:url(data:image/png;base64,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&quot;);background-repeat:no-repeat;">

</div>

<div
style="border:none;height:38px;left:-5px;outline:0px;position:absolute;top:-5px;visibility:hidden;width:38px;background-repeat:no-repeat;">

</div>

<div
style="border:none;height:30px;left:-5px;outline:0px;position:absolute;width:38px;background-image:url(data:image/png;base64,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&quot;);background-repeat:no-repeat;">

</div>

</div>

</div>

</div>

<div style="display:inline-block;height:100%;">

<div style="display:table;height:100%;">

<span
style="display:table-cell;vertical-align:middle;font-family:Roboto, helvetica, arial, sans-serif;font-size:14px;font-weight:400;line-height:17px;width:152px;">I'm
not a robot</span>

</div>

</div>

</div>

<div style="display:inline-block;height:74px;vertical-align:top;">

<div
style="margin:10px 0px 0px 26px;width:58px;-webkit-user-select:none;">

<div
style="background:url(&quot;&quot;) no-repeat;height:32px;margin:0px 13px;width:32px;background-size:32px;">

</div>

<div
style="color:rgb(155, 155, 155);cursor:default;font-family:Roboto, helvetica, arial, sans-serif;font-size:10px;font-weight:400;line-height:10px;margin-top:5px;text-align:center;">

reCAPTCHA

</div>

</div>

<div
style="color:rgb(155, 155, 155);font-family:Roboto, helvetica, arial, sans-serif;font-size:8px;font-weight:400;margin:4px 13px 0px 0px;padding-right:2px;position:absolute;right:0px;text-align:right;width:276px;">

[Privacy](https://www.google.com/intl/en/policies/privacy/) -
[Terms](https://www.google.com/intl/en/policies/terms/)

</div>

</div>

</div>

</div>

</div>

</div>

</div>

</div>

</div>

</div>

<div>

 

</div>

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
