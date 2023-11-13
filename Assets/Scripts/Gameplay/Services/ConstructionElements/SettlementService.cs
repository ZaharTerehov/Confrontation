
using Gameplay.Controllers.Units;
using Gameplay.Enums;
using Gameplay.Interfaces.ConstructionElements;
using UnityEngine;

namespace Gameplay.Services.ConstructionElements
{
    public class SettlementService : ISettlementService
    {
        private int _level;
        private int _garrisonDefenders;
        private int _playerSquad;

        private ObjectOwnership _objectOwnership;

        public void Init()
        {
            _level = 1;
            _objectOwnership = ObjectOwnership.Neutral;
            
            _garrisonDefenders = Random.Range(1, 2);
        }

        public (int, int) GetGarrisonDefendersAndPlayerSquad()
        {
            return (_garrisonDefenders, _playerSquad);
        }

        public void AddUnit(UnitController unit)
        {
            _playerSquad += unit.GetUnit();
        }

        public void TakeDamage(UnitController unit)
        {
            var power = unit.GetPower();
            
            if(power <= 0)
                return;
            
            if (_playerSquad > 0)
                _playerSquad -= power;
            else if (_garrisonDefenders > 0)
                _garrisonDefenders -= power;

            if (_playerSquad <= 0 && _garrisonDefenders <= 0)
                _objectOwnership = ObjectOwnership.Allied;
        }

        // public void Defense()
        // {
        //     
        // }

        public ObjectOwnership GetType() => _objectOwnership;

        public int GetCountGarrisonDefenders() => _garrisonDefenders;
    }
}