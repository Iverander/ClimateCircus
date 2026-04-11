using System;
using FMODUnity;
using UnityEngine;

public class VolumeAdjuster : MonoBehaviour
{
    StudioEventEmitter emitter;

    [Range(0, 1), SerializeField] private float volume;
    void Start()
    {
        emitter = GetComponent<StudioEventEmitter>();
        emitter.EventInstance.setVolume(volume);
    }

    private void Update()
    {
        //emitter.EventInstance.setVolume(volume); 
    }
}
