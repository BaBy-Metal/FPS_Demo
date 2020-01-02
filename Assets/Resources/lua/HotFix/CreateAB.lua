require "Glob"

function Init()
    local rootPath = StringDispose.Replace(Application.dataPath,"Assets", "AB");

    if Directory.Exists(rootPath)==false then
        Directory.CreateDirectory(rootPath);
    end

    Infect()
    BuildPipeline.BuildAssetBundles(rootPath, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
    --CreateCsv()
end

function Infect()
    local resPath = "Assets/Resources"
    local fileMsgs = SearchFiles(resPath,"",nil);

    if fileMsgs~=nil then
        --print(#fileMsgs)
        for key, value in pairs(fileMsgs) do
            value:SetValue("Assets\\", "Resources\\")
        end
    end

    for key, value in pairs(fileMsgs) do
        local importer=AssetImporter.GetAtPath(value.dataPath)
        local path=nil
        if value.extension==".prefab" then
            Debug.Log("生成预设体")
            path = "prefab/"..value.fileName
        else if value.extension==".png" then
            path = "png/"..value.fileName
        end
            path="other/"..value.fileName
        end

        importer.assetBundleName=path
        importer.assetBundleVariant="u3d"
    end
end

function SearchFiles(resPath, extension, files)
    if files==nil then
        files={}
    end

    local filesPath=Directory.GetFiles(resPath)
    if filesPath~=nil then
        local filesTmp={}
        for i = 0, filesPath.Length-1 do
            --Debug.Log(filesPath[i])
            table.insert(filesTmp,filesPath[i])
        end
        --Debug.Log(#filesTmp)

        for i = 1, #filesTmp do
            local exten=Path.GetExtension(filesTmp[i])
            if exten~=".meta" and exten~=extension then
                local msg=FileMsg.new(Path.GetFullPath(filesTmp[i]),Path.GetFileNameWithoutExtension(filesTmp[i]),exten)
                files[i]=msg
            end
        end
    end
    
    local dirPath = Directory.GetDirectories(resPath)
    if dirPath~=nil then
        local dirPathTmp={}
        for i = 0, dirPath.Length-1 do
            table.insert(dirPathTmp,dirPath[i])
        end
        for key, value in pairs(dirPathTmp) do
            SearchFiles(value,extension,files)
        end
    end

    return files
end

function CreateCsv()

end

FileMsg=Glob.lplus.class()

function FileMsg:ctor(fullPath,fileName,extension)
    self.fullPath=fullPath
    self.fileName=fileName
    self.dataPath=nil
    self.extension=extension
    self.UnAssetsPath=nil
end

function FileMsg:SetValue(oldStr,newStr)
    if self.fullPath~=nil then
        local tmp = StringDispose.Replace(self.fullPath,oldStr,"#"..oldStr)
        local a=StringDispose.Split(tmp,'#')
        self.dataPath=a[a.Length-1]
        local b = StringDispose.Split(tmp,{ newStr });
        self.UnAssetsPath=b[b.Length-1]
        --print(self.extension)
    end
end