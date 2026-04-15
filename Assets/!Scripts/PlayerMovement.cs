using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Camera cam => Player.instance.camera;
    Vector3 cameraForward => new Vector3(cam.transform.forward.x, 0, cam.transform.forward.z).normalized;
    Vector3 cameraRight => new Vector3(cam.transform.right.x, 0, cam.transform.right.z).normalized;
    Vector3 moveDir => (cameraForward * moveVal.y + cameraRight * moveVal.x).normalized;
    Vector2 moveVal;

    [SerializeField] float speed;

    Rigidbody rb => Player.instance.rb;
    void Start()
    {
        Player.InputReader.onMove += GetMoveValue;
    }

    private void OnDestroy()
    {
       Player.InputReader.onMove -= GetMoveValue; 
    }

    void FixedUpdate()
    { 
        //rb.AddForce(100 * speed * Time.fixedDeltaTime * moveDir, ForceMode.Force);
        Debug.Log(moveDir);
        rb.linearVelocity = moveDir * (speed * 100 * Time.fixedDeltaTime) + new Vector3(0, rb.linearVelocity.y, 0);
        LimitSpeed();
    }

    void GetMoveValue(Vector2 val)
    {
        moveVal = val;
    }
    void LimitSpeed()
    {
        Vector3 maxVelocity = new(rb.linearVelocity.x, 0, rb.linearVelocity.z);

        if (maxVelocity.magnitude > speed)
        {
            Vector3 newSpeed = maxVelocity.normalized * speed;
            rb.linearVelocity = new Vector3(newSpeed.x, rb.linearVelocity.y, newSpeed.z);
        }
    }
}
