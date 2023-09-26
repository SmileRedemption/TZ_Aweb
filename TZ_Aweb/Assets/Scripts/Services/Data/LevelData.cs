using UnityEngine;

namespace Services.Data
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "Level")]
    public class LevelData : ScriptableObject, ILevelData
    {
        [field: SerializeField] public string LevelKey { get; private set; }
        [field: SerializeField] public Vector3 InitialPlayerPosition { get; private set; }
        [field: SerializeField] public Vector3 LeftLimitX { get; private set;}
        [field: SerializeField] public Vector3 RightLimitX { get; private set;}
    }
}