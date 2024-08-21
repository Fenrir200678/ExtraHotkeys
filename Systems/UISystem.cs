using cohtml.Net;
using Game.Input;
using Game.Prefabs;
using Game.SceneFlow;
using Game.UI;
using Game.UI.InGame;
using System;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;

namespace ExtraHotkeys
{
    public partial class UISystem : UISystemBase
    {
        private InputManager inputManager;
        private View _uiView;
        private PrefabSystem m_PrefabSystem;
        private GameScreenUISystem m_GameScreenUISystem;

        // List to store hotkey bindings
        private List<(ProxyAction binding, string toolName)> _hotkeyBindings;

        protected override void OnCreate()
        {
            base.OnCreate();
            LogUtil.Info($"{nameof(UISystem)}.{nameof(OnCreate)}");

            try
            {
                InitializeSystems();
                AddKeybindings();
            }
            catch (Exception ex)
            {
                LogUtil.Exception(ex);
            }
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();

            try
            {
                CheckHotKeys();
            }
            catch (Exception ex)
            {
                LogUtil.Exception(ex);
            }
        }

        private void InitializeSystems()
        {
            inputManager = GameManager.instance.inputManager;
            _uiView = GameManager.instance.userInterface.view.View;
            m_PrefabSystem = World.GetOrCreateSystemManaged<PrefabSystem>();
            m_GameScreenUISystem = World.GetOrCreateSystemManaged<GameScreenUISystem>();
            _hotkeyBindings = new List<(ProxyAction, string)>();
        }

        private ProxyAction CreateAndEnableBinding(string settingName)
        {
            var binding = Mod.ModSettings.GetAction(settingName);
            binding.shouldBeEnabled = true;
            return binding;
        }

        private void AddKeybindings()
        {
            RegisterKeybinding(nameof(ModSettings.OpenZonesKeyBinding), "Zones");
            RegisterKeybinding(nameof(ModSettings.OpenAreasKeyBinding), "Areas");
            RegisterKeybinding(nameof(ModSettings.OpenSignaturesKeyBinding), "Signatures");
            RegisterKeybinding(nameof(ModSettings.OpenRoadsKeyBinding), "Roads");
            RegisterKeybinding(nameof(ModSettings.OpenElectricityKeyBinding), "Electricity");
            RegisterKeybinding(nameof(ModSettings.OpenWaterAndSewageKeyBinding), "Water & Sewage");
            RegisterKeybinding(nameof(ModSettings.OpenHealthAndDeathcareKeyBinding), "Health & Deathcare");
            RegisterKeybinding(nameof(ModSettings.OpenGarbageManagementKeyBinding), "Garbage Management");
            RegisterKeybinding(nameof(ModSettings.OpenEducationAndResearchKeyBinding), "Education & Research");
            RegisterKeybinding(nameof(ModSettings.OpenFireAndRescueKeyBinding), "Fire & Rescue");
            RegisterKeybinding(nameof(ModSettings.OpenPoliceAndAdministrationKeyBinding), "Police & Administration");
            RegisterKeybinding(nameof(ModSettings.OpenTransportationKeyBinding), "Transportation");
            RegisterKeybinding(nameof(ModSettings.OpenParksAndRecreationKeyBinding), "Parks & Recreation");
            RegisterKeybinding(nameof(ModSettings.OpenCommunicationsKeyBinding), "Communications");
            RegisterKeybinding(nameof(ModSettings.OpenLandscapingKeyBinding), "Landscaping");
        }

        private void RegisterKeybinding(string settingName, string toolName)
        {
            var binding = CreateAndEnableBinding(settingName);
            _hotkeyBindings.Add((binding, toolName));
        }

        private void CheckHotKeys()
        {
            if (!inputManager.mouseOnScreen)
                return;

            foreach (var (binding, toolName) in _hotkeyBindings)
            {
                if (binding.WasPerformedThisFrame())
                {
                    _uiView.TriggerEvent("toolbar.selectAssetMenu", GetEventObject(toolName));
                }
            }
        }

        private object GetEventObject(string toolName)
        {
            EntityQuery assetMenuData = GetEntityQuery(ComponentType.ReadOnly<UIAssetMenuData>());
            NativeArray<Entity> menuEntities = assetMenuData.ToEntityArray(Allocator.Temp);
            Entity menuEntity = Entity.Null;

            foreach (Entity entity in menuEntities)
            {
                UIAssetMenuPrefab assetMenuPrefab = m_PrefabSystem.GetPrefab<UIAssetMenuPrefab>(entity);
                if (assetMenuPrefab.name == toolName)
                {
                    //LogUtil.Info($"Found Prefab: {assetMenuPrefab.name}");
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
            }; ;
        }
    }
}