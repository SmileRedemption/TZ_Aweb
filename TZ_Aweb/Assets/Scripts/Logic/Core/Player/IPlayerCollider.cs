using System;
using Services;

namespace Logic.Core.Player
{
    public interface IPlayerCollider : IService
    {
        event Action CollidedWithSurface;
        void OnCollidedWithSurface();
    }
}