using System;
using UnityEngine;

public class Grabable : MonoBehaviour
{
   private Collider col;
   protected Rigidbody rb; 
   private void Start()
   {
      col = GetComponent<Collider>();
      rb = GetComponent<Rigidbody>();
   }

   /// <summary>
   /// Happens when the item is first picked up
   /// </summary>
   public virtual void OnPickup()
   {
       if (rb != null)
        {
            rb.isKinematic = true;
        }

        // Keep collider normal (non-trigger) so physics works
        if (col != null)
        {
            col.isTrigger = false;
        }
     // col.isTrigger = true;
   }

   /// <summary>
   /// Happens when the item is let go off
   /// </summary>
   public virtual void OnDrop()
   {
      // Resume physics
        if (rb != null)
        {
            rb.isKinematic = false;
        }

        if (col != null)
        {
            col.isTrigger = false;
        }
      //col.isTrigger =false;
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
