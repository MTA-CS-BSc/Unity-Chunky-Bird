using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System;

[Serializable]
public class ScoreData
{
    public List<int> scores = new List<int>();
}

public class ScoreScript : MonoBehaviour
{
    public int maxScoresCount;
    public string filePath;
    [SerializeField] private ScoreData scoresData;
    
    void Start() {
        filePath = Path.Combine(Application.persistentDataPath, filePath);
        LoadScores();
    }
    
    private void LoadScores() {
        scoresData = File.Exists(filePath) ? JsonUtility.FromJson<ScoreData>(File.ReadAllText(filePath)) : new ScoreData();  
    }

    private void SaveScores() {
        File.WriteAllText(filePath, JsonUtility.ToJson(scoresData));
    }
    
    public void AddScore(int score) {
        scoresData.scores.Add(score);
        scoresData.scores.Sort((a, b) => b.CompareTo(a));
        
        if (scoresData.scores.Count > maxScoresCount)
            scoresData.scores.RemoveAt(scoresData.scores.Count - 1);
        
        SaveScores();
    }

    public bool IsNewHighScore(int score) {
        return score > 0 && !scoresData.scores.Exists(x => x == score) &&
               (scoresData.scores.Count < maxScoresCount || scoresData.scores.Exists(x => x < score));
    }
}
