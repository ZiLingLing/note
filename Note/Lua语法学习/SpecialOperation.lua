--多变量赋值
local a,b,c=1,2,3
print("a:"..a.." b:"..b.." c:"..c)
local a,b,c=1,2--少赋值补nil,多赋值则忽略
print(c)
--多返回值
f1=function ()
    return 10,20,30,40
end
a,b,c,d,e=f1()
print(c)
print(d)
print(e)
--逻辑与和逻辑或
--and和or不知可以连接boolean,还可以连接任何东西
--在lua中只有nil和false才被认为是假
--对and有假则假，对or有真则真
print(0 and 1)
print(nil and 1)
--模拟三目运算符
x,y=2,3
local res= x>y and x or y
print(res)