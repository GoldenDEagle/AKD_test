using UnityEngine;

namespace Assets.Scripts.Gameplay.DragSystem
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class DraggableComponent : MonoBehaviour, IDraggable
    {
        private Rigidbody2D _rigidbody;
        private bool _isBeingDragged;
        private Vector2 _targetPosition;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            if (!_isBeingDragged) return;

            _rigidbody.MovePosition(_targetPosition);
        }

        public void StartDrag()
        {
            _isBeingDragged = true;
            _rigidbody.gravityScale = 0f;
        }

        public void StopDrag()
        {
            _isBeingDragged = false;
            _rigidbody.gravityScale = 1f;
        }

        public void SetTargetPosition(Vector2 targetPosition)
        {
            _targetPosition = targetPosition;
        }
    }
}