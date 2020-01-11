local CharactorData = Glob.lplus.class()

function CharactorData:ctor(_name,_career,_id,_pic,_type)
    self.name=_name
    self.career=_career
    self.id=_id
    self.headpic=_pic
    self._type=_type
end

return CharactorData