
using Gameplay.Interfaces;
using UnityEngine;
using Zenject;

namespace Gameplay.Controllers.Units
{
    public class UnitController : MonoBehaviour
    {
        [SerializeField] private Collider2D _unit;
        
        [SerializeField] private Animator _movingAnimation;
        [SerializeField] private Animator _selectedAnimation;
        [SerializeField] private Animator _targetAnimation;
        
        [SerializeField] private GameObject _selected;
        [SerializeField] private GameObject _target;
        
        [Inject] private IUnitService _unitService;

        private bool _isSelected;
        private Camera _camera;

        private void Start()
        {
            InitUnit();
            
            _movingAnimation.SetTrigger("Idle");
            _camera = Camera.main;
        }

        private void Update()
        {
            if (!Input.GetMouseButtonDown(0)) 
                return;
            
            var mousePosition = _camera.ScreenToWorldPoint(Input.touches[0].position);
            var hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider == _unit && !_isSelected)
            {
                _unitService.OnUnitSelected();
                
                _isSelected = true;
                _selected.SetActive(true);
                _selectedAnimation.SetTrigger("Selected");
            }

            else if (_isSelected)
            {
                _unitService.OnUnitNotSelected();
                
                _movingAnimation.SetTrigger("Walk");
                _isSelected = false;
                MoveOnTilemap.MoveUnit(gameObject);
                _selectedAnimation.SetTrigger("Selected");
                _selected.SetActive(false);
            }
        }

        public void OnSetIdleAnimation()
        {
            _movingAnimation.SetTrigger("Idle");
            
            _target.SetActive(false);
            _targetAnimation.SetTrigger("Target");
        }
        
        public void OnSetTargetAnimation(Vector3 position)
        {
            _target.transform.position = position;
            _target.SetActive(true);
            _targetAnimation.SetTrigger("Target");
        }
        
        private void InitUnit()
        {
            _unitService.InitUnit(this);
        }
    }
}