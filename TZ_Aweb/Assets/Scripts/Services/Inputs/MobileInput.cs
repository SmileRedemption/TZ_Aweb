using System;
using UnityEngine;

namespace Services.Inputs
{
    public class MobileInput : IInputSource
    {
        private const string MouseX = "Mouse X";
        
        private readonly Vector3 _leftDirection = new (-1, 0, 1);
        private readonly Vector3 _rightDirection = new (1, 0, 1);
        
        public event Action OnStartButtonDown;

        public Vector3 GetDirection()
        {
            if (Input.GetMouseButton(0))
            {
                var mouseDelta = Input.GetAxis(MouseX);
                return mouseDelta > 0 ? _rightDirection : _leftDirection;
            }
            
            return Vector3.forward;
        }
        
        public void OnButtonClick() => 
            OnStartButtonDown?.Invoke();
    }
}
