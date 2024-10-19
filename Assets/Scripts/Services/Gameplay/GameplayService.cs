using UnityEngine;

namespace Assets.Scripts.Services.Gameplay
{
    public class GameplayService : IGameplayService
    {
        public void EndGame()
        {
            Debug.Log("Game ended!");
        }

        public void ReloadGame()
        {
        }

        public void StartGame()
        {
            Debug.Log("Game started!");
        }
    }
}