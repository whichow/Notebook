<div>

\

</div>

<div>

<div>

``` {.prettyprint .linenums .prettyprinted}
void OnGUI(){    GUIStyle myStyle = new GUIStyle();    myStyle.fontSize = 50;    myStyle.normal.textColor = Color.red;    GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 25, 200, 50), "Hello World", myStyle);}
```

</div>

<div>

还可以通过GUI类设置全局的颜色

</div>

</div>

<div>

<div>

``` {.prettyprint .linenums .prettyprinted}
GUI.color = Color.red;GUI.backgroundColor = Color.black;
```

</div>

<div>

\

</div>

</div>

<div>

\

</div>
