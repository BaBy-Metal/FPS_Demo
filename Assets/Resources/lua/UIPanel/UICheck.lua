local UICheck=Glob.lplus.class(Glob.UIBase)

function UICheck:Init(content)
    self.ui=GameObject.Instantiate(Resources.Load("UIAssets"))
    self.ui.transform:SetParent(content,false)
end

return UICheck