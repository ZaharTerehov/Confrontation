
using System;
using Gameplay.Interfaces;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Gameplay.Services
{
    public class BoardService : IBoardService
    {
        public event Action ClickOnCapital;
        public event Action ClickNotOnCapital;
        
        public void ClickOnTilemap(Tilemap tilemap, Vector3Int position, Tile tile)
        {
            if (tile == tilemap.GetTile<Tile>(position))
                ClickOnCapital?.Invoke();
            else if (tile != tilemap.GetTile<Tile>(position))
                ClickNotOnCapital?.Invoke();
        }
    }
}