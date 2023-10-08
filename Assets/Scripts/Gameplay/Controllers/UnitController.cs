
using Gameplay.Interfaces;
using Gameplay.Units;
using UnityEngine;
using Zenject;

namespace Gameplay.Controllers
{
    public class UnitController : MonoBehaviour
    {
        [SerializeField] private Unit _unit;
        [Inject] private IUnitService _unitService;

        private void Start()
        {
            InitUnit();
        }

        private void InitUnit()
        {
            _unitService.InitUnit(_unit);
        }
    }
}