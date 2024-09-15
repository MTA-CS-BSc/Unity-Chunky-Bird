using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayScript : MonoBehaviour
{
    public int score;
    public Text scoreText;
    
    [ContextMenu("Increase Score")]
    public void IncreaseScore(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();
    }
}
