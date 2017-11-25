using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCamera : MonoBehaviour {

    public GameObject countdown;

    bool exists = false;
    bool paused = false;

    float timer = 0;
    float startCountdown = 3.0f;
    float startMovement = 8.0f;
    float offset = 6f; // remove countdown timer 10s after it appears

    // Use this for initialization
    void Start () {
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
            }
            else
            {
                Debug.Log("unpaused");
                paused = false;
                Time.timeScale = 1.0f;
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
            transform.position += new Vector3(.033f, 0, 0);
        }
    }
}
