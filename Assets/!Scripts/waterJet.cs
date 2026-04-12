using System;
using System.Collections.Generic;
using UnityEngine;

public class waterJet : Grabable
{
    [SerializeField] private ParticleSystem water;
    private List<ParticleCollisionEvent> collisions = new();
 [SerializeField] public  GameObject objectToToggle;

 private void Update()
 {
     foreach (var flame in FindObjectsByType<FlameSlot>(FindObjectsSortMode.None))
     {
         GetParticleCollisions(flame.gameObject); 
     }
     foreach (var torch in FindObjectsByType<ExtinguishTorch>(FindObjectsSortMode.None))
    {
        GetParticleCollisions(torch.gameObject);
    }

 }

 private void GetParticleCollisions(GameObject go)
 {
    water.GetCollisionEvents(go, collisions);

    foreach (var collision in collisions)
    {
        Debug.Log(collision.colliderComponent.name);
        if (collision.colliderComponent.TryGetComponent(out FlameSlot flame))
        {
            flame.DeactivateFlame();
        }
        else if (collision.colliderComponent.gameObject.TryGetComponent(out ExtinguishTorch torch))
        {
            torch.Extinguish();
        }
    }
 }

 public override void OnAction()
    {
        Debug.Log("Action triggered!");
        if (objectToToggle != null)
        {
            objectToToggle.SetActive(true);
        }

    }

    public override void OnEndAction()
    {
        Debug.Log("Action released!");
        if (objectToToggle != null)
        {
            objectToToggle.SetActive(false);
        }
    }
}
