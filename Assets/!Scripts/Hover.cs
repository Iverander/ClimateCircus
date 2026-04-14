using UnityEngine;

public class Hover : MonoBehaviour
{
    [SerializeField] Vector3 hoverAxis = Vector3.up;
    [SerializeField] private float degree = .2f;
    void Update()
    {
        transform.position += hoverAxis * (Mathf.Sin(Time.time) * degree * Time.deltaTime);
    }
}
