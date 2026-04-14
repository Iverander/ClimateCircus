
using UnityEngine;
using System.Collections;
using FMODUnity;
using FMOD.Studio;

public class GameEnding : MonoBehaviour{

    [Header("FMOD Events")]
    
    public EventReference winningGame;
    public FlameManager flameManager1; 
    public FlameManager flameManager2; 
    public FlameManager flameManager3; 

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
            RuntimeManager.PlayOneShot(winningGame);
            flameManager1.deactivateFlames(); 
            flameManager2.deactivateFlames(); 
            flameManager3.deactivateFlames(); 
            
        }
    }

    
}
