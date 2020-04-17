using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aPlayerController : MonoBehaviour
{
    public GameObject[] aProjectile;
    public Rigidbody2D amyRB;
    public static bool aNegative = false;
    public static int aScore;
    // Start is called before the first frame update
    void Start()
    {
        amyRB = GetComponent<Rigidbody2D>();
        amyRB.velocity = new Vector3(0, -GameManager.aTotalSpeed, 0);
        aScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("left") || Input.GetKeyDown("a")) 
        {
            Instantiate(aProjectile[0], new Vector3(transform.position.x -1, transform.position.y, transform.position.z), Quaternion.identity);
            aNegative = true;
        }
        if(Input.GetKeyDown("right") || Input.GetKeyDown("d"))
        {
            Instantiate(aProjectile[1], new Vector3(transform.position.x + 1, transform.position.y, transform.position.z), Quaternion.identity);
            aNegative = false;
        }
        if(aScore == 3 && amyRB.transform.position.y <= -8)
        {
            print("u won B");
            GameManager.aTotalScore += aScore;
            print("score");
            print(GameManager.aTotalScore);
            print("speed");
            print(GameManager.aTotalSpeed);
            GameManager.aAllowedChange = true;
            GameManager.aLevel = GameManager.aCurrentLevel.alex;
            // proceed to next level
        }
        else if (aScore < 3 && amyRB.transform.position.y <= -8)
        {
            GameManager.aTotalScore += aScore;
            GameManager.aAllowedChange = true;
            GameManager.aLevel = GameManager.aCurrentLevel.adead;
        }
        else
        {

        }
    }
}
