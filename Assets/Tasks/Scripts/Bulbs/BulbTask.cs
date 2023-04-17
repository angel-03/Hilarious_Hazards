using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using TMPro;


public class BulbTask : MonoBehaviour
{
    public PlayerMovement pm;
    public GameObject gameUI;
    public GameObject detection;
    public GameObject bulbUi;
    public GameObject task;
    public GameObject taskDone;

    public static int fixedBulb = 0;
    public static int bulbCount = 0;
    int totalBulbs = 5;
    public static int totalBulbsCollected=0;
    public TMP_Text countUI;

    void Start() 
    {
        taskDone.SetActive(false);
        bulbUi.SetActive(false); 
        bulbCount = 0;
        fixedBulb = 0;
    }

    void LateUpdate() 
    {
        countUI.SetText(bulbCount.ToString());
        if(!GameUi.isCanvasOn)
        {
            if(bulbCount > 0)
                bulbUi.SetActive(true); 
        }  
        CheckAnswer();
    }

    void CheckAnswer()
    {
        Debug.Log(fixedBulb);
        if(bulbTaskT.check)
        {
            if(fixedBulb >= totalBulbs)
            {
                Debug.Log("You Won");
                gameUI.GetComponent<GameUi>().MissionCompleted();
                GameUi.isPassed = true;
                TasksTrack.tasksDone++;
                bulbUi.SetActive(false);
                fixedBulb = 0;
                taskDone.SetActive(true);
                task.GetComponent<bulbTaskT>().enabled = false;
                detection.GetComponent<BoxCollider>().enabled = false;
                detection.SetActive(false);
            } 
        }
        else if(bulbTaskT.deathCheck)
        {
            if(bulbCount <= -1)
            {
                pm.Death();
                GameUi.deathType = 2;
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
