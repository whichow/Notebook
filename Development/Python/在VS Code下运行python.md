## 配置Python开发环境
以Windows为例，首先需要下载Python并安装，勾选添加Python到系统环境变量。Python 2.7.9和Python 3.4以上版本自带pip，可以很方便的安装各种包。

打开VS Code，按下快捷键`Ctrl+Shift+P`，输入"task"，选择"Tasks: Configure Task Runner"，之后选择'TypeScript - tsconfig.json'。
修改`tasks.json`文件
```json
{
    "version": "0.1.0",
    "command": "python",
    "isShellCommand": true,
    "args": ["${file}"],
    "showOutput": "always"
}
```
配置好后，按下`Ctrl+Shift+B`就可以执行了，或者按下`Ctrl+Shift+P`，输入"tasks"选择"Tasks:Run Task"。如果要停止，按下`Ctrl+Shift+P`，输入"tasks"，选择"Tasks:Terminate Running Task"。

## 调试
点击扩展按钮或按快捷键`Ctrl+Shift+X`，搜索Python，选第一个，安装Python扩展。安装好后，点击调试按钮或按快捷键`Ctrl+Shift+D`切换到调试模式了，打上断点，点击开始调试，会让你选择要调试的程序类型，选Python就可以了。

**参考**

[VS Code搭建Python开发环境](https://xin053.github.io/2016/06/11/VS%20Code%E6%90%AD%E5%BB%BAPython%E5%BC%80%E5%8F%91%E7%8E%AF%E5%A2%83/)

[[Python] 使用 Visual Studio Code 作為開發環境](http://oranwind.org/python-vscode/)