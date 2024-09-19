using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesMiddleScript : MonoBehaviour
{
    private GameplayScript _gameplayScript;
    
    void Start() {
        _gameplayScript = GameObject.FindGameObjectWithTag("Gameplay").GetComponent<GameplayScript>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("Bird"))
            _gameplayScript.IncreaseScore(1);
    }
}
