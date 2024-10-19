using Assets.Scripts.Services.Gameplay;
using Cysharp.Threading.Tasks;
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
            MoveTruck().Forget();
        }

        private async UniTaskVoid MoveTruck()
        {
            // couldn't resist to use one magic number :)
            int targetTime = 1000;
            int timer = 0;

            while (timer < targetTime)
            {
                await UniTask.Delay(1);
                timer++;
                transform.position += Vector3.right * _moveSpeed;
            }

            Destroy(gameObject);
        }
    }
}