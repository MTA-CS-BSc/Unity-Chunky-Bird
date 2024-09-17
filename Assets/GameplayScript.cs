using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayScript : MonoBehaviour
{
    public int score;
    public Text scoreText;
    public GameObject gameOverScreen;
    public GameObject highScoreScreen;
    public GameObject endGameActions;

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

    public void ExitToMainScreen() {
        SceneManager.LoadScene("LandingScene");
    }

    public void GameOver() {
        if (ScoresManagerScript.Instance.IsNewHighScore(score))
            NewHighScore(score);
        
        else
            gameOverScreen.SetActive(true);

        endGameActions.SetActive(true);
    }
    
    private void NewHighScore(int newScore) {
        highScoreScreen.SetActive(true);
        ScoresManagerScript.Instance.AddScore(newScore);
    }
}
