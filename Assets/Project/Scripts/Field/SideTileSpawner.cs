using Lean.Pool;
using UnityEngine;

public class SideTileSpawner : MonoBehaviour {

    public GameObject[] SideTilePrefabs;

    public float SideTileSpawnThreshold;

    private Car _car;

    private float _lastTilesNearX;

    private void Awake()
    {
        _car = FindObjectOfType<Car>();
    }

    private void Start()
    {
        for (var i = 0; i < 10; i++)
        {
            SpawnSideSegments();
        }
    }

    private void Update()
    {
        if (_lastTilesNearX - _car.transform.position.x < SideTileSpawnThreshold)
        {
            SpawnSideSegments();
        }
    }

    public void ResetSideSegments()
    {
        var sideTiles = GameObject.FindGameObjectsWithTag("SideTile");
        foreach (var sideTile in sideTiles)
        {
            LeanPool.Despawn(sideTile);
        }

        _lastTilesNearX = 0;
        for (var i = 0; i < 10; i++)
        {
            SpawnSideSegments();
        }
    }

    private void SpawnSideSegments()
    {
        var leftIndex = Random.Range(0, SideTilePrefabs.Length);
        var rightIndex = Random.Range(0, SideTilePrefabs.Length);

        var leftPrefab = SideTilePrefabs[leftIndex];
        var rightPrefab = SideTilePrefabs[rightIndex];

        var nearX = _lastTilesNearX + 15;

        var left = LeanPool.Spawn(leftPrefab);
        left.transform.parent = transform;
        left.GetComponent<SideTile>().MoveToPosition(Side.Left, nearX);

        var right = LeanPool.Spawn(rightPrefab);
        right.transform.parent = transform;
        right.GetComponent<SideTile>().MoveToPosition(Side.Right, nearX);

        _lastTilesNearX = nearX;
    }
}
