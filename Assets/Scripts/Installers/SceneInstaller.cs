
using Gameplay.Controllers.ConstructionElements;
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
        [SerializeField] private GameObject _settlement;
        [SerializeField] private GameObject _capital;
        
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
            Container.BindFactory<CapitalController, CapitalController.Factory>().FromComponentInNewPrefab(_capital);
            Container.Bind<ISettlementService>().To<SettlementService>().AsSingle();
            Container.BindFactory<SettlementController, SettlementController.Factory>().FromComponentInNewPrefab(_settlement);
        }
    }
}