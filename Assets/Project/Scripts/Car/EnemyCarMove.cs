using UnityEngine;

public class EnemyCarMove : MonoBehaviour {
    public float MinimumSpeed;
    public float MaximumSpeed;

    private float _deltaTime;
    private bool _gameRun = true;

    private static readonly Vector3 ForwardDirection = new Vector3(0, 0, 1);
    private float _speed;


    private void Start()
    {
        _speed = Random.Range(MinimumSpeed, MaximumSpeed);
    }

    private void Update()
    {
        if (_gameRun) {
            _deltaTime = Time.deltaTime;
        }
        else
        {
            _deltaTime = 0;
        }
        transform.Translate(ForwardDirection * _speed * _deltaTime);
    }

    public void StopEnemyMove()
    {
        _gameRun = false;
    }

}
