using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script for spawning pipes
/// </summary>
public class PipesSpawner : Spawner
{
    private Unity.Mathematics.Random _random;

    void Awake() {
        _random = new Unity.Mathematics.Random((uint)System.DateTime.Now.Millisecond);
    }
    
    protected override GameObject Spawn() {
        GameObject objectToSpawn = base.Spawn();
        
        if (_random.NextFloat() < .5f && !objectToSpawn.GetComponent<PipeOscillation>())
            objectToSpawn.AddComponent<PipeOscillation>();

        return objectToSpawn;
    }
}
