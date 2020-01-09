local f = assert(io.open(Application.dataPath .. "/__VR1710Josn.json"))
local str = f:read("*a")
f:close()
local datatable = Glob.js.decode(str)

print(datatable);
print(datatable.dic)
for key, value in pairs(datatable.dic) do
    print(key,value)
    -- for _key, _value in pairs(value) do
    --   print("*******",_key,_value)
    -- end
    print(value.ID,value.Name,value.height)
end

local funtable = {}

for i = 1, 10, 1 do
  funtable[i]=i;
end

local str = Glob.js.encode(funtable)

print("___________________",str);

local datatable = Glob.js.decode(str)
print("___________________",datatable);

for i = 1, 10, 1 do
 print( "___",datatable[i])
end

--  Glob.js.encode()
