
using System;
using System.Collections.Generic;
using Aoiti.Pathfinding;
using DG.Tweening;
using Gameplay.Interfaces;
using Gameplay.Structures;
using Gameplay.Units;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Gameplay.Services
{
    public class MoveOnTilemapService : IMoveOnTilemapService
    {
        private Vector3Int[] _directions = new Vector3Int[4] {Vector3Int.left, Vector3Int.right, 
            Vector3Int.up, Vector3Int.down};
        
        private Sequence _sequence;
        private List<Vector3Int> _path;
        private Pathfinder<Vector3Int> _pathfinder;

        private TileAndMovementCost[] _tiles;
        private Tilemap _tilemap;
        private Camera _camera;
        
        public static event Action EndMovement;
        
        public void InitPathfinder(TileAndMovementCost[] tiles, Tilemap tilemap)
        {
            _tiles = tiles;
            _tilemap = tilemap;
            
            _pathfinder = new Pathfinder<Vector3Int>(GetDistance, ConnectionsAndCosts);
            _camera = Camera.main;
        }

        public void MoveUnit(GameObject gameObject)
        {
            var currentCellPos = _tilemap.WorldToCell(gameObject.transform.position);
            var target = _tilemap.WorldToCell(_camera.ScreenToWorldPoint(Input.mousePosition));
            target.z = 0;
            _pathfinder.GenerateAstarPath(currentCellPos, target, out _path);

            Move(gameObject, _path, _tilemap);
        }
        
        public float GetDistance(Vector3Int a, Vector3Int b)
        {
            return (a - b).sqrMagnitude;
        }

        public Dictionary<Vector3Int, float> ConnectionsAndCosts(Vector3Int a)
        {
            var result = new Dictionary<Vector3Int, float>();
            
            foreach (var direction in _directions)
            {
                foreach (var tileAndMovementCost in _tiles)
                {
                    if (_tilemap.GetTile(a + direction) != tileAndMovementCost.tile) continue;
                    if (tileAndMovementCost.movable) result.Add(a + direction, tileAndMovementCost.movementCost);
                }
            }

            return result;
        }

        public void Move(GameObject gameObject, List<Vector3Int> path, Tilemap tilemap)
        {
            _sequence = DOTween.Sequence().SetSpeedBased();

            foreach (var position in path)
            {
                _sequence.Append(gameObject.transform.DOMove(new Vector3(tilemap.CellToWorld(position).x,
                    tilemap.CellToWorld(position).y + 0.35f), 0.8f));
            }

            _sequence.AppendCallback(() => EndMovement?.Invoke());
            path.Clear();
        }
    }
}