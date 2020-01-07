local ServerConfig=Glob.lplus.class(Glob.ConfigBase)

function ServerConfig:Init()
    self.msg=Glob.Read("serverData")
    if self.msg==nil then
        local a=function ()
            local c={Glob.ServerData.new("1","上地"),Glob.ServerData.new("2","西二旗"),Glob.ServerData.new("2","回龙观"),Glob.ServerData.new("1","西三旗"),Glob.ServerData.new("2","朝阳区"),Glob.ServerData.new("1","北京南站")}
            return c
        end
        self.msg=a()
        Debug.Log(self.msg[1].name)
        Glob.Write("serverData",self.msg)
    end

    local c=self.msg
    Debug.Log(c[1].name)
    return c
end

return ServerConfig