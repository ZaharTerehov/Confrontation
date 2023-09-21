
using System;
using Gameplay.Interfaces;
using UnityEngine;
using UnityEngine.Tilemaps;
using Zenject;

namespace Gameplay.Controllers
{
    public class MapGeneratorController : MonoBehaviour
    {
        [Header("Tilemap")]
        [SerializeField] private Tilemap _tilemap;

        [Inject] private IMapGeneratorService _mapGeneratorService;

        public static Rect Rect;

        public void GenerateLevel(LevelSettingData levelSettingsData)
        {
            _tilemap.ClearAllTiles();
            _tilemap.ClearAllEditorPreviewTiles();
            
            _mapGeneratorService.GenerateLevel(levelSettingsData, _tilemap, ref Rect);
        }
    }
}