using UnityEngine;
using System.Collections;

public class StoneBolderController : MonoBehaviour {

    GameObject myBolder;
    public bool bolderInstanciated = false;
    public bool bolderReleased = false;
    float increaseSpeedMagnitude = 0.2f;
    float weightIncreaseRatio = 2.0f;
    float scaleLimit = 0.55f;

    GameManager gm;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

	void Update () {
        if (gm.isPlaying && !gm.paused)
        {
            if (Input.GetMouseButtonDown(0) && !bolderInstanciated)
            {
                myBolder = Instantiate(Resources.Load("StoneBolder") as GameObject);
                myBolder.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                myBolder.transform.position = new Vector3(myBolder.transform.position.x, myBolder.transform.position.y, 0.0f);
                bolderInstanciated = true;

            }
            if (Input.GetMouseButton(0) && bolderInstanciated && !bolderReleased)
            {
                if (myBolder.transform.localScale.x < scaleLimit)
                {
                    myBolder.transform.localScale += new Vector3(Time.deltaTime * increaseSpeedMagnitude, Time.deltaTime * increaseSpeedMagnitude, 0.0f);
                }
                myBolder.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                myBolder.transform.position = new Vector3(myBolder.transform.position.x, myBolder.transform.position.y, 0.0f);
                myBolder.GetComponent<Rigidbody2D>().mass = myBolder.transform.localScale.x * 10.0f * weightIncreaseRatio;
            }
            if (Input.GetMouseButtonUp(0) && bolderInstanciated && !bolderReleased)
            {
                myBolder.GetComponent<Rigidbody2D>().gravityScale = 1.0f;
                bolderReleased = true;
            }
        }
	}
}
