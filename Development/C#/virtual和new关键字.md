The "new" keyword doesn't override, it signifies a new method that has
nothing to do with the base class method.

``` {.lang-cs .prettyprint .prettyprinted style="margin-top: 0px; margin-bottom: 1em; padding: 5px; border: 0px; font-size: 13px; width: auto; max-height: 600px; overflow: auto; font-family: Consolas, Menlo, Monaco, "Lucida Console", "Liberation Mono", "DejaVu Sans Mono", "Bitstream Vera Sans Mono", "Courier New", monospace, sans-serif; color: rgb(57, 51, 24); word-wrap: normal; background-color: rgb(239, 240, 241);"}
public class Foo{
     public bool DoSomething() { return false; }}public class Bar : Foo{
     public new bool DoSomething() { return true; }}public class Test{
    public static void Main ()
    {
        Foo test = new Bar ();
        Console.WriteLine (test.DoSomething ());
    }}
```

**This prints false, if you used override it would have printed true.**

(Base code taken from Joseph Daigle)

So, if you are doing real polymorphism you **SHOULD ALWAYS OVERRIDE**.
The only place where you need to use "new" is when the method is not
related in any way to the base class version.

![Virtual/Override
Explanation](http://farm4.static.flickr.com/3291/2906020424_f11f257afa.jpg?v=0)
