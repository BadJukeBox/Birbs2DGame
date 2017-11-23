using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour {


    private Animator _anim;
    private float _moveIncr = .1f;


	void Start () {
        _anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        if (_anim == null) return;
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");

        Move(x, y);

	}

    private void Move(float x, float y)
    {
        _anim.SetFloat("Velx", x);
        _anim.SetFloat("Vely", y);
        if(x != 0)
        {
            transform.position += x > 0 ? new Vector3(_moveIncr, 0, 0) : new Vector3(-_moveIncr, 0, 0);
        }
        if(y != 0)
        {
            transform.position += y > 0 ? new Vector3(0, _moveIncr, 0) : new Vector3(0, -_moveIncr, 0);
        }
    }
}
