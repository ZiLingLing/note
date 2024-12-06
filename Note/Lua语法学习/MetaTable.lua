--元表概念
--任何表变量都可以作为另一个表变量的元表
--任何表变量都可以由自己的表变量
--在有元表的表中进行一些 特定操作 时会执行元表中的内容

--设置元表
local meta={}
local myt={}
--设置元表参数
setmetatable(myt,meta)--第一个是表，第二个是元表
print(myt)
--元表特定操作
meta2={
    __tostring=function ()--子表要被当字符串使用时，默认调用这个元表的__tostring方法
        return "__tostring方法"
    end,
    __call=function (a,b)
        print(a)--这个a其实是这个子表本身,传入的是子表
        --print(b)--第二个开始才是传入的参数
        print("子表被当一个函数调用时会使用__call")
    end,
    __add=function (t1,t2)--相当于运算符重载+
        return t1.age+t2.age
    end,
    __sub=function (t1,t2)-- 减号重载
        return t1.age-t2.age
    end,
    __mul=function ()-- *
        
    end,
    __div=function ()-- /
        
    end,
    __mod=function ()-- %
        
    end,
    __pow=function ()-- ^
        
    end,
    __eq=function ()-- ==
        
    end,
    __lt=function ()-- <
        
    end,
    __le=function ()-- <=
        
    end,--没有大于、大于等于、不等于
    __concat=function (t1,t2)--拼接
        return "拼接"
    end,
    __index=function ()
        print("当子表中找不到某个属性时，会到__index指向的表中去找")
    end,
    __newindex=function ()
        --当赋值时如果赋值一个不存在的索引，则会把这个值赋值到newindex所指的表中而不修改自己
        print("指向的表没有就嵌套找，最后还是没有就报错")
    end
}
myt2={
    name="表2",
    age=1;
}
myt3={
    name='表3',
    age=2
}
setmetatable(myt2,meta2)
print(myt2)
myt2(2)
print(myt2+myt3.."  运算符重载加号")
print(myt2..myt3)
--用条件运算符时，两个元表一定要有一致的结构，否则会不准

-- __index和__newIndex的作用
meta2.__index=myt2--__index要在表外面初始化，且可以嵌套往上找，直到找到或者找不到为nil
myt4={}
setmetatable(myt4,meta2)
print(myt4.age)
meta2.__newindex=myt2
myt4.age=114514
print(myt4.age)
print(myt2.age)
print(myt4.age)

--获取元表
print(getmetatable(myt4))
--rawget 使用它时，回去找自己身上有没有这个变量，而不会去找元表的变量
print(rawget(myt4,"age"))
--rawset会忽略newindex的设置，只改自己的变量,即在有newindex的情况下为自己插入新的变量
rawset(myt4,"age",2024)
print(myt4.age)