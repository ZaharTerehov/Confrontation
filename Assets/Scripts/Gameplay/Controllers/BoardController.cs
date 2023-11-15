
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
        [SerializeField] private Tile _settlement;
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
            _builderService.ClickOnTilemap(_tilemap, position, _capital, _settlement);
        }
    }
}