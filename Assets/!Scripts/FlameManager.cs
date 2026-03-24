using UnityEngine;
using System.Collections;

public class FlameManager : MonoBehaviour
{
    public FlameSlot[] slots;

    public float minDelay = 0.5f;
    public float maxDelay = 2f;

    void Start()
    {
        StartCoroutine(ActivateRandomFlames());
    }

    IEnumerator ActivateRandomFlames()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));

            int index = Random.Range(0, slots.Length);
            slots[index].ActivateFlame();
        }
    }
}
