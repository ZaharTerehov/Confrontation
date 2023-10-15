
using System;
using Gameplay.Interfaces.ConstructionElements;

namespace Gameplay.Services.ConstructionElements
{
    public class CapitalService : ICapitalService
    {
        private float _unitsCapital;
        private int _gold;
        
        private float _unitsPerSecond = 1f;
        
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
    }
}