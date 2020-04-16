/*
 * By: Harry Jennings-Ramirez
 * Last Edited: 4/16/2020
 * Description: Moves the plate only on the x-axis
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hPlateControl : MonoBehaviour
{
    // Adjust the speed of the plate
    public float speed = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Gets the input to move plate
        if (Input.GetKey("left") || Input.GetKey("a"))
        {
            transform.position = transform.position + new Vector3(-speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey("right") || Input.GetKey("d"))
        {
            transform.position = transform.position + new Vector3(speed * Time.deltaTime, 0, 0);
        }
    }
}
