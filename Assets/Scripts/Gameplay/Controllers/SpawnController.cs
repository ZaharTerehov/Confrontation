
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
        [Inject] private UnitController.Factory _factory;

        private static SpawnController _instance;

        private void Start()
        {
            _instance = this;
        }

        public static void SpawnUnit(int countUnit)
        {
            var unit = _instance._factory.Create().gameObject;
            
            unit.GetComponent<UnitController>().InitUnit(countUnit);
            
            var position = _instance._tilemap.GetCellCenterWorld(new Vector3Int(CapitalController.Position.x, 
                CapitalController.Position.y + 1));

            unit.transform.position = new Vector3(position.x, position.y + 0.3f);
        }
    }
}