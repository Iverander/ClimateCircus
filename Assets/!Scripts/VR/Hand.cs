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
                    Player.inputReader.onHandPos_R += UpdatePosition;
                    Player.inputReader.onHandRot_R += UpdateRotation;
                    break;
                }
            case Handedness.Left:
                {
                    Player.inputReader.onHandPos_L += UpdatePosition;
                    Player.inputReader.onHandRot_L += UpdateRotation;
                    break;
                }
        }
    }

    void UpdatePosition(Vector3 pos)
    {
        transform.localPosition = pos;
    }
    void UpdateRotation(Quaternion rot)
    {
        transform.localRotation = rot;
    }

}
