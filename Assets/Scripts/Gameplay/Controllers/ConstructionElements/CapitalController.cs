
using Gameplay.Interfaces.ConstructionElements;
using UnityEngine;
using UnityEngine.Tilemaps;
using Zenject;

namespace Gameplay.Controllers.ConstructionElements
{
    public class CapitalController : MonoBehaviour
    {
        [SerializeField] private Tilemap _tilemap;
        
        [Inject] private ICapitalService _capitalService;

        private static CapitalController _instance;

        public static Vector3Int Position;

        private void Start()
        {
            _instance = this;
        }

        public static void SendUnit()
        {
            if (!(_instance._capitalService.GetUnits() > 0)) 
                return;
            
            var unit = SpawnController.SpawnUnit();
            var position = _instance._tilemap.GetCellCenterWorld(new Vector3Int(Position.x, 
                Position.y + 1));

            unit.transform.position = new Vector3(position.x, position.y + 0.3f);
        }
    }
}