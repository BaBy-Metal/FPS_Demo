local RoleModel=Glob.lplus.class()

function RoleModel:ctor(prefabType,content)
    return GameObject.Instantiate(Resources.Load(prefabType),content)
end

return RoleModel