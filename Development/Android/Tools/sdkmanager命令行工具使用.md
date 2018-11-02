# sdkmanager

`sdkmanager` 是一个命令行工具，它可以让你查看、安装、升级和卸载Android SDK包。

## 使用

你可以使用`sdkmanager`执行下面的任务。

### 列出已安装和可用的包

```
sdkmanager --list [options]
```

### 安装包

```
sdkmanager packages [options]
```

packages参数是使用--list命令列出的路径和版本，需要使用双引号括起来（如：`"build-tools;28.0.3"`或`"platforms;android-28"`）。你还可以同时下载多个包，只需要用空格将参数隔开。

如要下载最后版本的Platform Tools（包含`adb`和`fastboot`）和API level为20的Platform：

```
sdkmanager "platform-tools" "platforms;android-28"
```

或者，你可以传递一个文本文件指定要下载的所有包：

```
sdkmanager --package_file=package_file [options]
```

该文本文件的每一行都是一个要安装的包的路径（不需要双引号）。

### 卸载包:

```
sdkmanager --uninstall packages [options]
sdkmanager --uninstall --package_file=package_file [options]
```

### 升级所有已安装的包

```
sdkmanager --update [options]
```

## 可选参数

下面这张表列出了以上命令的可选参数。

| Option                                           | Description                                                  |
| ------------------------------------------------ | ------------------------------------------------------------ |
| `--sdk_root=**path**`                            | Use the specified SDK path instead of the SDK containing this tool |
| `--channel=**channel_id**`                       | Include packages in channels up to channel_id. Available channels are:`0` (Stable), `1` (Beta), `2` (Dev), and `3` (Canary). |
| `--include_obsolete`                             | Include obsolete packages in the package listing or package updates. For use with `--list`and `--update` only. |
| `--no_https`                                     | Force all connections to use HTTP rather than HTTPS.         |
| `--verbose`                                      | Verbose output mode. Errors, warnings and informational messages are printed. |
| `--proxy={http | socks}`                         | Connect via a proxy of the given type: either `http` for high level protocols such as HTTP or FTP, or `socks` for a SOCKS (V4 or V5) proxy. |
| `--proxy_host={**IP_address** |**DNS_address**}` | IP or DNS address of the proxy to use.                       |
| `--proxy_port=**port_number**`                   | Proxy port number to connect to.                             |