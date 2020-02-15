using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherScript : MonoBehaviour
{
    SpringJoint spring;
    public float pullSpeed = 0.01f;
    void Start()
    {
        spring = GetComponent<SpringJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Start"))
        {
            transform.position = (new Vector3(transform.position.x, transform.position.y, Mathf.Max(transform.position.z - pullSpeed, -16)));
            spring.spring = 0;
        }
        else
        {
            spring.spring = 2000;
        }
    }
}
