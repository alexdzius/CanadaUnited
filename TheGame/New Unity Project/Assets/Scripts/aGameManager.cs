using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class aGameManager : MonoBehaviour
{
    public enum aCurrentLevel {alex, cj, harry, josh, liam, marvin, astart};
    public static bool aAllowedChange = false;
    public static aCurrentLevel aLevel = aCurrentLevel.astart;
    public static int aTotalScore = 0;
    public static float aTotalSpeed = 2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        aTotalSpeed = aTotalScore / 10 * aTotalSpeed;
        if (aAllowedChange)
        {
            aAllowedChange = false;
            switch (aLevel)
            {
                case aCurrentLevel.astart:
                    {
                        SceneManager.LoadScene("start");
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
            }
        }
    }
}
