local UIPrompt=Glob.lplus.class(Glob.UIBase)

function UIPrompt:Init(content)
    self.ui=Resources.Load("UIPrompt")
    self.ui=GameObject.Instantiate(self.ui)
    self.ui.transform:SetParent(content,false)
end

local uiSelf=nil
function UIPrompt:Open()
    if self.ui~=nil then
        uiSelf=self.ui
        self.ui:SetActive(true)
        this.OnUpdate=self.AutoClose
    end
end

local timer=nil
function UIPrompt:AutoClose()
    if(timer==nil)then
        timer= Time.deltaTime
    end
    timer=timer+Time.deltaTime

    --print(self)
    if timer>=3.0 then
        GameObject.Destroy(uiSelf)
        timer=0

        Glob.UIMgr():Open(UIType.Log)
        Glob.UIMgr():Close(UIType.Sign)

        this.OnUpdate=nil
    end
end

return UIPrompt