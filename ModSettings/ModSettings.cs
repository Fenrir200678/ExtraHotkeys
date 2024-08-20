using Colossal.IO.AssetDatabase;
using Game.Input;
using Game.Modding;
using Game.Settings;
using Game.UI;
using Game.UI.Widgets;
using System.Collections.Generic;

namespace ExtraHotkeys
{
    [FileLocation(nameof(ExtraHotkeys))]
    [SettingsUIGroupOrder(kButtonGroup, kToggleGroup, kSliderGroup, kDropdownGroup, kKeybindingGroup)]
    [SettingsUIShowGroupName(kButtonGroup, kToggleGroup, kSliderGroup, kDropdownGroup, kKeybindingGroup)]
    [SettingsUIKeyboardAction(Mod.kVectorActionName, ActionType.Vector2, usages: new string[] { Usages.kMenuUsage, "TestUsage" }, interactions: new string[] { "UIButton" }, processors: new string[] { "ScaleVector2(x=100,y=100)" })]
    [SettingsUIKeyboardAction(Mod.kAxisActionName, ActionType.Axis, usages: new string[] { Usages.kMenuUsage, "TestUsage" }, interactions: new string[] { "UIButton" })]
    [SettingsUIKeyboardAction(Mod.kButtonActionName, ActionType.Button, usages: new string[] { Usages.kMenuUsage, "TestUsage" }, interactions: new string[] { "UIButton" })]
    [SettingsUIGamepadAction(Mod.kButtonActionName, ActionType.Button, usages: new string[] { Usages.kMenuUsage, "TestUsage" }, interactions: new string[] { "UIButton" })]
    [SettingsUIMouseAction(Mod.kButtonActionName, ActionType.Button, usages: new string[] { Usages.kMenuUsage, "TestUsage" }, interactions: new string[] { "UIButton" })]
    public class ModSettings : ModSetting
    {
        public const string kSection = "Main";

        public const string kButtonGroup = "Button";
        public const string kToggleGroup = "Toggle";
        public const string kSliderGroup = "Slider";
        public const string kDropdownGroup = "Dropdown";
        public const string kKeybindingGroup = "KeyBinding";

        public ModSettings(IMod mod) : base(mod)
        {
            LogUtil.Info($"{nameof(ModSettings)}.{nameof(ModSettings)}");
            SetDefaults();
        }

        [SettingsUISection(kSection, kButtonGroup)]
        public bool Button { set { LogUtil.Info("Button clicked"); } }

        [SettingsUIButton]
        [SettingsUIConfirmation]
        [SettingsUISection(kSection, kButtonGroup)]
        public bool ButtonWithConfirmation { set { LogUtil.Info("ButtonWithConfirmation clicked"); } }

        [SettingsUISection(kSection, kToggleGroup)]
        public bool Toggle { get; set; }

        [SettingsUISlider(min = 0, max = 100, step = 1, scalarMultiplier = 1, unit = Unit.kDataMegabytes)]
        [SettingsUISection(kSection, kSliderGroup)]
        public int IntSlider { get; set; }

        [SettingsUIDropdown(typeof(ModSettings), nameof(GetIntDropdownItems))]
        [SettingsUISection(kSection, kDropdownGroup)]
        public int IntDropdown { get; set; }

        [SettingsUISection(kSection, kDropdownGroup)]
        public SomeEnum EnumDropdown { get; set; } = SomeEnum.Value1;

        [SettingsUIKeyboardBinding(BindingKeyboard.Q, Mod.kButtonActionName, shift: true)]
        [SettingsUISection(kSection, kKeybindingGroup)]
        public ProxyBinding KeyboardBinding { get; set; }

        [SettingsUIMouseBinding(BindingMouse.Forward, Mod.kButtonActionName)]
        [SettingsUISection(kSection, kKeybindingGroup)]
        public ProxyBinding MouseBinding { get; set; }

        [SettingsUIGamepadBinding(BindingGamepad.Cross, Mod.kButtonActionName)]
        [SettingsUISection(kSection, kKeybindingGroup)]
        public ProxyBinding GamepadBinding { get; set; }


        [SettingsUIKeyboardBinding(BindingKeyboard.DownArrow, AxisComponent.Negative, Mod.kAxisActionName, shift: true)]
        [SettingsUISection(kSection, kKeybindingGroup)]
        public ProxyBinding FloatBindingNegative { get; set; }

        [SettingsUIKeyboardBinding(BindingKeyboard.UpArrow, AxisComponent.Positive, Mod.kAxisActionName, shift: true)]
        [SettingsUISection(kSection, kKeybindingGroup)]
        public ProxyBinding FloatBindingPositive { get; set; }

        [SettingsUIKeyboardBinding(BindingKeyboard.S, Vector2Component.Down, Mod.kVectorActionName, shift: true)]
        [SettingsUISection(kSection, kKeybindingGroup)]
        public ProxyBinding Vector2BindingDown { get; set; }

        [SettingsUIKeyboardBinding(BindingKeyboard.W, Vector2Component.Up, Mod.kVectorActionName, shift: true)]
        [SettingsUISection(kSection, kKeybindingGroup)]
        public ProxyBinding Vector2BindingUp { get; set; }

        [SettingsUIKeyboardBinding(BindingKeyboard.A, Vector2Component.Left, Mod.kVectorActionName, shift: true)]
        [SettingsUISection(kSection, kKeybindingGroup)]
        public ProxyBinding Vector2BindingLeft { get; set; }

        [SettingsUIKeyboardBinding(BindingKeyboard.D, Vector2Component.Right, Mod.kVectorActionName, shift: true)]
        [SettingsUISection(kSection, kKeybindingGroup)]
        public ProxyBinding Vector2BindingRight { get; set; }

        [SettingsUISection(kSection, kKeybindingGroup)]
        public bool ResetBindings
        {
            set
            {
                LogUtil.Info("Reset key bindings");
                ResetKeyBindings();
            }
        }


        public DropdownItem<int>[] GetIntDropdownItems()
        {
            var items = new List<DropdownItem<int>>();

            for (var i = 0; i < 3; i += 1)
            {
                items.Add(new DropdownItem<int>()
                {
                    value = i,
                    displayName = i.ToString(),
                });
            }

            return items.ToArray();
        }

        public override void SetDefaults()
        {
            throw new System.NotImplementedException();
        }

        public enum SomeEnum
        {
            Value1,
            Value2,
            Value3,
        }
    }
}
