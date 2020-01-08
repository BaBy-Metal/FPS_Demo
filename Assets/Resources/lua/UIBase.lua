local UIBase=Glob.lplus.class()

UIBase.ui=nil
--UIBase.UILayer=Layer.Main
function UIBase:Init()
    
end

function UIBase:Open()
    if self.ui~=nil then
        self.ui:SetActive(true)
    else
        Debug.Log("该场景未加载出来")
    end
end

function UIBase:Close()
    if self.ui~=nil then
        self.ui:SetActive(false)
    else
        Debug.Log("该场景未加载出来")
    end
end

return UIBase