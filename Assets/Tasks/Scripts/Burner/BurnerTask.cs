using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnerTask : MonoBehaviour
{
    public GameObject gameUI;
    public GameObject detection;
    public PlayerMovement pm;
    public GameObject burnerTaskT;

    int correctAnswer;
    public GameObject Fire1;
    public GameObject Fire2;
    public GameObject Fire3;
    public GameObject Fire4;
    public GameObject BigFire;

    public static int selectedAnswer;

    void Start()
    {
        correctAnswer = Random.Range(1,4);
        BigFire.SetActive(false);
        Debug.Log(correctAnswer);
        selectedAnswer = 0;
        Reset();
        SetFire(correctAnswer);
    }

    void Update()
    {
        CheckAnswer();
    }

    void CheckAnswer()
    {
        if(BurnerTaskT.check)
        {
            Debug.Log("CheckAnswer");
            if(correctAnswer == selectedAnswer)
            {
                Debug.Log("You Won");
                gameUI.GetComponent<GameUi>().MissionCompleted();
                GameUi.isPassed = true;
                TasksTrack.tasksDone++;
                burnerTaskT.GetComponent<BurnerTaskT>().enabled = false;
                detection.GetComponent<BoxCollider>().enabled = false;
                detection.SetActive(false);
            }
            else
            {
                BigFire.SetActive(true);
                pm.Death();
                GameUi.deathType = 4;
                StartCoroutine(Wait());
                Debug.Log("You Lost");
            }
        }
    }
    void SetFire(int correctAnswer)
    {
        switch(correctAnswer)
        {
            case 1:
                Fire1.SetActive(true);
                break;
            case 2:
                Fire2.SetActive(true);
                break;
            case 3:
                Fire3.SetActive(true);
                break;
            case 4:
                Fire4.SetActive(true);
                break;
            default:
                return;
        }
    }

    void Reset()
    {
        Fire1.SetActive(false);
        Fire2.SetActive(false);
        Fire3.SetActive(false);
        Fire4.SetActive(false);
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5f);
        gameUI.GetComponent<GameUi>().MissionFailed();
    }
}
