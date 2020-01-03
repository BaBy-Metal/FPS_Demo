local UIServer=Glob.lplus.class(Glob.UIBase)

function UIServer:Init(content)
    self.ui=Resources.Load("UIServer")
    self.ui=GameObject.Instantiate(self.ui)
    self.ui.transform:SetParent(content,false)
end

return UIServer