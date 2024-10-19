using Assets.Scripts.Services.Gameplay;
using Zenject;

namespace Assets.Scripts.Installers
{
    public class GameplayInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InstallGameplayService();
        }

        private void InstallGameplayService()
        {
            Container.Bind<IGameplayService>()
                .FromInstance(new GameplayService())
                .AsSingle();
        }
    }
}