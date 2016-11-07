 

This article demonstrates how to install Apache and PHP on CentOS 6.

[TABLE]

[]()CentOS - Installing Apache and PHP5
---------------------------------------

CentOS comes with Apache v.2.2.3 and PHP v.5.1.6 and they are easily installed via the default CentOS Package Manager, yum.

The advantage of using yum (as opposed to installing via source code) is that you will get any security updates (if and when distributed) and dependencies are automatically taken care of.

[]()Apache Install
------------------

A basic Apache install is very easy:

```
sudo yum install httpd mod_ssl
```

[]()Oddly, the server does not start automatically when you install it so you have to do this by hand:

```
sudo /usr/sbin/apachectl start
```

The first thing you will see is this error:

```
Starting httpd: httpd: Could not reliably determine the server's fully qualified domain name,
using 127.0.0.1 for ServerName
```

As you can see, the address 127.0.0.1 (or whatever address you see there, usually your main IP address) is used as the server name by default. It's a good idea to set the ServerName for the next time the server is started.

Open the main Apache “config”:

```
sudo nano /etc/httpd/conf/httpd.conf
```

Towards the end of the file you'll find a section that starts with ServerName and gives the example:

```
#ServerName www.example.com:80
```

All you need to do is enter your Cloud Server host name or a fully-qualified domain name:

```
ServerName demo
```

Note that my Cloud Server host name is “demo”.

Now just reload Apache:

```
sudo /usr/sbin/apachectl restart
```

And the warning has gone.

[]()Firewall
------------

Notice that in some versions of CentOS, a firewall is installed by default which will block access to port 80, on which Apache runs. The following command will open this port:

```
sudo iptables -I INPUT -p tcp --dport 80 -j ACCEPT
```

Remember to save your firewall rules after adding that instruction so your web server will be accessible the next time you reboot:

```
sudo service iptables save
```

For more information on firewalls and their configuration, it is strongly recommended to read the [Firewalls](https://www.rackspace.com/knowledge_center/index.php/List_of_Articles#Firewalls "/knowledge_center/index.php/List_of_Articles#Firewalls") section of our knowledge base.

[]()Default Page
----------------

If you navigate to your Cloud Server IP address:

```
http://123.45.67.89
```

You will see the default CentOS Apache welcome screen:

![ centos\_apache\_welcome.jpg](CentOS%206%20-%20Apache%20and%20PHP%20Install%20-%20Knowledge%20Cent_files/Cent0SWelcome01.png)

This means the Apache install is a success.

[]()

Chkconfig
---------

Now that we have Apache installed and working properly, we need to make sure that it's set to start automatically when the Cloud Server is rebooted.

```
sudo /sbin/chkconfig httpd on
```

Let's check our work to confirm:

```
sudo /sbin/chkconfig --list httpd
httpd           0:off        1:off  2:on    3:on    4:on    5:on    6:off
```

The setting works.[]()

PHP5 Install
------------

Let's move on to the PHP5 install. I'm not going to install all the modules available, just a few common ones so you get the idea.

As before, due to using yum to install PHP5, any dependencies are taken care of:

```
sudo yum install php-mysql php-devel php-gd php-pecl-memcache php-pspell php-snmp php-xmlrpc php-xml
```

Once done, reload Apache:

```
sudo /usr/sbin/apachectl restart
```

[]()Almost done
---------------

The last thing we need to do is configure Apache for our setup so we can host multiple sites. We'll cover that in the [next article](https://www.rackspace.com/knowledge_center/index.php/CentOS_-_Apache_Virtual_Hosts) in this series.


