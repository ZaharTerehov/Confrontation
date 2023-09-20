﻿
using System.Collections.Generic;
using Gameplay.Interfaces;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Gameplay.Services
{
    public class MapGeneratorService : IMapGeneratorService
    {
        private List<Vector3Int> _currentPositions = new List<Vector3Int>();
        
        public void InitLevel(LevelSettingData levelSettingsData, Tilemap tilemap)
        {
            for (var x = 0; x < levelSettingsData.GridSize.x; x++)
            {
                for (var y = 0; y < levelSettingsData.GridSize.y; y++)
                {
                    _currentPositions.Add(new Vector3Int(x, y, 0));
                }
            }

            GameBoardFilling(levelSettingsData, tilemap);
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
                    for (var j = Random.Range(1, -3); j < 5; j++)
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
                    for (var j = Random.Range(1, -3); j < 5; j++)
                    {
                        tilemap.SetTile(new Vector3Int(spawnPosition.x + j, spawnPosition.y - i), 
                            levelSettingsData.EdgeTile);
                    }
                }
            }

            else if (spawnPosition.y == 0)
            {
                for (var i = Random.Range(1, -3); i < 5; i++)
                {
                    tilemap.SetTile(new Vector3Int(spawnPosition.x, spawnPosition.y - i), 
                        levelSettingsData.EdgeTile);
                }
            }

            else if (spawnPosition.y == levelSettingsData.GridSize.y - 1)
            {
                for (var i = Random.Range(1, -3); i < 5; i++)
                {
                    tilemap.SetTile(new Vector3Int(spawnPosition.x, spawnPosition.y + i), 
                        levelSettingsData.EdgeTile);
                }
            }
        }
    }
}