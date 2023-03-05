using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlovePickUp : MonoBehaviour
{
    public GameObject gloveUi;

    void Start()
    {
        gloveUi.SetActive(false);    
    }
    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            gloveUi.SetActive(true);
            PoolTask.hasTakenGloves = true;
            Destroy(this.gameObject);
        }    
    }
}
