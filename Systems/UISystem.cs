//using cohtml.Net;
using Game;
using Game.Input;
using Game.Prefabs;
using Game.SceneFlow;
using Game.UI;
using Game.UI.InGame;

namespace ExtraHotkeys
{
    public partial class UISystem : UISystemBase
    {
        private InputManager inputManager;
        private PrefabSystem m_PrefabSystem;
        private GameScreenUISystem m_GameScreenUISystem;
        //private View _uiView;

        // Proxy actions for hotkey bindings
        private ProxyAction _openRoadsBinding;
        private ProxyAction _openZoningBinding;


        public override GameMode gameMode
        {
            get { return GameMode.Game; }
        }

        protected override void OnCreate()
        {
            base.OnCreate();
            LogUtil.Info($"{nameof(UISystem)}.{nameof(OnCreate)}");

            try
            {
                inputManager = GameManager.instance.inputManager;
                m_PrefabSystem = World.GetOrCreateSystemManaged<PrefabSystem>();
                m_GameScreenUISystem = World.GetOrCreateSystemManaged<GameScreenUISystem>();

                RegisterKeyBindings();
            }
            catch (System.Exception ex)
            {
                LogUtil.Exception(ex);
            }
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();

            try
            {
                CheckHotKeyPressed();
            }
            catch (System.Exception ex)
            {
                LogUtil.Exception(ex);
            }
        }

        private void RegisterKeyBindings()
        {
            // Hotkey bindings
            _openRoadsBinding = Mod.ModSettings.GetAction(nameof(ModSettings.OpenRoadKeyBinding));
            _openRoadsBinding.shouldBeEnabled = true;

            _openZoningBinding = Mod.ModSettings.GetAction(nameof(ModSettings.OpenZoningBinding));
            _openZoningBinding.shouldBeEnabled = true;

        }

        private void CheckHotKeyPressed()
        {
            if (_openRoadsBinding.WasPerformedThisFrame())
            {
                LogUtil.Info("Open road tools binding test");
            }

            if (_openZoningBinding.WasPerformedThisFrame())
            {
                LogUtil.Info("Open zoning tools binding test");
            }
        }
    }
}
