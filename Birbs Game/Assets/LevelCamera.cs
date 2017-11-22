using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCamera : MonoBehaviour {

    public GameObject countdown;

    bool exists = false;

    float timer = 0;
    float startCountdown = 3.0f;
    float startMovement = 8.0f;

    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;
        if(timer >= startCountdown)
        {
            if (!exists)
            {
                Instantiate(countdown);
                exists = true;
            }
        }
        if (timer >= startMovement)
        {
            transform.position += new Vector3(.033f, 0, 0);
        }
        Debug.Log(timer);
    }
}
