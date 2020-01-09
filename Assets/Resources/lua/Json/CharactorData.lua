local CharactorData = Glob.lplus.class()

function CharactorData:ctor(_name,_career,_type,_pic,_prefab)
    self.name=_name
    self.career=_career
    self._type=_type
    self.headpic=_pic
    self.prefab=_prefab
end

return CharactorData