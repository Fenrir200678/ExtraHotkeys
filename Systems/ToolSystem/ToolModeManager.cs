using cohtml.Net;
using Game.Input;
using Game.Tools;
using System;
using System.Collections.Generic;

namespace ExtraHotkeys
{
    public class ToolModeManager
    {
        private readonly View _uiView;
        private readonly UIInputManager _uiInputManager;
        private readonly ModSettings _modSettings;
        private readonly ToolBaseSystem _toolBaseSystem;
        private readonly ToolSystem _toolSystem;
        private readonly NetToolSystem _netToolSystem;
        private readonly ZoneToolSystem _zoneToolSystem;
        private readonly List<(ProxyAction binding, string toolMode)> _toolModeBindings;

        public ToolModeManager(
            View uiView,
            UIInputManager uiInputManager,
            ModSettings modSettings,
            ToolBaseSystem toolBaseSystem,
            ToolSystem m_toolSystem,
            NetToolSystem m_netToolSystem,
            ZoneToolSystem m_zoneToolSystem
            )
        {
            _uiView = uiView;
            _uiInputManager = uiInputManager;
            _toolSystem = m_toolSystem;
            _modSettings = modSettings;
            _toolBaseSystem = toolBaseSystem;
            _netToolSystem = m_netToolSystem;
            _zoneToolSystem = m_zoneToolSystem;
            _toolModeBindings = new List<(ProxyAction, string)>();

            InitializeBindings();

            LogUtil.Info($"{nameof(ToolModeManager)} initialized");
        }

        private void InitializeBindings()
        {
            RegisterKeybinding(nameof(_modSettings.ToolMode1_Keybinding), "Straight|FloodFill");
            RegisterKeybinding(nameof(_modSettings.ToolMode2_Keybinding), "SimpleCurve|Marquee");
            RegisterKeybinding(nameof(_modSettings.ToolMode3_Keybinding), "ComplexCurve|Paint");
            RegisterKeybinding(nameof(_modSettings.ToolMode4_Keybinding), "Continuous");
            RegisterKeybinding(nameof(_modSettings.ToolMode5_Keybinding), "Grid");
            RegisterKeybinding(nameof(_modSettings.ToolMode6_Keybinding), "Replace");
        }

        private void RegisterKeybinding(string settingName, string toolMode)
        {
            var binding = _uiInputManager.GetAndEnableBinding(settingName);
            _toolModeBindings.Add((binding, toolMode));
        }

        public void CheckHotkeys()
        {
            foreach (var (binding, toolMode) in _toolModeBindings)
            {
                if (binding.WasPerformedThisFrame())
                {
                    SetToolMode(toolMode);
                }
            }
        }

        private void SetToolMode(string toolMode)
        {
            if (_toolSystem.activeTool is NetToolSystem netTool)
            {
                string _toolMode = GetToolModeString(toolMode);
                SetNetToolMode(netTool, _toolMode);
            }
            else if (_toolSystem.activeTool is ZoneToolSystem zoneTool)
            {
                string _toolMode = GetToolModeString(toolMode, 1);
                SetZoneToolMode(zoneTool, _toolMode);
            }
        }

        private void SetNetToolMode(NetToolSystem tool, string modeName)
        {
            if (Enum.TryParse<NetToolSystem.Mode>(modeName, out var mode))
            {
                tool.mode = mode;
                _uiView.TriggerEvent("tool.selectToolMode", (int)mode);
            }
            else
            {
                LogUtil.Warn($"Invalid mode name for NetToolSystem: {modeName}");
            }
        }

        private void SetZoneToolMode(ZoneToolSystem tool, string modeName)
        {
            if (Enum.TryParse<ZoneToolSystem.Mode>(modeName, out var mode))
            {
                tool.mode = mode;
                _uiView.TriggerEvent("tool.selectToolMode", (int)mode);
            }
            else
            {
                LogUtil.Warn($"Invalid mode name for ZoneToolSystem: {modeName}");
            }
        }

        private static string GetToolModeString(string toolMode, int index = 0)
        {
            if (toolMode.Contains("|"))
            {
                string[] modes = toolMode.Split('|');
                return modes[index];
            }
            return toolMode;
        }
    }
}