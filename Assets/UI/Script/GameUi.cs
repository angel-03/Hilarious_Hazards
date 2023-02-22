using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUi : MonoBehaviour
{
    public GameObject gameOver;

    public void MissionFailed()
    {
        gameOver.SetActive(true);
        gameOver.GetComponent<GameOverScript>().GameOver(1);
    }

    public void MissionCompleted()
    {
        gameOver.SetActive(true);
        gameOver.GetComponent<GameOverScript>().GameOver(0);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Continue()
    {
        gameOver.SetActive(false);
        PlayerMovement.canMove = true;
    }

    public void GameOverUI(int deathVariant)
    {
        gameOver.SetActive(true);
        StartCoroutine(Wait(deathVariant));
    }

    public void ActivateScreen()
    {
        gameOver.SetActive(true);
    }

    IEnumerator Wait(int deathVariant)
    {
        yield return new WaitForSeconds(0.05f);
        switch(deathVariant)
        {
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
