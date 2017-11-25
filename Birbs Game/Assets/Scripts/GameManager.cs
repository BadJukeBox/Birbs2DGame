using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager{

    private static GameManager manager;
    string currentBird;

    private GameManager()
    {
        setCurrentBird("BlueJay");
    }

    public static GameManager getGameManager()
    {
        if(manager == null)
        {
            manager = new GameManager();
        }
        return manager;

    }

    public void setCurrentBird(string bird)
    {
        currentBird = bird;
    }

    public string getCurrentBird()
    {
        return currentBird;
    }
}
