using UnityEngine;

public class Hand : MonoBehaviour
{
    public enum Handedness
    {
        Right,
        Left
    }


    public Handedness handedness;

    void Start()
    {
        switch(handedness)
        {
            case Handedness.Right:
                {
                    Player.inputReader.onRHandPos += UpdatePosition;
                    break;
                }
            case Handedness.Left:
                {
                    Player.inputReader.onLHandPos += UpdatePosition;
                    break;
                }
        }
    }

    void UpdatePosition(Vector3 pos)
    {
        transform.position = pos;
    }

}
