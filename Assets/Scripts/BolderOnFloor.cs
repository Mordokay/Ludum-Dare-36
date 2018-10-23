using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BolderOnFloor : MonoBehaviour {

    float timeSinceFloorCollision = 0.0f;
    bool collidedWithFloor = false;
    bool touchedCatapult = false;
    GameManager gm;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag.Equals("FloorCollider"))
        {
            collidedWithFloor = true;
        }
        else if (coll.gameObject.tag.Equals("GameLimitCollider"))
        {
            SceneManager.LoadScene(0);
        }
        else if (coll.gameObject.tag.Equals("Catapult"))
        {
            //Debug.Log("Touched Catapult!!!");
            touchedCatapult = true;
        }
    }
	
	void Update () {
        if (!touchedCatapult)
        {
            if (collidedWithFloor)
            {
                timeSinceFloorCollision += Time.deltaTime;
            }
            if (timeSinceFloorCollision > 2.0f)
            {
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                //Destroy(this.gameObject);
                gm.restartBomb();
                timeSinceFloorCollision = 0.0f;
            }
        }
        else if (collidedWithFloor)
        {
            Destroy(this.gameObject);
        }
	}
}
