using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppScreensManager : MonoBehaviour
{
    public void ShowTopScoresScreen() {
        SceneManager.LoadScene("ScoresScene", LoadSceneMode.Single);
    }
    
    public void StartGame() {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }

    public void ExitGame() {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        
        Application.Quit();
    }
}
