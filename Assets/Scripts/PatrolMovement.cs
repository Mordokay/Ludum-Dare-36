using UnityEngine;
using System.Collections;

public class PatrolMovement : MonoBehaviour {

    public Vector3 startPos;
    public Vector3 endPos;
    public float speed = 1.0f;
    public bool movingToEnd;

    void Start()
    {
        movingToEnd = true;
        this.transform.position = startPos;
    }

    void Update()
    {

        float step = speed * Time.deltaTime;
        if (movingToEnd)
        {
            this.transform.position = Vector3.MoveTowards(transform.position, endPos, step);
            if (Vector3.Distance(this.transform.position, endPos) < 0.1f)
            {
                movingToEnd = false;
                //transform.Rotate(Vector3.up, 180);
            }
        }
        else
        {
            this.transform.position = Vector3.MoveTowards(transform.position, startPos, step);
            if (Vector3.Distance(this.transform.position, startPos) < 0.1f)
            {
                movingToEnd = true;
                //transform.Rotate(Vector3.up, 180);
            }
        }

    }
}
