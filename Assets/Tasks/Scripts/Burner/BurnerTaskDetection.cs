using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnerTaskDetection : MonoBehaviour
{
    public GameObject burnerTaskCamera;
    public GameObject burnerTaskT;

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            burnerTaskT.GetComponent<BurnerTaskT>().enabled = true;
            burnerTaskCamera.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            burnerTaskT.GetComponent<BurnerTaskT>().enabled = false;
            burnerTaskCamera.SetActive(false);
        }
    }
}
