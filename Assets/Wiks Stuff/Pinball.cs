using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinball : MonoBehaviour
{
    public const int numOfBalls = 20;
    List<GameObject> newBalls; 
    Vector3 startPoint;
    float radius = 5f;
    float moveSpeed = 30f;

    private void Start()
    {
        newBalls = new List<GameObject>();
    }

    private void Update()
    { 
        if(Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(SuperBallPowerup());
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            ChangeLayer();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            DestroyBalls();
        }
    }

    void SpawnBalls(int amount)
    {
        float angleStep = 360f / numOfBalls;
        float angle = 0f;

        for (int i=0; i<=numOfBalls -1; i++)
        {
            float ballDirXPos = startPoint.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
            float ballDirZPos = startPoint.z + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

            Vector3 ballVector = new Vector3(ballDirXPos, startPoint.y, ballDirZPos);
            Vector3 ballMoveDir = (ballVector - startPoint).normalized * moveSpeed;

            var spawn = Instantiate(this.gameObject, startPoint, Quaternion.identity);
            //spawn.layer = default;
            spawn.GetComponent<Rigidbody>().velocity = new Vector3(ballMoveDir.x, 0, ballMoveDir.z);
            //spawn.GetComponent<Pinball>().enabled = false;
            newBalls.Add(spawn);

            angle += angleStep;
        }
    }

    void DestroyBalls()
    {
        foreach (GameObject obj in newBalls)
        {
            Destroy(obj.gameObject, 0f);
        }
        newBalls.Clear();
    }

    void ChangeLayer()
    {
        foreach (GameObject obj in newBalls)
        {
            obj.layer = default;
        }
        gameObject.layer = default;
    }

    IEnumerator SuperBallPowerup()
    {
        gameObject.layer = 9;
        startPoint = transform.position;
        SpawnBalls(numOfBalls);
        Time.timeScale = 0.15f;
        yield return new WaitForSeconds(0.2f);
        Time.timeScale = 1f;
        ChangeLayer();
        yield return null;
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.layer == 9)
        {
            Physics.IgnoreLayerCollision(0,9);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.layer == 9)
        {
            Debug.Log("Exit");
            gameObject.layer = default;
        }
    }
}
