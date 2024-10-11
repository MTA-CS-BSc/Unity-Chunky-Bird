using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : Singleton<MusicManager>
{
    public AudioSource themeMusic;

    public void ToggleThemeMusic(bool isOn) => themeMusic.volume = isOn ? 1 : 0;
}
