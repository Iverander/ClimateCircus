using UnityEngine;

public class FlameSlot : MonoBehaviour
{
     public GameObject flamePrefab;

    private GameObject currentFlame;

    public void ActivateFlame()
    {
        if (currentFlame == null)
        {
            currentFlame = Instantiate(flamePrefab, transform.position, Quaternion.identity, transform);
        }
    }

    public void DeactivateFlame()
    {
        if (currentFlame != null)
        {
            Destroy(currentFlame);
            currentFlame = null;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // something hit the slot → remove flame
        DeactivateFlame();
    }
}
