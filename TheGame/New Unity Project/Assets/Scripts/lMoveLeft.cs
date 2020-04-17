/*
 lMoveLeft.cs
 By Liam Binford
 4/17/20
 This script makes the object move towards the left edge of the screen
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lMoveLeft : MonoBehaviour
{
    Vector3 target;
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        target = new Vector3(-7.5f, transform.position.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed);
    }
}
