using System;
using Core;
using UnityEngine;

namespace Services.Inputs
{
    public interface IInputSource : IService
    {
        Vector3 GetDirection();
        void OnButtonClick();
        event Action OnStartButtonDown;
    }
}