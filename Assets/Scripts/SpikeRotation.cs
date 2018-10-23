using UnityEngine;
using System.Collections;

public class SpikeRotation : MonoBehaviour {

    public float speed = 30.0f;
	
	// Update is called once per frame
	void Update () {
        this.transform.Rotate(Vector3.forward, Time.deltaTime * -speed);
	}
}
