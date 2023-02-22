using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour
{
    public float rotate;
    void Update()
    {
        Movement();
    }
    void Movement()
    {
        //transform.Translate(Vector2.left * Time.deltaTime * moveSpeed, Space.World);
        transform.Rotate(new Vector3(rotate,0,0 * Time.deltaTime), Space.Self);
    } 
}
