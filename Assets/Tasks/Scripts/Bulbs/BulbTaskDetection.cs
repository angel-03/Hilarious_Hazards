using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulbTaskDetection : MonoBehaviour
{
    //public GameObject bulbTaskCamera;
    public GameObject task;
    public GameObject toChangeBulb;
    public GameObject keyF;
    public static bool isBulbTask = false;
    public static bool isBulbChanged;


    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            isBulbTask = true;
            task.GetComponent<bulbTaskT>().enabled = true;
            toChangeBulb.GetComponent<ChangeBulb>().enabled = true;
            //bulbTaskCamera.SetActive(true);
            //keyF.SetActive(true);
            //hint.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            isBulbTask = false;
            task.GetComponent<bulbTaskT>().enabled = false;
           //bulbTaskCamera.SetActive(false);
            //keyF.SetActive(false);
            //hint.SetActive(false);
        }
    }
}
