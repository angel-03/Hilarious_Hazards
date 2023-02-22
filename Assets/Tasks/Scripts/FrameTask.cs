using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameTask : MonoBehaviour
{
    public GameObject frames;
    public GameObject gameUI;
    public PlayerMovement pm;

    int correctAnswer;

    public static int selectedAnswer;

    void Start()
    {
        correctAnswer = Random.Range(1,6);
        Debug.Log(correctAnswer);
        selectedAnswer = 0;
    }

    void Update()
    {
        CheckAnswer();
    }

    void CheckAnswer()
    {
        if(Task.check)
        {
            if(correctAnswer == selectedAnswer)
            {
                Debug.Log("You Won");
                gameUI.GetComponent<GameUi>().MissionCompleted();
            }
            else
            {
                pm.Death();
                StartCoroutine(Wait());
                Debug.Log("You Lost");
            }
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5f);
        gameUI.GetComponent<GameUi>().MissionFailed();
    }
}
