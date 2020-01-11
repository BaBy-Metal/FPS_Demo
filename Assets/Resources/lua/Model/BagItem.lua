local BagItem=Glob.lplus.class()

function BagItem:ctor(content,msg)
    self.item=GameObject.Instantiate(Resources.Load("BagItem"),content)
    local text=self.item.transform:Find("Text"):GetComponent("Text")
    text.text=msg.text
    self.item.name=msg.text

    local uiEvent=self.item:GetComponent("UIEvent")
    uiEvent:AddFunction(EventTriggerType.BeginDrag,BeginDrag)
    uiEvent:AddFunction(EventTriggerType.Drag,OnDrag)
    uiEvent:AddFunction(EventTriggerType.EndDrag,EndDrag)
    --uiEvent:AddFunction(EventTriggerType.PointerClick,OnClick)
end
local game
local oldObj
function BeginDrag(obj)
    oldObj=obj
    game = GameObject.Instantiate(Resources.Load("BagItem"));
    game.transform:SetParent(GameObject.Find("Canvas").transform, false)
    game.transform:Find("Text"):GetComponent("Text").text = obj.transform:Find("Text"):GetComponent("Text").text
    game:GetComponent("Image").raycastTarget = false;
end

function OnDrag(obj)
    game.transform.position =Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
end

function EndDrag(obj)
    Destroy(game)
    if obj~=nil then
        local endText=obj:GetComponent("Text")
        if endText==nil then
            return
        else
            local text=endText.text
            endText.text=oldObj.transform:Find("Text"):GetComponent("Text").text
            oldObj.transform:Find("Text"):GetComponent("Text").text=text
        end
    end
end

function OnClick(obj)
    
end

return BagItem