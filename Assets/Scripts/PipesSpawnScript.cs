using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesSpawnScript : MonoBehaviour 
{
    public PipesPoolScript pipesPool;
    public float spawnRate;
    private float _timer = 0;
    public float heightOffset;

    void Start() {
        pipesPool = GameObject.FindGameObjectWithTag("PipesPool").GetComponent<PipesPoolScript>();
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
        GameObject pipes = pipesPool.GetPipes();
        float lowest = transform.position.y - heightOffset;
        float highest = transform.position.y + heightOffset;   
        
        pipes.transform.position = new Vector3(transform.position.x, Random.Range(lowest, highest), 0);
    }
}
