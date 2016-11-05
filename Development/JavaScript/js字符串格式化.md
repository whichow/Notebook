<span>"{0},{1}".format("stringA", "stringB");</span>
<div>

<span
style="color: rgb(34, 34, 34); font-family: Consolas, Menlo, Monaco, 'Lucida Console', 'Liberation Mono', 'DejaVu Sans Mono', 'Bitstream Vera Sans Mono', 'Courier New', monospace, sans-serif; font-size: 13px; line-height: 16.9px; widows: 1; background-color: rgb(238, 238, 238);"></span>
``` {.default .prettyprint .prettyprinted style="margin-top: 0px; padding: 5px; border: 0px; font-size: 13px; overflow: auto; width: auto; max-height: 600px; font-family: Consolas, Menlo, Monaco, 'Lucida Console', 'Liberation Mono', 'DejaVu Sans Mono', 'Bitstream Vera Sans Mono', 'Courier New', monospace, sans-serif; color: rgb(57, 51, 24); word-wrap: normal; widows: 1; background-color: rgb(238, 238, 238);"}
String.prototype.format = function () {var args = [].slice.call(arguments);return this.replace(/(\{\d+\})/g, function (a){return args[+(a.substr(1,a.length-2))||0];});};
```

\
<div style="color:gray">

来源： &lt;<http://stackoverflow.com/questions/25227119/javascript-strings-format-is-not-defined>&gt;

</div>

 

</div>
