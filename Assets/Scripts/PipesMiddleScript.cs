using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles the collision for the middle of pipes
/// </summary>
public class PipesMiddleScript : SpawnedItem
{
    private GameplayScript _gameplayScript;
    
    void Start() {
        _gameplayScript = GameObject.FindGameObjectWithTag("Gameplay").GetComponent<GameplayScript>();
    }

    protected void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Bird"))
            _gameplayScript.IncreaseScore(1);
    }
}
