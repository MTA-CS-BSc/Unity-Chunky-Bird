using System;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T: MonoBehaviour
{
    public static T Instance { get; private set; }
    
    protected virtual void Awake() {
        if (Instance == null) {
            Instance = FindObjectOfType<T>();
            DontDestroyOnLoad(gameObject);
        }
        
        else if (Instance != this)
            Destroy(gameObject);
    }
    
    protected virtual void OnDestroy() {
        if (Instance == this)
            Instance = null;
    }
}