
using System;
using Gameplay.Controllers.ConstructionElements;
using Gameplay.Controllers.Units;

namespace Gameplay.Interfaces
{
    public interface IUnitService
    {
        public event Action UnitSelected;
        public event Action UnitNotSelected;

        public event Action<float> CharacteristicsChanged;
        
        public void InitUnit(UnitController unitController, int countUnit);
        
        public void OnUnitSelected();
        public void OnUnitNotSelected();

        public int GetCountUnits();
        public int GetPower();
        
        public void CombineUnits(int unitService);

        public void TakeDamage(SettlementController targetAttack);
    }
}