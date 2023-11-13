
using Gameplay.Interfaces;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Gameplay.Services
{
    public class BuilderService : IBuilderService
    {
        public void InitCapital(Vector3Int position, Tilemap tilemap, Tile capital)
        {
            tilemap.SetTile(position, capital);
        }

        public void Build()
        {
            throw new System.NotImplementedException();
        }
    }
}