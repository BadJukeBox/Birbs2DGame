using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour {

    public GameObject BackgroundMusic;
    public AudioSource clip;
    static bool exists = false;

	void Awake () {
        if (!exists)
        {
            DontDestroyOnLoad(BackgroundMusic);
            exists = true;
        }
        else
        {
            Destroy(BackgroundMusic);
        }
    }
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "LevelScene")
        {
            Destroy(BackgroundMusic);
        }
    }

}
