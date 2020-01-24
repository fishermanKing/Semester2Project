using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseRespawn : MonoBehaviour
{
    [SerializeField] private Transform pinball;
    [SerializeField] private Transform respawn;
    public int pinballLives = 3;
    public GameObject playable;
    private void OnTriggerEnter(Collider other)
    {
        
        pinball.transform.position = respawn.transform.position;
        pinballLives --;
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (pinballLives == 0)
        {
            playable.SetActive(false);
            Debug.Log("Game Over");

        }
    }
}
