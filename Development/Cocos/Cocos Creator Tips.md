1. 打包后的JS脚本及调试时使用的脚本都放在`project.dev.js`里

2. `cc.sys.localStorage`保存的数据都放在C:\Users\Administrator\AppData\Local\工程名\jsb.sqlite里

3. Cocos Creator编译的log及出错信息都放在C:\Users\Administrator\.CocosCreator\logs\native.log里

4. 打印当前的堆栈信息可以使用`cc.log((new Error()).stack);`

5. Android端调用JS脚本

   ```java
   runOnGLThread(new Runnable(){
       @Override
       public void run()
       {
       	Cocos2dxJavascriptJavaBridge.evalString("cc.log(\"Javascript Java bridge!\")");
   });
   ```