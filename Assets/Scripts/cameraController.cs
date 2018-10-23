using UnityEngine;
using System.Collections;

public class cameraController : MonoBehaviour {

    public bool movingBomb = false;
    public GameObject mainCam;
    public GameObject bombCam;
    GameObject bomb;
    float mainCameraMoveSpeed = 15.0f;
    GameManager gm;

    void Start()
    {
        bomb = GameObject.FindGameObjectWithTag("Bomb");
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (!movingBomb && (Time.timeSinceLevelLoad > 2.0f || gm.timeSinceReset > 2.0) && bomb.GetComponent<Rigidbody2D>().velocity.magnitude > 0.001f)
        {
            //Debug.Log(movingBomb + "     " + bomb.GetComponent<Rigidbody2D>().velocity.magnitude + "   TimeLevel load:   " + Time.timeSinceLevelLoad);
            movingBomb = true;
            bombCam.SetActive(true);
            mainCam.SetActive(false);
        }
        if (bomb.GetComponent<Rigidbody2D>().velocity.magnitude < 0.001f)
        {
            movingBomb = false;
        }

        if (movingBomb)
        {
            bombCam.transform.position = new Vector3(bomb.transform.position.x, bomb.transform.position.y, bombCam.transform.position.z);
        }
        else
        {
            if (Input.GetKey(KeyCode.W))
            {
                mainCam.transform.position += new Vector3(0.0f, Time.deltaTime * mainCameraMoveSpeed, 0.0f);
            }
            if (Input.GetKey(KeyCode.A))
            {
                mainCam.transform.position -= new Vector3(Time.deltaTime * mainCameraMoveSpeed, 0.0f, 0.0f);
            }
            if (Input.GetKey(KeyCode.S))
            {
                mainCam.transform.position -= new Vector3(0.0f, Time.deltaTime * mainCameraMoveSpeed, 0.0f);
            }
            if (Input.GetKey(KeyCode.D))
            {
                mainCam.transform.position += new Vector3(Time.deltaTime * mainCameraMoveSpeed, 0.0f, 0.0f);
            }
        }
        mainCam.transform.position = new Vector3(Mathf.Clamp(mainCam.transform.position.x, -26.0f, 44.0f),
                Mathf.Clamp(mainCam.transform.position.y, 5.4f, 55.2f), mainCam.transform.position.z);
        bombCam.transform.position = new Vector3(Mathf.Clamp(bombCam.transform.position.x, -26.0f, 44.0f),
                Mathf.Clamp(bombCam.transform.position.y, 5.4f, 55.2f), bombCam.transform.position.z);
    }
}
