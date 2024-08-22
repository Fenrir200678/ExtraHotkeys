using cohtml.Net;
using ExtraHotkeys;
using Game.Input;
using Game.Prefabs;
using Game.Tools;
using System;
using System.Collections.Generic;

namespace ExtraHotkeys
{
    public class ToolSnapOptionsManager
    {
        private readonly View _uiView;
        private readonly PrefabSystem _prefabSystem;
        private readonly ToolBaseSystem _toolBaseSystem;
        private readonly UIInputManager _uiInputManager;
        private readonly ModSettings _modSettings;
        private readonly List<(ProxyAction binding, string snapOption)> _snapOptionsBindings;

        public ToolSnapOptionsManager(
            View uiView, 
            PrefabSystem prefabSystem, 
            ToolBaseSystem toolBaseSystem, 
            UIInputManager uiInputManager, 
            ModSettings modSettings
            )
        {
            _uiView = uiView;
            _prefabSystem = prefabSystem;
            _toolBaseSystem = toolBaseSystem;
            _uiInputManager = uiInputManager;
            _modSettings = modSettings;
            _snapOptionsBindings = new List<(ProxyAction, string)>();

            InitializeBindings();

            LogUtil.Info($"{nameof(ToolSnapOptionsManager)} initialized");
        }

        private void InitializeBindings()
        {
            RegisterKeybinding(nameof(_modSettings.ToggleAllSnappingKeyBinding), "All");
            RegisterKeybinding(nameof(_modSettings.SnapToExistingGeometryKeyBinding), "ExistingGeometry");
            RegisterKeybinding(nameof(_modSettings.SnapToCellLengthKeyBinding), "CellLength");
            RegisterKeybinding(nameof(_modSettings.SnapTo90DegreeAnglesKeyBinding), "StraightDirection"); // ?
            RegisterKeybinding(nameof(_modSettings.SnapToBuildingSidesKeyBinding), "ObjectSide"); // ?
            RegisterKeybinding(nameof(_modSettings.SnapToGuidelinesKeyBinding), "GuideLines");
            RegisterKeybinding(nameof(_modSettings.SnapToNearbyGeometryKeyBinding), "NearbyGeometry");
            RegisterKeybinding(nameof(_modSettings.SnapToZoneGridKeyBinding), "ZoneGrid");
            RegisterKeybinding(nameof(_modSettings.SnapToRoadSidesKeyBinding), "NetSide");
            RegisterKeybinding(nameof(_modSettings.ShowContourLinesKeyBinding), "ContourLines");
        }

        private void RegisterKeybinding(string settingName, string snapOption)
        {
            var binding = _uiInputManager.GetAndEnableBinding(settingName);
            _snapOptionsBindings.Add((binding, snapOption));
        }

        public void CheckHotkeys()
        {
            foreach (var (binding, snapOption) in _snapOptionsBindings)
            {
                if (binding.WasPerformedThisFrame())
                {
                    SetSnapOption(snapOption);
                }
            }
        }

        private void SetSnapOption(string snapOption)
        {
            LogUtil.Info($"Snapoption {snapOption}");
            Snap snapValue = (Snap)Enum.Parse(typeof(Snap), snapOption);
            LogUtil.Info($"SnapValue: {snapValue} / {(uint)snapValue}");
            /*if (Enum.TryParse<Snap>(snapOption, out var maskValue))
            {
                LogUtil.Info($"Setting snap mask to: {maskValue} / {(uint)maskValue}");
                _uiView.TriggerEvent("tool.setSelectedSnapMask", (uint)maskValue);
            }
            else
            {
                LogUtil.Warn($"Failed to parse snap option: {snapOption}");
            }
            */

        }
    }
}