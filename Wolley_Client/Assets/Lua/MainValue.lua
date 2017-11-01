print('>  MainValue <')
MainValue = { };
--MainValue.uiManager = uiManager;
--MainValue.gameGUI = uiManager.gameGUI;
--MainValue.buildingLogic = buildingLogic;
--MainValue.notificationPanelManager = notificationPanelManager;
--MainValue.worldGUI = worldGUI;
--MainValue.soundManager = soundManager;

--MainValue.dataManager = dataManager;
--MainValue.dbManager = dbManager;
--MainValue.resLoader = require('Data.ResourceLoader').create();

--MainValue.AssetsManager = AssetsManager;
--
--MainValue.updateValue = { };
--MainValue.lateUpdateValue = { };
--MainValue.ftueManager = ftueManager;
--MainValue.activityManager = activityManager;
--MainValue.otherNotifyObject = { buildingLogic, worldGUI, notificationPanelManager, soundManager, ftueManager , activityManager};


--MainValue.fontManager = require('Font.FontManager').create();
MainValue.GlobalTick = os.time();

MainValue.Data = { };


function MainValue.GetTick()
	local value = MainValue.GlobalTick;
	MainValue.GlobalTick = MainValue.GlobalTick + 1;
	return value;
end


function MainValue.GetUIManager()
--	return MainValue.uiManager;
end

function MainValue.GetWorldGuiManager()
--	return MainValue.worldGUI;
end


function MainValue.GetVersion()
--	return Version.ClientVersion;
end

function MainValue:UpdatePreSecond()
	self:DispatchOnEvent("UpdatePreSecond");
end



function MainValue:Reset()
--	self.ResetBeforeScene = self.buildingLogic.currentScene;
--	self.buildingLogic:Reset();
--	self.ftueManager:Reset();
--	self.activityManager:Reset();
end




function MainValue:EnterScene(...)

--	SafeInvoke( self.buildingLogic.EnterScene , self.buildingLogic , ... );
--	SafeInvoke( self.gameGUI.EnterScene , self.gameGUI , ... );
--	SafeInvoke( self.worldGUI.EnterScene , self.worldGUI , ... );
--	self.buildingLogic:EnterScene(...);
--	self.gameGUI:EnterScene(...);
--	self.worldGUI:EnterScene(...);
	-- trace( "EnterScene(%s)" , tostring(scene));
end


function MainValue:ExitScene(scene)
--	self.buildingLogic:ExitScene(scene);
--	self.gameGUI:ExitScene(scene);
--	self.worldGUI:ExitScene(scene);
--	-- trace( "ExitScene(%s)" , tostring(scene));
end



function MainValue:LoadSprite(name)
--	return MainValue.resLoader:LoadSprite(name);
end


function MainValue:OnNetDisonnected(reConnect)
--	if (reConnect) then
--		game:DelayInvoke(0, function()
--			local ret = game:LoginGame(util.GetUID(), Version.ClientVersion);
--			if (ret and not uiManager.gameGUI.loadingPanel) then
--				self.gameGUI:ShowLoadingPanel();
--			end
--		end );
--	end
end




function MainValue:OnLoginResult(result, value)
--	if (value) then
--		trace("MainValue:OnLoginResult: %s , uid = %d , %s ", tostring(result), value.uid, tostring(value.uid));
--	else
--		trace("MainValue:OnLoginResult: %s ", tostring(result));
--	end
--
--	if (CS.network.message.Result.SUCCESS == result) then
--		self.gameGUI:CloseLoadingPanel();
--		if (self.ResetBeforeScene) then
--			local scene = self.ResetBeforeScene;
--			self.ResetBeforeScene = nil;
--			self.buildingLogic:EnterScene(scene);
--		end
--		util.SaveUID(value.uid);
--		game:LoginSuccess();
--
--		if (value.newRole == true) then
--			local key = game:GetSystemCountry();
--			local id = 1;--ÁªºÏ¹ú
--			if nil == key or key == '' then
--			else	
--				local dbdata = dbManager:GetFlagsDataByFlag(key);
--				id = dbdata.Id;
--			end
--			game:SetUserNationalFlagRequest(id);
--		end
--	else
--		game:LoginFail();
--	end
--	self:DispatchOnEvent('OnLoginResult', result, value);
end




function MainValue:DispatchOnEvent(key, ...)
--	self.gameGUI:ForEachPanelMethod(key, ...);
--	Array.ForEachMethod(self.otherNotifyObject, key, ...);
end







function MainValue:RegUpdate(value)
--	table.insert(self.updateValue, value);
end

function MainValue:UnRegUpdate(value)
--	table.removebyvalue(self.updateValue, value);

end

function MainValue:Update()
--	Array.ForEachMethod(self.updateValue, 'Update');
end



--function MainValue:RegLateUpdate(value)
--	table.insert(self.lateUpdateValue, value);
--end
--
--function MainValue:UnRegLateUpdate(value)
--	table.removebyvalue(self.lateUpdateValue, value);
--end
--
--function MainValue:LateUpdate()
--	Array.ForEachMethod(self.lateUpdateValue, 'LateUpdate');
--end
--
--function MainValue:GetAssetsName(assetName)
--
--	if (AssetsManager[assetName]) then
--		return AssetsManager[assetName].Bundle, AssetsManager[assetName].Prefab;
--	end
--	return nil;
--end
--
--function MainValue:LoadResList()
--
--	if (AssetsManager[assetName]) then
--		return AssetsManager[assetName].Bundle, AssetsManager[assetName].Prefab;
--	end
--	return nil;
--end
--
--function MainValue:OnLoadSceneProgress(sceneName, progress)
--	return self.gameGUI:OnLoadSceneProgress(sceneName, progress);
--end
--
--
--
--function MainValue.AddUiNotify(obj)
--	if (not table.indexof(MainValue.otherNotifyObject, obj)) then
--		table.insert(MainValue.otherNotifyObject, obj);
--	end
--end
--
--function MainValue.RemoveUiNotify(obj)
--	table.removebyvalue(MainValue.otherNotifyObject, obj);
--end
--
--function MainValue:OnTriggerFirstFtue()
--	self:DispatchOnEvent('OnTriggerFirstFtue');
--end
--
--
--
--function MainValue:GetFtueState()
--	return self.ftueManager:GetFtueState();
--end
--
--
--function MainValue:CompleteFute()
--	if self.ftueManager:IsClickTargetArea() then
--		self.ftueManager:CompleteFute();
--	end
--end
--
--
MainValue.mt = { };
MainValue.mt.__index = function(table, key)
	if (string.match(key, "On%w+")) then
		local ret = function(ui, ...) ui:DispatchOnEvent(key, ...); end;
		return ret;
	end
	return nil;
end
setmetatable(MainValue, MainValue.mt)