using cohtml.Net;
using Game.Input;
using Game.Tools;
using System;
using System.Collections.Generic;

namespace ExtraHotkeys
{
    public class ToolSnapOptionsManager
    {
        private readonly View _uiView;
        private readonly UIInputManager _uiInputManager;
        private readonly ModSettings _modSettings;
        private readonly NetToolSystem _netToolSystem;
        private readonly List<(ProxyAction binding, string snapOption)> _snapOptionsBindings;

        public ToolSnapOptionsManager(
            View uiView,
            UIInputManager uiInputManager,
            ModSettings modSettings,
            NetToolSystem netToolSystem
            )
        {
            _uiView = uiView;
            _uiInputManager = uiInputManager;
            _modSettings = modSettings;
            _netToolSystem = netToolSystem;
            _snapOptionsBindings = new List<(ProxyAction, string)>();

            InitializeBindings();

            LogUtil.Info($"{nameof(ToolSnapOptionsManager)} initialized");
        }

        private void InitializeBindings()
        {
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
                    _uiView.TriggerEvent("tool.setSelectedSnapMask", (uint)GetSnapMask(snapOption));
                }
            }
        }

        private Snap GetSnapMask(string snapOption)
        {
            Snap selectedSnapValue = (Snap)Enum.Parse(typeof(Snap), snapOption);
            Snap currentSnapMask = _netToolSystem.selectedSnap;

            return currentSnapMask ^ selectedSnapValue; 
        }
    }
}