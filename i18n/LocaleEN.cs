using Colossal;
using System.Collections.Generic;

namespace ExtraHotkeys
{
    public class LocaleEN : IDictionarySource
    {
        private readonly ModSettings m_Setting;
        public LocaleEN(ModSettings setting)
        {
            m_Setting = setting;
        }
        public IEnumerable<KeyValuePair<string, string>> ReadEntries(IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                // General, section and group translations
                { m_Setting.GetSettingsLocaleID(), ModAssemblyInfo.Title },
                { m_Setting.GetOptionTabLocaleID(ModSettings.sGeneral), "General" },
                { m_Setting.GetOptionTabLocaleID(ModSettings.sToolKeybindings), "Tool Keybindings" },

                { m_Setting.GetOptionGroupLocaleID(ModSettings.gOpenToolsKeybindings), "Open Tool Windows" },
                { m_Setting.GetOptionGroupLocaleID(ModSettings.gToolModeKeybindings), "Set Tool Modes" },
                { m_Setting.GetOptionGroupLocaleID(ModSettings.gSnappingKeybindings), "Set Snapping Options" },

                { m_Setting.GetOptionGroupLocaleID(ModSettings.gGeneral), "General Settings" },
                { m_Setting.GetOptionGroupLocaleID(ModSettings.gToolRelated), "Quality Of Life Settings" },
                { m_Setting.GetOptionGroupLocaleID(ModSettings.gAbout), "About Mod" },


                // General settings translations
                { m_Setting.GetOptionLabelLocaleID(nameof(ModSettings.EnableMod)), "Enable mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(ModSettings.EnableMod)), "Enable or disable the mod" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ModSettings.ResetBindings)), "Reset all key bindings" },
                { m_Setting.GetOptionDescLocaleID(nameof(ModSettings.ResetBindings)), "Reset all key bindings of the mod" },


                // Tool related translations
                { m_Setting.GetOptionLabelLocaleID(nameof(ModSettings.EnableElevationScroll)), "Enable elevation scroll" },
                { m_Setting.GetOptionDescLocaleID(nameof(ModSettings.EnableElevationScroll)), "Enable to set elevation via Ctrl + scroll wheel." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ModSettings.EnableElevationStepScroll)), "Enable elevation steps scroll" },
                { m_Setting.GetOptionDescLocaleID(nameof(ModSettings.EnableElevationStepScroll)), "Enable to set elevation steps via Alt + scroll wheel." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ModSettings.EnableResetElevation)), "Enable elevation reset" },
                { m_Setting.GetOptionDescLocaleID(nameof(ModSettings.EnableResetElevation)), "Enable to reset elevation with Ctrl + right mouse click." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ModSettings.EnableBrushSizeScroll)), "Enable brush-size scroll" },
                { m_Setting.GetOptionDescLocaleID(nameof(ModSettings.EnableBrushSizeScroll)), "Enable to set brush-size via Ctrl + scroll wheel in terrain tool." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ModSettings.EnableBrushStrengthScroll)), "Enable brush-strength scroll" },
                { m_Setting.GetOptionDescLocaleID(nameof(ModSettings.EnableBrushStrengthScroll)), "Enable to set brush-strength via Alt + scroll wheel in terrain tool." },


                // Tool keybinding translations
                { m_Setting.GetOptionLabelLocaleID(nameof(ModSettings.OpenZonesKeyBinding)), "Zones" },
                { m_Setting.GetOptionDescLocaleID(nameof(ModSettings.OpenZonesKeyBinding)), "Open Zones tools" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ModSettings.OpenAreasKeyBinding)), "Areas" },
                { m_Setting.GetOptionDescLocaleID(nameof(ModSettings.OpenAreasKeyBinding)), "Open Areas tools" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ModSettings.OpenSignaturesKeyBinding)), "Signatures" },
                { m_Setting.GetOptionDescLocaleID(nameof(ModSettings.OpenSignaturesKeyBinding)), "Open Signatures tools" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ModSettings.OpenRoadsKeyBinding)), "Roads" },
                { m_Setting.GetOptionDescLocaleID(nameof(ModSettings.OpenRoadsKeyBinding)), "Open Roads tools" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ModSettings.OpenElectricityKeyBinding)), "Electricity" },
                { m_Setting.GetOptionDescLocaleID(nameof(ModSettings.OpenElectricityKeyBinding)), "Open Electricity tools" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ModSettings.OpenWaterAndSewageKeyBinding)), "Water & Sewage" },
                { m_Setting.GetOptionDescLocaleID(nameof(ModSettings.OpenWaterAndSewageKeyBinding)), "Open Water & Sewage tools" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ModSettings.OpenHealthAndDeathcareKeyBinding)), "Health & Deathcare" },
                { m_Setting.GetOptionDescLocaleID(nameof(ModSettings.OpenHealthAndDeathcareKeyBinding)), "Open Health & Deathcare tools" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ModSettings.OpenGarbageManagementKeyBinding)), "Garbage Management" },
                { m_Setting.GetOptionDescLocaleID(nameof(ModSettings.OpenGarbageManagementKeyBinding)), "Open Garbage Management tools" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ModSettings.OpenEducationAndResearchKeyBinding)), "Education & Research" },
                { m_Setting.GetOptionDescLocaleID(nameof(ModSettings.OpenEducationAndResearchKeyBinding)), "Open Education & Research tools" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ModSettings.OpenFireAndRescueKeyBinding)), "Fire & Rescue" },
                { m_Setting.GetOptionDescLocaleID(nameof(ModSettings.OpenFireAndRescueKeyBinding)), "Open Fire & Rescue tools" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ModSettings.OpenPoliceAndAdministrationKeyBinding)), "Police & Administration" },
                { m_Setting.GetOptionDescLocaleID(nameof(ModSettings.OpenPoliceAndAdministrationKeyBinding)), "Open Police & Administration tools" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ModSettings.OpenTransportationKeyBinding)), "Transportation" },
                { m_Setting.GetOptionDescLocaleID(nameof(ModSettings.OpenTransportationKeyBinding)), "Open Transportation tools" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ModSettings.OpenParksAndRecreationKeyBinding)), "Parks & Recreation" },
                { m_Setting.GetOptionDescLocaleID(nameof(ModSettings.OpenParksAndRecreationKeyBinding)), "Open Parks & Recreation tools" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ModSettings.OpenCommunicationsKeyBinding)), "Communications" },
                { m_Setting.GetOptionDescLocaleID(nameof(ModSettings.OpenCommunicationsKeyBinding)), "Open Communications tools" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ModSettings.OpenLandscapingKeyBinding)), "Landscaping" },
                { m_Setting.GetOptionDescLocaleID(nameof(ModSettings.OpenLandscapingKeyBinding)), "Open Landscaping tools" },


                // Toolmode keybinding translations
                { m_Setting.GetOptionLabelLocaleID(nameof(ModSettings.ToolMode1_Keybinding)), "Toolmode 1" },
                { m_Setting.GetOptionDescLocaleID(nameof(ModSettings.ToolMode1_Keybinding)), "Set toolmode straight for roads or fill for zones" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ModSettings.ToolMode2_Keybinding)), "Toolmode 2" },
                { m_Setting.GetOptionDescLocaleID(nameof(ModSettings.ToolMode2_Keybinding)), "Set toolmode simple curve for roads and marquee for zones" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ModSettings.ToolMode3_Keybinding)), "Toolmode 3" },
                { m_Setting.GetOptionDescLocaleID(nameof(ModSettings.ToolMode3_Keybinding)), "Set toolmode complex curve for roads and paint for zones" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ModSettings.ToolMode4_Keybinding)), "Toolmode 4" },
                { m_Setting.GetOptionDescLocaleID(nameof(ModSettings.ToolMode4_Keybinding)), "Set toolmode continuous for roads" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ModSettings.ToolMode5_Keybinding)), "Toolmode 5" },
                { m_Setting.GetOptionDescLocaleID(nameof(ModSettings.ToolMode5_Keybinding)), "Set toolmode grid for roads" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ModSettings.ToolMode6_Keybinding)), "Toolmode 6" },
                { m_Setting.GetOptionDescLocaleID(nameof(ModSettings.ToolMode6_Keybinding)), "Set toolmode replace for roads" },

              

                // Snapping options translations
                { m_Setting.GetOptionLabelLocaleID(nameof(ModSettings.SnapToExistingGeometryKeyBinding)), "Existing geometry" },
                { m_Setting.GetOptionDescLocaleID(nameof(ModSettings.SnapToExistingGeometryKeyBinding)), "Snap to existing geometry" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ModSettings.SnapToCellLengthKeyBinding)), "Zoning cell lenght" },
                { m_Setting.GetOptionDescLocaleID(nameof(ModSettings.SnapToCellLengthKeyBinding)), "Snap to zoning cell lenght" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ModSettings.SnapTo90DegreeAnglesKeyBinding)), "90 degree angles" },
                { m_Setting.GetOptionDescLocaleID(nameof(ModSettings.SnapTo90DegreeAnglesKeyBinding)), "Snap to 90 degree angles" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ModSettings.SnapToBuildingSidesKeyBinding)), "Building sides" },
                { m_Setting.GetOptionDescLocaleID(nameof(ModSettings.SnapToBuildingSidesKeyBinding)), "Snap to building sides" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ModSettings.SnapToGuidelinesKeyBinding)), "Guidelines" },
                { m_Setting.GetOptionDescLocaleID(nameof(ModSettings.SnapToGuidelinesKeyBinding)), "Snap to guidelines" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ModSettings.SnapToNearbyGeometryKeyBinding)), "Nearby geometry" },
                { m_Setting.GetOptionDescLocaleID(nameof(ModSettings.SnapToNearbyGeometryKeyBinding)), "Snap to nearby geometry" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ModSettings.SnapToZoneGridKeyBinding)), "Zone grid" },
                { m_Setting.GetOptionDescLocaleID(nameof(ModSettings.SnapToZoneGridKeyBinding)), "Snap to zone grid" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ModSettings.SnapToRoadSidesKeyBinding)), "Road sides" },
                { m_Setting.GetOptionDescLocaleID(nameof(ModSettings.SnapToRoadSidesKeyBinding)), "Snap to road sides" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ModSettings.ShowContourLinesKeyBinding)), "Contour lines" },
                { m_Setting.GetOptionDescLocaleID(nameof(ModSettings.ShowContourLinesKeyBinding)), "Show contour lines" },


                // About mod translations
                { m_Setting.GetOptionLabelLocaleID(nameof(ModSettings.ModVersion)), $"{ModAssemblyInfo.Title}, © 2024 by Fenrir" },
                { m_Setting.GetOptionDescLocaleID(nameof(ModSettings.ModVersion)), $"V{ModAssemblyInfo.Version}" },
            };
        }

        public void Unload()
        {

        }
    }
}
