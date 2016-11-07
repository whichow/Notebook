Python使用MySQL
使用connect构造器创建MySQL数据库连接，返回一个MySQLConnection对象

import mysql.connector

cnx = mysql.connector.connect(user='scott', password='tiger', host='127.0.0.1', database='employees')

使用MySQLConnection创建数据库连接

from mysql.connector import (connection)

cnx = connection.MySQLConnection(user='scott', password='tiger',  host='127.0.0.1', database='employees')

使用try语句捕捉异常

import mysql.connectorfrom mysql.connector import errorcode

try:

    cnx = mysql.connector.connect(user='scott', database='testt')

except mysql.connector.Error as err:

    if err.errno == errorcode.ER\_ACCESS\_DENIED\_ERROR:

        print("Something is wrong with your user name or password")

    elif err.errno == errorcode.ER\_BAD\_DB\_ERROR:

        print("Database does not exist")

    else:    print(err)

else:  cnx.close()

使用配置参数连接数据库

import mysql.connector

config = {

    'user': 'scott',

    'password': 'tiger',

    'host': '127.0.0.1',

    'database': 'employees',

    'raise\_on\_warnings': True,

}

cnx = mysql.connector.connect(\*\*config)

使用执行SQL语句

cursor = cnx.cursor()

cursor.execute('''mysql statement''')

关闭数据库连接

cursor.close()

cnx.close()


