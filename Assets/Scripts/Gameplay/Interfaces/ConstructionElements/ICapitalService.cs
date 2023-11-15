
using System;
using Gameplay.Enums;

namespace Gameplay.Interfaces.ConstructionElements
{
    public interface ICapitalService
    {
        public void Init(ObjectOwnership objectOwnership);
        
        public event Action<int, int, int, int, int> ClickingCapital;
        
        public void ResourceProduction();
        public void ResetResource();

        public int GetUnits();

        public int GetGold();
        
        public void OnClickingCapital();
    }
}