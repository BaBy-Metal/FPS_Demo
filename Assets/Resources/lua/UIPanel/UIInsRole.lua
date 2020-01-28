local UIInsRole=Glob.lplus.class(Glob.UIBase)

local instance=nil
local Instance=function ()
    if instance==nil then
        instance = UIInsRole.new()
        return instance
    end
end

function UIInsRole:Init(content)
    self.ui=GameObject.Instantiate(Resources.Load("UIInsRole"),content)
    
    local fb=self.ui:GetComponent("FindBase")
    local conf_Btn=fb:GetButton("conf")
    local Dropdown=fb:GetDropdown("Dropdown")
    local Name=fb:GetInputField("Name1")

    conf_Btn.onClick:AddListener(function ()
        if Name.text~="" then
            print("生成新角色")
            print(Dropdown.captionText.text)
            if Dropdown.captionText.text=="攻坚干员" then
                self.prefab=Glob.RoleModel.new("MT")
            elseif Dropdown.captionText.text=="火力干员" then
                self.prefab=Glob.RoleModel.new("DPS")
            elseif Dropdown.captionText.text=="医疗干员" then
                self.prefab=Glob.RoleModel.new("NAI")
            end

            Glob.UIMgr():Close(UIType.UIInsRole)
        end
    end)
end

return Instance