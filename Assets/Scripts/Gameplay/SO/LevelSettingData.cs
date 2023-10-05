
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Gameplay
{
    [CreateAssetMenu(fileName = "New LevelSettingData", menuName = "LevelSetting Data")]
    public class LevelSettingData : ScriptableObject
    {
        [Header("Size board")]
        [SerializeField] public Vector2Int GridSize;
        
        [Header("Tiles to fill")]
        [SerializeField] public List<Tile> Tiles = new List<Tile>();
        
        [Header("Edge tile")]
        [SerializeField] public Tile EdgeTile;
    }
}