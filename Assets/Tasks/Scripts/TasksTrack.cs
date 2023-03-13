using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TasksTrack : MonoBehaviour
{
    public static int tasksDone;
    int totalTasks = 4;
    public GameObject gameOver;
    public GameObject gameUi;

    void Start()
    {
        tasksDone = 0;
    }

    void Update()
    {
        Debug.Log("Tasks" + tasksDone);
        if(tasksDone == totalTasks)
        {
            GameUi.isPassed = false;
            Debug.Log("GameOver");
            gameUi.SetActive(false);
            //gameOver.GetComponent<GameOverScript>().TheEnd();
        }
    }
}
