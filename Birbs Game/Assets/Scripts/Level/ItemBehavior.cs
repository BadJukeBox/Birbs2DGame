using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehavior : MonoBehaviour {

    ScoreManager manager = new ScoreManager();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("plus 200");
        //manager.updateScore();
        Destroy(this.gameObject);
    }

}
