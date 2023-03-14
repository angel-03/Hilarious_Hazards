using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnerTaskDetection : MonoBehaviour
{
    public GameObject burnerTaskCamera;
    public GameObject burnerTaskT;

    public GameObject key1;
    public GameObject key2;
    public GameObject key3;
    public GameObject key4;
    public GameObject hint;

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            burnerTaskT.GetComponent<BurnerTaskT>().enabled = true;
            burnerTaskCamera.SetActive(true);
            // key1.SetActive(true);
            // key2.SetActive(true);
            // key3.SetActive(true);
            // key4.SetActive(true);
            // hint.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            burnerTaskT.GetComponent<BurnerTaskT>().enabled = false;
            burnerTaskCamera.SetActive(false);
            // key1.SetActive(false);
            // key2.SetActive(false);
            // key3.SetActive(false);
            // key4.SetActive(false);
            // hint.SetActive(false);
        }
    }
}
