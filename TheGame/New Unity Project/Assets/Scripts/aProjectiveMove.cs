using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aProjectiveMove : MonoBehaviour
{
    public Rigidbody2D aMovObject;
    public bool aMinus;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if it hits scoreing tile
        if(collision.gameObject.tag == "Finish")
        {
            aPlayerController.aScore++;
            Destroy(gameObject);
        }
        // if it hits platform
        else if(collision.gameObject.tag == "EditorOnly")
        {
            Destroy(gameObject);
        }
        else 
        {
            // do nothing lol
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        aMovObject = GetComponent<Rigidbody2D>();
        aMinus = aPlayerController.aNegative;
    }

    // Update is called once per frame
    void Update()
    {
        if (aMinus) 
        {
            aMovObject.transform.Translate(Vector2.left * 5 * Time.deltaTime);
        } 
        else 
        {
            aMovObject.transform.Translate(Vector2.right * 5 * Time.deltaTime);
        }

        if(aMovObject.transform.position.x > 9 || aMovObject.transform.position.x < -9)
        {
            Destroy(gameObject);
        }
    }
}
