
using System;
using Gameplay.Controllers.Units;
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
        private float _power;
        
        private float _defensePercentage;
        private float _attack;
        
        private int _countUnit;

        public void InitUnit(UnitController unitController, int countUnit)
        {
            _moveOnTilemapService.EndMovement += unitController.OnSetIdleAnimation;
            _moveOnTilemapService.EndPosition += unitController.OnSetTargetAnimation;

            _countUnit = countUnit;
            CalculateCharacteristics(_countUnit);
        }

        public void OnUnitSelected() => UnitSelected?.Invoke();

        public void OnUnitNotSelected() => UnitNotSelected?.Invoke();
        
        public int GetCountUnits() => _countUnit;
        
        public void CombineUnits(int unitCount)
        {
            _countUnit += unitCount;
            CalculateCharacteristics(_countUnit);
        }

        private void CalculateCharacteristics(int unitCount)
        {
            _defensePercentage = 1.1f * unitCount;
            _attack = 1.1f * unitCount;

            _power = (_defensePercentage + _attack) / 2;
            
            CharacteristicsChanged?.Invoke(_power);
        }
    }
}