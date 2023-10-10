﻿
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
        private bool _levelIsLoaded;

        private static ResourceController _instance;

        private void Start()
        {
            _instance = this;
            _time = 0f;
        }
        
        private void Update()
        {
            if (!_levelIsLoaded) 
                return;
            
            _time += Time.deltaTime;
                
            while(_time >= _interval) {
                _resourceService.ResourceProduction(_unitsPerSecond, _unitRecruitmentRate, _goldPerSecond);
                _time -= _interval;
            }
        }

        public static void LoadLevel()
        {
            _instance._levelIsLoaded = true;
        }
        
        public static void ExitLevel()
        {
            _instance._levelIsLoaded = false;
            _instance._resourceService.ResetResource();
        }
    }
}