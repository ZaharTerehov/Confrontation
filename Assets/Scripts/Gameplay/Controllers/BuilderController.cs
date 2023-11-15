
using Gameplay.Controllers.ConstructionElements;
using Gameplay.Enums;
using Gameplay.Interfaces;
using UnityEngine;
using UnityEngine.Tilemaps;
using Zenject;

namespace Gameplay.Controllers
{
    public class BuilderController : MonoBehaviour
    {
        [SerializeField] private Tile _capital;
        [SerializeField] private Tile _settlement;
        [SerializeField] private Tile _mine;
        [SerializeField] private Tile _barracks;
        [SerializeField] private Tile _stable;

        [Space]
        [SerializeField] private Tilemap _tilemap;

        [SerializeField] private Transform _settlements;
        
        [Inject] private IMapGeneratorService _mapGeneratorService;
        [Inject] private IBuilderService _builderService;
        [Inject] private SettlementController.Factory _settlementControllerFactory;
        [Inject] private CapitalController.Factory _capitalControllerFactory;

        private static BuilderController _instance;
        
        private void Start()
        {
            _instance = this;
            
            _tilemap.ClearAllTiles();
            
            _mapGeneratorService.SetSettlement += SpawnSettlement;
            _mapGeneratorService.SetCapital += SpawnCapital;
        }

        private void SpawnSettlement(Vector3Int position)
        {
            _instance._tilemap.SetTile(position, _instance._settlement);
            
            var worldPos = _instance._tilemap.CellToWorld(position);
            var settlement = _instance._settlementControllerFactory.Create().gameObject;
            
            settlement.transform.position = worldPos;
            settlement.transform.SetParent(_instance._settlements, true);
        }
        
        private static void SpawnCapital(Vector3Int position, ObjectOwnership objectOwnership)
        {
            _instance._tilemap.SetTile(position, _instance._capital);
            
            var worldPos = _instance._tilemap.CellToWorld(position);
            var capital = _instance._capitalControllerFactory.Create().gameObject;
            var capitalController = capital.GetComponent<CapitalController>();
            
            capitalController.Init(position, objectOwnership);
            
            capital.transform.position = worldPos;
            capital.transform.SetParent(_instance._settlements, true);
        }

        public static void OnClearAllCapital()
        {
            _instance._tilemap.ClearAllTiles();
        }

        public static void BuildSettlement()
        {
            var pos = new Vector3Int(CapitalController.Position.x, CapitalController.Position.y + 1);
            _instance._tilemap.SetTile(pos, _instance._settlement);
        }
    }
}