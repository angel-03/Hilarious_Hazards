using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnerTaskT : MonoBehaviour
{
    public GameObject playerMovement;
    public static bool check;
    public BurnerTask burt;

    void LateUpdate()
    {
        BurnerTask4();
    }

    void BurnerTask4()
    {
        if(Input.GetKeyDown(KeyCode.Keypad1))
        {
            check = true;
            BurnerTask.selectedAnswer = 1;
            WaitTime();
        }
        if(Input.GetKeyDown(KeyCode.Keypad2))
        {
            check = true;
            BurnerTask.selectedAnswer = 2;
            WaitTime();
        }
        if(Input.GetKeyDown(KeyCode.Keypad3))
        {
            check = true;
            BurnerTask.selectedAnswer = 3;
            WaitTime();
        }
        if(Input.GetKeyDown(KeyCode.Keypad4))
        {
            check = true;
            BurnerTask.selectedAnswer = 4;
            WaitTime();
        }

        // if(Input.GetKeyDown(KeyCode.H))
        // {
        //     ft.ActivateAnswer();
        // }
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
