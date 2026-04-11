using UnityEngine;
using FMODUnity;

// Simple grabable object with no extra effects
// A simple grabable with no effects can be achieved with just the grabable script :)))
public class waterBaloon : Grabable // a monobehaviour script (a script thats put onto objects) has to have the same name as its file btw :)))
{
   [Header("Impact Effects")]
    public GameObject splashEffectPrefab;

    [Header("FMOD")]
    public EventReference splashEvent;

    private bool hasHit = false;
    private bool isArmed = false; // NEW: only explodes after throw

    void Awake()
    {
        isArmed = false;
    }

    // CALL THIS when you RELEASE / THROW the object from Grabable
    public void ArmBalloon()
    {
        isArmed = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!isArmed) return;   // ❌ ignore table collisions
        if (hasHit) return;

        hasHit = true;

        Vector3 hitPoint = collision.contacts[0].point;

        // VFX
        if (splashEffectPrefab != null)
        {
            Instantiate(splashEffectPrefab, hitPoint, Quaternion.identity);
        }

        // FMOD sound
        RuntimeManager.PlayOneShot(splashEvent, hitPoint);

        // Hide object
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        WaterBalloonManager.Instance.BalloonDestroyed();

        Destroy(gameObject, 0.5f);
    }

}
