using UnityEngine;
using System.Collections;

public class WoodenBoardController : MonoBehaviour {

    GameObject board;
    bool selectedBoard = false;
    float speedRotation = 20.0f;

    GameManager gm;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (gm.isBuildinglevel && !gm.paused)
        {
            if (Input.GetMouseButtonDown(0) && !selectedBoard)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

                if (hit.collider != null && hit.collider.gameObject.tag.Equals("WoodenBoard"))
                {
                    selectedBoard = true;
                    board = hit.collider.gameObject;
                }
            }
            else if (Input.GetMouseButton(0) && selectedBoard)
            {
                if (selectedBoard)
                {
                    board.transform.Rotate(Vector3.forward, Time.deltaTime * speedRotation);
                }
            }
            else if (Input.GetMouseButtonUp(0))
            {
                selectedBoard = false;
            }
        }
    }
}
