-   启动方法：

    ``` hljs
    Process.Start(@"E:\TestScene\test.exe", " asdasd");
    ```

-   Unity Script：

    ``` hljs
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

    ``` hljs
    E:\TestScene\test.exe;asdasd;
    ```

    可以清楚的看到，arguments数组的第一项是路径，第二项即是传递进来的参数


