using System;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T: MonoBehaviour
{
    public static T Instance { get; private set; }
    
    // Self implemented optimized code
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
    
    // Code from class
    // Property to access the instance
    // public static T Instance
    // {
    //     get
    //     {
    //         
    //         //if (_instance != null) return _instance;
    //         if (!ReferenceEquals(_instance, null)) return _instance;
    //         
    //         // If the instance doesn't exist, find it in the scene
    //         _instance = FindObjectOfType<T>();
    //
    //         if (_instance == null)
    //         {
    //             var singletonObject = new GameObject(typeof(T).Name);
    //             _instance = singletonObject.AddComponent<T>();
    //             DontDestroyOnLoad(_instance.gameObject);
    //         }
    //             
    //         return _instance;
    //     }
    // }
}