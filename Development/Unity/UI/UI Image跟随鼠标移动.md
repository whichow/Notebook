如果Canvas的RenderMode设置为`Screen Space - Overlay`，则可以使用
```csharp
transform.position = Input.mousePosition;
```
如果你改变了Canvas的RenderMode，使用下面的方法
```csharp
Vector2 pos;
RectTransformUtility.ScreenPointToLocalPointInRectangle(myCanvas.transform as RectTransform, Input.mousePosition, myCanvas.worldCamera, out pos);
transform.position = myCanvas.transform.TransformPoint(pos);
```

如果使用了选项`Screen Space - Camera`，方法如下
```csharp
var screenPoint = Vector3(Input.mousePosition);
screenPoint.z = 10.0f; //distance of the plane from the camera
transform.position = Camera.main.ScreenToWorldPoint(screenPoint);
```