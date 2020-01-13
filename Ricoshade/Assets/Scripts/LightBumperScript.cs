using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBumperScript : MonoBehaviour
{
    // Start is called before the first frame update
    public bool lightOn = false;
    Light myLight;
    void Start()
    {
        myLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == ("Pinball"))
        {
            myLight.enabled = !myLight.enabled;
            print("Hit!");
        }
    }
}
