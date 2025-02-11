using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchToScene : MonoBehaviour
{
    string filenamePath = "Assets/Contours/RetrySceneName.txt";
    string sceneName = "";
    public void SwitchScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    } // SwitchScene

    public void RetryLevel()
    {
        // get filename from txt file
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

    public void Next() {
// get filename from txt file
        using (StreamReader read = new StreamReader(filenamePath))
        {
            string line;
            while ((line = read.ReadLine()) != null)
            {
                sceneName = line;
            } // while

        } // using

        if (sceneName.Equals("TutorialLevelOne")) {
            SceneManager.LoadScene("TutorialLevelTwo");
        } else if (sceneName.Equals("TutorialLevelTwo")) {
            SceneManager.LoadScene("MainScene");
        }  else if (sceneName.Equals("MainScene")) {
            SceneManager.LoadScene("MainSceneTwo");
        }  else if (sceneName.Equals("MainSceneTwo")) {
            SceneManager.LoadScene("MainSceneThree");
        } else if (sceneName.Equals("MainSceneThree")) {
            SceneManager.LoadScene("MainSceneFour");
        } else if (sceneName.Equals("MainSceneFour")) {
            SceneManager.LoadScene("MainSceneFive");
        } /*else if (sceneName.Equals("MainSceneFive")) {
            SceneManager.LoadScene("MainSceneSix");
        } */else {
             SceneManager.LoadScene("MainMenuScene");
        }
    }
}
