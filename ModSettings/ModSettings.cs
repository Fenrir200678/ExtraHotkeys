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
        public const string kKeybindingGroup = "KeyBindings";
        public const string kAbout = "About";

        // key binding action names
        public const string aOpenRoad = "Open road tools";

        public ModSettings(IMod mod) : base(mod)
        {
        }

        [SettingsUIKeyboardBinding(BindingKeyboard.R, nameof(OpenRoadKeyBinding))]
        [SettingsUISection(kKeybindingGroup)]
        public ProxyBinding OpenRoadKeyBinding { get; set; }

        [SettingsUIKeyboardBinding(BindingKeyboard.E, nameof(OpenZoningBinding))]
        [SettingsUISection(kKeybindingGroup)]
        public ProxyBinding OpenZoningBinding { get; set; }

        [SettingsUISection(kKeybindingGroup)]
        public bool ResetBindings
        {
            set
            {
                LogUtil.Info("Reset key bindings");
                ResetKeyBindings();
            }
        }

        public override void SetDefaults()
        {
            throw new System.NotImplementedException();
        }

        [SettingsUISection(kAbout)]
        public string ModVersion { get { return $"V{ModAssemblyInfo.Version}"; } }
    }
}
