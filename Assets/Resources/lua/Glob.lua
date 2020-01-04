Glob={}

require "head"
Glob.lplus = require "Lplus"
Glob.json = require "json"
Glob.UIMgr = require "UIMgr"
Glob.UIBase=require "UIBase"
Glob.UIName=require "UIName"
Glob.Write=require "Json/WriteJson"
Glob.Read=require "Json/ReadJson"
Glob.UILog=require "UIPanel/UILog"
Glob.UIServer=require "UIPanel/UIServer"
Glob.UIChar=require "UIPanel/UIChar"
Glob.UISign=require "UIPanel/UISign"

UIType={
    Log=1,
    Server=2,
    Charactor=3,
    Sign=4,
    LogError=5,
    Check=6
}