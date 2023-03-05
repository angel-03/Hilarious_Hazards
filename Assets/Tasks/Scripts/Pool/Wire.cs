using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{
    void LateUpdate()
    {
        if(PoolTask.hasClickedWire)
        {
            Destroy(this.gameObject);
        }    
    }
}
