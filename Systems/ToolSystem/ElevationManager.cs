using cohtml.Net;
using Game.SceneFlow;
using Game.Tools;
using System;

namespace ExtraHotkeys
{
    public class ElevationManager
    {
        private readonly ModSettings _modSettings;
        private readonly UIInputManager _uiInputManager;
        private readonly NetToolSystem _netToolSystem;
        private readonly View _uiView;

        private readonly float[] _elevationSteps = { 1.25f, 2.5f, 5f, 10f };

        public ElevationManager(ModSettings modSettings, UIInputManager uiInputManager, NetToolSystem netToolSystem)
        {
            _modSettings = modSettings;
            _uiInputManager = uiInputManager;
            _netToolSystem = netToolSystem;
            _uiView = GameManager.instance.userInterface.view.View;
        }

        public void OnElevationScroll()
        {
            if (!_modSettings.EnableElevationScroll) return;

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

        public void OnElevationStepScroll()
        {
            if (!_modSettings.EnableElevationStepScroll) return;

            int currentIndex = Array.IndexOf(_elevationSteps, _netToolSystem.elevationStep);

            if (_uiInputManager.IsZoomingIn())
            {
                IncreaseElevationStep(currentIndex);
            }
            else if (_uiInputManager.IsZoomingOut())
            {
                DecreaseElevationStep(currentIndex);
            }
        }

        private void IncreaseElevationStep(int currentIndex)
        {
            if (currentIndex < _elevationSteps.Length - 1)
            {
                SetElevationStep(_elevationSteps[currentIndex + 1]);
                PlayUISound("select-item");
            }
        }

        private void DecreaseElevationStep(int currentIndex)
        {
            if (currentIndex > 0)
            {
                SetElevationStep(_elevationSteps[currentIndex - 1]);
                PlayUISound("select-item");
            }
        }

        private void SetElevationStep(float newStep)
        {
            _uiView.TriggerEvent("tool.setElevationStep", newStep);
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
