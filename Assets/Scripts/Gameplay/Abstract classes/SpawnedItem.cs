using UnityEngine;

public abstract class SpawnedItem : MonoBehaviour
{
    public float moveSpeed;
    private const float XDeathPoint = -45;

    void Update() {
        if (transform.position.x < XDeathPoint)
            Destroy(gameObject);
        
        transform.position += Vector3.left * (moveSpeed * Time.deltaTime);    
    }
}