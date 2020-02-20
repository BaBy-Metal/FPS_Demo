local PlayerMgr=Glob.lplus.class()

function PlayerMgr:Init()
    self.name=PlayerPrefs.GetString("name")

    self.obj=GameObject.Instantiate(Resources.Load(self.name))
    self.FC=self.obj:GetComponent("Find")
end

function PlayerMgr:Move()
    local x = Input.GetAxis("Horizontal");
    local z = Input.GetAxis("Vertical");

    self.obj.transform:Translate(Vector3(x,0,z));
end

return PlayerMgr