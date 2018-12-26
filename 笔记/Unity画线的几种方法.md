- Debug.DrawLine
    - 一般在Update/Fixed Update/LateUpdate中调用
    - 只在Scene窗口中显示
    - 不能设置材质
- Gizmos.DrawLine
    - 在OnDrawGizmos/OnDrawGizmosSelected中调用
    - 只在Scene窗口中显示
    - 不能设置材质
- Graphic.DrawMesh(需要先创建Mesh)
    - 一般在Update/Fixed Update/LateUpdate中调用
    - 在Game和Scene窗口都显示
    - 可以设置材质
- GL.Begin(GL.LINES)
    - 在物体的OnRenderObject或者相机的OnPostRender中调用
    - 在Game和Scene窗口都显示
    - 可以设置材质
- Handles.DrawLine
    - 编辑器脚本
    - 只在Scene窗口显示
    - 在OnSceneGUI中调用
- LineRenderer
    - Unity组件
    - 可以设置材质
    - 在Game和Scene窗口都显示

[【风宇冲】图形化调试](http://blog.sina.com.cn/s/blog_471132920101gxzf.html)

[How to draw a line using script](https://answers.unity.com/questions/8338/how-to-draw-a-line-using-script.html)