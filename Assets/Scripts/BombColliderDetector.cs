using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BombColliderDetector : MonoBehaviour {

    float timeSinceFloorCollision = 0.0f;
    public float timeSinceStop = 0.0f;
    bool collidedWithFloor = false;

    GameObject victoryCircle;
    public float TimeOnVictory = 0.0f;
    float timeSinceLastBlink = 0.0f;
    float blinkInterval = 0.2f;
    float TimeToVictory = 3.0f;

    GameObject catapult;
    GameManager gm;
    public GameObject mainCam;
    public GameObject bombCam;

    public GameObject victoryCanvas;

    void Start()
    {
        catapult = GameObject.FindGameObjectWithTag("Catapult");
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag.Equals("FloorCollider")){
            collidedWithFloor = true;
        }
        else if (coll.gameObject.tag.Equals("GameLimitCollider")) {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            gm.restartBomb();
            mainCam.SetActive(true);
            bombCam.SetActive(false);
        }
        else if (coll.gameObject.tag.Equals("BadSpike"))
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            gm.restartBomb();
            mainCam.SetActive(true);
            bombCam.SetActive(false);
        }
    }

	void Update () {
        victoryCircle = GameObject.FindGameObjectWithTag("VictoryCircle");

        if (this.GetComponent<Rigidbody2D>().velocity.magnitude < 0.0001 &&
            !this.GetComponent<CircleCollider2D>().bounds.Intersects(catapult.GetComponent<EdgeCollider2D>().bounds))
        {
            timeSinceStop += Time.deltaTime;
        }

        if (this.GetComponent<CircleCollider2D>().bounds.Intersects(victoryCircle.GetComponent<CircleCollider2D>().bounds) &&
            TimeOnVictory < TimeToVictory)
        {
                TimeOnVictory += Time.deltaTime;
                timeSinceLastBlink += Time.deltaTime;
                if (timeSinceLastBlink > blinkInterval)
                {
                    if (victoryCircle.GetComponent<SpriteRenderer>().color.a == 0.4f)
                    {
                        victoryCircle.GetComponent<SpriteRenderer>().color =
                            new Color(victoryCircle.GetComponent<SpriteRenderer>().color.r,
                                victoryCircle.GetComponent<SpriteRenderer>().color.g,
                                victoryCircle.GetComponent<SpriteRenderer>().color.b, 0.6f);
                    }
                    else
                    {
                        victoryCircle.GetComponent<SpriteRenderer>().color =
                            new Color(victoryCircle.GetComponent<SpriteRenderer>().color.r,
                                victoryCircle.GetComponent<SpriteRenderer>().color.g,
                                victoryCircle.GetComponent<SpriteRenderer>().color.b, 0.4f);
                    }
                    timeSinceLastBlink = 0.0f;
                }
        }
        else if (TimeOnVictory > TimeToVictory)
        {
            victoryCircle.GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.9f, 0.0f, 0.9f);
            Time.timeScale = 0.0f;
            victoryCanvas.SetActive(true);
            PlayerPrefs.SetInt("Level" + (PlayerPrefs.GetInt("levelToLoad") + 1).ToString(), 1);
            TimeOnVictory = 0.0f;
        }
        else
        {
            TimeOnVictory = 0.0f;
            victoryCircle.GetComponent<SpriteRenderer>().color =
                        new Color(victoryCircle.GetComponent<SpriteRenderer>().color.r,
                            victoryCircle.GetComponent<SpriteRenderer>().color.g,
                            victoryCircle.GetComponent<SpriteRenderer>().color.b, 0.4f); ;
        }

        if (collidedWithFloor)
        {
            timeSinceFloorCollision += Time.deltaTime;
        }
        if (timeSinceFloorCollision > 2.0f)
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            timeSinceFloorCollision = 0.0f;
            collidedWithFloor = false;
            gm.restartBomb();
        }
        if (timeSinceStop > 2.0f && !this.GetComponent<CircleCollider2D>().bounds.Intersects(victoryCircle.GetComponent<CircleCollider2D>().bounds))
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            timeSinceStop = 0.0f;
            collidedWithFloor = false;
            gm.restartBomb();
        }
	}
}

