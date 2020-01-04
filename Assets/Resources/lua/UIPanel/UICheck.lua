local UICheck=Glob.lplus.class(Glob.UIBase)

function UICheck:Init()
    self.ui=Resources.Load("UICheck")
    self.ui=GameObject.Instantiate(self.ui)
end

return UICheck