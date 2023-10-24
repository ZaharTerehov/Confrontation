
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
        [SerializeField] private Tilemap _tilemap;
        
        [Inject] private IMapGeneratorService _mapGeneratorService;
        [Inject] private IBuilderService _builderService;

        private static BuilderController _instance;
        
        private void Start()
        {
            _instance = this;
            
            _tilemap.ClearAllTiles();
            _mapGeneratorService.TilemapGenerationIsFinished += OnInitCapital;
        }

        private void OnInitCapital(Vector3Int position, bool isAlly = false)
        {
            if(isAlly)
                CapitalController.Position = position;
            
            _builderService.InitCapital(position, _tilemap, _capital);
        }

        public static void OnClearAllCapital()
        {
            _instance._tilemap.ClearAllTiles();
        }
    }
}