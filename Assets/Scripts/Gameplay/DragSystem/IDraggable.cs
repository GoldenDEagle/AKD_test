﻿using UnityEngine;

namespace Assets.Scripts.Gameplay.DragSystem
{
    public interface IDraggable
    {
        public void SetTargetPosition(Vector2 targetPosition);

        public void StartDrag();

        public void StopDrag();
    }
}
