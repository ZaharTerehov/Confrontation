
using System;
using Cysharp.Threading.Tasks;
using Gameplay.Controllers.ConstructionElements;
using Gameplay.Enums;
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
        [SerializeField] private Animator _bloodAnimation;
        [SerializeField] private Animator _targetAnimation;
        [SerializeField] private Animator _combineAnimation;
        
        [SerializeField] private GameObject _selected;
        [SerializeField] private GameObject _target;
        
        [Inject] private IUnitService _unitService;

        private SettlementController _targetAttack;

        private bool _isSelected;
        private bool _isAttacked;
        private Camera _camera;

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
            _target.SetActive(false);
            _targetAnimation.SetTrigger("Target");

            if (_isAttacked)
            {
                _movingAnimation.SetTrigger("Attack");
                _bloodAnimation.SetTrigger("Blood");
                return;
            }
            
            _movingAnimation.SetTrigger("Idle");
        }
        
        public void OnSetTargetAnimation(Vector3 position)
        {
            _target.transform.position = position;
            _target.SetActive(true);
            _targetAnimation.SetTrigger("Target");
        }
        
        public void InitUnit(int countUnit)
        {
            _movingAnimation.SetTrigger("Idle");
            _camera = Camera.main;

            _unitService.InitUnit(this, countUnit);
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (!gameObject.activeSelf && collider.gameObject.GetComponent<UnitController>() != null)
            { 
                _unitService.CombineUnits(collider.gameObject.GetComponent<UnitController>().GetUnit());
                collider.gameObject.SetActive(false);
                _combineAnimation.SetTrigger("Combine");
            }

            var settlement = collider.gameObject.GetComponent<SettlementController>();

            if (gameObject.activeSelf && settlement != null)
            {
                if (settlement.GetType() != ObjectOwnership.Allied)
                {
                    _targetAttack = settlement;
                    _isAttacked = true;
                    Attack();
                }
            }
        }

        private void EnterSettlement()
        {
            _targetAttack.AddUnit(this);
            gameObject.SetActive(false);
        }

        private async void Attack()
        {
            while (_isAttacked)
            {
                _unitService.TakeDamage(_targetAttack);

                if (_targetAttack.GetGarrisonDefendersAndPlayerSquad().Item1 <= 0 &&
                    _targetAttack.GetGarrisonDefendersAndPlayerSquad().Item2 <= 0)
                {
                    EnterSettlement();
                    _isAttacked = false;
                }
                    
                
                _targetAttack.TakeDamage(this);

                await UniTask.Delay(TimeSpan.FromSeconds(2f));
            }
            
            _bloodAnimation.SetTrigger("Blood");
            _movingAnimation.SetTrigger("Idle");
            

        }

        public int GetUnit() => _unitService.GetCountUnits();
        
        public int GetPower() => _unitService.GetPower();
        
        public class Factory : PlaceholderFactory<UnitController> {}
    }
}