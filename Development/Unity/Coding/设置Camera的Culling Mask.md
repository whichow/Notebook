
```csharp
//设置cullingMask为TransparentFX + OtherLayer
camera.cullingMask = (1 << LayerMask.NameToLayer("TransparentFX")) | (1 << LayerMask.NameToLayer("OtherLayer"));
//设置为Everything
camera.cullingMask = -1;
//设置为Nothing
camera.cullingMask = 0;
//设置为除了该层以外的所有层
camera.cullingMask = ~(1 << 14);
```

```csharp
// Turn on the bit using an OR operation:
private void Show() {
    camera.cullingMask |= 1 << LayerMask.NameToLayer("SomeLayer");
}

// Turn off the bit using an AND operation with the complement of the shifted int:
private void Hide() {
    camera.cullingMask &=  ~(1 << LayerMask.NameToLayer("SomeLayer"));
}

// Toggle the bit using a XOR operation:
private void Toggle() {
    camera.cullingMask ^= 1 << LayerMask.NameToLayer("SomeLayer");
}
```

[Edit Camera Culling Mask](http://answers.unity3d.com/questions/348974/edit-camera-culling-mask.html)

[Selective Camera Culling Mask](https://forum.unity3d.com/threads/selective-camera-culling-mask.28661/)