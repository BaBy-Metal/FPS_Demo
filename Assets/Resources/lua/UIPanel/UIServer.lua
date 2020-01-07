local UIServer=Glob.lplus.class(Glob.UIBase)

local recSerDic={}
function UIServer:Init(content)
    self.ui=Resources.Load("UIServer")
    self.ui=GameObject.Instantiate(self.ui)
    self.ui.transform:SetParent(content,false)

    local fb=self.ui:GetComponent("FindBase")
    local Content=fb:GetRectTransform("Content")
    local Image1=fb:GetImage("Image1")
    local Text1=fb:GetText("Text1")

    local msg=Glob.ConfigMgr():GetMsg(UIType.Server)
    Debug.Log(msg[1].state)
    for key, value in pairs(msg) do
        local item=Resources.Load("ServerItem")
        item=GameObject.Instantiate(item)
        item.transform:SetParent(Content.transform,false)
        item.name="ServerItem"

        local itemfb=item:GetComponent("FindBase")
        local text=itemfb:GetText("Text")
        local image=itemfb:GetImage("ServerItem")
        Debug.Log(image)

        text.text=value.name

        if value.state=="1" then
            image.sprite=Resources.Load("001-startmenu/btn_流畅3",typeof(Sprite))
            recSerDic[key]=value
        elseif value.state=="2" then
            image.sprite=Resources.Load("001-startmenu/btn_火爆3",typeof(Sprite))
        end
    end

    if #recSerDic>0 then
        
    end
end

return UIServer