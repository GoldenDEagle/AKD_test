using Assets.Scripts.Gameplay.DragSystem;
using UnityEngine;

namespace Assets.Scripts.Gameplay
{
    [RequireComponent(typeof(DraggableComponent))]
    public class CollectableItem : MonoBehaviour
    {
        private IDraggable _draggableComponent;

        private void Awake()
        {
            _draggableComponent = GetComponent<DraggableComponent>();
        }

        public void WasCollected()
        {
            _draggableComponent.StopDrag();
            _draggableComponent.EnableDrag(false);
        }
    }
}