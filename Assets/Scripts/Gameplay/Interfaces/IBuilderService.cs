
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Gameplay.Interfaces
{
    public interface IBuilderService
    {
        public void InitCapital(Vector3Int position, Tilemap tilemap, Tile capital);
    }
}