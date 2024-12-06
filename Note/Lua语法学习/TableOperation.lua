--表的公共操作
t1={{age=1,name="123"},{age=2,name="234"}}
t2={name="张三",sex="男"}
--插入
print("插入前长度"..#t1)
--table.insert(t1,t2)
table.insert(t1,1,t2)
print("插入后长度"..#t1.."    "..#t2)
for key, value in pairs(t1) do
    for key, value in pairs(t1[key]) do
        print(key,value)
    end
end
--删除 传入一个参数默认移除最后一个，传入则移除指定位置的
table.remove(t1,1)
print(#t1)
--排序,默认升序
t3={5,12,5,1,2,123.3}
table.sort(t3)
print("**********升序************")
for key, value in pairs(t3) do
    print(value)
end
table.sort(t3,function (a,b)
    if a>b then
        return true
    end
end)
print("***********降序**************")
for key, value in pairs(t3) do
    print(value)
end
--拼接 第一个参数是表，第二个参数用于拼接表中元素 返回字符串
t4={"123","456","789"}
print(table.concat(t4,"*"))
