
using System;
using System.Collections.Generic;
using Gameplay.Interfaces;
using Gameplay.SO;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

namespace Gameplay.Services
{
    public class MapGeneratorService : IMapGeneratorService
    {
        private List<Vector3Int> _currentPositions = new List<Vector3Int>();
        private List<Vector3Int> _currentPositionsEdge = new List<Vector3Int>();

        public event Action<Vector3Int, bool> TilemapGenerationIsFinished;
        public event Action<Vector3Int> SetSettlement;

        public void GenerateLevel(LevelSettingData levelSettingsData, Tilemap tilemap, Tilemap edgeTilemap, ref Rect rect)
        {
            _currentPositions.Clear();
            tilemap.ClearAllTiles();
            edgeTilemap.ClearAllTiles();

            _currentPositions = FillCurrentPosition(_currentPositions, levelSettingsData.GridSize);
            _currentPositionsEdge = FillCurrentPosition(_currentPositionsEdge, 
                new Vector2Int(levelSettingsData.GridSize.x + 10, levelSettingsData.GridSize.y + 10));

            GameBoardFilling(levelSettingsData, tilemap, edgeTilemap);

            rect = new Rect(edgeTilemap.localBounds.center - edgeTilemap.localBounds.extents, 
                edgeTilemap.localBounds.size);
        }

        private List<Vector3Int> FillCurrentPosition(List<Vector3Int> list, Vector2Int gridSize)
        {
            for (var x = 0; x < gridSize.x; x++)
            {
                for (var y = 0; y < gridSize.y; y++)
                {
                    list.Add(new Vector3Int(x, y, 0));
                }
            }

            return list;
        }

        public void GameBoardFilling(LevelSettingData levelSettingsData, Tilemap tilemap, Tilemap edgeTilemap)
        {
            foreach (var position in _currentPositions)
            {
                SetRandomTile(position, levelSettingsData, tilemap);
            }

            foreach (var position in _currentPositionsEdge)
            {
                edgeTilemap.SetTile(position, levelSettingsData.EdgeTile);
            }

            TilemapGenerationIsFinished?.Invoke(new Vector3Int(Random.Range(1, 4), Random.Range(2, 8)), true);
            TilemapGenerationIsFinished?.Invoke(new Vector3Int(Random.Range(12, 14), Random.Range(2, 8)), false);
        }

        public void SetRandomTile(Vector3Int spawnPosition, LevelSettingData levelSettingsData, Tilemap tilemap)
        {
            var tile = levelSettingsData.Tiles[Random.Range(0, levelSettingsData.Tiles.Count)];
            tilemap.SetTile(spawnPosition, tile);

            if (Random.Range(1, 100) <= 8)
            {
                SetSettlement?.Invoke(new Vector3Int(spawnPosition.x, spawnPosition.y));
            }
        }
    }
}