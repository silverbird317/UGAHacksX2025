using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchToScene : MonoBehaviour {
    string filenamePath = "Assets/TXT Files/RetrySceneName.txt";
    string sceneName = "";

    string sceneNameListPath = "Assets/TXT Files/SceneNamesList.txt";

    /*
     * switch scene to the a specific scene
     * 
     * parameters: string sceneName
     * returns: n/a
     */
    public void SwitchScene(string name) {
        SceneManager.LoadScene(name);
    } // SwitchScene

    /*
     * return from 2d level to the corresponding 3d level
     * 
     * parameters: n/a
     * returns: n/a
     */
    public void RetryLevel() {
        // get scenename from RetrySceneName.txt file
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
        // get scenename from RetrySceneName.txt file
        using (StreamReader read = new StreamReader(filenamePath)) {
            string line;
            // loop through txt file
            while ((line = read.ReadLine()) != null) {
                sceneName = line;
            } // while
        } // using
        Debug.Log(sceneName);
        char sceneType = sceneName[0];
        int sceneNumber = 0;
        bool convertNum = false;
        convertNum = int.TryParse(sceneName.Substring(1, 5), out sceneNumber);

        // get all scene names from SceneNamesList.txt file
        Dictionary<int, string> tutorialLevels = new Dictionary<int, string>();
        Dictionary<int, string> levels = new Dictionary<int, string>();
        int tutorialMaxKey = 0;
        int levelMaxKey = 0;
        using (StreamReader read = new StreamReader(sceneNameListPath)) {
            string line;
            // loop through txt file
            while ((line = read.ReadLine()) != null) {
                string levelNum = line.Substring(1, 5);
                bool isConvertible = false;
                int nameAsInt = 0;
                isConvertible = int.TryParse(levelNum, out nameAsInt);
                if (line[0] == 'T') {
                    tutorialLevels.Add(nameAsInt, line);
                    if (nameAsInt > tutorialMaxKey) {
                        tutorialMaxKey = nameAsInt;
                    } // if
                }
                else if (line[0] == 'L') {
                    levels.Add(nameAsInt, line);
                    if (nameAsInt > levelMaxKey) {
                        levelMaxKey = nameAsInt;
                    } // if
                } // if-else
            } // while
        } // using

        Debug.Log("tutorial Max: " + tutorialMaxKey);
        Debug.Log("level Max: " + levelMaxKey);
        Debug.Log("current scene num: " + sceneNumber);
        Debug.Log("current scene type: " + sceneType);

        string nextLevel = " ";
        if (sceneType == 'T') {
            if (sceneNumber == tutorialMaxKey) {
                nextLevel = "L00001";
            } else {
                nextLevel = "T" + (sceneNumber + 1).ToString("D5");
            } // if-else
        } else if (sceneType == 'L') {
            if (sceneNumber == levelMaxKey) {
                nextLevel = "Title Screen";
            } else {
                nextLevel = "L" + (sceneNumber + 1).ToString("D5");
            } // if-else
        } // if-else

        Debug.Log("next level: " + nextLevel);
        SceneManager.LoadScene(nextLevel);

        /*
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
        */
    } // Next
} // SwitchToScene
