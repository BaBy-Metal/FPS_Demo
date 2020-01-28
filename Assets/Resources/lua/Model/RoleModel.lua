local RoleModel=Glob.lplus.class()

local instance=nil
local Instance=function ()
    if instance==nil then
        instance = RoleModel.new()
    end

    return instance
end

function RoleModel:Create(prefabType)
    if self.pos~=nil then
        return GameObject.Instantiate(Resources.Load(prefabType),self.pos)
    else
        print("生成点未赋值"..self.pos)
    end
end

function RoleModel:Content(content)
    self.pos = content
end

return Instance