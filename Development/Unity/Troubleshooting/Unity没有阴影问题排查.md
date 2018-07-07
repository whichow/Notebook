## Troubleshooting shadows

If you find that one or more objects are not casting shadows then you should check the following points:

- Old graphics hardware may not support shadows. See below for a list of minimal hardware specs that can handle shadows.
- Shadows can be disabled in the [Quality Settings](https://docs.unity3d.com/Manual/class-QualitySettings.html). Make sure that you have the correct quality level enabled and that shadows are switched on for that setting.
- All [Mesh Renderers](https://docs.unity3d.com/Manual/class-MeshRenderer.html) in the scene must be set up with their *Receive Shadows* and *Cast Shadows* correctly set. Both are enabled by default but check that they haven’t been disabled unintentionally.
- Only opaque objects cast and receive shadows so objects using the built-in [Transparent](https://docs.unity3d.com/Manual/shader-TransparentFamily.html) or Particle shaders will neither cast nor receive. Generally, you can use the [Transparent Cutout](https://docs.unity3d.com/Manual/shader-TransparentCutoutFamily.html) shaders instead for objects with “gaps” such as fences, vegetation, etc. Custom [Shaders](https://docs.unity3d.com/Manual/Shaders.html) must be pixel-lit and use the [Geometry render queue](https://docs.unity3d.com/Manual/SL-SubShaderTags.html).
- Objects using **VertexLit** shaders can’t receive shadows but they can cast them.
- With the [Forward rendering path](https://docs.unity3d.com/Manual/RenderTech-ForwardRendering.html), some shaders allow only the brightest directional light to cast shadows (in particular, this happens with Unity’s legacy built-in shaders from 4.x versions). If you want to have more than one shadow-casting light then you should use the [Deferred Shading](https://docs.unity3d.com/Manual/RenderTech-DeferredShading.html) rendering path instead. You can enabled your own shaders to support “full shadows” by using the `fullforwardshadows` [surface shader](https://docs.unity3d.com/Manual/SL-SurfaceShaders.html) directive.

 