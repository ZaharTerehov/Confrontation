
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Gameplay.Interfaces
{
    public interface IMapGeneratorService
    {
        public void InitLevel(LevelSettingData levelSettingsData, Tilemap tilemap);

        public void GameBoardFilling(LevelSettingData levelSettingsData, Tilemap tilemap);

        public void SetRandomTile(Vector3Int spawnPosition, LevelSettingData levelSettingsData, Tilemap tilemap);

        public void AddRandom(Vector3Int spawnPosition, Tilemap tilemap, LevelSettingData levelSettingsData);
    }
}