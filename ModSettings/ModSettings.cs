using Colossal.IO.AssetDatabase;
using Game.Input;
using Game.Modding;
using Game.Settings;

namespace ExtraHotkeys
{
    [FileLocation(nameof(ExtraHotkeys))]
    [SettingsUIGroupOrder(kKeybindingGroup, kAbout)]
    [SettingsUIShowGroupName(kKeybindingGroup, kAbout)]

    public class ModSettings : ModSetting
    {
        public const string kKeybindingGroup = "Keybindings";
        public const string kAbout = "About";

        public ModSettings(IMod mod) : base(mod) { }

        // Keybindings
        // Zones
        [SettingsUIKeyboardBinding(BindingKeyboard.None, nameof(OpenZonesKeyBinding))]
        [SettingsUISection(kKeybindingGroup)]
        public ProxyBinding OpenZonesKeyBinding { get; set; }

        // Areas
        [SettingsUIKeyboardBinding(BindingKeyboard.None, nameof(OpenAreasKeyBinding))]
        [SettingsUISection(kKeybindingGroup)]
        public ProxyBinding OpenAreasKeyBinding { get; set; }

        // Signatures
        [SettingsUIKeyboardBinding(BindingKeyboard.None, nameof(OpenSignaturesKeyBinding))]
        [SettingsUISection(kKeybindingGroup)]
        public ProxyBinding OpenSignaturesKeyBinding { get; set; }


        // Roads
        [SettingsUIKeyboardBinding(BindingKeyboard.R, nameof(OpenRoadsKeyBinding))]
        [SettingsUISection(kKeybindingGroup)]
        public ProxyBinding OpenRoadsKeyBinding { get; set; }

        // Electricity
        [SettingsUIKeyboardBinding(BindingKeyboard.None, nameof(OpenElectricityKeyBinding))]
        [SettingsUISection(kKeybindingGroup)]
        public ProxyBinding OpenElectricityKeyBinding { get; set; }

        // WaterAndSewage
        [SettingsUIKeyboardBinding(BindingKeyboard.None, nameof(OpenWaterAndSewageKeyBinding))]
        [SettingsUISection(kKeybindingGroup)]
        public ProxyBinding OpenWaterAndSewageKeyBinding { get; set; }

        // HealthAndDeathcare
        [SettingsUIKeyboardBinding(BindingKeyboard.None, nameof(OpenHealthAndDeathcareKeyBinding))]
        [SettingsUISection(kKeybindingGroup)]
        public ProxyBinding OpenHealthAndDeathcareKeyBinding { get; set; }

        // GarbageManagement
        [SettingsUIKeyboardBinding(BindingKeyboard.None, nameof(OpenGarbageManagementKeyBinding))]
        [SettingsUISection(kKeybindingGroup)]
        public ProxyBinding OpenGarbageManagementKeyBinding { get; set; }

        // EducationAndResearch
        [SettingsUIKeyboardBinding(BindingKeyboard.None, nameof(OpenEducationAndResearchKeyBinding))]
        [SettingsUISection(kKeybindingGroup)]
        public ProxyBinding OpenEducationAndResearchKeyBinding { get; set; }

        // FireAndRescue
        [SettingsUIKeyboardBinding(BindingKeyboard.None, nameof(OpenFireAndRescueKeyBinding))]
        [SettingsUISection(kKeybindingGroup)]
        public ProxyBinding OpenFireAndRescueKeyBinding { get; set; }

        // PoliceAndAdministration
        [SettingsUIKeyboardBinding(BindingKeyboard.None, nameof(OpenPoliceAndAdministrationKeyBinding))]
        [SettingsUISection(kKeybindingGroup)]
        public ProxyBinding OpenPoliceAndAdministrationKeyBinding { get; set; }

        // Transportation
        [SettingsUIKeyboardBinding(BindingKeyboard.None, nameof(OpenTransportationKeyBinding))]
        [SettingsUISection(kKeybindingGroup)]
        public ProxyBinding OpenTransportationKeyBinding { get; set; }

        // ParksAndRecreation
        [SettingsUIKeyboardBinding(BindingKeyboard.None, nameof(OpenParksAndRecreationKeyBinding))]
        [SettingsUISection(kKeybindingGroup)]
        public ProxyBinding OpenParksAndRecreationKeyBinding { get; set; }

        // Communications
        [SettingsUIKeyboardBinding(BindingKeyboard.None, nameof(OpenCommunicationsKeyBinding))]
        [SettingsUISection(kKeybindingGroup)]
        public ProxyBinding OpenCommunicationsKeyBinding { get; set; }

        // Landscaping
        [SettingsUIKeyboardBinding(BindingKeyboard.None, nameof(OpenLandscapingKeyBinding))]
        [SettingsUISection(kKeybindingGroup)]
        public ProxyBinding OpenLandscapingKeyBinding { get; set; }


        // Reset key bindings
        [SettingsUISection(kKeybindingGroup)]
        public bool ResetBindings
        {
            set
            {
                LogUtil.Info("Reset key bindings");
                ResetKeyBindings();
            }
        }

        // About mod
        [SettingsUISection(kAbout)]
        public string ModVersion { get { return $"V{ModAssemblyInfo.Version}"; } }

        public override void SetDefaults()
        {
            throw new System.NotImplementedException();
        }
    }
}
