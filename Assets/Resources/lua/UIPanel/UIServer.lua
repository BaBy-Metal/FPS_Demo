local UIServer=Glob.lplus.class(Glob.UIBase)

local recSerDic={}
local firstTime=0
local localTime=0
local Interval=0.5
function UIServer:Init(content)
    self.ui=Resources.Load("UIServer")
    self.ui=GameObject.Instantiate(self.ui)
    self.ui.transform:SetParent(content,false)

    local msg=Glob.ConfigMgr():GetMsg(UIType.Server)
    
    local fb=self.ui:GetComponent("FindBase")
    local Content=fb:GetRectTransform("Content")
    local Image1=fb:GetImage("Image1")
    local Image2=fb:GetImage("Image2")
    local Text1=fb:GetText("Text1")
    local Text2=fb:GetText("Text2")
    local uiEvent=fb:GetUIEvent("Image2")
    local close_Btn=fb:GetButton("Close1")

    close_Btn.onClick:AddListener(function ()
        Glob.UIMgr():Open(UIType.Log)
        Glob.UIMgr():Close(UIType.Server)
    end)

    uiEvent:AddFunction(EventTriggerType.PointerClick,function ()
        localTime = Time.realtimeSinceStartup;

        if (localTime - firstTime < Interval) then
            Glob.UIMgr():Close(UIType.Server)
            Glob.UIMgr():Open(UIType.Charactor)
        else
            firstTime = localTime;
        end
    end)

    --Debug.Log(msg[1].state)
    for key, value in pairs(msg) do
        local item=Resources.Load("ServerItem")
        item=GameObject.Instantiate(item)
        item.transform:SetParent(Content.transform,false)
        item.name=value.name
        local event=item:GetComponent("UIEvent")

        local itemfb=item:GetComponent("FindBase")
        local text=itemfb:GetText("Text")
        local image=itemfb:GetImage(item.name)
        local Btn=itemfb:GetButton(item.name)

        event:AddFunction(EventTriggerType.PointerClick,Show)

        text.text=value.name
        Btn.onClick:AddListener(function ()
            Image2.sprite=image.sprite
            Text2.text=text.text
        end)

        if value.state=="1" then
            image.sprite=Resources.Load("001-startmenu/btn_流畅3",typeof(Sprite))
            recSerDic[key]={text.text,image.sprite}
        elseif value.state=="2" then
            image.sprite=Resources.Load("001-startmenu/btn_火爆3",typeof(Sprite))
        end
    end

    if #recSerDic>0 then
        Text1.text=recSerDic[1][1]
        Image1.sprite=recSerDic[1][2]
    end

    if Text1.text~=nil and Image1.sprite~=nil then
        Image2.sprite=Image1.sprite
        Text2.text=Text1.text
    end
end

function Show(obj)
    Debug.Log("这是服务器："..obj.name)
end

return UIServer