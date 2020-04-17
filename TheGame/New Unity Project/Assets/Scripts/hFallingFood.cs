/*
 * By: Harry Jennings-Ramirez
 * Last Edited: 4/15/2020
 * Description: Spawns a falling object (burger) randomly on the x-axis
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hFallingFood : MonoBehaviour
{
    private GameObject Burger;

    // Makes sure it spawns within the wanted range
    public float xMin;
    public float xMax;

    // Used to make sure it only spawns once
    private bool burgerSpawned;

    // Start is called before the first frame update
    void Start()
    {
        burgerSpawned = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Ensures it only spawns once
        Burger = GameObject.Find("burger");
        if (!burgerSpawned)
        {
            burgerSpawned = true;
            Instantiate(Burger, new Vector2(Random.Range(xMin, xMax), 5), Quaternion.identity);
        }
    }
}