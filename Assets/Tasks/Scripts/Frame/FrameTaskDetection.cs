using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameTaskDetection : MonoBehaviour
{
    public GameObject frameTaskCamera;
    public GameObject task;
    public GameObject objective;

    public GameObject key1;
    public GameObject key2;
    public GameObject key3;
    public GameObject key4;
    public GameObject key5;
    //public GameObject hint;

    public static bool isFrameTask = false;

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            objective.SetActive(true);
            isFrameTask = true;
            GameUi.isDetected = true;
            GameUi.task = 1;
            task.GetComponent<Task>().enabled = true;
            frameTaskCamera.SetActive(true);
            key1.SetActive(true);
            key2.SetActive(true);
            key3.SetActive(true);
            key4.SetActive(true);
            key5.SetActive(true);
            //hint.SetActive(true);
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
            isFrameTask = false;
            GameUi.isDetected = false;
            GameUi.task = 0;
            task.GetComponent<Task>().enabled = false;
            frameTaskCamera.SetActive(false);
            key1.SetActive(false);
            key2.SetActive(false);
            key3.SetActive(false);
            key4.SetActive(false);
            key5.SetActive(false);
            //hint.SetActive(false);
        }
    }
}
