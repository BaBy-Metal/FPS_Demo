local UISign=Glob.lplus.class(Glob.UIBase)

local panel
function UISign:Init(content)
    panel=Resources.Load("UIServer")
    panel=GameObject.Instantiate(panel)
    panel.transform:SetParent(content,false)
end

return UISign