using UnityEngine;
using System.Collections;

public class FlameManager : MonoBehaviour
{
    public FlameSlot[] slots;
    private bool flamesActivated = true; 

    public float minDelay = 0.5f;
    public float maxDelay = 2f;

    void Start()
    {
        StartCoroutine(ActivateRandomFlames());
    }

    public void deactivateFlames()
    {
        flamesActivated = false; 
    }

    IEnumerator ActivateRandomFlames()
    {
        while (flamesActivated)
        {
            yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));

            if(!flamesActivated) yield break;
            int index = Random.Range(0, slots.Length);
            slots[index].ActivateFlame();
        }
    }
}
