local LogConfig=Glob.lplus.class(Glob.ConfigBase)

function LogConfig:Init()
    self.msg=Glob.Read("data")
    if self.msg==nil then
        local a=function ()
            local LogClass = Glob.lplus.class()
            LogClass.ctor=function (name,pwd)
                self.name=name
                self.pwd=pwd
            end

            local c={LogClass.new("cth","123"),LogClass.new("chen","123456"),LogClass.new("321","111")}
            Debug.Log(c[1].name)
            return c
        end
        self.msg=a()
        print(self.msg[1])
        Glob.Write("data",self.msg)
    end

    return self.msg
end

return LogConfig