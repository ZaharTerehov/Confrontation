
using System;

namespace Gameplay.Interfaces.ConstructionElements
{
    public interface ICapitalService
    {
        // public event Action<int> AddGold;
        // public event Action<float> AddUnits;
        
        public event Action<int, int, int> GetInfo;
        
        public void ResourceProduction();
        public void ResetResource();

        public int GetUnits();

        public int GetGold();
    }
}