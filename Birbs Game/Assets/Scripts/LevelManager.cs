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

    float timer = 0;
    float startCountdown = 7.0f;
    float startMovement = 12.0f;
    private float _startx = -5.922f;
    private float _starty = -1.66f;
    private float _screenMove = .033f;
    float offset = 6f; // remove countdown timer 10s after it appears

    void Start () {
        Instantiate(Resources.Load(manager.getCurrentBird()), new Vector3(_startx,_starty,0), new Quaternion());
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
        if (timer >= startMovement && !paused)
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
