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

    public static int fixedBulb = 0;
    public static int bulbCount = 0;
    private int totalBulbs = 5;
    public static int totalBulbsCollected=0;
    public TMP_Text countUI;

    void Start() 
    {
        bulbCount = 0;
        fixedBulb = 0;
    }

    void LateUpdate() 
    {
        countUI.SetText(bulbCount.ToString());   
        CheckAnswer();
    }

    void CheckAnswer()
    {
        if(bulbTaskT.check)
        {
            if(fixedBulb == totalBulbs)
            {
                Debug.Log("You Won");
                gameUI.GetComponent<GameUi>().MissionCompleted();
                GameUi.isPassed = true;
                TasksTrack.tasksDone++;
                detection.GetComponent<BoxCollider>().enabled = false;
                detection.SetActive(false);
            }
            else if(bulbCount <= -1)
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
