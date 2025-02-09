using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void PlayGame() {
        SceneManager.LoadScene("MainScene");
    }

    public void MainMenuPage() {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void LevelsPage() {
        SceneManager.LoadScene("Levels");
    }

}
