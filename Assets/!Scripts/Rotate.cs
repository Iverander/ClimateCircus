using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] Vector3 axis = Vector3.up;
    [SerializeField] private float speed = 3;
    
    void Update()
    {
        transform.Rotate(axis * (Time.deltaTime * speed));
    }
}
