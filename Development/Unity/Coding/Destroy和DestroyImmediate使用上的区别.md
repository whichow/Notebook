Object.Destroy用来移除一个gameobject，component或asset。

如果移除的对象是一个Component，将从GameObject移除并销毁它，如果移除的对象是一个GameObject，将销毁这个GameObject，包括它所有的component和子transform。对象实际的销毁总是延迟到当前Update循环之后，但是在渲染之前完成。

```csharp
// Kills the game object
Destroy (gameObject);

// Removes this script instance from the game object
Destroy (this);

// Removes the rigidbody from the game object
Destroy (rigidbody);

// Kills the game object in 5 seconds after loading the object
Destroy (gameObject, 5);

// When the user presses Ctrl, it will remove the script 
// named FooScript from the game object
void Update () {
    if (Input.GetButton("Fire1") && GetComponent<FooScript>())
    {
        Destroy (GetComponent<FooScript>());
    }
}
```

Object.DestroyImmediate，立即销毁对象。

必须小心使用这个函数，因为它可以立即永久的销毁资源。注意你永远不应该在数组遍历中销毁成员。这个函数只应该用在写编辑器代码中。

在游戏代码中你应该使用Object.Destroy代替Object.DestroyImmediate。始终强烈建议使用Object.Destroy，Destory会在一个安全的时间执行。DestroyImmediate则会立即发生。