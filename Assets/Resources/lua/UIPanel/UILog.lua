local UILog=Glob.lplus.class(Glob.UIBase)

local log_Btn;
local sign_Btn;
local userName;
local userPsw;

function UILog:Init(content)
    self.ui=Resources.Load("UILog")
    self.ui=GameObject.Instantiate(self.ui)
    self.ui.transform:SetParent(content,false)

    local fb = self.ui:GetComponent("FindBase")
    log_Btn=fb:GetButton("SignIn")
    sign_Btn=fb:GetButton("SignOn")
    userName=fb:GetInputField("Name")
    userPsw=fb:GetInputField("Pwd")

    log_Btn.onClick:AddListener(function ()
        local msg=Glob.ConfigMgr():GetMsg(UIType.Log)
        if msg==nil then
            Glob.UIMgr():Open(UIType.Sign)
            Glob.UIMgr():Close(UIType.Log)
        else
            for key, value in pairs(msg) do
                if userName.text==value.name and userPsw.text==value.pwd then
                    Debug.Log("登录")
                    Glob.UIMgr():Open(UIType.Server)
                    Glob.UIMgr():Close(UIType.Log)

                    return
                end
            end

            Debug.Log("登录密码有误，请重新登录")
        end
    end)

    sign_Btn.onClick:AddListener(function ()
        Glob.UIMgr():Open(UIType.Sign)
        Glob.UIMgr():Close(UIType.Log)
    end)
end

return UILog