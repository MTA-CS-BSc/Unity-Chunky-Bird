using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Vector2 = UnityEngine.Vector2;

/// <summary>
/// A class that maintains the bird instance
/// </summary>
public class Bird : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public float jumpStrength;
    private GameplayScript _gameplayScript;
    private bool _isAlive = true;
    private readonly float _yDeathPoint = 12;
    private readonly float _xDeathPoint = 20;
    public AudioSource flipSound;
    public AudioSource hitSound;
    public AudioSource outOfBoundsSound;
    public AudioSource invisibleSound;
    public AudioSource doublePointsSound;
    private bool _isInvisible = false;
    public SpriteRenderer spriteRenderer;
    
    void Start() {
        rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        _gameplayScript = GameObject.FindGameObjectWithTag("Gameplay").GetComponent<GameplayScript>();
    }

    void Update() {
        if (_isAlive && Input.GetKeyDown(KeyCode.Space)) {
            flipSound.Play();
            rigidbody.velocity = Vector2.up * jumpStrength;
        }

        if (!_isAlive || (!(transform.position.y < -_yDeathPoint) && !(transform.position.y > _yDeathPoint) &&
                          !(transform.position.x < -_xDeathPoint) && !(transform.position.x > _xDeathPoint))) return;

        outOfBoundsSound.Play();
        KillBird();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Invisibility")) HandleInvisibilityCollision(other);
        if (other.gameObject.CompareTag("DoubleScore")) HandleDoublePointsCollision(other);
        if (!_isInvisible && other.gameObject.CompareTag("Pipes")) HandlePipesCollision();
    }

    private void HandleDoublePointsCollision(Collision2D reward) {
        doublePointsSound.Play();
        MakeDoublePoints();
        reward.gameObject.SetActive(false);
    }
    
    private void HandleInvisibilityCollision(Collision2D reward) {
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
        _gameplayScript.GameOver();
    }

    private void MakeDoublePoints(int seconds = 10) {
        _gameplayScript.SetPassMiddlePoints(2);
        StartCoroutine(MakeNormalPoints(seconds));
    }
    
    private void MakeInvisible(int seconds = 10) {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Bird"), LayerMask.NameToLayer("Pipes"), true);
        spriteRenderer.material.color = new Color(1f, 1f, 1f, .5f);
        _isInvisible = true;
        StartCoroutine(MakeVisible(seconds));
    }
    
    private IEnumerator MakeVisible(int seconds) {
        yield return new WaitForSeconds(seconds);
        
        spriteRenderer.material.color = new Color(1f, 1f, 1f, 1f);
        _isInvisible = false;
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Bird"), LayerMask.NameToLayer("Pipes"), false);
    }
    
    private IEnumerator MakeNormalPoints(int seconds) {
        yield return new WaitForSeconds(seconds);
        _gameplayScript.SetPassMiddlePoints(1);
    }
} 
