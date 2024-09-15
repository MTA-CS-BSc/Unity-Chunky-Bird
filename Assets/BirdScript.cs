using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public float jumpStrength;
    public GameplayScript gameplayScript;
    public bool isAlive = true;
    
    void Start() {
        gameplayScript = GameObject.FindGameObjectWithTag("Gameplay").GetComponent<GameplayScript>();
    }

    void Update() {
        if (isAlive && Input.GetKeyDown(KeyCode.Space))
            rigidbody.velocity = Vector2.up * jumpStrength;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        isAlive = false;
        gameplayScript.GameOver();
    }
} 
