using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour {


    private Animator _anim;
    private float _forwardIncr = .033f;
    private float _moveIncr = .2f;
    private float _moving = 1f;
    private float _idle = 0.01f;
    private float _takeOff = .5f;
    float startMovement = 8.0f;
    float timer = 0f;
    

    void Start () {
        _anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        timer += Time.deltaTime;
        if (_anim == null) return;
        var y = Input.GetAxis("Vertical");

        if (timer > startMovement-1 && timer < startMovement)
        {
            Move(_takeOff, y);
        }
        else if (timer > startMovement)
        {
            Move(_moving, y);
        }
        else
        {
            Move(_idle, 0);
        }
    }

    private void Move(float moveType, float y)
    {
        _anim.SetFloat("Vely", moveType);
        if(moveType != 0.01f) transform.position += new Vector3(_forwardIncr, 0, 0);
        if (y != 0)
        {
            transform.position += y > 0 ? new Vector3(0, _moveIncr, 0) : new Vector3(0, -_moveIncr, 0);
        }
        
    }
}
