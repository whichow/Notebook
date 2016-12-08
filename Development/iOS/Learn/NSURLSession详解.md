# NSURLSession 详解

## 理解 URL Session 的概念

### 会话(Session)的类型
`NSURLSession` API 支持三种类型的会话，由用于创建会话的配置对象的类型确定：
- 默认会话(Default session)的行为类似于 Foundation 中其他用于 URL 下载的方法。它们使用持久的基于磁盘的缓存并且储存凭据到用户的钥匙串中。
- 临时会话(Ephemeral session)不会存储任何数据到硬盘；所有缓存，凭证存储，和其他东西都存放在内存中并且和会话绑定。因此，当你的 app 终止了会话，它们将被自动清除。
- 后台会话(Background session)类似于默认会话，除了单独的进程处理所有的数据传输。后台会话有一些附加的限制，在下面会有说明。

### 任务(Tasks)的类型
在一个会话中，`NSURLSession` 类支持三种类型的任务：数据任务，下载任务，和上传任务。
- 数据任务(Data tasks)使用 NSData 对象发送和接收数据。数据任务用于从你的 app 到服务器的简短的，通常是交互的请求。数据任务可以在每次收到数据就返回数据到你的 app，或者通过 completion handler 将所有数据一起返回。 
- 下载任务(Download tasks)以文件的形式获取数据，并支持后台下载在 app 没有运行的时候。
- 上传任务(Upload tasks)以文件的形式发送数据，并支持后台上传在 app 没有运行的时候。

### 后台传输注意事项
`NSURLSession` 类支持你的 app 被挂起的时候在后台传输。后台传输只由使用后台会话配置创建的会话提供。

对于后台会话，由于实际传输由单独的进程执行，并且由于重启应用程序进程的过程相对昂贵，因此几个功能不可用，导致以下的限制：
- 会话必须提供一个 delegate 用于事件的传递。
- 只支持 HTTP 和 HTTPS 协议。
- 重定向始终都会执行。
- 只支持从文件的上传任务。
- 如果后台传输实在 app 处于后台运行时启动的，则配置对象的 `discretionary` 属性将被视为 `true`。

> 注意：在iOS 8 和 OS X 10.10 之前，数据任务不被后台任务支持。

在 iOS 中，当后台传输完成或者需要验证时，如果你的 app 不再运行，iOS 将在后台自动重启你的 app，并且调用你的 app 的UIApplicationDelegate对象中的 `application:handleEventsForBackgroundURLSession:completionHandler:` 方法。调用提供导致你的 app 启动的会话的标识符。你的 app 应该保存 completion handler，以相同的标识符创建一个后台配置对象，并用配置对象创建一个会话。新的会话会与正在进行的后台活动自动重新关联。之后，当会话完成最后的后台下载，它将发送一个 `URLSessionDidFinishEventsForBackgroundURLSession:` 的消息给会话的 delegate。在 delegate 方法中，在主线程中调用之前保存的 completion handler 使得操作系统知道可以再次安全的挂起你的 app。

在 iOS 和 OS X 中，当用户重启你的 app，你的 app 应该立即以和最后一次运行 app 时未完成的任务的任何会话相同的标识符创建后台配置对象，然后为每一个配置对象创建一个会话。这些新的会话类似的会与正在进行的后台活动进行重新关联。

> 注意：你必须给每一个标识符创建一个会话。多个会话共享一个标识符的行为将无法确定。

如果有任何任务在你的 app 挂起时完成，delegate 的 `URLSession:downloadTask:didFinishDownloadingToURL:` 方法将随着相关的任务和新下载的文件的 URL 被调用。

类似的，如果你的任务需要验证，`NSURLSession` 对象将适当的调用 delegate 的 `URLSession:task:didReceiveChallenge:completionHandler:` 方法或者 `URLSession:didReceiveChallenge:completionHandler` 方法。

网络错误后，URL 加载系统会自动重试在后台会话中上传和下载任务。没有必要使用可达性 API 来确定何时重试一个失败的任务。

## 创建和配置会话

`NSURLSession` API 提供了各种各样的配置选项：
- 私有存储以指定一个单独的会话的方式提供给缓存，cookies，凭据，和协议
- 认证，绑定到特定请求（任务）或请求（会话）组
- 通过 URL 上传和下载文件，鼓励将数据（文件内容）从元数据（URL 和设置）中分离
- 每个主机最大连接数配置
- 如果一个资源在确定的时间内不能下载将触发每个资源的超时时间
- 最小和最大 TLS 版本支持
- 自定义代理字典
- 控制 cookie 的政策
- 控制 HTTP 流水线行为

