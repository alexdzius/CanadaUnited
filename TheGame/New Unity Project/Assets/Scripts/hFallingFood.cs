/*
 * By: Harry Jennings-Ramirez
 * Last Edited: 4/17/2020
 * Description: Spawns a falling object (burger) randomly on the x-axis
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hFallingFood : MonoBehaviour
{
    public GameObject Burger;

    // Makes sure it spawns within the wanted range
    public float xMin;
    public float xMax;
    public float yMax;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Instantiate(Burger, new Vector2(Random.Range(xMin, xMax), yMax), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }
}