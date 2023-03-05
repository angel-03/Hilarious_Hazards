using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WreTask : MonoBehaviour
{
    public static bool check;
    void LateUpdate()
    {
        PoolTask3();
    }

    void PoolTask3()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            check = true;
            WaitTime();
        }
    }

    void WaitTime()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);
        check = false;
    }
}
