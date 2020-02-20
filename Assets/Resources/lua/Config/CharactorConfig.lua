--角色数据
local CharactorConfig=Glob.lplus.class(Glob.ConfigBase)

function CharactorConfig:Init()
    self.msg=Glob.Read("RoleMsg")
    if self.msg==nil then
        local a=function ()
            local c={Glob.CharactorData.new("AAA","攻坚干员",1001,"nan1","MT"),Glob.CharactorData.new("BBB","火力干员",1002,"nan4","DPS"),Glob.CharactorData.new("CCC","医疗干员",1003,"nv1","NAI")}
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
    local name,career=...
    print(self.msg[#self.msg].id+1)
    if career=="攻坚干员" then
        self.msg[#self.msg+1]=Glob.CharactorData.new(name,career,self.msg[#self.msg].id+1,"nan1","MT")
    elseif career=="火力干员" then
        self.msg[#self.msg+1]=Glob.CharactorData.new(name,career,self.msg[#self.msg].id+1,"nan4","DPS")
    elseif career=="医疗干员" then
        self.msg[#self.msg+1]=Glob.CharactorData.new(name,career,self.msg[#self.msg].id+1,"nv1","NAI")
    end
    
    Glob.Write("RoleMsg",self.msg)
end

return CharactorConfig