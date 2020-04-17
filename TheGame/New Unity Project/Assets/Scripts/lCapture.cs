/*
 lCapture.cs
 By Liam Binford
 4/17/20
 This script allows the player to hover the reticle over the target and press a button to capture it
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lCapture : MonoBehaviour
{
    public GameObject target;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            print("touch");
            if (Input.GetKey("space"))
            {
                GameManager.aTotalScore += 3;
                GameManager.aAllowedChange = true;
                GameManager.aLevel = (GameManager.aCurrentLevel)Random.Range(0, 5);
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
