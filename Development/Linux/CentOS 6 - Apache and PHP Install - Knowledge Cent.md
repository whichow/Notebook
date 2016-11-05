<div id="content">

<div id="content-wrap" class="container">

<div id="content-main" class="twelve columns">

<div class="region region-content">

<div id="block-system-main" class="block block-system">

<div class="content">

<div class="content">

<div
class="field field-name-body field-type-text-with-summary field-label-hidden">

<div class="field-items">

<div property="content:encoded"
style="border: 0px none rgb(51, 51, 51); color: rgb(51, 51, 51); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 13px; line-height: normal; font-family: arial; height: 3047px; margin: 0px; outline: rgb(51, 51, 51) none 0px; padding: 0px; text-decoration: none; width: 700px;">

 

This article demonstrates how to install Apache and PHP on CentOS 6.

+--------------------------------------------------------------------------+
| Contents {#contents style="border: 0px none rgb(81, 76, 76); color: rgb( |
| 81, 76, 76); display: block; font-style: normal; font-variant: normal; f |
| ont-weight: bold; font-stretch: normal; font-size: 18px; line-height: no |
| rmal; font-family: arial; height: 21px; margin: 0px; outline: rgb(81, 76 |
| , 76) none 0px; padding: 0px; text-decoration: none; width: 272px; word- |
| wrap: break-word;"}                                                      |
| --------                                                                 |
|                                                                          |
| -   [1 CentOS - Installing Apache and                                    |
|     PHP5](#CentOS_-_Installing_Apache_and_PHP5)                          |
| -   [2 Apache Install](#Apache_Install)                                  |
| -   [3 ServerName](#ServerName)                                          |
| -   [4 Firewall](#Firewall)                                              |
| -   [5 Default Page](#Default_Page)                                      |
| -   [6 Chkconfig](#Chkconfig)                                            |
| -   [7 PHP5 Install](#PHP5_Install)                                      |
| -   [8 Almost](#Almost)                                                  |
+--------------------------------------------------------------------------+

[]()CentOS - Installing Apache and PHP5 {#centos---installing-apache-and-php5 style="border: 0px none rgb(81, 76, 76); color: rgb(81, 76, 76); display: block; font-style: normal; font-variant: normal; font-weight: bold; font-stretch: normal; font-size: 18px; line-height: normal; font-family: arial; height: 21px; margin: 0px; outline: rgb(81, 76, 76) none 0px; padding: 0px; text-decoration: none; width: 700px;"}
---------------------------------------

CentOS comes with Apache v.2.2.3 and PHP v.5.1.6 and they are easily
installed via the default CentOS Package Manager, yum.

The advantage of using yum (as opposed to installing via source code) is
that you will get any security updates (if and when distributed) and
dependencies are automatically taken care of.

[]()Apache Install {#apache-install style="border: 0px none rgb(81, 76, 76); color: rgb(81, 76, 76); display: block; font-style: normal; font-variant: normal; font-weight: bold; font-stretch: normal; font-size: 18px; line-height: normal; font-family: arial; height: 21px; margin: 0px; outline: rgb(81, 76, 76) none 0px; padding: 0px; text-decoration: none; width: 700px;"}
------------------

A basic Apache install is very easy:

``` {style="border: 0px none rgb(255, 255, 255); color: rgb(255, 255, 255); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 13px; line-height: normal; font-family: monospace; height: 16px; margin: 13px 0px; outline: rgb(255, 255, 255) none 0px; overflow: auto; padding: 40px 20px 20px; text-decoration: none; white-space: pre; width: 660px; background: none 0% 0% / auto repeat scroll padding-box border-box rgb(51, 51, 51);"}
sudo yum install httpd mod_ssl
```

[]()Oddly, the server does not start automatically when you install it
so you have to do this by hand:

``` {style="border: 0px none rgb(255, 255, 255); color: rgb(255, 255, 255); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 13px; line-height: normal; font-family: monospace; height: 16px; margin: 13px 0px; outline: rgb(255, 255, 255) none 0px; overflow: auto; padding: 40px 20px 20px; text-decoration: none; white-space: pre; width: 660px; background: none 0% 0% / auto repeat scroll padding-box border-box rgb(51, 51, 51);"}
sudo /usr/sbin/apachectl start
```

The first thing you will see is this error:

``` {style="border: 0px none rgb(255, 255, 255); color: rgb(255, 255, 255); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 13px; line-height: normal; font-family: monospace; height: 30px; margin: 13px 0px; outline: rgb(255, 255, 255) none 0px; overflow: auto; padding: 40px 20px 20px; text-decoration: none; white-space: pre; width: 660px; background: none 0% 0% / auto repeat scroll padding-box border-box rgb(51, 51, 51);"}
Starting httpd: httpd: Could not reliably determine the server's fully qualified domain name,
using 127.0.0.1 for ServerName
```

As you can see, the address 127.0.0.1 (or whatever address you see
there, usually your main IP address) is used as the server name by
default. It's a good idea to set the ServerName for the next time the
server is started.

Open the main Apache “config”:

``` {style="border: 0px none rgb(255, 255, 255); color: rgb(255, 255, 255); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 13px; line-height: normal; font-family: monospace; height: 16px; margin: 13px 0px; outline: rgb(255, 255, 255) none 0px; overflow: auto; padding: 40px 20px 20px; text-decoration: none; white-space: pre; width: 660px; background: none 0% 0% / auto repeat scroll padding-box border-box rgb(51, 51, 51);"}
sudo nano /etc/httpd/conf/httpd.conf
```

Towards the end of the file you'll find a section that starts with
ServerName and gives the example:

``` {style="border: 0px none rgb(255, 255, 255); color: rgb(255, 255, 255); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 13px; line-height: normal; font-family: monospace; height: 16px; margin: 13px 0px; outline: rgb(255, 255, 255) none 0px; overflow: auto; padding: 40px 20px 20px; text-decoration: none; white-space: pre; width: 660px; background: none 0% 0% / auto repeat scroll padding-box border-box rgb(51, 51, 51);"}
#ServerName www.example.com:80
```

All you need to do is enter your Cloud Server host name or a
fully-qualified domain name:

``` {style="border: 0px none rgb(255, 255, 255); color: rgb(255, 255, 255); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 13px; line-height: normal; font-family: monospace; height: 16px; margin: 13px 0px; outline: rgb(255, 255, 255) none 0px; overflow: auto; padding: 40px 20px 20px; text-decoration: none; white-space: pre; width: 660px; background: none 0% 0% / auto repeat scroll padding-box border-box rgb(51, 51, 51);"}
ServerName demo
```

Note that my Cloud Server host name is “demo”.

Now just reload Apache:

``` {style="border: 0px none rgb(255, 255, 255); color: rgb(255, 255, 255); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 13px; line-height: normal; font-family: monospace; height: 16px; margin: 13px 0px; outline: rgb(255, 255, 255) none 0px; overflow: auto; padding: 40px 20px 20px; text-decoration: none; white-space: pre; width: 660px; background: none 0% 0% / auto repeat scroll padding-box border-box rgb(51, 51, 51);"}
sudo /usr/sbin/apachectl restart
```

And the warning has gone.

[]()Firewall {#firewall style="border: 0px none rgb(81, 76, 76); color: rgb(81, 76, 76); display: block; font-style: normal; font-variant: normal; font-weight: bold; font-stretch: normal; font-size: 18px; line-height: normal; font-family: arial; height: 21px; margin: 0px; outline: rgb(81, 76, 76) none 0px; padding: 0px; text-decoration: none; width: 700px;"}
------------

Notice that in some versions of CentOS, a firewall is installed by
default which will block access to port 80, on which Apache runs. The
following command will open this port:

``` {style="border: 0px none rgb(255, 255, 255); color: rgb(255, 255, 255); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 13px; line-height: normal; font-family: monospace; height: 16px; margin: 13px 0px; outline: rgb(255, 255, 255) none 0px; overflow: auto; padding: 40px 20px 20px; text-decoration: none; white-space: pre; width: 660px; background: none 0% 0% / auto repeat scroll padding-box border-box rgb(51, 51, 51);"}
sudo iptables -I INPUT -p tcp --dport 80 -j ACCEPT
```

Remember to save your firewall rules after adding that instruction so
your web server will be accessible the next time you reboot:

``` {style="border: 0px none rgb(255, 255, 255); color: rgb(255, 255, 255); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 13px; line-height: normal; font-family: monospace; height: 16px; margin: 13px 0px; outline: rgb(255, 255, 255) none 0px; overflow: auto; padding: 40px 20px 20px; text-decoration: none; white-space: pre; width: 660px; background: none 0% 0% / auto repeat scroll padding-box border-box rgb(51, 51, 51);"}
sudo service iptables save
```

For more information on firewalls and their configuration, it is
strongly recommended to read the
[Firewalls](https://www.rackspace.com/knowledge_center/index.php/List_of_Articles#Firewalls "/knowledge_center/index.php/List_of_Articles#Firewalls")
section of our knowledge base.

[]()Default Page {#default-page style="border: 0px none rgb(81, 76, 76); color: rgb(81, 76, 76); display: block; font-style: normal; font-variant: normal; font-weight: bold; font-stretch: normal; font-size: 18px; line-height: normal; font-family: arial; height: 21px; margin: 0px; outline: rgb(81, 76, 76) none 0px; padding: 0px; text-decoration: none; width: 700px;"}
----------------

If you navigate to your Cloud Server IP address:

``` {style="border: 0px none rgb(255, 255, 255); color: rgb(255, 255, 255); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 13px; line-height: normal; font-family: monospace; height: 16px; margin: 13px 0px; outline: rgb(255, 255, 255) none 0px; overflow: auto; padding: 40px 20px 20px; text-decoration: none; white-space: pre; width: 660px; background: none 0% 0% / auto repeat scroll padding-box border-box rgb(51, 51, 51);"}
http://123.45.67.89
```

You will see the default CentOS Apache welcome screen:

![
centos\_apache\_welcome.jpg](CentOS%206%20-%20Apache%20and%20PHP%20Install%20-%20Knowledge%20Cent_files/Cent0SWelcome01.png){width="490"
height="342"}

This means the Apache install is a success.

[]()

Chkconfig {#chkconfig style="border: 0px none rgb(81, 76, 76); color: rgb(81, 76, 76); display: block; font-style: normal; font-variant: normal; font-weight: bold; font-stretch: normal; font-size: 18px; line-height: normal; font-family: arial; height: 21px; margin: 0px; outline: rgb(81, 76, 76) none 0px; padding: 0px; text-decoration: none; width: 700px;"}
---------

Now that we have Apache installed and working properly, we need to make
sure that it's set to start automatically when the Cloud Server is
rebooted.

``` {style="border: 0px none rgb(255, 255, 255); color: rgb(255, 255, 255); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 13px; line-height: normal; font-family: monospace; height: 16px; margin: 13px 0px; outline: rgb(255, 255, 255) none 0px; overflow: auto; padding: 40px 20px 20px; text-decoration: none; white-space: pre; width: 660px; background: none 0% 0% / auto repeat scroll padding-box border-box rgb(51, 51, 51);"}
sudo /sbin/chkconfig httpd on
```

Let's check our work to confirm:

``` {style="border: 0px none rgb(255, 255, 255); color: rgb(255, 255, 255); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 13px; line-height: normal; font-family: monospace; height: 30px; margin: 13px 0px; outline: rgb(255, 255, 255) none 0px; overflow: auto; padding: 40px 20px 20px; text-decoration: none; white-space: pre; width: 660px; background: none 0% 0% / auto repeat scroll padding-box border-box rgb(51, 51, 51);"}
sudo /sbin/chkconfig --list httpd
httpd           0:off        1:off  2:on    3:on    4:on    5:on    6:off
```

The setting works.[]()

PHP5 Install {#php5-install style="border: 0px none rgb(81, 76, 76); color: rgb(81, 76, 76); display: block; font-style: normal; font-variant: normal; font-weight: bold; font-stretch: normal; font-size: 18px; line-height: normal; font-family: arial; height: 21px; margin: 0px; outline: rgb(81, 76, 76) none 0px; padding: 0px; text-decoration: none; width: 700px;"}
------------

Let's move on to the PHP5 install. I'm not going to install all the
modules available, just a few common ones so you get the idea.

As before, due to using yum to install PHP5, any dependencies are taken
care of:

``` {style="border: 0px none rgb(255, 255, 255); color: rgb(255, 255, 255); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 13px; line-height: normal; font-family: monospace; height: 16px; margin: 13px 0px; outline: rgb(255, 255, 255) none 0px; overflow: auto; padding: 40px 20px 20px; text-decoration: none; white-space: pre; width: 660px; background: none 0% 0% / auto repeat scroll padding-box border-box rgb(51, 51, 51);"}
sudo yum install php-mysql php-devel php-gd php-pecl-memcache php-pspell php-snmp php-xmlrpc php-xml
```

Once done, reload Apache:

``` {style="border: 0px none rgb(255, 255, 255); color: rgb(255, 255, 255); display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 13px; line-height: normal; font-family: monospace; height: 16px; margin: 13px 0px; outline: rgb(255, 255, 255) none 0px; overflow: auto; padding: 40px 20px 20px; text-decoration: none; white-space: pre; width: 660px; background: none 0% 0% / auto repeat scroll padding-box border-box rgb(51, 51, 51);"}
sudo /usr/sbin/apachectl restart
```

[]()Almost done {#almost-done style="border: 0px none rgb(81, 76, 76); color: rgb(81, 76, 76); display: block; font-style: normal; font-variant: normal; font-weight: bold; font-stretch: normal; font-size: 18px; line-height: normal; font-family: arial; height: 21px; margin: 0px; outline: rgb(81, 76, 76) none 0px; padding: 0px; text-decoration: none; width: 700px;"}
---------------

The last thing we need to do is configure Apache for our setup so we can
host multiple sites. We'll cover that in the [next
article](https://www.rackspace.com/knowledge_center/index.php/CentOS_-_Apache_Virtual_Hosts) in
this series.

</div>

</div>

</div>

</div>

</div>

</div>

</div>

</div>

</div>

</div>
