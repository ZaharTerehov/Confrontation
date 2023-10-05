
using UnityEngine;
using Gameplay.Controllers;
using Gameplay.Services;

namespace Gameplay.Units
{
    public class Unit : MonoBehaviour
    {
        [SerializeField] private Collider2D _unit;
        [SerializeField] private Animator _animator;
        
        private bool _isSelected;
        private static Unit _instance;

        private void Start()
        {
            _instance = this;
            
            MoveOnTilemapService.EndMovement += OnSetIdleAnimation;
            _animator.SetTrigger("Idle");
        }

        private void Update()
        {
            if (!Input.GetMouseButtonDown(0)) return;
            
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.touches[0].position);
            var hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider == _unit && !_isSelected)
                _isSelected = true;
                
            else if (_isSelected)
            {
                _animator.SetTrigger("Walk");
                _isSelected = false;
                MoveOnTilemap.MoveUnit(gameObject);
            }
        }

        private static void OnSetIdleAnimation()
        {
            _instance._animator.SetTrigger("Idle");
        }
    }
}