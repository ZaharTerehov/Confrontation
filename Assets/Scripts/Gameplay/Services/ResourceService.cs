
using System;
using Gameplay.Interfaces;
using Gameplay.Interfaces.ConstructionElements;
using Zenject;

namespace Gameplay.Services
{
    public class ResourceService : IResourceService
    {
        [Inject] private ICapitalService _capitalService;
        
        private float _unitsCapital;
        private int _gold;

        // public event Action<int> AddGold;
        // public event Action<float> AddUnits;
        
        public void ResourceProduction()
        {
            _capitalService.ResourceProduction();
            
            // AddGold?.Invoke(_gold);
            // AddUnits?.Invoke(_unitsCapital);
        }

        public void ResetResource()
        {
            _unitsCapital = 0;
            _gold = 0;
            
            // AddGold?.Invoke(_gold);
            // AddUnits?.Invoke(_unitsCapital);
        }
    }
}