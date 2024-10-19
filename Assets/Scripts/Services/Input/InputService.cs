using System;
using UnityEngine;

namespace Assets.Scripts.Services.Input
{
    public class InputService : IInputService
    {
        private Vector2 _pointerPosition;
        public Vector2 PointerPosition => _pointerPosition;

        public event Action OnPointerDown;
        public event Action OnPointerUp;

        private PlayerControls _controls;

        public InputService()
        {
            _controls = new PlayerControls();
            _controls.Enable();

            _controls.Player.Drag.started += Drag_started;
            _controls.Player.Drag.canceled += Drag_canceled;
        }

        private void Drag_started(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            Debug.Log("Drag started");
        }

        private void Drag_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            Debug.Log("Drag ended");
        }

        public void Tick()
        {
            _pointerPosition = _controls.Player.PointerPosition.ReadValue<Vector2>();
        }

        public void Dispose()
        {
            _controls.Player.Drag.started -= Drag_started;
            _controls.Player.Drag.canceled -= Drag_canceled;
            _controls.Dispose();
        }
    }
}
