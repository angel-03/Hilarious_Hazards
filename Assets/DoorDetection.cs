using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorDetection : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        if(this.gameObject.name == "Front")
            DoorMechanics.isFront = true;
         
        else if(this.gameObject.name == "Back")
            DoorMechanics.isFront = false;    
    } 
}
