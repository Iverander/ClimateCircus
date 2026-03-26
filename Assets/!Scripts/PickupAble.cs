using UnityEngine;

public abstract class PickupAble : MonoBehaviour
{
   /// <summary>
   /// Happens when the item is first picked up
   /// </summary>
   public abstract void OnPickup();
   /// <summary>
   /// Happens when the item is let go off
   /// </summary>
   public abstract void OnDrop();
   
   /// <summary>
   /// When the player holds trigger, this will run once
   /// </summary>
   public abstract void OnAction();
   /// <summary>
   /// This runs when the player lets go off the trigger
   /// </summary>
   public abstract void OnEndAction();
}
