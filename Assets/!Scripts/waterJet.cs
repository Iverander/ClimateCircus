using System;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;
using Random = System.Random;

public class waterJet : Grabable
{
    [SerializeField] private ParticleSystem water;
    [SerializeField] private StudioEventEmitter waterAudio;
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
            if(UnityEngine.Random.Range(0, 5) != 0) return;
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
        
        water.Play();
        waterAudio.Play();
        /*
        if (objectToToggle != null)
        {
            objectToToggle.SetActive(true);
        }*/

    }

    public override void OnEndAction()
    {
        Debug.Log("Action released!");
        
        water.Stop();
        waterAudio.Stop();
        /*
        if (objectToToggle != null)
        {
            objectToToggle.SetActive(false);
        }*/
    }
}
