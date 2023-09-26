using System;
using Services;
using Services.Data;
using Services.Inputs;
using UnityEngine;

namespace Logic.Movement
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private Rigidbody _rigidbody;
        private IInputSource _inputSource;
        private ILevelData _levelData;

        public void Initialize(IInputSource inputSource, ILevelData levelData)
        {
            _inputSource = inputSource;
            _inputSource.OnStartButtonDown += OnStartButtonDown;
            _levelData = levelData;
        }

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnDestroy()
        {
            _inputSource.OnStartButtonDown -= OnStartButtonDown;
        }

        private void FixedUpdate()
        {
            Move(_inputSource.GetDirection());
        }

        private void Move(Vector3 direction)
        {
            var offset = direction.normalized * _speed * Time.fixedDeltaTime;
            var newPosition = _rigidbody.position + offset;
            newPosition = new Vector3(Math.Clamp(newPosition.x, _levelData.LeftLimitX.x, _levelData.RightLimitX.x), newPosition.y, newPosition.z);
            _rigidbody.MovePosition(newPosition);
        }
        
        private void OnStartButtonDown() => 
            gameObject.SetActive(true);
    }
}