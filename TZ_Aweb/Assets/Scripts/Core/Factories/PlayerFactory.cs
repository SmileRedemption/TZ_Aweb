using Core.AssetManagement;
using Logic.CameraLogic;
using Logic.Movement;
using UnityEngine;

namespace Core.Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        private readonly IAssetProvider _assets;

        public PlayerFactory(IAssetProvider assetProvider) => 
            _assets = assetProvider;

        public PlayerMovement CreatePlayer(Vector3 at) => 
            _assets.Instantiate<PlayerMovement>(AssetPath.PlayerPath, at);
    }
}