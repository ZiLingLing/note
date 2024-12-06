--面向对象基于表
--封装
Object={}
Object.id=1
--实现一个实例化方法，相当于实现new
function Object:new()
    local obj={}
    --结合元表的相关只是
    self.__index=self
    setmetatable(obj,self)
    return obj
end

function Object:Test()
    print(self.id)
end

local myobj=Object:new()
print(myobj.id)
--赋值相当于在当前的表赋值一个新的变量
myobj.id=2
print(myobj.id)--2
print(Object.id)--1
myobj:Test()--哪个表调用，哪个表就是传进去的self

--继承
--继承使用了_G的特性
function Object:subClass(className)
    _G[className]={}
    --继承 
    local obj=_G[className]
    self.__index=self
    --定义一个base属性,记录父类，能通过base调用父类的方法
    obj.base=self
    setmetatable(obj,self)
end
Object:subClass("Person")
p1=Person:new()--p1的元表是Person
print("p1的id  "..p1.id)--实际上嵌套输出的是Object中的id

--多态
--相同行为 不同表现 多态
--相同方法 执行不同逻辑
Object:subClass("GameObject")
--_G["GameObject"].posX=0
--_G["GameObject"].posY=0
GameObject.posX=0
GameObject.posY=0
function GameObject:Move()
    self.posX=self.posX+1
    self.posY=self.posY+1
    print(self.posX,self.posY)
end

GameObject:subClass("Player")
function Player:Move()
    --这种方式调用相当于把基类表作为第一个参数传入了方法中
    --这里的self.base相当于是用GameObject在调用
    --self.base:Move()
    --正确的做法是避免把基类表传入到方法中 如果把基类表传入相当于公用一张表的属性了
    --因此不能使用冒号调用，而要用点调用自己传入第一个参数
    self.base.Move(self)
end
--这样的写法有错，因为实际上p1,p2都是共用的一个posX和posY
local p1=Player:new()
p1:Move()
local p2=Player:new()
p2:Move()