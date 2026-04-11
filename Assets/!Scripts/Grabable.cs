using System;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Serialization;

public class Grabable : MonoBehaviour
{
    public bool Throwable = false;
    [ShowIf("Throwable"), SerializeField] float mass = 1f;
   private Collider col;
   private void Start()
   {
      col = GetComponent<Collider>();
   }

   /// <summary>
   /// Happens when the item is first picked up
   /// </summary>
   public virtual void OnPickup(Hand hand)
   {
       col.isTrigger = true;
       if(col.attachedRigidbody != null)
           col.attachedRigidbody.isKinematic = true; //simplified
   }

   /// <summary>
   /// Happens when the item is let go off
   /// </summary>
   public virtual void OnDrop(Hand hand)
   {
       col.isTrigger = false;
       if (col.attachedRigidbody != null)
       {
           col.attachedRigidbody.isKinematic = false; // here too
           
           if(!Throwable) return;
           col.attachedRigidbody.AddForce(hand.CalculateVelocity() / mass, ForceMode.Force);
       }
        GetComponent<waterBaloon>()?.ArmBalloon();
   }

   /// <summary>
   /// When the player holds trigger, this will run once
   /// </summary>
   public virtual void OnAction()
   {
      
   }

   /// <summary>
   /// This runs when the player lets go off the trigger
   /// </summary>
   public virtual void OnEndAction()
   {
      
   }
}
