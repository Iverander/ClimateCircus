using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 moveDir => (Player.instance.camera.transform.forward * moveVal.y + Player.instance.camera.transform.right * moveVal.x).normalized;
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
        rb.AddForce(100 * speed * Time.fixedDeltaTime * moveDir, ForceMode.Force);
        Debug.Log(moveDir);
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
