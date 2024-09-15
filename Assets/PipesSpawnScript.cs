using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesSpawnScript : MonoBehaviour
{
    public GameObject pipes;
    public float spawnRate = 2;
    private float timer = 0;
    public float heightOffset;
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnPipes();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
            timer += Time.deltaTime;

        else {
            timer = 0;
            SpawnPipes();
        }
    }

    private void SpawnPipes()
    {
        float lowest = transform.position.y - heightOffset;
        float highest = transform.position.y + heightOffset;
        Instantiate(pipes, new Vector3(transform.position.x, Random.Range(lowest, highest), 0), transform.rotation);
    }
}
