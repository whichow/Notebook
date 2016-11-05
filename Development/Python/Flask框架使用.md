<div>

<div>

安装Flask

</div>

<div>

\

</div>

<div
style="-en-codeblock: true; box-sizing: border-box; padding: 8px; font-family: Monaco, Menlo, Consolas, &quot;Courier New&quot;, monospace; font-size: 12px; color: rgb(51, 51, 51); border-top-left-radius: 4px; border-top-right-radius: 4px; border-bottom-right-radius: 4px; border-bottom-left-radius: 4px; background-color: rgb(251, 250, 248); border: 1px solid rgba(0, 0, 0, 0.14902); background-position: initial initial; background-repeat: initial initial;">

<div>

<div>

pip install flask

</div>

</div>

</div>

<div>

\

</div>

<div>

hello.py

</div>

<div>

\

</div>

<div
style="-en-codeblock: true; box-sizing: border-box; padding: 8px; font-family: Monaco, Menlo, Consolas, &quot;Courier New&quot;, monospace; font-size: 12px; color: rgb(51, 51, 51); border-top-left-radius: 4px; border-top-right-radius: 4px; border-bottom-right-radius: 4px; border-bottom-left-radius: 4px; background-color: rgb(251, 250, 248); border: 1px solid rgba(0, 0, 0, 0.14902); background-position: initial initial; background-repeat: initial initial;">

<div>

from flask import Flask

</div>

<div>

app = Flask(\_\_name\_\_)

</div>

<div>

\

</div>

<div>

@app.route('/')

</div>

<div>

def hello\_world():

</div>

<div>

    return 'Hello, World!'

</div>

</div>

<div>

\

</div>

<div
style="-en-codeblock: true; box-sizing: border-box; padding: 8px; font-family: Monaco, Menlo, Consolas, &quot;Courier New&quot;, monospace; font-size: 12px; color: rgb(51, 51, 51); border-top-left-radius: 4px; border-top-right-radius: 4px; border-bottom-right-radius: 4px; border-bottom-left-radius: 4px; background-color: rgb(251, 250, 248); border: 1px solid rgba(0, 0, 0, 0.14902); background-position: initial initial; background-repeat: initial initial;">

<div>

\$ export FLASK\_APP=hello.py

</div>

<div>

\$ flask run

</div>

<div>

 \* Running on http://127.0.0.1:5000/

</div>

</div>

<div>

\

</div>

<div>

------------------------------------------------------------------------

更新，还可以用这种方式运行：

</div>

<div>

hello.py

</div>

<div>

<div>

``` {.prettyprint .linenums .prettyprinted}
from flask import Flaskapp = Flask(__name__)@app.route("/")def hello():    return "Hello World!"if __name__ == "__main__":    app.run()
```

</div>

<div>

运行

</div>

</div>

<div>

<div>

``` {.prettyprint .linenums .prettyprinted}
$ python hello.py * Running on http://localhost:5000/
```

</div>

<div>

------------------------------------------------------------------------

</div>

</div>

<div>

默认运行在本机，要运行在服务器上使得可以从外网访问到

</div>

<div>

\

</div>

<div
style="-en-codeblock: true; box-sizing: border-box; padding: 8px; font-family: Monaco, Menlo, Consolas, &quot;Courier New&quot;, monospace; font-size: 12px; color: rgb(51, 51, 51); border-top-left-radius: 4px; border-top-right-radius: 4px; border-bottom-right-radius: 4px; border-bottom-left-radius: 4px; background-color: rgb(251, 250, 248); border: 1px solid rgba(0, 0, 0, 0.14902); background-position: initial initial; background-repeat: initial initial;">

<div>

flask run --host=0.0.0.0

</div>

</div>

<div>

\

</div>

<div>

运行在其他端口

</div>

<div>

<div>

``` {.prettyprint .linenums .prettyprinted}
if __name__ == '__main__':      app.run(host='0.0.0.0', port=8000)
```

</div>

<div>

<span style="line-height: 1.6;">调试模式</span>\

</div>

</div>

<div>

\

</div>

<div
style="-en-codeblock: true; box-sizing: border-box; padding: 8px; font-family: Monaco, Menlo, Consolas, &quot;Courier New&quot;, monospace; font-size: 12px; color: rgb(51, 51, 51); border-top-left-radius: 4px; border-top-right-radius: 4px; border-bottom-right-radius: 4px; border-bottom-left-radius: 4px; background-color: rgb(251, 250, 248); border: 1px solid rgba(0, 0, 0, 0.14902); background-position: initial initial; background-repeat: initial initial;">

<div>

\$ export FLASK\_DEBUG=1

</div>

<div>

\$ flask run

</div>

</div>

<div>

\

</div>

<div>

http方法

</div>

<div>

\

</div>

<div
style="-en-codeblock: true; box-sizing: border-box; padding: 8px; font-family: Monaco, Menlo, Consolas, &quot;Courier New&quot;, monospace; font-size: 12px; color: rgb(51, 51, 51); border-top-left-radius: 4px; border-top-right-radius: 4px; border-bottom-right-radius: 4px; border-bottom-left-radius: 4px; background-color: rgb(251, 250, 248); border: 1px solid rgba(0, 0, 0, 0.14902); background-position: initial initial; background-repeat: initial initial;">

<div>

from flask import request

</div>

<div>

\

</div>

<div>

@app.route('/login', methods=\['GET', 'POST'\])def login():

</div>

<div>

    if request.method == 'POST':

</div>

<div>

        do\_the\_login()

</div>

<div>

    else:

</div>

<div>

        show\_the\_login\_form()

</div>

</div>

<div>

\

</div>

<div>

访问MySQL

</div>

<div>

\

</div>

<div>

安装 Flask-MySQLdb

</div>

<div>

\

</div>

<div
style="-en-codeblock: true; box-sizing: border-box; padding: 8px; font-family: Monaco, Menlo, Consolas, &quot;Courier New&quot;, monospace; font-size: 12px; color: rgb(51, 51, 51); border-top-left-radius: 4px; border-top-right-radius: 4px; border-bottom-right-radius: 4px; border-bottom-left-radius: 4px; background-color: rgb(251, 250, 248); border: 1px solid rgba(0, 0, 0, 0.14902); background-position: initial initial; background-repeat: initial initial;">

<div>

\$pip install flask-mysqldb

</div>

</div>

<div>

\

</div>

<div>

如果安装不了先安装mysqlclient和pymysql

</div>

<div>

\

</div>

<div
style="-en-codeblock: true; box-sizing: border-box; padding: 8px; font-family: Monaco, Menlo, Consolas, &quot;Courier New&quot;, monospace; font-size: 12px; color: rgb(51, 51, 51); border-top-left-radius: 4px; border-top-right-radius: 4px; border-bottom-right-radius: 4px; border-bottom-left-radius: 4px; background-color: rgb(251, 250, 248); border: 1px solid rgba(0, 0, 0, 0.14902); background-position: initial initial; background-repeat: initial initial;">

<div>

pip install mysqlclient

</div>

<div>

pip install pymysql

</div>

</div>

<div>

\

</div>

<div>

mysql.py

</div>

<div>

\

</div>

<div
style="-en-codeblock: true; box-sizing: border-box; padding: 8px; font-family: Monaco, Menlo, Consolas, &quot;Courier New&quot;, monospace; font-size: 12px; color: rgb(51, 51, 51); border-top-left-radius: 4px; border-top-right-radius: 4px; border-bottom-right-radius: 4px; border-bottom-left-radius: 4px; background-color: rgb(251, 250, 248); border: 1px solid rgba(0, 0, 0, 0.14902); background-position: initial initial; background-repeat: initial initial;">

<div>

from flask import Flask

</div>

<div>

from flask\_mysqldb import MySQL

</div>

<div>

\

</div>

<div>

app = Flask(\_\_name\_\_)

</div>

<div>

\#配置数据库

</div>

<div>

app.config\['MYSQL\_USER'\] = 'root'

</div>

<div>

app.config\['MYSQL\_PASSWORD'\] = 'password'

</div>

<div>

app.config\['MYSQL\_DB'\] = 'test'

</div>

<div>

\

</div>

<div>

mysql = MySQL(app)

</div>

<div>

\

</div>

<div>

@app.route('/')

</div>

<div>

def users():

</div>

<div>

    cur = mysql.connection.cursor()

</div>

<div>

    cur.execute('select \* from user')

</div>

<div>

    rv = cur.fetchall()

</div>

<div>

    return str(rv)

</div>

</div>

<div>

\

</div>

</div>
