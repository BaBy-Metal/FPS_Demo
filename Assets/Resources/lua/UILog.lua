local UILog=Glob.lplus.class(Glob.UIBase)

function UILog:Init(content)
    local uiLog=Resources.Load("UILog")
    uiLog=GameObject.Instantiate(uiLog)
    uiLog.transform:SetParent(content,false)

    local fb = uiLog:GetComponent("FindBase")
end

function UILog:Open()
    
end

function UILog:Close()
    
end

return UILog