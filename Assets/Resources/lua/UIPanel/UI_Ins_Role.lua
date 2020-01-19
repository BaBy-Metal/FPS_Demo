local UIInsRole=Glob.lplus.class(Glob.UIBase)

function UIInsRole:Init(content)
    self.ui=GameObject.Instantiate(Resources.Load("UIInsRole"),content)
    
    local fb=self.ui:GetComponent("FindComponent")
    local conf_Btn=fb:GetComponent("conf","button")
    local Dropdown=fb:GetComponent("Dropdown","Dropdown")
    local Name=fb:GetComponent("InputField","InputField")

    conf_Btn.onClick:AddListener(function ()
        if true then
            
        end
    end)
end

return UIInsRole