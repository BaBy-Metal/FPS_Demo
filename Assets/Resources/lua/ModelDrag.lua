local onDrag = false;
local speed = 60

RoleMove.OnDown=function ()
    if Input.GetMouseButtonDown(0) then
        onDrag = true
    end
end

RoleMove.OnDrag=function (transform)
    if onDrag then
        transform:Rotate(Vector3.up,-Input.GetAxis("Mouse X")*speed)
    end
end

RoleMove.OnUp=function ()
    onDrag = false
end