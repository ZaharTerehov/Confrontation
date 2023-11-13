
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Gameplay.Interfaces
{
    public interface IBoardService
    {
        public event Action ClickOnCapital;
        public event Action ClickNotOnCapital;

        public void ClickOnTilemap(Tilemap tilemap, Vector3Int position, List<Tile> clickableTiles);
    }
}