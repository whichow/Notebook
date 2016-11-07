安装Flask

pip install flask

hello.py

from flask import Flask

app = Flask(\_\_name\_\_)

@app.route('/')

def hello\_world():

    return 'Hello, World!'

$ export FLASK\_APP=hello.py

$ flask run

 \* Running on http://127.0.0.1:5000/

------------------------------------------------------------------------

更新，还可以用这种方式运行：

hello.py

``` prettyprint
from flask import Flaskapp = Flask(__name__)@app.route("/")def hello():    return "Hello World!"if __name__ == "__main__":    app.run()
```

运行

``` prettyprint
$ python hello.py * Running on http://localhost:5000/
```

------------------------------------------------------------------------

默认运行在本机，要运行在服务器上使得可以从外网访问到

flask run --host=0.0.0.0

运行在其他端口

``` prettyprint
if __name__ == '__main__':      app.run(host='0.0.0.0', port=8000)
```

调试模式

$ export FLASK\_DEBUG=1

$ flask run

http方法

from flask import request

@app.route('/login', methods=\['GET', 'POST'\])def login():

    if request.method == 'POST':

        do\_the\_login()

    else:

        show\_the\_login\_form()

访问MySQL

安装 Flask-MySQLdb

$pip install flask-mysqldb

如果安装不了先安装mysqlclient和pymysql

pip install mysqlclient

pip install pymysql

mysql.py

from flask import Flask

from flask\_mysqldb import MySQL

app = Flask(\_\_name\_\_)

\#配置数据库

app.config\['MYSQL\_USER'\] = 'root'

app.config\['MYSQL\_PASSWORD'\] = 'password'

app.config\['MYSQL\_DB'\] = 'test'

mysql = MySQL(app)

@app.route('/')

def users():

    cur = mysql.connection.cursor()

    cur.execute('select \* from user')

    rv = cur.fetchall()

    return str(rv)


