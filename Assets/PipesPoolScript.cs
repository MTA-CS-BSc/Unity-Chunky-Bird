using System.Collections.Generic;
using UnityEngine;

public class PipesPoolScript : MonoBehaviour
{
    public GameObject pipesPrefab;
    public int poolSize;
    private Queue<GameObject> _queue;

    void Start() {
        _queue = new Queue<GameObject>();

        for (int i = 0; i < poolSize; i++) {
            GameObject pipe = Instantiate(pipesPrefab);
            pipe.SetActive(false);
            _queue.Enqueue(pipe);
        }
    }

    public GameObject GetPipes() {
        if (_queue.Count > 0) {
            GameObject pipes = _queue.Dequeue();
            pipes.SetActive(true);
            return pipes;
        }
        
        return Instantiate(pipesPrefab);
    }

    public void ReturnPipes(GameObject pipes) {
        pipes.SetActive(false);
        _queue.Enqueue(pipes);
    }
}