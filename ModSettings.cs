using Colossal.IO.AssetDatabase;
using Game.Input;
using Game.Modding;
using Game.Settings;

namespace ExtraHotkeys
{
    [FileLocation(nameof(ExtraHotkeys))]
    [SettingsUIGroupOrder(gOpenToolsKeybindings, gToolModeKeybindings, gSnappingKeybindings, gGeneral, gToolRelated, gAbout)]
    [SettingsUIShowGroupName(gOpenToolsKeybindings, gToolModeKeybindings, gSnappingKeybindings, gGeneral, gToolRelated, gAbout)]


    public class ModSettings : ModSetting
    {
        // Section names
        public const string sToolKeybindings = "Tool Keybindings";
        public const string sGeneral = "General";

        // Group names
        public const string gOpenToolsKeybindings = "Open tools";
        public const string gToolModeKeybindings = "Tool modes";
        public const string gSnappingKeybindings = "Snapping options";
        
        public const string gGeneral = "General";
        public const string gToolRelated = "Tool related";
        public const string gAbout = "About";

        public ModSettings(IMod mod) : base(mod) { }

        // Tool keybindings
        // Zones
        [SettingsUIKeyboardBinding(BindingKeyboard.None, nameof(OpenZonesKeyBinding))]
        [SettingsUISection(sToolKeybindings, gOpenToolsKeybindings)]
        public ProxyBinding OpenZonesKeyBinding { get; set; }

        // Areas
        [SettingsUIKeyboardBinding(BindingKeyboard.None, nameof(OpenAreasKeyBinding))]
        [SettingsUISection(sToolKeybindings, gOpenToolsKeybindings)]
        public ProxyBinding OpenAreasKeyBinding { get; set; }

        // Signatures
        [SettingsUIKeyboardBinding(BindingKeyboard.None, nameof(OpenSignaturesKeyBinding))]
        [SettingsUISection(sToolKeybindings, gOpenToolsKeybindings)]
        public ProxyBinding OpenSignaturesKeyBinding { get; set; }


        // Roads
        [SettingsUIKeyboardBinding(BindingKeyboard.None, nameof(OpenRoadsKeyBinding))]
        [SettingsUISection(sToolKeybindings, gOpenToolsKeybindings)]
        public ProxyBinding OpenRoadsKeyBinding { get; set; }

        // Electricity
        [SettingsUIKeyboardBinding(BindingKeyboard.None, nameof(OpenElectricityKeyBinding))]
        [SettingsUISection(sToolKeybindings, gOpenToolsKeybindings)]
        public ProxyBinding OpenElectricityKeyBinding { get; set; }

        // WaterAndSewage
        [SettingsUIKeyboardBinding(BindingKeyboard.None, nameof(OpenWaterAndSewageKeyBinding))]
        [SettingsUISection(sToolKeybindings, gOpenToolsKeybindings)]
        public ProxyBinding OpenWaterAndSewageKeyBinding { get; set; }

        // HealthAndDeathcare
        [SettingsUIKeyboardBinding(BindingKeyboard.None, nameof(OpenHealthAndDeathcareKeyBinding))]
        [SettingsUISection(sToolKeybindings, gOpenToolsKeybindings)]
        public ProxyBinding OpenHealthAndDeathcareKeyBinding { get; set; }

        // GarbageManagement
        [SettingsUIKeyboardBinding(BindingKeyboard.None, nameof(OpenGarbageManagementKeyBinding))]
        [SettingsUISection(sToolKeybindings, gOpenToolsKeybindings)]
        public ProxyBinding OpenGarbageManagementKeyBinding { get; set; }

        // EducationAndResearch
        [SettingsUIKeyboardBinding(BindingKeyboard.None, nameof(OpenEducationAndResearchKeyBinding))]
        [SettingsUISection(sToolKeybindings, gOpenToolsKeybindings)]
        public ProxyBinding OpenEducationAndResearchKeyBinding { get; set; }

        // FireAndRescue
        [SettingsUIKeyboardBinding(BindingKeyboard.None, nameof(OpenFireAndRescueKeyBinding))]
        [SettingsUISection(sToolKeybindings, gOpenToolsKeybindings)]
        public ProxyBinding OpenFireAndRescueKeyBinding { get; set; }

        // PoliceAndAdministration
        [SettingsUIKeyboardBinding(BindingKeyboard.None, nameof(OpenPoliceAndAdministrationKeyBinding))]
        [SettingsUISection(sToolKeybindings, gOpenToolsKeybindings)]
        public ProxyBinding OpenPoliceAndAdministrationKeyBinding { get; set; }

        // Transportation
        [SettingsUIKeyboardBinding(BindingKeyboard.None, nameof(OpenTransportationKeyBinding))]
        [SettingsUISection(sToolKeybindings, gOpenToolsKeybindings)]
        public ProxyBinding OpenTransportationKeyBinding { get; set; }

        // ParksAndRecreation
        [SettingsUIKeyboardBinding(BindingKeyboard.None, nameof(OpenParksAndRecreationKeyBinding))]
        [SettingsUISection(sToolKeybindings, gOpenToolsKeybindings)]
        public ProxyBinding OpenParksAndRecreationKeyBinding { get; set; }

        // Communications
        [SettingsUIKeyboardBinding(BindingKeyboard.None, nameof(OpenCommunicationsKeyBinding))]
        [SettingsUISection(sToolKeybindings, gOpenToolsKeybindings)]
        public ProxyBinding OpenCommunicationsKeyBinding { get; set; }

        // Landscaping
        [SettingsUIKeyboardBinding(BindingKeyboard.None, nameof(OpenLandscapingKeyBinding))]
        [SettingsUISection(sToolKeybindings, gOpenToolsKeybindings)]
        public ProxyBinding OpenLandscapingKeyBinding { get; set; }



        // Tool mode keybindings
        // Straight for net tools or fill for zone tools
        [SettingsUIKeyboardBinding(BindingKeyboard.None, nameof(ToolMode1_Keybinding))]
        [SettingsUISection(sToolKeybindings, gToolModeKeybindings)]
        public ProxyBinding ToolMode1_Keybinding { get; set; }

        // Simple curve for net tools or marquee for zone tools
        [SettingsUIKeyboardBinding(BindingKeyboard.None, nameof(ToolMode2_Keybinding))]
        [SettingsUISection(sToolKeybindings, gToolModeKeybindings)]
        public ProxyBinding ToolMode2_Keybinding { get; set; }

        // Complex curve for net tools or paint for zone tools
        [SettingsUIKeyboardBinding(BindingKeyboard.None, nameof(ToolMode3_Keybinding))]
        [SettingsUISection(sToolKeybindings, gToolModeKeybindings)]
        public ProxyBinding ToolMode3_Keybinding { get; set; }

        // Continuous 
        [SettingsUIKeyboardBinding(BindingKeyboard.None, nameof(ToolMode4_Keybinding))]
        [SettingsUISection(sToolKeybindings, gToolModeKeybindings)]
        public ProxyBinding ToolMode4_Keybinding { get; set; }

        // Grid
        [SettingsUIKeyboardBinding(BindingKeyboard.None, nameof(ToolMode5_Keybinding))]
        [SettingsUISection(sToolKeybindings, gToolModeKeybindings)]
        public ProxyBinding ToolMode5_Keybinding { get; set; }

        // Replace
        [SettingsUIKeyboardBinding(BindingKeyboard.None, nameof(ToolMode6_Keybinding))]
        [SettingsUISection(sToolKeybindings, gToolModeKeybindings)]
        public ProxyBinding ToolMode6_Keybinding { get; set; }


        // Snapping options
        // Snap to exising geometry
        [SettingsUIKeyboardBinding(BindingKeyboard.None, nameof(SnapToExistingGeometryKeyBinding))]
        [SettingsUISection(sToolKeybindings, gSnappingKeybindings)]
        public ProxyBinding SnapToExistingGeometryKeyBinding { get; set; }

        // Snap to zoning cell lenght
        [SettingsUIKeyboardBinding(BindingKeyboard.None, nameof(SnapToCellLengthKeyBinding))]
        [SettingsUISection(sToolKeybindings, gSnappingKeybindings)]
        public ProxyBinding SnapToCellLengthKeyBinding { get; set; }

        // Snap to 90 degree angles
        [SettingsUIKeyboardBinding(BindingKeyboard.None, nameof(SnapTo90DegreeAnglesKeyBinding))]
        [SettingsUISection(sToolKeybindings, gSnappingKeybindings)]
        public ProxyBinding SnapTo90DegreeAnglesKeyBinding { get; set; }

        // Snap to sides of a building
        [SettingsUIKeyboardBinding(BindingKeyboard.None, nameof(SnapToBuildingSidesKeyBinding))]
        [SettingsUISection(sToolKeybindings, gSnappingKeybindings)]
        public ProxyBinding SnapToBuildingSidesKeyBinding { get; set; }

        // Snap to guidelines
        [SettingsUIKeyboardBinding(BindingKeyboard.None, nameof(SnapToGuidelinesKeyBinding))]
        [SettingsUISection(sToolKeybindings, gSnappingKeybindings)]
        public ProxyBinding SnapToGuidelinesKeyBinding { get; set; }

        // Snap to nearby geometry
        [SettingsUIKeyboardBinding(BindingKeyboard.None, nameof(SnapToNearbyGeometryKeyBinding))]
        [SettingsUISection(sToolKeybindings, gSnappingKeybindings)]
        public ProxyBinding SnapToNearbyGeometryKeyBinding { get; set; }

        // Snap to zone grid
        [SettingsUIKeyboardBinding(BindingKeyboard.None, nameof(SnapToZoneGridKeyBinding))]
        [SettingsUISection(sToolKeybindings, gSnappingKeybindings)]
        public ProxyBinding SnapToZoneGridKeyBinding { get; set; }

        // Snap to the sides of a road
        [SettingsUIKeyboardBinding(BindingKeyboard.None, nameof(SnapToRoadSidesKeyBinding))]
        [SettingsUISection(sToolKeybindings, gSnappingKeybindings)]
        public ProxyBinding SnapToRoadSidesKeyBinding { get; set; }

        // Show contour lines
        [SettingsUIKeyboardBinding(BindingKeyboard.None, nameof(ShowContourLinesKeyBinding))]
        [SettingsUISection(sToolKeybindings, gSnappingKeybindings)]
        public ProxyBinding ShowContourLinesKeyBinding { get; set; }


        // General settings
        // Enable mod
        [SettingsUISection(sGeneral, gGeneral)]
        public bool EnableMod { get; set; } = true;

        // Reset key bindings
        [SettingsUISection(sGeneral, gGeneral)]
        public bool ResetBindings
        {
            set
            {
                LogUtil.Info("Reset key bindings");
                ResetKeyBindings();
            }
        }

        // Tool related settings
        // Enable elevation scroll (Ctrl + scroll wheel)
        [SettingsUISection(sGeneral, gToolRelated)]
        public bool EnableElevationScroll { get; set; } = false;

        // Enable elevation steps (Alt + scroll wheel)
        [SettingsUISection(sGeneral, gToolRelated)]
        public bool EnableElevationStepScroll { get; set; } = false;

        // Enable reset elevation (Alt + right click)
        [SettingsUISection(sGeneral, gToolRelated)]
        public bool EnableResetElevation { get; set; } = false;

        // Hidden elevation scroll key bindings
        [SettingsUIMouseBinding(BindingMouse.Right, nameof(ResetElevation), ctrl: true)]
        [SettingsUIHidden]
        public ProxyBinding ResetElevation { get; set; }

        // Enable brush size scroll (Crtl + scroll wheel)
        [SettingsUISection(sGeneral, gToolRelated)]
        public bool EnableBrushSizeScroll { get; set; } = false;

        // Enable brush strengh scroll (Alt + scroll wheel)
        [SettingsUISection(sGeneral, gToolRelated)]
        public bool EnableBrushStrenghScroll { get; set; } = false;



        // About mod
        [SettingsUISection(sGeneral, gAbout)]
        public string ModVersion { get { return $"V{ModAssemblyInfo.Version}"; } }

        public override void SetDefaults()
        {
            throw new System.NotImplementedException();
        }
    }
}
