local UIMgr=Glob.lplus.class()

local instance=nil
local Instance=function ()
    if instance==nil then
        instance=UIMgr.new()
        instance.content=GameObject.Find("content").transform
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
        Glob.UIBase:Init(uiType)
    end
end

function UIMgr:Close()
    
end

return Instance