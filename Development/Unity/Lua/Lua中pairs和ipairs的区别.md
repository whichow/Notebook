pairs会遍历表中所有的key-value值，而pairs会根据key的数值从1开始加1递增遍历对应的table[i]值，直到出现第一个不是按1递增的数值时候退出。

```lua
stars = {[1] = "Sun", [2] = "Moon", [5] = 'Earth'}

for i, v in pairs(stars) do

   print(i, v)

end
```
使用pairs()将会遍历表中所有的数据，输出结果是：

1    Sun
2    Moon
5    Earth

如果使用ipairs（）的话，
```lua
for i, v in ipairs(stars) do

   print(i, v)

end
```
当i的值遍历到第三个元素时，i的值为5，此时i并不是上一个次i值（2）的+1递增，所以遍历结束，结果则会是：

1    Sun
2    Moon

还有一个要注意的是pairs()的一个问题，用pairs()遍历是[key]-[value]形式的表是随机的，跟key的哈希值有关系
```lua
stars = {[1] = "Sun", [2] = "Moon", [3] = "Earth", [4] = "Mars", [5] = "Venus"}

for i, v in pairs(stars) do

   print(i, v)

end
```
结果是：

2    Moon
3    Earth
1    Sun
4    Mars
5    Venus

---

tbl = {"alpha", "beta", ["one"] = "uno", ["two"] = "dos"}

for key, value in ipairs(tbl) do

print(key, value)

end

--pairs()

--pairs()函数基本和ipairs()函数用法相同, 区别在于pairs()可以遍历整个table, 即包括数组及非数组部分.

-->如有pairs迭代输出如下：

-->1 alpha

-->2 beta

-->one uno

-->two dos

-->如有ipairs迭代输出如下：

--ipairs()

--ipairs()函数用于遍历table中的数组部分.

-->1 alpha

-->2 beta