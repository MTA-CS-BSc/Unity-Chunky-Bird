using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsSpawnScript : MonoBehaviour
{
    public GameObject clouds;
    public float spawnRate;
    private float timer = 0;
    public float heightOffset;

    void Start() {
        SpawnClouds();
    }

    void Update() {
        if (timer < spawnRate)
            timer += Time.deltaTime;

        else {
            timer = 0;
            SpawnClouds();
        }
    }
    
    private void SpawnClouds() {
        float lowest = transform.position.y - heightOffset;
        float highest = transform.position.y + heightOffset;
        Instantiate(clouds, new Vector3(transform.position.x, Random.Range(lowest, highest), 0), transform.rotation);
    }
}
