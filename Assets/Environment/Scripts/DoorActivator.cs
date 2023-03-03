using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorActivator : MonoBehaviour
{
    //public DoorMechanics dm;

    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            this.gameObject.GetComponent<DoorMechanics>().enabled = true;
        }    
    }

    void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            this.gameObject.GetComponent<DoorMechanics>().enabled = false;
        }    
    }
}
