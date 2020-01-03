local UIBase=Glob.lplus.class()

UIBase.ui=nil
function UIBase:Init()
    
end

function UIBase:Open()
    self.ui:SetActive(true)
end

function UIBase:Close()
    self.ui:SetActive(false)
end

return UIBase