using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolTaskDetection : MonoBehaviour
{
    public GameObject poolTaskCamera;
    public GameObject poolTask;
    public GameObject objective;

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            objective.SetActive(true);
            GameUi.isDetected = true;
            GameUi.task = 3;
            poolTask.GetComponent<WreTask>().enabled = true;
            poolTaskCamera.SetActive(true);
            if(GameUi.isCanvasOn)
            {
                objective.SetActive(false);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            objective.SetActive(false);
            GameUi.isDetected = false;
            GameUi.task = 0;
            poolTask.GetComponent<WreTask>().enabled = false;
            poolTaskCamera.SetActive(false);
        }
    }
}
