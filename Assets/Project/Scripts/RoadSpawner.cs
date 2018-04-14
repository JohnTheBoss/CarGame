using Lean.Pool;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public GameObject RoadSegmentPrefab;
    public GameObject LastRoadSegment;

    public float RoadSegmentSpawnThreshold;

    private Car _car;

    private void Awake()
    {
        _car = FindObjectOfType<Car>();
    }

    private void Start()
    {
        for (var i = 0; i < 30; i++)
        {
            SpawnRoadSegment();
        }
    }

    private void Update()
    {
        if (LastRoadSegment.transform.position.x - _car.transform.position.x < RoadSegmentSpawnThreshold)
        {
            SpawnRoadSegment();
        }
    }

    private void SpawnRoadSegment()
    {
        var position = Vector3.zero;
        if (LastRoadSegment != null)
        {
            position = new Vector3(LastRoadSegment.transform.position.x + 5, 0, 0);
        }

        LastRoadSegment = LeanPool.Spawn(RoadSegmentPrefab, position, Quaternion.identity, transform);
    }

    public void ResetRoad()
    {
        var roadSegments = GameObject.FindGameObjectsWithTag("RoadSegment");
        foreach (var roadSegment in roadSegments)
        {
            LeanPool.Despawn(roadSegment);
        }

        LastRoadSegment = null;
        for (var i = 0; i < 30; i++)
        {
            SpawnRoadSegment();
        }
    }
}