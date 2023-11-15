
using System;
using Gameplay.Enums;
using Gameplay.Interfaces.ConstructionElements;
using UI.Element;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Gameplay.Controllers.ConstructionElements
{
    public class CapitalController : MonoBehaviour, IPointerDownHandler
    {
        [Inject] private ICapitalService _capitalService;

        private static CapitalController _instance;

        public static Vector3Int Position;

        private void Start()
        {
            _instance = this;
        }
        
        public void Init(Vector3Int position, ObjectOwnership objectOwnership)
        {
            Position = position;
            _capitalService.Init(objectOwnership); 
        }

        public static void OnSendUnit()
        {
            var unitInCapital = _instance._capitalService.GetUnits();
            
            if (unitInCapital == 0)
                return;
            
            SpawnController.SpawnUnit(unitInCapital);
        }
        
        public void OnPointerDown(PointerEventData eventData)
        {
            _capitalService.OnClickingCapital();
        }
        
        public  class Factory : PlaceholderFactory<CapitalController> {}
    }
}