local UICharact=Glob.lplus.class(Glob.UIBase)

local itemDic={}
function UICharact:Init(content)
    self.ui=Resources.Load("UIChar")
    self.ui=GameObject.Instantiate(self.ui)
    self.ui.transform:SetParent(content,false)

    local msg=Glob.ConfigMgr():GetMsg(UIType.Charactor)

    local fb=self.ui:GetComponent("FindBase")
    local _content=fb:GetRectTransform("Content")
    local close_Btn=fb:GetButton("Close1")
    local enter_Btn=fb:GetButton("enter1")
    --local uiBtn=self.ui:GetComponent("UIButton")
    -- uiBtn.func=function (obj)
    --     print("该面板名称：",obj.name)
    -- end

    for key, value in pairs(msg) do
        local item=Glob.RoleItemModel.new()
        item:Init(value,_content)
        itemDic[value.id]=item
    end

    close_Btn.onClick:AddListener(function ()
        Glob.UIMgr():Open(UIType.Server)
        Glob.UIMgr():Close(UIType.Charactor)
    end)

    enter_Btn.onClick:AddListener(function ()
        Glob.UIMgr():Open(UIType.Main)
        Glob.UIMgr():Close(UIType.Charactor)
    end)
end

return UICharact