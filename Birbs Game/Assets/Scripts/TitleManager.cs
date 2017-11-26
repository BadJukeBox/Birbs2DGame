using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour {

    GameManager manager;

    private void Start()
    {
        Debug.Log(Time.timeScale);
        manager = GameManager.getGameManager(); 
        if (manager.getCurrentBird() == null) manager.setCurrentBird("BlueJay");
    }

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
