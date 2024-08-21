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

        // Proxy actions for hotkey bindings
        private ProxyAction _openRoadsBinding;

        //private View _uiView;

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

                // Hotkey bindings
                _openRoadsBinding = Mod.ModSettings.GetAction(nameof(ModSettings.OpenRoadKeyBinding));
                _openRoadsBinding.shouldBeEnabled = true;

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
                if(_openRoadsBinding.WasPerformedThisFrame())
                {
                    LogUtil.Info("Open road tools binding test");
                }
            }
            catch (System.Exception ex)
            {
                LogUtil.Exception(ex);
            }
        }
    }
}
