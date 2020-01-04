local json=function (fileName,msg)
    local file=io.open(Application.persistentDataPath.."/lua/"..fileName..".txt","w")
    local str=Glob.json.encode(msg)

    file:write(str)
    file:close()
end

return json