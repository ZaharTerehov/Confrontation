
using System;
using Gameplay.Interfaces;
using UnityEngine;
using Zenject;

namespace Gameplay.Controllers
{
    public class ResourceController : MonoBehaviour
    {
        [SerializeField] float _interval = 2f;
        
        [SerializeField] private float _unitsPerSecond = 1f;
        
        [Space]
        [SerializeField] private int _goldPerSecond = 1;
        
        [Space]
        [SerializeField] private float _unitRecruitmentRate = 1.1f;
        
        [Inject] private IResourceService _resourceService;

        private float _time;
        

        private void Start()
        {
            _time = 0f;
        }
        
        private void Update() 
        {
            _time += Time.deltaTime;
            
            while(_time >= _interval) {
                _resourceService.ResourceProduction(_unitsPerSecond, _unitRecruitmentRate, _goldPerSecond);
                _time -= _interval;
            }
        }
    }
}