
using Gameplay.Controllers.Units;
using UnityEngine;
using Zenject;

namespace Gameplay.Controllers
{
    public class SpawnController : MonoBehaviour
    {
        [Inject] private UnitController.Factory _factory;

        private static SpawnController _insance;

        private void Start()
        {
            _insance = this;
        }

        public static GameObject SpawnUnit()
        {
            return _insance._factory.Create().gameObject;
        }
    }
}