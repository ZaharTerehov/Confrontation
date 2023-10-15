
using System;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Gameplay.ConstructionElements;
using Gameplay.Interfaces;
using UnityEngine;
using UnityEngine.Tilemaps;
using Zenject;

namespace Gameplay.Controllers
{
    public class BoardController : MonoBehaviour
    {
        private Camera _camera;

        [SerializeField] private Tile _capital;
        // [SerializeField] private Capital _capital;
        [SerializeField] private Tilemap _tilemap;
        
        [Inject] private IBoardService _builderService;

        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            if (!Input.GetMouseButtonDown(0)) return;
            
            var position = _tilemap.WorldToCell(_camera.ScreenToWorldPoint(Input.mousePosition));
            ClickOnTilemap(position);
        }

        private void ClickOnTilemap(Vector3Int position)
        {
            _builderService.ClickOnTilemap(_tilemap, position, _capital);
        }
    }
}