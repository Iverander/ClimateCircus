using UnityEngine;

public class MovingRod2 : MonoBehaviour
{
    public float amplitude = 0.2f;
    public float speed = 2f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float offset = Mathf.Sin(Time.time * speed) * amplitude;
        transform.position = startPos + transform.forward * offset;
    }
}
