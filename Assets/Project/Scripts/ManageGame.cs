using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManageGame : MonoBehaviour {

    public GameObject GameOverUI;
    private GameController _gameController;

    public Text ScoreText;
    public Text BestScoreText;

    private CarMove _carMove;

    private void Awake()
    {
        _carMove = FindObjectOfType<CarMove>();
    }


    public void GameOver()
    {   
        GameOverUI.SetActive(true);
        FindObjectOfType<EnemyCarSpawner>().StopSpawn();
        StopAllEnemyCars();
        _carMove.StopCarMove();
        Debug.Log("GAME OVER");
    }

    // nekem ez nem biztos hogy kell, mert van egy gamecontroller ami újraindít, bár akkor "bugol" a kamera
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
