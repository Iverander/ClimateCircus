using System;
using UnityEngine;

public class Grabable : MonoBehaviour
{
   private Collider col;
   private void Start()
   {
      col = GetComponent<Collider>();
   }

   /// <summary>
   /// Happens when the item is first picked up
   /// </summary>
   public virtual void OnPickup()
   {
      col.isTrigger = true;
   }

   /// <summary>
   /// Happens when the item is let go off
   /// </summary>
   public virtual void OnDrop()
   {
      col.isTrigger =false;
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
