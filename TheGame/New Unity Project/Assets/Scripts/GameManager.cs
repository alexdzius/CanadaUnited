using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public enum aCurrentLevel {alex, cj, harry, josh, liam, marvin, astart, adead};
    public static bool aAllowedChange = false;
    public static aCurrentLevel aLevel = aCurrentLevel.astart;
    public static int aTotalScore = 0;
    public static float aTotalSpeed = 2;
    public int aScoreValue = 4;
    // Start is called before the first frame update
    void Start()
    {
        GameManager[] anObject = FindObjectsOfType<GameManager>();
        if (anObject.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
        if (aAllowedChange)
        {
            print("speed before edit");
            print(aTotalSpeed);
            aTotalSpeed = ((float) aScoreValue / 4) * aTotalSpeed;
            print("speed after edit");
            print(aTotalSpeed);
            aScoreValue = aTotalScore;
            aAllowedChange = false;
            switch (aLevel)
            {
                case aCurrentLevel.astart:
                    {
                        SceneManager.LoadScene("start");
                        print("loading");
                        break;
                    }
                case aCurrentLevel.alex:
                    {
                        SceneManager.LoadScene("alex");
                        break;
                    }
                case aCurrentLevel.cj:
                    {
                        SceneManager.LoadScene("cj");
                        break;
                    }
                case aCurrentLevel.harry:
                    {
                        SceneManager.LoadScene("harry");
                        break;
                    }
                case aCurrentLevel.josh:
                    {
                        SceneManager.LoadScene("josh");
                        break;
                    }
                case aCurrentLevel.liam:
                    {
                        SceneManager.LoadScene("liam");
                        break;
                    }
                case aCurrentLevel.marvin:
                    {
                        SceneManager.LoadScene("marvin");
                        break;
                    }
                case aCurrentLevel.adead:
                    {
                        SceneManager.LoadScene("dead");
                        break;
                    }
            }
        }
    }
}
