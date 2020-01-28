require "Glob"

local onDrag = false;
local speed = 60
local zSpeed
local X
local mXY

RoleMove.OnDown=function ()
    if Input.GetMouseButtonDown(0) then
        onDrag = true
    end
end

RoleMove.OnDrag=function ()
    if onDrag then
        RoleMove.transform:Rotate(Vector3.up,-Input.GetAxis("Mouse X")*speed)
    end
end

RoleMove.OnUp=function ()
    onDrag = false
end