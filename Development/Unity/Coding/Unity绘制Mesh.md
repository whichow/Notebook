
```cs
using UnityEngine;
using System.Collections;

public class ExampleClass : MonoBehaviour {
    public Mesh mesh;
    public Material material;
    public void Update() {
        // will make the mesh appear in the scene at origin position
        Graphics.DrawMesh(mesh, Vector3.zero, Quaternion.identity, material, 0);
    }
}
```

[Graphics.DrawMesh](https://docs.unity3d.com/ScriptReference/Graphics.DrawMesh.html)