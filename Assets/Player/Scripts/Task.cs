using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
    public GameObject playerMovement;
    public static bool check;

    void LateUpdate()
    {
        GuessAnswer();
    }

    void GuessAnswer()
    {
        if(Input.GetKeyDown(KeyCode.Keypad1))
        {
            check = true;
            FrameTask.selectedAnswer = 1;
            WaitTime();
        }
        if(Input.GetKeyDown(KeyCode.Keypad2))
        {
            check = true;
            FrameTask.selectedAnswer = 2;
            WaitTime();
        }
        if(Input.GetKeyDown(KeyCode.Keypad3))
        {
            check = true;
            FrameTask.selectedAnswer = 3;
            WaitTime();
        }
        if(Input.GetKeyDown(KeyCode.Keypad4))
        {
            check = true;
            FrameTask.selectedAnswer = 4;
            WaitTime();
        }
        if(Input.GetKeyDown(KeyCode.Keypad5))
        {
            check = true;
            FrameTask.selectedAnswer = 5;
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
