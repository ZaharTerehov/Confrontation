
using System;

namespace Gameplay.Interfaces
{
    public interface IResourceService
    {
        public event Action<int> AddGold;

        public void ResourceProduction(float unitsPerSecond, float unitRecruitmentRate, int goldPerSecond);

        public void ResetResource();
    }
}