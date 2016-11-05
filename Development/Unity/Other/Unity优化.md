<div>

1.  在任何可能地方加入GC回收和resource回收，如暂停，从后台返回，切换场景等等
2.  严禁在游戏正常运行中进行GC回收和resource回收，除非特殊情况
3.  严禁移动静态collider（不包含rigidbody的碰撞器），应加上rigidbody    
                                             
4.  严禁使用FindGameObject或者FindObjectOfType相关（包括Awake中Find场景物件），除非特殊情况，应在编辑器界面指定
5.  unity5.0以下访问transform必须先缓存起来
6.  严禁使用string+string，会造成大量额外GC，应使用StringBuilder        
                                                                       
                            
7.  循环调用yield return new WaitForSecond()将会每帧导致垃圾分配GC      
                                                        
8.  所有事件基于触发（事件委托），不采用update脏更新，如if(last != now)
    DoSomthing
9.  尽量用for代替foreach
10. 字典查找必须用TryGetValue
11. 不要使用GameObject.tag或GameObject.name，效率不高并且会造成额外GC  
                                             
12. 严禁每帧设置UI数据（特别是如HP之类的动态数值需要UI每帧去获取，而是基于触发），除非特殊情况
13. 不要使用OnGUI
14. 删除所有空的Start Update等方法
15. 用委托代替SendMessage

<div>

<div>

\

</div>

<div>

减少模型面数

</div>

<div>

降低Drawcall：<span style="line-height: 1.6;">UI合并图集，static
batching(将不需要移动的物体</span><span
style="line-height: 1.6;">设置为static)</span>

</div>

<div>

减少粒子数量

</div>

<div>

减少光源数量

</div>

<div>

减少相机数量

</div>

<div>

使用prefab

</div>

<div>

对GameObject回收利用

</div>

<div>

算法

</div>

</div>

</div>
