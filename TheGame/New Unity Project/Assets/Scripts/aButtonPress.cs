using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class aButtonPress : MonoBehaviour
{
    public void OnPress()
    {
        GameManager.aAllowedChange = true;
        GameManager.aLevel = (GameManager.aCurrentLevel)Random.Range(0, 5);
        print(GameManager.aLevel);
        print(GameManager.aAllowedChange);
    }
    public void OnDeathPress()
    {
        GameManager.aAllowedChange = true;
        GameManager.aLevel = GameManager.aCurrentLevel.astart;
        print(GameManager.aLevel);
        print(GameManager.aAllowedChange);
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
