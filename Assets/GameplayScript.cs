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
        gameOverScreen.SetActive(true);
    }
}
