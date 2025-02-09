using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchToScene : MonoBehaviour
{
    string filenamePath = "Assets/Contours/RetrySceneName.txt";
    public void SwitchScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    } // SwitchScene

    public void RetryLevel()
    {
        // get filename from txt file
        string sceneName = "";
        using (StreamReader read = new StreamReader(filenamePath))
        {
            string line;
            while ((line = read.ReadLine()) != null)
            {
                sceneName = line;
            } // while

        } // using
        SceneManager.LoadScene(sceneName);
    } // RetryLevel
}
