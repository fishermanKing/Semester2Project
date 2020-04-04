using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinballScript : MonoBehaviour
{
    FMOD.Studio.EventInstance audioCollision;
    void Start()
    {
        audioCollision = FMODUnity.RuntimeManager.CreateInstance("event:/Collision");
    }

    private void OnCollisionEnter(Collision collision)
    {
         audioCollision.setParameterByName("hitMagnitude", collision.relativeVelocity.magnitude);
         audioCollision.start();
    }
}
