test={id=1,name="312132"}
print(collectgarbage("count"))--得到具体的内存占用字节数

collectgarbage("collect")--进行一次垃圾回收
print(collectgarbage("count"))
test=nil
collectgarbage("collect")
print(collectgarbage("count"))