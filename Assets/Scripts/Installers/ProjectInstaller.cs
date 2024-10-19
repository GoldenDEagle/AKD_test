using Assets.Scripts.Services.Input;
using Zenject;

namespace Assets.Scripts.Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindInputService();
        }

        private void BindInputService()
        {
            Container.BindInterfacesAndSelfTo<IInputService>()
                            .FromInstance(new InputService())
                            .AsSingle()
                            .NonLazy();
        }
    }
}
