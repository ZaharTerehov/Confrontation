
using System;
using Gameplay.Interfaces;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Gameplay.Services
{
    public class BoardService : IBoardService
    {
        public event Action ClickOnBuilding;
        public event Action ClickNotOnBuilding;

        public void ClickOnTilemap(Tilemap tilemap, Vector3Int position, Tile capital, Tile settlement)
        {
            if (tilemap.GetTile<Tile>(position) == capital || tilemap.GetTile<Tile>(position) == settlement)
            {
                ClickOnBuilding?.Invoke();
                
                
            }
                
            else
                ClickNotOnBuilding?.Invoke();
        }
    }
}