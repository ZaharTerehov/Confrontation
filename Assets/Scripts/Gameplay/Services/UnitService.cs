
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
        
        private int _speed;
        private int _power;
        
        private int _defensePercentage;
        private int _attack;
        
        private int _countUnit;

        public void InitUnit(UnitController unitController, int countUnit)
        {
            _moveOnTilemapService.EndMovement += unitController.OnSetIdleAnimation;
            _moveOnTilemapService.EndPosition += unitController.OnSetTargetAnimation;

            _countUnit = countUnit;
        }

        public void OnUnitSelected() => UnitSelected?.Invoke();

        public void OnUnitNotSelected() => UnitNotSelected?.Invoke();
    }
}