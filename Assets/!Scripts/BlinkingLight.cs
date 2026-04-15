using UnityEngine;

public class FlickerLight : MonoBehaviour
{
    public float minIntensity = 0.2f;
    public float maxIntensity = 1.5f;
    private Light myLight;

    void Start()
    {
        myLight = GetComponent<Light>();
    }

    void Update()
    {
        // Altera a intensidade aleatoriamente a cada frame
        myLight.intensity = Random.Range(minIntensity, maxIntensity);
    }
}
