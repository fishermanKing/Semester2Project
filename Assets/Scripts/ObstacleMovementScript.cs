using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovementScript : MonoBehaviour
{
    private GameObject controller;
    private ObstacleGeneration obstacleGeneration;
    public bool isSinking = false;
    private bool doOnce = false;

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("ObstacleController");
        obstacleGeneration = controller.GetComponent<ObstacleGeneration>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isSinking)
        {
            Sink();
        }
        MoveDown();
    }

    void MoveDown()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - obstacleGeneration.speed * Time.deltaTime);
    }

    void Sink()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - obstacleGeneration.speed * Time.deltaTime, transform.position.z);

        if (!doOnce)
        {
            doOnce = true;
            Destroy(gameObject, 5f);
        }
    }
}
