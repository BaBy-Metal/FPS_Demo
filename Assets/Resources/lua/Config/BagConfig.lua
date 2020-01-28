local BagConfig=Glob.lplus.class(Glob.ConfigBase)

function BagConfig:Init()
    self.msg=Glob.Read("BagMsg")
    if self.msg==nil then
        local a=function ()
            local c={}
            for i = 1, 25 do
                c[i]=Glob.BagData.new(i)
            end
            return c
        end

        self.msg=a()
        Debug.Log(self.msg[1].text)
        Glob.Write("BagMsg",self.msg)
    end

    local c=self.msg
    Debug.Log(c[1].text)
    return c
end

return BagConfig