local UIBase=Glob.lplus.class()

UIBase.ui=nil
function UIBase:Init()
    
end

function UIBase:Open()
    if self.ui~=nil then
        self.ui:SetActive(true)
    end
end

function UIBase:Close()
    if self.ui~=nil then
        self.ui:SetActive(false)
    end
end

return UIBase