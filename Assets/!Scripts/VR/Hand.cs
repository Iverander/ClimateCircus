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


    [SerializeField] private Animator handAnimator; 
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
                    Player.inputReader.onUse_R += Use;
                    Player.inputReader.onEndUse_R += EndUse;
                    break;
                }
            case Handedness.Left:
                {
                    Player.inputReader.onHandPos_L += UpdatePosition;
                    Player.inputReader.onHandRot_L += UpdateRotation;
                    Player.inputReader.Grab_L += Grab;
                    Player.inputReader.UnGrab_L += UnGrab;
                    Player.inputReader.onUse_L += Use;
                    Player.inputReader.onEndUse_L += EndUse;
                    break;
                }
        }
    }

    private void EndUse()
    {
        handAnimator.SetFloat("Trigger", 0);
        if (!grabbed) return;
        
        grabbed.OnEndAction();
    }

    private void Use()
    {
        handAnimator.SetFloat("Trigger", 1);
       if(!grabbed) return;
       
       grabbed.OnAction();
    }

    private void Update()
    {
       if(!toGrab || grabbed) return;
       if (Vector3.Distance(toGrab.transform.position, transform.position) > .5f)
           toGrab = null;
    }

    [SerializeField, ReadOnly]private Grabable toGrab;
    private Grabable grabbed;
    private void OnTriggerEnter(Collider other)
    {
        if(grabbed) return;
        if (other.TryGetComponent(out Grabable pickupAble))
        {
            toGrab = pickupAble;
        }
    }
    

    [Button]
    void Grab()
    {
        handAnimator.SetFloat("Grip", 1);
        
        if(!toGrab) return;
        
        grabbed = toGrab;
        toGrab = null;
        grabbed.transform.parent = transform;
        grabbed.OnPickup();
    }
    [Button]
    private void UnGrab()
    {
        handAnimator.SetFloat("Grip", 0);
        if(!grabbed) return;
        
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
