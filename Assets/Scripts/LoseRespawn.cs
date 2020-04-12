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
    
    // Update is called once per frame
    void Update()
    {
        if (pinballLives == 0)
        {
            //playable.SetActive(false);
            //Debug.Log("Game Over");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Pinball")
        {
            //pinball.transform.position = respawn.transform.position;
            pinballLives--;
            Instantiate(pinball, respawn.position, respawn.rotation);
            gate.Open();
        }
    }
}
