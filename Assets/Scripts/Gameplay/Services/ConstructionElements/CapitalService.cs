
using System;
using Gameplay.Enums;
using Gameplay.Interfaces.ConstructionElements;
using UI.Element;
using UnityEngine;

namespace Gameplay.Services.ConstructionElements
{
    public class CapitalService : ICapitalService
    {
        private int _lvl;
        private int _unitsCapital;
        private int _gold;

        private int _unitsPerSecond = 1;
        private int _goldPerSecond = 1;

        private int _garrisonDefenders;
        private int _playerSquad;

        private ObjectOwnership _objectOwnership;

        public event Action<int, int, int, int, int> ClickingCapital;
        
        public void Init(ObjectOwnership objectOwnership)
        {
            _lvl = 1;
            _objectOwnership = objectOwnership;
            _unitsCapital = 0;
            _gold = 0;

            ClickingCapital += TextBoxBuilding.SetInfo;
        }

        public void ResourceProduction()
        {
            _unitsCapital += _unitsPerSecond;
            _gold += _goldPerSecond;
        }

        public void ResetResource()
        {
            _gold = 0;
            _unitsCapital = 0;
        }

        public int GetUnits() => _unitsCapital;
        
        public int GetGold() => _gold;
        
        public void OnClickingCapital()
        {
            Debug.Log(_gold);
            ClickingCapital?.Invoke(_lvl, _playerSquad, _gold, _unitsPerSecond, _goldPerSecond);
        }
    }
}