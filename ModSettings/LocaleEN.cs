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
                { m_Setting.GetSettingsLocaleID(), ModAssemblyInfo.Title },
                { m_Setting.GetOptionGroupLocaleID(ModSettings.kKeybindingGroup), "Tool Keybindings" },
                { m_Setting.GetOptionGroupLocaleID(ModSettings.kAbout), "About mod" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ModSettings.OpenRoadKeyBinding)), "Open road tools" },
                { m_Setting.GetOptionDescLocaleID(nameof(ModSettings.OpenRoadKeyBinding)), $"Keyboard binding for opening road tools" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ModSettings.ModVersion)), $"{ModAssemblyInfo.Title}, © 2024 by Fenrir" },
                { m_Setting.GetOptionDescLocaleID(nameof(ModSettings.ModVersion)), $"V{ModAssemblyInfo.Version}" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ModSettings.ResetBindings)), "Reset key bindings" },
                { m_Setting.GetOptionDescLocaleID(nameof(ModSettings.ResetBindings)), $"Reset all key bindings of the mod" },

                { m_Setting.GetBindingMapLocaleID(), ModAssemblyInfo.Title },
            };
        }

        public void Unload()
        {

        }
    }
}
