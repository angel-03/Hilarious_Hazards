using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBulb : MonoBehaviour
{
    void LateUpdate()
    {
        ChangeBulbs();
    }

    public void ChangeBulbs()
    {
        if(BulbTaskDetection.isBulbChanged)
        {
            this.gameObject.transform.GetChild(1).gameObject.SetActive(true);
            //this.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}