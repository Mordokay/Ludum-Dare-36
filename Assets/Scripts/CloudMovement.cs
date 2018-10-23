using UnityEngine;
using System.Collections;

public class CloudMovement : MonoBehaviour {

    public Vector3 startPos;
    public Vector3 endPos;
    public float speed = 1.0f;
    public bool movingToEnd;

    void Start()
    {
        movingToEnd = true;
    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        
        this.transform.position = Vector3.MoveTowards(transform.position, endPos, step);
        if (Vector3.Distance(this.transform.position, endPos) < 0.1f)
        {
            this.transform.position = startPos;
        }        
    }
}
