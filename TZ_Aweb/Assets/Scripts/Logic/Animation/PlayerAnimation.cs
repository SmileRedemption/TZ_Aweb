using System;
using UnityEngine;

namespace Logic.Animation
{
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private void Start()
        {
            _animator.Play("Idle");
        }

        public void OnCubeAdded(Vector3 at, float offset)
        {
            _animator.Play("Jumping");
        }
    }
}