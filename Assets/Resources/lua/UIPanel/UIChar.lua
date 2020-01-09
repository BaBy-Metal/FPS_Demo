local UICharact=Glob.lplus.class(Glob.UIBase)

function UICharact:Init(content)
    self.ui=Resources.Load("UIChar")
    self.ui=GameObject.Instantiate(self.ui)
    self.ui.transform:SetParent(content,false)

    local msg=Glob.ConfigMgr():GetMsg(UIType.Charactor)

    local uiEvent=self.ui:GetComponent("UIEvent")
    uiEvent:AddFunction(EventTriggerType.PointerClick,function (obj)
        
    end)

    local fb=self.ui:GetComponent("FindBase")
    local close_Btn=fb:GetButton("Close1")
end

return UICharact