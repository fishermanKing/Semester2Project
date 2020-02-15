using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravityScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = transform.rotation * Physics.gravity;
    }
}
