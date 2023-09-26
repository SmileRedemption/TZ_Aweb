using Services;
using UnityEngine;

namespace Core.AssetManagement
{
    public interface IAssetProvider : IService
    {
        T Instantiate<T>(string path, Vector3 at) where T : Object;
        T Instantiate<T>(string path) where T : Object;
    }
}