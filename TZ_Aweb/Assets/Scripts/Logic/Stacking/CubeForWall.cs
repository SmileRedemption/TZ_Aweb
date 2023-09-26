using System;
using UnityEngine;

namespace Logic.Stacking
{
    public class CubeForWall : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out CubeForPickup cubeForPickup)) 
                cubeForPickup.CollideWithWall();
        }
    }
}