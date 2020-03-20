Glob={}

require "head"
Glob.lplus = require "Lplus"
Glob.json = require "json"

--数据类以及读取写入类
Glob.Write=require "Json/WriteJson"
Glob.Read=require "Json/ReadJson"
Glob.LogClass=require "Json/LogClass"
Glob.ServerData=require "Json/ServerData"
Glob.CharactorData=require "Json/CharactorData"
Glob.BagData=require "Json/BagData"

--ui界面
Glob.UIMgr=require "Framework/UIMgr"
Glob.UIBase=require "Framework/UIBase"
Glob.UIName=require "UIName"
Glob.UILog=require "UIPanel/UILog"
Glob.UIServer=require "UIPanel/UIServer"
Glob.UIChar=require "UIPanel/UIChar"
Glob.UISign=require "UIPanel/UISign"
Glob.UICheck=require "UIPanel/UICheck"
Glob.UIPrompt=require "UIPanel/UIPrompt"
Glob.UIBag=require "UIPanel/UIBag"
Glob.UIInsRole=require "UIPanel/UIInsRole"

--
Glob.ConfigBase=require "Config/ConfigBase"
Glob.ConfigMgr=require "Config/ConfigMgr"
Glob.LogConfig=require "Config/LogConfig"
Glob.ServerConfig=require "Config/ServerConfig"
Glob.CharactorConfig=require "Config/CharactorConfig"
Glob.BagConfig=require "Config/BagConfig"

Glob.RoleItemModel=require "Model/RoleItemModel"
Glob.BagItem=require "Model/BagItem"
Glob.RoleModel=require "Model/RoleModel"

--游戏战斗逻辑相关
Glob.PlayerMgr=require 'Game/Player/PlayerMgr'

UIType={
    Log=1,
    Server=2,
    Charactor=3,
    Sign=4,
    LogError=5,
    Check=6,
    Prompt=7,
    Bag=8,
    CreateRole=9,
    UIInsRole=10
}

Layer={
    Main=1,
    Func=2
}