using Colossal;
using Game.Input;
using Game.Settings;
using Game.UI.Widgets;
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
                { m_Setting.GetOptionTabLocaleID(ModSettings.kSection), "Main" },

                { m_Setting.GetOptionGroupLocaleID(ModSettings.kButtonGroup), "Buttons" },
                { m_Setting.GetOptionGroupLocaleID(ModSettings.kToggleGroup), "Toggle" },
                { m_Setting.GetOptionGroupLocaleID(ModSettings.kSliderGroup), "Sliders" },
                { m_Setting.GetOptionGroupLocaleID(ModSettings.kDropdownGroup), "Dropdowns" },
                { m_Setting.GetOptionGroupLocaleID(ModSettings.kKeybindingGroup), "Key bindings" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ModSettings.Button)), "Button" },
                { m_Setting.GetOptionDescLocaleID(nameof(ModSettings.Button)), $"Simple single button. It should be bool property with only setter or use [{nameof(SettingsUIButtonAttribute)}] to make button from bool property with setter and getter" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ModSettings.ButtonWithConfirmation)), "Button with confirmation" },
                { m_Setting.GetOptionDescLocaleID(nameof(ModSettings.ButtonWithConfirmation)), $"Button can show confirmation message. Use [{nameof(SettingsUIConfirmationAttribute)}]" },
                { m_Setting.GetOptionWarningLocaleID(nameof(ModSettings.ButtonWithConfirmation)), "is it confirmation text which you want to show here?" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ModSettings.Toggle)), "Toggle" },
                { m_Setting.GetOptionDescLocaleID(nameof(ModSettings.Toggle)), $"Use bool property with setter and getter to get toggable option" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ModSettings.IntSlider)), "Int slider" },
                { m_Setting.GetOptionDescLocaleID(nameof(ModSettings.IntSlider)), $"Use int property with getter and setter and [{nameof(SettingsUISliderAttribute)}] to get int slider" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ModSettings.IntDropdown)), "Int dropdown" },
                { m_Setting.GetOptionDescLocaleID(nameof(ModSettings.IntDropdown)), $"Use int property with getter and setter and [{nameof(SettingsUIDropdownAttribute)}(typeof(SomeType), nameof(SomeMethod))] to get int dropdown: Method must be static or instance of your setting class with 0 parameters and returns {typeof(DropdownItem<int>).Name}" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ModSettings.EnumDropdown)), "Simple enum dropdown" },
                { m_Setting.GetOptionDescLocaleID(nameof(ModSettings.EnumDropdown)), $"Use any enum property with getter and setter to get enum dropdown" },

                { m_Setting.GetEnumValueLocaleID(ModSettings.SomeEnum.Value1), "Value 1" },
                { m_Setting.GetEnumValueLocaleID(ModSettings.SomeEnum.Value2), "Value 2" },
                { m_Setting.GetEnumValueLocaleID(ModSettings.SomeEnum.Value3), "Value 3" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ModSettings.KeyboardBinding)), "Keyboard binding" },
                { m_Setting.GetOptionDescLocaleID(nameof(ModSettings.KeyboardBinding)), $"Keyboard binding of Button input action" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ModSettings.MouseBinding)), "Mouse binding" },
                { m_Setting.GetOptionDescLocaleID(nameof(ModSettings.MouseBinding)), $"Mouse binding of Button input action" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ModSettings.GamepadBinding)), "Gamepad binding" },
                { m_Setting.GetOptionDescLocaleID(nameof(ModSettings.GamepadBinding)), $"Gamepad binding of Button input action" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ModSettings.FloatBindingNegative)), "Negative binding" },
                { m_Setting.GetOptionDescLocaleID(nameof(ModSettings.FloatBindingNegative)), $"Negative component of Axis input action" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ModSettings.FloatBindingPositive)), "Positive binding" },
                { m_Setting.GetOptionDescLocaleID(nameof(ModSettings.FloatBindingPositive)), $"Positive component of Axis input action" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ModSettings.Vector2BindingDown)), "Keyboard binding down" },
                { m_Setting.GetOptionDescLocaleID(nameof(ModSettings.Vector2BindingDown)), $"Down component of Vector input action" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ModSettings.Vector2BindingUp)), "Keyboard binding up" },
                { m_Setting.GetOptionDescLocaleID(nameof(ModSettings.Vector2BindingUp)), $"Up component of Vector input action" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ModSettings.Vector2BindingLeft)), "Keyboard binding left" },
                { m_Setting.GetOptionDescLocaleID(nameof(ModSettings.Vector2BindingLeft)), $"Left component of Vector input action" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ModSettings.Vector2BindingRight)), "Keyboard binding right" },
                { m_Setting.GetOptionDescLocaleID(nameof(ModSettings.Vector2BindingRight)), $"Right component of Vector input action" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ModSettings.ResetBindings)), "Reset key bindings" },
                { m_Setting.GetOptionDescLocaleID(nameof(ModSettings.ResetBindings)), $"Reset all key bindings of the mod" },

                { m_Setting.GetBindingKeyLocaleID(Mod.kButtonActionName), "Button key" },

                { m_Setting.GetBindingKeyLocaleID(Mod.kAxisActionName, AxisComponent.Negative), "Negative key" },
                { m_Setting.GetBindingKeyLocaleID(Mod.kAxisActionName, AxisComponent.Positive), "Positive key" },

                { m_Setting.GetBindingKeyLocaleID(Mod.kVectorActionName, Vector2Component.Down), "Down key" },
                { m_Setting.GetBindingKeyLocaleID(Mod.kVectorActionName, Vector2Component.Up), "Up key" },
                { m_Setting.GetBindingKeyLocaleID(Mod.kVectorActionName, Vector2Component.Left), "Left key" },
                { m_Setting.GetBindingKeyLocaleID(Mod.kVectorActionName, Vector2Component.Right), "Right key" },

                { m_Setting.GetBindingMapLocaleID(), ModAssemblyInfo.Title },
            };
        }

        public void Unload()
        {

        }
    }
}
