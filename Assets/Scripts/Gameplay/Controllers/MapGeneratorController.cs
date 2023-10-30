
using Gameplay.Interfaces;
using Gameplay.SO;
using UnityEngine;
using UnityEngine.Tilemaps;
using Zenject;

namespace Gameplay.Controllers
{
    public class MapGeneratorController : MonoBehaviour
    {
        [Header("Tilemap")]
        [SerializeField] private Tilemap _tilemap;
        [SerializeField] private Tilemap _edgeTilemap;

        [Inject] private IMapGeneratorService _mapGeneratorService;

        public static Rect Rect;

        public void GenerateLevel(LevelSettingData levelSettingsData)
        {
            _tilemap.ClearAllTiles();
            _tilemap.ClearAllEditorPreviewTiles();
            
            _mapGeneratorService.GenerateLevel(levelSettingsData, _tilemap, _edgeTilemap, ref Rect);
        }
    }
}