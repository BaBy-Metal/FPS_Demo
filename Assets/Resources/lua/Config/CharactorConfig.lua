--角色数据
local CharactorConfig=Glob.lplus.class(Glob.ConfigBase)

function CharactorConfig:Init()
    self.msg=Glob.Read("RoleMsg")
    if self.msg==nil then
        local a=function ()
            local c={Glob.CharactorData.new("AAA","攻坚干员","1001","nan1","prefab1"),Glob.CharactorData.new("BBB","火力干员","1002","nan4","prefab2"),Glob.CharactorData.new("CCC","医疗干员","1003","nv1","prefab3")}
            Debug.Log(c[1])
            return c
        end

        self.msg=a()
        Debug.Log(self.msg[1].name)
        Glob.Write("RoleMsg",self.msg)
    end

    local c=self.msg
    Debug.Log(c[1].name)
    return c
end

function CharactorConfig:SetMsg(...)
    self.msg[#self.msg+1]=Glob.CharactorData.new(...)
end

return CharactorConfig