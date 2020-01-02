local UIName=function (uiType)
    if uiType==UIType.Log then
        return Glob.UILog.new()
    elseif uiType==UIType.Server then
        return Glob.UIServer.new()
    elseif uiType==UIType.Charactor then
        return Glob.UIChar.new()
    elseif uiType==UIType.Sign then
        return Glob.UISign.new()
    end
end

return UIName