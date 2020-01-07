Glob={}

require "head"
Glob.lplus = require "Lplus"
Glob.json = require "json"

Glob.Write=require "Json/WriteJson"
Glob.Read=require "Json/ReadJson"
Glob.LogClass=require "Json/LogClass"
Glob.ServerData=require "Json/ServerData"

Glob.UIMgr=require "UIMgr"
Glob.UIBase=require "UIBase"
Glob.UIName=require "UIName"
Glob.UILog=require "UIPanel/UILog"
Glob.UIServer=require "UIPanel/UIServer"
Glob.UIChar=require "UIPanel/UIChar"
Glob.UISign=require "UIPanel/UISign"
Glob.UICheck=require "UIPanel/UICheck"
Glob.UIPrompt=require "UIPanel/UIPrompt"

Glob.ConfigBase=require "Config/ConfigBase"
Glob.ConfigMgr=require "Config/ConfigMgr"
Glob.LogConfig=require "Config/LogConfig"
Glob.ServerConfig=require "Config/ServerConfig"

UIType={
    Log=1,
    Server=2,
    Charactor=3,
    Sign=4,
    LogError=5,
    Check=6,
    Prompt=7
}