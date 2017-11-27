using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehavior : MonoBehaviour {

    ScoreManager manager;

    private void Start()
    {
        manager = new ScoreManager();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(this.gameObject.name);
        if(this.gameObject.name.Contains("leaf") || this.gameObject.name.Contains("leaf2"))
        {
            manager.decreaseScore();
        }
        else if(this.gameObject.name.Contains("acorn"))
        {
            manager.updateScore();
        }
        Destroy(this.gameObject);
    }

}
