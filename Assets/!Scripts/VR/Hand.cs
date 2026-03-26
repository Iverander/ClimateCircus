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

    private void Update()
    {
       if(toGrab) return;
       if (Vector3.Distance(toGrab.transform.position, transform.position) < .5f)
           toGrab = null;
    }

    private Grabable toGrab;
    private Grabable grabbed;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Grabable pickupAble))
        {
            toGrab = pickupAble;
        }
    }
    

    [Button]
    void Grab()
    {
        if(toGrab == null) return;
        
        toGrab.transform.parent = transform;
        toGrab.transform.localPosition = Vector3.zero;
        toGrab = grabbed;
        grabbed.OnPickup();
    }
    [Button]
    private void UnGrab()
    {
        if(grabbed == null) return;
        
        grabbed.OnDrop();
        grabbed.transform.parent = null;
        grabbed = null;
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
