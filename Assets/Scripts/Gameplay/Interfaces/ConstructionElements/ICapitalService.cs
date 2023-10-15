
using System;

namespace Gameplay.Interfaces.ConstructionElements
{
    public interface ICapitalService
    {
        public event Action<int> AddGold;
        public event Action<float> AddUnits;
        
        public void ResourceProduction();
    }
}