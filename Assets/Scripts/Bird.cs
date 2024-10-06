using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        // TODO: Handle collision cases
        hitSound.Play();
        EndGame();
    }

    private void EndGame() {
        _isAlive = false;
        gameplayScript.GameOver();
    }
} 
