local UICharact=Glob.lplus.class(Glob.UIBase)

function UICharact:Init(content)
    self.ui=Resources.Load("UIChar")
    self.ui=GameObject.Instantiate(self.ui)
    self.ui.transform:SetParent(content,false)
end

return UICharact