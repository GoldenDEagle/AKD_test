using Assets.Scripts.Services.Gameplay;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Gameplay
{
    public class PickupTruck : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 1f;

        private IGameplayService _gameplayService;

        [Inject]
        public void Construct(IGameplayService gameplayService)
        {
            _gameplayService = gameplayService;
        }

        private void OnEnable()
        {
            _gameplayService.OnGameCompleted += LauchTruck;
        }

        private void OnDisable()
        {
            _gameplayService.OnGameCompleted -= LauchTruck;
        }


        private void LauchTruck()
        {

        }
    }
}