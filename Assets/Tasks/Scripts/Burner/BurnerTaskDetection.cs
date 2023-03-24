using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnerTaskDetection : MonoBehaviour
{
    public GameObject burnerTaskCamera;
    public GameObject burnerTaskT;
    public GameObject objective;

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            objective.SetActive(true);
            GameUi.isDetected = true;
            GameUi.task = 4;
            burnerTaskT.GetComponent<BurnerTaskT>().enabled = true;
            burnerTaskCamera.SetActive(true);
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
            burnerTaskT.GetComponent<BurnerTaskT>().enabled = false;
            burnerTaskCamera.SetActive(false);
        }
    }
}
