
using UI.Interfaces;
using UI.Services;
using Zenject;

namespace Installers
{
    public class SceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IUIService>().To<UIService>().AsSingle();
            Container.Bind<IAudioService>().To<AudioService>().AsSingle();
        }
    }
}










