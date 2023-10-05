
using UnityEngine;
using UnityEngine.Tilemaps;
using Aoiti.Pathfinding;
using Gameplay.Interfaces;
using Gameplay.Structures;
using Zenject;

namespace Gameplay.Controllers
{
    public class MoveOnTilemap : MonoBehaviour
    {
        [SerializeField] private Tilemap _tilemap;
        [SerializeField] private TileAndMovementCost[] _tiles;

        [Inject] private IMoveOnTilemapService _moveOnTilemapService;
        
        private Pathfinder<Vector3Int> _pathfinder;
        private bool _isSelected;

        private static MoveOnTilemap _instance;

        private void Start()
        {
            _instance = this;
            _moveOnTilemapService.InitPathfinder(_tiles, _tilemap);
        }

        public static void MoveUnit(GameObject movableObject)
        {
            _instance._moveOnTilemapService.MoveUnit(movableObject);
        }
    }
}