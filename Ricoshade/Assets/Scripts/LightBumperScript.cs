﻿using System.Collections;
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
}