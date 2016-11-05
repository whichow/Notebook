Python使用MySQL
<div>

<div>

使用connect构造器创建MySQL数据库连接，返回一个MySQLConnection对象

</div>

<div>

\

</div>

<div
style="-en-codeblock: true; box-sizing: border-box; padding: 8px; font-family: Monaco, Menlo, Consolas, &quot;Courier New&quot;, monospace; font-size: 12px; color: rgb(51, 51, 51); border-top-left-radius: 4px; border-top-right-radius: 4px; border-bottom-right-radius: 4px; border-bottom-left-radius: 4px; background-color: rgb(251, 250, 248); border: 1px solid rgba(0, 0, 0, 0.14902); background-position: initial initial; background-repeat: initial initial;">

<div>

<div>

import mysql.connector

</div>

<div>

cnx = mysql.connector.connect(user='scott', password='tiger',
host='127.0.0.1', database='employees')

</div>

</div>

</div>

<div>

\

</div>

<div>

使用MySQLConnection创建数据库连接

</div>

<div>

\

</div>

<div
style="-en-codeblock: true; box-sizing: border-box; padding: 8px; font-family: Monaco, Menlo, Consolas, &quot;Courier New&quot;, monospace; font-size: 12px; color: rgb(51, 51, 51); border-top-left-radius: 4px; border-top-right-radius: 4px; border-bottom-right-radius: 4px; border-bottom-left-radius: 4px; background-color: rgb(251, 250, 248); border: 1px solid rgba(0, 0, 0, 0.14902); background-position: initial initial; background-repeat: initial initial;">

<div>

<div>

from mysql.connector import (connection)

</div>

<div>

cnx = connection.MySQLConnection(user='scott', password='tiger',
 host='127.0.0.1', database='employees')

</div>

</div>

</div>

<div>

\

</div>

<div>

使用try语句捕捉异常

</div>

<div>

\

</div>

<div
style="-en-codeblock: true; box-sizing: border-box; padding: 8px; font-family: Monaco, Menlo, Consolas, &quot;Courier New&quot;, monospace; font-size: 12px; color: rgb(51, 51, 51); border-top-left-radius: 4px; border-top-right-radius: 4px; border-bottom-right-radius: 4px; border-bottom-left-radius: 4px; background-color: rgb(251, 250, 248); border: 1px solid rgba(0, 0, 0, 0.14902); background-position: initial initial; background-repeat: initial initial;">

<div>

<div>

import mysql.connectorfrom mysql.connector import errorcode

</div>

<div>

try:

</div>

<div>

    cnx = mysql.connector.connect(user='scott', database='testt')

</div>

<div>

except mysql.connector.Error as err:

</div>

<div>

    if err.errno == errorcode.ER\_ACCESS\_DENIED\_ERROR:

</div>

<div>

        print("Something is wrong with your user name or password")

</div>

<div>

    elif err.errno == errorcode.ER\_BAD\_DB\_ERROR:

</div>

<div>

        print("Database does not exist")

</div>

<div>

    else:    print(err)

</div>

<div>

else:  cnx.close()

</div>

</div>

</div>

<div>

\

</div>

<div>

使用配置参数连接数据库

</div>

<div>

\

</div>

<div
style="-en-codeblock: true; box-sizing: border-box; padding: 8px; font-family: Monaco, Menlo, Consolas, &quot;Courier New&quot;, monospace; font-size: 12px; color: rgb(51, 51, 51); border-top-left-radius: 4px; border-top-right-radius: 4px; border-bottom-right-radius: 4px; border-bottom-left-radius: 4px; background-color: rgb(251, 250, 248); border: 1px solid rgba(0, 0, 0, 0.14902); background-position: initial initial; background-repeat: initial initial;">

<div>

<div>

import mysql.connector

</div>

<div>

config = {

</div>

<div>

    'user': 'scott',

</div>

<div>

    'password': 'tiger',

</div>

<div>

    'host': '127.0.0.1',

</div>

<div>

    'database': 'employees',

</div>

<div>

    'raise\_on\_warnings': True,

</div>

<div>

}

</div>

<div>

cnx = mysql.connector.connect(\*\*config)

</div>

</div>

</div>

<div>

\

</div>

<div>

使用执行SQL语句

</div>

<div>

\

</div>

<div
style="-en-codeblock: true; box-sizing: border-box; padding: 8px; font-family: Monaco, Menlo, Consolas, &quot;Courier New&quot;, monospace; font-size: 12px; color: rgb(51, 51, 51); border-top-left-radius: 4px; border-top-right-radius: 4px; border-bottom-right-radius: 4px; border-bottom-left-radius: 4px; background-color: rgb(251, 250, 248); border: 1px solid rgba(0, 0, 0, 0.14902); background-position: initial initial; background-repeat: initial initial;">

<div>

<div>

cursor = cnx.cursor()

</div>

<div>

cursor.execute('''mysql statement''')

</div>

</div>

</div>

<div>

\

</div>

<div>

关闭数据库连接

</div>

<div>

\

</div>

<div
style="-en-codeblock: true; box-sizing: border-box; padding: 8px; font-family: Monaco, Menlo, Consolas, &quot;Courier New&quot;, monospace; font-size: 12px; color: rgb(51, 51, 51); border-top-left-radius: 4px; border-top-right-radius: 4px; border-bottom-right-radius: 4px; border-bottom-left-radius: 4px; background-color: rgb(251, 250, 248); border: 1px solid rgba(0, 0, 0, 0.14902); background-position: initial initial; background-repeat: initial initial;">

<div>

<div>

cursor.close()

</div>

<div>

cnx.close()

</div>

</div>

</div>

<div>

\

</div>

</div>
