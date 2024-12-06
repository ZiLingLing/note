--类的本质也是表
--lua中默认没有面向对象，需要自己实现
--只是用表来表现类和结构体
--成员变量，成员函数
Students={
    age=24,
    sex="男",

    Up=function ()
        --函数中的age实际上和表中的age没有任何关系
        --需要指定age，即表名点键，这是方法1
        Students.age=Students.age+1
        print("当前年纪")
        print(Students.age)
        return Students.age
    end,

    Learn=function (t)
        --第二种在内部调用自己属性的方法是把自己作为一个参数传进来在内部访问
        print(t.age)
        print("学习，学个屁！")
    end
}
--[[
    -使用这个实现的类，因为lua中没有new也没有实例化，
    所以可以看作是静态类和静态函数
]]
--修改直接点出来，声明新的字段和函数也是这么做
Students.name="仙贝"
Students.Speak=function ()
    print("哼哼哼，啊啊啊啊啊！")
end
Students.Speak2=function (t)
    --lua中在使用冒号时有一个关键字self表示默认传入的第一个参数
    print(t.sex)
    print("说话")
end
Students.Up()
Students.Speak()
--第三种访问方法是Lua的语法糖
--冒号调用方法会默认把调用者作为第一个参数传入方法中
print("***********语法糖********")
Students:Learn()
Students.Learn(Students)
Students:Speak2()