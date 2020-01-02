local UICharact=Glob.lplus.class(Glob.UIBase)

local panel
function UICharact:Init(content)
    panel=Resources.Load("UIServer")
    panel=GameObject.Instantiate(panel)
    panel.transform:SetParent(content,false)
end

function UICharact:Open()
    panel:LSetActive(true)
end

function UICharact:Close()
    panel:LSetActive(true)
end

return UICharact