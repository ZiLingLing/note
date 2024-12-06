--while循环 while 条件 do...end
num=10
while num>=5 do
    print(num)
    num=num-1
end
--do while循环 repeat...until 结束条件
num=0
repeat
    print(num)
    num=num+1
until num>5
--for循环 for 循环范围,增量 do 不写增量默认加1
for i=0,4 do
    print(i)
end
for i=1,10,2  do
    print(i)
end