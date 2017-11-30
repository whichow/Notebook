在使用Unity的过程中，我们总是想直接给position的x、y、z直接赋值，像这样
```cs
transform.position.x = 10f;
```
但是编译器总是会提示报错"Cannot modify the return value of 'Transform.position' because it is not a variable"

网上说是因为position是Vector3类型的，而Vector3是一个结构体，本来结构体这样复制也没什么问题，但是position在Transform中是一个有get和set方法的property，访问transform的position会调用get方法，由于结构体是值类型的数据类型，所以调用get方法得到的是position的拷贝，给这个拷贝复制不会对Transform的position有产生任何改变，如果编译器不提示的话，很难定位这样的Bug。

[Set value on GameObject.transform.position.x with C# ?](https://forum.unity.com/threads/set-value-on-gameobject-transform-position-x-with-c.66768/)