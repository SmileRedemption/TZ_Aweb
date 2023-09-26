using System.Collections;
using Logic.Core.PoolOfObject.Cube;
using Services;
using Services.Data;
using UnityEngine;

namespace Logic.Core.PoolOfObject.TrackPool
{
    public class TrackSpawner : ObjectsPool<Track>
    {
        [SerializeField] private Track[] _possibleTrackToSpawnTemplate;
        [SerializeField] private CubeForPickupPool _cubeForPickupPool;
        [SerializeField] private float _delayOfSpawn;
        [SerializeField] private Transform _pointToSpawn;
        
        private void Awake() => 
            Initialize(_possibleTrackToSpawnTemplate);

        private void Start() => 
            StartCoroutine(Spawning());

        private IEnumerator Spawning()
        {
            while (enabled)
            {
                yield return new WaitForSeconds(_delayOfSpawn);
                Spawn();
            }
        }
    
        private void Spawn()
        {
            if (TryGetObject(out Track track))
                SetTrack(track);
            
        }

        private void SetTrack(Track track)
        {
            track.Initialize(_cubeForPickupPool);
        
            track.transform.position = _pointToSpawn.position;
            track.Restart();
            track.TurnOn();
        
            _pointToSpawn.position = track.SpawnPoint;
        }
    }
}