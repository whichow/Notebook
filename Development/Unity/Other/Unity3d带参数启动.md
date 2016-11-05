<div class="show-content"
style="color: rgb(47, 47, 47); font-size: 16px; line-height: 1.7; font-family: -apple-system, 'Helvetica Neue', Arial, 'PingFang SC', 'lucida grande', 'lucida sans unicode', lucida, helvetica, 'Hiragino Sans GB', 'Microsoft YaHei', 'WenQuanYi Micro Hei', sans-serif; font-variant-ligatures: normal; orphans: 2; widows: 2; background-color: rgb(255, 255, 255);">

-   启动方法：

    ``` {.hljs .css style="padding: 9.5px; font-family: Menlo, Monaco, Consolas, 'Courier New', monospace; font-size: 13px; color: rgb(101, 123, 131); border-radius: 4px; margin-top: 0px; margin-bottom: 20px; line-height: 20px; word-break: break-all; word-wrap: normal; border: 1px solid rgba(0, 0, 0, 0.14902); overflow: auto; background: rgb(253, 246, 227);"}
    Process.Start(@"E:\TestScene\test.exe", " asdasd");
    ```

-   Unity Script：

    ``` {.hljs .cs style="padding: 9.5px; font-family: Menlo, Monaco, Consolas, 'Courier New', monospace; font-size: 13px; color: rgb(101, 123, 131); border-radius: 4px; margin-top: 0px; margin-bottom: 20px; line-height: 20px; word-break: break-all; word-wrap: normal; border: 1px solid rgba(0, 0, 0, 0.14902); overflow: auto; background: rgb(253, 246, 227);"}
      [SerializeField]
      Text t;
      string cmdInfo = "";
      void Start()
      {
          string[] arguments = Environment.GetCommandLineArgs();
          foreach (string arg in arguments)
          {
              cmdInfo += arg.ToString()+";";
          }
          t.text = cmdInfo;
      }
    ```

-   unity启动后拿到的结果：

    ``` {.hljs .css style="padding: 9.5px; font-family: Menlo, Monaco, Consolas, 'Courier New', monospace; font-size: 13px; color: rgb(101, 123, 131); border-radius: 4px; margin-top: 0px; margin-bottom: 20px; line-height: 20px; word-break: break-all; word-wrap: normal; border: 1px solid rgba(0, 0, 0, 0.14902); overflow: auto; background: rgb(253, 246, 227);"}
    E:\TestScene\test.exe;asdasd;
    ```

    可以清楚的看到，arguments数组的第一项是路径，第二项即是传递进来的参数

    <div style="color:gray">

    \

    </div>

</div>
