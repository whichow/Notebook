ssh传输文件
**Secure Copy (scp)**

To copy a file from B to A while logged into B:

scp /path/to/file username@a:/path/to/destination

To copy a file from B to A while logged into A:

scp username@b:/path/to/file /path/to/destination

**Secure FTP (sftp)**

sftp username@server

**SSHFS**

install sshfs

create a empty dir

mkdir /home/user/testdir

"link" or "mount" the two directories

sshfs user@server.com:/remote/dir /home/user/test

"unlink" the dirs

fusermount -u /home/youruser/remotecomp


