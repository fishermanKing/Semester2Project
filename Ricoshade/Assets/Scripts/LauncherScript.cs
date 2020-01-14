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
            transform.localPosition = (new Vector3(transform.localPosition.x, Mathf.Max(transform.localPosition.y-pullSpeed,-16), transform.localPosition.z));
            spring.spring = 0;
        }
        else
        {
            spring.spring = 2000;
        }
    }
}
