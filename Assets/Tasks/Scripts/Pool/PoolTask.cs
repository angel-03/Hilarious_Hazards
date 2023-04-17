using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolTask : MonoBehaviour
{
    public static bool hasTakenGloves;
    public static bool hasClickedWire;
    public static int wireCount;

    public PlayerMovement pm;
    public GameObject gameUI;  
    public GameObject detection; 
    public GameObject glovesUi;
    public GameObject pool;
    public GameObject poolTask;
    public GameObject taskDone;

    //public TMP_Text countUI;

    void Start() 
    {
        taskDone.SetActive(false);
        wireCount = 1;
        hasTakenGloves = false;  
        hasClickedWire = false;
    }

    void LateUpdate() 
    {
        //countUI.SetText(bulbCount.ToString());   
        CheckAnswer();
    }

    void CheckAnswer()
    {
        if(WreTask.check)
        {
            if(hasTakenGloves)
            {
                hasClickedWire = true;
                wireCount--;
                if(wireCount <= 0 )
                {
                    Debug.Log("You Won");
                    StartCoroutine(WaitForWire());
                }
            }
            else
            {
                pm.Death();
                GameUi.deathType = 3;
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

    IEnumerator WaitForWire()
    {
        yield return new WaitForSeconds(1f);
        gameUI.GetComponent<GameUi>().MissionCompleted();
        GameUi.isPassed = true;
        glovesUi.SetActive(false);
        TasksTrack.tasksDone++;
        taskDone.SetActive(true);
        poolTask.GetComponent<WreTask>().enabled = false;
        pool.GetComponent<BoxCollider>().isTrigger = false;
        detection.GetComponent<BoxCollider>().enabled = false;
        detection.SetActive(false);
    }
}
