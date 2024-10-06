using UnityEngine;

public class SpawnedItem : MonoBehaviour
{
    public float moveSpeed;
    private readonly float _xDeathPoint = -45;

    void Update() {
        if (transform.position.x < _xDeathPoint)
            Destroy(gameObject);
        
        transform.position += Vector3.left * (moveSpeed * Time.deltaTime);    
    }
}