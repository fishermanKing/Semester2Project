using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovementScript : MonoBehaviour
{
    private GameObject controller;
    private ObstacleGeneration obstacleGeneration;
    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("ObstacleController");
        obstacleGeneration = controller.GetComponent<ObstacleGeneration>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - obstacleGeneration.speed*Time.deltaTime);
    }
}
