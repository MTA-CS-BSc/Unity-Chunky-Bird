using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
    public float moveSpeed;
    public float cloudsXDeathPoint;
    
    void Update() {
        if (transform.position.x < cloudsXDeathPoint)
            Destroy(gameObject);
        
        transform.position += Vector3.left * (moveSpeed * Time.deltaTime);   
    }
}
