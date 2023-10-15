
using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Gameplay.Interfaces
{
    public interface IBoardService
    {
        public event Action ClickOnCapital;
        public event Action ClickNotOnCapital;

        public void ClickOnTilemap(Tilemap tilemap, Vector3Int position, Tile tile);
    }
}