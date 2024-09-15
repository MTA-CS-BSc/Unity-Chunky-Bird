using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    public GameplayScript gameplayScript;
    
    void Start() {
        gameplayScript = GameObject.FindGameObjectWithTag("Gameplay").GetComponent<GameplayScript>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == 6)
            gameplayScript.IncreaseScore(1);
    }
}
