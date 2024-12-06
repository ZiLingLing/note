--函数也是一种变量类型
--函数可以有多个返回值
--function 函数名()...end
--a = function ()...end

function f1()
    print("f1")
end
f1()

f2=function ()
    print("f2")
end
f2()

f3=function (a)
    print(a)
end
f3(1)
f3("123"*2)
f3(true)
f3()--默认输入的是nil
f3(1,2,3)--传入参数和参数个数不匹配，则只会补空或者报错

f4=function (a)
    return a
end
temp=f4(2)
print(temp)

f5=function (a)
    return a,"123",true
end
t1,t2,t3,t4=f5(3)--多返回值声明多个变量接取，变量不够也不影响接取对应位置返回值
print(t1) print(t2) print(t3) print(t4)

--函数的类型
f6=function ()
    print(1)
end
print(type(f6))--function

--函数重载 Lua不支持函数重载
f6=function (a)
    return 1
end
print(f6())

--变长参数
function  f7(...)
    arg={...}--变长参数使用一个表存起来 才能使用
    for i = 1, #arg do
        print(arg[i])
    end
end
f7("1",2,nil,true)

--函数嵌套 闭包在Lua中的体现就是函数嵌套
function f8()
    f9=function ()
        print(123)
    end
    return f9()
end
res=f8()
f9()