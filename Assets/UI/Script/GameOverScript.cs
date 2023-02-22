using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameOverScript : MonoBehaviour
{
    //public static int deathVariant;
    public Sprite missionCompleted;
    public Sprite missionFailed;
    public Sprite encountered;
    public Sprite steppedOn;
    public Sprite cornered;
    public Sprite rocked;
    public Sprite bath;

    public GameObject gameOver;
    Image deathImage; 

    void Start()
    {
        deathImage = gameOver.GetComponent<Image>();
        gameOver.SetActive(false);
    }

    public void GameOver(int deathVariant)
    {
        switch(deathVariant)
        {
            case 0:
                deathImage.sprite = missionCompleted;
                break;
            case 1:
                deathImage.sprite = missionFailed;
                break;
            case 2:
                deathImage.sprite = encountered;
                break;
            case 3:
                deathImage.sprite = steppedOn;
                break;
            case 4:
                deathImage.sprite = cornered;
                break;
            case 5:
                deathImage.sprite = rocked;
                break;
            case 6:
                deathImage.sprite = bath;
                break;
        }
    }
}
