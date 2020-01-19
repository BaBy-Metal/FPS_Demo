local UIName=function (uiType)
    if uiType==UIType.Log then
        return Glob.UILog.new()
    elseif uiType==UIType.Server then
        return Glob.UIServer.new()
    elseif uiType==UIType.Charactor then
        return Glob.UIChar.new()
    elseif uiType==UIType.Sign then
        return Glob.UISign.new()
    elseif uiType==UIType.Check then
        return Glob.UICheck.new()
    elseif uiType==UIType.Prompt then
        return Glob.UIPrompt.new()
    elseif uiType==UIType.Bag then
        return Glob.UIBag.new()
    elseif uiType==UIType.Bag then
        return Glob.UIInsRole.new()
    end
    return nil
end

return UIName