
using Gameplay.Services;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Gameplay.Controllers
{
    public class BuilderController : MonoBehaviour
    {
        [SerializeField] private Tile _capital;
        [SerializeField] private Tilemap _tilemap;
        
        private void Start()
        {
            _tilemap.ClearAllTiles();
            _tilemap.ClearAllEditorPreviewTiles();
            MapGeneratorService._tilemapGenerationIsFinished += InitCapital;
        }

        private void InitCapital(Vector3Int position)
        {
            _tilemap.SetTile(position, _capital);
        }
    }
}