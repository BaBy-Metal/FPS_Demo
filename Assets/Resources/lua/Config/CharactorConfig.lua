local CharactorConfig=Glob.lplus.class(Glob.ConfigBase)

function CharactorConfig:Init()
    self.msg=Glob.Read("RoleMsg")
    if self.msg==nil then
        local a=function ()
            local c={Glob.CharactorData.new("AAA","战士","1",""),Glob.CharactorData.new("BBB","法师","2"),Glob.CharactorData.new("CCC","射手","3")}
            Debug.Log(c[1])
            return c
        end

        self.msg=a()
        Debug.Log(self.msg[1].name)
        Glob.Write("data",self.msg)
    end

    local c=self.msg
    Debug.Log(c["name"])
    return c
end

return CharactorConfig