
using Gameplay.Interfaces;
using Gameplay.Services;
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
            Container.Bind<IMapGeneratorService>().To<MapGeneratorService>().AsSingle();
            Container.Bind<ILevelService>().To<LevelService>().AsSingle();
            Container.Bind<IMoveOnTilemapService>().To<MoveOnTilemapService>().AsSingle();
            Container.Bind<IUnitService>().To<UnitService>().AsSingle();
            Container.Bind<IBuilderService>().To<BuilderService>().AsSingle();
            Container.Bind<IResourceService>().To<ResourceService>().AsSingle();
        }
    }
}