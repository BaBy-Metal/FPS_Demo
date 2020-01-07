local LogClass = Glob.lplus.class()

function LogClass:ctor(_name,_pwd)
    self.name=_name
    self.pwd=_pwd
end

return LogClass