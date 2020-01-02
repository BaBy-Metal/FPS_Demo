local UIServer=Glob.lplus.class(Glob.UIBase)

local panel
function UIServer:Init(content)
    panel=Resources.Load("UIServer")
    panel=GameObject.Instantiate(panel)
    panel.transform:SetParent(content,false)
end

function UIServer:Open()
    panel:LSetActive(true)
end

function UIServer:Close()
    panel:LSetActive(true)
end

return UIServer