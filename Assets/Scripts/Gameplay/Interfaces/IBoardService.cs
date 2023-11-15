
using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Gameplay.Interfaces
{
    public interface IBoardService
    {
        public event Action ClickOnBuilding;
        public event Action ClickNotOnBuilding;

        public void ClickOnTilemap(Tilemap tilemap, Vector3Int position, Tile capital, Tile settlement);
    }
}