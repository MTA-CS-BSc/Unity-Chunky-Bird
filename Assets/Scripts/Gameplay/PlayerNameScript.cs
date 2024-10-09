using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Script for entering the player's name before the game starts
/// </summary>
public class PlayerNameScript : MonoBehaviour
{
    public Text playerNameText;
    
    public void SaveNameAndStartGame() {
        PlayerPrefs.SetString("PlayerName", playerNameText.text);
        SceneManager.LoadScene("GameScene");
    }
	
	public void ExitToMainScreen() {
		SceneManager.LoadScene("LandingScene");
    }
}