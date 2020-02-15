using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBumperScript : MonoBehaviour
{
    // Start is called before the first frame update
    public bool lightOn = false;
    Light myLight;
    float fadeRate = 2;
    void Start()
    {
        myLight = GetComponent<Light>();
        myLight.enabled = lightOn;
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == ("Pinball"))
        {
            myLight.enabled = !myLight.enabled;
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
        myLight.enabled = false;
    }
}
