using cohtml.Net;
using Colossal.UI;
using Game.Input;
using Game.Prefabs;
using System;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;

namespace ExtraHotkeys
{
    public class ToolWindowManager
    {
        private readonly View _uiView;
        private readonly UIInputManager _uiInputManager;
        private readonly ModSettings _modSettings;
        private readonly PrefabSystem _prefabSystem;
        private readonly List<(ProxyAction binding, string toolName)> _openToolWindowsBindings;

        public ToolWindowManager(
            View uiView, 
            UIInputManager uiInputManager, 
            ModSettings modSettings,
            PrefabSystem m_prefabSystem
            )
        {
            _uiView = uiView;
            _uiInputManager = uiInputManager;
            _modSettings = modSettings;
            _prefabSystem = m_prefabSystem;
            _openToolWindowsBindings = new List<(ProxyAction, string)>();

            InitializeBindings();

            LogUtil.Info($"{nameof(ToolWindowManager)} initialized");
        }


        private void InitializeBindings()
        {
            RegisterKeybinding(nameof(_modSettings.OpenZonesKeyBinding), "Zones");
            RegisterKeybinding(nameof(_modSettings.OpenAreasKeyBinding), "Areas");
            RegisterKeybinding(nameof(_modSettings.OpenSignaturesKeyBinding), "Signatures");
            RegisterKeybinding(nameof(_modSettings.OpenRoadsKeyBinding), "Roads");
            RegisterKeybinding(nameof(_modSettings.OpenElectricityKeyBinding), "Electricity");
            RegisterKeybinding(nameof(_modSettings.OpenWaterAndSewageKeyBinding), "Water & Sewage");
            RegisterKeybinding(nameof(_modSettings.OpenHealthAndDeathcareKeyBinding), "Health & Deathcare");
            RegisterKeybinding(nameof(_modSettings.OpenGarbageManagementKeyBinding), "Garbage Management");
            RegisterKeybinding(nameof(_modSettings.OpenEducationAndResearchKeyBinding), "Education & Research");
            RegisterKeybinding(nameof(_modSettings.OpenFireAndRescueKeyBinding), "Fire & Rescue");
            RegisterKeybinding(nameof(_modSettings.OpenPoliceAndAdministrationKeyBinding), "Police & Administration");
            RegisterKeybinding(nameof(_modSettings.OpenTransportationKeyBinding), "Transportation");
            RegisterKeybinding(nameof(_modSettings.OpenParksAndRecreationKeyBinding), "Parks & Recreation");
            RegisterKeybinding(nameof(_modSettings.OpenCommunicationsKeyBinding), "Communications");
            RegisterKeybinding(nameof(_modSettings.OpenLandscapingKeyBinding), "Landscaping");
        }

        private void RegisterKeybinding(string settingName, string toolName)
        {
            var binding = _uiInputManager.GetAndEnableBinding(settingName);
            _openToolWindowsBindings.Add((binding, toolName));
        }

        public void CheckHotkeys()
        {
            foreach (var (binding, toolName) in _openToolWindowsBindings)
            {
                if (binding.WasPerformedThisFrame())
                {
                    _uiView.TriggerEvent("toolbar.selectAssetMenu", GetAssetMenuObject(toolName));
                }
            }
        }

        private object GetAssetMenuObject(string toolName)
        {
            EntityQuery assetMenuData = _prefabSystem.World.EntityManager.CreateEntityQuery(ComponentType.ReadOnly<UIAssetMenuData>());
            NativeArray<Entity> menuEntities = assetMenuData.ToEntityArray(Allocator.Temp);
            Entity menuEntity = Entity.Null;

            foreach (Entity entity in menuEntities)
            {
                UIAssetMenuPrefab assetMenuPrefab = _prefabSystem.GetPrefab<UIAssetMenuPrefab>(entity);
                if (assetMenuPrefab.name == toolName)
                {
                    menuEntity = entity;
                    break;
                }
            }
            menuEntities.Dispose();

            if (menuEntity == Entity.Null)
            {
                LogUtil.Exception(new Exception($"Could not find menu entity for {toolName}"));
            }

            return new
            {
                __Type = menuEntity.GetType().ToString(),
                index = menuEntity.Index,
                version = menuEntity.Version
            };
        }
    }
}