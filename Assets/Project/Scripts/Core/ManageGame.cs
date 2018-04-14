using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManageGame : MonoBehaviour {

    public GameObject GameOverUI;

    public Text ScoreText;
    public Text BestScoreText;

    private CarMove _carMove;
    private int _score;
    private int _bestScore;

    private void Awake()
    {
        _bestScore = PlayerPrefs.GetInt("HighScore", 0);
        _carMove = FindObjectOfType<CarMove>();
    }


    public void GameOver()
    {
        GameObject.Find("UI Root").SetActive(false);
        GameOverUI.SetActive(true);

        GameController _gameController = GameObject.Find("InGameUI").GetComponent<GameController>();
        _score = _gameController.ScoreText.Score;
        _bestScore = _gameController.BestScoreText.Score;

        ScoreText.text = "Score: " + _score.ToString();
        
        if (_bestScore < _score)
        {
            _bestScore = _score;
            PlayerPrefs.SetInt("HighScore", _bestScore);
        }

        BestScoreText.text = "Best: " + _bestScore;

        

        FindObjectOfType<EnemyCarSpawner>().StopSpawn();
        StopAllEnemyCars();
        _carMove.StopCarMove();

        Debug.Log("GAME OVER");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /*
     *  This function, search all enemycar, and stop move. 
    */
    private void StopAllEnemyCars()
    {
        EnemyCarMove[] enemyCarsMove = FindObjectsOfType(typeof(EnemyCarMove)) as EnemyCarMove[];
        foreach (EnemyCarMove enemyCar in enemyCarsMove)
        {
            enemyCar.StopEnemyMove();
        }
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
