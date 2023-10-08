
using Gameplay.Interfaces;
using Gameplay.Units;
using Zenject;

namespace Gameplay.Services
{
    public class UnitService : IUnitService
    {
        [Inject] private IMoveOnTilemapService _moveOnTilemapService;

        public void InitUnit(Unit unit)
        {
            _moveOnTilemapService.EndMovement += unit.OnSetIdleAnimation;
            _moveOnTilemapService.EndPosition += unit.OnSetTargetAnimation;
        }
    }
}