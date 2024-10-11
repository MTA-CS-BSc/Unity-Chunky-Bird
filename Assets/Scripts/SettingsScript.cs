using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    private MusicManager _musicManager;
    public Toggle themeMusicToggle;

    private void Start() {
        themeMusicToggle.isOn = AppSettings.isThemeMusicOn;
        _musicManager = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<MusicManager>();
        themeMusicToggle.onValueChanged.AddListener(delegate {
            ToggleMusic(themeMusicToggle.isOn);
        });
    }

    public void ExitToMainScreen() => AppSettings.ExitToMainScreen();
    private void ToggleMusic(bool isOn) {
        AppSettings.isThemeMusicOn = isOn;
        _musicManager.ToggleThemeMusic(isOn);
    }
}
