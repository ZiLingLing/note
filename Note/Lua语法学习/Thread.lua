--协程的创建
local f1=function ()
    print("执行函数f1")
end
c1=coroutine.create(f1)
print(c1)
print(type(c1))--thread

c2=coroutine.wrap(f1)
print(c2)
print(type(c2))--function
--协程的运行
print("create创建") coroutine.resume(c1)--create创建的协程的执行
print("wrap创建") c2()--函数创建的协程执行
--协程的挂起
f2=function ()
    local i=1
    while i<10 do
        print(i)
        print(coroutine.status(c3))
        i=i+1
        coroutine.yield(i)--挂起，挂起后下次执行是继续执行
    end
end
c3=coroutine.create(f2)
temp1,temp2=coroutine.resume(c3)--协程返回第一个参数是是否重启成功,第二个是yield括号中的值
print(temp1,temp2)
temp1,temp2=coroutine.resume(c3)
print(temp1,temp2)
c4=coroutine.wrap(f2)
print("返回值"..c4())--直接打印不会返回boolean
c4()
--协程的状态
--coroutine.status(协程对象)
--dead结束
--suspended结束
--running执行中
print(coroutine.status(c3))
--得到当前正在运行的协程的编号
print(coroutine.running())--没有任何正在运行的返回nil,必须在协程内部打印才能得到