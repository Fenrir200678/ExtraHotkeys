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
        private readonly ToolSystem _toolSystem;
        private readonly NetToolSystem _netToolSystem;
        private readonly ZoneToolSystem _zoneToolSystem;
        private readonly List<(ProxyAction binding, string toolMode)> _toolModeBindings;

        public ToolModeManager(
            View uiView,
            UIInputManager uiInputManager,
            ModSettings modSettings,
            ToolSystem toolSystem,
            NetToolSystem netToolSystem,
            ZoneToolSystem zoneToolSystem
        )
        {
            _uiView = uiView;
            _uiInputManager = uiInputManager;
            _modSettings = modSettings;
            _toolSystem = toolSystem;
            _netToolSystem = netToolSystem;
            _zoneToolSystem = zoneToolSystem;
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
            RegisterKeybinding(nameof(_modSettings.UpdateElevationStep), "UpdateElevation");
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
                    if (toolMode == "UpdateElevation")
                    {
                        SetElevationStep();
                    }
                    else
                    {
                        SetToolMode(toolMode);
                    }
                }
            }
        }

        public void CheckScrollWheel()
        {
            if (!_uiInputManager.IsHoldingCtrl() || !(_toolSystem.activeTool is NetToolSystem))
            {
                _uiInputManager.DisableCameraZoom(false);
                return;
            }

            _uiInputManager.DisableCameraZoom(true);

            if (_uiInputManager.IsZoomingIn())
            {
                CycleNetToolMode(true);
            }
            else if (_uiInputManager.IsZoomingOut())
            {
                CycleNetToolMode(false);
            }
        }

        private void CycleNetToolMode(bool forward)
        {
            NetToolSystem.Mode newMode;
            if (forward)
            {
                newMode = _netToolSystem.mode == NetToolSystem.Mode.Replace ? 
                    NetToolSystem.Mode.Straight : (NetToolSystem.Mode)((int)_netToolSystem.mode + 1);
            }
            else
            {
                newMode = _netToolSystem.mode == NetToolSystem.Mode.Straight ? 
                    NetToolSystem.Mode.Replace : (NetToolSystem.Mode)((int)_netToolSystem.mode - 1);
            }

            _netToolSystem.mode = newMode;
            _uiView.TriggerEvent("tool.selectToolMode", (int)newMode);
            PlayUISound("select-item");
        }

        private void SetToolMode(string toolMode)
        {
            if (_toolSystem.activeTool is NetToolSystem netTool)
            {
                SetNetToolMode(netTool, GetToolModeString(toolMode));
            }
            else if (_toolSystem.activeTool is ZoneToolSystem zoneTool)
            {
                SetZoneToolMode(zoneTool, GetToolModeString(toolMode, 1));
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

        private void SetElevationStep()
        {
            if (_modSettings.EnableUpdateElevationSteps && _toolSystem.activeTool is NetToolSystem)
            {
                float newElevation = _netToolSystem.elevationStep / 2.0f;
                newElevation = newElevation < 1.25f ? 10f : newElevation;
                _uiView.TriggerEvent("tool.setElevationStep", newElevation);
            }
        }

        private static string GetToolModeString(string toolMode, int index = 0)
        {
            return toolMode.Contains("|") ? toolMode.Split('|')[index] : toolMode;
        }

        private void PlayUISound(string soundName)
        {
            _uiView.TriggerEvent("audio.playSound", soundName, 1);
        }
    }
}