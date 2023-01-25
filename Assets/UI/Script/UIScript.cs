using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject modesPanel;
    public GameObject creditsPanel;

    public GameObject musicButton;
    public Sprite musicOnSprite;
    public Sprite musicOffSprite;

    private Image image;

    private bool isMusicOn;

    void Start()
    {
        isMusicOn = false;
        image = musicButton.GetComponent<Image>();
    }

    public void OnClickStartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void OnClickExitButton()
    {
        Debug.Log("End Game");
        Application.Quit();
    }

    public void OnClickMusicButton()
    {
        if(isMusicOn)
        {
            ChangeSprite(isMusicOn);
            isMusicOn = false;
        }
        else
        {
            ChangeSprite(isMusicOn);
            isMusicOn = true;
        }
    }

    public void OnClickCreditsButton()
    {
        mainMenuPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }

    public void OnClickCloseCreditsButton()
    {
        mainMenuPanel.SetActive(true);
        creditsPanel.SetActive(false);
    }

    void ChangeSprite(bool isMusicOn)
    {
        if(isMusicOn)
        {
            image.sprite = musicOnSprite;
        }
        else
        {
            image.sprite = musicOffSprite;
        }
    }
}
