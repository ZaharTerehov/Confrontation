
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

        private void InitLevel(LevelSettingData levelSettingsData)
        {
            _mapGeneratorService.InitLevel(levelSettingsData, _tilemap);
        }
    }
}