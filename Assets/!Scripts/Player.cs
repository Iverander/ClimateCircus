using UnityEngine;

[DefaultExecutionOrder(-100)]
[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    public static InputReader inputReader = new();
    public static Player instance;


    public Rigidbody rb { get; private set; }


    void Start()
    {
        inputReader.Enable();
        instance = this;
        rb = GetComponent<Rigidbody>();
    }
    void OnDestroy()
    {
        inputReader.Disable();
    }


    void Update()
    {
        
    }
}
