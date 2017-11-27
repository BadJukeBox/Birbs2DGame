using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    GameManager manager = GameManager.getGameManager();
    public GameObject countdown;
    public GameObject instructions;
    public GameObject result;
    public Camera cam;
    public Canvas pauseMenu;
    public Canvas score;
    public Canvas endMenu;
    public AudioSource bgMusic;

    bool exists;
    bool paused;
    static bool end;

    float timer = 0;
    float startCountdown = 7.0f;
    float startMovement = 12.0f;
    private float _screenMove = .033f;

    void Start() {

        exists = false;
        paused = false;
        end = false;

        if (manager.getCurrentBird() == "BlueJay") Instantiate(Resources.Load(manager.getCurrentBird()), new Vector3(-5.922f, -1.66f, 0), new Quaternion());
        else if (manager.getCurrentBird() == "Little") Instantiate(Resources.Load(manager.getCurrentBird()), new Vector3(-5.819f, -0.905f, 0), new Quaternion());
        else Instantiate(Resources.Load(manager.getCurrentBird()), new Vector3(-5.927f, -0.765f, 0), new Quaternion());

        endMenu.gameObject.SetActive(false);
        score.gameObject.SetActive(false);
        pauseMenu.gameObject.SetActive(false);
    }

    void Update() {
        if (!paused) timer += Time.deltaTime;

        
        if(!end)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                pauseGame();
            }

            if (timer >= startCountdown && !paused)
            {
                if (!exists)
                {
                    Destroy(instructions);
                    score.gameObject.SetActive(true);
                    Instantiate(countdown);
                    exists = true;
                }
            }
            if (timer >= startMovement && !paused)
            {
                cam.transform.position += new Vector3(_screenMove, 0, 0);
            }
        }
        else
        {
            Debug.Log(ScoreManager.score);
            Image resultImg = result.GetComponent<Image>();
            if (ScoreManager.score < 2000) {
                Debug.Log("noooo");
                resultImg.sprite = Resources.Load<Sprite>("TryAgain");
            }
            else
            {
                resultImg.sprite = Resources.Load<Sprite>("Great");
            }
            endMenu.gameObject.SetActive(true);
        }
    }

    public void exitToMainMenu()
    {
        if(paused)pauseGame();
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
            bgMusic.volume = .15f;
            if (instructions != null) instructions.gameObject.SetActive(false);
            paused = true;
            pauseMenu.gameObject.SetActive(true);
            Time.timeScale = 0;
            BirdMovement.pauseMovement(true);
        }
        else
        {
            bgMusic.volume = .5f;
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

    public void reload()
    {
        SceneManager.LoadScene("LevelScene");
    }
}
