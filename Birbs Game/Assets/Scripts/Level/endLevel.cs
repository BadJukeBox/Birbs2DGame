using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endLevel : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        LevelManager.stopCamera();
        BirdMovement.goToEnd();
    }

}
