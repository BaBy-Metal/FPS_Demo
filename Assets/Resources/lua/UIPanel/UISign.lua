local UISign=Glob.lplus.class(Glob.UIBase)

local UserName
local UserPwd
local SignOn
function UISign:Init(content)
    if self.ui~=nil then
        self.ui=nil
    end
    self.ui=Resources.Load("UISign")
    self.ui=GameObject.Instantiate(self.ui)
    self.ui.transform:SetParent(content,false)

    local fb=self.ui:GetComponent("FindBase")
    UserName=fb:GetInputField("UserName")
    UserPwd=fb:GetInputField("UserPwd")
    SignOn=fb:GetButton("SignOn")

    SignOn.onClick:AddListener(function ()
        if UserName.text~="" and UserPwd.text~="" then
            local msg=Glob.LogClass.new(UserName.text,UserPwd.text)
            local allMsg = Glob.Read("data")
            Debug.Log(allMsg)
            if #allMsg>0 then
                table.insert(allMsg,msg)
            else
                allMsg={msg}
            end
            Glob.Write("data",allMsg)

            Glob.UIMgr():Open(UIType.Prompt)
        end
    end)
end

return UISign