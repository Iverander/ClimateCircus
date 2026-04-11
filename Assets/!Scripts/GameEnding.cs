
using UnityEngine;
using System.Collections;
using FMODUnity;
using FMOD.Studio;
using System.Diagnostics;

public class GameEnding : MonoBehaviour{

    [Header("FMOD Events")]
    
    public EventReference winningGame;
    public FlameManager flameManager1; 
    public FlameManager flameManager2; 
    public FlameManager flameManager3; 
     public FlameManager flameManager4; 
    public FlameManager flameManager5; 
    public FlameManager flameManager6; 
     public FlameManager flameManager7; 
    public FlameManager flameManager8; 
    public FlameManager flameManager9; 

    private int flameCount = 0; 
    public GameObject ringmaster; 
    
    public void IncreaseFlameCount()
    {
        flameCount++; 
    }
    public void DecreaseFlameCount()
    {
        flameCount--; 
    }
    public void CheckFlameCount()
    {
        if (flameCount == 0 )
        {
            flameManager1.deactivateFlames(); 
            flameManager2.deactivateFlames(); 
            flameManager3.deactivateFlames(); 
            flameManager4.deactivateFlames(); 
            flameManager5.deactivateFlames(); 
            flameManager6.deactivateFlames(); 
            flameManager7.deactivateFlames(); 
            flameManager8.deactivateFlames(); 
            flameManager9.deactivateFlames(); 
            
            

            var emitter = new GameObject().AddComponent<StudioEventEmitter>();
            emitter.EventReference = winningGame;
            emitter.Play();

            RuntimeManager.PlayOneShot(winningGame);
        }
    }

    
}
