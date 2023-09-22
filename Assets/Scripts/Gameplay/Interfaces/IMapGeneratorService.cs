
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Gameplay.Interfaces
{
    public interface IMapGeneratorService
    {
        public void GenerateLevel(LevelSettingData levelSettingsData, Tilemap tilemap, ref Rect rect);

        public void GameBoardFilling(LevelSettingData levelSettingsData, Tilemap tilemap);

        public void SetRandomTile(Vector3Int spawnPosition, LevelSettingData levelSettingsData, Tilemap tilemap);

        public void AddRandom(Vector3Int spawnPosition, Tilemap tilemap, LevelSettingData levelSettingsData);
    }
}