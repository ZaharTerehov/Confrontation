
using System;
using Gameplay.Interfaces.ConstructionElements;

namespace Gameplay.Services.ConstructionElements
{
    public class CapitalService : ICapitalService
    {
        private int _unitsCapital;
        private int _gold;

        private int _unitsPerSecond = 1;
        
        private int _goldPerSecond = 1;

        public event Action<int> AddGold;
        public event Action<float> AddUnits;
        
        public void ResourceProduction()
        {
            _unitsCapital += _unitsPerSecond;
            _gold += _goldPerSecond;
            
            AddGold?.Invoke(_gold);
            AddUnits?.Invoke(_unitsCapital);
        }
        
        public int GetUnits() => _unitsCapital;
    }
}