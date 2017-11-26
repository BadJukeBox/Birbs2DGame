using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseBirdManager : MonoBehaviour {

    GameManager manager = GameManager.getGameManager();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            acceptAndExit();
        }
    }

    public void chooseBlueJay()
    {
        manager.setCurrentBird("BlueJay");
    }

    public void chooseBigBlue()
    {
        manager.setCurrentBird("BigBlue");
    }

    public void chooseLittle()
    {
        manager.setCurrentBird("Little");
    }

    public void acceptAndExit()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
