using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public bool isBuildinglevel;
    public bool isPlaying;
    public bool paused = false;
    public GameObject bomb;
    public GameObject catapult;
    public float timeSinceReset = 0.0f;

    public GameObject mainCam;
    public GameObject bombCam;

    public Button playButton;
    public GameObject startButton;
    public GameObject inGameMenu;
    public GameObject victoryMenu;

    bool menuActive = false;

    int CurrentLevel;

    public void restartBomb()
    {
        victoryMenu.SetActive(false);
        isBuildinglevel = true;
        isPlaying = false;
        inGameMenu.SetActive(false);
        catapult.transform.position = new Vector3(-4.167999f, -0.459f, 0.0f);
        catapult.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        catapult.transform.rotation = Quaternion.identity;
        mainCam.SetActive(true);
        mainCam.transform.position = new Vector3(6.2f, 5.4f, -10);
        bomb.transform.position = new Vector3(-7.375f, 0.14f, 0.0f);
        bomb.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        bomb.transform.rotation = Quaternion.identity;
        bomb.GetComponent<Rigidbody2D>().Sleep();
        //bombCam.transform.position = new Vector3();
        bombCam.SetActive(false);
        GameObject[] bolders = GameObject.FindGameObjectsWithTag("Bolder");
        if (!bolders.Length.Equals(0))
        {
            Destroy(bolders[0].gameObject);
        }
        startButton.SetActive(true);
        this.GetComponent<StoneBolderController>().bolderInstanciated = false;
        this.GetComponent<StoneBolderController>().bolderReleased = false;
        this.GetComponent<cameraController>().movingBomb = false;
        timeSinceReset = 0.0f;
        Time.timeScale = 1.0f;
    }

    void Start()
    {
        Time.timeScale = 1.0f;
        isBuildinglevel = true;
        isPlaying = false;
        inGameMenu.SetActive(false);
        victoryMenu.SetActive(false);
    }

    public void nextlevel()
    {
       
         PlayerPrefs.SetInt("levelToLoad", PlayerPrefs.GetInt("levelToLoad") + 1);
         SceneManager.LoadScene(1);
    }

    public void StartPlay()
    {
        isBuildinglevel = false;
        isPlaying = true;
        mainCam.SetActive(true);
        bombCam.SetActive(false);
        mainCam.transform.position = new Vector3(6.2f, 5.4f, -10);
    }

    public void Continue()
    {
        inGameMenu.SetActive(false);
        Time.timeScale = 1.0f;
        paused = false;
        menuActive = false;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }

    void Update()
    {
        timeSinceReset += Time.deltaTime;
        if (!isBuildinglevel)
        {
            startButton.SetActive(false);
        }
        else
        {
            startButton.SetActive(true);
            mainCam.SetActive(true);
            bombCam.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menuActive)
            {
                inGameMenu.SetActive(false);
                Time.timeScale = 1.0f;
                paused = false;
                menuActive = false;
            }
            else
            {
                inGameMenu.SetActive(true);
                Time.timeScale = 0.0f;
                paused = true;
                menuActive = true;
            }
        }
    }
}
