using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles the collision for the middle of pipes
/// </summary>
public class PipesMiddleScript : CollisionItem
{
    private GameplayScript _gameplayScript;
    
    void Start() {
        _gameplayScript = GameObject.FindGameObjectWithTag("Gameplay").GetComponent<GameplayScript>();
    }

    protected override void OnHit(GameObject other) {
        _gameplayScript.IncreaseScore(1);
    }
}
