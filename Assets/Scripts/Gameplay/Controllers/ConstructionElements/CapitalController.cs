
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
            var unitInCapital = _instance._capitalService.GetUnits();
            
            if (unitInCapital == 0)
                return;
            
            SpawnController.SpawnUnit(unitInCapital);
        }
    }
}