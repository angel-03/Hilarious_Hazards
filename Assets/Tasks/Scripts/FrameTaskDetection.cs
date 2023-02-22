using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameTaskDetection : MonoBehaviour
{
    public GameObject frameTaskCamera;
    public GameObject task;

    public GameObject key1;
    public GameObject key2;
    public GameObject key3;
    public GameObject key4;
    public GameObject key5;

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            task.GetComponent<Task>().enabled = true;
            frameTaskCamera.SetActive(true);
            key1.SetActive(true);
            key2.SetActive(true);
            key3.SetActive(true);
            key4.SetActive(true);
            key5.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            task.GetComponent<Task>().enabled = false;
            frameTaskCamera.SetActive(false);
            key1.SetActive(false);
            key2.SetActive(false);
            key3.SetActive(false);
            key4.SetActive(false);
            key5.SetActive(false);
        }
    }
}
