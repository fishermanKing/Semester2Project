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
    public GameObject[] level2;
    public int currentLevel = 1;

    public bool canSpawn = false;
    private List<GameObject> obstacles;

    public Material redMat;
    public Material greenMat;
    public Material whiteMat;

    void Start()
    {
        obstacles = new List<GameObject>();
    }
    
    void Update()
    {
        //if (canSpawn)
        //{
        //    if (generationTime > 0)
        //    {
        //        generationTime -= speed * Time.deltaTime;
        //    }
        //    else
        //    {
        //        if (!transition)
        //        {
        //            Instantiate(GetObstacles((GameObject[])this.GetType().GetField("level" + currentLevel.ToString()).GetValue(this)), gameObject.transform); //I know right? Using Reflection to add level+currentLevel to reference an array of Game Objects
        //        }
        //        else
        //        {
        //            Instantiate(getTransition(leveltransition), gameObject.transform);
        //            i += 1;
        //        }
        //        generationTime = generationMax;
        //    }
        //}
    }
    private GameObject GetObstacles(GameObject[] array)
    {
        int r = Random.Range(0, array.Length); 
        return array[r];
    }
    private GameObject getTransition(GameObject[] array)
    {
        int j = i;
        if (i+1 > array.Length)
        {
            transition = false;
            currentLevel += 1;
            i = 0;
        }
        return array[j];
    }

    public void StopSpawning()
    {
        StopAllCoroutines();
        speed = 0;
        StartCoroutine(Dissolve());
    }

    public void StartSpawning()
    {
        StartCoroutine(SpawnObstacle());
        speed = 2f;
        redMat.SetFloat("Vector1_7466B80A", -0.2f);
        greenMat.SetFloat("Vector1_7466B80A", -0.2f);
        whiteMat.SetFloat("Vector1_7466B80A", -0.2f);
    }

    IEnumerator SpawnObstacle()
    {
        while(true)
        {
            GameObject spawn = Instantiate(GetObstacles((GameObject[])this.GetType().GetField("level" + currentLevel.ToString()).GetValue(this)), gameObject.transform);
            obstacles.Add(spawn);
            yield return new WaitForSeconds(3f);
        }
        yield return null;
    }

    IEnumerator Dissolve()
    {
        float value = -0.2f;
        while(value <= 1)
        {
            redMat.SetFloat("Vector1_7466B80A", value);
            greenMat.SetFloat("Vector1_7466B80A", value);
            whiteMat.SetFloat("Vector1_7466B80A", value);
            yield return new WaitForEndOfFrame();
            value += 0.01f;
        }

        foreach (GameObject obj in obstacles)
        {
            Destroy(obj.gameObject, 0f);
        }
        obstacles.Clear();
        yield return null;
    }
}
