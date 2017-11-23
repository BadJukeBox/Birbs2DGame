using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour {


    void Start () {
		
	}
	
	void Update () {
        Debug.Log("why no work");
	}

    public void exitGame()
    {
        Debug.Log("exiting");
        //Application.Quit();
    }

    public void playLevel()
    {
        Debug.Log("going to play scene");
        //SceneManager.LoadScene("LevelScene");
    }

    public void goToCredits()
    {
        Debug.Log("going to credits");
        //SceneManager.LoadScene("LevelScene");
    }
}
