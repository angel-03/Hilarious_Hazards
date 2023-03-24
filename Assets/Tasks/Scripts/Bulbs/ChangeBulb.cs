using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBulb : MonoBehaviour
{
    public GameObject bulb;
    void LateUpdate()
    {
        ChangeBulbs();
    }

    public void ChangeBulbs()
    {
        if(BulbTaskDetection.isBulbChanged)
        {
            BulbTask.fixedBulb ++;
            this.gameObject.transform.GetChild(1).gameObject.SetActive(true);
            this.gameObject.transform.GetChild(2).gameObject.SetActive(false);
        }
    }
}