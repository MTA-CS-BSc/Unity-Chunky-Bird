using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeOscillation : MonoBehaviour
{
    public float amplitude = 0.5f; // How far the pipe will move up and down
    public float frequency = 2f; // How fast the pipe oscillates

    private Vector3 startPosition;
    private float time;

    void Start() {
        startPosition = transform.position;
    }

    void Update() {
        time += Time.deltaTime * frequency;
        float newY = startPosition.y + Mathf.Sin(time) * amplitude;

        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
