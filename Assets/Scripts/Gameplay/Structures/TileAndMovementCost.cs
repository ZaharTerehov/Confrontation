
using UnityEngine.Tilemaps;

namespace Gameplay.Structures
{
    [System.Serializable]
    public struct TileAndMovementCost
    {
        public Tile tile;
        public bool movable;
        public float movementCost;
    }
}