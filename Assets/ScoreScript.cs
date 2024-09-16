using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System;

[Serializable]
public class ScoreData
{
    [Serializable]
    public class ScoreRecord
    {
        public int score;
        public string name;

        public ScoreRecord(string _name, int _score)
        {
            score = _score;
            name = _name;
        }
    }
    
    public List<ScoreRecord> scores = new();
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
        scoresData.scores.Add(new ScoreData.ScoreRecord(PlayerPrefs.GetString("PlayerName"), score));
        scoresData.scores.Sort((a, b) => b.score.CompareTo(a.score));
        
        if (scoresData.scores.Count > maxScoresCount)
            scoresData.scores.RemoveAt(scoresData.scores.Count - 1);
        
        SaveScores();
    }

    public bool IsNewHighScore(int score) {
        return score > 0 && !scoresData.scores.Exists(x => x.score == score) &&
               (scoresData.scores.Count < maxScoresCount || scoresData.scores.Exists(x => x.score < score));
    }
}
