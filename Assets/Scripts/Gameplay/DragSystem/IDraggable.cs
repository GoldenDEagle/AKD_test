using UnityEngine;

namespace Assets.Scripts.Gameplay.DragSystem
{
    public interface IDraggable
    {
        public void SetDesiredPosition(Vector2 targetPosition);

        public void StartDrag();

        public void StopDrag();

        public void EnableDrag(bool isEnabled);
    }
}
