using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    SpringJoint spring;
    public float pullSpeed = 5f;
    public float springPower = 500f;

    Vector3 defaultPos;
    Vector3 pulledPos;

    void Start()
    {
        defaultPos = transform.position;
        pulledPos = defaultPos + new Vector3(0, 0, -2.5f);
        spring = GetComponent<SpringJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Start"))
        {
            transform.position = Vector3.MoveTowards(transform.position, pulledPos, pullSpeed * Time.deltaTime);
            spring.spring = 5;
        }
        else
        {
            spring.spring = springPower;
        }
    }
}
