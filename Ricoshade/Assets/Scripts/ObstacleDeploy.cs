using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDeploy : MonoBehaviour
{
    public GameObject Obstacle1;
    public float respawnTime = 2.0f;
    private Vector3 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(ObstacleWave());
    }
    private void spawnEnemy()
    {
        GameObject a = Instantiate(Obstacle1) as GameObject;
         a.transform.position = new Vector3(screenBounds.x * -2, screenBounds.y * -2, screenBounds.z * -2);
    }
    IEnumerator ObstacleWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
