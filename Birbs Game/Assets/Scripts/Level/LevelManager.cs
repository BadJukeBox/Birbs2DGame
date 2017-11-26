using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    GameManager manager = GameManager.getGameManager();
    public GameObject countdown;
    public Camera cam;
    public Canvas pauseMenu;
    public GameObject instructions;

    bool exists = false;
    bool paused = false;
    static bool end = false;

    float timer = 0;
    float startCountdown = 7.0f;
    float startMovement = 12.0f;
    private float _screenMove = .033f;

    void Start () {

        if(manager.getCurrentBird() == "BlueJay")Instantiate(Resources.Load(manager.getCurrentBird()), new Vector3(-5.922f, -1.66f, 0), new Quaternion());
        else if (manager.getCurrentBird() == "Little")Instantiate(Resources.Load(manager.getCurrentBird()), new Vector3(-5.819f, -0.905f, 0), new Quaternion());
        else Instantiate(Resources.Load(manager.getCurrentBird()), new Vector3(-5.927f, -0.765f, 0), new Quaternion());

        pauseMenu.gameObject.SetActive(false);
    }

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
                Destroy(instructions);
                Instantiate(countdown);
                exists = true;
            }
        }
        if (timer >= startMovement && !paused && !end)
        {
            cam.transform.position += new Vector3(_screenMove, 0, 0);
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
            if (instructions != null) instructions.gameObject.SetActive(false);
            paused = true;
            pauseMenu.gameObject.SetActive(true);
            Time.timeScale = 0;
            BirdMovement.pauseMovement(true);
        }
        else
        {
            if (instructions != null) instructions.gameObject.SetActive(true);
            paused = false;
            pauseMenu.gameObject.SetActive(false);
            Time.timeScale = 1.0f;
            BirdMovement.pauseMovement(false);
        }
    }

    public static void stopCamera()
    {
        end = true;
    }

}
