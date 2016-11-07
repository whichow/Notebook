Invoke Tutorial: Passing parameters (Part 3) | manski's blog
[P/Invoke Tutorial: Passing parameters (Part 3)](http://manski.net/2012/06/pinvoke-tutorial-passing-parameters-part-3/ "Permalink to this page")
================================================================================================================================================

🕔 August 10, 2013 •  [6 comments](http://manski.net/2012/06/pinvoke-tutorial-passing-parameters-part-3/#comments)

P/In­voke tries to make your life eas­ier by au­to­mat­i­cally con­vert­ing (“mar­shalling”) data types from man­aged code to na­tive code and the other way around.

Table of Con­tents \[[hide](#)\]

-   [1 Mar­shalling Prim­i­tive Data Types](http://manski.net/2012/06/pinvoke-tutorial-passing-parameters-part-3/#marshalling-primitive-data-types)
-   [2 Mar­shalling Strings](http://manski.net/2012/06/pinvoke-tutorial-passing-parameters-part-3/#marshalling-strings)
-   [3 Mar­shalling Ar­rays](http://manski.net/2012/06/pinvoke-tutorial-passing-parameters-part-3/#marshalling-arrays)
-   [4 Mar­shalling Ob­jects](http://manski.net/2012/06/pinvoke-tutorial-passing-parameters-part-3/#marshalling-objects)
-   [5 Mar­shalling Structs](http://manski.net/2012/06/pinvoke-tutorial-passing-parameters-part-3/#marshalling-structs)
-   [6 Mar­shalling Del­e­gates](http://manski.net/2012/06/pinvoke-tutorial-passing-parameters-part-3/#marshalling-delegates)
-   [7 Mar­shalling Ar­bi­trary Point­ers](http://manski.net/2012/06/pinvoke-tutorial-passing-parameters-part-3/#marshalling-arbitrary-pointers)

Mar­shalling Prim­i­tive Data Types [∞](http://manski.net/2012/06/pinvoke-tutorial-passing-parameters-part-3/#marshalling-primitive-data-types "Link to this section")
----------------------------------------------------------------------------------------------------------------------------------------------------------------------

Prim­i­tive data types (`bool`, `int`, `double`, …) are the eas­i­est to use. They map di­rectly to their na­tive coun­ter­parts.

| C\# type | C/C++ type                           | Bytes      | Range                               |
|----------|--------------------------------------|------------|-------------------------------------|
| `bool`   | `bool` (with `int` fall­back)        | usu­ally 1 | `true` or `false`                   |
| `char`   | `wchar_t` (or `char` if nec­es­sary) | 2 (1)      | Uni­code BMP                        |
| `byte`   | `unsigned char`                      | 1          | 0 to 255                            |
| `sbyte`  | `char`                               | 1          | -128 to 127                         |
| `short`  | `short`                              | 2          | -32,768 to 32,767                   |
| `ushort` | `unsigned short`                     | 2          | 0 to 65,535                         |
| `int`    | `int`                                | 4          | -2 bil­lion to 2 bil­lion           |
| `uint`   | `unsigned int`                       | 4          | 0 to 4 bil­lion                     |
| `long`   | `__int64`                            | 8          | -9 quin­til­lion to 9 quin­til­lion |
| `ulong`  | `unsigned __int64`                   | 8          | 0 to 18 quin­til­lion               |
| `float`  | `float`                              | 4          | 7 sig­nif­i­cant dec­i­mal dig­its  |
| `double` | `double`                             | 8          | 15 sig­nif­i­cant dec­i­mal dig­its |

Mar­shalling Strings [∞](http://manski.net/2012/06/pinvoke-tutorial-passing-parameters-part-3/#marshalling-strings "Link to this section")
------------------------------------------------------------------------------------------------------------------------------------------

For pass­ing strings, it’s rec­om­mended that you pass them as Uni­code strings (if pos­si­ble). For this, you need to spec­ify `Char.Unicode` like this:

```
[DllImport("NativeLib.dll", CharSet = CharSet.Unicode)]
private static extern void do_something(string str);
```

This re­quires the C/C++ pa­ra­me­ter type be a `wchar_t*`:

```
void do_something(const wchar_t* str);
```

For more de­tails, see [P/In­voke Tu­to­r­ial: Pass­ing strings (Part 2)](http://manski.net/2012/06/pinvoke-tutorial-passing-strings-part-2/).

Mar­shalling Ar­rays [∞](http://manski.net/2012/06/pinvoke-tutorial-passing-parameters-part-3/#marshalling-arrays "Link to this section")
-----------------------------------------------------------------------------------------------------------------------------------------

Ar­rays of prim­i­tive types can be passed di­rectly.

```
[DllImport("NativeLib.dll")]
private static extern void do_something(byte[] data);
```

Mar­shalling Ob­jects [∞](http://manski.net/2012/06/pinvoke-tutorial-passing-parameters-part-3/#marshalling-objects "Link to this section")
-------------------------------------------------------------------------------------------------------------------------------------------

To be able to pass ob­jects you need to make their mem­ory lay­out se­quen­tial:

```
[StructLayout(LayoutKind.Sequential)]
class MyClass {
  ...
}
```

This en­sures that the fields are stored in the same order they’re writ­ten in code. (With­out this at­tribute the C\# com­piler re­order fields around to op­ti­mize the data struc­ture.)

Then sim­ply use the ob­ject’s class di­rectly:

```
[DllImport("NativeLib.dll")]
private static extern void do_something(MyClass data);
```

The ob­ject will be passed by ref­er­ence (ei­ther as `struct*` or `stuct&`) to the C func­tion:

```
typedef struct {
  ...
} MyClass;

void do_something(MyClass* data);
```

*Note:* Ob­vi­ously the order of the fields in the na­tive struct and the man­aged class *must be ex­actly the same*.

Mar­shalling Structs [∞](http://manski.net/2012/06/pinvoke-tutorial-passing-parameters-part-3/#marshalling-structs "Link to this section")
------------------------------------------------------------------------------------------------------------------------------------------

Mar­shalling man­aged `struct`s is al­most iden­ti­cal to mar­shalling ob­jects with only one dif­fer­ence: `struct`s are passed by copy by de­fault.

So for `struct`s the C/C++ func­tion sig­na­ture reads:

```
void do_something(MyClass data);
```

Of course, you can pass the `struct` also by ref­er­ence. In this case, use `(MyClass* data)` or `(MyClass& data)` in C/C++ and `(ref MyClass data)` in C\#.

Mar­shalling Del­e­gates [∞](http://manski.net/2012/06/pinvoke-tutorial-passing-parameters-part-3/#marshalling-delegates "Link to this section")
------------------------------------------------------------------------------------------------------------------------------------------------

Del­e­gates are mar­shalled di­rectly. The only thing you need to take care of is the “call­ing con­ven­tion”. The de­fault call­ing con­ven­tion is `Winapi` (which equals to `StdCall` on Win­dows). If your na­tive li­brary uses a dif­fer­ent call­ing con­ven­tion, you need to spec­ify it like this:

```
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void MyDelegate(IntPtr value);
```

Mar­shalling Ar­bi­trary Point­ers [∞](http://manski.net/2012/06/pinvoke-tutorial-passing-parameters-part-3/#marshalling-arbitrary-pointers "Link to this section")
-------------------------------------------------------------------------------------------------------------------------------------------------------------------

Ar­bi­trary point­ers (like `void*`) are mar­shalled as `IntPtr` ob­jects.

So this C func­tion:

```
void do_something(void* ptr);
```

be­comes:

```
[DllImport("NativeLib.dll")]
private static extern void do_something(IntPtr ptr);
```

👤Sebastian Krysmanski • [Articles](http://manski.net/topics/articles/), [Code Project](http://manski.net/topics/articles/code-project-articles/), [Software Development](http://manski.net/topics/tech/software-develop/) • [C\#](http://manski.net/tags/csharp/), [marshalling](http://manski.net/tags/marshalling/), [P/Invoke](http://manski.net/tags/pinvoke/)

6 comments
----------

1.  ![](Invoke%20Tutorial-%20Passing%20parameters%20(Part%203)%20-%20man_files/79498d665324b252dccd5279de71fd3a.png)Levy said: November 2, 2012 at 20:15 [∞](http://manski.net/2012/06/pinvoke-tutorial-passing-parameters-part-3/#comment-39327 "Permalink to this comment")

    How do I marshall an object from a third party DLL for which I do not have access to the source code?

     [Reply](http://manski.net/2012/06/pinvoke-tutorial-passing-parameters-part-3/?replytocom=39327#respond)

2.  ![](Invoke%20Tutorial-%20Passing%20parameters%20(Part%203)%20-%20man_files/77a37a4223989b6cddde24ae2cb6caa3.jpg)[Manski](http://www.mayastudios.com/) (post author) said: November 5, 2012 at 09:22 [∞](http://manski.net/2012/06/pinvoke-tutorial-passing-parameters-part-3/#comment-40058 "Permalink to this comment")

    If it’s a C++ object/class, I think you’re out of luck – at least, if you want to call any methods of the class (no matter whether you have the source code or not). If you just want to pass it around, use “IntPtr”.

     [Reply](http://manski.net/2012/06/pinvoke-tutorial-passing-parameters-part-3/?replytocom=40058#respond)

    -   ![](Invoke%20Tutorial-%20Passing%20parameters%20(Part%203)%20-%20man_files/6083e7f3db5f4023e4255b9483364f39.png)[Shawn](http://www.xinterop.com/) replied: April 28, 2013 at 19:17 [∞](http://manski.net/2012/06/pinvoke-tutorial-passing-parameters-part-3/#comment-141800 "Permalink to this comment")

        Hi, it is really very nice tutorial about pinvoke, and very organized.

        Even if its C++ class/object, it can still be called using PInvoke. Please read [PInvoke Interop SDK for C++ DLL](http://www.xinterop.com/index.php/2013/04/13/introduction-to-c-pinvoke-interop-sdk), basically, you would be able to marshal anything from C++ to C\# as long as they are exported from the C++ DLL.

3.  ![](Invoke%20Tutorial-%20Passing%20parameters%20(Part%203)%20-%20man_files/ce117e745472b132a6bf387a816fbc7a.png)Levy said: December 3, 2013 at 13:15 [∞](http://manski.net/2012/06/pinvoke-tutorial-passing-parameters-part-3/#comment-213911 "Permalink to this comment")

    How do I marshall an array of pointers in a C\# callback? For example:

    ```
    public delegate void CallbackPrototype(int sizeOfArray, IntPtr[] arrayOfPointers);

    void MyCallback(int sizeOfArray, IntPtr[] arrayOfPointers)
    {
      for (int i = 0; i < sizeOfArray; i++)
      {
        IntPtr intPtr = arrayOfPointers[i]; // fails for i != 0 because arrayOfPointers.Length is one
      }
    }
    ```

     [Reply](http://manski.net/2012/06/pinvoke-tutorial-passing-parameters-part-3/?replytocom=213911#respond)

4.  ![](Invoke%20Tutorial-%20Passing%20parameters%20(Part%203)%20-%20man_files/dd12c41bc4f34b6d3f47bb6474a935cc.jpg)[Tore Aurstad](http://aurstad.info/) said: April 25, 2015 at 13:50 [∞](http://manski.net/2012/06/pinvoke-tutorial-passing-parameters-part-3/#comment-270848 "Permalink to this comment")

    Great overview of P/Invoke! Is it possible to retrieve internal errors in the code you call, simple as wrapping a try catch I suppose? But will that give a generic error message, or is it possible to get internal details from the unmanaged dll?

     [Reply](http://manski.net/2012/06/pinvoke-tutorial-passing-parameters-part-3/?replytocom=270848#respond)

5.  ![](Invoke%20Tutorial-%20Passing%20parameters%20(Part%203)%20-%20man_files/92be9748b68b0c50257d6e870818ae4d.png)steve said: November 5, 2015 at 14:28 [∞](http://manski.net/2012/06/pinvoke-tutorial-passing-parameters-part-3/#comment-278262 "Permalink to this comment")

    Dear Sebastian
    Maybe, you got an idea or advice what’s the issue with passing a 2D string array from C\# to C++. Many thanks ..

    Here the C\# code, which works fine:

    public struct TestStruct
    {
    public string\[,\] stringArray;
    }

    \[DllImport(“C:\\\\Users\\\\Win32Project2.dll”,
    EntryPoint = “DDentry”,
    CallingConvention = CallingConvention.StdCall)\]

    public static extern void DDentry
    (
    \[In\]\[MarshalAs(UnmanagedType.LPArray,
    ArraySubType = UnmanagedType.BStr)\]
    string\[,\] arrayReadDat, int iDim1, int iDim2
    );

    private void button6\_Click\_1(object sender, EventArgs e)
    {
    TestStruct arrayReadDat = new TestStruct();
    arrayReadDat.stringArray = new string\[lastRow+1, lastCol+1\];
    string strK = “testify”;
    for (int i = 2; i &lt;= lastRow; i++)
    {
    for (int j = 1; j &lt;= lastCol; j++)
    {
    arrayReadDat.stringArray\[i, j\] = strK;
    }
    }

    int size = Marshal.SizeOf(typeof(TestStruct));
    IntPtr strPointer = Marshal.AllocHGlobal(size);
    Marshal.StructureToPtr(arrayReadDat, strPointer, false);

    DDentry(arrayReadDat.stringArray, lastRow+1, lastCol+1);

    Marshal.FreeHGlobal(strPointer);
    }

    Here the C++ code, where "no" data were passed to the pointer/array:

    extern "C"
    {
    \_declspec(dllexport) void DDentry(string \*p2DIntArray, int iDim1, int iDim2)

    {
    int iIndex = 0;
    for (int i = 2; i &lt;= iDim1; i++)
    {
    for (int j = 1; j &lt;= iDim2; j++)
    {
    arrayREAD\[i\]\[j\] = p2DIntArray\[iIndex++\];
    }
    }
    }
    }

     [Reply](http://manski.net/2012/06/pinvoke-tutorial-passing-parameters-part-3/?replytocom=278262#respond)

### Leave a Reply

Your email address will not be published. Required fields are marked \*

Comment

Name \*

Email \*

Website

recaptcha status
================

Recaptcha requires verification

I'm not a robot

reCAPTCHA

[Privacy](https://www.google.com/intl/en/policies/privacy/) - [Terms](https://www.google.com/intl/en/policies/terms/)

 


