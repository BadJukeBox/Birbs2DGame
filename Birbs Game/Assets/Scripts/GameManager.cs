using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private static GameManager manager;

    private GameManager()
    {
        currentBird = (GameObject)Resources.Load("BlueJay");
    }

    GameObject currentBird;

    public static GameManager getGameManager()
    {
        if(manager == null)
        {
            manager = new GameManager();
        }
        return manager;

    }

    public void setCurrentBird()
    {

    }
}
