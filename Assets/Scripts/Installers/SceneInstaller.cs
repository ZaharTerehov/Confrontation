
using Gameplay.Controllers.Units;
using Gameplay.Interfaces;
using Gameplay.Interfaces.ConstructionElements;
using Gameplay.Services;
using Gameplay.Services.ConstructionElements;
using UI.Interfaces;
using UI.Services;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _unit;
        
        public override void InstallBindings()
        {
            Container.Bind<IUIService>().To<UIService>().AsSingle();
            Container.Bind<IAudioService>().To<AudioService>().AsSingle();
            Container.Bind<IMapGeneratorService>().To<MapGeneratorService>().AsSingle();
            Container.Bind<ILevelService>().To<LevelService>().AsSingle();
            Container.Bind<IMoveOnTilemapService>().To<MoveOnTilemapService>().AsSingle();
            Container.Bind<IUnitService>().To<UnitService>().AsSingle();
            Container.BindFactory<UnitController, UnitController.Factory>().FromComponentInNewPrefab(_unit);
            Container.Bind<IBuilderService>().To<BuilderService>().AsSingle();
            Container.Bind<IResourceService>().To<ResourceService>().AsSingle();
            Container.Bind<IBoardService>().To<BoardService>().AsSingle();
            Container.Bind<ICapitalService>().To<CapitalService>().AsSingle();
        }
    }
}