local ConfigMgr=Glob.lplus.class()

local instance
local Instance=function ()
    if instance==nil then
        instance=ConfigMgr.new()
    end

    return instance
end

local configDic={}
function ConfigMgr:Init()
    configDic[UIType.Log]=Glob.LogConfig.new():Init()
    configDic[UIType.Server]=Glob.ServerConfig.new():Init()
end

function ConfigMgr:GetMsg(_type)
    for key, value in pairs(configDic) do
        if key==_type then
            return value
        end
    end
end

return Instance