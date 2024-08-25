using cohtml.Net;
using Game.Prefabs;
using Game.SceneFlow;
using Game.Tools;
using Game.UI;
using Game.UI.InGame;
using System;
using Unity.Entities;

namespace ExtraHotkeys
{
    public partial class UISystem : UISystemBase
    {
        private View _uiView;
        private ModSettings ModSettings => Mod.ModSettings;

        private PrefabSystem m_prefabSystem;
        private ToolBaseSystem m_ToolBaseSystem;
        private ToolSystem m_toolSystem;
        private NetToolSystem m_netToolSystem;
        private ZoneToolSystem m_zoneToolSystem;
        private GameScreenUISystem m_gameScreenUISystem;

        private UIInputManager _uiInputManager;
        private ToolWindowManager _toolWindowManager;
        private ToolModeManager _toolModeManager;
        private ToolSnapOptionsManager _toolSnapOptionsManager;

        private GameManager _gameManager;


        protected override void OnCreate()
        {
            base.OnCreate();
            LogUtil.Info($"{nameof(UISystem)}.{nameof(OnCreate)}");

            try
            {
                Initialize();
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
                if (ModSettings.EnableMod && _gameManager.gameMode == Game.GameMode.Game)
                {
                    if (!_uiInputManager.IsMouseOnScreen())
                        return;

                    _toolWindowManager?.CheckHotkeys();
                    _toolModeManager?.CheckHotkeys();
                    _toolModeManager?.CheckScrollWheel();
                    _toolSnapOptionsManager?.CheckHotkeys();
                }
            }
            catch (Exception ex)
            {
                LogUtil.Exception(ex);
            }
        }

        private void Initialize()
        {
            var inputManager = GameManager.instance.inputManager;
            _gameManager = GameManager.instance;

            _uiView = GameManager.instance.userInterface.view.View;

            m_prefabSystem = World.GetOrCreateSystemManaged<PrefabSystem>();
            m_ToolBaseSystem = World.GetOrCreateSystemManaged<ToolBaseSystem>();
            m_toolSystem = World.GetOrCreateSystemManaged<ToolSystem>();
            m_netToolSystem = World.GetOrCreateSystemManaged<NetToolSystem>();
            m_zoneToolSystem = World.GetOrCreateSystemManaged<ZoneToolSystem>();
            m_gameScreenUISystem = World.GetOrCreateSystemManaged<GameScreenUISystem>();

            _uiInputManager = new UIInputManager(
                inputManager,
                ModSettings
                );

            _toolWindowManager = new ToolWindowManager(
                _uiView,
                _uiInputManager,
                ModSettings,
                m_prefabSystem
                );

            _toolModeManager = new ToolModeManager(
                _uiView,
                _uiInputManager,
                ModSettings,
                m_ToolBaseSystem,
                m_toolSystem,
                m_netToolSystem,
                m_zoneToolSystem
                );

            _toolSnapOptionsManager = new ToolSnapOptionsManager(
                _uiView,
                _uiInputManager,
                ModSettings,
                m_netToolSystem
                );
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            LogUtil.Info($"{nameof(UISystem)}.{nameof(OnDestroy)}");
        }
    }
}