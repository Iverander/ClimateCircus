using UnityEngine;
using System.Collections;
using System.Collections.Generic; 
using FMODUnity;
using FMOD.Studio;

public class DialogueStarter : MonoBehaviour
{
    
    [Header("References")]
    public GameObject characterObj;
    public GameEnding endingAttached; 

    [Header("FMOD Events")]
    public EventReference[] phrases;
    public EventReference endEvent;

    [Header("Timing")]
    public float minDelay = 5f;
    public float maxDelay = 10f;
    public float startDelay = 10f;
    public float gameDuration = 120f;

    [Header("Fade Settings")]
    public float fadeSpeed = 2f;

    private EventInstance currentInstance;

    void Start()
    {
        characterObj.SetActive(true);

        StartCoroutine(DialogueSequence());
        StartCoroutine(GameTimer());
    }

    IEnumerator DialogueSequence()
    {
        yield return new WaitForSeconds(startDelay);

        yield return StartCoroutine(FadeInCharacter());

        foreach (EventReference phrase in phrases)
        {
            currentInstance = RuntimeManager.CreateInstance(phrase);
            currentInstance.start();

            // wait until event finishes
            yield return StartCoroutine(WaitForFMODEvent(currentInstance));

            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);
        }
    }

    IEnumerator GameTimer()
    {
        yield return new WaitForSeconds(gameDuration);

        Debug.Log("The timer is up"); 

        endingAttached.StartGameEnding(); 
    }

    IEnumerator WaitForFMODEvent(EventInstance instance)
    {
        PLAYBACK_STATE state;
        do
        {
            instance.getPlaybackState(out state);
            yield return null;
        }
        while (state != PLAYBACK_STATE.STOPPED);
    }

    IEnumerator FadeInCharacter()
    {
        SpriteRenderer sr = characterObj.GetComponent<SpriteRenderer>();
        if (sr == null) yield break;

        Color color = sr.color;
        color.a = 0;
        sr.color = color;

        while (color.a < 1)
        {
            color.a += Time.deltaTime * fadeSpeed;
            sr.color = color;
            yield return null;
        }
    }
    
}