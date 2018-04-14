using UnityEngine;

public enum Side { Left, Right };

public class SideTile : MonoBehaviour {
    public Side DefaultSide;
    public float DefaultPosX;
    public float OtherPosX;

    public void MoveToPosition(Side side, float nearX)
    {
        if (side == DefaultSide)
        {
            transform.Translate(nearX, 0, DefaultPosX, Space.World);
            // transform.Translate(nearX, 0, (float)-7.6, Space.World);
        }
        else
        {
            transform.Rotate(Vector3.up, 180);
            transform.Translate(nearX + 15, 0, OtherPosX, Space.World);
            // transform.Translate(nearX + 5, 0, (float)7.6, Space.World);
        }
    }

}
