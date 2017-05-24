1.直接遍历
```lua
local len = array.Length

for i = 0, len - 1 do
    print('Array: '..tostring(array[i]))
end
```
2.转成table再遍历
```lua
local t = array:ToTable()                

for i = 1, #t do
    print('table: '.. tostring(t[i]))
end
```
3.使用迭代器遍历
```lua
local iter = array:GetEnumerator()

while iter:MoveNext() do
    print('iter: '..iter.Current)
end           
```