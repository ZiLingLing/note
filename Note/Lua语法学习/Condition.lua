--条件分支语句 if 条件 then...(else(if))...end
a=1
if a>=3 then
    print(a)
elseif a==0 then
    print(0)
else
    print(-a)
end
--Lua中没有switch操作，需要自己实现