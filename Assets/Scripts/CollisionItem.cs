using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CollisionItem : SpawnedItem
{
    protected abstract void OnHit(GameObject other);
    
    protected void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Bird"))
            OnHit(other.gameObject);
    }
}
