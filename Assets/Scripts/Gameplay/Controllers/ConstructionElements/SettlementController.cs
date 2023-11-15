
using Gameplay.Controllers.Units;
using Gameplay.Enums;
using Gameplay.Interfaces.ConstructionElements;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Gameplay.Controllers.ConstructionElements
{
    public class SettlementController : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private SpriteRenderer _sprite;
        
        [Inject] private ISettlementService _settlementService;

        private UnitController _attackingUnit;

        private void Start()
        {
            Init();
            OnPointerClick(null);
        }

        private void Init()
        {
            _settlementService.Init();
            SetType(ObjectOwnership.Neutral);
        }

        public void SetType(ObjectOwnership objectOwnership)
        {
            switch (objectOwnership)
            {
                case ObjectOwnership.Allied:
                    _sprite.color = new Color32(30, 200, 30, 50);
                    break;
                case ObjectOwnership.Neutral:
                    _sprite.color = new Color32(30, 200, 30, 0);
                    break;
                case ObjectOwnership.Enemy:
                    _sprite.color = new Color32(200, 30, 30, 50);
                    break;
            }
        }

        public (int, int) GetGarrisonDefendersAndPlayerSquad() =>
            _settlementService.GetGarrisonDefendersAndPlayerSquad();

        public void TakeDamage(UnitController unit)
        {
            _settlementService.TakeDamage(unit);
        }

        public void AddUnit(UnitController unit)
        {
            _settlementService.AddUnit(unit);
        }

        public ObjectOwnership GetType() => _settlementService.GetType();
        
        public void OnPointerClick(PointerEventData eventData)
        {
            _settlementService.OnClickingSettlement();
        }

        public class Factory : PlaceholderFactory<SettlementController> {}
    }
}