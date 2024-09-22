using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Script for maintaining the gameplay itself 
/// </summary>
public class GameplayScript : MonoBehaviour
{
    private int _score;
    public Text scoreText;
    public GameObject gameOverScreen;
    public GameObject highScoreScreen;
    public GameObject endGameActions;

    public void IncreaseScore(int amount) {
        if (!gameOverScreen.activeSelf) {
            _score += amount;
            scoreText.text = _score.ToString();   
        }
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitToMainScreen() {
        SceneManager.LoadScene("LandingScene");
    }

    public void GameOver() {
        if (ScoresManager.Instance.IsNewHighScore(_score))
            NewHighScore(_score);
        
        else if (!highScoreScreen.activeSelf)
            gameOverScreen.SetActive(true);

        endGameActions.SetActive(true);
    }
    
    private void NewHighScore(int newScore) {
        highScoreScreen.SetActive(true);
        ScoresManager.Instance.AddScore(newScore);
    }
}
