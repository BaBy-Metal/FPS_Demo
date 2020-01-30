-- 角色信息模型
local RoleItemModel=Glob.lplus.class()

local msg,content

--对角色栏模型初始化赋值
function RoleItemModel:Init(...)
    msg,content=...
    self.obj=GameObject.Instantiate(Resources.Load("RoleItem"))
    self.obj.transform:SetParent(content,false)

    self.fb=self.obj:GetComponent("FindBase")
    self.toggle=self.obj:GetComponent("Toggle")
    self.head=self.fb:GetImage("head")
    self.name1=self.fb:GetInputField("name1")
    self.ZhiYe_1=self.fb:GetText("ZhiYe_1")

    self.toggle.group=content:GetComponent("ToggleGroup")
    self.toggle.isOn=false
    local picPath="headicon/"..msg.headpic
    self.head.sprite=Resources.Load(picPath,typeof(Sprite))
    self.name1.text=msg.name
    self.ZhiYe_1.text=msg.career
end

return RoleItemModel