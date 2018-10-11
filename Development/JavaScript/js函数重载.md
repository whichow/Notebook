JavaScript从严格意义上来说是没有函数重载的。函数重载需要同名的两个函数的签名（参数类型和数量）不同，而JavaScript没有函数签名，因为其参数是由包含零或多个值的数组来表示的。

JavaScript要实现类似函数重载的功能有下面几种方式：
1. 通过检查参数的类型和数量来做出不同的反应
```js
function fun() {
    if(arguments.length == 0) {
        //do something
    }
    else if(arguments.length == 1) {
        if(type arguments[0] == "Number") {
            //do something
        }
        else if(type arguments[0] == "String") {
            //do something
        }
    }
    else if(arguments.length == 2) {
        if(type arguments[0] == "Number" && type arguments[1] == "Boolean") {
            //do something
        }
    }
}
```
2. 利用JS闭包特性
```js
//addMethod
function addMethod(object, name, fn) {
　　var old = object[name];
　　object[name] = function() {
　　　　if(fn.length === arguments.length) {
　　　　　　return fn.apply(this, arguments);
　　　　} else if(typeof old === "function") {
　　　　　　return old.apply(this, arguments);
　　　　}
　　}
}
 
 
var people = {
　　values: ["Dean Edwards", "Alex Russell", "Dean Tom"]
};
 
/* 下面开始通过addMethod来实现对people.find方法的重载 */
 
// 不传参数时，返回peopld.values里面的所有元素
addMethod(people, "find", function() {
　　return this.values;
});
 
// 传一个参数时，按first-name的匹配进行返回
addMethod(people, "find", function(firstName) {
　　var ret = [];
　　for(var i = 0; i < this.values.length; i++) {
　　　　if(this.values[i].indexOf(firstName) === 0) {
　　　　　　ret.push(this.values[i]);
　　　　}
　　}
　　return ret;
});
 
// 传两个参数时，返回first-name和last-name都匹配的元素
addMethod(people, "find", function(firstName, lastName) {
　　var ret = [];
　　for(var i = 0; i < this.values.length; i++) {
　　　　if(this.values[i] === (firstName + " " + lastName)) {
　　　　　　ret.push(this.values[i]);
　　　　}
　　}
　　return ret;
});
```

[浅谈JavaScript函数重载](https://www.cnblogs.com/yugege/p/5539020.html)  
JavaScript高级程序设计（第3版）3.7.2 没有重载