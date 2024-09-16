using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
            topScoresStr += $"{i + 1}. {scores[i].name}\nScore: {scores[i].score.ToString()}\n\n";

        if (topScoresStr == "")
            topScoresStr += "No top scores recorded!";
        
        topScoresText.text = topScoresStr;
    }

    public void ExitToMainScreen() {
        SceneManager.LoadScene("LandingScene");
    }
}
