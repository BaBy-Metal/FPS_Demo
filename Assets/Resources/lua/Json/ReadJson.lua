local json=function (fileName)
    Debug.Log(Application.persistentDataPath)
    local file=io.open(Application.persistentDataPath.."/lua/"..fileName..".txt",'r')
    if file==nil then
        print("不存在该文件")
        return nil
    else
        local msg=file:read("a")
        if msg~="" then
            local str=Glob.json.decode(msg)
            file:close()
            return str
        else
            return nil
        end
    end
end

return json