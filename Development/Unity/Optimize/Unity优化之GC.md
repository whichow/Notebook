- 使用缓存
- 重复使用链表或数组
- 使用对象池
- 字符串
  - 减少不必要的字符串的创建
  - 减少不必要的字符串操作
  - 使用`StringBuilder`而不是`+`来拼接字符串
- 避免频繁装箱操作
- 5.5以下版本不使用foreach
- 减少LINQ的使用
- 发布正式包时移除游戏中的Debug.Log()函数

[Unity性能优化（3）-官方教程Optimizing garbage collection in Unity games翻译](https://www.cnblogs.com/alan777/p/6155501.html)