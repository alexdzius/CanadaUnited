using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aShooting : MonoBehaviour
{
    public GameObject[] aProjectile;
    public static bool aNegative = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("left") || Input.GetKey("a")) 
        {
            Instantiate(aProjectile[0], transform.position, Quaternion.identity);
            aNegative = true;
        }
        if(Input.GetKey("right") || Input.GetKey("d"))
        {
            Instantiate(aProjectile[1], transform.position, Quaternion.identity);
        }
    }
}
