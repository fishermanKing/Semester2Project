using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    //public float Speed;
    //public float AngularSpeed;
    //Rigidbody rb;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    rb = GetComponent<Rigidbody>();
    //}

    //// Update is called once per frame
    //void FixedUpdate()
    //{
    //    Speed = rb.velocity.magnitude;
    //    AngularSpeed = rb.angularVelocity.magnitude;
    //    rb.AddTorque(Vector3.up);
    //}

    public float speed = 50.0f;

    private void Update()
    {
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }
}
