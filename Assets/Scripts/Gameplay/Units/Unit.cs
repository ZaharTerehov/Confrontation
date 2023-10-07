
using UnityEngine;
using Gameplay.Controllers;
using Gameplay.Services;

namespace Gameplay.Units
{
    public class Unit : MonoBehaviour
    {
        [SerializeField] private Collider2D _unit;
        
        [SerializeField] private Animator _movingAnimation;
        [SerializeField] private Animator _selectedAnimation;
        [SerializeField] private Animator _targetAnimation;
        
        [SerializeField] private GameObject _selected;
        [SerializeField] private GameObject _target;
        
        private bool _isSelected;
        private static Unit _instance;

        private void Start()
        {
            _instance = this;
            
            MoveOnTilemapService.EndMovement += OnSetIdleAnimation;
            MoveOnTilemapService.EndPosition += OnSetTargetAnimation;
            _movingAnimation.SetTrigger("Idle");
        }

        private void Update()
        {
            if (!Input.GetMouseButtonDown(0)) return;
            
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.touches[0].position);
            var hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider == _unit && !_isSelected)
            {
                _isSelected = true;
                _selected.SetActive(true);
                _selectedAnimation.SetTrigger("Selected");
            }

            else if (_isSelected)
            {
                _movingAnimation.SetTrigger("Walk");
                _isSelected = false;
                MoveOnTilemap.MoveUnit(gameObject);
                _selectedAnimation.SetTrigger("Selected");
                _selected.SetActive(false);
                
 
            }
        }

        private static void OnSetIdleAnimation()
        {
            _instance._movingAnimation.SetTrigger("Idle");
            
            _instance._target.SetActive(false);
            _instance._targetAnimation.SetTrigger("Target");
        }
        
        private static void OnSetTargetAnimation(Vector3 position)
        {
            _instance._target.transform.position = position;
            _instance._target.SetActive(true);
            _instance._targetAnimation.SetTrigger("Target");
        }
    }
}