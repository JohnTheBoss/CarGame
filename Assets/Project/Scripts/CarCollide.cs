using UnityEngine;

public class CarCollide : MonoBehaviour {
    // private GameController _gameController;
    private ManageGame _manageGame;

    private void Awake()
    {
        // _gameController = FindObjectOfType<GameController>();
        _manageGame = FindObjectOfType<ManageGame>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car")){
            // valakinek szólni kell! 
            _manageGame.GameOver();
            // _gameController.ResetGame();
        }
    }
}
