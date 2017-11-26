using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManagement : MonoBehaviour {

    public GameObject leaf1;
    public GameObject leaf2;
    public GameObject acorn;
    public Camera cam;
    private float _bottom;
    private float _top;
    private float _left;
    private float _right;
    bool meh = true;

    void Start () {
		
	}
	
	void Update () {
        //_bottom = Camera.main.WorldToViewportPoint(transform.position).x;
        Vector3 n = cam.WorldToScreenPoint(new Vector3(0,0,0));
        if (meh)
        {
            Instantiate(acorn, n, new Quaternion());
            meh = false;
        }


    }
}
