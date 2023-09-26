using Logic.Core.PoolOfObject;
using UnityEngine;

namespace Logic.Stacking
{
    [RequireComponent(typeof(Rigidbody))]
    public class CubeForPickup : MonoBehaviour, ISpawnable
    {
        private Rigidbody _rigidbody;
    
        public Vector3 Position => transform.position;
        public bool IsStacking { get; private set; }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void StartMoving(Transform transformForFollowing)
        {
            transform.parent = transformForFollowing;
            StartStacking();
        }
        
        public void CollideWithWall()
        {
            transform.parent = null;
        }

        public void StartStacking()
        {
            IsStacking = true;
            StopKinematic();
        }

        public void StopStacking()
        {
            IsStacking = false;
            StarKinematic();
        }
        
        private void StarKinematic() => _rigidbody.isKinematic = true;
        private void StopKinematic() => _rigidbody.isKinematic = false;
        public void SetPosition(Vector3 position) => transform.position = position;
        
        public void TurnOff() => gameObject.SetActive(false);
        public void TurnOn() => gameObject.SetActive(true);
    }
}