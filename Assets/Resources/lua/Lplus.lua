local _class={}--全局类容器
local Class = function(super)
	local class_type={}--在此类上操作，最后返回
	class_type.ctor = false--构造 方法
	class_type.super = super--基类
	_class[class_type]={}--放入类容器
	local vtbl = _class[class_type];--创建一个基础元表 在全局类容器中开辟一块空间保存此类
	class_type.new = function(...)--new方法 创建类的实例化
		local obj={}
		setmetatable(obj,{ __index = vtbl })--在new的时候又设置一个_

		do
			--确保调用一个class的new的时候调用到“基类”的new。一个递归，找到所有基类，调用一下所有类的new
			local create
			create = function(this,...)
				if this.super then--有基类就重新检查一遍基类有没有构造
					create(this.super,...)
				end
				if this.ctor then--无论当前的C是派生类还是基类，有用户赋值的构造就调用
					this.ctor(obj,...)
				end
			end
			create(class_type,...)--进入递归
		end

		return obj
	end


	setmetatable(class_type,{__newindex=	--注意只赋值了newindex
		function(t,k,v)
			vtbl[k]=v
		end
	})


	if super then--如果有基类
		--先设置一个__index，一个方法，这个方法是找基类！！
		setmetatable(vtbl,{__index=
			function(t,k)
				local ret=_class[super][k]
				vtbl[k]=ret
				return ret
			end
		})
	end

	return class_type
end

return {class = Class}