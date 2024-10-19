using UnityEngine;

namespace Assets.Scripts.Gameplay.DragSystem
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class DraggableComponent : MonoBehaviour, IDraggable
    {
        [SerializeField] private float _dragFollowStrength = 1f;

        private Rigidbody2D _rigidbody;
        private bool _isBeingDragged;
        private Vector2 _desiredPosition;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            if (!_isBeingDragged) return;

            var targetPosition = Vector2.Lerp(_rigidbody.position, _desiredPosition, _dragFollowStrength * Time.fixedDeltaTime);
            _rigidbody.MovePosition(targetPosition);
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

        public void SetDesiredPosition(Vector2 desiredPosition)
        {
            _desiredPosition = desiredPosition;
        }

        public void EnableDrag(bool isEnabled)
        {
            enabled = isEnabled;
        }
    }
}