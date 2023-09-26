using Logic.Movement;
using Services;
using UnityEngine;

namespace Core.Factories
{
    public interface IPlayerFactory : IService
    {
        PlayerMovement CreatePlayer(Vector3 at);
    }
}