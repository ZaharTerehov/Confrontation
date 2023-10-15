
using System;
using Gameplay.Controllers.Units;

namespace Gameplay.Interfaces
{
    public interface IUnitService
    {
        public event Action UnitSelected;
        public event Action UnitNotSelected;
        
        public void InitUnit(UnitController unitController);
        
        public void OnUnitSelected();
        public void OnUnitNotSelected();
    }
}