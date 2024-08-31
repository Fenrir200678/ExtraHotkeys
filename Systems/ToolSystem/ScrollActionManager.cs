using Game.Tools;

namespace ExtraHotkeys
{
    public class ScrollActionManager
    {
        private readonly UIInputManager _uiInputManager;
        private readonly ModSettings _modSettings;
        private readonly ToolSystem _toolSystem;
        private readonly NetToolSystem _netToolSystem;
        private readonly TerrainToolSystem _terrainToolSystem;
        private readonly BrushManager _brushManager;
        private readonly ElevationManager _elevationManager;

        public ScrollActionManager(
            UIInputManager uiInputManager,
            ModSettings modSettings,
            ToolSystem m_toolSystem,
            NetToolSystem m_netToolSystem,
            TerrainToolSystem m_terrainToolSystem
            )
        {
            _uiInputManager = uiInputManager;
            _modSettings = modSettings;
            _toolSystem = m_toolSystem;
            _netToolSystem = m_netToolSystem;
            _terrainToolSystem = m_terrainToolSystem;
            _brushManager = new BrushManager(modSettings, uiInputManager, m_terrainToolSystem);
            _elevationManager = new ElevationManager(modSettings, uiInputManager, m_netToolSystem);

            LogUtil.Info($"{nameof(ScrollActionManager)} initialized");
        }

        public void CheckScrollWheelActions()
        {
            if (_toolSystem.activeTool is NetToolSystem)
                HandleNetToolScrollActions();
            else if (_toolSystem.activeTool is TerrainToolSystem)
                HandleTerrainToolScrollActions();
        }

        private void HandleNetToolScrollActions()
        {
            if (_uiInputManager.IsHoldingCtrl())
            {
                _uiInputManager.DisableCameraZoom(true);
                _elevationManager.OnElevationScroll();
            }
            else if (_uiInputManager.IsHoldingAlt())
            {
                _uiInputManager.DisableCameraZoom(true);
                _elevationManager.OnElevationStepScroll();
            }
            else
            {
                _uiInputManager.DisableCameraZoom(false);
            }
        }

        private void HandleTerrainToolScrollActions()
        {
            if (_uiInputManager.IsHoldingCtrl())
            {
                _uiInputManager.DisableCameraZoom(true);
                _brushManager.OnBrushSizeScroll();
            }
            else if (_uiInputManager.IsHoldingAlt())
            {
                _uiInputManager.DisableCameraZoom(true);
                _brushManager.OnBrushStrengthScroll();
            }
            else
            {
                _uiInputManager.DisableCameraZoom(false);
            }
        }
    }
}
