using UnityEngine;

[DefaultExecutionOrder(-100)]
[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    public static InputReader inputReader = new();
    public static Player instance;

    public Camera camera {get;private set;}
    public Rigidbody rb { get; private set; }


    void Start()
    {
        inputReader.Enable();
        instance = this;
        rb = GetComponent<Rigidbody>();
        camera = GetComponentInChildren<Camera>();
        
        var w = Input.GetJoystickNames();

        foreach (var VARIABLE in w)
        {
            Debug.Log(VARIABLE);
        }
    }
    void OnDestroy()
    {
        inputReader.Disable();
    }


    void Update()
    {
        
    }
}
