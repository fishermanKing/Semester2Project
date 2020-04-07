using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transitionScript : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject ObstacleController;
    TextMesh LevelName;
    string[] names = { "River Styx", "Elysium", "Mourning Fields", "Tartarus", "Erebus" };
    int level = 0;

    void Start()
    {
        ObstacleController = GameObject.Find("ObstacleController");
        level = ObstacleController.GetComponent<ObstacleGeneration>().currentLevel;
        LevelName = transform.GetComponentInChildren<TextMesh>();
        LevelName.text = names[level];
    }
}
