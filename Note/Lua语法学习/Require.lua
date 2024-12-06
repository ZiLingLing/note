--全局变量和本地变量
for i = 1, 5, 1 do
    c="全局变量";--c为全局变量
end
print(c)
for i = 1, 5, 1 do
    local d="局部变量";--c为局部变量
end
print(d)--这里输出为nil
local a=0
print(a)
--多脚本执行
--关键字require requier("脚本名") 通过这个可以执行其他脚本的内容
require("Hello Lua")--任何通过require执行过的脚本都可以使用其中的全局变量
print(str)
print(localstr)
--脚本卸载
require("Hello Lua")--脚本只会加载一次，再次加载不会执行
print(package.loaded['Hello Lua'])--返回值是boolean，得到该脚本是否被执行过
package.loaded['Hello Lua']=nil--脚本卸载
local e=require("Hello Lua")--卸载后再次加载
print(e)
--可以在脚本中把局部变量return出去，在外部接收，就可以使用它
--大G表 固定写法 _G 是一个总表，将所有声明的全局变量都存储在其中,局部变量不存入其中
for key, value in pairs(_G) do
    print(key,value)
end