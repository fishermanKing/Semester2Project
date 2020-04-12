using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherGate : MonoBehaviour
{
    public Animator anim;

    private void Start()
    {
        Open();
    }

    public void Open()
    {
        anim.ResetTrigger("Close");
        anim.SetTrigger("Open");
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Pinball")
        {
            anim.ResetTrigger("Open");
            anim.SetTrigger("Close");
            GameManager.Instance.StartObstacleSpawning();
        }
    }
}
