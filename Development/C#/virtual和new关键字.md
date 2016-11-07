The "new" keyword doesn't override, it signifies a new method that has nothing to do with the base class method.

```csharp
public class Foo{
    public bool DoSomething() { return false; }}public class Bar : Foo{
    public new bool DoSomething() { return true; }}public class Test{
    public static void Main ()
    {
        Foo test = new Bar ();
        Console.WriteLine (test.DoSomething ());
    }
}
```

**This prints false, if you used override it would have printed true.**

(Base code taken from Joseph Daigle)

So, if you are doing real polymorphism you **SHOULD ALWAYS OVERRIDE**. The only place where you need to use "new" is when the method is not related in any way to the base class version.

![Virtual/Override Explanation](http://farm4.static.flickr.com/3291/2906020424_f11f257afa.jpg?v=0)
