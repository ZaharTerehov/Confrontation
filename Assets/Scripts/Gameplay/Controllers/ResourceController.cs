
using UnityEngine;

namespace Gameplay.Controllers
{
    public class ResourceController : MonoBehaviour
    {
        [SerializeField] float _interval = 2f;
        
        [SerializeField] private float _unitsCapital;
        [SerializeField] private float _unitsPerSecond = 1f;
        
        [Space]
        [SerializeField] private int _gold;
        [SerializeField] private int _goldPerSecond = 1;
        
        [Space]
        [SerializeField] private float _unitRecruitmentRate = 1.1f;
        
        private float _time;

        private void Start()
        {
            _time = 0f;
        }
        
        private void Update() 
        {
            _time += Time.deltaTime;
            
            while(_time >= _interval) {
                ResourceProduction();
                _time -= _interval;
            }
        }

        private void ResourceProduction()
        {
            _unitsCapital += _unitsPerSecond * _unitRecruitmentRate;
            _gold += _goldPerSecond;
        }
    }
}