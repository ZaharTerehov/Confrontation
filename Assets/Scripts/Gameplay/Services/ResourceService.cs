
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

        public void ResourceProduction()
        {
            _capitalService.ResourceProduction();
        }

        public void ResetResource()
        {
            _capitalService.ResetResource();
        }
    }
}