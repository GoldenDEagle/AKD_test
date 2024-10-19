using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Services.Gameplay
{
    public interface IGameplayService
    {
        public event Action OnGameStarted;
        public event Action OnGameCompleted;

        public void StartGame();
        public void EndGame();
        public void ReloadGame();
    }
}
