
using System;
using Gameplay.Controllers.ConstructionElements;
using Gameplay.Controllers.Units;
using Gameplay.Enums;
using Gameplay.Interfaces;
using Zenject;

namespace Gameplay.Services
{
    public class UnitService : IUnitService
    {
        [Inject] private IMoveOnTilemapService _moveOnTilemapService;
        
        public event Action UnitSelected;
        public event Action UnitNotSelected;
        
        public event Action<float> CharacteristicsChanged;
        
        private int _speed;
        private int _power;
        
        private float _defensePercentage;
        private float _attack;
        
        private int _countUnit;
        private ObjectOwnership _objectOwnership;

        public void InitUnit(UnitController unitController, int countUnit)
        {
            _moveOnTilemapService.EndMovement += unitController.OnSetIdleAnimation;
            _moveOnTilemapService.EndPosition += unitController.OnSetTargetAnimation;

            _countUnit = countUnit;
            _objectOwnership = ObjectOwnership.Allied;
            
            CalculateCharacteristics(_countUnit);
        }

        public void OnUnitSelected() => UnitSelected?.Invoke();

        public void OnUnitNotSelected() => UnitNotSelected?.Invoke();
        
        public int GetCountUnits() => _countUnit;
        public int GetPower() => _power;
        
        public void CombineUnits(int unitCount)
        {
            _countUnit += unitCount;
            CalculateCharacteristics(_countUnit);
        }

        private void CalculateCharacteristics(int unitCount)
        {
            _defensePercentage = 1.1f * unitCount;
            _attack = 1.1f * unitCount;

            _power = (int)(_defensePercentage + _attack) / 2;
            
            CharacteristicsChanged?.Invoke(_power);
        }

        public void TakeDamage(SettlementController targetAttack)
        {
            var garrisonDefendersAndPlayerSquad = targetAttack.GetGarrisonDefendersAndPlayerSquad();
            
            if(garrisonDefendersAndPlayerSquad.Item1 > 0)
                _countUnit -= garrisonDefendersAndPlayerSquad.Item1;
            else if(garrisonDefendersAndPlayerSquad.Item2 > 0)
                _countUnit -= garrisonDefendersAndPlayerSquad.Item2;

            CalculateCharacteristics(_countUnit);

            if (garrisonDefendersAndPlayerSquad.Item1 <= 0 && garrisonDefendersAndPlayerSquad.Item2 <= 0
                                                           && _attack > 0)
            {
                targetAttack.SetType(ObjectOwnership.Allied);
            }
        }
    }
}