using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUi : MonoBehaviour
{
    public GameObject gameOver;
    public GameObject pausePanel;
    public GameObject continueButton;
    public static bool isPassed;
    public static bool isPaused;
    public static bool isCanvasOn;

    void Start()
    {
        isPassed = false; 
        isPaused = false;
        isCanvasOn = false;
        continueButton.SetActive(false); 
        pausePanel.SetActive(false);  
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
    }

    public void MissionFailed()
    {
        isCanvasOn = true;
        gameOver.SetActive(true);
        gameOver.GetComponent<GameOverScript>().GameOver(1);
    }

    public void MissionCompleted()
    {
        isCanvasOn = true;
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
}
