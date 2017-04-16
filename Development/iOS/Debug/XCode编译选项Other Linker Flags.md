
我们有时在引用第三方库的时候，app运行的时候会闪退，提示"selector not recognized"运行时异常。我们仔细查看这些库的文档一般都会告诉我们要在Other Linker Flags中添加`-ObjC`选项，这是为什么呢

**参考**

[Building Objective-C static libraries with categories](https://developer.apple.com/library/content/qa/qa1490/_index.html)