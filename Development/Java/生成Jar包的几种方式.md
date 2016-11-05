生成Jar包的几种方式
<div>

<div>

有下面一段HelloWorld.java的代码需要生成.jar文件，将文件按照包名放在com/wh/test目录下

</div>

<div>

\

</div>

<div
style="-en-codeblock: true; box-sizing: border-box; padding: 8px; font-family: Monaco, Menlo, Consolas, &quot;Courier New&quot;, monospace; font-size: 12px; color: rgb(51, 51, 51); border-top-left-radius: 4px; border-top-right-radius: 4px; border-bottom-right-radius: 4px; border-bottom-left-radius: 4px; background-color: rgb(251, 250, 248); border: 1px solid rgba(0, 0, 0, 0.14902); background-position: initial initial; background-repeat: initial initial;">

<div>

package com.wh.test;

</div>

<div>

\

</div>

<div>

public class HelloWorld {

</div>

<div>

    public static void main(String\[\] args) {

</div>

<div>

        System.out.println("Hello World");

</div>

<div>

    }

</div>

<div>

}

</div>

</div>

<div>

\

</div>

<div>

**命令行生成jar：**

</div>

<div>

\

</div>

<div>

创建src文件夹，将源文件包放在其中，创建build/classes文件夹存放编译后的.class文件，

</div>

<div>

运行javac
src/com/wh/test/HelloWorld.java就能生成HelloWorld.class放在源文件的目录下，

</div>

<div>

使用-d
build/classes指定输出文件夹，编译后会按照源文件的目录结构存放.class文件。

</div>

<div>

如果有多个java文件可以用javac src/com/wh/test/\*.java -d build/classes

</div>

<div>

如果多个java文件在不同目录下，可以新建sourcefiles文件将java文件路径列表添加进去
，然后运行javac @sourcefiles -d build/classes，在Linux下可以使用find
./src -name \*.java &gt; sourcefiles快速添加。

</div>

<div>

如果引用了用户自定义类或源文件时，默认将会在CLASSPATH环境变量中查找，可以使用-classpath或-cp选项指定查找路径，如果没有CLASSPATH且不使用-classpathhuo-cp选项，将在当前目录中查找。

</div>

<div>

如果使用了中文需要加上-encoding UTF-8选项。

</div>

<div>

\

</div>

<div>

将编译好的.class文件打包成jar，在classes目录下使用jar cvf classes.jar
com/wh/test/HelloWorld.class，

</div>

<div>

或者在当前目录中使用jar cvf classes.jar -C build/classes .    
//表示将build/classes中的所有文件归档到classes.jar中(注意空格后加点号表示)

</div>

<div>

如果要添加主类也就是有入口函数(main)的类则需要使用清单文件，创建manifest文件，并添加"Main-Class:
com.wh.test.HelloWorld"，

</div>

<div>

然后运行jar cvfm classes.jar manifest -C build/classes .    
//注意jar和manifest的顺序与fm选项相对应

</div>

<div>

也可以用-e选项指定入口函数。

</div>

<div>

使用xcf可以解压jar包。

</div>

<div>

\

</div>

<div>

\

</div>

<div>

**使用gradle生成jar：**

</div>

<div>

**\
**

</div>

<div>

新建一个文件夹做为工程文件夹，将代码文件放在在src/main/java中，依赖的包放在libs中，

</div>

<div>

新建build.gradle文件，添加

</div>

<div>

\

</div>

<div
style="-en-codeblock: true; box-sizing: border-box; padding: 8px; font-family: Monaco, Menlo, Consolas, &quot;Courier New&quot;, monospace; font-size: 12px; color: rgb(51, 51, 51); border-top-left-radius: 4px; border-top-right-radius: 4px; border-bottom-right-radius: 4px; border-bottom-left-radius: 4px; background-color: rgb(251, 250, 248); border: 1px solid rgba(0, 0, 0, 0.14902); background-position: initial initial; background-repeat: initial initial;">

<div>

//添加Java插件，如果其他使用默认的话只需要这行就能编译出jar包

</div>

<div>

apply plugin : 'java'

</div>

<div>

//需要添加的依赖

</div>

<div>

dependencies {

</div>

<div>

  compile fileTree(dir : 'libs', include : \['\*.jar' \])

</div>

<div>

}

</div>

<div>

//源文件和资源文件路径，默认为src/main/java和src/main/resources

</div>

<div>

sourceSets {

</div>

<div>

  main {

</div>

<div>

    java {

</div>

<div>

      srcDir 'src/main/java'

</div>

<div>

    }

</div>

<div>

    resources {

</div>

<div>

      srcDir 'src/main/resources'

</div>

<div>

    }

</div>

<div>

  }

</div>

<div>

}

</div>

<div>

//指定入口函数

</div>

<div>

jar {

</div>

<div>

  manifest {

</div>

<div>

    attributes(

</div>

<div>

      'Main-Class': 'com.wh.test.HelloWorld'

</div>

<div>

    )

</div>

<div>

  }

</div>

<div>

}

</div>

</div>

<div>

\

</div>

<div>

运行gradle
assembl或build，编译出的jar文件放在build/libs中，使用build将会对包进行测试

</div>

<div>

\

</div>

<div>

\

</div>

<div>

**使用ant生成jar：**

</div>

<div>

\

</div>

<div>

源文件包放在src文件夹中，创建build.xml文件，添加

</div>

<div>

\

</div>

<div
style="-en-codeblock: true; box-sizing: border-box; padding: 8px; font-family: Monaco, Menlo, Consolas, &quot;Courier New&quot;, monospace; font-size: 12px; color: rgb(51, 51, 51); border-top-left-radius: 4px; border-top-right-radius: 4px; border-bottom-right-radius: 4px; border-bottom-left-radius: 4px; background-color: rgb(251, 250, 248); border: 1px solid rgba(0, 0, 0, 0.14902); background-position: initial initial; background-repeat: initial initial;">

<div>

&lt;target name="jar"&gt;

</div>

<div>

  &lt;mkdir dir="build/classes"/&gt;

</div>

<div>

  /\*指定源文件路径和生成的.class文件路径\*/

</div>

<div>

  &lt;javac srcdir="src" basedir="build/classes"&gt;

</div>

<div>

  /\*指定输出的jar路径和需要的.class文件路径\*/

</div>

<div>

  &lt;jar destfile="bin/classes.jar" basedir="build/classes"&gt;

</div>

<div>

    /\*指定入口函数\*/

</div>

<div>

    &lt;manifest&gt;

</div>

<div>

      &lt;attribute name="Main-Class" value="com.wh.test.HelloWorld"
/&gt;

</div>

<div>

    &lt;/manifest&gt;

</div>

<div>

  &lt;/jar&gt;

</div>

<div>

&lt;/target&gt;

</div>

</div>

<div>

\

</div>

<div>

运行ant jar将编译出bin/classes.jar

</div>

<div>

\

</div>

<div>

类似的工具还有Maven

</div>

</div>
