using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Haptics;

public class Hand : MonoBehaviour
{
    public enum Handedness
    {
        Right,
        Left
    }


    [SerializeField] private Animator handAnimator; 
    public Handedness handedness;
    private HapticImpulsePlayer hapticPlayer;
    
    [ReadOnly] public List<Vector3> handPos = new()
    {
        Vector3.zero,
        Vector3.zero
    };

    void Start()
    {
        hapticPlayer = GetComponent<HapticImpulsePlayer>();
        
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
        if (!grabbed) return;
        
        grabbed.OnEndAction();
    }

    private void Use()
    {
       if(!grabbed) return;
       
       HapticFeedback(.6f, .1f);
       grabbed.OnAction();
    }

    private void Update()
    {
        handPos[0] = transform.position;
        handPos[1] = handPos[0];
        
        if(handedness == Handedness.Right)
            handAnimator.SetFloat("Grip", Player.inputReader.gripValue_R);
        else if(handedness == Handedness.Left)
            handAnimator.SetFloat("Grip", Player.inputReader.gripValue_L);
        
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
            HapticFeedback(.3f, .1f);
            toGrab = pickupAble;
        }
    }
    

    [Button]
    void Grab()
    {
        if(!toGrab) return;
        
        HapticFeedback(.6f, .1f);
        
        grabbed = toGrab;
        toGrab = null;
        grabbed.transform.parent = transform;
        grabbed.OnPickup(this);
    }
    [Button]
    private void UnGrab()
    {
        if(!grabbed) return;
        
        grabbed.OnDrop(this);
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


    public void HapticFeedback(float amp, float dur)
    {
        hapticPlayer.SendHapticImpulse(amp, dur);
    }
    
    public Vector3 CalculateVelocity()
    {
        return (handPos[0] - handPos[1])/Time.deltaTime;
    }
}
