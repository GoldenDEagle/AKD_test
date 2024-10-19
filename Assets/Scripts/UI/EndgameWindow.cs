using Assets.Scripts.Services.Gameplay;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.UI
{
    public class EndgameWindow : MonoBehaviour
    {
        [SerializeField] private Button _restartButton;
        [SerializeField] private RectTransform _window;

        private IGameplayService _gameplayService;

        [Inject]
        public void Construct(IGameplayService gameplayService)
        {
            _gameplayService = gameplayService;
        }

        private void OnEnable()
        {
            _restartButton.onClick.AddListener(RestartGame);
            _gameplayService.OnGameCompleted += ShowWindow;
        }

        private void OnDisable()
        {
            _restartButton.onClick.RemoveAllListeners();
            _gameplayService.OnGameCompleted -= ShowWindow;
        }

        private void ShowWindow()
        {
            _window.gameObject.SetActive(true);
        }

        private void RestartGame()
        {
            _gameplayService.ReloadGame();
        }
    }
}