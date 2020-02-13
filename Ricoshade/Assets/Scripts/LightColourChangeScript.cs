using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightColourChangeScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Color[] colours;
    private int i = 0;
    Light myLight;
    void Start()
    {
        myLight = GetComponent<Light>();
        myLight.color = colours[0];
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (myLight != null & colours.Length > 0)
        {
            i += 1;
            if (i > colours.Length-1) i = 0;
            myLight.color = colours[i];
        }
    }
}
