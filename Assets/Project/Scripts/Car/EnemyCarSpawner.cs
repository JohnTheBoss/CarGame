using Lean.Pool;
using UnityEngine;

public class EnemyCarSpawner : MonoBehaviour {

    public GameObject[] EnemyCarPrefabs;

    public float MinimumSpawnZ;
    public float MaximumSpawnZ;
    public float MinimumSpawnSeconds;
    public float MaximumSpawnSeconds;

    private RoadSpawner _roadSpawner;

    private float _nextSpawnTime;
    private float _nextSpawnZ;
    private bool spawn = true;

    private void Awake()
    {
        _roadSpawner = FindObjectOfType<RoadSpawner>();
    }

    private void Start()
    {
        EnqueueNextSpawn();
    }

    private void Update()
    {
        if (spawn)
        {
            if (!(Time.time >= _nextSpawnTime) || _roadSpawner.LastRoadSegment == null) return;

            var carIndex = Random.Range(0, EnemyCarPrefabs.Length);
            var carPrefab = EnemyCarPrefabs[carIndex];
            var startPosition = new Vector3(_roadSpawner.LastRoadSegment.transform.position.x,
                carPrefab.transform.position.y, _nextSpawnZ);

            LeanPool.Spawn(carPrefab, startPosition, carPrefab.transform.rotation, transform);
            EnqueueNextSpawn();
        }
    }

    private void EnqueueNextSpawn()
    {
        _nextSpawnTime = Time.time + Random.Range(MinimumSpawnSeconds, MaximumSpawnSeconds);
        _nextSpawnZ = Random.Range(MinimumSpawnZ, MaximumSpawnZ);
    }

    public void ResetEnemyCars()
    {
        var enemyCars = GameObject.FindGameObjectsWithTag("EnemyCar");
        foreach (var enemyCar in enemyCars)
        {
            LeanPool.Despawn(enemyCar);
        }
        spawn = true;
        EnqueueNextSpawn();
    }

    public void StopSpawn()
    {
        spawn = false;
    }
}
