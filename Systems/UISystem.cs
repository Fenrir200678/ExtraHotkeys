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
        private PrefabSystem m_prefabSystem;
        private ToolSystem m_toolSystem;
        private ToolBaseSystem m_ToolBaseSystem;
        private NetToolSystem m_netToolSystem;
        private ZoneToolSystem m_zoneToolSystem;
        private GameScreenUISystem m_gameScreenUISystem;

        private UIInputManager _uiInputManager;
        private ToolWindowManager _toolWindowManager;
        private ToolModeManager _toolModeManager;
        private ToolSnapOptionsManager _toolSnapOptionsManager;

        private ModSettings ModSettings => Mod.ModSettings;

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
                if (ModSettings.EnableMod)
                {
                    if (!_uiInputManager.IsMouseOnScreen())
                        return;

                    _toolWindowManager.CheckHotkeys();
                    _toolModeManager.CheckHotkeys();
                    _toolSnapOptionsManager.CheckHotkeys();
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
            _uiView = GameManager.instance.userInterface.view.View;

            m_prefabSystem = World.GetOrCreateSystemManaged<PrefabSystem>();
            m_toolSystem = World.GetOrCreateSystemManaged<ToolSystem>();
            m_ToolBaseSystem = World.GetOrCreateSystemManaged<ToolBaseSystem>();
            m_netToolSystem = World.GetOrCreateSystemManaged<NetToolSystem>();
            m_zoneToolSystem = World.GetOrCreateSystemManaged<ZoneToolSystem>();
            m_gameScreenUISystem = World.GetOrCreateSystemManaged<GameScreenUISystem>();

            _uiInputManager = new UIInputManager(inputManager, ModSettings);
            _toolWindowManager = new ToolWindowManager(_uiView, m_prefabSystem, _uiInputManager, ModSettings);
            _toolModeManager = new ToolModeManager(_uiView, m_toolSystem, m_netToolSystem, _uiInputManager, m_zoneToolSystem, ModSettings, m_ToolBaseSystem);
            _toolSnapOptionsManager = new ToolSnapOptionsManager(_uiView, m_prefabSystem, m_ToolBaseSystem, _uiInputManager, ModSettings);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            LogUtil.Info($"{nameof(UISystem)}.{nameof(OnDestroy)}");
        }
    }
}