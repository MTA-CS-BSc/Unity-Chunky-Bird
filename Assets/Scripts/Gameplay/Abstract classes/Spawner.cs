using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    private AppObjectPool _pool;
    public GameObject prefab;
    private float _timer = 0;
    public float spawnRate;
    public float heightOffset;
    
    void Start() {
        _pool = new AppObjectPool(prefab);
    }

    void Update() {
        if (_timer < spawnRate)
            _timer += Time.deltaTime;

        else {
            Spawn();
            _timer = 0;
        }
    }

    private GameObject GetFromPool() => _pool.Get();

    protected virtual GameObject Spawn() {
        GameObject objectToSpawn = GetFromPool();
        var lowest = transform.position.y - heightOffset;
        var highest = transform.position.y + heightOffset;   
        
        objectToSpawn.transform.position = new Vector3(transform.position.x, Random.Range(lowest, highest), 0);

        return objectToSpawn;
    }
}
