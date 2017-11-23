using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour {


    private Animator _anim;
    private float _forwardIncr = .033f;
    private float _moveIncr = .2f;
    float startMovement = 8.0f;
    float timer = 0f;

    void Start () {
        _anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        timer += Time.deltaTime;
        if (_anim == null) return;
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");

        if(timer > startMovement)
        {
            Move(x, y);

        }
    }

    private void Move(float x, float y)
    {
        _anim.SetFloat("Velx", x);
        _anim.SetFloat("Vely", y);
        /*if(x != 0)
        {
            transform.position += x > 0 ? new Vector3(_moveIncr, 0, 0) : new Vector3(-_moveIncr, 0, 0);
        }*/
        transform.position += new Vector3(_forwardIncr, 0, 0);
        if (y != 0)
        {
            transform.position += y > 0 ? new Vector3(0, _moveIncr, 0) : new Vector3(0, -_moveIncr, 0);
        }
        
    }
}
