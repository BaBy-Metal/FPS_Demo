local ServerData = Glob.lplus.class()

function ServerData:ctor(a,b)
    self.state=a
    self.name=b
end

return ServerData