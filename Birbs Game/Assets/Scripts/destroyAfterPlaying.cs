using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyAfterPlaying : MonoBehaviour {

    public GameObject countdown;
	// Use this for initialization
	void Start () {
        Destroy(countdown, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
