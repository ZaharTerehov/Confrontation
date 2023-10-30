
using System;
using Gameplay.SO;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Gameplay.Interfaces
{
    public interface IMapGeneratorService
    {
        public event Action<Vector3Int, bool> TilemapGenerationIsFinished;
        public event Action<Vector3Int> SetSettlement;
        
        public void GenerateLevel(LevelSettingData levelSettingsData, Tilemap tilemap, Tilemap edgeTilemap, ref Rect rect);

        public void GameBoardFilling(LevelSettingData levelSettingsData, Tilemap tilemap, Tilemap edgeTilemap);

        public void SetRandomTile(Vector3Int spawnPosition, LevelSettingData levelSettingsData, Tilemap tilemap);
    }
}