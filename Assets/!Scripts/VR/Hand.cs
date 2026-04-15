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
                    Player.InputReader.onHandPos_R += UpdatePosition;
                    Player.InputReader.onHandRot_R += UpdateRotation;
                    Player.InputReader.Grab_R += Grab;
                    Player.InputReader.UnGrab_R += UnGrab;
                    Player.InputReader.onUse_R += Use;
                    Player.InputReader.onEndUse_R += EndUse;
                    break;
                }
            case Handedness.Left:
                {
                    Player.InputReader.onHandPos_L += UpdatePosition;
                    Player.InputReader.onHandRot_L += UpdateRotation;
                    Player.InputReader.Grab_L += Grab;
                    Player.InputReader.UnGrab_L += UnGrab;
                    Player.InputReader.onUse_L += Use;
                    Player.InputReader.onEndUse_L += EndUse;
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
        handPos[1] = handPos[0];
        handPos[0] = transform.position;
        
        if(handedness == Handedness.Right)
            handAnimator.SetFloat("Grip", Player.InputReader.gripValue_R);
        else if(handedness == Handedness.Left)
            handAnimator.SetFloat("Grip", Player.InputReader.gripValue_L);
        
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
        
        grabbed.transform.parent = null;
        grabbed.OnDrop(this);
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
