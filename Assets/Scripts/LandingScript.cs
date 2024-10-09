using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Script for the landing screen
/// </summary>
public class LandingScript : MonoBehaviour
{
    public void ShowTopScoresScreen() {
        SceneManager.LoadScene("ScoresScene");
    }
    
    public void StartGame() { 
        SceneManager.LoadScene("PlayerNameScene");
    }

    public void ExitGame() {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        
        Application.Quit();
    }
}
