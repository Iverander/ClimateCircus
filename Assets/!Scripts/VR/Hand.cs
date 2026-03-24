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
                    Player.inputReader.onRHandRot += UpdateRotation;
                    break;
                }
            case Handedness.Left:
                {
                    Player.inputReader.onLHandPos += UpdatePosition;
                    Player.inputReader.onLHandRot += UpdateRotation;
                    break;
                }
        }
    }

    void UpdatePosition(Vector3 pos)
    {
        transform.position = pos;
    }
    void UpdateRotation(Quaternion rot)
    {
        transform.rotation = rot;
    }

}
