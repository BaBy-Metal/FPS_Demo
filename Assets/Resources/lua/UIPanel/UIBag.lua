local UIBag=Glob.lplus.class(Glob.UIBase)

local bagDic={}
function UIBag:Init(content)
    self.ui=GameObject.Instantiate(Resources.Load("UIBag"),content)
    self.ui.name="UIBag"

    local fb=self.ui:GetComponent("FindBase")
    local _content=fb:GetRectTransform("Content")
    local add_Btn=fb:GetButton("Add")
    local delete_Btn=fb:GetButton("Delete")

    --local msg=Glob.ConfigMgr():GetMsg(UIType.Bag)
    local msg=Glob.Read("BagData")
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

    delete_Btn.onClick:AddListener(function ()
        print("准备删除")
        for key, value in pairs(bagDic) do
            local isDel=value.IsDel
            if isDel then
                local item=table.remove(bagDic,key)
                Destroy(item.item)
            end
        end
    end)
end

return UIBag