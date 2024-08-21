using cohtml.Net;
using Game;
using Game.Input;
using Game.Prefabs;
using Game.SceneFlow;
using Game.UI;
using Game.UI.InGame;
using System;

namespace ExtraHotkeys
{
    public partial class UISystem : UISystemBase
    {
        private InputManager inputManager;
        private PrefabSystem m_PrefabSystem;
        private GameScreenUISystem m_GameScreenUISystem;
        private View _uiView;

        // Proxy actions for hotkey bindings
        private ProxyAction _openRoadsBinding;
        private ProxyAction _openZoningBinding;

        protected override void OnCreate()
        {
            base.OnCreate();
            LogUtil.Info($"{nameof(UISystem)}.{nameof(OnCreate)}");

            try
            {
                InitializeSystems();
                RegisterKeyBindings();
            }
            catch (Exception ex)
            {
                LogUtil.Exception(ex);
            }
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();

            try
            {
                CheckHotKeysPressed();
            }
            catch (Exception ex)
            {
                LogUtil.Exception(ex);
            }
        }

        private void InitializeSystems()
        {
            inputManager = GameManager.instance.inputManager;
            m_PrefabSystem = World.GetOrCreateSystemManaged<PrefabSystem>();
            m_GameScreenUISystem = World.GetOrCreateSystemManaged<GameScreenUISystem>();
        }

        private ProxyAction CreateAndEnableBinding(string settingName)
        {
            var binding = Mod.ModSettings.GetAction(settingName);
            binding.shouldBeEnabled = true;
            return binding;
        }

        private void RegisterKeyBindings()
        {
            _openRoadsBinding = CreateAndEnableBinding(nameof(ModSettings.OpenRoadKeyBinding));
            _openZoningBinding = CreateAndEnableBinding(nameof(ModSettings.OpenZoningBinding));

        }

        private void CheckBinding(ProxyAction binding, Action callback)
        {
            if (binding.WasPerformedThisFrame())
            {
                callback.DynamicInvoke();
            }
        }

        private void CheckHotKeysPressed()
        {
            if (!inputManager.mouseOnScreen)
                return;

            CheckBinding(_openRoadsBinding, () => TestLog("Open road tools binding test"));
            CheckBinding(_openZoningBinding, () => TestLog("Open zoning tools binding test"));
        }

        private void TestLog(string message)
        {
            LogUtil.Info(message);
        }
    }
}
