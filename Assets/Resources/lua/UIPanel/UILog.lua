local UILog=Glob.lplus.class(Glob.UIBase)

local uiLog
local log_Btn;
local sign_Btn;
local userName;
local userPsw;
function UILog:Init(content)
    uiLog=Resources.Load("UILog")
    uiLog=GameObject.Instantiate(uiLog)
    uiLog.transform:SetParent(content,false)

    local fb = uiLog:GetComponent("FindBase")
    Debug.Log(fb)
    log_Btn=fb:GetButton("SignIn")
    Debug.Log(log_Btn)
    sign_Btn=fb:GetButton("SignOn")
    userName=fb:GetInputField("Name")
    userPsw=fb:GetInputField("Pwd")

    log_Btn.onClick:AddListener(function ()
        if userName.text~="" and userPsw.text~="" then
            Debug.Log("登录")
            Glob.UIMgr():Open(UIType.Server)
            Glob.UIMgr():Close(UIType.Log)
        end
    end)

    sign_Btn.onClick:AddListener(function ()
        Glob.UIMgr():Open(UIType.Sign)
        Glob.UIMgr():Close(UIType.Log)
    end)
end

function UILog:Open()
    uiLog:SetActive(true)
end

function UILog:Close()
    uiLog:SetActive(false)
end

return UILog