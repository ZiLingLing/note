--自带库
--string
--table

--时间相关
print(os.time())--系统时间
print(os.time({year=2024,month=6,day=13}))--自己传入参数得到时间
--os.date("*t")
local now=os.date("*t")
for key, value in pairs(now) do
    print(key,value)
end
print(now.hour)--还有其他的如second等

--数学运算
print(math.abs(-11))--绝对值
print(math.deg(math.pi))--弧度转角度
print(math.cos(math.pi))--三角函数
--取整
print(math.floor(2.6))--向下
print(math.ceil(2.6))--向上
--最值
print(math.max(1,2))
print(math.min(4,5))

print(math.modf(3.14))--整数小数分离
print(math.pow(2,5))--幂运算，但已经废弃，由^代替了

--随机数
math.randomseed(os.time())--随机数种子，但是第一个随机出来的都是一样的，除非种子不一样
print(math.random(100))
print(math.random(100))

print(math.sqrt(4))--开方

--路径相关
print(package.path)--lua脚本加载路径，环境变量