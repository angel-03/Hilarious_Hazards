using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulbTaskT : MonoBehaviour
{
    public static bool check;
    public static bool deathCheck;
    void LateUpdate()
    {
        BulbTask2();
    }

    void BulbTask2()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            deathCheck = true;
            check = true;
            if(BulbTask.bulbCount > 0)
                BulbTaskDetection.isBulbChanged = true;
            BulbTask.bulbCount--;
            WaitTime();
        }
    }

    void WaitTime()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.005f);
        check = false;
        BulbTaskDetection.isBulbChanged = false;
        if(BulbTask.bulbCount == 0)
            check = true;
        yield return new WaitForSeconds(0.1f);
        deathCheck = false;
    }
}
