using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DectectBulbs : MonoBehaviour
{
    public GameObject bulbUi;

    void Awake()
    {
        bulbUi.SetActive(false);    
    }
  
    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            bulbUi.SetActive(true);
            BulbTask.bulbCount++;
            BulbTask.totalBulbsCollected++;
            Destroy(this.gameObject);
        }    
    }
}
