using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Script for the top scores screen
/// </summary>
public class TopScoresScript : MonoBehaviour
{
    public Transform contentPanel;
    public GameObject scoreItemPrefab;
    private List<ScoresManager.ScoresData.ScoreRecord> _topScores;
    
    void Start() {
        LoadTopScores();
        PopulateScoresList();
    }

    void LoadTopScores() {
        _topScores = ScoresManager.Instance.GetTopScores();
    }
    
    void PopulateScoresList() {
        for (int i = 0; i < _topScores.Count; i++) {
            GameObject scoreItem = Instantiate(scoreItemPrefab, contentPanel);
            Text scoreText = scoreItem.GetComponent<Text>();
            scoreText.text = $"{i + 1}. {_topScores[i].name}\nScore: {_topScores[i].score.ToString()}";
        }
    }

    public void ExitToMainScreen() {
        SceneManager.LoadScene("LandingScene");
    }
}
