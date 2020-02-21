using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlareBumperScript : MonoBehaviour
{
    // Start is called before the first frame update
    Light myLight;
    float flareRate = 16;
    float flareDecay = 8;
    private bool flareOn = false;
    public float flareMax;
    void Start()
    {
        myLight = GetComponent<Light>();
        myLight.enabled = true;
        myLight.intensity = 0;
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == ("Pinball") & !flareOn)
        {
            StartCoroutine(flare());
        }
    }
    private IEnumerator flare()
    {
        flareOn = true;
        while(myLight.intensity < flareMax)
        {
            myLight.intensity += flareRate * Time.deltaTime;
            yield return null;
        }
        while (myLight.intensity > 0)
        {
            myLight.intensity -= flareDecay * Time.deltaTime;
            yield return null;
        }
        flareOn = false;
    }
}
