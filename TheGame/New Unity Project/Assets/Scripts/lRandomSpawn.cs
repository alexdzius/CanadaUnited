/*
 lRandomSpawn.cs
 By Liam Binford
 4/16/20
 This script will allow the user to choose where the spawning x and y coordinates are for the object, including the option to make it random
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lRandomSpawn : MonoBehaviour
{
    public float xPos;
    public float yPos;
    public bool xRandom;
    public bool yRandom;
    Vector3 spawnPos;
    GameObject obj;
    public string spawnedObject;


    // Start is called before the first frame update
    void Start()
    {
        obj = GameObject.Find(spawnedObject);
        if(xRandom)
        {
            //if the player chooses, set xPos to a random number
            xPos = Random.Range(-7.5f, 7.5f);
        }

        if(yRandom)
        {
            //if the player chooses, set yPos to a random number
            yPos = Random.Range(-4.5f, 4.5f);
        }

        //set new spawn coordinates
        spawnPos = new Vector3(xPos, yPos, 0);
        //spawn object at said coordinates
        GameObject.Instantiate(obj, spawnPos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
