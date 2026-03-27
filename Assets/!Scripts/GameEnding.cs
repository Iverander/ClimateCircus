
using UnityEngine;
using System.Collections;
using FMODUnity;
using FMOD.Studio;

public class GameEnding : MonoBehaviour{

    [Header("FMOD Events")]
    
    public EventReference winningGame;

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
        }
    }

    
}
