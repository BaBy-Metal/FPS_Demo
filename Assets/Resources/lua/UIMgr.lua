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
function UIMgr:Open()
    
end

function UIMgr:Close()
    
end

return Instance