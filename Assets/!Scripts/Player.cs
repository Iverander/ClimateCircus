using UnityEngine;

[DefaultExecutionOrder(-100)]
[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    public static Player instance;
    public static InputReader InputReader = instance.inputReader;

    
    public InputReader inputReader { get; private set; }
    public Camera camera {get;private set;}
    public Rigidbody rb { get; private set; }


    void Start()
    {
        inputReader = new InputReader();
        inputReader.Enable();
        instance = this;
        rb = GetComponent<Rigidbody>();
        camera = GetComponentInChildren<Camera>();
    }
    void OnDestroy()
    {
        inputReader.Disable();
    }


    void Update()
    {
        
    }
}
