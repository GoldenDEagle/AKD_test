using System;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Services.Gameplay
{
    public class GameplayService : IGameplayService
    {
        public event Action OnGameStarted;
        public event Action OnGameCompleted;

        public void EndGame()
        {
            OnGameCompleted?.Invoke();
        }

        public void ReloadGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void StartGame()
        {
            OnGameStarted?.Invoke();
        }
    }
}