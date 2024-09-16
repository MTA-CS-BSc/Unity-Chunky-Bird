using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopScoresScript : MonoBehaviour
{
    public Text topScoresText;
    
    void Start() {
        LoadTopScores();
    }

    void LoadTopScores() {
        List<ScoresManagerScript.ScoresData.ScoreRecord> scores = ScoresManagerScript.Instance.GetTopScores();
        string topScoresStr = "";

        for (int i = 0; i < scores.Count; i++)
            topScoresStr += $"{i}. {scores[i].name}\n" + $"Score: {scores[i].score.ToString()}\n\n";

        topScoresText.text = topScoresStr;
    }
}
