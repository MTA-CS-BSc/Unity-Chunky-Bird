using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// A class that maintains the bird instance
/// </summary>
public class Bird : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public float jumpStrength;
    public GameplayScript gameplayScript;
    private bool _isAlive = true;
    private readonly float _yDeathPoint = 12;
    public AudioSource flipSound;
    public AudioSource hitSound;
    public AudioSource outOfBoundsSound;
    void Start() {
        gameplayScript = GameObject.FindGameObjectWithTag("Gameplay").GetComponent<GameplayScript>();
    }

    void Update() {
        if (_isAlive && Input.GetKeyDown(KeyCode.Space)) {
            flipSound.Play();
            rigidbody.velocity = Vector2.up * jumpStrength;
        }

        if (_isAlive && (transform.position.y < -_yDeathPoint || transform.position.y > _yDeathPoint)) {
            outOfBoundsSound.Play();
            EndGame();
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Pipes")) HandlePipesCollision();
        else if (other.gameObject.CompareTag("InvisibleReward")) HandleInvisibleRewardCollision();
    }

    private void HandleInvisibleRewardCollision() {
        // invisibleSound.Play();
        MakeInvisible();
    }
    
    private void HandlePipesCollision() {
        hitSound.Play();
        EndGame();
    }

    private void EndGame() {
        _isAlive = false;
        gameplayScript.GameOver();
    }

    private void MakeInvisible(int seconds = 7) {
        GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 0f);
    }
} 
