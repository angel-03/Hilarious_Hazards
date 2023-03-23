using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{
    public GameObject sparksVFX;
    void LateUpdate()
    {
        if(PoolTask.hasClickedWire)
        {
            Destroy(this.gameObject);
            Destroy(sparksVFX);
        }    
    }
}
