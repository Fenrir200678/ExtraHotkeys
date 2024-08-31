using cohtml.Net;
using Game.SceneFlow;
using Game.Tools;
using System;

namespace ExtraHotkeys
{
    public class BrushManager
    {
        private const float MIN_BRUSH_SIZE = 10f;
        private const float MAX_BRUSH_SIZE = 1000f;
        private const float MIN_BRUSH_STRENGTH = 0.01f;
        private const float MAX_BRUSH_STRENGTH = 1.00f;

        private readonly ModSettings _modSettings;
        private readonly UIInputManager _uiInputManager;
        private readonly TerrainToolSystem _terrainToolSystem;
        private readonly View _uiView;

        public BrushManager(ModSettings modSettings, UIInputManager uiInputManager, TerrainToolSystem terrainToolSystem)
        {
            _modSettings = modSettings;
            _uiInputManager = uiInputManager;
            _terrainToolSystem = terrainToolSystem;
            _uiView = GameManager.instance.userInterface.view.View;
        }

        public void OnBrushSizeScroll()
        {
            if (!_modSettings.EnableBrushSizeScroll) return;

            if (_uiInputManager.IsZoomingIn())
            {
                IncreaseBrushSize();
            }
            else if (_uiInputManager.IsZoomingOut())
            {
                DecreaseBrushSize();
            }
        }

        public void OnBrushStrengthScroll()
        {
            if (!_modSettings.EnableBrushStrenghScroll) return;

            if (_uiInputManager.IsZoomingIn())
            {
                IncreaseBrushStrength();
            }
            else if (_uiInputManager.IsZoomingOut())
            {
                DecreaseBrushStrength();
            }
        }

        private void IncreaseBrushSize()
        {
            float increment = GetBrushSizeIncrement(_terrainToolSystem.brushSize);
            _terrainToolSystem.brushSize = Math.Min(_terrainToolSystem.brushSize + increment, MAX_BRUSH_SIZE);
            PlayUISound("increase-elevation");
        }

        private void DecreaseBrushSize()
        {
            float decrement = GetBrushSizeIncrement(_terrainToolSystem.brushSize - 1);  // -1 to handle edge cases
            _terrainToolSystem.brushSize = Math.Max(_terrainToolSystem.brushSize - decrement, MIN_BRUSH_SIZE);
            PlayUISound("decrease-elevation");
        }

        private float GetBrushSizeIncrement(float currentSize)
        {
            if (currentSize < 100) return 10f;
            if (currentSize < 500) return 50f;
            return 100f;
        }

        private void IncreaseBrushStrength()
        {
            float increment = GetBrushStrengthIncrement(_terrainToolSystem.brushStrength);
            _terrainToolSystem.brushStrength = Math.Min(_terrainToolSystem.brushStrength + increment, MAX_BRUSH_STRENGTH);
            PlayUISound("increase-elevation");
        }

        private void DecreaseBrushStrength()
        {
            float decrement = GetBrushStrengthDecrement(_terrainToolSystem.brushStrength);
            _terrainToolSystem.brushStrength = Math.Max(_terrainToolSystem.brushStrength - decrement, MIN_BRUSH_STRENGTH);
            PlayUISound("decrease-elevation");
        }

        private float GetBrushStrengthIncrement(float currentStrength)
        {
            if (currentStrength < 0.09f) return 0.01f;
            if (currentStrength < 1f) return 0.05f;
            return 0f;  // Already at max strength
        }

        private float GetBrushStrengthDecrement(float currentStrength)
        {
            if (currentStrength <= 0.10f) return 0.01f;
            return 0.05f;
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