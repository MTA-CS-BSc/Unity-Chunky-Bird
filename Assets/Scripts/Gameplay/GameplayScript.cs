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
    private int _passMiddlePoints = 1;
    
    public void IncreaseScore() {
        if (!gameOverScreen.activeSelf) {
            _score += _passMiddlePoints;
            scoreText.text = _score.ToString();   
        }
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitToMainScreen() => AppSettings.ExitToMainScreen();

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
    
    public void SetPassMiddlePoints(int value) { _passMiddlePoints = value; }
}
