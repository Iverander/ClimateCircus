using System;
using NaughtyAttributes;
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
                    Player.inputReader.Grab_R += Grab;
                    Player.inputReader.UnGrab_R += UnGrab;
                    break;
                }
            case Handedness.Left:
                {
                    Player.inputReader.onHandPos_L += UpdatePosition;
                    Player.inputReader.onHandRot_L += UpdateRotation;
                    Player.inputReader.Grab_L += Grab;
                    Player.inputReader.UnGrab_L += UnGrab;
                    break;
                }
        }
    }

    private Collider toGrab;
    private Collider grabbed;
    private void OnTriggerEnter(Collider other)
    {
         toGrab = other;
    }

    private void OnTriggerExit(Collider other)
    {
        if(toGrab == other)
            toGrab = null;
    }

    [Button]
    void Grab()
    {
        toGrab = grabbed;
        toGrab.transform.parent = transform;
    }
    
    /*
    [Button]
    private void UnGrab()
    {
        grabbed.transform.parent = null;
        grabbed = null;
    }*/
    void UpdatePosition(Vector3 pos)
    {
        transform.localPosition = pos;
    }
    void UpdateRotation(Quaternion rot)
    {
        transform.localRotation = rot;
    }

}
