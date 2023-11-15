
using System;
using Gameplay.Interfaces;
using Gameplay.Interfaces.ConstructionElements;
using Zenject;

namespace Gameplay.Services
{
    public class ResourceService : IResourceService
    {
        [Inject] private ICapitalService _capitalService;

        public event Action<int> AddProduction;
        
        private float _unitsCapital;
        private int _gold;

        public void ResourceProduction()
        {
            _capitalService.ResourceProduction();
            _gold = _capitalService.GetGold();
            
            AddProduction?.Invoke(_gold);
        }

        public void ResetResource()
        {
            _capitalService.ResetResource();
        }

        public int GetCountGold()
        {
            return _capitalService.GetGold();
        }
    }
}