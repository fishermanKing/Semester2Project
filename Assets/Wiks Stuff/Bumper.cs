using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    public float bumperForce = 10f;
    public bool noScore = false;
    public float scoreAmount = 100f;
    //public GameObject ball;
    private ScreenShake shaker;
    FMOD.Studio.EventInstance bumperCollision;

    // Start is called before the first frame update
    void Start()
    {
        //ball = GameObject.FindGameObjectWithTag("Pinball");
        shaker = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ScreenShake>();
        bumperCollision = FMODUnity.RuntimeManager.CreateInstance("event:/Bumper");

    }

    //public void OnTriggerEnter(Collider other)
    //{
    //    if(other.gameObject == ball)
    //    {
    //        ball.GetComponent<Rigidbody>().AddExplosionForce(bumperForce, transform.position, 1);
    //    }
    //}

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Pinball")
        {
            foreach(ContactPoint contact in collision.contacts)
            {
                //print(contact.thisCollider.name + " hit " + contact.otherCollider.attachedRigidbody.velocity);
                StartCoroutine(shaker.Shake(0.15f, 0.4f));
                contact.otherCollider.attachedRigidbody.AddForce(-1 * contact.normal * bumperForce, ForceMode.Impulse);

                if(!noScore)
                {
                    AddScore(contact.point);
                }
            }
            bumperCollision.start();
        }
    }

    public void AddScore(Vector3 pos)
    {
        //scoreAmount = Random.Range(60, 100);
        FloatingTextController.CreateFloatingText(scoreAmount.ToString(), pos);
    }
}
