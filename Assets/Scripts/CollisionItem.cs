using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CollisionItem : MonoBehaviour
{
    protected abstract void OnHit(GameObject other);
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("Bird"))
            OnHit(other.gameObject);
    }
}
