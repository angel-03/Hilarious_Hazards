using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolTaskDetection : MonoBehaviour
{
    public GameObject poolTaskCamera;
    public GameObject poolTask;

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            poolTask.GetComponent<WreTask>().enabled = true;
            poolTaskCamera.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            poolTask.GetComponent<WreTask>().enabled = false;
            poolTaskCamera.SetActive(false);
        }
    }
}
