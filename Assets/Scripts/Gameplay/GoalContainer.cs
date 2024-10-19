using Assets.Scripts.Services.Gameplay;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Gameplay
{
    public class GoalContainer : MonoBehaviour
    {
        [SerializeField] private int _itemsToEndGame = 3;

        private int _collectedItems = 0;

        private IGameplayService _gameplayService;

        [Inject]
        public void Construct(IGameplayService gameplayService)
        {
            _gameplayService = gameplayService;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out CollectableItem collectable))
            {
                collectable.WasCollected();
                _collectedItems++;

                if (_collectedItems >= _itemsToEndGame)
                {
                    AllItemsCollected();
                }
            }
        }

        private void AllItemsCollected()
        {
            _gameplayService.EndGame();
        }
    }
}