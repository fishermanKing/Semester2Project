using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherNP : MonoBehaviour
{
    public float power = 1000;
    GameObject ball;

    // Update is called once per frame
    void Update()
    {
        if(ball)
        {
            if(Input.GetKeyUp(KeyCode.Space))
            {
                ball.GetComponent<Rigidbody>().AddForce(power * Vector3.forward);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Pinball")
        {
            ball = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Pinball")
        {
            ball = null;
        }
    }
}
