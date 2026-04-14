using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] Vector3 axis = Vector3.up;

    [SerializeField] private float speed = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(axis * (Time.deltaTime * speed));
    }
}
