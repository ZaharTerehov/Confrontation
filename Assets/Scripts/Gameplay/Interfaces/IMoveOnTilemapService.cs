using System;
using System.Collections.Generic;
using Gameplay.Services;
using Gameplay.Structures;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Gameplay.Interfaces
{
    public interface IMoveOnTilemapService
    {
        public event Action EndMovement;
        public event Action<Vector3> EndPosition;
        
        public void InitPathfinder(TileAndMovementCost[] tiles, Tilemap tilemap);
        
        public void MoveUnit(GameObject gameObject);
        
        public float GetDistance(Vector3Int a, Vector3Int b);

        public Dictionary<Vector3Int, float> ConnectionsAndCosts(Vector3Int a);
        
        public void Move(GameObject gameObject, List<Vector3Int> path, Tilemap tilemap);
    }
}