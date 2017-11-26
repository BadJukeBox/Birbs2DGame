using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyAfterPlaying : MonoBehaviour {

    public GameObject countdown;
	void Start () {
        Destroy(countdown, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
    }
	
	void Update () {
		
	}
}
