using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseRespawn : MonoBehaviour
{
    //[SerializeField] private Transform pinball;
    [SerializeField] private GameObject pinball;
    [SerializeField] private Transform respawn;
    public int pinballLives = 3;
    public GameObject playable;
    [SerializeField] private LauncherGate gate;
    private ScreenShake shaker;

    private void Start()
    {
        shaker = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ScreenShake>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pinballLives == 0)
        {
            //playable.SetActive(false);
            //Debug.Log("Game Over");
        }
    }

    public void Respawn()
    {
        Instantiate(pinball, respawn.position, respawn.rotation);
        gate.Open();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Pinball")
        {
            //pinball.transform.position = respawn.transform.position;
            pinballLives--;
            StartCoroutine(shaker.Shake(1.5f, 0.6f));
            GameManager.Instance.StopObstacleSpawning();            
        }
    }
}
