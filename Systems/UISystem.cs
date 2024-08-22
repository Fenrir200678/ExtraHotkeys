using cohtml.Net;
using Game.Input;
using Game.Prefabs;
using Game.SceneFlow;
using Game.Tools;
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
        private ToolSystem m_ToolSystem;
        private NetToolSystem m_NetToolSystem;
        private ZoneToolSystem m_ZoneToolSystem;
        private ModSettings ModSettings => Mod.ModSettings;

        // List for open tool windows bindings
        private List<(ProxyAction binding, string toolName)> _openToolWindowsBindings;

        // List for tool mode bindings
        private List<(ProxyAction binding, string toolMode)> _toolModeBindings;

        protected override void OnCreate()
        {
            base.OnCreate();
            LogUtil.Info($"{nameof(UISystem)}.{nameof(OnCreate)}");

            try
            {
                Initialize();
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
                if (ModSettings.EnableMod)
                {
                    if (!inputManager.mouseOnScreen)
                        return;

                    OnOpenToolWindowHotkeyPress();
                    OnToolModeHotkeyPress();
                }
            }
            catch (Exception ex)
            {
                LogUtil.Exception(ex);
            }
        }

        private void Initialize()
        {
            inputManager = GameManager.instance.inputManager;
            _uiView = GameManager.instance.userInterface.view.View;

            m_PrefabSystem = World.GetOrCreateSystemManaged<PrefabSystem>();
            m_GameScreenUISystem = World.GetOrCreateSystemManaged<GameScreenUISystem>();
            m_ToolSystem = World.GetOrCreateSystemManaged<ToolSystem>();
            m_NetToolSystem = World.GetOrCreateSystemManaged<NetToolSystem>();
            m_ZoneToolSystem = World.GetOrCreateSystemManaged<ZoneToolSystem>();

            _openToolWindowsBindings = new List<(ProxyAction, string)>();
            _toolModeBindings = new List<(ProxyAction, string)>();

            AddOpenToolsKeybindings();
            AddSetToolModeKeybindings();
        }

        private void AddOpenToolsKeybindings()
        {
            RegisterOpenToolsKeybinding(nameof(ModSettings.OpenZonesKeyBinding), "Zones");
            RegisterOpenToolsKeybinding(nameof(ModSettings.OpenAreasKeyBinding), "Areas");
            RegisterOpenToolsKeybinding(nameof(ModSettings.OpenSignaturesKeyBinding), "Signatures");
            RegisterOpenToolsKeybinding(nameof(ModSettings.OpenRoadsKeyBinding), "Roads");
            RegisterOpenToolsKeybinding(nameof(ModSettings.OpenElectricityKeyBinding), "Electricity");
            RegisterOpenToolsKeybinding(nameof(ModSettings.OpenWaterAndSewageKeyBinding), "Water & Sewage");
            RegisterOpenToolsKeybinding(nameof(ModSettings.OpenHealthAndDeathcareKeyBinding), "Health & Deathcare");
            RegisterOpenToolsKeybinding(nameof(ModSettings.OpenGarbageManagementKeyBinding), "Garbage Management");
            RegisterOpenToolsKeybinding(nameof(ModSettings.OpenEducationAndResearchKeyBinding), "Education & Research");
            RegisterOpenToolsKeybinding(nameof(ModSettings.OpenFireAndRescueKeyBinding), "Fire & Rescue");
            RegisterOpenToolsKeybinding(nameof(ModSettings.OpenPoliceAndAdministrationKeyBinding), "Police & Administration");
            RegisterOpenToolsKeybinding(nameof(ModSettings.OpenTransportationKeyBinding), "Transportation");
            RegisterOpenToolsKeybinding(nameof(ModSettings.OpenParksAndRecreationKeyBinding), "Parks & Recreation");
            RegisterOpenToolsKeybinding(nameof(ModSettings.OpenCommunicationsKeyBinding), "Communications");
            RegisterOpenToolsKeybinding(nameof(ModSettings.OpenLandscapingKeyBinding), "Landscaping");
        }

        private void AddSetToolModeKeybindings()
        {
            RegisterToolModeKeybinding(nameof(ModSettings.ToolMode1_Keybinding), "Straight|FloodFill");
            RegisterToolModeKeybinding(nameof(ModSettings.ToolMode2_Keybinding), "SimpleCurve|Marquee");
            RegisterToolModeKeybinding(nameof(ModSettings.ToolMode3_Keybinding), "ComplexCurve|Paint");
            RegisterToolModeKeybinding(nameof(ModSettings.ToolMode4_Keybinding), "Continuous");
            RegisterToolModeKeybinding(nameof(ModSettings.ToolMode5_Keybinding), "Grid");
            RegisterToolModeKeybinding(nameof(ModSettings.ToolMode6_Keybinding), "Replace");
        }

        private void RegisterOpenToolsKeybinding(string settingName, string toolName)
        {
            var binding = CreateAndEnableBinding(settingName);
            _openToolWindowsBindings.Add((binding, toolName));
        }

        private void RegisterToolModeKeybinding(string settingName, string toolMode)
        {
            var binding = CreateAndEnableBinding(settingName);
            _toolModeBindings.Add((binding, toolMode));
        }

        private ProxyAction CreateAndEnableBinding(string settingName)
        {
            var binding = Mod.ModSettings.GetAction(settingName);
            binding.shouldBeEnabled = true;
            return binding;
        }

        private void OnOpenToolWindowHotkeyPress()
        {
            foreach (var (binding, toolName) in _openToolWindowsBindings)
            {
                if (binding.WasPerformedThisFrame())
                {
                    _uiView.TriggerEvent("toolbar.selectAssetMenu", GetEventObject(toolName));
                }
            }
        }

        private void OnToolModeHotkeyPress()
        {
            string _toolMode = string.Empty;

            foreach (var (binding, toolMode) in _toolModeBindings)
            {
                if (binding.WasPerformedThisFrame())
                {
                    if (m_ToolSystem.activeTool is NetToolSystem)
                    {
                        _toolMode = GetToolModeString(toolMode);
                        SetToolMode((NetToolSystem.Mode)Enum.Parse(typeof(NetToolSystem.Mode), _toolMode));
                    }
                    else if (m_ToolSystem.activeTool is ZoneToolSystem)
                    {
                        _toolMode = GetToolModeString(toolMode, 1);
                        SetToolMode((ZoneToolSystem.Mode)Enum.Parse(typeof(ZoneToolSystem.Mode), _toolMode));
                    }
                }
            }
        }

        private static string GetToolModeString(string toolMode, int index = 0)
        {
            string _toolMode;

            // check if toolmode string contains a pipe. that is needed because the first 3 toolmodes share the same keybinding
            if (toolMode.Contains("|"))
            {
                string[] modes = toolMode.Split('|');
                _toolMode = modes[index];
            }
            else
            {
                _toolMode = toolMode;
            }

            return _toolMode;
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

        private void SetToolMode(object mode)
        {
            if (mode is NetToolSystem.Mode netToolMode)
            {
                m_NetToolSystem.mode = netToolMode;
                _uiView.TriggerEvent("tool.selectToolMode", (int)netToolMode);
            }

            if (mode is ZoneToolSystem.Mode zoneToolMode)
            {
                m_ZoneToolSystem.mode = zoneToolMode;
                _uiView.TriggerEvent("tool.selectToolMode", (int)zoneToolMode);
            }

        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            LogUtil.Info($"{nameof(UISystem)}.{nameof(OnDestroy)}");
        }
    }
}