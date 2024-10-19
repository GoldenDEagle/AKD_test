using Assets.Scripts.Services.Gameplay;
using Assets.Scripts.Services.Input;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Gameplay.DragSystem
{
    public class SceneDragSystem : MonoBehaviour
    {
        [SerializeField] private LayerMask _draggableLayer;

        private IDraggable _currentlyDraggedObject;
        private Camera _camera;

        private IInputService _inputService;
        private IGameplayService _gameplayService;

        [Inject]
        public void Construct(IInputService inputService, IGameplayService gameplayService)
        {
            _inputService = inputService;
            _gameplayService = gameplayService;
        }

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void OnEnable()
        {
            _inputService.OnPointerDown += OnDragAttempted;
            _inputService.OnPointerUp += OnDragEnded;
        }

        private void OnDisable()
        {
            _inputService.OnPointerDown -= OnDragAttempted;
            _inputService.OnPointerUp -= OnDragEnded;
        }

        private void Update()
        {
            if (_currentlyDraggedObject == null) return;

            _currentlyDraggedObject.SetDesiredPosition(_camera.ScreenToWorldPoint(_inputService.PointerPosition));
        }

        private void OnDragAttempted()
        {
            RaycastHit2D hit = Physics2D.Raycast(_camera.ScreenToWorldPoint(_inputService.PointerPosition), Vector2.zero, _draggableLayer);

            if (hit == false) return;

            if (hit.collider.TryGetComponent(out IDraggable draggedObject))
            {
                _currentlyDraggedObject = draggedObject;
                _currentlyDraggedObject.StartDrag();
            }
        }

        private void OnDragEnded()
        {
            if (_currentlyDraggedObject == null) return;

            _currentlyDraggedObject.StopDrag();
            _currentlyDraggedObject = null;
        }
    }
}
