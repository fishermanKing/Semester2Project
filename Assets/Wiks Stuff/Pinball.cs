using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinball : MonoBehaviour
{
    [SerializeField] private float globalGravity = 9.81f;
    [SerializeField] private float gravityScale = 1.0f;

    public bool warpSpeed = false;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.maxAngularVelocity = 1000;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 gravity = globalGravity * gravityScale * -Vector3.up;
        rb.AddForce(gravity, ForceMode.Acceleration);

        if(warpSpeed)
        {
            warpSpeed = false;
            rb.velocity = rb.velocity * 2;
        }
    }
}
