
using System;
using Gameplay.Controllers.Units;
using Gameplay.Enums;

namespace Gameplay.Interfaces.ConstructionElements
{
    public interface ISettlementService
    {
        public event Action<int, int, int, int, int>ClickingSettlement;
        
        public void Init();

        public (int, int) GetGarrisonDefendersAndPlayerSquad();

        public void TakeDamage(UnitController unit);

        public void AddUnit(UnitController unit);
        
        public void OnClickingSettlement();
        
        public ObjectOwnership GetType();
    }
}