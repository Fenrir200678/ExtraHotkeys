using Game.Input;

namespace ExtraHotkeys
{
    public class UIInputManager
    {
        private readonly InputManager _gameInputManager;
        private readonly ModSettings _modSettings;

        public UIInputManager(InputManager gameInputManager, ModSettings modSettings)
        {
            _gameInputManager = gameInputManager;
            _modSettings = modSettings;

            LogUtil.Info($"{nameof(UIInputManager)} initialized");
        }

        public bool IsMouseOnScreen()
        {
            return _gameInputManager.mouseOnScreen;
        }

        public ProxyAction GetAndEnableBinding(string settingName)
        {
            var binding = _modSettings.GetAction(settingName);
            binding.shouldBeEnabled = true;
            return binding;
        }
    }
}