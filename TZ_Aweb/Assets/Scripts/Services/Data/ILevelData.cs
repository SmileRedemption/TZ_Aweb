using UnityEngine;

namespace Services.Data
{
    public interface ILevelData : IService
    {
        string LevelKey { get; }
        Vector3 InitialPlayerPosition { get; }
        Vector3 LeftLimitX { get; }
        Vector3 RightLimitX { get; }
    }
}