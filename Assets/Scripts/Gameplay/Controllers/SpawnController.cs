
using Gameplay.Controllers.ConstructionElements;
using Gameplay.Controllers.Units;
using UnityEngine;
using UnityEngine.Tilemaps;
using Zenject;

namespace Gameplay.Controllers
{
    public class SpawnController : MonoBehaviour
    {
        [SerializeField] private Tilemap _tilemap;
        [SerializeField] private Transform _units;
        [Inject] private UnitController.Factory _unitControllerFactory;

        private static SpawnController _instance;

        private void Start()
        {
            _instance = this;
        }

        public static void SpawnUnit(int countUnit)
        {
            var unit = _instance._unitControllerFactory.Create().gameObject;
            var baseUnit = unit.transform.parent.gameObject;
            baseUnit.transform.SetParent(_instance._units, false);
            
            unit.GetComponent<UnitController>().InitUnit(countUnit);
            
            var position = _instance._tilemap.GetCellCenterWorld(new Vector3Int(CapitalController.Position.x, 
                CapitalController.Position.y + 1));

            unit.transform.position = new Vector3(position.x, position.y + 0.3f);
        }
    }
}