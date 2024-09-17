using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesSpawnScript : MonoBehaviour 
{
    public PipesPoolScript pipesPool;
    public float spawnRate;
    private float timer = 0;
    public float heightOffset;

    void Start() {
        pipesPool = GameObject.FindGameObjectWithTag("PipesPool").GetComponent<PipesPoolScript>();
    }
    
    void Update() {
        if (timer < spawnRate)
            timer += Time.deltaTime;

        else {
            SpawnPipes();
            timer = 0;
        }
    }

    void SpawnPipes() {
        GameObject pipes = pipesPool.GetPipes();
        float lowest = transform.position.y - heightOffset;
        float highest = transform.position.y + heightOffset;   
        
        pipes.transform.position = new Vector3(transform.position.x, Random.Range(lowest, highest), 0);
    }
}
