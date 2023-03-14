using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DectectBulbs : MonoBehaviour
{
    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            BulbTask.bulbCount++;
            BulbTask.totalBulbsCollected++;
            Destroy(this.gameObject);
        }    
    }
}
