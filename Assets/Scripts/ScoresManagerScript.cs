using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScoresManagerScript : MonoBehaviour
{
    [Serializable]
    public class ScoresData {
        [Serializable]
        public class ScoreRecord
        {
            public int score;
            public string name;

            public ScoreRecord(string name, int score) {
                this.score = score;
                this.name = name;
            }
        }
    
        public List<ScoreRecord> scores = new();
    }
    public static ScoresManagerScript Instance { get; private set; }
    
    private const int MaxScoresCount = 5;
    private string _filePath;
    [SerializeField] private ScoresData scoresData;
    
    void Awake() {
        _filePath = Path.Combine(Application.persistentDataPath, "scores.json");
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        
        else if (Instance != this)
            Destroy(gameObject);
    }
    
    void Start() {
        LoadScores();
    }
    
    private void LoadScores() {
        scoresData = File.Exists(_filePath) ? JsonUtility.FromJson<ScoresData>(File.ReadAllText(_filePath)) : new ScoresData();  
    }

    private void SaveScores() {
        File.WriteAllText(_filePath, JsonUtility.ToJson(scoresData));
    }
    
    public void AddScore(int score) {
        scoresData.scores.Add(new ScoresData.ScoreRecord(PlayerPrefs.GetString("PlayerName"), score));
        scoresData.scores.Sort((a, b) => b.score.CompareTo(a.score));
        
        if (scoresData.scores.Count > MaxScoresCount)
            scoresData.scores.RemoveAt(scoresData.scores.Count - 1);
        
        SaveScores();
    }

    public bool IsNewHighScore(int score) {
        return score > 0 &&
               (scoresData.scores.Count < MaxScoresCount || scoresData.scores.Exists(x => x.score < score));
    }
    
    public List<ScoresData.ScoreRecord> GetTopScores() {
        return scoresData.scores;
    }
}