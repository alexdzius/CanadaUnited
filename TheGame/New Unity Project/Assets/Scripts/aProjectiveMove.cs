using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aProjectiveMove : MonoBehaviour
{
    public Rigidbody2D aMovObject;
    public bool aMinus;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if it hits scoreing tile
        if (collision.gameObject.tag == "Respawn")
        {
            aPlayerController.aScore++;
            Destroy(gameObject);
            Destroy(collision.gameObject);
        } 
        if (collision.gameObject.tag == "EditorOnly")
        {
            // if it hits platform
            Destroy(gameObject);
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
            aMovObject.transform.Translate(Vector2.left * 15 * Time.deltaTime);
        } 
        else 
        {
            aMovObject.transform.Translate(Vector2.right * 15 * Time.deltaTime);
        }

        if(aMovObject.transform.position.x > 9 || aMovObject.transform.position.x < -9)
        {
            Destroy(gameObject);
        }
    }
}
