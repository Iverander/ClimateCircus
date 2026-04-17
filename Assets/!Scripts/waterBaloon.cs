using System;
using UnityEngine;
using FMODUnity;

// Simple grabable object with no extra effects
// A simple grabable with no effects can be achieved with just the grabable script :)))
public class waterBaloon : Grabable // a monobehaviour script (a script thats put onto objects) has to have the same name as its file btw :)))
{
   [Header("Impact Effects")]
    public GameObject splashEffectPrefab;

    [Header("FMOD")]
    public EventReference splashEvent;
    private bool isArmed = false; // NEW: only explodes after throw

    protected override void Start() //using start is better
    {
        base.Start();
        isArmed = false;
        WaterBalloonManager.Instance.currentBalloons++; //shortcut for +1
    }

    private void OnDestroy()
    {
        if(!Application.isPlaying) return;

        Collider[] col = Physics.OverlapSphere(transform.position, 2);

        foreach (Collider coll in col)
        {
            if (coll.TryGetComponent(out FlameSlot flame))
            {
                flame.DeactivateFlame();
            }
            else if ( coll.TryGetComponent(out ExtinguishTorch flame2))
            {
                 flame2.Extinguish();
            }
        }
        
        // VFX
        if (splashEffectPrefab != null)
        {
            Destroy(Instantiate(splashEffectPrefab, transform.position, Quaternion.identity), 1);
        }

        // FMOD sound
        RuntimeManager.PlayOneShot(splashEvent, transform.position);
        
        WaterBalloonManager.Instance.BalloonDestroyed();
    }

    public override void OnDrop(Hand hand) //override the original method from the Grabable script with our own
    {
        base.OnDrop(hand); //do the original method
        
        Debug.Log("dropped balloon");
        
        Destroy(gameObject, 5);
        isArmed = true; // arm
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!isArmed) return;   // ❌ ignore table collisions

        Destroy(gameObject);
    }

}
