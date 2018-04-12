# Unity渲染优先级

在Unity中有多种控制渲染顺序的方式，Camera的Depth、Renderer的SortingLayer和SortingOrder、Shader的RenderQueue。

优先级：
Camera Depth > Renderer SortingLayer > Render SortingOrder > Shader RenderQueue

- Camera Depth：  
Depth越大，渲染顺序越靠后

- Renderer SortingLayer和SortingOrder：  
可以设置这两个参数的组件有Canvas，所有的Renderer(包括SpriteRenderer，MeshRenderer等)，
但是通常只对SpriteRenderer有效。这是因为MeshRenderer一般使用的材质中Shader都开启的深度写入，所以即使设置了这两个参数最后因为深度的影响不起作用。如果换成如Particles之类的Shader，或者使用自定义的Shader中关闭深度写入(Zwrite Off)，就可以看到效果了。

- Shader RenderQueue：  
在Shader中控制渲染顺序，在ShaderLab中，有几个预定义的RenderQueue，可以在预定义的值之间设置更多的值：
  - Background ：表示渲染在任何物体之前
  - Geometry（default）：渲染大多数几何物体所用的render queue
  - AlphaTest：用于alpha测试
  - Transparent：用于渲染半透明物体
  - Overlay：渲染所有物体之上
