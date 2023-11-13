
using Gameplay.Controllers.Units;
using Gameplay.Enums;

namespace Gameplay.Interfaces.ConstructionElements
{
    public interface ISettlementService
    {
        public void Init();

        public (int, int) GetGarrisonDefendersAndPlayerSquad();

        public void TakeDamage(UnitController unit);

        public void AddUnit(UnitController unit);
        
        public ObjectOwnership GetType();
    }
}