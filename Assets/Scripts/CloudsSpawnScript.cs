using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsSpawnScript : MonoBehaviour
{
    public CloudsPoolScript cloudsPool;
    public float spawnRate;
    private float _timer = 0;
    public float heightOffset;

    void Start() {
        cloudsPool = GameObject.FindGameObjectWithTag("CloudsPool").GetComponent<CloudsPoolScript>();
    }
    
    void Update() {
        if (_timer < spawnRate)
            _timer += Time.deltaTime;

        else {
            SpawnClouds();
            _timer = 0;
        }
    }

    void SpawnClouds() {
        GameObject clouds = cloudsPool.GetClouds();
        float lowest = transform.position.y - heightOffset;
        float highest = transform.position.y + heightOffset;   
        
        clouds.transform.position = new Vector3(transform.position.x, Random.Range(lowest, highest), 0);
    }
}
