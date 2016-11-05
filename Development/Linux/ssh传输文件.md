ssh传输文件
<div>

<div>

<div
style="margin: 0px 0px 1em; padding: 0px; border: 0px; clear: both; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: auto; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255);">

<div>

**Secure Copy (scp)**

</div>

<div>

To copy a file from B to A while logged into B:

</div>

<div>

\

</div>

<div
style="box-sizing: border-box; padding: 8px; border-radius: 4px; border: 1px solid rgba(0, 0, 0, 0.14902); background-color: rgb(251, 250, 248);">

<div>

<div>

scp /path/to/file username@a:/path/to/destination

</div>

</div>

</div>

<div>

\

</div>

<div>

To copy a file from B to A while logged into A:

</div>

<div>

\

</div>

<div
style="box-sizing: border-box; padding: 8px; border-radius: 4px; border: 1px solid rgba(0, 0, 0, 0.14902); background-color: rgb(251, 250, 248);">

<div>

<div>

scp username@b:/path/to/file /path/to/destination

</div>

</div>

</div>

<div>

\

</div>

<div>

**Secure FTP (sftp)**

</div>

<div>

\

</div>

<div
style="box-sizing: border-box; padding: 8px; border-radius: 4px; border: 1px solid rgba(0, 0, 0, 0.14902); background-color: rgb(251, 250, 248);">

<div>

<div>

sftp username@server

</div>

</div>

</div>

<div>

\

</div>

<div>

<div
style="margin: 0px 0px 1em; padding: 0px; border: 0px; clear: both; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: auto; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255);">

<div>

**SSHFS**

</div>

<div>

install sshfs

</div>

<div>

create a empty dir

</div>

<div>

\

</div>

<div
style="-en-codeblock: true; box-sizing: border-box; padding: 8px; font-family: Monaco, Menlo, Consolas, &quot;Courier New&quot;, monospace; font-size: 12px; color: rgb(51, 51, 51); border-top-left-radius: 4px; border-top-right-radius: 4px; border-bottom-right-radius: 4px; border-bottom-left-radius: 4px; background-color: rgb(251, 250, 248); border: 1px solid rgba(0, 0, 0, 0.14902); background-position: initial initial; background-repeat: initial initial;">

<div>

<div>

mkdir /home/user/testdir

</div>

</div>

</div>

<div>

\

</div>

<div>

"link" or "mount" the two directories

</div>

<div>

\

</div>

<div
style="-en-codeblock: true; box-sizing: border-box; padding: 8px; font-family: Monaco, Menlo, Consolas, &quot;Courier New&quot;, monospace; font-size: 12px; color: rgb(51, 51, 51); border-top-left-radius: 4px; border-top-right-radius: 4px; border-bottom-right-radius: 4px; border-bottom-left-radius: 4px; background-color: rgb(251, 250, 248); border: 1px solid rgba(0, 0, 0, 0.14902); background-position: initial initial; background-repeat: initial initial;">

<div>

<div>

sshfs user@server.com:/remote/dir /home/user/test

</div>

</div>

</div>

<div>

\

</div>

<div>

"unlink" the dirs

</div>

<div>

\

</div>

<div
style="-en-codeblock: true; box-sizing: border-box; padding: 8px; font-family: Monaco, Menlo, Consolas, &quot;Courier New&quot;, monospace; font-size: 12px; color: rgb(51, 51, 51); border-top-left-radius: 4px; border-top-right-radius: 4px; border-bottom-right-radius: 4px; border-bottom-left-radius: 4px; background-color: rgb(251, 250, 248); border: 1px solid rgba(0, 0, 0, 0.14902); background-position: initial initial; background-repeat: initial initial;">

<div>

<div>

fusermount -u /home/youruser/remotecomp

</div>

</div>

</div>

<div>

\

</div>

</div>

</div>

</div>

</div>

</div>
