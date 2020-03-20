local UIMgr=Glob.lplus.class()

local instance=nil
local Instance=function ()
    if instance==nil then
        instance=UIMgr.new()
        instance.Canvas=GameObject.Find("Canvas").transform
    end

    return instance
end

UIMgr.UIDic={}
function UIMgr:Open(uiType)
    local c=nil
    for key, value in pairs(self.UIDic) do
        if key==uiType then
            c=value
        end
    end

    if c==nil then
        c=Glob.UIName(uiType)
        if c==nil then
            print("不存在该界面")
            return
        end
        c:Init(self.Canvas)

        self.UIDic[uiType]=c
    end

    c:Open()
end

function UIMgr:Close(uiType)
    local c=nil

    for key, value in pairs(self.UIDic) do
        if key==uiType then
            c=value
        end
    end

    if c~=nil then
        c:Close()
    else
        Debug.Log("该界面未打开")
    end
end

return Instance