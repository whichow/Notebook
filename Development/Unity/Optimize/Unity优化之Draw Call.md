- Draw Call拼合的物体仍然可以正常进行渲染剔除
- 静态物体勾选Static可以使用静态拼合
  - 静态拼合比动态拼合效率更高，但是会使用更多的内存
  - 一定不要移动、旋转或缩放静态物体
- Unity会自动拼合材质相同的运动物体，但是要注意动态拼合的条件
  - 动态拼合的物体只能应用在顶点属性(包括顶点位置，法向量，UV)少于900个的Mesh上
  - Transform镜像的的物体不能拼合(scale为+1和scale为-1的物体不能拼合)
  - 材质不同的物体不能拼合，甚至相同的材质的不同实例也不能拼合
  - 访问材质需要使用Renderer.sharedMaterial，Renderer.material会拷贝一份材质
  - 可以将贴图合并成图集来共享材质
  - 有lightmap的物体的lightmap中index和offset/scale不同不能拼合
  - 多pass的Shader不能拼合
  - 只有Mesh Renderers, Trail Renderers, Line Renderers, Particle Systems和Sprite Renderers可以拼合，skinned Meshes, Cloth和其他渲染组件不会拼合
  - Renderer只会和相同类型的Renderer拼合
  - 半透明的物体由于渲染顺序的原因会拼合不成功
- 可以使用Mesh.CombineMeshes手动合并相近物体的Mesh，比draw call拼合性能更好

[Draw call batching](https://docs.unity3d.com/Manual/DrawCallBatching.html)