using Assets.Scripts.Services.Gameplay;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Gameplay
{
    public class GoalContainer : MonoBehaviour
    {
        [SerializeField] private int _itemsToEndGame = 3;
        [SerializeField] private Transform _containerTransform;

        private int _collectedItems = 0;
        private List<CollectableItem> _collectedItemsList = new List<CollectableItem>();

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
                if (_collectedItemsList.Contains(collectable)) return;

                collectable.WasCollected();
                collectable.transform.SetParent(_containerTransform, true);
                _collectedItems++;
                _collectedItemsList.Add(collectable);

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