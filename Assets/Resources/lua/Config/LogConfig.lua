local LogConfig=Glob.lplus.class(Glob.ConfigBase)

function LogConfig:Init()
    self.msg=Glob.Read("data")
    if self.msg==nil then
        local a=function ()
            local c={Glob.LogClass.new("cth","123"),Glob.LogClass.new("chen","123456"),Glob.LogClass.new("321","111")}
            Debug.Log(c[1])
            return c
        end
        self.msg=a()
        Debug.Log(self.msg[1].name)
        Glob.Write("data",self.msg)
    end

    local c=self.msg
    Debug.Log(c[1].name)
    return c
end

return LogConfig