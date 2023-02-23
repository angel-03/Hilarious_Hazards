using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameTask : MonoBehaviour
{
    public GameObject frames;
    public GameObject gameUI;
    public PlayerMovement pm;

    // public Sprite minecraft;
    // public Sprite nfs;
    // public Sprite amongus;
    // public Sprite fallguys;
    // public Sprite gta;
    // SpriteRenderer sp;

    public GameObject MineCraft;
    public GameObject NFS;
    public GameObject AmongUs;
    public GameObject FallGuys;
    public GameObject GTA;

    public GameObject answer;
    int correctAnswer;

    public static int selectedAnswer;

    void Start()
    {
        correctAnswer = Random.Range(1,6);
        Debug.Log(correctAnswer);
        selectedAnswer = 0;
        //sp = answer.GetComponent<SpriteRenderer>();
        //SetHint(correctAnswer);
        Reset();
    }

    void Update()
    {
        CheckAnswer();
    }

    void CheckAnswer()
    {
        if(Task.check)
        {
            if(correctAnswer == selectedAnswer)
            {
                Debug.Log("You Won");
                gameUI.GetComponent<GameUi>().MissionCompleted();
            }
            else
            {
                pm.Death();
                StartCoroutine(Wait());
                Debug.Log("You Lost");
            }
        }
    }

    void SetHint(int correctAnswer)
    {
        switch(correctAnswer)
        {
            case 1:
                //sp.sprite = minecraft;
                MineCraft.SetActive(true);
                break;
            case 2:
                //sp.sprite = nfs;
                NFS.SetActive(true);
                break;
            case 3:
                //sp.sprite = amongus;
                AmongUs.SetActive(true);
                break;
            case 4:
                //sp.sprite = fallguys;
                FallGuys.SetActive(true);
                break;
            case 5:
                //sp.sprite = gta;
                GTA.SetActive(true);
                break;
            default:
                return;
        }
    }

    public void ActivateAnswer()
    {
        answer.SetActive(true);
        SetHint(correctAnswer);
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5f);
        gameUI.GetComponent<GameUi>().MissionFailed();
    }

    void Reset()
    {
        MineCraft.SetActive(false);
        NFS.SetActive(false);
        AmongUs.SetActive(false);
        FallGuys.SetActive(false);
        GTA.SetActive(false);
    }
}