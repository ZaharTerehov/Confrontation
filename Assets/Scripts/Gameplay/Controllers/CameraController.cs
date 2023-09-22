
using UI.Controllers;
using UnityEngine;

namespace Gameplay.Controllers
{
    public class CameraController : MonoBehaviour
    {
        private Vector3 _mouseScrollStartPos;
        private Camera _camera;

        private void Start()
        {
            _camera = GetComponent<Camera>();
        }

        private void Update()
        {
            if (!UIController.MapWindow.activeSelf)
                return;

            if (Input.GetMouseButtonDown(0))
                _mouseScrollStartPos = _camera.ScreenToWorldPoint(Input.mousePosition);

            if (Input.GetMouseButton(0))
            {
                var movement = Vector3.zero;
                movement = _camera.ScreenToWorldPoint(Input.mousePosition) - _mouseScrollStartPos;
                
                _camera.transform.position -= movement;
            }

            CheckLimits();
        }

        private void CheckLimits()
        {
            var boundaries = MapGeneratorController.Rect;

            if (boundaries.xMin - 1.5 > _camera.transform.position.x)
                _camera.transform.position = new Vector3(boundaries.xMin - 1.5f, _camera.transform.position.y,
                    _camera.transform.position.z);
            if (boundaries.xMax * 20 / 100 < _camera.transform.position.x)
                _camera.transform.position = new Vector3(boundaries.xMax * 20 / 100, _camera.transform.position.y,
                    _camera.transform.position.z);
            if (boundaries.yMin > _camera.transform.position.y)
                _camera.transform.position = new Vector3(_camera.transform.position.x, boundaries.yMin, 
                    _camera.transform.position.z);
            if (boundaries.yMax * 25 / 100 < _camera.transform.position.y)
                _camera.transform.position = new Vector3(_camera.transform.position.x, boundaries.yMax * 25 / 100,
                    _camera.transform.position.z);
        }
    }
}