using System;
using Logic.Animation;
using Logic.Core.Player;
using Services;
using UnityEngine;

namespace Logic.Stacking
{
    public class PlayerStacking : MonoBehaviour
    {
        [SerializeField] private StackOfCube _stackOfCube;
        [SerializeField] private PlayerAnimation _playerAnimation;
        
        private IPlayerCollider _playerCollider;
        
        private void OnEnable()
        {
            _stackOfCube.CubeAdded += OnCubeAdded;
            _stackOfCube.CubeAdded += _playerAnimation.OnCubeAdded;
        }

        private void Start()
        {
            _playerCollider = ServiceLocator.Container.GetService<IPlayerCollider>();
        }

        private void OnDisable()
        {
            _stackOfCube.CubeAdded -= OnCubeAdded;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out Track _) || collision.gameObject.TryGetComponent(out CubeForWall _))
                _playerCollider.OnCollidedWithSurface();
        }

        private void OnCubeAdded(Vector3 position, float offset) => 
            transform.position = new Vector3(position.x, position.y + offset / 2, position.z);
    }
}