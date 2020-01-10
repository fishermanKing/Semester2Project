using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float hitStrength = 700f;

    // Update is called once per frame
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == ("Pinball"))
        {
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            rb.AddForce((other.transform.position-transform.position)*hitStrength);
            ScoreboardScript.Score += 100;
        }
    }
}
