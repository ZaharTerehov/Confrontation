
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Gameplay.SO
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
        
        [Header("Settlement")]
        [SerializeField] public Tile SettlementTile;
        
        [Header("Mine")]
        [SerializeField] public Tile MineTile;
        
        [Header("Barracks")]
        [SerializeField] public Tile BarracksTile;
        
        [Header("Stable")]
        [SerializeField] public Tile StableTile;
    }
}