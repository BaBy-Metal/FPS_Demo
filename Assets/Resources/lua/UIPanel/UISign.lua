local UISign=Glob.lplus.class(Glob.UIBase)

local UserName
local UserPwd
local SignOn
function UISign:Init(content)
    self.ui=Resources.Load("UIServer")
    self.ui=GameObject.Instantiate(self.ui)
    self.ui.transform:SetParent(content,false)

    local fb=self.ui:GetComponent("FindBase")
    UserName=fb:GetInputField("UserName")
    UserPwd=fb:GetInputField("UserPwd")
    SignOn=fb:GetButton("SignOn")

    SignOn.onClick:AddListener(function ()
        if UserName.text~="" and UserPwd.text~="" then
            local msg={UserName.text,UserPwd.text}
            Glob.Write("data",msg)
        end
    end)
end

return UISign