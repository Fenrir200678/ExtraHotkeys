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
                // General and group translations
                { m_Setting.GetSettingsLocaleID(), ModAssemblyInfo.Title },
                { m_Setting.GetOptionLabelLocaleID(nameof(ModSettings.ResetBindings)), "Reset key bindings" },
                { m_Setting.GetOptionDescLocaleID(nameof(ModSettings.ResetBindings)), $"Reset all key bindings of the mod" },

                { m_Setting.GetOptionGroupLocaleID(ModSettings.kKeybindingGroup), "Tool Keybindings" },
                { m_Setting.GetOptionGroupLocaleID(ModSettings.kAbout), "About Mod" },


                // Keybinding translations (label / description)
                { m_Setting.GetOptionLabelLocaleID(nameof(ModSettings.OpenZonesKeyBinding)), "Zones" },
                { m_Setting.GetOptionDescLocaleID(nameof(ModSettings.OpenZonesKeyBinding)), "Open Zones tools" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ModSettings.OpenAreasKeyBinding)), "Areas" },
                { m_Setting.GetOptionDescLocaleID(nameof(ModSettings.OpenAreasKeyBinding)), "Open Areas tools" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ModSettings.OpenSignaturesKeyBinding)), "Signatures" },
                { m_Setting.GetOptionDescLocaleID(nameof(ModSettings.OpenSignaturesKeyBinding)), "Open Signatures tools" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ModSettings.OpenRoadsKeyBinding)), "Roads" },
                { m_Setting.GetOptionDescLocaleID(nameof(ModSettings.OpenRoadsKeyBinding)), "Open Roads tools" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ModSettings.OpenElectricityKeyBinding)), "Electricity" },
                { m_Setting.GetOptionDescLocaleID(nameof(ModSettings.OpenElectricityKeyBinding)), $"Open Electricity tools" },

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
