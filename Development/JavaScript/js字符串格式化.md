"{0},{1}".format("stringA", "stringB");
``` default
String.prototype.format = function () {var args = [].slice.call(arguments);return this.replace(/(\{\d+\})/g, function (a){return args[+(a.substr(1,a.length-2))||0];});};
```

来源： &lt;<http://stackoverflow.com/questions/25227119/javascript-strings-format-is-not-defined>&gt;

 
