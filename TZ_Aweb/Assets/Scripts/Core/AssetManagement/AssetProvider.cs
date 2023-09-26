using Logic.Core.PoolOfObject.TrackPool;
using Logic.Movement;
using UnityEngine;

namespace Core.AssetManagement
{
    public class AssetProvider : IAssetProvider
    {
        public T Instantiate<T>(string path, Vector3 at) where T : Object
        {
            var prefab = Resources.Load<T>(path);
            return Object.Instantiate(prefab, at, Quaternion.identity);
        }

        public T Instantiate<T>(string path) where T : Object
        {
            var prefab = Resources.Load<T>(path);
            return Object.Instantiate(prefab);
        }
    }
}