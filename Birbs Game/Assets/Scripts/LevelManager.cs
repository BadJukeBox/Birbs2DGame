using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    GameManager manager = GameManager.getGameManager();
    public GameObject countdown;
    public Camera cam;

    bool exists = false;
    bool paused = false;

    float timer = 0;
    float startCountdown = 3.0f;
    float startMovement = 8.0f;
    float offset = 6f; // remove countdown timer 10s after it appears

    // Use this for initialization
    void Start () {
        Instantiate(Resources.Load(manager.getCurrentBird()));
    }

    // Update is called once per frame
    void Update () {
        if(!paused) timer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
            {
                Debug.Log("paused");
                paused = true;
                Time.timeScale = 0;
                BirdMovement.pauseMovement(true);
            }
            else
            {
                Debug.Log("unpaused");
                paused = false;
                Time.timeScale = 1.0f;
                BirdMovement.pauseMovement(false);
            }
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
}
