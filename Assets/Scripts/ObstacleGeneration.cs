using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGeneration : MonoBehaviour
{
    public float speed = 3.0f;
    private float generationMax = 8.9f;//This number is arbitrary. It corresponds to the size of the obstacle prefabs. They have to be the same size
    private float generationTime = 0;
    public bool transition;
    private int i = 0;
    public GameObject[] leveltransition;
    public GameObject[] level1;//All levels have to follow the syntax of level+currentlevel
    public int currentLevel = 1;
    void Start()
    {
    }
    
    void Update()
    {
        if (generationTime > 0)
        {
            generationTime -= speed * Time.deltaTime;
        }
        else 
        {
            if (!transition)
            {
                Instantiate(GetObstacles((GameObject[])this.GetType().GetField("level" + currentLevel.ToString()).GetValue(this)), gameObject.transform); //I know right? Using Reflection to add level+currentLevel to reference an array of Game Objects
            }
            else
            {
                Instantiate(getTransition(leveltransition), gameObject.transform);
                i += 1;
            }
            generationTime = generationMax;
        }
    }
    private GameObject GetObstacles(GameObject[] array)
    {
        int r = Random.Range(0, array.Length); 
        return array[r];
    }
    private GameObject getTransition(GameObject[] array)
    {
        if (i+1 > array.Length)
        {
            transition = false;
            currentLevel += 1;
        }
        return array[i];
    }
}
