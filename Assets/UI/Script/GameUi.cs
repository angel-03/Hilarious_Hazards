using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUi : MonoBehaviour
{
    public GameObject gameOver;
    public GameObject pausePanel;
    public GameObject continueButton;
    public GameObject objective;
    public GameObject death;

    public static bool isPassed;
    public static bool isPaused;
    public static bool isDetected;
    public static bool isDead;
    public static bool isCanvasOn;
    public static int task = 0;
    public static int deathType = 0;

    public TMP_Text objectiveText;
    public TMP_Text deathText;

    void Start()
    {
        isDead = false;
        isPassed = false; 
        isPaused = false;
        isCanvasOn = false;
        isDetected = false;
        continueButton.SetActive(false); 
        pausePanel.SetActive(false);
        objective.SetActive(false);
        death.SetActive(false); 
    }

    void Update()
    {
        if(isPassed)
        {
            continueButton.SetActive(true);
        }
        if(isPaused)
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0;
        }
        if(isDetected)
        {
            DisplayObjective(task);
        }
        if(isDead)
        {
            DeathText(deathType);
        }
    }

    public void MissionFailed()
    {
        isCanvasOn = true;
        isDead = true;
        objective.SetActive(false);
        gameOver.SetActive(true);
        death.SetActive(true);
        gameOver.GetComponent<GameOverScript>().GameOver(1);
    }

    public void MissionCompleted()
    {
        isCanvasOn = true;
        objective.SetActive(false);
        gameOver.SetActive(true);
        gameOver.GetComponent<GameOverScript>().GameOver(0);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }

    public void Retry()
    {
        isCanvasOn = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Continue()
    {
        isPassed = false;
        isCanvasOn = false;
        continueButton.SetActive(false);
        gameOver.SetActive(false);
        PlayerMovement.canMove = true;
    }

    public void GameOverUI(int deathVariant)
    {
        isCanvasOn = true;
        gameOver.SetActive(true);
        StartCoroutine(Wait(deathVariant));
    }

    public void ActivateScreen()
    {
        gameOver.SetActive(true);
    }

    public void ClosePausePanel()
    {
        pausePanel.SetActive(false);
        isPaused = false;
        Time.timeScale = 1;
    }

    IEnumerator Wait(int deathVariant)
    {
        yield return new WaitForSeconds(0.05f);
        switch(deathVariant)
        {
            case 1:
                gameOver.GetComponent<GameOverScript>().GameOver(1);
                break;
            case 2:
                gameOver.GetComponent<GameOverScript>().GameOver(2);
                break;
            case 3:
                gameOver.GetComponent<GameOverScript>().GameOver(3);
                break;
            case 4:
                gameOver.GetComponent<GameOverScript>().GameOver(4);
                break;
            case 5:
                gameOver.GetComponent<GameOverScript>().GameOver(5);
                break;
            case 6:
                gameOver.GetComponent<GameOverScript>().GameOver(6);
                break; 
        }
    }

    void DisplayObjective(int task)
    {
        switch(task)
        {
            case 1:
                objectiveText.SetText("Pick the correct frame");
                break;
            case 2:
                objectiveText.SetText("Fix the fence lights");
                break;
            case 3:
                objectiveText.SetText("Remove the live wire");
                break;
            case 4:
                objectiveText.SetText("Pick the correct burner knob");
                break; 
        }
    }

    void DeathText(int deathType)
    {
        switch(deathType)
        {
            case 1:
                deathText.SetText("You Got Framed!");
                break;
            case 2:
                deathText.SetText("Lights Out For You Buddy!");
                break;
            case 3:
                deathText.SetText("Shocking Isn't It!");
                break;
            case 4:
                deathText.SetText("You Just Got Roasted!");
                break;
        } 
    }

}
