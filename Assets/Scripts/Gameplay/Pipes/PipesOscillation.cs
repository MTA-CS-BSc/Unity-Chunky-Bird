using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class PipeOscillation : MonoBehaviour
{
    private float _amplitude; // How far the pipe will move up and down
    private float _frequency; // How fast the pipe oscillates

    private Vector3 _startPosition;
    private float _time;

    void Start() {
        _startPosition = transform.position;
        _frequency = new Random().Next(1, 6);
        _amplitude = 1f;
    }

    void Update() {
        _time += Time.deltaTime * _frequency;
        var newY = _startPosition.y + Mathf.Sin(_time) * _amplitude;

        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
