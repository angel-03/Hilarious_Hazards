using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMechanics : MonoBehaviour
{
    [SerializeField] private GameObject front;
    [SerializeField] private GameObject back;

    public static bool isOpen = true;
    public static bool check = false;
    public static bool isFront;

    private static Animator anim;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();    
    }

    void FixedUpdate()
    {
        OpenDoor(check);  
    }

    void OpenDoor(bool check)
    {
        if(check)
        {
            check = false;
            StartCoroutine(Door());
        }
    }

    IEnumerator Door()
    {
        if(isFront)
        {
            if(isOpen)
            {
                anim.SetBool("isOpen",true);
                yield return new WaitForSeconds(1f);
                isOpen = false;
            }
            else
            {
                anim.SetBool("isOpen",false);
                yield return new WaitForSeconds(1f);
                isOpen = true;
                yield return new WaitForSeconds(0.5f);
                anim.SetTrigger("doorIdle");
            }
        }
        else if(!isFront)
        {
            if(isOpen)
            {
                anim.SetBool("isOpenBackwards",true);
                yield return new WaitForSeconds(1f);
                isOpen = false;
            }
            else
            {
                anim.SetBool("isOpenBackwards",false);
                yield return new WaitForSeconds(1f);
                isOpen = true;
                yield return new WaitForSeconds(0.5f);
                anim.SetTrigger("doorIdle");
            }
        }
    }
}
