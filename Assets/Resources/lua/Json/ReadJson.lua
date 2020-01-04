local json=function (fileName)
    local file=io.open(Application.persistentDataPath.."/lua/"..fileName..".txt",'r')
    if file==nil then
        print("不存在该文件")
        return nil
    end
    local msg=file:read("a")
    Debug.Log("1"..msg)
    local str=Glob.json.decode(msg)
    file:close()

    return str
end

return json