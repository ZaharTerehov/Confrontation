
using Gameplay.Controllers.ConstructionElements;
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

        private static BuilderController _instance;
        
        private void Start()
        {
            _instance = this;
            
            _tilemap.ClearAllTiles();
            
            _mapGeneratorService.TilemapGenerationIsFinished += OnInitCapital;
            _mapGeneratorService.SetSettlement += SpawnSettlement;
        }

        private void OnInitCapital(Vector3Int position, bool isAlly = false)
        {
            if(isAlly)
                CapitalController.Position = position;
            
            _builderService.InitCapital(position, _tilemap, _capital);
        }

        private static void SpawnSettlement(Vector3Int position)
        {
            _instance._tilemap.SetTile(position, _instance._settlement);
            
            var worldPos = _instance._tilemap.CellToWorld(position);
            var settlement = _instance._settlementControllerFactory.Create().gameObject;
            settlement.transform.position = worldPos;
            settlement.transform.SetParent(_instance._settlements, true);
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