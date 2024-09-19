using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsPoolScript : MonoBehaviour
{
    public GameObject cloudsPrefab;
    public int poolSize;
    private Queue<GameObject> _queue;

    void Start() {
        _queue = new Queue<GameObject>();

        for (int i = 0; i < poolSize; i++) {
            GameObject pipe = Instantiate(cloudsPrefab);
            pipe.SetActive(false);
            _queue.Enqueue(pipe);
        }
    }

    public GameObject GetClouds() {
        if (_queue.Count > 0) {
            GameObject clouds = _queue.Dequeue();
            clouds.SetActive(true);
            return clouds;
        }
        
        return Instantiate(cloudsPrefab);
    }

    public void ReturnPipe(GameObject clouds) {
        clouds.SetActive(false);
        _queue.Enqueue(clouds);
    }
}
