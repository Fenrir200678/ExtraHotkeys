using Game;
using Game.Audio;
using Game.Input;
using Game.Prefabs;
using Unity.Entities;
using UnityEngine.InputSystem;

namespace ExtraHotkeys
{
    public class UIInputManager
    {
        private readonly InputManager _gameInputManager;
        private readonly ModSettings _modSettings;

        private readonly ProxyAction m_MouseZoomAction;
        protected readonly ProxyActionMap m_CameraMap;

        private CameraController m_CameraController;

        public bool m_IsInProgress;
        public bool IsActive => m_IsInProgress;

        public enum WheelSensitivityFactor
        {
            Low = 1,
            Medium = 2,
            High = 3
        }

        public UIInputManager(
            InputManager gameInputManager,
            ModSettings modSettings
            )
        {
            _gameInputManager = gameInputManager;
            _modSettings = modSettings;

            m_CameraMap = _gameInputManager.FindActionMap("Camera");
            m_MouseZoomAction = m_CameraMap.FindAction("Zoom Mouse");

            m_IsInProgress = false;

            LogUtil.Info($"{nameof(UIInputManager)} initialized");
        }

        public ProxyAction GetAndEnableBinding(string settingName)
        {
            var binding = _modSettings.GetAction(settingName);
            binding.shouldBeEnabled = true;
            return binding;
        }

        public void DisableCameraZoom(bool isDisabled)
        {
            if (m_CameraController == null && CameraController.TryGet(out CameraController cameraController))
            {
                m_CameraController = cameraController;
            }

            m_CameraController.inputEnabled = !isDisabled;
        }

        public bool IsMouseOnScreen()
        {
            return _gameInputManager.mouseOnScreen;
        }

        public bool IsHoldingKey(Key key)
        {
            return Keyboard.current[key].isPressed;
        }

        public bool IsHoldingAlt()
        {
            return Keyboard.current[Key.LeftAlt].isPressed || Keyboard.current[Key.RightAlt].isPressed;
        }

        public bool IsHoldingCtrl()
        {
            return Keyboard.current[Key.LeftCtrl].isPressed || Keyboard.current[Key.RightCtrl].isPressed;
        }

        public bool IsZoomingIn(WheelSensitivityFactor sensitivityFactor = WheelSensitivityFactor.Medium)
        {
            float mouseZoomValue = m_MouseZoomAction.ReadValue<float>();
            return mouseZoomValue < -GetZoomFactor(sensitivityFactor);
        }

        public bool IsZoomingOut(WheelSensitivityFactor sensitivityFactor = WheelSensitivityFactor.Medium)
        {
            float mouseZoomValue = m_MouseZoomAction.ReadValue<float>();
            return mouseZoomValue > GetZoomFactor(sensitivityFactor);
        }

        private static float GetZoomFactor(WheelSensitivityFactor factor)
        {
            return factor switch
            {
                WheelSensitivityFactor.Low => 0.02f,
                WheelSensitivityFactor.High => 0.008f,
                _ => 0.013f,

            };
        }
    }
}