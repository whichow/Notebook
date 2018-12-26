在C#中如果我们想要将一个类型赋值给另外一个不同的类型，如果直接赋值是编译不通过的，我们可以通过运算符重载来实现

有一个如下的类，我们想要让它可以赋值给UnityEngine.Vector3类型：

```c#
public class Point3D
{
    public float X
    {
        get;
        set;
    }

    public float Y
    {
        get;
        set;
    }

    public float Z
    {
        get;
        set;
    }
}
```

隐式转换：

```c#
public class Point3D
{
    ......
    public static implicit operator Vector3(Point3D point)
    {
        return new Vector3(point.X, point.Y, point.Z);
    }
}
```

示例：

```c#
Point3D p = new Point3D(){X = 0.1f, Y = 0.2f, Z = 0.3f};
Vector3 v = p;
```

显式转换：

```c#
public class Point3D
{
    ......
    public static explicit operator Vector3(Point3D point)
    {
        return new Vector3(point.X, point.Y, point.Z);
    }
}
```

示例：

```c#
Point3D p = new Point3D(){X = 0.1f, Y = 0.2f, Z = 0.3f};
Vector3 v = (Vector3)p;
```

需要注意的是，隐式转换和显式转换不可以同时存在



[c#自定义类型的转换方式operator,以及implicit（隐式）和explicit （显示）声明的区别](https://www.cnblogs.com/madkex/archive/2012/05/29/2523977.html)