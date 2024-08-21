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
        private List<(ProxyAction binding, string toolName)> hotkeyBindings;

        protected override void OnCreate()
        {
            base.OnCreate();
            LogUtil.Info($"{nameof(UISystem)}.{nameof(OnCreate)}");

            try
            {
                InitializeSystems();
                RegisterKeyBindings();
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
                CheckHotKeysPressed();
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
            hotkeyBindings = new List<(ProxyAction, string)>();
        }

        private ProxyAction CreateAndEnableBinding(string settingName)
        {
            var binding = Mod.ModSettings.GetAction(settingName);
            binding.shouldBeEnabled = true;
            return binding;
        }

        private void RegisterKeyBindings()
        {
            AddHotkeyBinding(nameof(ModSettings.OpenRoadKeyBinding), "Roads");
            AddHotkeyBinding(nameof(ModSettings.OpenZoningBinding), "Zones");
            // Add more bindings here as needed
        }

        private void AddHotkeyBinding(string settingName, string toolName)
        {
            var binding = CreateAndEnableBinding(settingName);
            hotkeyBindings.Add((binding, toolName));
        }

        private void CheckHotKeysPressed()
        {
            if (!inputManager.mouseOnScreen)
                return;

            foreach (var (binding, toolName) in hotkeyBindings)
            {
                if (binding.WasPerformedThisFrame())
                {
                    OpenGameTool(toolName);
                }
            }
        }

        private void OpenGameTool(string toolName)
        {
            LogUtil.Info($"Opening {toolName} tool");
            Entity menuEntity = GetMenuEntity(toolName);
            var menuObject = new
            {
                __Type = menuEntity.GetType().ToString(),
                index = menuEntity.Index,
                version = menuEntity.Version
            };
            _uiView.TriggerEvent("toolbar.selectAssetMenu", menuObject);
        }

        private Entity GetMenuEntity(string toolName)
        {
            EntityQuery assetMenuData = GetEntityQuery(ComponentType.ReadOnly<UIAssetMenuData>());
            NativeArray<Entity> menuEntities = assetMenuData.ToEntityArray(Allocator.Temp);
            Entity menuEntity = Entity.Null;
            foreach (Entity entity in menuEntities)
            {
                UIAssetMenuPrefab assetMenuPrefab = m_PrefabSystem.GetPrefab<UIAssetMenuPrefab>(entity);
                if (assetMenuPrefab.name == toolName)
                {
                    menuEntity = entity;
                    break;
                }
            }
            menuEntities.Dispose();
            return menuEntity;
        }
    }
}