
using System;

namespace Gameplay.Interfaces
{
    public interface IResourceService
    {
        // public event Action<int> AddGold;
        // public event Action<float> AddUnits;

        public void ResourceProduction();

        public void ResetResource();
    }
}