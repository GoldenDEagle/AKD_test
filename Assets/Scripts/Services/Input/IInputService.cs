using System;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Services.Input
{
    public interface IInputService : ITickable, IDisposable
    {
        public Vector2 PointerPosition { get; }

        public event Action OnPointerDown;
        public event Action OnPointerUp;
    }
}
