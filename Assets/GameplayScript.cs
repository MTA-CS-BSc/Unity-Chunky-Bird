using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayScript : MonoBehaviour
{
    public int score;
    public Text scoreText;
    public GameObject gameOverScreen;
    public ScoreScript scoreScript;

    void Start() {
        scoreScript = GameObject.FindGameObjectWithTag("Scores").GetComponent<ScoreScript>();
    }

    [ContextMenu("Increase Score")]
    public void IncreaseScore(int amount) {
        if (!gameOverScreen.activeSelf) {
            score += amount;
            scoreText.text = score.ToString();   
        }
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver() {
        if (scoreScript.IsNewHighScore(score))
            NewHighScore(score);
        
        gameOverScreen.SetActive(true);
    }
    private void NewHighScore(int newScore) {
        // highScoreScreen.SetActive(true);
        scoreScript.AddScore(newScore);
    }
}
