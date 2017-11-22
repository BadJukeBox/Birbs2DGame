using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallIntoPlace : MonoBehaviour {

    float bottom;
    float buffer = 3.9f; //because the below evidently isn't the "bottom"
    void Start () {
        bottom = Camera.main.WorldToViewportPoint(transform.position).y + buffer;
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y <= bottom)
        {
            transform.position += new Vector3(0, .066f, 0);
        }
    }
}
