﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreboardScript : MonoBehaviour

{
    public static int Score = 0;
    public static
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnGUI()
    {
        GUI.Box(new Rect(100, 100, 500, 100), Score.ToString ());
    }
}
