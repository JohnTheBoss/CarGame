using UnityEngine;

public class Car : MonoBehaviour {
    private Vector3 _startPosition;
    private Quaternion _startOrientation;

    private void Awake()
    {
        _startPosition = transform.position;
        _startOrientation = transform.rotation;
    }

    public void ResetCar()
    {
        transform.rotation = _startOrientation;
        transform.position = _startPosition;
    }
}
