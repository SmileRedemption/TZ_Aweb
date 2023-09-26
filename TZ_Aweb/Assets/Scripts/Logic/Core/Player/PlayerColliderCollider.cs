using System;

namespace Logic.Core.Player
{
    public class PlayerColliderCollider : IPlayerCollider
    {
        public event Action CollidedWithSurface;

        public void OnCollidedWithSurface() => 
            CollidedWithSurface?.Invoke();
    }
}