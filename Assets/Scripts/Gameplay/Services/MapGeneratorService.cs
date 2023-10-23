
using System;
using System.Collections.Generic;
using Gameplay.Interfaces;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

namespace Gameplay.Services
{
    public class MapGeneratorService : IMapGeneratorService
    {
        private List<Vector3Int> _currentPositions = new List<Vector3Int>();

        public event Action<Vector3Int, bool> TilemapGenerationIsFinished;

        public void GenerateLevel(LevelSettingData levelSettingsData, Tilemap tilemap, ref Rect rect)
        {
            _currentPositions.Clear();
            tilemap.ClearAllTiles();
            
            for (var x = 0; x < levelSettingsData.GridSize.x; x++)
            {
                for (var y = 0; y < levelSettingsData.GridSize.y; y++)
                {
                    _currentPositions.Add(new Vector3Int(x, y, 0));
                }
            }

            GameBoardFilling(levelSettingsData, tilemap);
            
            rect = new Rect(tilemap.localBounds.center - tilemap.localBounds.extents, 
                tilemap.localBounds.size);
        }

        public void GameBoardFilling(LevelSettingData levelSettingsData, Tilemap tilemap)
        {
            foreach (var position in _currentPositions)
            {
                SetRandomTile(position, levelSettingsData, tilemap);
            }
            
            foreach (var position in _currentPositions)
            {
                AddRandom(position, tilemap, levelSettingsData);
            }
            
            TilemapGenerationIsFinished?.Invoke(new Vector3Int(Random.Range(1, 4), Random.Range(2, 8)), true);
            TilemapGenerationIsFinished?.Invoke(new Vector3Int(Random.Range(12, 14), Random.Range(2, 8)), false);
        }

        public void SetRandomTile(Vector3Int spawnPosition, LevelSettingData levelSettingsData, Tilemap tilemap)
        {
            var tile = levelSettingsData.Tiles[Random.Range(0, levelSettingsData.Tiles.Count)];
            tilemap.SetTile(spawnPosition, tile);
        }

        public void AddRandom(Vector3Int spawnPosition, Tilemap tilemap, LevelSettingData levelSettingsData)
        {
            if (spawnPosition.x == 0)
            {
                for (var i = -4; i < 5; i++)
                {
                    for (var j = Random.Range(1, -1); j < 5; j++)
                    {
                        tilemap.SetTile(new Vector3Int(spawnPosition.x - j,
                            spawnPosition.y + i), levelSettingsData.EdgeTile);
                    }
                }
            }
            
            else if (spawnPosition.x == levelSettingsData.GridSize.x - 1)
            {
                for (var i = -4; i < 5; i++)
                {
                    for (var j = Random.Range(1, -1); j < 5; j++)
                    {
                        tilemap.SetTile(new Vector3Int(spawnPosition.x + j, spawnPosition.y - i), 
                            levelSettingsData.EdgeTile);
                    }
                }
            }

            else if (spawnPosition.y == 0)
            {
                for (var i = Random.Range(1, -1); i < 5; i++)
                {
                    tilemap.SetTile(new Vector3Int(spawnPosition.x, spawnPosition.y - i), 
                        levelSettingsData.EdgeTile);
                }
            }

            else if (spawnPosition.y == levelSettingsData.GridSize.y - 1)
            {
                for (var i = Random.Range(1, -1); i < 5; i++)
                {
                    tilemap.SetTile(new Vector3Int(spawnPosition.x, spawnPosition.y + i), 
                        levelSettingsData.EdgeTile);
                }
            }
        }
    }
}