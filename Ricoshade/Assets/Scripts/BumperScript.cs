using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float hitStrength = 700f;
    public int points = 100;

    // Update is called once per frame
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == ("Pinball"))
        {
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            //Vector3 temp = (other.transform.position - transform.position);
            //Vector3 newForce = new Vector3((other.transform.position - transform.position).x, (other.transform.position - transform.position).y, 0); //No Z Morce
            Vector3 newForce = new Vector3((other.transform.position - transform.position).x, 0, (other.transform.position - transform.position).z); //No y Force
            //Vector3 newForce = other.transform.position - transform.position;
            rb.AddForce((newForce) * 22000);
            ScoreboardScript.Score += points;
        }
    }
}
