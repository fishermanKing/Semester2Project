using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBumperScript : MonoBehaviour
{
    // Start is called before the first frame update
    public bool lightOn = false;
    Light myLight;
    float fadeRate = 2;
    FMOD.Studio.EventInstance lightCollision;
    void Start()
    {
        myLight = GetComponent<Light>();
        myLight.enabled = lightOn;
        lightCollision = FMODUnity.RuntimeManager.CreateInstance("event:/Light");
        if (myLight.enabled)
        {
            lightCollision.start();
        }
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == ("Pinball"))
        {
            myLight.enabled = !myLight.enabled;
        }
        if (myLight.enabled)
        {
            lightCollision.start();
        }
        else
        {
            lightCollision.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Kill") & myLight.enabled)
        {
            StartCoroutine(fade());
        }
    }
    private IEnumerator fade()
    {
        while(myLight.intensity > 0)
        {
            myLight.intensity -= fadeRate * Time.deltaTime;
            yield return null;
        }
        if (myLight.enabled)
        {
            lightCollision.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
        myLight.enabled = false;
    }
}
