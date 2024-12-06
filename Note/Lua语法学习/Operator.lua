--算术运算符
--+ - * / % ^
--没有自增++自减--
--没有复合运算符如+=
a=0 b=1
print(a+b)
--字符串如果可以转为number则可以参与运算
print("123.1"+1)
print(1/2)--0.5
print(2^3)--8 幂运算

--条件运算符
-- > < >= <= == ~=(不等于)
print(3~=1)

--逻辑运算符 
--and or not 对应 与 或 非 ps:Lua同样支持短路，前面为假则不执行后面的and操作
print(true and false)
print(not true)

--Lua不支持位运算，需要自己实现
--Lua同样不支持三目运算符