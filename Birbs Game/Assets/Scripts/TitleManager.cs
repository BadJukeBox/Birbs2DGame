using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour {

    public void exitGame()
    {
        Application.Quit();
    }

    public void playLevel()
    {
        SceneManager.LoadScene("LevelScene");
    }

    public void chooseBird()
    {
        SceneManager.LoadScene("BirdSelect");
    }

    public void goToCredits()
    {
        SceneManager.LoadScene("Credits");
    }
}
