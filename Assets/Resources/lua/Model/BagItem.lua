local BagItem=Glob.lplus.class()

local tab={}
function BagItem:ctor(content,msg)
    self.item=GameObject.Instantiate(Resources.Load("BagItem"),content)
    tab[self.item]=self

    self.item.name=msg.pic
    local image=self.item:GetComponent("Image")
    local text=self.item.transform:Find("Text"):GetComponent("Text")

    image.sprite=Resources.Load(msg.pic,typeof(Sprite))
    text.text=msg.num

    self.IsDel=false

    local uiEvent=self.item:GetComponent("UIEvent")
    uiEvent:AddFunction(EventTriggerType.BeginDrag,BeginDrag)
    uiEvent:AddFunction(EventTriggerType.Drag,OnDrag)
    uiEvent:AddFunction(EventTriggerType.EndDrag,EndDrag)
    uiEvent:AddFunction(EventTriggerType.PointerClick,OnClick)
end

local game
local oldObj
function BeginDrag(obj)
    oldObj=obj
    game = GameObject.Instantiate(Resources.Load("BagItem"));
    game.transform:SetParent(GameObject.Find("Canvas").transform, false)

    game:GetComponent("Image").sprite=obj:GetComponent("Image").sprite
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
        local endImage=obj.transform.parent:GetComponent("Image")
        if endText==nil then
            return
        else
            local text=endText.text
            local image=endImage.sprite

            Debug.Log(oldObj)
            endText.text=oldObj.transform:Find("Text"):GetComponent("Text").text
            endImage.sprite=oldObj:GetComponent("Image").sprite
            oldObj:GetComponent("Image").sprite=image
            oldObj.transform:Find("Text"):GetComponent("Text").text=text
        end
    end
end

function OnClick(obj)
    Debug.Log(tab[obj].IsDel)
    tab[obj].IsDel=true
    Debug.Log(tab[obj].IsDel)
end

return BagItem