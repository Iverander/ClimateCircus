using System;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Serialization;

public class Grabable : MonoBehaviour
{
    public bool Throwable = false;
    [ShowIf("Throwable"), SerializeField] float mass = 1f;
   [ReadOnly, SerializeField]private Collider col;
   protected virtual void Start()
   {
      col = GetComponent<Collider>();
   }

   /// <summary>
   /// Happens when the item is first picked up
   /// </summary>
   public virtual void OnPickup(Hand hand)
   {
       if(col.attachedRigidbody)
           col.attachedRigidbody.isKinematic = true; //simplified
       
       col.enabled = false;
   }

   /// <summary>
   /// Happens when the item is let go off
   /// </summary>
   public virtual void OnDrop(Hand hand)
   {
       col.enabled = true;
       if (col.attachedRigidbody)
       {
           col.attachedRigidbody.isKinematic = false; // here too
           Debug.Log(col.attachedRigidbody.isKinematic);

           if (Throwable)
           {
               col.attachedRigidbody.AddForce(hand.CalculateVelocity() / mass, ForceMode.Force);
           }
       }
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
