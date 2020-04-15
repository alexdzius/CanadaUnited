using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aProjectiveMove : MonoBehaviour
{
    public Rigidbody2D aMovObject;
    // Start is called before the first frame update
    void Start()
    {
        aMovObject = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (aShooting.aNegative) 
        {
            aMovObject.transform.Translate(Vector2.left * -5 * Time.deltaTime);
        } 
        else
        {
            aMovObject.transform.Translate(Vector2.left * 5 * Time.deltaTime);
        }
    }
}
