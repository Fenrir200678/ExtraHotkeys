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
        private readonly ObjectToolSystem _objectToolSystem;
        private readonly ToolSystem _toolSystem;
        private readonly View _uiView;

        public BrushManager(ModSettings modSettings, UIInputManager uiInputManager, TerrainToolSystem terrainToolSystem, ObjectToolSystem objectToolSystem, ToolSystem toolSystem)
        {
            _modSettings = modSettings;
            _uiInputManager = uiInputManager;
            _terrainToolSystem = terrainToolSystem;
            _objectToolSystem = objectToolSystem;
            _toolSystem = toolSystem;
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
            if (!_modSettings.EnableBrushStrengthScroll) return;

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
            float currentSize = GetCurrentBrushSize();
            float increment = GetBrushSizeIncrement(currentSize);
            float newSize = Math.Min(currentSize + increment, MAX_BRUSH_SIZE);
            SetBrushSize(newSize);
            PlayUISound("increase-elevation");
        }

        private void DecreaseBrushSize()
        {
            float currentSize = GetCurrentBrushSize();
            float decrement = GetBrushSizeIncrement(currentSize - 1);  // -1 to handle edge cases
            float newSize = Math.Max(currentSize - decrement, MIN_BRUSH_SIZE);
            SetBrushSize(newSize);
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
            float currentStrength = GetCurrentBrushStrength();
            float increment = GetBrushStrengthIncrement(currentStrength);
            float newStrength = Math.Min(currentStrength + increment, MAX_BRUSH_STRENGTH);
            SetBrushStrength(newStrength);
            PlayUISound("increase-elevation");
        }

        private void DecreaseBrushStrength()
        {
            float currentStrength = GetCurrentBrushStrength();
            float decrement = GetBrushStrengthDecrement(currentStrength);
            float newStrength = Math.Max(currentStrength - decrement, MIN_BRUSH_STRENGTH);
            SetBrushStrength(newStrength);
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

        private float GetCurrentBrushSize()
        {
            return IsTerrainToolActive() ? _terrainToolSystem.brushSize : _objectToolSystem.brushSize;
        }

        private float GetCurrentBrushStrength()
        {
            return IsTerrainToolActive() ? _terrainToolSystem.brushStrength : _objectToolSystem.brushStrength;
        }

        private void SetBrushSize(float newSize)
        {
            _uiView.TriggerEvent("tool.setBrushSize", newSize);
        }

        private void SetBrushStrength(float newStrength)
        {
            _uiView.TriggerEvent("tool.setBrushStrength", newStrength);
        }

        private bool IsTerrainToolActive()
        {
            return _toolSystem.activeTool is TerrainToolSystem;
        }

        private void PlayUISound(string soundName)
        {
            _uiView.TriggerEvent("audio.playSound", soundName, 1);
        }
    }
}