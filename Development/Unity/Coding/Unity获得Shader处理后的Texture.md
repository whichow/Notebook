
```cs
using UnityEngine;
using System.Collections;

public class ExampleClass : MonoBehaviour {
    public Texture aTexture;
    public RenderTexture rTex;
    void Start() {
        if (!aTexture || !rTex)
            Debug.LogError("A texture or a render texture are missing, assign them.");
        
    }
    void Update() {
        Graphics.Blit(aTexture, rTex);
    }
}
```

[Graphics.Blit](https://docs.unity3d.com/ScriptReference/Graphics.Blit.html)