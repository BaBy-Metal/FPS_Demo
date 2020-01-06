require "Glob"

Glob.ConfigMgr():Init()
--Glob.UIMgr():Open(UIType.Check)

function OnStart()
    Glob.UIMgr():Close(UIType.Check)
    Glob.UIMgr():Open(UIType.Log)
end