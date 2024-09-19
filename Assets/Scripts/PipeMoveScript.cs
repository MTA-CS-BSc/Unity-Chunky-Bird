using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public float moveSpeed;
    public float pipesXDeathPoint;

    void Update() {
        if (transform.position.x < pipesXDeathPoint)
            Destroy(gameObject);
        
        transform.position += Vector3.left * (moveSpeed * Time.deltaTime);    
    }
}
