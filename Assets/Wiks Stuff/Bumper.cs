using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    public float bumperForce = 10f;
    public GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Pinball");
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == ball)
        {
            ball.GetComponent<Rigidbody>().AddExplosionForce(bumperForce, transform.position, 1);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == ball)
        {
            foreach(ContactPoint contact in collision.contacts)
            {
                print(contact.thisCollider.name + " hit " + contact.otherCollider.attachedRigidbody.velocity);

                contact.otherCollider.attachedRigidbody.AddForce(-1 * contact.normal * bumperForce, ForceMode.Impulse);
            }
        }
    }
}
