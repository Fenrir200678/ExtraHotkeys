using cohtml.Net;
using Game.Tools;
using System;

namespace ExtraHotkeys
{
    public class ScrollActionManager
    {
        private readonly View _uiView;
        private readonly UIInputManager _uiInputManager;
        private readonly ModSettings _modSettings;
        private readonly ToolSystem _toolSystem;
        private readonly NetToolSystem _netToolSystem;
        private readonly TerrainToolSystem _terrainToolSystem;

        private readonly float[] _elevationSteps = { 1.25f, 2.5f, 5f, 10f };

        public ScrollActionManager(
            View uiView,
            UIInputManager uiInputManager,
            ModSettings modSettings,
            ToolSystem m_toolSystem,
            NetToolSystem m_netToolSystem,
            TerrainToolSystem m_terrainToolSystem
            )
        {
            _uiView = uiView;
            _uiInputManager = uiInputManager;
            _modSettings = modSettings;
            _toolSystem = m_toolSystem;
            _netToolSystem = m_netToolSystem;
            _terrainToolSystem = m_terrainToolSystem;

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
                OnElevationScroll();
            }
            else if (_uiInputManager.IsHoldingAlt())
            {
                _uiInputManager.DisableCameraZoom(true);
                OnElevationStepScroll();
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
                OnBrushSizeScroll(); // todo
            }
            else if (_uiInputManager.IsHoldingAlt())
            {
                _uiInputManager.DisableCameraZoom(true);
                OnBrushStrengthScroll(); // todo
            }
            else
            {
                _uiInputManager.DisableCameraZoom(false);
            }
        }

        private void OnElevationScroll()
        {
            if (_modSettings.EnableElevationScroll)
            {
                if (_uiInputManager.IsZoomingIn())
                {
                    _netToolSystem.ElevationUp();
                    PlayUISound("increase-elevation");
                }
                else if (_uiInputManager.IsZoomingOut())
                {
                    _netToolSystem.ElevationDown();
                    PlayUISound("decrease-elevation");
                }
            }
        }

        private void OnElevationStepScroll()
        {
            if (_modSettings.EnableElevationStepScroll)
            {
                int currentIndex = Array.IndexOf(_elevationSteps, _netToolSystem.elevationStep);

                if (_uiInputManager.IsZoomingIn() && currentIndex < _elevationSteps.Length - 1)
                {
                    float newStep = _elevationSteps[currentIndex + 1];
                    _uiView.TriggerEvent("tool.setElevationStep", newStep);
                    PlayUISound("increase-elevation");
                }
                else if (_uiInputManager.IsZoomingOut() && currentIndex > 0)
                {
                    float newStep = _elevationSteps[currentIndex - 1];
                    _uiView.TriggerEvent("tool.setElevationStep", newStep);
                    PlayUISound("decrease-elevation");
                }
            }
        }

        private void OnBrushSizeScroll()
        {
            if (_modSettings.EnableBrushSizeScroll)
            {
                if (_uiInputManager.IsZoomingIn())
                {
                    switch (_terrainToolSystem.brushSize)
                    {
                        case < 100:
                            _terrainToolSystem.brushSize += 10f;
                            break;
                        case < 500:
                            _terrainToolSystem.brushSize += 50f;
                            break;
                        case < 1000:
                            _terrainToolSystem.brushSize += 100f;
                            break;
                        case >= 1000:
                            _terrainToolSystem.brushSize = 1000f;
                            break;
                    }

                    PlayUISound("increase-elevation");
                }
                else if (_uiInputManager.IsZoomingOut())
                {
                    switch (_terrainToolSystem.brushSize)
                    {
                        case <= 10:
                            _terrainToolSystem.brushSize = 10f;
                            break;
                        case < 100:
                            _terrainToolSystem.brushSize -= 10f;
                            break;
                        case < 500:
                            _terrainToolSystem.brushSize -= 50f;
                            break;
                        case <= 1000:
                            _terrainToolSystem.brushSize -= 100f;
                            break;
                    }
                    PlayUISound("decrease-elevation");
                }
            }
        }

        private void OnBrushStrengthScroll()
        {
            if (_modSettings.EnableBrushStrenghScroll)
            {
                if (_uiInputManager.IsZoomingIn())
                {
                    switch (_terrainToolSystem.brushStrength)
                    {
                        case < 0.09f:
                            _terrainToolSystem.brushStrength += 0.01f;
                            break;
                        case < 1f:
                            _terrainToolSystem.brushStrength += 0.05f;
                            break;
                        case >= 1f:
                            _terrainToolSystem.brushStrength = 1.00f;
                            break;
                    }
                    PlayUISound("increase-elevation");
                }
                else if (_uiInputManager.IsZoomingOut())
                {
                    switch (_terrainToolSystem.brushStrength)
                    {
                        case <= 0.01f:
                            _terrainToolSystem.brushStrength = 0.01f;
                            break;
                        case <= 0.10f:
                            _terrainToolSystem.brushStrength -= 0.01f;
                            break;
                        case <= 1f:
                            _terrainToolSystem.brushStrength -= 0.05f;
                            break;
                    }
                    PlayUISound("decrease-elevation");
                }
            }
        }

        private void PlayUISound(string soundName)
        {
            // open-panel
            // select-item (tool mode select & set elevation step)
            // increase-elevation
            // decrease-elevation

            _uiView.TriggerEvent("audio.playSound", soundName, 1);
        }
    }
}
