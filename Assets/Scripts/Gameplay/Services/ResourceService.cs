
using System;
using Gameplay.Interfaces;

namespace Gameplay.Services
{
    public class ResourceService : IResourceService
    {
        private float _unitsCapital;
        private int _gold;
        
        public event Action<int> AddGold;
        
        public void ResourceProduction(float unitsPerSecond, float unitRecruitmentRate, int goldPerSecond)
        {
            _unitsCapital += unitsPerSecond * unitRecruitmentRate;
            _gold += goldPerSecond;
            
            AddGold?.Invoke(_gold);
        }
    }
}