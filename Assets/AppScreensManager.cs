using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppScreensManager : MonoBehaviour
{
    public void ShowTopScoresScreen() {
        SceneManager.LoadScene("ScoresScene", LoadSceneMode.Single);
    }
}
