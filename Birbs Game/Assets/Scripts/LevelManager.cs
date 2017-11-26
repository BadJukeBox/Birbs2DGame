using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    GameManager manager = GameManager.getGameManager();
    public GameObject countdown;
    public Camera cam;
    public Canvas pauseMenu;

    bool exists = false;
    bool paused = false;

    float timer = 0;
    float startCountdown = 3.0f;
    float startMovement = 8.0f;
    float offset = 6f; // remove countdown timer 10s after it appears

    // Use this for initialization
    void Start () {
        Instantiate(Resources.Load(manager.getCurrentBird()));
        pauseMenu.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
        if(!paused) timer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseGame();
        }

        if(timer >= startCountdown && !paused)
        {
            if (!exists)
            {
                Instantiate(countdown);
                exists = true;
            }
        }
        if (timer >= startMovement && !paused)
        {
            cam.transform.position += new Vector3(.033f, 0, 0);
        }
    }

    public void exitToMainMenu()
    {
        pauseGame();
        SceneManager.LoadScene("TitleScene");
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void resume()
    {
        pauseGame();
    }

    private void pauseGame()
    {
        if (!paused)
        {
            paused = true;
            pauseMenu.gameObject.SetActive(true);
            Time.timeScale = 0;
            BirdMovement.pauseMovement(true);
        }
        else
        {
            paused = false;
            pauseMenu.gameObject.SetActive(false);
            Time.timeScale = 1.0f;
            BirdMovement.pauseMovement(false);
        }
    }
}
