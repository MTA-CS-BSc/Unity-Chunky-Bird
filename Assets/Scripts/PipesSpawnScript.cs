using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script for spawning pipes
/// </summary>
public class PipesSpawnScript : MonoBehaviour 
{
    public Pipes pipesPrefab;
    private GenericObjectPool<Pipes> _pipesPool;
    public float spawnRate;
    private float _timer = 0;
    public float heightOffset;

    void Start() {
        _pipesPool = new GenericObjectPool<Pipes>(pipesPrefab);
    }
    
    void Update() {
        if (_timer < spawnRate)
            _timer += Time.deltaTime;

        else {
            SpawnPipes();
            _timer = 0;
        }
    }

    void SpawnPipes() {
        Pipes pipes = _pipesPool.Get();
        float lowest = transform.position.y - heightOffset;
        float highest = transform.position.y + heightOffset;   
        
        pipes.transform.position = new Vector3(transform.position.x, Random.Range(lowest, highest), 0);
    }
}
