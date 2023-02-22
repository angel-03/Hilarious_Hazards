using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    public PlayerMovement pm;
    public GameObject gameUI;

    public int deathVariant;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Died");
            //Time.timeScale = 0;
            //pm.TurnOnRagdoll();
            pm.Death();
            StartCoroutine(StartGameOver());
        }    
    }

    IEnumerator StartGameOver()
    {
        yield return new WaitForSeconds(4f);
        gameUI.GetComponent<GameUi>().ActivateScreen();
        yield return new WaitForSeconds(0.05f);
        gameUI.GetComponent<GameUi>().GameOverUI(deathVariant);
    }
}
