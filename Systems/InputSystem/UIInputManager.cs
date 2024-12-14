using Game;
using Game.Input;
using System;
using UnityEngine.InputSystem;

namespace ExtraHotkeys
{
    public class UIInputManager
    {
        private readonly InputManager _gameInputManager;
        private readonly ModSettings _modSettings;
        private readonly ProxyActionMap m_CameraMap;
        private CameraController m_CameraController;
        public bool m_IsInProgress;
        public bool IsActive => m_IsInProgress;

        public UIInputManager(
            InputManager gameInputManager,
            ModSettings modSettings
            )
        {
            _gameInputManager = gameInputManager ?? throw new ArgumentNullException(nameof(gameInputManager));
            _modSettings = modSettings ?? throw new ArgumentNullException(nameof(modSettings));
            m_CameraMap = _gameInputManager.FindActionMap("Camera");
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

        public bool IsHoldingAlt()
        {
            try
            {
                return Keyboard.current?.altKey?.isPressed == true;
            }
            catch (Exception ex)
            {
                LogUtil.Exception(ex);
                return false;
            }
        }

        public bool IsHoldingCtrl()
        {
            try
            {
                return Keyboard.current?.ctrlKey?.isPressed == true;
            }
            catch (Exception ex)
            {
                LogUtil.Exception(ex);
                return false;
            }
        }

        public bool IsZoomingIn()
        {
            try
            {
                if (Mouse.current == null) return false;
                return Mouse.current.scroll.ReadValue().y > 0;
            }
            catch (Exception ex)
            {
                LogUtil.Error($"Error in IsZoomingIn: {ex.Message}");
                return false;
            }
        }

        public bool IsZoomingOut()
        {
            try
            {
                if (Mouse.current == null) return false;
                return Mouse.current.scroll.ReadValue().y < 0;
            }
            catch (Exception ex)
            {
                LogUtil.Error($"Error in IsZoomingOut: {ex.Message}");
                return false;
            }
        }
    }
}