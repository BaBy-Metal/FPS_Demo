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
    configDic[UIType.Log]=Glob.LogConfig.new()
    configDic[UIType.Server]=Glob.ServerConfig.new()
    configDic[UIType.Charactor]=Glob.CharactorConfig.new()
    configDic[UIType.Bag]=Glob.BagConfig.new()
end

function ConfigMgr:GetMsg(_type)
    for key, value in pairs(configDic) do
        if key==_type then
            return value:Init()
        end
    end
end

function ConfigMgr:SetMsg(_type,...)
    for key, value in pairs(configDic) do
        if key==_type then
            return value:Init()
        end
    end
end

function ConfigMgr:RefreshMsg(enum)
    for key, value in pairs(configDic) do
        if key==enum then
            configDic[key]=value:Init()
        end
    end
end

return Instance