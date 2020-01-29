local UICharact=Glob.lplus.class(Glob.UIBase)

local itemDic={}
local prefabDic={}
function UICharact:Init(content)
    --获取ui界面
    self.ui=GameObject.Instantiate(Resources.Load("UIChar"))
    self.ui.transform:SetParent(content,false)

    --获取角色数据
    local msg=Glob.ConfigMgr():GetMsg(UIType.Charactor)

    local fb=self.ui:GetComponent("FindBase")
    local _content=fb:GetRectTransform("Content")
    local close_Btn=fb:GetButton("Close1")
    local enter_Btn=fb:GetButton("enter1")
    local create_Btn=fb:GetButton("CreateRole")
    local pos=fb:GetTransform("pos")
    Glob.RoleModel():Content(pos)

    --local a1=Glob.

    --循环生成角色栏模型，并保存到字典中
    for _, value in pairs(msg) do
        print("角色栏："..value.career)
        local item=Glob.RoleItemModel.new()
        item:Init(value,_content)
        itemDic[value.id]=item
    end

    --根据角色栏字典，生成角色模型并保存
    for _, value in pairs(itemDic) do
        local tmp
        print("角色栏类型"..value.ZhiYe_1.text)
        if prefabDic[value.ZhiYe_1.text]==nil then
            if value.ZhiYe_1.text=="攻坚干员" then
                tmp=Glob.RoleModel():Create("MT")
            elseif value.ZhiYe_1.text=="火力干员" then
                tmp=Glob.RoleModel():Create("DPS")
            elseif value.ZhiYe_1.text=="医疗干员" then
                tmp=Glob.RoleModel():Create("NAI")
            end

            prefabDic[value.ZhiYe_1.text]=tmp
        end
    end

    this.OnToggle=function ()
        for _, value in pairs(itemDic) do
            if value.toggle.isOn then
                prefabDic[value.ZhiYe_1.text]:SetActive(true)
            else
                prefabDic[value.ZhiYe_1.text]:SetActive(false)
            end
        end
    end

    --关闭按钮触发事件
    close_Btn.onClick:AddListener(function ()
        Glob.UIMgr():Open(UIType.Server)
        Glob.UIMgr():Close(UIType.Charactor)
    end)

    --跳转界面按钮触发事件
    enter_Btn.onClick:AddListener(function ()
        for _, value in pairs(itemDic) do
            if value.toggle.isOn then
                Glob.UIMgr():Open(UIType.Main)
                Glob.UIMgr():Close(UIType.Charactor)
            end
        end
    end)

    --创建新角色按钮事件
    create_Btn.onClick:AddListener(function ()
        pos.gameObject:SetActive(false)
        Glob.UIMgr():Open(UIType.UIInsRole)
    end)
end

return UICharact