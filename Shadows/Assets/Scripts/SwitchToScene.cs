using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchToScene : MonoBehaviour {
    string filenamePath = "Assets/Contours/RetrySceneName.txt";
    string sceneName = "";

    /*
     * switch scene to the a specific scene
     * 
     * parameters: string sceneName
     * returns: n/a
     */
    public void SwitchScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    } // SwitchScene

    /*
     * return from 2d level to the corresponding 3d level
     * 
     * parameters: n/a
     * returns: n/a
     */
    public void RetryLevel() {
        // get filename from RetrySceneName.txt file
        using (StreamReader read = new StreamReader(filenamePath)) {
            string line;
            // loop through txt file
            while ((line = read.ReadLine()) != null) {
                sceneName = line;
            } // while
        } // using
        SceneManager.LoadScene(sceneName);
    } // RetryLevel

    /*
     * reset the 3d level objects to their starting positions
     * 
     * parameters: n/a
     * returns: n/a
     */
    public void ResetLevel() {
        // get current scene name and load scene by name
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    } // ResetLevel

    /*
     * switch to scene for next level
     * if last level, go to main menu scene
     * 
     * parameters: n/a
     * returns: n/a
     */
    public void Next() {
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
        } else {
             SceneManager.LoadScene("MainMenuScene");
        } // if-else
    } // Next
} // SwitchToScene
