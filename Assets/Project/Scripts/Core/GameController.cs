using UnityEngine;

public class GameController : MonoBehaviour {
    private Car _car;
    private EnemyCarSpawner _enemyCarSpawner;
    private RoadSpawner _roadSpawner;
    private SideTileSpawner _sideTileSpawner;
    private GameObject dd;

    public UIScore ScoreText;
    public UIScore BestScoreText;

    private void Start()
    {
        BestScoreText.Score = PlayerPrefs.GetInt("HighScore", 0);
    }

    private void Awake()
    {
        _car = FindObjectOfType<Car>();
        _enemyCarSpawner = FindObjectOfType<EnemyCarSpawner>();
        _roadSpawner = FindObjectOfType<RoadSpawner>();
        _sideTileSpawner = FindObjectOfType<SideTileSpawner>();
    }

    public void ResetGame()
    {
        if(BestScoreText.Score < ScoreText.Score)
        {
            BestScoreText.Score = ScoreText.Score;
        }

        _car.ResetCar();
        _enemyCarSpawner.ResetEnemyCars();
        _roadSpawner.ResetRoad();
        _sideTileSpawner.ResetSideSegments();
    }

    public void UpdateBestScore(int NewBestScore)
    {
        BestScoreText.Score = NewBestScore;
    }

    private void Update()
    {
        ScoreText.Score = Mathf.Max(0, Mathf.FloorToInt(_car.transform.position.x / 10));
    } 
}
