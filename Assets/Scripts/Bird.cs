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
    public AudioSource invisibleSound;
    private bool _isInvisible = false;
    
    void Start() {
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        gameplayScript = GameObject.FindGameObjectWithTag("Gameplay").GetComponent<GameplayScript>();
    }

    void Update() {
        if (_isAlive && Input.GetKeyDown(KeyCode.Space)) {
            flipSound.Play();
            rigidbody.velocity = Vector2.up * jumpStrength;
        }

        if (_isAlive && (transform.position.y < -_yDeathPoint || transform.position.y > _yDeathPoint)) {
            outOfBoundsSound.Play();
            KillBird();
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (!_isInvisible && other.gameObject.CompareTag("Pipes")) HandlePipesCollision();
        if (other.gameObject.CompareTag("InvisibleReward")) HandleInvisibleRewardCollision(other);
    }

    private void HandleInvisibleRewardCollision(Collision2D reward) {
        invisibleSound.Play();
        MakeInvisible();
        reward.gameObject.SetActive(false);
    }
    
    private void HandlePipesCollision() {
        hitSound.Play();
        KillBird();
    }

    private void KillBird() {
        _isAlive = false;
        gameplayScript.GameOver();
    }

    private void MakeInvisible(int seconds = 7) {
        GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, .5f);
        SetPipesColliders(false);
        _isInvisible = true;
        StartCoroutine(ReturnToNormal(seconds));
    }

    private void SetPipesColliders(bool activated) {
        GameObject[] allPipes = GameObject.FindGameObjectsWithTag("Pipes");
        
        foreach (GameObject pipe in allPipes)
            pipe.GetComponent<BoxCollider2D>().enabled = activated;
    }
    
    private IEnumerator ReturnToNormal(int seconds) {
        yield return new WaitForSeconds(seconds);
        
        GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 1f);
        _isInvisible = false;
        SetPipesColliders(true);
    }
} 
