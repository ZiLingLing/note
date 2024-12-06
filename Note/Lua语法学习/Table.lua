--table也是一种数据类型，数组、二维数组、字典本质上都是table
--数组以及数组遍历，本质上是表
a={1,"123",true,nil,12.1}
b={1,"2",nil,3,4,nil}
print(a[4])
print(#a)--获取数组长度
print(#b)--若数组最后一个元素为nil则输出长度只会到第一个nil之前的长度
for i = 1, #a, 1 do
    print(a[i])
end
--二维数组的形式，但是实际是表的嵌套
a={{1,2,3},{4,5,6}}
print(#a)
print(#a[1])
print(a[2][1])
for i = 1, #a, 1 do
    b=a[i]
    for j = 1, #b, 1 do
        print(b[j])
    end
end
--自定义索引
a2={[0]=1,2,3,[-1]=4,5}--实际上2，3，5在空间中紧挨着
print(a2[-1])
print(#a2)--#获取数组长度只是下标从1开始到最后
a3={1,2,[4]=4,[5]=5}--若中间漏了一个下标，实际输出长度只到断的下标之前
a4={1,2,[5]=5,[6]=6}
print(#a3) print(#a4)
for i = 1, #a3, 1 do
    print(a3[i])
end
--迭代器遍历表
print("*********迭代器主要用来遍历表***********")
--因为#得到的长度不一定准确，所以一般不用#遍历表
--ipairs迭代器,其实还是从下标为1的位置开始遍历，中间断点后得不到，小于等于0下标得不到
for index, value in ipairs(a3) do
    print("ipairs遍历键值"..index.."_"..value)
end
--pairs迭代器,能够遍历得到所有的键和所有的值
for key, value in pairs(a3) do
    print("pairs遍历键值"..key.."_"..value)
end
print("********table实现字典***********")
--自定义索引实现字典,键尽量不要使用汉字，因为如果不支持Unicode编码则无法点出来
dic1={["名字"]="张三",["age"]=24,["职业"]="学生",["field"]=114514}
--字典元素的访问
print(dic1["名字"])
print(dic1.age)
--字典元素的修改和添加和删除
dic1["名字"]="野兽先辈"
print(dic1["名字"])
dic1["sex"]="男"
print(dic1["sex"])
dic1["sex"]=nil--删除直接置为nil
print(dic1["sex"])
--遍历字典用pairs
for key, value in pairs(dic1) do
    print(key,value)
end
for key in pairs(dic1) do--可以直接遍历键，但不可以只遍历值
    print(key,dic1[key])
end