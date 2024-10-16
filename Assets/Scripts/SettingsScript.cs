using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    private MusicManager _musicManager;
    public Toggle themeMusicToggle;
    public Toggle birdSoundsToggle;
    public Dropdown difficultyDropdown;

    private void Start() {
        _musicManager = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<MusicManager>();

        themeMusicToggle.isOn = AppSettings.isThemeMusicOn;
        themeMusicToggle.onValueChanged.AddListener(delegate {
            OnToggleThemeMusicChanged(themeMusicToggle.isOn);
        });

        birdSoundsToggle.isOn = AppSettings.isBirdsSoundsOn;
        birdSoundsToggle.onValueChanged.AddListener(delegate {
            OnToggleBirdSounds(birdSoundsToggle.isOn);
        });
        
        var enumNames = Enum.GetNames(typeof(Difficulty)).ToList();
        difficultyDropdown.AddOptions(enumNames);
        difficultyDropdown.value = (int)AppSettings.difficulty;
        difficultyDropdown.onValueChanged.AddListener(delegate {
            OnDifficultyChanged((Difficulty)difficultyDropdown.value);
        });
    }

    public void ExitToMainScreen() => AppSettings.ExitToMainScreen();

    private void OnDifficultyChanged(Difficulty newDifficulty) {
        AppSettings.difficulty = newDifficulty;
    }
    
    private void OnToggleThemeMusicChanged(bool isOn) {
        AppSettings.isThemeMusicOn = isOn;
        _musicManager.ToggleThemeMusic(isOn);
    }

    private void OnToggleBirdSounds(bool isOn) {
        AppSettings.isBirdsSoundsOn = isOn;
        _musicManager.ToggleBirdSounds(isOn);
    }
}
