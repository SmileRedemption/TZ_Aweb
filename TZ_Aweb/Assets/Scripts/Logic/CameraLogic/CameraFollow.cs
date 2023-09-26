using UnityEngine;

namespace Logic.CameraLogic
{
    public class CameraFollow : MonoBehaviour
    {
        private Transform _playerTransform;
        private float _offset;

        public void Follow(Transform followTransform)
        {
            _playerTransform = followTransform;
            _offset = Vector3.Distance(_playerTransform.position, transform.position);
        }

        private void LateUpdate()
        {
            if (_playerTransform == null)
            {
                return;
            }
            
            var cameraTransform = transform;
            var newPosition = cameraTransform.position;
            newPosition = new Vector3(newPosition.x, newPosition.y, _playerTransform.position.z - _offset);
            cameraTransform.position = newPosition;
        }
    }
}