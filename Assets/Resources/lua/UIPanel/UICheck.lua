local UICheck=Glob.lplus.class(Glob.UIBase)

function UICheck:Init(content)
    self.ui=Resources.Load("UIAssets")
    self.ui=GameObject.Instantiate(self.ui)
    self.ui.transform:SetParent(content,false)
end

return UICheck