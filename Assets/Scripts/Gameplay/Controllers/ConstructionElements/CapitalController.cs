﻿
using Gameplay.Interfaces.ConstructionElements;
using UnityEngine;
using Zenject;

namespace Gameplay.Controllers.ConstructionElements
{
    public class CapitalController : MonoBehaviour
    {
        [Inject] private ICapitalService _capitalService;

        private static CapitalController _instance;

        public static Vector3Int Position;

        private void Start()
        {
            _instance = this;
        }

        public static void OnSendUnit()
        {
            var unitInCapital = _instance._capitalService.GetUnits();
            
            if (unitInCapital == 0)
                return;
            
            SpawnController.SpawnUnit(unitInCapital);
        }
    }
}