local UIBag=Glob.lplus.class(Glob.UIBase)

local bagDic={}
function UIBag:Init(content)
    self.ui=GameObject.Instantiate(Resources.Load("UIBag"),content)

    local fb=self.ui:GetComponent("FindBase")
    local _content=fb:GetRectTransform("Content")
    local add_Btn=fb:GetButton("Add")

    local msg=Glob.ConfigMgr():GetMsg(UIType.Bag)
    if msg~=nil then
        for key, value in pairs(msg) do
            local item=Glob.BagItem.new(_content,value)
            bagDic[key]=item
        end
    end

    add_Btn.onClick:AddListener(function ()
        local item=Glob.BagItem.new(_content,msg[1])
        bagDic[#bagDic+1]=item
    end)
end

return UIBag