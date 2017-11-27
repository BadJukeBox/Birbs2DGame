using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour {

    private Transform target;
    private Transform endPoint;
    private Animator _anim;
    private static float _forwardIncr = .033f;
    private static float _moveIncr = .2f;
    private float _idle = 0f;
    private float _takeOff = .34f;
    private float _moving = .67f;
    private float _landing = 1f;

    float startMovement = 12.0f;
    float timer = 0f;

    public static bool end;
    

    void Start () {
        end = false;
        target = GameObject.Find("endPointFlight").transform;
        endPoint = GameObject.Find("endPoint").transform;
        _anim = GetComponent<Animator>();
	}
	
	void Update () {
        timer += Time.deltaTime;
        if (_anim == null) return;
        var y = Input.GetAxis("Vertical");
        
        if (end)
        {
            Move(_landing, 0);
        }
        else
        {
            if (timer > startMovement - 1 && timer < startMovement)
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
    }

    private void Move(float moveType, float y)
    {
        _anim.SetFloat("Vely", moveType);
        if (moveType > .01f && moveType < 1f) transform.position += new Vector3(_forwardIncr, 0, 0);
        else if (moveType == 1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, .05f);
            if (transform.position == target.position)
            {
                transform.position = target.position = endPoint.position;
                Move(_idle, 0);
            }   
        }
        if (y != 0)
        {
            transform.position += y > 0 ? new Vector3(0, _moveIncr, 0) : new Vector3(0, -_moveIncr, 0);
        }
        
    }

    public static void pauseMovement(bool pause)
    {
        if (pause)
        {
            Time.timeScale = 0;
            _moveIncr = _forwardIncr = 0;
        }
        else
        {
            Time.timeScale = 1.0f;
            _moveIncr = .2f;
            _forwardIncr = 0.33f;
        }
    }

    public static void goToEnd()
    {
        end = true;
    }
}
