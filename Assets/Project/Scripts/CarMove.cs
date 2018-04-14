using UnityEngine;

public class CarMove : MonoBehaviour {
	public Joystick Joystick;

	public float Accelleration;
	public float Speed;
	public float TurnSpeed;
    private float _deltaTime;
    private bool _runGame = true;

	private static readonly Vector3 ForwardDirection = new Vector3(0, 0, 1);

    private void Awake()
    {
        _deltaTime = Time.deltaTime;
    }

    private void Update() {

        if (_runGame)
        {
            _deltaTime = Time.deltaTime;
        } else
        {
            _deltaTime = 0;
        }

		var inputVertical = Joystick.Vertical;
		var inputHorizontal = Joystick.Horizontal;

		transform.Rotate(0, inputHorizontal * TurnSpeed * _deltaTime, 0);
		transform.Translate(ForwardDirection * (Speed + inputVertical * Accelleration) * _deltaTime, Space.Self);
	}

    public void StopCarMove()
    {
        _runGame = false;
    }
}
