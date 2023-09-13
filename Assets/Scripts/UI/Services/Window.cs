using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace UI.Services
{
    public class Window : MonoBehaviour, IWindowService
    {
        [SerializeField] private bool _isOpen = true;
        
        public async virtual UniTask Hide()
        {
            if (_isOpen)
            {
                _isOpen = false;
                gameObject.SetActive(_isOpen);
            }
        }

        public async virtual UniTask Show()
        {
            if (!_isOpen)
            {
                _isOpen = true;
                gameObject.SetActive(true);
            }
        }

        public async virtual UniTask Initialize(object data)
        {
        }
    }
}