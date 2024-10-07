using UnityEngine;

public abstract class SpawnedItem : MonoBehaviour
{
    public float moveSpeed;
    private readonly float _xDeathPoint = -45;

    void Update() {
        if (transform.position.x < _xDeathPoint)
            gameObject.SetActive(false);
        
        transform.position += Vector3.left * (moveSpeed * Time.deltaTime);    
    }
}