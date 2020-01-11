local RoleItemModel=Glob.lplus.class()

local msg,content
local fb
function RoleItemModel:Init(...)
    msg,content=...
    Debug.Log(msg.id)
    self.obj=GameObject.Instantiate(Resources.Load("RoleItem"))
    self.obj.transform:SetParent(content,false)

    fb=self.obj:GetComponent("FindBase")
    local toggle=self.obj:GetComponent("Toggle")
    local head=fb:GetImage("head")
    local name1=fb:GetInputField("name1")
    local ZhiYe_1=fb:GetText("ZhiYe_1")

    toggle.group=content:GetComponent("ToggleGroup")
    toggle.isOn=false
    local picPath="headicon/"..msg.headpic
    print(picPath)
    head.sprite=Resources.Load(picPath,typeof(Sprite))
    name1.text=msg.name
    ZhiYe_1.text=msg.career
end

return RoleItemModel