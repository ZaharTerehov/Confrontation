
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
                var movement = _camera.ScreenToWorldPoint(Input.mousePosition) - _mouseScrollStartPos;
                _camera.transform.position -= movement;
            }
            
            CheckLimits();
        }

        private void CheckLimits()
        {
            var boundaries = MapGeneratorController.Rect;

            var cameraPosition = _camera.transform.position;

            if (boundaries.xMin - 4.5 > _camera.transform.position.x)
                _camera.transform.position = new Vector3(boundaries.xMin - 4.5f, cameraPosition.y,
                    cameraPosition.z);
            if (boundaries.xMax * 20 / 100 < _camera.transform.position.x)
                _camera.transform.position = new Vector3(boundaries.xMax * 20 / 100, cameraPosition.y,
                    cameraPosition.z);
            if (boundaries.yMin - 4.5 > _camera.transform.position.y)
                _camera.transform.position = new Vector3(cameraPosition.x, boundaries.yMin - 4.5f, 
                    cameraPosition.z);
            if (boundaries.yMax * 25 / 100 < _camera.transform.position.y)
                _camera.transform.position = new Vector3(cameraPosition.x, boundaries.yMax * 25 / 100,
                    cameraPosition.z);
        }
    }
}